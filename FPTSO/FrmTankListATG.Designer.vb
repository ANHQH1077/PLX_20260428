<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankListATG
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTankListATG))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.Name_nd = New U_TextBox.GridColumn()
        Me.ColNhomBeXuat = New U_TextBox.GridColumn()
        Me.Product_nd = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TenHangHoa = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.colClient = New U_TextBox.GridColumn()
        Me.TrueDBGrid2 = New U_TextBox.TrueDBGrid()
        Me.GridView2 = New U_TextBox.GridView()
        Me.GridColumn2 = New U_TextBox.GridColumn()
        Me.NhomBeXuat = New U_TextBox.GridColumn()
        Me.GridColumn4 = New U_TextBox.GridColumn()
        Me.GridColumn5 = New U_TextBox.GridColumn()
        Me.GridColumn7 = New U_TextBox.GridColumn()
        Me.Client = New U_TextBox.GridColumn()
        Me.CrUser = New U_TextBox.GridColumn()
        Me.colCHECKUPD = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemButtonEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.U_ButtonCus2 = New U_TextBox.U_ButtonCus(Me.components)
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(477, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 19)
        Me.Label2.TabIndex = 483
        Me.Label2.Text = "Danh sách bể đồng bộ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 19)
        Me.Label1.TabIndex = 482
        Me.Label1.Text = "Danh sách bể"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(5, 69)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit3, Me.RepositoryItemButtonEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(400, 333)
        Me.TrueDBGrid1.TabIndex = 481
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Name_nd, Me.ColNhomBeXuat, Me.Product_nd, Me.TenHangHoa, Me.CHECKUPD, Me.colClient})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "Name_nd"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "zTankList_v"
        Me.GridView1.Where = Nothing
        '
        'Name_nd
        '
        Me.Name_nd.AllowInsert = True
        Me.Name_nd.AllowUpdate = True
        Me.Name_nd.ButtonClick = True
        Me.Name_nd.Caption = "Mã bể"
        Me.Name_nd.CFLColumnHide = ""
        Me.Name_nd.CFLKeyField = ""
        Me.Name_nd.CFLPage = False
        Me.Name_nd.CFLReturn0 = ""
        Me.Name_nd.CFLReturn1 = ""
        Me.Name_nd.CFLReturn2 = ""
        Me.Name_nd.CFLReturn3 = ""
        Me.Name_nd.CFLReturn4 = ""
        Me.Name_nd.CFLReturn5 = ""
        Me.Name_nd.CFLReturn6 = ""
        Me.Name_nd.CFLReturn7 = ""
        Me.Name_nd.CFLShowLoad = False
        Me.Name_nd.ChangeFormStatus = True
        Me.Name_nd.ColumnKey = True
        Me.Name_nd.ComboLine = 5
        Me.Name_nd.CopyFromItem = ""
        Me.Name_nd.DefaultButtonClick = False
        Me.Name_nd.Digit = False
        Me.Name_nd.FieldType = "C"
        Me.Name_nd.FieldView = "Name_nd"
        Me.Name_nd.FormarNumber = True
        Me.Name_nd.FormList = False
        Me.Name_nd.KeyInsert = ""
        Me.Name_nd.LocalDecimal = False
        Me.Name_nd.Name = "Name_nd"
        Me.Name_nd.NoUpdate = ""
        Me.Name_nd.NumberDecimal = 0
        Me.Name_nd.ParentControl = ""
        Me.Name_nd.RefreshSource = False
        Me.Name_nd.Required = False
        Me.Name_nd.SequenceName = ""
        Me.Name_nd.ShowCalc = True
        Me.Name_nd.ShowDataTime = False
        Me.Name_nd.ShowOnlyTime = False
        Me.Name_nd.SQLString = ""
        Me.Name_nd.UpdateIfNull = ""
        Me.Name_nd.UpdateWhenFormLock = False
        Me.Name_nd.UpperValue = False
        Me.Name_nd.ValidateValue = True
        Me.Name_nd.Visible = True
        Me.Name_nd.VisibleIndex = 0
        Me.Name_nd.Width = 95
        '
        'ColNhomBeXuat
        '
        Me.ColNhomBeXuat.AllowInsert = True
        Me.ColNhomBeXuat.AllowUpdate = True
        Me.ColNhomBeXuat.ButtonClick = True
        Me.ColNhomBeXuat.Caption = "Nhóm bể"
        Me.ColNhomBeXuat.CFLColumnHide = ""
        Me.ColNhomBeXuat.CFLKeyField = ""
        Me.ColNhomBeXuat.CFLPage = False
        Me.ColNhomBeXuat.CFLReturn0 = ""
        Me.ColNhomBeXuat.CFLReturn1 = ""
        Me.ColNhomBeXuat.CFLReturn2 = ""
        Me.ColNhomBeXuat.CFLReturn3 = ""
        Me.ColNhomBeXuat.CFLReturn4 = ""
        Me.ColNhomBeXuat.CFLReturn5 = ""
        Me.ColNhomBeXuat.CFLReturn6 = ""
        Me.ColNhomBeXuat.CFLReturn7 = ""
        Me.ColNhomBeXuat.CFLShowLoad = False
        Me.ColNhomBeXuat.ChangeFormStatus = True
        Me.ColNhomBeXuat.ColumnKey = False
        Me.ColNhomBeXuat.ComboLine = 5
        Me.ColNhomBeXuat.CopyFromItem = ""
        Me.ColNhomBeXuat.DefaultButtonClick = False
        Me.ColNhomBeXuat.Digit = False
        Me.ColNhomBeXuat.FieldType = "C"
        Me.ColNhomBeXuat.FieldView = "NhomBeXuat"
        Me.ColNhomBeXuat.FormarNumber = True
        Me.ColNhomBeXuat.FormList = False
        Me.ColNhomBeXuat.KeyInsert = ""
        Me.ColNhomBeXuat.LocalDecimal = False
        Me.ColNhomBeXuat.Name = "ColNhomBeXuat"
        Me.ColNhomBeXuat.NoUpdate = ""
        Me.ColNhomBeXuat.NumberDecimal = 0
        Me.ColNhomBeXuat.OptionsColumn.ReadOnly = True
        Me.ColNhomBeXuat.ParentControl = ""
        Me.ColNhomBeXuat.RefreshSource = False
        Me.ColNhomBeXuat.Required = False
        Me.ColNhomBeXuat.SequenceName = ""
        Me.ColNhomBeXuat.ShowCalc = True
        Me.ColNhomBeXuat.ShowDataTime = False
        Me.ColNhomBeXuat.ShowOnlyTime = False
        Me.ColNhomBeXuat.SQLString = ""
        Me.ColNhomBeXuat.UpdateIfNull = ""
        Me.ColNhomBeXuat.UpdateWhenFormLock = False
        Me.ColNhomBeXuat.UpperValue = False
        Me.ColNhomBeXuat.ValidateValue = True
        Me.ColNhomBeXuat.Visible = True
        Me.ColNhomBeXuat.VisibleIndex = 1
        Me.ColNhomBeXuat.Width = 100
        '
        'Product_nd
        '
        Me.Product_nd.AllowInsert = True
        Me.Product_nd.AllowUpdate = True
        Me.Product_nd.ButtonClick = True
        Me.Product_nd.Caption = "Mã hàng hóa"
        Me.Product_nd.CFLColumnHide = ""
        Me.Product_nd.CFLKeyField = "MaHangHoa"
        Me.Product_nd.CFLPage = False
        Me.Product_nd.CFLReturn0 = ""
        Me.Product_nd.CFLReturn1 = "TenHangHoa"
        Me.Product_nd.CFLReturn2 = ""
        Me.Product_nd.CFLReturn3 = ""
        Me.Product_nd.CFLReturn4 = ""
        Me.Product_nd.CFLReturn5 = ""
        Me.Product_nd.CFLReturn6 = ""
        Me.Product_nd.CFLReturn7 = ""
        Me.Product_nd.CFLShowLoad = False
        Me.Product_nd.ChangeFormStatus = True
        Me.Product_nd.ColumnEdit = Me.RepositoryItemButtonEdit1
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
        Me.Product_nd.SQLString = "SELECT MaHangHoa,TenHangHoa FROM tblHangHoa  where dbo.FPT_MaHangHoaBomXuat(MaHan" & _
            "gHoa)=1"
        Me.Product_nd.UpdateIfNull = ""
        Me.Product_nd.UpdateWhenFormLock = False
        Me.Product_nd.UpperValue = False
        Me.Product_nd.ValidateValue = True
        Me.Product_nd.Visible = True
        Me.Product_nd.VisibleIndex = 2
        Me.Product_nd.Width = 95
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'TenHangHoa
        '
        Me.TenHangHoa.AllowInsert = True
        Me.TenHangHoa.AllowUpdate = True
        Me.TenHangHoa.ButtonClick = True
        Me.TenHangHoa.Caption = "Hàng hóa"
        Me.TenHangHoa.CFLColumnHide = ""
        Me.TenHangHoa.CFLKeyField = ""
        Me.TenHangHoa.CFLPage = False
        Me.TenHangHoa.CFLReturn0 = ""
        Me.TenHangHoa.CFLReturn1 = ""
        Me.TenHangHoa.CFLReturn2 = ""
        Me.TenHangHoa.CFLReturn3 = ""
        Me.TenHangHoa.CFLReturn4 = ""
        Me.TenHangHoa.CFLReturn5 = ""
        Me.TenHangHoa.CFLReturn6 = ""
        Me.TenHangHoa.CFLReturn7 = ""
        Me.TenHangHoa.CFLShowLoad = False
        Me.TenHangHoa.ChangeFormStatus = True
        Me.TenHangHoa.ColumnEdit = Me.RepositoryItemButtonEdit3
        Me.TenHangHoa.ColumnKey = False
        Me.TenHangHoa.ComboLine = 5
        Me.TenHangHoa.CopyFromItem = ""
        Me.TenHangHoa.DefaultButtonClick = False
        Me.TenHangHoa.Digit = False
        Me.TenHangHoa.FieldType = "C"
        Me.TenHangHoa.FieldView = "TenHangHoa"
        Me.TenHangHoa.FormarNumber = True
        Me.TenHangHoa.FormList = False
        Me.TenHangHoa.KeyInsert = ""
        Me.TenHangHoa.LocalDecimal = False
        Me.TenHangHoa.Name = "TenHangHoa"
        Me.TenHangHoa.NoUpdate = ""
        Me.TenHangHoa.NumberDecimal = 0
        Me.TenHangHoa.OptionsColumn.ReadOnly = True
        Me.TenHangHoa.ParentControl = ""
        Me.TenHangHoa.RefreshSource = False
        Me.TenHangHoa.Required = False
        Me.TenHangHoa.SequenceName = ""
        Me.TenHangHoa.ShowCalc = True
        Me.TenHangHoa.ShowDataTime = False
        Me.TenHangHoa.ShowOnlyTime = False
        Me.TenHangHoa.SQLString = ""
        Me.TenHangHoa.UpdateIfNull = ""
        Me.TenHangHoa.UpdateWhenFormLock = False
        Me.TenHangHoa.UpperValue = False
        Me.TenHangHoa.ValidateValue = True
        Me.TenHangHoa.Visible = True
        Me.TenHangHoa.VisibleIndex = 3
        Me.TenHangHoa.Width = 95
        '
        'RepositoryItemButtonEdit3
        '
        Me.RepositoryItemButtonEdit3.AutoHeight = False
        Me.RepositoryItemButtonEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit3.Name = "RepositoryItemButtonEdit3"
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
        '
        'colClient
        '
        Me.colClient.AllowInsert = True
        Me.colClient.AllowUpdate = True
        Me.colClient.ButtonClick = True
        Me.colClient.Caption = "GridColumn1"
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
        '
        'TrueDBGrid2
        '
        Me.TrueDBGrid2.DefaultRemove = True
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid2.Location = New System.Drawing.Point(475, 69)
        Me.TrueDBGrid2.MainView = Me.GridView2
        Me.TrueDBGrid2.Name = "TrueDBGrid2"
        Me.TrueDBGrid2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit2, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit4})
        Me.TrueDBGrid2.Size = New System.Drawing.Size(442, 333)
        Me.TrueDBGrid2.TabIndex = 480
        Me.TrueDBGrid2.UseEmbeddedNavigator = True
        Me.TrueDBGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.AllowInsert = False
        Me.GridView2.CheckUpd = True
        Me.GridView2.ColumnAutoWidth = False
        Me.GridView2.ColumnKey = ""
        Me.GridView2.ColumnKeyIns = True
        Me.GridView2.ColumnKeyType = "N"
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.NhomBeXuat, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7, Me.Client, Me.CrUser, Me.colCHECKUPD})
        Me.GridView2.CompanyCode = ""
        Me.GridView2.DefaultRemove = False
        Me.GridView2.GetB1 = False
        Me.GridView2.GridControl = Me.TrueDBGrid2
        Me.GridView2.LastQuery = ""
        Me.GridView2.Name = "GridView2"
        Me.GridView2.ObjectChild = False
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsSelection.MultiSelect = True
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        Me.GridView2.OrderBy = "TankCode"
        Me.GridView2.ParentItem = Nothing
        Me.GridView2.RowNumber = ""
        Me.GridView2.TableName = "zTankListATG"
        Me.GridView2.ViewName = "zTankListATG_v"
        Me.GridView2.Where = Nothing
        '
        'GridColumn2
        '
        Me.GridColumn2.AllowInsert = True
        Me.GridColumn2.AllowUpdate = True
        Me.GridColumn2.ButtonClick = True
        Me.GridColumn2.Caption = "Bể xuất"
        Me.GridColumn2.CFLColumnHide = ""
        Me.GridColumn2.CFLKeyField = "Name_nd"
        Me.GridColumn2.CFLPage = False
        Me.GridColumn2.CFLReturn0 = ""
        Me.GridColumn2.CFLReturn1 = ""
        Me.GridColumn2.CFLReturn2 = ""
        Me.GridColumn2.CFLReturn3 = ""
        Me.GridColumn2.CFLReturn4 = ""
        Me.GridColumn2.CFLReturn5 = ""
        Me.GridColumn2.CFLReturn6 = ""
        Me.GridColumn2.CFLReturn7 = ""
        Me.GridColumn2.CFLShowLoad = True
        Me.GridColumn2.ChangeFormStatus = True
        Me.GridColumn2.ColumnKey = False
        Me.GridColumn2.ComboLine = 5
        Me.GridColumn2.CopyFromItem = ""
        Me.GridColumn2.DefaultButtonClick = False
        Me.GridColumn2.Digit = False
        Me.GridColumn2.FieldType = "C"
        Me.GridColumn2.FieldView = "TankCode"
        Me.GridColumn2.FormarNumber = True
        Me.GridColumn2.FormList = False
        Me.GridColumn2.KeyInsert = ""
        Me.GridColumn2.LocalDecimal = False
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.NoUpdate = ""
        Me.GridColumn2.NumberDecimal = 0
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.ParentControl = ""
        Me.GridColumn2.RefreshSource = False
        Me.GridColumn2.Required = False
        Me.GridColumn2.SequenceName = ""
        Me.GridColumn2.ShowCalc = True
        Me.GridColumn2.ShowDataTime = False
        Me.GridColumn2.ShowOnlyTime = False
        Me.GridColumn2.SQLString = ""
        Me.GridColumn2.UpdateIfNull = ""
        Me.GridColumn2.UpdateWhenFormLock = False
        Me.GridColumn2.UpperValue = False
        Me.GridColumn2.ValidateValue = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'NhomBeXuat
        '
        Me.NhomBeXuat.AllowInsert = True
        Me.NhomBeXuat.AllowUpdate = True
        Me.NhomBeXuat.ButtonClick = True
        Me.NhomBeXuat.Caption = "Nhóm bể"
        Me.NhomBeXuat.CFLColumnHide = ""
        Me.NhomBeXuat.CFLKeyField = ""
        Me.NhomBeXuat.CFLPage = False
        Me.NhomBeXuat.CFLReturn0 = ""
        Me.NhomBeXuat.CFLReturn1 = ""
        Me.NhomBeXuat.CFLReturn2 = ""
        Me.NhomBeXuat.CFLReturn3 = ""
        Me.NhomBeXuat.CFLReturn4 = ""
        Me.NhomBeXuat.CFLReturn5 = ""
        Me.NhomBeXuat.CFLReturn6 = ""
        Me.NhomBeXuat.CFLReturn7 = ""
        Me.NhomBeXuat.CFLShowLoad = False
        Me.NhomBeXuat.ChangeFormStatus = True
        Me.NhomBeXuat.ColumnKey = False
        Me.NhomBeXuat.ComboLine = 5
        Me.NhomBeXuat.CopyFromItem = ""
        Me.NhomBeXuat.DefaultButtonClick = False
        Me.NhomBeXuat.Digit = False
        Me.NhomBeXuat.FieldType = "C"
        Me.NhomBeXuat.FieldView = "NhomBeXuat"
        Me.NhomBeXuat.FormarNumber = True
        Me.NhomBeXuat.FormList = False
        Me.NhomBeXuat.KeyInsert = ""
        Me.NhomBeXuat.LocalDecimal = False
        Me.NhomBeXuat.Name = "NhomBeXuat"
        Me.NhomBeXuat.NoUpdate = ""
        Me.NhomBeXuat.NumberDecimal = 0
        Me.NhomBeXuat.OptionsColumn.ReadOnly = True
        Me.NhomBeXuat.ParentControl = ""
        Me.NhomBeXuat.RefreshSource = False
        Me.NhomBeXuat.Required = False
        Me.NhomBeXuat.SequenceName = ""
        Me.NhomBeXuat.ShowCalc = True
        Me.NhomBeXuat.ShowDataTime = False
        Me.NhomBeXuat.ShowOnlyTime = False
        Me.NhomBeXuat.SQLString = ""
        Me.NhomBeXuat.UpdateIfNull = ""
        Me.NhomBeXuat.UpdateWhenFormLock = False
        Me.NhomBeXuat.UpperValue = False
        Me.NhomBeXuat.ValidateValue = True
        Me.NhomBeXuat.Visible = True
        Me.NhomBeXuat.VisibleIndex = 1
        Me.NhomBeXuat.Width = 100
        '
        'GridColumn4
        '
        Me.GridColumn4.AllowInsert = True
        Me.GridColumn4.AllowUpdate = True
        Me.GridColumn4.ButtonClick = True
        Me.GridColumn4.Caption = "Mã hàng hóa"
        Me.GridColumn4.CFLColumnHide = ""
        Me.GridColumn4.CFLKeyField = ""
        Me.GridColumn4.CFLPage = False
        Me.GridColumn4.CFLReturn0 = ""
        Me.GridColumn4.CFLReturn1 = ""
        Me.GridColumn4.CFLReturn2 = ""
        Me.GridColumn4.CFLReturn3 = ""
        Me.GridColumn4.CFLReturn4 = ""
        Me.GridColumn4.CFLReturn5 = ""
        Me.GridColumn4.CFLReturn6 = ""
        Me.GridColumn4.CFLReturn7 = ""
        Me.GridColumn4.CFLShowLoad = False
        Me.GridColumn4.ChangeFormStatus = True
        Me.GridColumn4.ColumnKey = False
        Me.GridColumn4.ComboLine = 5
        Me.GridColumn4.CopyFromItem = ""
        Me.GridColumn4.DefaultButtonClick = False
        Me.GridColumn4.Digit = False
        Me.GridColumn4.FieldType = "C"
        Me.GridColumn4.FieldView = "Product"
        Me.GridColumn4.FormarNumber = True
        Me.GridColumn4.FormList = False
        Me.GridColumn4.KeyInsert = ""
        Me.GridColumn4.LocalDecimal = False
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.NoUpdate = ""
        Me.GridColumn4.NumberDecimal = 0
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.ParentControl = ""
        Me.GridColumn4.RefreshSource = False
        Me.GridColumn4.Required = False
        Me.GridColumn4.SequenceName = ""
        Me.GridColumn4.ShowCalc = True
        Me.GridColumn4.ShowDataTime = False
        Me.GridColumn4.ShowOnlyTime = False
        Me.GridColumn4.SQLString = ""
        Me.GridColumn4.UpdateIfNull = ""
        Me.GridColumn4.UpdateWhenFormLock = False
        Me.GridColumn4.UpperValue = False
        Me.GridColumn4.ValidateValue = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.AllowInsert = True
        Me.GridColumn5.AllowUpdate = True
        Me.GridColumn5.ButtonClick = True
        Me.GridColumn5.Caption = "Tên hàng hóa"
        Me.GridColumn5.CFLColumnHide = ""
        Me.GridColumn5.CFLKeyField = ""
        Me.GridColumn5.CFLPage = False
        Me.GridColumn5.CFLReturn0 = ""
        Me.GridColumn5.CFLReturn1 = ""
        Me.GridColumn5.CFLReturn2 = ""
        Me.GridColumn5.CFLReturn3 = ""
        Me.GridColumn5.CFLReturn4 = ""
        Me.GridColumn5.CFLReturn5 = ""
        Me.GridColumn5.CFLReturn6 = ""
        Me.GridColumn5.CFLReturn7 = ""
        Me.GridColumn5.CFLShowLoad = False
        Me.GridColumn5.ChangeFormStatus = True
        Me.GridColumn5.ColumnKey = False
        Me.GridColumn5.ComboLine = 5
        Me.GridColumn5.CopyFromItem = ""
        Me.GridColumn5.DefaultButtonClick = False
        Me.GridColumn5.Digit = False
        Me.GridColumn5.FieldType = "C"
        Me.GridColumn5.FieldView = "TenHangHoa"
        Me.GridColumn5.FormarNumber = True
        Me.GridColumn5.FormList = False
        Me.GridColumn5.KeyInsert = ""
        Me.GridColumn5.LocalDecimal = False
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.NoUpdate = ""
        Me.GridColumn5.NumberDecimal = 0
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.ParentControl = ""
        Me.GridColumn5.RefreshSource = False
        Me.GridColumn5.Required = False
        Me.GridColumn5.SequenceName = ""
        Me.GridColumn5.ShowCalc = True
        Me.GridColumn5.ShowDataTime = False
        Me.GridColumn5.ShowOnlyTime = False
        Me.GridColumn5.SQLString = ""
        Me.GridColumn5.UpdateIfNull = ""
        Me.GridColumn5.UpdateWhenFormLock = False
        Me.GridColumn5.UpperValue = False
        Me.GridColumn5.ValidateValue = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 170
        '
        'GridColumn7
        '
        Me.GridColumn7.AllowInsert = False
        Me.GridColumn7.AllowUpdate = False
        Me.GridColumn7.ButtonClick = True
        Me.GridColumn7.Caption = "ID"
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
        Me.GridColumn7.ColumnKey = True
        Me.GridColumn7.ComboLine = 5
        Me.GridColumn7.CopyFromItem = ""
        Me.GridColumn7.DefaultButtonClick = False
        Me.GridColumn7.Digit = False
        Me.GridColumn7.FieldType = "N"
        Me.GridColumn7.FieldView = "ID"
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
        'Client
        '
        Me.Client.AllowInsert = True
        Me.Client.AllowUpdate = True
        Me.Client.ButtonClick = True
        Me.Client.Caption = "GridColumn1"
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
        Me.Client.SQLString = ""
        Me.Client.UpdateIfNull = ""
        Me.Client.UpdateWhenFormLock = False
        Me.Client.UpperValue = False
        Me.Client.ValidateValue = True
        Me.Client.Visible = True
        '
        'CrUser
        '
        Me.CrUser.AllowInsert = True
        Me.CrUser.AllowUpdate = True
        Me.CrUser.ButtonClick = True
        Me.CrUser.Caption = "CrUser"
        Me.CrUser.CFLColumnHide = ""
        Me.CrUser.CFLKeyField = ""
        Me.CrUser.CFLPage = False
        Me.CrUser.CFLReturn0 = ""
        Me.CrUser.CFLReturn1 = ""
        Me.CrUser.CFLReturn2 = ""
        Me.CrUser.CFLReturn3 = ""
        Me.CrUser.CFLReturn4 = ""
        Me.CrUser.CFLReturn5 = ""
        Me.CrUser.CFLReturn6 = ""
        Me.CrUser.CFLReturn7 = ""
        Me.CrUser.CFLShowLoad = False
        Me.CrUser.ChangeFormStatus = True
        Me.CrUser.ColumnKey = False
        Me.CrUser.ComboLine = 5
        Me.CrUser.CopyFromItem = ""
        Me.CrUser.DefaultButtonClick = False
        Me.CrUser.Digit = False
        Me.CrUser.FieldType = "C"
        Me.CrUser.FieldView = "CrUser"
        Me.CrUser.FormarNumber = True
        Me.CrUser.FormList = False
        Me.CrUser.KeyInsert = ""
        Me.CrUser.LocalDecimal = False
        Me.CrUser.Name = "CrUser"
        Me.CrUser.NoUpdate = ""
        Me.CrUser.NumberDecimal = 0
        Me.CrUser.ParentControl = ""
        Me.CrUser.RefreshSource = False
        Me.CrUser.Required = False
        Me.CrUser.SequenceName = ""
        Me.CrUser.ShowCalc = True
        Me.CrUser.ShowDataTime = False
        Me.CrUser.ShowOnlyTime = False
        Me.CrUser.SQLString = ""
        Me.CrUser.UpdateIfNull = ""
        Me.CrUser.UpdateWhenFormLock = False
        Me.CrUser.UpperValue = False
        Me.CrUser.ValidateValue = True
        Me.CrUser.Visible = True
        Me.CrUser.VisibleIndex = 4
        '
        'colCHECKUPD
        '
        Me.colCHECKUPD.AllowInsert = True
        Me.colCHECKUPD.AllowUpdate = True
        Me.colCHECKUPD.ButtonClick = True
        Me.colCHECKUPD.Caption = "GridColumn3"
        Me.colCHECKUPD.CFLColumnHide = ""
        Me.colCHECKUPD.CFLKeyField = ""
        Me.colCHECKUPD.CFLPage = False
        Me.colCHECKUPD.CFLReturn0 = ""
        Me.colCHECKUPD.CFLReturn1 = ""
        Me.colCHECKUPD.CFLReturn2 = ""
        Me.colCHECKUPD.CFLReturn3 = ""
        Me.colCHECKUPD.CFLReturn4 = ""
        Me.colCHECKUPD.CFLReturn5 = ""
        Me.colCHECKUPD.CFLReturn6 = ""
        Me.colCHECKUPD.CFLReturn7 = ""
        Me.colCHECKUPD.CFLShowLoad = False
        Me.colCHECKUPD.ChangeFormStatus = True
        Me.colCHECKUPD.ColumnKey = False
        Me.colCHECKUPD.ComboLine = 5
        Me.colCHECKUPD.CopyFromItem = ""
        Me.colCHECKUPD.DefaultButtonClick = False
        Me.colCHECKUPD.Digit = False
        Me.colCHECKUPD.FieldType = "C"
        Me.colCHECKUPD.FieldView = "CHECKUPD"
        Me.colCHECKUPD.FormarNumber = True
        Me.colCHECKUPD.FormList = False
        Me.colCHECKUPD.KeyInsert = ""
        Me.colCHECKUPD.LocalDecimal = False
        Me.colCHECKUPD.Name = "colCHECKUPD"
        Me.colCHECKUPD.NoUpdate = ""
        Me.colCHECKUPD.NumberDecimal = 0
        Me.colCHECKUPD.ParentControl = ""
        Me.colCHECKUPD.RefreshSource = False
        Me.colCHECKUPD.Required = False
        Me.colCHECKUPD.SequenceName = ""
        Me.colCHECKUPD.ShowCalc = True
        Me.colCHECKUPD.ShowDataTime = False
        Me.colCHECKUPD.ShowOnlyTime = False
        Me.colCHECKUPD.SQLString = ""
        Me.colCHECKUPD.UpdateIfNull = ""
        Me.colCHECKUPD.UpdateWhenFormLock = False
        Me.colCHECKUPD.UpperValue = False
        Me.colCHECKUPD.ValidateValue = True
        Me.colCHECKUPD.Visible = True
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemButtonEdit4
        '
        Me.RepositoryItemButtonEdit4.AutoHeight = False
        Me.RepositoryItemButtonEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit4.Name = "RepositoryItemButtonEdit4"
        '
        'U_ButtonCus2
        '
        Me.U_ButtonCus2.DefaultUpdate = True
        Me.U_ButtonCus2.EnableWhenFormLock = False
        Me.U_ButtonCus2.Image = CType(resources.GetObject("U_ButtonCus2.Image"), System.Drawing.Image)
        Me.U_ButtonCus2.Location = New System.Drawing.Point(423, 258)
        Me.U_ButtonCus2.Name = "U_ButtonCus2"
        Me.U_ButtonCus2.Size = New System.Drawing.Size(40, 33)
        Me.U_ButtonCus2.TabIndex = 479
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Image = CType(resources.GetObject("U_ButtonCus1.Image"), System.Drawing.Image)
        Me.U_ButtonCus1.Location = New System.Drawing.Point(423, 177)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(40, 33)
        Me.U_ButtonCus1.TabIndex = 478
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(929, 28)
        Me.ToolStrip2.TabIndex = 484
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
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(122, 25)
        Me.ToolStripButton2.Text = "Lịch sử thay đổi"
        '
        'FrmTankListATG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 406)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.TrueDBGrid2)
        Me.Controls.Add(Me.U_ButtonCus2)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmTankListATG"
        Me.Text = "Danh sách bể đồng bộ ATG"
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus2, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid2, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cName As U_TextBox.GridColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents Name_nd As U_TextBox.GridColumn
    Friend WithEvents Product_nd As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents TenHangHoa As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents TrueDBGrid2 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView2 As U_TextBox.GridView
    Friend WithEvents GridColumn2 As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumn4 As U_TextBox.GridColumn
    Friend WithEvents GridColumn5 As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumn7 As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents U_ButtonCus2 As U_TextBox.U_ButtonCus
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Client As U_TextBox.GridColumn
    Friend WithEvents colClient As U_TextBox.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CrUser As U_TextBox.GridColumn
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents colCHECKUPD As U_TextBox.GridColumn
    Friend WithEvents NhomBeXuat As U_TextBox.GridColumn
    Friend WithEvents ColNhomBeXuat As U_TextBox.GridColumn
End Class
