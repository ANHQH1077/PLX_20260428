<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehicleInfor
    Inherits U_CusForm.XtraCusForm1

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVehicleInfor))
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.TrueDBGrid2 = New U_TextBox.TrueDBGrid()
        Me.GridView2 = New U_TextBox.GridView()
        Me.ColID = New U_TextBox.GridColumn()
        Me.ColMaPhuongTien = New U_TextBox.GridColumn()
        Me.HoVaTen = New U_TextBox.GridColumn()
        Me.ColNoiDung = New U_TextBox.GridColumn()
        Me.ColFromDate = New U_TextBox.GridColumn()
        Me.ColToDate = New U_TextBox.GridColumn()
        Me.ColsType = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.sDefault = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Dem = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colCHECKUPD = New U_TextBox.GridColumn()
        Me.ColUpdUser = New U_TextBox.GridColumn()
        Me.ColUpdDate = New U_TextBox.GridColumn()
        Me.RepositoryItemCalcEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ID = New U_TextBox.GridColumn()
        Me.MaPhuongTien = New U_TextBox.GridColumn()
        Me.NoiDung = New U_TextBox.GridColumn()
        Me.FromDate = New U_TextBox.GridColumn()
        Me.ToDate = New U_TextBox.GridColumn()
        Me.sType = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.UpdUser = New U_TextBox.GridColumn()
        Me.UpdDate = New U_TextBox.GridColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.txtPhuongTien = New U_TextBox.U_TextBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.txtPhuongTien.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XtraTabControl1.Appearance.Options.UseBackColor = True
        Me.XtraTabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XtraTabControl1.Location = New System.Drawing.Point(1, 35)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage3
        Me.XtraTabControl1.Size = New System.Drawing.Size(803, 310)
        Me.XtraTabControl1.TabIndex = 439
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage3})
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Appearance.PageClient.BackColor = System.Drawing.Color.DimGray
        Me.XtraTabPage3.Appearance.PageClient.Options.UseBackColor = True
        Me.XtraTabPage3.Controls.Add(Me.TrueDBGrid2)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(797, 284)
        Me.XtraTabPage3.Text = "Thông tin gắn với Lái xe"
        '
        'TrueDBGrid2
        '
        Me.TrueDBGrid2.DefaultRemove = True
        Me.TrueDBGrid2.Location = New System.Drawing.Point(3, 3)
        Me.TrueDBGrid2.MainView = Me.GridView2
        Me.TrueDBGrid2.Name = "TrueDBGrid2"
        Me.TrueDBGrid2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2, Me.RepositoryItemCalcEdit1, Me.RepositoryItemCheckEdit3, Me.RepositoryItemCheckEdit4})
        Me.TrueDBGrid2.Size = New System.Drawing.Size(791, 278)
        Me.TrueDBGrid2.TabIndex = 1
        Me.TrueDBGrid2.UseEmbeddedNavigator = True
        Me.TrueDBGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.AllowInsert = True
        Me.GridView2.CheckUpd = True
        Me.GridView2.ColumnAutoWidth = False
        Me.GridView2.ColumnKey = "ID"
        Me.GridView2.ColumnKeyIns = True
        Me.GridView2.ColumnKeyType = "N"
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColID, Me.ColMaPhuongTien, Me.HoVaTen, Me.ColNoiDung, Me.ColFromDate, Me.ColToDate, Me.ColsType, Me.sDefault, Me.Dem, Me.colCHECKUPD, Me.ColUpdUser, Me.ColUpdDate})
        Me.GridView2.CompanyCode = ""
        Me.GridView2.DefaultRemove = True
        Me.GridView2.GetB1 = False
        Me.GridView2.GridControl = Me.TrueDBGrid2
        Me.GridView2.LastQuery = ""
        Me.GridView2.Name = "GridView2"
        Me.GridView2.ObjectChild = False
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        Me.GridView2.OrderBy = "HoVaTen"
        Me.GridView2.ParentItem = Nothing
        Me.GridView2.RowNumber = ""
        Me.GridView2.TableName = "tblPhuongTien_LaiXe"
        Me.GridView2.ViewName = "FPT_tblPhuongTien_LaiXe_V"
        Me.GridView2.Where = Nothing
        '
        'ColID
        '
        Me.ColID.AllowInsert = False
        Me.ColID.AllowUpdate = False
        Me.ColID.ButtonClick = True
        Me.ColID.Caption = "GridColumn1"
        Me.ColID.CFLColumnHide = ""
        Me.ColID.CFLKeyField = ""
        Me.ColID.CFLPage = False
        Me.ColID.CFLReturn0 = ""
        Me.ColID.CFLReturn1 = ""
        Me.ColID.CFLReturn2 = ""
        Me.ColID.CFLReturn3 = ""
        Me.ColID.CFLReturn4 = ""
        Me.ColID.CFLReturn5 = ""
        Me.ColID.CFLReturn6 = ""
        Me.ColID.CFLReturn7 = ""
        Me.ColID.CFLShowLoad = False
        Me.ColID.ChangeFormStatus = True
        Me.ColID.ColumnKey = True
        Me.ColID.ComboLine = 5
        Me.ColID.CopyFromItem = ""
        Me.ColID.DefaultButtonClick = False
        Me.ColID.Digit = False
        Me.ColID.FieldType = "N"
        Me.ColID.FieldView = "ID"
        Me.ColID.FormarNumber = True
        Me.ColID.FormList = False
        Me.ColID.KeyInsert = ""
        Me.ColID.LocalDecimal = False
        Me.ColID.Name = "ColID"
        Me.ColID.NoUpdate = ""
        Me.ColID.NumberDecimal = 0
        Me.ColID.ParentControl = ""
        Me.ColID.RefreshSource = False
        Me.ColID.Required = False
        Me.ColID.SequenceName = ""
        Me.ColID.ShowCalc = True
        Me.ColID.ShowDataTime = False
        Me.ColID.ShowOnlyTime = False
        Me.ColID.SQLString = ""
        Me.ColID.UpdateIfNull = ""
        Me.ColID.UpdateWhenFormLock = False
        Me.ColID.UpperValue = False
        Me.ColID.ValidateValue = True
        Me.ColID.Visible = True
        Me.ColID.Width = 65
        '
        'ColMaPhuongTien
        '
        Me.ColMaPhuongTien.AllowInsert = True
        Me.ColMaPhuongTien.AllowUpdate = False
        Me.ColMaPhuongTien.ButtonClick = True
        Me.ColMaPhuongTien.Caption = "GridColumn2"
        Me.ColMaPhuongTien.CFLColumnHide = ""
        Me.ColMaPhuongTien.CFLKeyField = ""
        Me.ColMaPhuongTien.CFLPage = False
        Me.ColMaPhuongTien.CFLReturn0 = ""
        Me.ColMaPhuongTien.CFLReturn1 = ""
        Me.ColMaPhuongTien.CFLReturn2 = ""
        Me.ColMaPhuongTien.CFLReturn3 = ""
        Me.ColMaPhuongTien.CFLReturn4 = ""
        Me.ColMaPhuongTien.CFLReturn5 = ""
        Me.ColMaPhuongTien.CFLReturn6 = ""
        Me.ColMaPhuongTien.CFLReturn7 = ""
        Me.ColMaPhuongTien.CFLShowLoad = False
        Me.ColMaPhuongTien.ChangeFormStatus = True
        Me.ColMaPhuongTien.ColumnKey = False
        Me.ColMaPhuongTien.ComboLine = 5
        Me.ColMaPhuongTien.CopyFromItem = ":txtPhuongTien"
        Me.ColMaPhuongTien.DefaultButtonClick = False
        Me.ColMaPhuongTien.Digit = False
        Me.ColMaPhuongTien.FieldType = "C"
        Me.ColMaPhuongTien.FieldView = "MaPhuongTien"
        Me.ColMaPhuongTien.FormarNumber = True
        Me.ColMaPhuongTien.FormList = False
        Me.ColMaPhuongTien.KeyInsert = ""
        Me.ColMaPhuongTien.LocalDecimal = False
        Me.ColMaPhuongTien.Name = "ColMaPhuongTien"
        Me.ColMaPhuongTien.NoUpdate = ""
        Me.ColMaPhuongTien.NumberDecimal = 0
        Me.ColMaPhuongTien.ParentControl = ""
        Me.ColMaPhuongTien.RefreshSource = False
        Me.ColMaPhuongTien.Required = False
        Me.ColMaPhuongTien.SequenceName = ""
        Me.ColMaPhuongTien.ShowCalc = True
        Me.ColMaPhuongTien.ShowDataTime = False
        Me.ColMaPhuongTien.ShowOnlyTime = False
        Me.ColMaPhuongTien.SQLString = ""
        Me.ColMaPhuongTien.UpdateIfNull = ""
        Me.ColMaPhuongTien.UpdateWhenFormLock = False
        Me.ColMaPhuongTien.UpperValue = False
        Me.ColMaPhuongTien.ValidateValue = True
        Me.ColMaPhuongTien.Visible = True
        '
        'HoVaTen
        '
        Me.HoVaTen.AllowInsert = True
        Me.HoVaTen.AllowUpdate = True
        Me.HoVaTen.ButtonClick = True
        Me.HoVaTen.Caption = "Họ tên lái xe"
        Me.HoVaTen.CFLColumnHide = ""
        Me.HoVaTen.CFLKeyField = ""
        Me.HoVaTen.CFLPage = False
        Me.HoVaTen.CFLReturn0 = ""
        Me.HoVaTen.CFLReturn1 = ""
        Me.HoVaTen.CFLReturn2 = ""
        Me.HoVaTen.CFLReturn3 = ""
        Me.HoVaTen.CFLReturn4 = ""
        Me.HoVaTen.CFLReturn5 = ""
        Me.HoVaTen.CFLReturn6 = ""
        Me.HoVaTen.CFLReturn7 = ""
        Me.HoVaTen.CFLShowLoad = False
        Me.HoVaTen.ChangeFormStatus = True
        Me.HoVaTen.ColumnKey = False
        Me.HoVaTen.ComboLine = 5
        Me.HoVaTen.CopyFromItem = ""
        Me.HoVaTen.DefaultButtonClick = False
        Me.HoVaTen.Digit = False
        Me.HoVaTen.FieldType = "C"
        Me.HoVaTen.FieldView = "HoVaTen"
        Me.HoVaTen.FormarNumber = True
        Me.HoVaTen.FormList = False
        Me.HoVaTen.KeyInsert = ""
        Me.HoVaTen.LocalDecimal = False
        Me.HoVaTen.Name = "HoVaTen"
        Me.HoVaTen.NoUpdate = ""
        Me.HoVaTen.NumberDecimal = 0
        Me.HoVaTen.ParentControl = ""
        Me.HoVaTen.RefreshSource = False
        Me.HoVaTen.Required = False
        Me.HoVaTen.SequenceName = ""
        Me.HoVaTen.ShowCalc = True
        Me.HoVaTen.ShowDataTime = False
        Me.HoVaTen.ShowOnlyTime = False
        Me.HoVaTen.SQLString = ""
        Me.HoVaTen.UpdateIfNull = ""
        Me.HoVaTen.UpdateWhenFormLock = False
        Me.HoVaTen.UpperValue = False
        Me.HoVaTen.ValidateValue = True
        Me.HoVaTen.Visible = True
        Me.HoVaTen.VisibleIndex = 0
        Me.HoVaTen.Width = 150
        '
        'ColNoiDung
        '
        Me.ColNoiDung.AllowInsert = True
        Me.ColNoiDung.AllowUpdate = True
        Me.ColNoiDung.ButtonClick = True
        Me.ColNoiDung.Caption = "Nội dung"
        Me.ColNoiDung.CFLColumnHide = ""
        Me.ColNoiDung.CFLKeyField = ""
        Me.ColNoiDung.CFLPage = False
        Me.ColNoiDung.CFLReturn0 = ""
        Me.ColNoiDung.CFLReturn1 = ""
        Me.ColNoiDung.CFLReturn2 = ""
        Me.ColNoiDung.CFLReturn3 = ""
        Me.ColNoiDung.CFLReturn4 = ""
        Me.ColNoiDung.CFLReturn5 = ""
        Me.ColNoiDung.CFLReturn6 = ""
        Me.ColNoiDung.CFLReturn7 = ""
        Me.ColNoiDung.CFLShowLoad = False
        Me.ColNoiDung.ChangeFormStatus = True
        Me.ColNoiDung.ColumnKey = False
        Me.ColNoiDung.ComboLine = 5
        Me.ColNoiDung.CopyFromItem = ""
        Me.ColNoiDung.DefaultButtonClick = False
        Me.ColNoiDung.Digit = False
        Me.ColNoiDung.FieldType = "C"
        Me.ColNoiDung.FieldView = "NoiDung"
        Me.ColNoiDung.FormarNumber = True
        Me.ColNoiDung.FormList = False
        Me.ColNoiDung.KeyInsert = ""
        Me.ColNoiDung.LocalDecimal = False
        Me.ColNoiDung.Name = "ColNoiDung"
        Me.ColNoiDung.NoUpdate = ""
        Me.ColNoiDung.NumberDecimal = 0
        Me.ColNoiDung.ParentControl = ""
        Me.ColNoiDung.RefreshSource = False
        Me.ColNoiDung.Required = False
        Me.ColNoiDung.SequenceName = ""
        Me.ColNoiDung.ShowCalc = True
        Me.ColNoiDung.ShowDataTime = False
        Me.ColNoiDung.ShowOnlyTime = False
        Me.ColNoiDung.SQLString = ""
        Me.ColNoiDung.UpdateIfNull = ""
        Me.ColNoiDung.UpdateWhenFormLock = False
        Me.ColNoiDung.UpperValue = False
        Me.ColNoiDung.ValidateValue = True
        Me.ColNoiDung.Visible = True
        Me.ColNoiDung.VisibleIndex = 1
        Me.ColNoiDung.Width = 170
        '
        'ColFromDate
        '
        Me.ColFromDate.AllowInsert = True
        Me.ColFromDate.AllowUpdate = True
        Me.ColFromDate.ButtonClick = True
        Me.ColFromDate.Caption = "Ngày hiệu lực"
        Me.ColFromDate.CFLColumnHide = ""
        Me.ColFromDate.CFLKeyField = ""
        Me.ColFromDate.CFLPage = False
        Me.ColFromDate.CFLReturn0 = ""
        Me.ColFromDate.CFLReturn1 = ""
        Me.ColFromDate.CFLReturn2 = ""
        Me.ColFromDate.CFLReturn3 = ""
        Me.ColFromDate.CFLReturn4 = ""
        Me.ColFromDate.CFLReturn5 = ""
        Me.ColFromDate.CFLReturn6 = ""
        Me.ColFromDate.CFLReturn7 = ""
        Me.ColFromDate.CFLShowLoad = False
        Me.ColFromDate.ChangeFormStatus = True
        Me.ColFromDate.ColumnKey = False
        Me.ColFromDate.ComboLine = 5
        Me.ColFromDate.CopyFromItem = ""
        Me.ColFromDate.DefaultButtonClick = False
        Me.ColFromDate.Digit = False
        Me.ColFromDate.FieldType = "D"
        Me.ColFromDate.FieldView = "FromDate"
        Me.ColFromDate.FormarNumber = True
        Me.ColFromDate.FormList = False
        Me.ColFromDate.KeyInsert = ""
        Me.ColFromDate.LocalDecimal = False
        Me.ColFromDate.Name = "ColFromDate"
        Me.ColFromDate.NoUpdate = ""
        Me.ColFromDate.NumberDecimal = 0
        Me.ColFromDate.ParentControl = ""
        Me.ColFromDate.RefreshSource = False
        Me.ColFromDate.Required = False
        Me.ColFromDate.SequenceName = ""
        Me.ColFromDate.ShowCalc = True
        Me.ColFromDate.ShowDataTime = False
        Me.ColFromDate.ShowOnlyTime = False
        Me.ColFromDate.SQLString = ""
        Me.ColFromDate.UpdateIfNull = ""
        Me.ColFromDate.UpdateWhenFormLock = False
        Me.ColFromDate.UpperValue = False
        Me.ColFromDate.ValidateValue = True
        Me.ColFromDate.Visible = True
        Me.ColFromDate.VisibleIndex = 2
        Me.ColFromDate.Width = 120
        '
        'ColToDate
        '
        Me.ColToDate.AllowInsert = True
        Me.ColToDate.AllowUpdate = True
        Me.ColToDate.ButtonClick = True
        Me.ColToDate.Caption = "Ngày hết hiệu lực"
        Me.ColToDate.CFLColumnHide = ""
        Me.ColToDate.CFLKeyField = ""
        Me.ColToDate.CFLPage = False
        Me.ColToDate.CFLReturn0 = ""
        Me.ColToDate.CFLReturn1 = ""
        Me.ColToDate.CFLReturn2 = ""
        Me.ColToDate.CFLReturn3 = ""
        Me.ColToDate.CFLReturn4 = ""
        Me.ColToDate.CFLReturn5 = ""
        Me.ColToDate.CFLReturn6 = ""
        Me.ColToDate.CFLReturn7 = ""
        Me.ColToDate.CFLShowLoad = False
        Me.ColToDate.ChangeFormStatus = True
        Me.ColToDate.ColumnKey = False
        Me.ColToDate.ComboLine = 5
        Me.ColToDate.CopyFromItem = ""
        Me.ColToDate.DefaultButtonClick = False
        Me.ColToDate.Digit = False
        Me.ColToDate.FieldType = "D"
        Me.ColToDate.FieldView = "ToDate"
        Me.ColToDate.FormarNumber = True
        Me.ColToDate.FormList = False
        Me.ColToDate.KeyInsert = ""
        Me.ColToDate.LocalDecimal = False
        Me.ColToDate.Name = "ColToDate"
        Me.ColToDate.NoUpdate = ""
        Me.ColToDate.NumberDecimal = 0
        Me.ColToDate.ParentControl = ""
        Me.ColToDate.RefreshSource = False
        Me.ColToDate.Required = False
        Me.ColToDate.SequenceName = ""
        Me.ColToDate.ShowCalc = True
        Me.ColToDate.ShowDataTime = False
        Me.ColToDate.ShowOnlyTime = False
        Me.ColToDate.SQLString = ""
        Me.ColToDate.UpdateIfNull = ""
        Me.ColToDate.UpdateWhenFormLock = False
        Me.ColToDate.UpperValue = False
        Me.ColToDate.ValidateValue = True
        Me.ColToDate.Visible = True
        Me.ColToDate.VisibleIndex = 3
        Me.ColToDate.Width = 130
        '
        'ColsType
        '
        Me.ColsType.AllowInsert = True
        Me.ColsType.AllowUpdate = True
        Me.ColsType.ButtonClick = True
        Me.ColsType.Caption = "Cảnh báo"
        Me.ColsType.CFLColumnHide = ""
        Me.ColsType.CFLKeyField = ""
        Me.ColsType.CFLPage = False
        Me.ColsType.CFLReturn0 = ""
        Me.ColsType.CFLReturn1 = ""
        Me.ColsType.CFLReturn2 = ""
        Me.ColsType.CFLReturn3 = ""
        Me.ColsType.CFLReturn4 = ""
        Me.ColsType.CFLReturn5 = ""
        Me.ColsType.CFLReturn6 = ""
        Me.ColsType.CFLReturn7 = ""
        Me.ColsType.CFLShowLoad = False
        Me.ColsType.ChangeFormStatus = True
        Me.ColsType.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.ColsType.ColumnKey = False
        Me.ColsType.ComboLine = 5
        Me.ColsType.CopyFromItem = ""
        Me.ColsType.DefaultButtonClick = False
        Me.ColsType.Digit = False
        Me.ColsType.FieldType = "C"
        Me.ColsType.FieldView = "sType"
        Me.ColsType.FormarNumber = True
        Me.ColsType.FormList = False
        Me.ColsType.KeyInsert = ""
        Me.ColsType.LocalDecimal = False
        Me.ColsType.Name = "ColsType"
        Me.ColsType.NoUpdate = ""
        Me.ColsType.NumberDecimal = 0
        Me.ColsType.ParentControl = ""
        Me.ColsType.RefreshSource = False
        Me.ColsType.Required = False
        Me.ColsType.SequenceName = ""
        Me.ColsType.ShowCalc = True
        Me.ColsType.ShowDataTime = False
        Me.ColsType.ShowOnlyTime = False
        Me.ColsType.SQLString = ""
        Me.ColsType.UpdateIfNull = ""
        Me.ColsType.UpdateWhenFormLock = False
        Me.ColsType.UpperValue = False
        Me.ColsType.ValidateValue = True
        Me.ColsType.Visible = True
        Me.ColsType.VisibleIndex = 4
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'sDefault
        '
        Me.sDefault.AllowInsert = True
        Me.sDefault.AllowUpdate = True
        Me.sDefault.ButtonClick = True
        Me.sDefault.Caption = "Mặc định"
        Me.sDefault.CFLColumnHide = ""
        Me.sDefault.CFLKeyField = ""
        Me.sDefault.CFLPage = False
        Me.sDefault.CFLReturn0 = ""
        Me.sDefault.CFLReturn1 = ""
        Me.sDefault.CFLReturn2 = ""
        Me.sDefault.CFLReturn3 = ""
        Me.sDefault.CFLReturn4 = ""
        Me.sDefault.CFLReturn5 = ""
        Me.sDefault.CFLReturn6 = ""
        Me.sDefault.CFLReturn7 = ""
        Me.sDefault.CFLShowLoad = False
        Me.sDefault.ChangeFormStatus = True
        Me.sDefault.ColumnEdit = Me.RepositoryItemCheckEdit3
        Me.sDefault.ColumnKey = False
        Me.sDefault.ComboLine = 5
        Me.sDefault.CopyFromItem = ""
        Me.sDefault.DefaultButtonClick = False
        Me.sDefault.Digit = False
        Me.sDefault.FieldType = "C"
        Me.sDefault.FieldView = "sDefault"
        Me.sDefault.FormarNumber = True
        Me.sDefault.FormList = False
        Me.sDefault.KeyInsert = ""
        Me.sDefault.LocalDecimal = False
        Me.sDefault.Name = "sDefault"
        Me.sDefault.NoUpdate = ""
        Me.sDefault.NumberDecimal = 0
        Me.sDefault.ParentControl = ""
        Me.sDefault.RefreshSource = False
        Me.sDefault.Required = False
        Me.sDefault.SequenceName = ""
        Me.sDefault.ShowCalc = True
        Me.sDefault.ShowDataTime = False
        Me.sDefault.ShowOnlyTime = False
        Me.sDefault.SQLString = ""
        Me.sDefault.UpdateIfNull = ""
        Me.sDefault.UpdateWhenFormLock = False
        Me.sDefault.UpperValue = False
        Me.sDefault.ValidateValue = True
        Me.sDefault.Visible = True
        Me.sDefault.VisibleIndex = 5
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        Me.RepositoryItemCheckEdit3.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'Dem
        '
        Me.Dem.AllowInsert = True
        Me.Dem.AllowUpdate = True
        Me.Dem.ButtonClick = True
        Me.Dem.Caption = "Lái đêm"
        Me.Dem.CFLColumnHide = ""
        Me.Dem.CFLKeyField = ""
        Me.Dem.CFLPage = False
        Me.Dem.CFLReturn0 = ""
        Me.Dem.CFLReturn1 = ""
        Me.Dem.CFLReturn2 = ""
        Me.Dem.CFLReturn3 = ""
        Me.Dem.CFLReturn4 = ""
        Me.Dem.CFLReturn5 = ""
        Me.Dem.CFLReturn6 = ""
        Me.Dem.CFLReturn7 = ""
        Me.Dem.CFLShowLoad = False
        Me.Dem.ChangeFormStatus = True
        Me.Dem.ColumnEdit = Me.RepositoryItemCheckEdit4
        Me.Dem.ColumnKey = False
        Me.Dem.ComboLine = 5
        Me.Dem.CopyFromItem = ""
        Me.Dem.DefaultButtonClick = False
        Me.Dem.Digit = False
        Me.Dem.FieldType = "C"
        Me.Dem.FieldView = "Dem"
        Me.Dem.FormarNumber = True
        Me.Dem.FormList = False
        Me.Dem.KeyInsert = ""
        Me.Dem.LocalDecimal = False
        Me.Dem.Name = "Dem"
        Me.Dem.NoUpdate = ""
        Me.Dem.NumberDecimal = 0
        Me.Dem.ParentControl = ""
        Me.Dem.RefreshSource = False
        Me.Dem.Required = False
        Me.Dem.SequenceName = ""
        Me.Dem.ShowCalc = True
        Me.Dem.ShowDataTime = False
        Me.Dem.ShowOnlyTime = False
        Me.Dem.SQLString = ""
        Me.Dem.UpdateIfNull = ""
        Me.Dem.UpdateWhenFormLock = False
        Me.Dem.UpperValue = False
        Me.Dem.ValidateValue = True
        Me.Dem.Visible = True
        Me.Dem.VisibleIndex = 6
        '
        'RepositoryItemCheckEdit4
        '
        Me.RepositoryItemCheckEdit4.AutoHeight = False
        Me.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4"
        '
        'colCHECKUPD
        '
        Me.colCHECKUPD.AllowInsert = True
        Me.colCHECKUPD.AllowUpdate = True
        Me.colCHECKUPD.ButtonClick = True
        Me.colCHECKUPD.Caption = "GridColumn9"
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
        'ColUpdUser
        '
        Me.ColUpdUser.AllowInsert = True
        Me.ColUpdUser.AllowUpdate = True
        Me.ColUpdUser.ButtonClick = True
        Me.ColUpdUser.Caption = "User"
        Me.ColUpdUser.CFLColumnHide = ""
        Me.ColUpdUser.CFLKeyField = ""
        Me.ColUpdUser.CFLPage = False
        Me.ColUpdUser.CFLReturn0 = ""
        Me.ColUpdUser.CFLReturn1 = ""
        Me.ColUpdUser.CFLReturn2 = ""
        Me.ColUpdUser.CFLReturn3 = ""
        Me.ColUpdUser.CFLReturn4 = ""
        Me.ColUpdUser.CFLReturn5 = ""
        Me.ColUpdUser.CFLReturn6 = ""
        Me.ColUpdUser.CFLReturn7 = ""
        Me.ColUpdUser.CFLShowLoad = False
        Me.ColUpdUser.ChangeFormStatus = True
        Me.ColUpdUser.ColumnKey = False
        Me.ColUpdUser.ComboLine = 5
        Me.ColUpdUser.CopyFromItem = ""
        Me.ColUpdUser.DefaultButtonClick = False
        Me.ColUpdUser.Digit = False
        Me.ColUpdUser.FieldType = "C"
        Me.ColUpdUser.FieldView = ""
        Me.ColUpdUser.FormarNumber = True
        Me.ColUpdUser.FormList = False
        Me.ColUpdUser.KeyInsert = ""
        Me.ColUpdUser.LocalDecimal = False
        Me.ColUpdUser.Name = "ColUpdUser"
        Me.ColUpdUser.NoUpdate = ""
        Me.ColUpdUser.NumberDecimal = 0
        Me.ColUpdUser.OptionsColumn.ReadOnly = True
        Me.ColUpdUser.ParentControl = ""
        Me.ColUpdUser.RefreshSource = False
        Me.ColUpdUser.Required = False
        Me.ColUpdUser.SequenceName = ""
        Me.ColUpdUser.ShowCalc = True
        Me.ColUpdUser.ShowDataTime = False
        Me.ColUpdUser.ShowOnlyTime = False
        Me.ColUpdUser.SQLString = ""
        Me.ColUpdUser.UpdateIfNull = ""
        Me.ColUpdUser.UpdateWhenFormLock = False
        Me.ColUpdUser.UpperValue = False
        Me.ColUpdUser.ValidateValue = True
        Me.ColUpdUser.Visible = True
        Me.ColUpdUser.VisibleIndex = 7
        '
        'ColUpdDate
        '
        Me.ColUpdDate.AllowInsert = True
        Me.ColUpdDate.AllowUpdate = True
        Me.ColUpdDate.ButtonClick = True
        Me.ColUpdDate.Caption = "Ngày tháng"
        Me.ColUpdDate.CFLColumnHide = ""
        Me.ColUpdDate.CFLKeyField = ""
        Me.ColUpdDate.CFLPage = False
        Me.ColUpdDate.CFLReturn0 = ""
        Me.ColUpdDate.CFLReturn1 = ""
        Me.ColUpdDate.CFLReturn2 = ""
        Me.ColUpdDate.CFLReturn3 = ""
        Me.ColUpdDate.CFLReturn4 = ""
        Me.ColUpdDate.CFLReturn5 = ""
        Me.ColUpdDate.CFLReturn6 = ""
        Me.ColUpdDate.CFLReturn7 = ""
        Me.ColUpdDate.CFLShowLoad = False
        Me.ColUpdDate.ChangeFormStatus = True
        Me.ColUpdDate.ColumnKey = False
        Me.ColUpdDate.ComboLine = 5
        Me.ColUpdDate.CopyFromItem = ""
        Me.ColUpdDate.DefaultButtonClick = False
        Me.ColUpdDate.Digit = False
        Me.ColUpdDate.FieldType = "D"
        Me.ColUpdDate.FieldView = ""
        Me.ColUpdDate.FormarNumber = True
        Me.ColUpdDate.FormList = False
        Me.ColUpdDate.KeyInsert = ""
        Me.ColUpdDate.LocalDecimal = False
        Me.ColUpdDate.Name = "ColUpdDate"
        Me.ColUpdDate.NoUpdate = ""
        Me.ColUpdDate.NumberDecimal = 0
        Me.ColUpdDate.OptionsColumn.ReadOnly = True
        Me.ColUpdDate.ParentControl = ""
        Me.ColUpdDate.RefreshSource = False
        Me.ColUpdDate.Required = False
        Me.ColUpdDate.SequenceName = ""
        Me.ColUpdDate.ShowCalc = True
        Me.ColUpdDate.ShowDataTime = True
        Me.ColUpdDate.ShowOnlyTime = False
        Me.ColUpdDate.SQLString = ""
        Me.ColUpdDate.UpdateIfNull = ""
        Me.ColUpdDate.UpdateWhenFormLock = False
        Me.ColUpdDate.UpperValue = False
        Me.ColUpdDate.ValidateValue = True
        Me.ColUpdDate.Visible = True
        Me.ColUpdDate.VisibleIndex = 8
        Me.ColUpdDate.Width = 130
        '
        'RepositoryItemCalcEdit1
        '
        Me.RepositoryItemCalcEdit1.AutoHeight = False
        Me.RepositoryItemCalcEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit1.Name = "RepositoryItemCalcEdit1"
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.Gainsboro
        Me.XtraTabPage1.Appearance.PageClient.Options.UseBackColor = True
        Me.XtraTabPage1.Controls.Add(Me.TrueDBGrid1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(797, 284)
        Me.XtraTabPage1.Text = "Thông tin gắn với Phương tiện"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 3)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(757, 278)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "ID"
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.MaPhuongTien, Me.NoiDung, Me.FromDate, Me.ToDate, Me.sType, Me.CHECKUPD, Me.UpdUser, Me.UpdDate})
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
        Me.GridView1.TableName = "tblPhuongTien_Infor"
        Me.GridView1.ViewName = "FPT_tblPhuongTien_Infor_V"
        Me.GridView1.Where = Nothing
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.ButtonClick = True
        Me.ID.Caption = "GridColumn1"
        Me.ID.CFLColumnHide = ""
        Me.ID.CFLKeyField = ""
        Me.ID.CFLPage = False
        Me.ID.CFLReturn0 = ""
        Me.ID.CFLReturn1 = ""
        Me.ID.CFLReturn2 = ""
        Me.ID.CFLReturn3 = ""
        Me.ID.CFLReturn4 = ""
        Me.ID.CFLReturn5 = ""
        Me.ID.CFLReturn6 = ""
        Me.ID.CFLReturn7 = ""
        Me.ID.CFLShowLoad = False
        Me.ID.ChangeFormStatus = True
        Me.ID.ColumnKey = True
        Me.ID.ComboLine = 5
        Me.ID.CopyFromItem = ""
        Me.ID.DefaultButtonClick = False
        Me.ID.Digit = False
        Me.ID.FieldType = "N"
        Me.ID.FieldView = "ID"
        Me.ID.FormarNumber = True
        Me.ID.FormList = False
        Me.ID.KeyInsert = ""
        Me.ID.LocalDecimal = False
        Me.ID.Name = "ID"
        Me.ID.NoUpdate = ""
        Me.ID.NumberDecimal = 0
        Me.ID.ParentControl = ""
        Me.ID.RefreshSource = False
        Me.ID.Required = False
        Me.ID.SequenceName = ""
        Me.ID.ShowCalc = True
        Me.ID.ShowDataTime = False
        Me.ID.ShowOnlyTime = False
        Me.ID.SQLString = ""
        Me.ID.UpdateIfNull = ""
        Me.ID.UpdateWhenFormLock = False
        Me.ID.UpperValue = False
        Me.ID.ValidateValue = True
        Me.ID.Visible = True
        Me.ID.Width = 20
        '
        'MaPhuongTien
        '
        Me.MaPhuongTien.AllowInsert = True
        Me.MaPhuongTien.AllowUpdate = False
        Me.MaPhuongTien.ButtonClick = True
        Me.MaPhuongTien.Caption = "MaPhuongTien"
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
        Me.MaPhuongTien.CopyFromItem = ":txtPhuongTien"
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
        Me.MaPhuongTien.Width = 119
        '
        'NoiDung
        '
        Me.NoiDung.AllowInsert = True
        Me.NoiDung.AllowUpdate = True
        Me.NoiDung.ButtonClick = True
        Me.NoiDung.Caption = "Nội dung"
        Me.NoiDung.CFLColumnHide = ""
        Me.NoiDung.CFLKeyField = ""
        Me.NoiDung.CFLPage = False
        Me.NoiDung.CFLReturn0 = ""
        Me.NoiDung.CFLReturn1 = ""
        Me.NoiDung.CFLReturn2 = ""
        Me.NoiDung.CFLReturn3 = ""
        Me.NoiDung.CFLReturn4 = ""
        Me.NoiDung.CFLReturn5 = ""
        Me.NoiDung.CFLReturn6 = ""
        Me.NoiDung.CFLReturn7 = ""
        Me.NoiDung.CFLShowLoad = False
        Me.NoiDung.ChangeFormStatus = True
        Me.NoiDung.ColumnKey = False
        Me.NoiDung.ComboLine = 5
        Me.NoiDung.CopyFromItem = ""
        Me.NoiDung.DefaultButtonClick = False
        Me.NoiDung.Digit = False
        Me.NoiDung.FieldType = "C"
        Me.NoiDung.FieldView = "NoiDung"
        Me.NoiDung.FormarNumber = True
        Me.NoiDung.FormList = False
        Me.NoiDung.KeyInsert = ""
        Me.NoiDung.LocalDecimal = False
        Me.NoiDung.Name = "NoiDung"
        Me.NoiDung.NoUpdate = ""
        Me.NoiDung.NumberDecimal = 0
        Me.NoiDung.ParentControl = ""
        Me.NoiDung.RefreshSource = False
        Me.NoiDung.Required = True
        Me.NoiDung.SequenceName = ""
        Me.NoiDung.ShowCalc = True
        Me.NoiDung.ShowDataTime = False
        Me.NoiDung.ShowOnlyTime = False
        Me.NoiDung.SQLString = ""
        Me.NoiDung.UpdateIfNull = ""
        Me.NoiDung.UpdateWhenFormLock = False
        Me.NoiDung.UpperValue = False
        Me.NoiDung.ValidateValue = True
        Me.NoiDung.Visible = True
        Me.NoiDung.VisibleIndex = 0
        Me.NoiDung.Width = 370
        '
        'FromDate
        '
        Me.FromDate.AllowInsert = True
        Me.FromDate.AllowUpdate = True
        Me.FromDate.ButtonClick = True
        Me.FromDate.Caption = "Ngày hiệu lực"
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
        Me.FromDate.ParentControl = ""
        Me.FromDate.RefreshSource = False
        Me.FromDate.Required = False
        Me.FromDate.SequenceName = ""
        Me.FromDate.ShowCalc = True
        Me.FromDate.ShowDataTime = False
        Me.FromDate.ShowOnlyTime = False
        Me.FromDate.SQLString = ""
        Me.FromDate.UpdateIfNull = ""
        Me.FromDate.UpdateWhenFormLock = False
        Me.FromDate.UpperValue = False
        Me.FromDate.ValidateValue = True
        Me.FromDate.Visible = True
        Me.FromDate.VisibleIndex = 1
        Me.FromDate.Width = 100
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = True
        Me.ToDate.AllowUpdate = True
        Me.ToDate.ButtonClick = True
        Me.ToDate.Caption = "Ngày hết hiệu lực"
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
        Me.ToDate.FieldType = "D"
        Me.ToDate.FieldView = "ToDate"
        Me.ToDate.FormarNumber = True
        Me.ToDate.FormList = False
        Me.ToDate.KeyInsert = ""
        Me.ToDate.LocalDecimal = False
        Me.ToDate.Name = "ToDate"
        Me.ToDate.NoUpdate = ""
        Me.ToDate.NumberDecimal = 0
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
        Me.ToDate.VisibleIndex = 2
        Me.ToDate.Width = 120
        '
        'sType
        '
        Me.sType.AllowInsert = True
        Me.sType.AllowUpdate = True
        Me.sType.ButtonClick = True
        Me.sType.Caption = "Cảnh báo"
        Me.sType.CFLColumnHide = ""
        Me.sType.CFLKeyField = ""
        Me.sType.CFLPage = False
        Me.sType.CFLReturn0 = ""
        Me.sType.CFLReturn1 = ""
        Me.sType.CFLReturn2 = ""
        Me.sType.CFLReturn3 = ""
        Me.sType.CFLReturn4 = ""
        Me.sType.CFLReturn5 = ""
        Me.sType.CFLReturn6 = ""
        Me.sType.CFLReturn7 = ""
        Me.sType.CFLShowLoad = False
        Me.sType.ChangeFormStatus = True
        Me.sType.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.sType.ColumnKey = False
        Me.sType.ComboLine = 5
        Me.sType.CopyFromItem = ""
        Me.sType.DefaultButtonClick = False
        Me.sType.Digit = False
        Me.sType.FieldType = "C"
        Me.sType.FieldView = "sType"
        Me.sType.FormarNumber = True
        Me.sType.FormList = False
        Me.sType.KeyInsert = ""
        Me.sType.LocalDecimal = False
        Me.sType.Name = "sType"
        Me.sType.NoUpdate = ""
        Me.sType.NumberDecimal = 0
        Me.sType.ParentControl = ""
        Me.sType.RefreshSource = False
        Me.sType.Required = False
        Me.sType.SequenceName = ""
        Me.sType.ShowCalc = True
        Me.sType.ShowDataTime = False
        Me.sType.ShowOnlyTime = False
        Me.sType.SQLString = ""
        Me.sType.UpdateIfNull = ""
        Me.sType.UpdateWhenFormLock = False
        Me.sType.UpperValue = False
        Me.sType.ValidateValue = True
        Me.sType.Visible = True
        Me.sType.VisibleIndex = 3
        Me.sType.Width = 119
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.ButtonClick = True
        Me.CHECKUPD.Caption = "GridColumn7"
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
        Me.CHECKUPD.Width = 124
        '
        'UpdUser
        '
        Me.UpdUser.AllowInsert = True
        Me.UpdUser.AllowUpdate = True
        Me.UpdUser.ButtonClick = True
        Me.UpdUser.Caption = "User"
        Me.UpdUser.CFLColumnHide = ""
        Me.UpdUser.CFLKeyField = ""
        Me.UpdUser.CFLPage = False
        Me.UpdUser.CFLReturn0 = ""
        Me.UpdUser.CFLReturn1 = ""
        Me.UpdUser.CFLReturn2 = ""
        Me.UpdUser.CFLReturn3 = ""
        Me.UpdUser.CFLReturn4 = ""
        Me.UpdUser.CFLReturn5 = ""
        Me.UpdUser.CFLReturn6 = ""
        Me.UpdUser.CFLReturn7 = ""
        Me.UpdUser.CFLShowLoad = False
        Me.UpdUser.ChangeFormStatus = True
        Me.UpdUser.ColumnKey = False
        Me.UpdUser.ComboLine = 5
        Me.UpdUser.CopyFromItem = ""
        Me.UpdUser.DefaultButtonClick = False
        Me.UpdUser.Digit = False
        Me.UpdUser.FieldType = "C"
        Me.UpdUser.FieldView = ""
        Me.UpdUser.FormarNumber = True
        Me.UpdUser.FormList = False
        Me.UpdUser.KeyInsert = ""
        Me.UpdUser.LocalDecimal = False
        Me.UpdUser.Name = "UpdUser"
        Me.UpdUser.NoUpdate = ""
        Me.UpdUser.NumberDecimal = 0
        Me.UpdUser.OptionsColumn.ReadOnly = True
        Me.UpdUser.ParentControl = ""
        Me.UpdUser.RefreshSource = False
        Me.UpdUser.Required = False
        Me.UpdUser.SequenceName = ""
        Me.UpdUser.ShowCalc = True
        Me.UpdUser.ShowDataTime = False
        Me.UpdUser.ShowOnlyTime = False
        Me.UpdUser.SQLString = ""
        Me.UpdUser.UpdateIfNull = ""
        Me.UpdUser.UpdateWhenFormLock = False
        Me.UpdUser.UpperValue = False
        Me.UpdUser.ValidateValue = True
        Me.UpdUser.Visible = True
        Me.UpdUser.VisibleIndex = 4
        '
        'UpdDate
        '
        Me.UpdDate.AllowInsert = True
        Me.UpdDate.AllowUpdate = True
        Me.UpdDate.ButtonClick = True
        Me.UpdDate.Caption = "Ngày tháng"
        Me.UpdDate.CFLColumnHide = ""
        Me.UpdDate.CFLKeyField = ""
        Me.UpdDate.CFLPage = False
        Me.UpdDate.CFLReturn0 = ""
        Me.UpdDate.CFLReturn1 = ""
        Me.UpdDate.CFLReturn2 = ""
        Me.UpdDate.CFLReturn3 = ""
        Me.UpdDate.CFLReturn4 = ""
        Me.UpdDate.CFLReturn5 = ""
        Me.UpdDate.CFLReturn6 = ""
        Me.UpdDate.CFLReturn7 = ""
        Me.UpdDate.CFLShowLoad = False
        Me.UpdDate.ChangeFormStatus = True
        Me.UpdDate.ColumnKey = False
        Me.UpdDate.ComboLine = 5
        Me.UpdDate.CopyFromItem = ""
        Me.UpdDate.DefaultButtonClick = False
        Me.UpdDate.Digit = False
        Me.UpdDate.FieldType = "D"
        Me.UpdDate.FieldView = ""
        Me.UpdDate.FormarNumber = True
        Me.UpdDate.FormList = False
        Me.UpdDate.KeyInsert = ""
        Me.UpdDate.LocalDecimal = False
        Me.UpdDate.Name = "UpdDate"
        Me.UpdDate.NoUpdate = ""
        Me.UpdDate.NumberDecimal = 0
        Me.UpdDate.OptionsColumn.ReadOnly = True
        Me.UpdDate.ParentControl = ""
        Me.UpdDate.RefreshSource = False
        Me.UpdDate.Required = False
        Me.UpdDate.SequenceName = ""
        Me.UpdDate.ShowCalc = True
        Me.UpdDate.ShowDataTime = True
        Me.UpdDate.ShowOnlyTime = False
        Me.UpdDate.SQLString = ""
        Me.UpdDate.UpdateIfNull = ""
        Me.UpdDate.UpdateWhenFormLock = False
        Me.UpdDate.UpperValue = False
        Me.UpdDate.ValidateValue = True
        Me.UpdDate.Visible = True
        Me.UpdDate.VisibleIndex = 5
        Me.UpdDate.Width = 130
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(804, 28)
        Me.ToolStrip2.TabIndex = 472
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
        'txtPhuongTien
        '
        Me.txtPhuongTien.AllowInsert = False
        Me.txtPhuongTien.AllowUpdate = False
        Me.txtPhuongTien.AutoKeyFix = ""
        Me.txtPhuongTien.AutoKeyName = ""
        Me.txtPhuongTien.BindingSourceName = ""
        Me.txtPhuongTien.ChangeFormStatus = False
        Me.txtPhuongTien.CopyFromItem = ""
        Me.txtPhuongTien.DefaultValue = ""
        Me.txtPhuongTien.FieldName = ""
        Me.txtPhuongTien.FieldType = "C"
        Me.txtPhuongTien.KeyInsert = ""
        Me.txtPhuongTien.LinkLabel = ""
        Me.txtPhuongTien.Location = New System.Drawing.Point(328, 15)
        Me.txtPhuongTien.Name = "txtPhuongTien"
        Me.txtPhuongTien.NoUpdate = "N"
        Me.txtPhuongTien.PrimaryKey = ""
        Me.txtPhuongTien.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtPhuongTien.Properties.Appearance.Options.UseFont = True
        Me.txtPhuongTien.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtPhuongTien.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPhuongTien.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtPhuongTien.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPhuongTien.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtPhuongTien.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPhuongTien.Properties.AutoHeight = False
        Me.txtPhuongTien.Required = ""
        Me.txtPhuongTien.Size = New System.Drawing.Size(0, 30)
        Me.txtPhuongTien.TabIndex = 473
        Me.txtPhuongTien.TableName = ""
        Me.txtPhuongTien.TabStop = False
        Me.txtPhuongTien.UpdateIfNull = ""
        Me.txtPhuongTien.UpdateWhenFormLock = False
        Me.txtPhuongTien.UpperValue = False
        Me.txtPhuongTien.ViewName = ""
        '
        'FrmVehicleInfor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 370)
        Me.Controls.Add(Me.txtPhuongTien)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmVehicleInfor"
        Me.Text = "Thông tin bổ sung"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.txtPhuongTien, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.txtPhuongTien.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents TrueDBGrid2 As U_TextBox.TrueDBGrid
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents GridView2 As U_TextBox.GridView
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents MaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents NoiDung As U_TextBox.GridColumn
    Friend WithEvents FromDate As U_TextBox.GridColumn
    Friend WithEvents ToDate As U_TextBox.GridColumn
    Friend WithEvents sType As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColID As U_TextBox.GridColumn
    Friend WithEvents ColMaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents HoVaTen As U_TextBox.GridColumn
    Friend WithEvents ColNoiDung As U_TextBox.GridColumn
    Friend WithEvents ColFromDate As U_TextBox.GridColumn
    Friend WithEvents ColToDate As U_TextBox.GridColumn
    Friend WithEvents ColsType As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents sDefault As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colCHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCalcEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents txtPhuongTien As U_TextBox.U_TextBox
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Dem As U_TextBox.GridColumn
    Friend WithEvents UpdUser As U_TextBox.GridColumn
    Friend WithEvents UpdDate As U_TextBox.GridColumn
    Friend WithEvents ColUpdUser As U_TextBox.GridColumn
    Friend WithEvents ColUpdDate As U_TextBox.GridColumn
End Class
