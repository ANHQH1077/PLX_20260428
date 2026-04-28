<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankChange
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTankChange))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.TableID = New U_TextBox.GridColumn()
        Me.MaHangHoa = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TenHangHoa = New U_TextBox.GridColumn()
        Me.DonViTinh = New U_TextBox.GridColumn()
        Me.TongDuXuat = New U_TextBox.GridColumn()
        Me.HColTongXuat = New U_TextBox.GridColumn()
        Me.MeterId = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.BeXuat = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.NhomBeXuat = New U_TextBox.GridColumn()
        Me.HColSoLenh = New U_TextBox.GridColumn()
        Me.ColMaLenh = New U_TextBox.GridColumn()
        Me.HColNgayXuat = New U_TextBox.GridColumn()
        Me.LineID = New U_TextBox.GridColumn()
        Me.HCHECKUPD = New U_TextBox.GridColumn()
        Me.Status = New U_TextBox.GridColumn()
        Me.MaVanChuyen = New U_TextBox.GridColumn()
        Me.NgayTichKe = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemGridLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SoLenh = New U_TextBox.U_TextBox()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NhomBe = New U_TextBox.U_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CreateDate = New U_TextBox.U_DateEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TankNew = New U_TextBox.U_ButtonEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TankOld = New U_TextBox.U_ButtonEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NhomBe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreateDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TankNew.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TankOld.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(4, 133)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemComboBox2, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemGridLookUpEdit1, Me.RepositoryItemButtonEdit3, Me.RepositoryItemButtonEdit4, Me.RepositoryItemComboBox3})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(899, 248)
        Me.TrueDBGrid1.TabIndex = 7
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TableID, Me.MaHangHoa, Me.TenHangHoa, Me.DonViTinh, Me.TongDuXuat, Me.HColTongXuat, Me.MeterId, Me.BeXuat, Me.NhomBeXuat, Me.HColSoLenh, Me.ColMaLenh, Me.HColNgayXuat, Me.LineID, Me.HCHECKUPD, Me.Status, Me.MaVanChuyen, Me.NgayTichKe})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "TableId"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblLenhXuat_HangHoaE5"
        Me.GridView1.ViewName = "FPT_tblLenhXuat_HangHoaE5_V1"
        Me.GridView1.Where = "SoLenh=:SoLenh"
        '
        'TableID
        '
        Me.TableID.AllowInsert = False
        Me.TableID.AllowUpdate = False
        Me.TableID.ButtonClick = True
        Me.TableID.Caption = "Mã lệnh"
        Me.TableID.CFLColumnHide = ""
        Me.TableID.CFLKeyField = ""
        Me.TableID.CFLPage = False
        Me.TableID.CFLReturn0 = ""
        Me.TableID.CFLReturn1 = ""
        Me.TableID.CFLReturn2 = ""
        Me.TableID.CFLReturn3 = ""
        Me.TableID.CFLReturn4 = ""
        Me.TableID.CFLReturn5 = ""
        Me.TableID.CFLReturn6 = ""
        Me.TableID.CFLReturn7 = ""
        Me.TableID.CFLShowLoad = False
        Me.TableID.ChangeFormStatus = True
        Me.TableID.ColumnKey = True
        Me.TableID.ComboLine = 5
        Me.TableID.CopyFromItem = ""
        Me.TableID.DefaultButtonClick = False
        Me.TableID.Digit = False
        Me.TableID.FieldType = "C"
        Me.TableID.FieldView = "TableID"
        Me.TableID.FormarNumber = True
        Me.TableID.FormList = False
        Me.TableID.KeyInsert = ""
        Me.TableID.LocalDecimal = False
        Me.TableID.Name = "TableID"
        Me.TableID.NoUpdate = ""
        Me.TableID.NumberDecimal = 0
        Me.TableID.OptionsColumn.AllowEdit = False
        Me.TableID.ParentControl = ""
        Me.TableID.RefreshSource = False
        Me.TableID.Required = False
        Me.TableID.SequenceName = ""
        Me.TableID.ShowCalc = True
        Me.TableID.ShowDataTime = False
        Me.TableID.ShowOnlyTime = False
        Me.TableID.SQLString = ""
        Me.TableID.UpdateIfNull = ""
        Me.TableID.UpdateWhenFormLock = False
        Me.TableID.UpperValue = False
        Me.TableID.ValidateValue = True
        Me.TableID.Visible = True
        Me.TableID.VisibleIndex = 0
        Me.TableID.Width = 70
        '
        'MaHangHoa
        '
        Me.MaHangHoa.AllowInsert = False
        Me.MaHangHoa.AllowUpdate = False
        Me.MaHangHoa.ButtonClick = True
        Me.MaHangHoa.Caption = "Mã hàng hóa"
        Me.MaHangHoa.CFLColumnHide = ""
        Me.MaHangHoa.CFLKeyField = "MaHangHoa"
        Me.MaHangHoa.CFLPage = False
        Me.MaHangHoa.CFLReturn0 = ""
        Me.MaHangHoa.CFLReturn1 = "TenHangHoa"
        Me.MaHangHoa.CFLReturn2 = ""
        Me.MaHangHoa.CFLReturn3 = ""
        Me.MaHangHoa.CFLReturn4 = ""
        Me.MaHangHoa.CFLReturn5 = ""
        Me.MaHangHoa.CFLReturn6 = ""
        Me.MaHangHoa.CFLReturn7 = ""
        Me.MaHangHoa.CFLShowLoad = False
        Me.MaHangHoa.ChangeFormStatus = True
        Me.MaHangHoa.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.MaHangHoa.ColumnKey = False
        Me.MaHangHoa.ComboLine = 5
        Me.MaHangHoa.CopyFromItem = ""
        Me.MaHangHoa.DefaultButtonClick = False
        Me.MaHangHoa.Digit = False
        Me.MaHangHoa.FieldType = "C"
        Me.MaHangHoa.FieldView = "MaHangHoa"
        Me.MaHangHoa.FormarNumber = True
        Me.MaHangHoa.FormList = True
        Me.MaHangHoa.KeyInsert = ""
        Me.MaHangHoa.LocalDecimal = False
        Me.MaHangHoa.Name = "MaHangHoa"
        Me.MaHangHoa.NoUpdate = ""
        Me.MaHangHoa.NumberDecimal = 0
        Me.MaHangHoa.OptionsColumn.AllowEdit = False
        Me.MaHangHoa.ParentControl = ""
        Me.MaHangHoa.RefreshSource = False
        Me.MaHangHoa.Required = True
        Me.MaHangHoa.SequenceName = ""
        Me.MaHangHoa.ShowCalc = True
        Me.MaHangHoa.ShowDataTime = False
        Me.MaHangHoa.ShowOnlyTime = False
        Me.MaHangHoa.SQLString = "select MaHangHoa, TenHangHoa  from tblHangHoa a where Status='X'"
        Me.MaHangHoa.UpdateIfNull = ""
        Me.MaHangHoa.UpdateWhenFormLock = False
        Me.MaHangHoa.UpperValue = False
        Me.MaHangHoa.ValidateValue = True
        Me.MaHangHoa.Visible = True
        Me.MaHangHoa.VisibleIndex = 1
        Me.MaHangHoa.Width = 70
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
        Me.TenHangHoa.Caption = "Tên hàng hóa"
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
        Me.TenHangHoa.OptionsColumn.AllowEdit = False
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
        Me.TenHangHoa.VisibleIndex = 2
        Me.TenHangHoa.Width = 150
        '
        'DonViTinh
        '
        Me.DonViTinh.AllowInsert = False
        Me.DonViTinh.AllowUpdate = False
        Me.DonViTinh.ButtonClick = True
        Me.DonViTinh.Caption = "ĐV tính"
        Me.DonViTinh.CFLColumnHide = ""
        Me.DonViTinh.CFLKeyField = ""
        Me.DonViTinh.CFLPage = False
        Me.DonViTinh.CFLReturn0 = ""
        Me.DonViTinh.CFLReturn1 = ""
        Me.DonViTinh.CFLReturn2 = ""
        Me.DonViTinh.CFLReturn3 = ""
        Me.DonViTinh.CFLReturn4 = ""
        Me.DonViTinh.CFLReturn5 = ""
        Me.DonViTinh.CFLReturn6 = ""
        Me.DonViTinh.CFLReturn7 = ""
        Me.DonViTinh.CFLShowLoad = False
        Me.DonViTinh.ChangeFormStatus = True
        Me.DonViTinh.ColumnKey = False
        Me.DonViTinh.ComboLine = 5
        Me.DonViTinh.CopyFromItem = ""
        Me.DonViTinh.DefaultButtonClick = False
        Me.DonViTinh.Digit = False
        Me.DonViTinh.FieldType = "C"
        Me.DonViTinh.FieldView = "DonViTinh"
        Me.DonViTinh.FormarNumber = True
        Me.DonViTinh.FormList = False
        Me.DonViTinh.KeyInsert = ""
        Me.DonViTinh.LocalDecimal = False
        Me.DonViTinh.Name = "DonViTinh"
        Me.DonViTinh.NoUpdate = ""
        Me.DonViTinh.NumberDecimal = 0
        Me.DonViTinh.OptionsColumn.AllowEdit = False
        Me.DonViTinh.ParentControl = ""
        Me.DonViTinh.RefreshSource = False
        Me.DonViTinh.Required = False
        Me.DonViTinh.SequenceName = ""
        Me.DonViTinh.ShowCalc = True
        Me.DonViTinh.ShowDataTime = False
        Me.DonViTinh.ShowOnlyTime = False
        Me.DonViTinh.SQLString = "select Code as DonViTinh from FPT_DonViTinh_V"
        Me.DonViTinh.UpdateIfNull = ""
        Me.DonViTinh.UpdateWhenFormLock = False
        Me.DonViTinh.UpperValue = False
        Me.DonViTinh.ValidateValue = True
        Me.DonViTinh.Visible = True
        Me.DonViTinh.VisibleIndex = 3
        Me.DonViTinh.Width = 50
        '
        'TongDuXuat
        '
        Me.TongDuXuat.AllowInsert = False
        Me.TongDuXuat.AllowUpdate = False
        Me.TongDuXuat.ButtonClick = True
        Me.TongDuXuat.Caption = "Tổng dự xuất"
        Me.TongDuXuat.CFLColumnHide = ""
        Me.TongDuXuat.CFLKeyField = ""
        Me.TongDuXuat.CFLPage = False
        Me.TongDuXuat.CFLReturn0 = ""
        Me.TongDuXuat.CFLReturn1 = ""
        Me.TongDuXuat.CFLReturn2 = ""
        Me.TongDuXuat.CFLReturn3 = ""
        Me.TongDuXuat.CFLReturn4 = ""
        Me.TongDuXuat.CFLReturn5 = ""
        Me.TongDuXuat.CFLReturn6 = ""
        Me.TongDuXuat.CFLReturn7 = ""
        Me.TongDuXuat.CFLShowLoad = False
        Me.TongDuXuat.ChangeFormStatus = True
        Me.TongDuXuat.ColumnKey = False
        Me.TongDuXuat.ComboLine = 5
        Me.TongDuXuat.CopyFromItem = ""
        Me.TongDuXuat.DefaultButtonClick = False
        Me.TongDuXuat.Digit = True
        Me.TongDuXuat.FieldType = "N"
        Me.TongDuXuat.FieldView = "TongDuXuat"
        Me.TongDuXuat.FormarNumber = True
        Me.TongDuXuat.FormList = False
        Me.TongDuXuat.KeyInsert = ""
        Me.TongDuXuat.LocalDecimal = True
        Me.TongDuXuat.Name = "TongDuXuat"
        Me.TongDuXuat.NoUpdate = ""
        Me.TongDuXuat.NumberDecimal = 0
        Me.TongDuXuat.OptionsColumn.AllowEdit = False
        Me.TongDuXuat.ParentControl = ""
        Me.TongDuXuat.RefreshSource = False
        Me.TongDuXuat.Required = False
        Me.TongDuXuat.SequenceName = ""
        Me.TongDuXuat.ShowCalc = True
        Me.TongDuXuat.ShowDataTime = False
        Me.TongDuXuat.ShowOnlyTime = False
        Me.TongDuXuat.SQLString = ""
        Me.TongDuXuat.UpdateIfNull = ""
        Me.TongDuXuat.UpdateWhenFormLock = False
        Me.TongDuXuat.UpperValue = False
        Me.TongDuXuat.ValidateValue = True
        Me.TongDuXuat.Visible = True
        Me.TongDuXuat.VisibleIndex = 4
        Me.TongDuXuat.Width = 80
        '
        'HColTongXuat
        '
        Me.HColTongXuat.AllowInsert = False
        Me.HColTongXuat.AllowUpdate = False
        Me.HColTongXuat.ButtonClick = True
        Me.HColTongXuat.Caption = "Quy đổi"
        Me.HColTongXuat.CFLColumnHide = ""
        Me.HColTongXuat.CFLKeyField = ""
        Me.HColTongXuat.CFLPage = False
        Me.HColTongXuat.CFLReturn0 = ""
        Me.HColTongXuat.CFLReturn1 = ""
        Me.HColTongXuat.CFLReturn2 = ""
        Me.HColTongXuat.CFLReturn3 = ""
        Me.HColTongXuat.CFLReturn4 = ""
        Me.HColTongXuat.CFLReturn5 = ""
        Me.HColTongXuat.CFLReturn6 = ""
        Me.HColTongXuat.CFLReturn7 = ""
        Me.HColTongXuat.CFLShowLoad = False
        Me.HColTongXuat.ChangeFormStatus = True
        Me.HColTongXuat.ColumnKey = False
        Me.HColTongXuat.ComboLine = 5
        Me.HColTongXuat.CopyFromItem = ""
        Me.HColTongXuat.DefaultButtonClick = False
        Me.HColTongXuat.Digit = True
        Me.HColTongXuat.FieldType = "N"
        Me.HColTongXuat.FieldView = "TongXuat"
        Me.HColTongXuat.FormarNumber = True
        Me.HColTongXuat.FormList = False
        Me.HColTongXuat.KeyInsert = ""
        Me.HColTongXuat.LocalDecimal = True
        Me.HColTongXuat.Name = "HColTongXuat"
        Me.HColTongXuat.NoUpdate = ""
        Me.HColTongXuat.NumberDecimal = 0
        Me.HColTongXuat.OptionsColumn.AllowEdit = False
        Me.HColTongXuat.ParentControl = ""
        Me.HColTongXuat.RefreshSource = False
        Me.HColTongXuat.Required = False
        Me.HColTongXuat.SequenceName = ""
        Me.HColTongXuat.ShowCalc = True
        Me.HColTongXuat.ShowDataTime = False
        Me.HColTongXuat.ShowOnlyTime = False
        Me.HColTongXuat.SQLString = ""
        Me.HColTongXuat.UpdateIfNull = ""
        Me.HColTongXuat.UpdateWhenFormLock = False
        Me.HColTongXuat.UpperValue = False
        Me.HColTongXuat.ValidateValue = True
        Me.HColTongXuat.Visible = True
        Me.HColTongXuat.VisibleIndex = 5
        Me.HColTongXuat.Width = 80
        '
        'MeterId
        '
        Me.MeterId.AllowInsert = False
        Me.MeterId.AllowUpdate = False
        Me.MeterId.ButtonClick = True
        Me.MeterId.Caption = "Công tơ"
        Me.MeterId.CFLColumnHide = ""
        Me.MeterId.CFLKeyField = "[Công tơ]"
        Me.MeterId.CFLPage = False
        Me.MeterId.CFLReturn0 = ""
        Me.MeterId.CFLReturn1 = ""
        Me.MeterId.CFLReturn2 = ""
        Me.MeterId.CFLReturn3 = ""
        Me.MeterId.CFLReturn4 = ""
        Me.MeterId.CFLReturn5 = ""
        Me.MeterId.CFLReturn6 = ""
        Me.MeterId.CFLReturn7 = ""
        Me.MeterId.CFLShowLoad = True
        Me.MeterId.ChangeFormStatus = True
        Me.MeterId.ColumnEdit = Me.RepositoryItemButtonEdit4
        Me.MeterId.ColumnKey = False
        Me.MeterId.ComboLine = 5
        Me.MeterId.CopyFromItem = ""
        Me.MeterId.DefaultButtonClick = False
        Me.MeterId.Digit = False
        Me.MeterId.FieldType = "C"
        Me.MeterId.FieldView = "MeterId"
        Me.MeterId.FormarNumber = True
        Me.MeterId.FormList = True
        Me.MeterId.KeyInsert = ""
        Me.MeterId.LocalDecimal = False
        Me.MeterId.Name = "MeterId"
        Me.MeterId.NoUpdate = ""
        Me.MeterId.NumberDecimal = 0
        Me.MeterId.ParentControl = ""
        Me.MeterId.RefreshSource = True
        Me.MeterId.Required = False
        Me.MeterId.SequenceName = ""
        Me.MeterId.ShowCalc = True
        Me.MeterId.ShowDataTime = False
        Me.MeterId.ShowOnlyTime = False
        Me.MeterId.SQLString = "select MeterId  as [Công tơ] from vwMeterAll where LoadingSite=:LoaiXuat and Prod" & _
            "uctCode=:Column.MaHangHoa"
        Me.MeterId.UpdateIfNull = ""
        Me.MeterId.UpdateWhenFormLock = False
        Me.MeterId.UpperValue = False
        Me.MeterId.ValidateValue = True
        Me.MeterId.Visible = True
        Me.MeterId.VisibleIndex = 6
        Me.MeterId.Width = 80
        '
        'RepositoryItemButtonEdit4
        '
        Me.RepositoryItemButtonEdit4.AutoHeight = False
        Me.RepositoryItemButtonEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit4.Name = "RepositoryItemButtonEdit4"
        '
        'BeXuat
        '
        Me.BeXuat.AllowInsert = True
        Me.BeXuat.AllowUpdate = True
        Me.BeXuat.ButtonClick = True
        Me.BeXuat.Caption = "Bể xuất"
        Me.BeXuat.CFLColumnHide = ""
        Me.BeXuat.CFLKeyField = "[Bể xuất]"
        Me.BeXuat.CFLPage = False
        Me.BeXuat.CFLReturn0 = ""
        Me.BeXuat.CFLReturn1 = ""
        Me.BeXuat.CFLReturn2 = ""
        Me.BeXuat.CFLReturn3 = ""
        Me.BeXuat.CFLReturn4 = ""
        Me.BeXuat.CFLReturn5 = ""
        Me.BeXuat.CFLReturn6 = ""
        Me.BeXuat.CFLReturn7 = ""
        Me.BeXuat.CFLShowLoad = True
        Me.BeXuat.ChangeFormStatus = True
        Me.BeXuat.ColumnEdit = Me.RepositoryItemButtonEdit3
        Me.BeXuat.ColumnKey = False
        Me.BeXuat.ComboLine = 5
        Me.BeXuat.CopyFromItem = ""
        Me.BeXuat.DefaultButtonClick = False
        Me.BeXuat.Digit = False
        Me.BeXuat.FieldType = "C"
        Me.BeXuat.FieldView = "BeXuat"
        Me.BeXuat.FormarNumber = True
        Me.BeXuat.FormList = True
        Me.BeXuat.KeyInsert = ""
        Me.BeXuat.LocalDecimal = False
        Me.BeXuat.Name = "BeXuat"
        Me.BeXuat.NoUpdate = ""
        Me.BeXuat.NumberDecimal = 0
        Me.BeXuat.ParentControl = ""
        Me.BeXuat.RefreshSource = True
        Me.BeXuat.Required = False
        Me.BeXuat.SequenceName = ""
        Me.BeXuat.ShowCalc = True
        Me.BeXuat.ShowDataTime = True
        Me.BeXuat.ShowOnlyTime = False
        Me.BeXuat.SQLString = resources.GetString("BeXuat.SQLString")
        Me.BeXuat.UpdateIfNull = ""
        Me.BeXuat.UpdateWhenFormLock = False
        Me.BeXuat.UpperValue = False
        Me.BeXuat.ValidateValue = True
        Me.BeXuat.Visible = True
        Me.BeXuat.VisibleIndex = 7
        Me.BeXuat.Width = 80
        '
        'RepositoryItemButtonEdit3
        '
        Me.RepositoryItemButtonEdit3.AutoHeight = False
        Me.RepositoryItemButtonEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit3.Name = "RepositoryItemButtonEdit3"
        '
        'NhomBeXuat
        '
        Me.NhomBeXuat.AllowInsert = False
        Me.NhomBeXuat.AllowUpdate = False
        Me.NhomBeXuat.ButtonClick = True
        Me.NhomBeXuat.Caption = "Nhóm bể xuất"
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
        Me.NhomBeXuat.VisibleIndex = 8
        Me.NhomBeXuat.Width = 110
        '
        'HColSoLenh
        '
        Me.HColSoLenh.AllowInsert = False
        Me.HColSoLenh.AllowUpdate = False
        Me.HColSoLenh.ButtonClick = True
        Me.HColSoLenh.Caption = "SoLenh"
        Me.HColSoLenh.CFLColumnHide = ""
        Me.HColSoLenh.CFLKeyField = ""
        Me.HColSoLenh.CFLPage = False
        Me.HColSoLenh.CFLReturn0 = ""
        Me.HColSoLenh.CFLReturn1 = ""
        Me.HColSoLenh.CFLReturn2 = ""
        Me.HColSoLenh.CFLReturn3 = ""
        Me.HColSoLenh.CFLReturn4 = ""
        Me.HColSoLenh.CFLReturn5 = ""
        Me.HColSoLenh.CFLReturn6 = ""
        Me.HColSoLenh.CFLReturn7 = ""
        Me.HColSoLenh.CFLShowLoad = False
        Me.HColSoLenh.ChangeFormStatus = True
        Me.HColSoLenh.ColumnKey = True
        Me.HColSoLenh.ComboLine = 5
        Me.HColSoLenh.CopyFromItem = ""
        Me.HColSoLenh.DefaultButtonClick = False
        Me.HColSoLenh.Digit = False
        Me.HColSoLenh.FieldType = "C"
        Me.HColSoLenh.FieldView = "SoLenh"
        Me.HColSoLenh.FormarNumber = True
        Me.HColSoLenh.FormList = False
        Me.HColSoLenh.KeyInsert = ""
        Me.HColSoLenh.LocalDecimal = False
        Me.HColSoLenh.Name = "HColSoLenh"
        Me.HColSoLenh.NoUpdate = ""
        Me.HColSoLenh.NumberDecimal = 0
        Me.HColSoLenh.ParentControl = ""
        Me.HColSoLenh.RefreshSource = False
        Me.HColSoLenh.Required = False
        Me.HColSoLenh.SequenceName = ""
        Me.HColSoLenh.ShowCalc = True
        Me.HColSoLenh.ShowDataTime = False
        Me.HColSoLenh.ShowOnlyTime = False
        Me.HColSoLenh.SQLString = ""
        Me.HColSoLenh.UpdateIfNull = ""
        Me.HColSoLenh.UpdateWhenFormLock = False
        Me.HColSoLenh.UpperValue = False
        Me.HColSoLenh.ValidateValue = True
        Me.HColSoLenh.Visible = True
        Me.HColSoLenh.Width = 28
        '
        'ColMaLenh
        '
        Me.ColMaLenh.AllowInsert = False
        Me.ColMaLenh.AllowUpdate = False
        Me.ColMaLenh.ButtonClick = True
        Me.ColMaLenh.Caption = "MaLenh"
        Me.ColMaLenh.CFLColumnHide = ""
        Me.ColMaLenh.CFLKeyField = ""
        Me.ColMaLenh.CFLPage = False
        Me.ColMaLenh.CFLReturn0 = ""
        Me.ColMaLenh.CFLReturn1 = ""
        Me.ColMaLenh.CFLReturn2 = ""
        Me.ColMaLenh.CFLReturn3 = ""
        Me.ColMaLenh.CFLReturn4 = ""
        Me.ColMaLenh.CFLReturn5 = ""
        Me.ColMaLenh.CFLReturn6 = ""
        Me.ColMaLenh.CFLReturn7 = ""
        Me.ColMaLenh.CFLShowLoad = False
        Me.ColMaLenh.ChangeFormStatus = True
        Me.ColMaLenh.ColumnKey = True
        Me.ColMaLenh.ComboLine = 5
        Me.ColMaLenh.CopyFromItem = ""
        Me.ColMaLenh.DefaultButtonClick = False
        Me.ColMaLenh.Digit = False
        Me.ColMaLenh.FieldType = "C"
        Me.ColMaLenh.FieldView = "MaLenh"
        Me.ColMaLenh.FormarNumber = True
        Me.ColMaLenh.FormList = False
        Me.ColMaLenh.KeyInsert = ""
        Me.ColMaLenh.LocalDecimal = False
        Me.ColMaLenh.Name = "ColMaLenh"
        Me.ColMaLenh.NoUpdate = ""
        Me.ColMaLenh.NumberDecimal = 0
        Me.ColMaLenh.ParentControl = ""
        Me.ColMaLenh.RefreshSource = False
        Me.ColMaLenh.Required = False
        Me.ColMaLenh.SequenceName = ""
        Me.ColMaLenh.ShowCalc = True
        Me.ColMaLenh.ShowDataTime = False
        Me.ColMaLenh.ShowOnlyTime = False
        Me.ColMaLenh.SQLString = ""
        Me.ColMaLenh.UpdateIfNull = ""
        Me.ColMaLenh.UpdateWhenFormLock = False
        Me.ColMaLenh.UpperValue = False
        Me.ColMaLenh.ValidateValue = True
        Me.ColMaLenh.Visible = True
        Me.ColMaLenh.Width = 28
        '
        'HColNgayXuat
        '
        Me.HColNgayXuat.AllowInsert = False
        Me.HColNgayXuat.AllowUpdate = False
        Me.HColNgayXuat.ButtonClick = True
        Me.HColNgayXuat.Caption = "NgayXuat"
        Me.HColNgayXuat.CFLColumnHide = ""
        Me.HColNgayXuat.CFLKeyField = ""
        Me.HColNgayXuat.CFLPage = False
        Me.HColNgayXuat.CFLReturn0 = ""
        Me.HColNgayXuat.CFLReturn1 = ""
        Me.HColNgayXuat.CFLReturn2 = ""
        Me.HColNgayXuat.CFLReturn3 = ""
        Me.HColNgayXuat.CFLReturn4 = ""
        Me.HColNgayXuat.CFLReturn5 = ""
        Me.HColNgayXuat.CFLReturn6 = ""
        Me.HColNgayXuat.CFLReturn7 = ""
        Me.HColNgayXuat.CFLShowLoad = False
        Me.HColNgayXuat.ChangeFormStatus = True
        Me.HColNgayXuat.ColumnKey = False
        Me.HColNgayXuat.ComboLine = 5
        Me.HColNgayXuat.CopyFromItem = ""
        Me.HColNgayXuat.DefaultButtonClick = False
        Me.HColNgayXuat.Digit = False
        Me.HColNgayXuat.FieldType = "D"
        Me.HColNgayXuat.FieldView = "NgayXuat"
        Me.HColNgayXuat.FormarNumber = True
        Me.HColNgayXuat.FormList = False
        Me.HColNgayXuat.KeyInsert = ""
        Me.HColNgayXuat.LocalDecimal = False
        Me.HColNgayXuat.Name = "HColNgayXuat"
        Me.HColNgayXuat.NoUpdate = ""
        Me.HColNgayXuat.NumberDecimal = 0
        Me.HColNgayXuat.ParentControl = ""
        Me.HColNgayXuat.RefreshSource = False
        Me.HColNgayXuat.Required = False
        Me.HColNgayXuat.SequenceName = ""
        Me.HColNgayXuat.ShowCalc = True
        Me.HColNgayXuat.ShowDataTime = False
        Me.HColNgayXuat.ShowOnlyTime = False
        Me.HColNgayXuat.SQLString = ""
        Me.HColNgayXuat.UpdateIfNull = ""
        Me.HColNgayXuat.UpdateWhenFormLock = False
        Me.HColNgayXuat.UpperValue = False
        Me.HColNgayXuat.ValidateValue = True
        Me.HColNgayXuat.Visible = True
        Me.HColNgayXuat.Width = 28
        '
        'LineID
        '
        Me.LineID.AllowInsert = False
        Me.LineID.AllowUpdate = False
        Me.LineID.ButtonClick = True
        Me.LineID.Caption = "LineID"
        Me.LineID.CFLColumnHide = ""
        Me.LineID.CFLKeyField = ""
        Me.LineID.CFLPage = False
        Me.LineID.CFLReturn0 = ""
        Me.LineID.CFLReturn1 = ""
        Me.LineID.CFLReturn2 = ""
        Me.LineID.CFLReturn3 = ""
        Me.LineID.CFLReturn4 = ""
        Me.LineID.CFLReturn5 = ""
        Me.LineID.CFLReturn6 = ""
        Me.LineID.CFLReturn7 = ""
        Me.LineID.CFLShowLoad = False
        Me.LineID.ChangeFormStatus = True
        Me.LineID.ColumnKey = True
        Me.LineID.ComboLine = 5
        Me.LineID.CopyFromItem = ""
        Me.LineID.DefaultButtonClick = False
        Me.LineID.Digit = False
        Me.LineID.FieldType = "C"
        Me.LineID.FieldView = "LineID"
        Me.LineID.FormarNumber = True
        Me.LineID.FormList = False
        Me.LineID.KeyInsert = ""
        Me.LineID.LocalDecimal = False
        Me.LineID.Name = "LineID"
        Me.LineID.NoUpdate = ""
        Me.LineID.NumberDecimal = 0
        Me.LineID.ParentControl = ""
        Me.LineID.RefreshSource = False
        Me.LineID.Required = False
        Me.LineID.SequenceName = ""
        Me.LineID.ShowCalc = True
        Me.LineID.ShowDataTime = False
        Me.LineID.ShowOnlyTime = False
        Me.LineID.SQLString = ""
        Me.LineID.UpdateIfNull = ""
        Me.LineID.UpdateWhenFormLock = False
        Me.LineID.UpperValue = False
        Me.LineID.ValidateValue = True
        Me.LineID.Visible = True
        Me.LineID.Width = 28
        '
        'HCHECKUPD
        '
        Me.HCHECKUPD.AllowInsert = True
        Me.HCHECKUPD.AllowUpdate = True
        Me.HCHECKUPD.ButtonClick = True
        Me.HCHECKUPD.Caption = "CHECKUPD"
        Me.HCHECKUPD.CFLColumnHide = ""
        Me.HCHECKUPD.CFLKeyField = ""
        Me.HCHECKUPD.CFLPage = False
        Me.HCHECKUPD.CFLReturn0 = ""
        Me.HCHECKUPD.CFLReturn1 = ""
        Me.HCHECKUPD.CFLReturn2 = ""
        Me.HCHECKUPD.CFLReturn3 = ""
        Me.HCHECKUPD.CFLReturn4 = ""
        Me.HCHECKUPD.CFLReturn5 = ""
        Me.HCHECKUPD.CFLReturn6 = ""
        Me.HCHECKUPD.CFLReturn7 = ""
        Me.HCHECKUPD.CFLShowLoad = False
        Me.HCHECKUPD.ChangeFormStatus = True
        Me.HCHECKUPD.ColumnKey = False
        Me.HCHECKUPD.ComboLine = 5
        Me.HCHECKUPD.CopyFromItem = ""
        Me.HCHECKUPD.DefaultButtonClick = False
        Me.HCHECKUPD.Digit = False
        Me.HCHECKUPD.FieldType = "C"
        Me.HCHECKUPD.FieldView = "CHECKUPD"
        Me.HCHECKUPD.FormarNumber = True
        Me.HCHECKUPD.FormList = False
        Me.HCHECKUPD.KeyInsert = ""
        Me.HCHECKUPD.LocalDecimal = False
        Me.HCHECKUPD.MinWidth = 10
        Me.HCHECKUPD.Name = "HCHECKUPD"
        Me.HCHECKUPD.NoUpdate = ""
        Me.HCHECKUPD.NumberDecimal = 0
        Me.HCHECKUPD.ParentControl = ""
        Me.HCHECKUPD.RefreshSource = False
        Me.HCHECKUPD.Required = False
        Me.HCHECKUPD.SequenceName = ""
        Me.HCHECKUPD.ShowCalc = True
        Me.HCHECKUPD.ShowDataTime = False
        Me.HCHECKUPD.ShowOnlyTime = False
        Me.HCHECKUPD.SQLString = ""
        Me.HCHECKUPD.UpdateIfNull = ""
        Me.HCHECKUPD.UpdateWhenFormLock = False
        Me.HCHECKUPD.UpperValue = False
        Me.HCHECKUPD.ValidateValue = True
        Me.HCHECKUPD.Visible = True
        Me.HCHECKUPD.Width = 34
        '
        'Status
        '
        Me.Status.AllowInsert = False
        Me.Status.AllowUpdate = False
        Me.Status.ButtonClick = True
        Me.Status.Caption = "Trạng thái"
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
        Me.Status.FieldView = "Status"
        Me.Status.FormarNumber = True
        Me.Status.FormList = False
        Me.Status.KeyInsert = ""
        Me.Status.LocalDecimal = False
        Me.Status.Name = "Status"
        Me.Status.NoUpdate = ""
        Me.Status.NumberDecimal = 0
        Me.Status.OptionsColumn.ReadOnly = True
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
        Me.Status.VisibleIndex = 9
        '
        'MaVanChuyen
        '
        Me.MaVanChuyen.AllowInsert = True
        Me.MaVanChuyen.AllowUpdate = True
        Me.MaVanChuyen.ButtonClick = True
        Me.MaVanChuyen.Caption = "Mã vận chuyển"
        Me.MaVanChuyen.CFLColumnHide = ""
        Me.MaVanChuyen.CFLKeyField = ""
        Me.MaVanChuyen.CFLPage = False
        Me.MaVanChuyen.CFLReturn0 = ""
        Me.MaVanChuyen.CFLReturn1 = ""
        Me.MaVanChuyen.CFLReturn2 = ""
        Me.MaVanChuyen.CFLReturn3 = ""
        Me.MaVanChuyen.CFLReturn4 = ""
        Me.MaVanChuyen.CFLReturn5 = ""
        Me.MaVanChuyen.CFLReturn6 = ""
        Me.MaVanChuyen.CFLReturn7 = ""
        Me.MaVanChuyen.CFLShowLoad = False
        Me.MaVanChuyen.ChangeFormStatus = True
        Me.MaVanChuyen.ColumnKey = False
        Me.MaVanChuyen.ComboLine = 5
        Me.MaVanChuyen.CopyFromItem = ""
        Me.MaVanChuyen.DefaultButtonClick = False
        Me.MaVanChuyen.Digit = False
        Me.MaVanChuyen.FieldType = "C"
        Me.MaVanChuyen.FieldView = "MaVanChuyen"
        Me.MaVanChuyen.FormarNumber = True
        Me.MaVanChuyen.FormList = False
        Me.MaVanChuyen.KeyInsert = ""
        Me.MaVanChuyen.LocalDecimal = False
        Me.MaVanChuyen.Name = "MaVanChuyen"
        Me.MaVanChuyen.NoUpdate = ""
        Me.MaVanChuyen.NumberDecimal = 0
        Me.MaVanChuyen.ParentControl = ""
        Me.MaVanChuyen.RefreshSource = False
        Me.MaVanChuyen.Required = False
        Me.MaVanChuyen.SequenceName = ""
        Me.MaVanChuyen.ShowCalc = True
        Me.MaVanChuyen.ShowDataTime = False
        Me.MaVanChuyen.ShowOnlyTime = False
        Me.MaVanChuyen.SQLString = ""
        Me.MaVanChuyen.UpdateIfNull = ""
        Me.MaVanChuyen.UpdateWhenFormLock = False
        Me.MaVanChuyen.UpperValue = False
        Me.MaVanChuyen.ValidateValue = True
        Me.MaVanChuyen.Visible = True
        Me.MaVanChuyen.VisibleIndex = 10
        '
        'NgayTichKe
        '
        Me.NgayTichKe.AllowInsert = True
        Me.NgayTichKe.AllowUpdate = True
        Me.NgayTichKe.ButtonClick = True
        Me.NgayTichKe.Caption = "Ngày tích kê"
        Me.NgayTichKe.CFLColumnHide = ""
        Me.NgayTichKe.CFLKeyField = ""
        Me.NgayTichKe.CFLPage = False
        Me.NgayTichKe.CFLReturn0 = ""
        Me.NgayTichKe.CFLReturn1 = ""
        Me.NgayTichKe.CFLReturn2 = ""
        Me.NgayTichKe.CFLReturn3 = ""
        Me.NgayTichKe.CFLReturn4 = ""
        Me.NgayTichKe.CFLReturn5 = ""
        Me.NgayTichKe.CFLReturn6 = ""
        Me.NgayTichKe.CFLReturn7 = ""
        Me.NgayTichKe.CFLShowLoad = False
        Me.NgayTichKe.ChangeFormStatus = True
        Me.NgayTichKe.ColumnKey = False
        Me.NgayTichKe.ComboLine = 5
        Me.NgayTichKe.CopyFromItem = ""
        Me.NgayTichKe.DefaultButtonClick = False
        Me.NgayTichKe.Digit = False
        Me.NgayTichKe.FieldType = "D"
        Me.NgayTichKe.FieldView = "NgayTichKe"
        Me.NgayTichKe.FormarNumber = True
        Me.NgayTichKe.FormList = False
        Me.NgayTichKe.KeyInsert = ""
        Me.NgayTichKe.LocalDecimal = False
        Me.NgayTichKe.Name = "NgayTichKe"
        Me.NgayTichKe.NoUpdate = ""
        Me.NgayTichKe.NumberDecimal = 0
        Me.NgayTichKe.ParentControl = ""
        Me.NgayTichKe.RefreshSource = False
        Me.NgayTichKe.Required = False
        Me.NgayTichKe.SequenceName = ""
        Me.NgayTichKe.ShowCalc = True
        Me.NgayTichKe.ShowDataTime = False
        Me.NgayTichKe.ShowOnlyTime = False
        Me.NgayTichKe.SQLString = ""
        Me.NgayTichKe.UpdateIfNull = ""
        Me.NgayTichKe.UpdateWhenFormLock = False
        Me.NgayTichKe.UpperValue = False
        Me.NgayTichKe.ValidateValue = True
        Me.NgayTichKe.Visible = True
        Me.NgayTichKe.VisibleIndex = 11
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
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
        'RepositoryItemGridLookUpEdit1
        '
        Me.RepositoryItemGridLookUpEdit1.AutoHeight = False
        Me.RepositoryItemGridLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemGridLookUpEdit1.Name = "RepositoryItemGridLookUpEdit1"
        Me.RepositoryItemGridLookUpEdit1.View = Me.GridView2
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemComboBox3
        '
        Me.RepositoryItemComboBox3.AutoHeight = False
        Me.RepositoryItemComboBox3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox3.Name = "RepositoryItemComboBox3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 19)
        Me.Label1.TabIndex = 424
        Me.Label1.Text = "Số lệnh"
        '
        'SoLenh
        '
        Me.SoLenh.AllowInsert = False
        Me.SoLenh.AllowUpdate = False
        Me.SoLenh.AutoKeyFix = ""
        Me.SoLenh.AutoKeyName = ""
        Me.SoLenh.BindingSourceName = ""
        Me.SoLenh.ChangeFormStatus = False
        Me.SoLenh.CopyFromItem = ""
        Me.SoLenh.DefaultValue = ""
        Me.SoLenh.FieldName = ""
        Me.SoLenh.FieldType = "C"
        Me.SoLenh.KeyInsert = "Y"
        Me.SoLenh.LinkLabel = ""
        Me.SoLenh.Location = New System.Drawing.Point(100, 70)
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = "N"
        Me.SoLenh.PrimaryKey = ""
        Me.SoLenh.Properties.AutoHeight = False
        Me.SoLenh.Properties.MaxLength = 10
        Me.SoLenh.Required = ""
        Me.SoLenh.Size = New System.Drawing.Size(140, 26)
        Me.SoLenh.TabIndex = 423
        Me.SoLenh.TableName = ""
        Me.SoLenh.UpdateIfNull = "N"
        Me.SoLenh.UpdateWhenFormLock = False
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ViewName = ""
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.Location = New System.Drawing.Point(246, 70)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(90, 26)
        Me.SimpleButton7.TabIndex = 425
        Me.SimpleButton7.Text = "&Tìm kiếm"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(906, 28)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NhomBe)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CreateDate)
        Me.GroupBox1.Controls.Add(Me.SimpleButton1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TankNew)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TankOld)
        Me.GroupBox1.Location = New System.Drawing.Point(496, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 96)
        Me.GroupBox1.TabIndex = 483
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cập nhật hàng loạt"
        '
        'NhomBe
        '
        Me.NhomBe.AllowInsert = False
        Me.NhomBe.AllowUpdate = False
        Me.NhomBe.AutoKeyFix = ""
        Me.NhomBe.AutoKeyName = ""
        Me.NhomBe.BindingSourceName = ""
        Me.NhomBe.ChangeFormStatus = False
        Me.NhomBe.CopyFromItem = ""
        Me.NhomBe.DefaultValue = ""
        Me.NhomBe.FieldName = ""
        Me.NhomBe.FieldType = "C"
        Me.NhomBe.KeyInsert = "Y"
        Me.NhomBe.LinkLabel = ""
        Me.NhomBe.Location = New System.Drawing.Point(161, 55)
        Me.NhomBe.Name = "NhomBe"
        Me.NhomBe.NoUpdate = "N"
        Me.NhomBe.PrimaryKey = ""
        Me.NhomBe.Properties.AutoHeight = False
        Me.NhomBe.Properties.MaxLength = 10
        Me.NhomBe.Properties.ReadOnly = True
        Me.NhomBe.Required = ""
        Me.NhomBe.Size = New System.Drawing.Size(57, 26)
        Me.NhomBe.TabIndex = 490
        Me.NhomBe.TableName = ""
        Me.NhomBe.UpdateIfNull = "N"
        Me.NhomBe.UpdateWhenFormLock = False
        Me.NhomBe.UpperValue = False
        Me.NhomBe.ViewName = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(164, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 19)
        Me.Label4.TabIndex = 489
        Me.Label4.Text = "Ngày tháng"
        '
        'CreateDate
        '
        Me.CreateDate.AllowInsert = True
        Me.CreateDate.AllowUpdate = True
        Me.CreateDate.BindingSourceName = ""
        Me.CreateDate.ChangeFormStatus = True
        Me.CreateDate.CopyFromItem = ""
        Me.CreateDate.DefaultValue = ""
        Me.CreateDate.EditValue = Nothing
        Me.CreateDate.FieldName = ""
        Me.CreateDate.FieldType = "D"
        Me.CreateDate.KeyInsert = ""
        Me.CreateDate.LinkLabel = "Label2"
        Me.CreateDate.Location = New System.Drawing.Point(260, 20)
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
        Me.CreateDate.Size = New System.Drawing.Size(125, 26)
        Me.CreateDate.TabIndex = 488
        Me.CreateDate.TableName = ""
        Me.CreateDate.TabStop = False
        Me.CreateDate.UpdateIfNull = ""
        Me.CreateDate.UpdateWhenFormLock = False
        Me.CreateDate.ViewName = ""
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Location = New System.Drawing.Point(295, 58)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(90, 26)
        Me.SimpleButton1.TabIndex = 487
        Me.SimpleButton1.Text = "Cập nhật"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 19)
        Me.Label3.TabIndex = 486
        Me.Label3.Text = "Bể mới"
        '
        'TankNew
        '
        Me.TankNew.AllowInsert = True
        Me.TankNew.AllowUpdate = True
        Me.TankNew.AutoWidth = False
        Me.TankNew.BindingSourceName = ""
        Me.TankNew.ChangeFormStatus = True
        Me.TankNew.CopyFromItem = ""
        Me.TankNew.DefaultButtonClick = True
        Me.TankNew.DefaultValue = ""
        Me.TankNew.FieldName = ""
        Me.TankNew.FieldType = "C"
        Me.TankNew.FormList = False
        Me.TankNew.ItemReturn1 = ""
        Me.TankNew.ItemReturn2 = "NhomBe"
        Me.TankNew.ItemReturn3 = ""
        Me.TankNew.KeyInsert = ""
        Me.TankNew.LinkLabel = ""
        Me.TankNew.Location = New System.Drawing.Point(72, 55)
        Me.TankNew.MultiSelect = False
        Me.TankNew.Name = "TankNew"
        Me.TankNew.NoUpdate = "N"
        Me.TankNew.OrderbyEx = ""
        Me.TankNew.PrimaryKey = ""
        Me.TankNew.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankNew.Properties.Appearance.Options.UseFont = True
        Me.TankNew.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankNew.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TankNew.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankNew.Properties.AppearanceFocused.Options.UseFont = True
        Me.TankNew.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankNew.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TankNew.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TankNew.Required = ""
        Me.TankNew.ShowLoad = True
        Me.TankNew.Size = New System.Drawing.Size(83, 26)
        Me.TankNew.SqlFielKey = "Name_nd"
        Me.TankNew.SqlString = ""
        Me.TankNew.TabIndex = 485
        Me.TankNew.TableName = ""
        Me.TankNew.UpdateIfNull = ""
        Me.TankNew.UpdateWhenFormLock = False
        Me.TankNew.UpperValue = True
        Me.TankNew.ValidateValue = False
        Me.TankNew.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 19)
        Me.Label2.TabIndex = 484
        Me.Label2.Text = "Bể cũ"
        '
        'TankOld
        '
        Me.TankOld.AllowInsert = True
        Me.TankOld.AllowUpdate = True
        Me.TankOld.AutoWidth = False
        Me.TankOld.BindingSourceName = ""
        Me.TankOld.ChangeFormStatus = True
        Me.TankOld.CopyFromItem = ""
        Me.TankOld.DefaultButtonClick = True
        Me.TankOld.DefaultValue = ""
        Me.TankOld.FieldName = ""
        Me.TankOld.FieldType = "C"
        Me.TankOld.FormList = True
        Me.TankOld.ItemReturn1 = ""
        Me.TankOld.ItemReturn2 = ""
        Me.TankOld.ItemReturn3 = ""
        Me.TankOld.KeyInsert = ""
        Me.TankOld.LinkLabel = ""
        Me.TankOld.Location = New System.Drawing.Point(72, 23)
        Me.TankOld.MultiSelect = False
        Me.TankOld.Name = "TankOld"
        Me.TankOld.NoUpdate = "N"
        Me.TankOld.OrderbyEx = ""
        Me.TankOld.PrimaryKey = ""
        Me.TankOld.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankOld.Properties.Appearance.Options.UseFont = True
        Me.TankOld.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankOld.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TankOld.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankOld.Properties.AppearanceFocused.Options.UseFont = True
        Me.TankOld.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankOld.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TankOld.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TankOld.Required = ""
        Me.TankOld.ShowLoad = True
        Me.TankOld.Size = New System.Drawing.Size(83, 26)
        Me.TankOld.SqlFielKey = "Name_nd"
        Me.TankOld.SqlString = ""
        Me.TankOld.TabIndex = 483
        Me.TankOld.TableName = ""
        Me.TankOld.UpdateIfNull = ""
        Me.TankOld.UpdateWhenFormLock = False
        Me.TankOld.UpperValue = True
        Me.TankOld.ValidateValue = False
        Me.TankOld.ViewName = ""
        '
        'FrmTankChange
        '
        Me.AcceptButton = Me.SimpleButton7
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 410)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SoLenh)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmTankChange"
        Me.ShowFormMessage = True
        Me.Text = "Đổi bể xuất"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.SoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NhomBe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreateDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TankNew.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TankOld.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents TableID As U_TextBox.GridColumn
    Friend WithEvents MaHangHoa As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents TenHangHoa As U_TextBox.GridColumn
    Friend WithEvents DonViTinh As U_TextBox.GridColumn
    Friend WithEvents TongDuXuat As U_TextBox.GridColumn
    Friend WithEvents HColTongXuat As U_TextBox.GridColumn
    Friend WithEvents MeterId As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents BeXuat As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents HColSoLenh As U_TextBox.GridColumn
    Friend WithEvents ColMaLenh As U_TextBox.GridColumn
    Friend WithEvents HColNgayXuat As U_TextBox.GridColumn
    Friend WithEvents LineID As U_TextBox.GridColumn
    Friend WithEvents HCHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SoLenh As U_TextBox.U_TextBox
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents RepositoryItemComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Status As U_TextBox.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaVanChuyen As U_TextBox.GridColumn
    Friend WithEvents NgayTichKe As U_TextBox.GridColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TankNew As U_TextBox.U_ButtonEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TankOld As U_TextBox.U_ButtonEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CreateDate As U_TextBox.U_DateEdit
    Friend WithEvents NhomBeXuat As U_TextBox.GridColumn
    Friend WithEvents NhomBe As U_TextBox.U_TextBox
End Class
