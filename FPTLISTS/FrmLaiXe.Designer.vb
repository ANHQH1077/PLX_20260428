<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLaiXe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLaiXe))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
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
        Me.RepositoryItemCalcEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(988, 28)
        Me.ToolStrip2.TabIndex = 473
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
        'TrueDBGrid2
        '
        Me.TrueDBGrid2.DefaultRemove = True
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid2.Location = New System.Drawing.Point(0, 31)
        Me.TrueDBGrid2.MainView = Me.GridView2
        Me.TrueDBGrid2.Name = "TrueDBGrid2"
        Me.TrueDBGrid2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2, Me.RepositoryItemCalcEdit1, Me.RepositoryItemCheckEdit3, Me.RepositoryItemCheckEdit4})
        Me.TrueDBGrid2.Size = New System.Drawing.Size(988, 485)
        Me.TrueDBGrid2.TabIndex = 474
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
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColID, Me.ColMaPhuongTien, Me.HoVaTen, Me.ColNoiDung, Me.ColFromDate, Me.ColToDate, Me.ColsType, Me.sDefault, Me.Dem, Me.colCHECKUPD})
        Me.GridView2.CompanyCode = ""
        Me.GridView2.DefaultRemove = True
        Me.GridView2.GetB1 = False
        Me.GridView2.GridControl = Me.TrueDBGrid2
        Me.GridView2.LastQuery = ""
        Me.GridView2.Name = "GridView2"
        Me.GridView2.ObjectChild = False
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OrderBy = "MaPhuongTien"
        Me.GridView2.ParentItem = Nothing
        Me.GridView2.RowNumber = ""
        Me.GridView2.TableName = "tblPhuongTien_LaiXe"
        Me.GridView2.ViewName = "FPT_tblPhuongTien_LaiXe_V"
        Me.GridView2.Where = "X='1'"
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
        Me.ColID.ValidateValue = True
        Me.ColID.Visible = True
        Me.ColID.Width = 65
        '
        'ColMaPhuongTien
        '
        Me.ColMaPhuongTien.AllowInsert = True
        Me.ColMaPhuongTien.AllowUpdate = False
        Me.ColMaPhuongTien.ButtonClick = True
        Me.ColMaPhuongTien.Caption = "Phương tiện"
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
        Me.ColMaPhuongTien.OptionsColumn.ReadOnly = True
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
        Me.ColMaPhuongTien.ValidateValue = True
        Me.ColMaPhuongTien.Visible = True
        Me.ColMaPhuongTien.VisibleIndex = 0
        Me.ColMaPhuongTien.Width = 110
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
        Me.HoVaTen.ValidateValue = True
        Me.HoVaTen.Visible = True
        Me.HoVaTen.VisibleIndex = 1
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
        Me.ColNoiDung.ValidateValue = True
        Me.ColNoiDung.Visible = True
        Me.ColNoiDung.VisibleIndex = 2
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
        Me.ColFromDate.ValidateValue = True
        Me.ColFromDate.Visible = True
        Me.ColFromDate.VisibleIndex = 3
        Me.ColFromDate.Width = 100
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
        Me.ColToDate.ValidateValue = True
        Me.ColToDate.Visible = True
        Me.ColToDate.VisibleIndex = 4
        Me.ColToDate.Width = 100
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
        Me.ColsType.ValidateValue = True
        Me.ColsType.Visible = True
        Me.ColsType.VisibleIndex = 5
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
        Me.sDefault.ValidateValue = True
        Me.sDefault.Visible = True
        Me.sDefault.VisibleIndex = 6
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
        Me.Dem.ValidateValue = True
        Me.Dem.Visible = True
        Me.Dem.VisibleIndex = 7
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
        Me.colCHECKUPD.ValidateValue = True
        Me.colCHECKUPD.Visible = True
        '
        'RepositoryItemCalcEdit1
        '
        Me.RepositoryItemCalcEdit1.AutoHeight = False
        Me.RepositoryItemCalcEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit1.Name = "RepositoryItemCalcEdit1"
        '
        'FrmLaiXe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 516)
        Me.Controls.Add(Me.TrueDBGrid2)
        Me.Controls.Add(Me.ToolStrip2)
        Me.MaximizeBox = False
        Me.Name = "FrmLaiXe"
        Me.Text = "Danh sách lái xe"
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrueDBGrid2 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView2 As U_TextBox.GridView
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
    Friend WithEvents Dem As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colCHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCalcEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
End Class
