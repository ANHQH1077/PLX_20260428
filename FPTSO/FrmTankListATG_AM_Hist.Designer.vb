<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankListATG_AM_Hist
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
        Me.TrueDBGrid2 = New U_TextBox.TrueDBGrid()
        Me.GridView2 = New U_TextBox.GridView()
        Me.GridColumn2 = New U_TextBox.GridColumn()
        Me.NhomBeXuat = New U_TextBox.GridColumn()
        Me.GridColumn4 = New U_TextBox.GridColumn()
        Me.GridColumn5 = New U_TextBox.GridColumn()
        Me.GridColumn7 = New U_TextBox.GridColumn()
        Me.FromDate = New U_TextBox.GridColumn()
        Me.ToDate = New U_TextBox.GridColumn()
        Me.DateHist = New U_TextBox.GridColumn()
        Me.CrUser = New U_TextBox.GridColumn()
        Me.Status = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemButtonEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid2
        '
        Me.TrueDBGrid2.DefaultRemove = True
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid2.Location = New System.Drawing.Point(1, 12)
        Me.TrueDBGrid2.MainView = Me.GridView2
        Me.TrueDBGrid2.Name = "TrueDBGrid2"
        Me.TrueDBGrid2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit2, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit4})
        Me.TrueDBGrid2.Size = New System.Drawing.Size(938, 514)
        Me.TrueDBGrid2.TabIndex = 481
        Me.TrueDBGrid2.UseEmbeddedNavigator = True
        Me.TrueDBGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.AllowInsert = False
        Me.GridView2.CheckUpd = False
        Me.GridView2.ColumnAutoWidth = False
        Me.GridView2.ColumnKey = ""
        Me.GridView2.ColumnKeyIns = True
        Me.GridView2.ColumnKeyType = "N"
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.NhomBeXuat, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7, Me.FromDate, Me.ToDate, Me.DateHist, Me.CrUser, Me.Status})
        Me.GridView2.CompanyCode = ""
        Me.GridView2.DefaultRemove = False
        Me.GridView2.GetB1 = False
        Me.GridView2.GridControl = Me.TrueDBGrid2
        Me.GridView2.LastQuery = ""
        Me.GridView2.Name = "GridView2"
        Me.GridView2.ObjectChild = False
        Me.GridView2.OptionsBehavior.ReadOnly = True
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsSelection.MultiSelect = True
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        Me.GridView2.OrderBy = "TankCode, dDate"
        Me.GridView2.ParentItem = Nothing
        Me.GridView2.RowNumber = ""
        Me.GridView2.TableName = ""
        Me.GridView2.ViewName = "zTankListATG_AM_Hist_v"
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
        'FromDate
        '
        Me.FromDate.AllowInsert = True
        Me.FromDate.AllowUpdate = True
        Me.FromDate.ButtonClick = True
        Me.FromDate.Caption = "Hiệu lực"
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
        Me.FromDate.VisibleIndex = 4
        Me.FromDate.Width = 170
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = True
        Me.ToDate.AllowUpdate = True
        Me.ToDate.ButtonClick = True
        Me.ToDate.Caption = "Hết hiệu lực"
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
        Me.ToDate.OptionsColumn.ReadOnly = True
        Me.ToDate.ParentControl = ""
        Me.ToDate.RefreshSource = False
        Me.ToDate.Required = False
        Me.ToDate.SequenceName = ""
        Me.ToDate.ShowCalc = True
        Me.ToDate.ShowDataTime = True
        Me.ToDate.ShowOnlyTime = False
        Me.ToDate.SQLString = ""
        Me.ToDate.UpdateIfNull = ""
        Me.ToDate.UpdateWhenFormLock = False
        Me.ToDate.UpperValue = False
        Me.ToDate.ValidateValue = True
        Me.ToDate.Visible = True
        Me.ToDate.VisibleIndex = 5
        Me.ToDate.Width = 170
        '
        'DateHist
        '
        Me.DateHist.AllowInsert = True
        Me.DateHist.AllowUpdate = True
        Me.DateHist.ButtonClick = True
        Me.DateHist.Caption = "Ngày giờ thay đổi"
        Me.DateHist.CFLColumnHide = ""
        Me.DateHist.CFLKeyField = ""
        Me.DateHist.CFLPage = False
        Me.DateHist.CFLReturn0 = ""
        Me.DateHist.CFLReturn1 = ""
        Me.DateHist.CFLReturn2 = ""
        Me.DateHist.CFLReturn3 = ""
        Me.DateHist.CFLReturn4 = ""
        Me.DateHist.CFLReturn5 = ""
        Me.DateHist.CFLReturn6 = ""
        Me.DateHist.CFLReturn7 = ""
        Me.DateHist.CFLShowLoad = False
        Me.DateHist.ChangeFormStatus = True
        Me.DateHist.ColumnKey = False
        Me.DateHist.ComboLine = 5
        Me.DateHist.CopyFromItem = ""
        Me.DateHist.DefaultButtonClick = False
        Me.DateHist.Digit = False
        Me.DateHist.FieldType = "D"
        Me.DateHist.FieldView = "dDate"
        Me.DateHist.FormarNumber = True
        Me.DateHist.FormList = False
        Me.DateHist.KeyInsert = ""
        Me.DateHist.LocalDecimal = False
        Me.DateHist.Name = "DateHist"
        Me.DateHist.NoUpdate = ""
        Me.DateHist.NumberDecimal = 0
        Me.DateHist.ParentControl = ""
        Me.DateHist.RefreshSource = False
        Me.DateHist.Required = False
        Me.DateHist.SequenceName = ""
        Me.DateHist.ShowCalc = True
        Me.DateHist.ShowDataTime = True
        Me.DateHist.ShowOnlyTime = False
        Me.DateHist.SQLString = ""
        Me.DateHist.UpdateIfNull = ""
        Me.DateHist.UpdateWhenFormLock = False
        Me.DateHist.UpperValue = False
        Me.DateHist.ValidateValue = True
        Me.DateHist.Visible = True
        Me.DateHist.VisibleIndex = 6
        Me.DateHist.Width = 200
        '
        'CrUser
        '
        Me.CrUser.AllowInsert = True
        Me.CrUser.AllowUpdate = True
        Me.CrUser.ButtonClick = True
        Me.CrUser.Caption = "User"
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
        Me.CrUser.FieldView = "UpdatedBy"
        Me.CrUser.FormarNumber = False
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
        Me.CrUser.VisibleIndex = 7
        '
        'Status
        '
        Me.Status.AllowInsert = True
        Me.Status.AllowUpdate = True
        Me.Status.ButtonClick = True
        Me.Status.Caption = "Loại"
        Me.Status.CFLColumnHide = ""
        Me.Status.CFLKeyField = ""
        Me.Status.CFLPage = False
        Me.Status.CFLReturn0 = ""
        Me.Status.CFLReturn1 = ""
        Me.Status.CFLReturn2 = ""
        Me.Status.CFLReturn3 = ""
        Me.Status.CFLReturn4 = ""
        Me.Status.CFLReturn5 = ""
        Me.Status.CFLReturn6 = ""
        Me.Status.CFLReturn7 = ""
        Me.Status.CFLShowLoad = False
        Me.Status.ChangeFormStatus = True
        Me.Status.ColumnKey = False
        Me.Status.ComboLine = 5
        Me.Status.CopyFromItem = ""
        Me.Status.DefaultButtonClick = False
        Me.Status.Digit = False
        Me.Status.FieldType = "C"
        Me.Status.FieldView = "sStatus"
        Me.Status.FormarNumber = True
        Me.Status.FormList = False
        Me.Status.KeyInsert = ""
        Me.Status.LocalDecimal = False
        Me.Status.Name = "Status"
        Me.Status.NoUpdate = ""
        Me.Status.NumberDecimal = 0
        Me.Status.ParentControl = ""
        Me.Status.RefreshSource = False
        Me.Status.Required = False
        Me.Status.SequenceName = ""
        Me.Status.ShowCalc = True
        Me.Status.ShowDataTime = False
        Me.Status.ShowOnlyTime = False
        Me.Status.SQLString = ""
        Me.Status.UpdateIfNull = ""
        Me.Status.UpdateWhenFormLock = False
        Me.Status.UpperValue = False
        Me.Status.ValidateValue = True
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 8
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
        'FrmTankListATG_AM_Hist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 526)
        Me.Controls.Add(Me.TrueDBGrid2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmTankListATG_AM_Hist"
        Me.Text = "Lịch sử thay đổi"
        Me.Controls.SetChildIndex(Me.TrueDBGrid2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid2 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView2 As U_TextBox.GridView
    Friend WithEvents GridColumn2 As U_TextBox.GridColumn
    Friend WithEvents GridColumn4 As U_TextBox.GridColumn
    Friend WithEvents GridColumn5 As U_TextBox.GridColumn
    Friend WithEvents GridColumn7 As U_TextBox.GridColumn
    Friend WithEvents CrUser As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemButtonEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateHist As U_TextBox.GridColumn
    Friend WithEvents Status As U_TextBox.GridColumn
    Friend WithEvents FromDate As U_TextBox.GridColumn
    Friend WithEvents ToDate As U_TextBox.GridColumn
    Friend WithEvents NhomBeXuat As U_TextBox.GridColumn
End Class
