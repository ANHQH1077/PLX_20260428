<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQCIThuy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQCIThuy))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.MaNgan = New U_TextBox.GridColumn()
        Me.MaHangHoa = New U_TextBox.GridColumn()
        Me.TenHangHoa = New U_TextBox.GridColumn()
        Me.ThucXuat = New U_TextBox.GridColumn()
        Me.DonViTinh = New U_TextBox.GridColumn()
        Me.NhietDo = New U_TextBox.GridColumn()
        Me.TyTrong = New U_TextBox.GridColumn()
        Me.Ltt = New U_TextBox.GridColumn()
        Me.L15 = New U_TextBox.GridColumn()
        Me.M15 = New U_TextBox.GridColumn()
        Me.Kg = New U_TextBox.GridColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(4, 36)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(779, 201)
        Me.TrueDBGrid1.TabIndex = 1
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MaNgan, Me.MaHangHoa, Me.TenHangHoa, Me.ThucXuat, Me.DonViTinh, Me.NhietDo, Me.TyTrong, Me.Ltt, Me.L15, Me.M15, Me.Kg})
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
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = ""
        Me.GridView1.Where = Nothing
        '
        'MaNgan
        '
        Me.MaNgan.AllowInsert = True
        Me.MaNgan.AllowUpdate = True
        Me.MaNgan.Caption = "Ngăn"
        Me.MaNgan.CFLColumnHide = ""
        Me.MaNgan.CFLKeyField = ""
        Me.MaNgan.CFLPage = False
        Me.MaNgan.CFLReturn0 = ""
        Me.MaNgan.CFLReturn1 = ""
        Me.MaNgan.CFLReturn2 = ""
        Me.MaNgan.CFLReturn3 = ""
        Me.MaNgan.CFLReturn4 = ""
        Me.MaNgan.CFLReturn5 = ""
        Me.MaNgan.CFLReturn6 = ""
        Me.MaNgan.CFLReturn7 = ""
        Me.MaNgan.CFLShowLoad = False
        Me.MaNgan.ChangeFormStatus = True
        Me.MaNgan.ColumnKey = False
        Me.MaNgan.ComboLine = 5
        Me.MaNgan.CopyFromItem = ""
        Me.MaNgan.DefaultButtonClick = False
        Me.MaNgan.Digit = False
        Me.MaNgan.FieldType = "C"
        Me.MaNgan.FieldView = "MaNgan"
        Me.MaNgan.FormList = False
        Me.MaNgan.KeyInsert = ""
        Me.MaNgan.LocalDecimal = False
        Me.MaNgan.Name = "MaNgan"
        Me.MaNgan.NoUpdate = ""
        Me.MaNgan.NumberDecimal = 0
        Me.MaNgan.OptionsColumn.ReadOnly = True
        Me.MaNgan.ParentControl = ""
        Me.MaNgan.RefreshSource = False
        Me.MaNgan.Required = False
        Me.MaNgan.ShowDataTime = False
        Me.MaNgan.SQLString = ""
        Me.MaNgan.UpdateIfNull = ""
        Me.MaNgan.UpdateWhenFormLock = False
        Me.MaNgan.ValidateValue = True
        Me.MaNgan.Visible = True
        Me.MaNgan.VisibleIndex = 0
        '
        'MaHangHoa
        '
        Me.MaHangHoa.AllowInsert = True
        Me.MaHangHoa.AllowUpdate = True
        Me.MaHangHoa.Caption = "Mã HH"
        Me.MaHangHoa.CFLColumnHide = ""
        Me.MaHangHoa.CFLKeyField = ""
        Me.MaHangHoa.CFLPage = False
        Me.MaHangHoa.CFLReturn0 = ""
        Me.MaHangHoa.CFLReturn1 = ""
        Me.MaHangHoa.CFLReturn2 = ""
        Me.MaHangHoa.CFLReturn3 = ""
        Me.MaHangHoa.CFLReturn4 = ""
        Me.MaHangHoa.CFLReturn5 = ""
        Me.MaHangHoa.CFLReturn6 = ""
        Me.MaHangHoa.CFLReturn7 = ""
        Me.MaHangHoa.CFLShowLoad = False
        Me.MaHangHoa.ChangeFormStatus = True
        Me.MaHangHoa.ColumnKey = False
        Me.MaHangHoa.ComboLine = 5
        Me.MaHangHoa.CopyFromItem = ""
        Me.MaHangHoa.DefaultButtonClick = False
        Me.MaHangHoa.Digit = False
        Me.MaHangHoa.FieldType = "C"
        Me.MaHangHoa.FieldView = "MaHangHoa"
        Me.MaHangHoa.FormList = False
        Me.MaHangHoa.KeyInsert = ""
        Me.MaHangHoa.LocalDecimal = False
        Me.MaHangHoa.Name = "MaHangHoa"
        Me.MaHangHoa.NoUpdate = ""
        Me.MaHangHoa.NumberDecimal = 0
        Me.MaHangHoa.OptionsColumn.ReadOnly = True
        Me.MaHangHoa.ParentControl = ""
        Me.MaHangHoa.RefreshSource = False
        Me.MaHangHoa.Required = False
        Me.MaHangHoa.ShowDataTime = False
        Me.MaHangHoa.SQLString = ""
        Me.MaHangHoa.UpdateIfNull = ""
        Me.MaHangHoa.UpdateWhenFormLock = False
        Me.MaHangHoa.ValidateValue = True
        Me.MaHangHoa.Visible = True
        Me.MaHangHoa.VisibleIndex = 1
        '
        'TenHangHoa
        '
        Me.TenHangHoa.AllowInsert = True
        Me.TenHangHoa.AllowUpdate = True
        Me.TenHangHoa.Caption = "Tên hàng hóa"
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
        Me.TenHangHoa.ShowDataTime = False
        Me.TenHangHoa.SQLString = ""
        Me.TenHangHoa.UpdateIfNull = ""
        Me.TenHangHoa.UpdateWhenFormLock = False
        Me.TenHangHoa.ValidateValue = True
        Me.TenHangHoa.Visible = True
        Me.TenHangHoa.VisibleIndex = 2
        Me.TenHangHoa.Width = 250
        '
        'ThucXuat
        '
        Me.ThucXuat.AllowInsert = True
        Me.ThucXuat.AllowUpdate = True
        Me.ThucXuat.Caption = "Thực xuất"
        Me.ThucXuat.CFLColumnHide = ""
        Me.ThucXuat.CFLKeyField = ""
        Me.ThucXuat.CFLPage = False
        Me.ThucXuat.CFLReturn0 = ""
        Me.ThucXuat.CFLReturn1 = ""
        Me.ThucXuat.CFLReturn2 = ""
        Me.ThucXuat.CFLReturn3 = ""
        Me.ThucXuat.CFLReturn4 = ""
        Me.ThucXuat.CFLReturn5 = ""
        Me.ThucXuat.CFLReturn6 = ""
        Me.ThucXuat.CFLReturn7 = ""
        Me.ThucXuat.CFLShowLoad = False
        Me.ThucXuat.ChangeFormStatus = True
        Me.ThucXuat.ColumnKey = False
        Me.ThucXuat.ComboLine = 5
        Me.ThucXuat.CopyFromItem = ""
        Me.ThucXuat.DefaultButtonClick = False
        Me.ThucXuat.Digit = False
        Me.ThucXuat.FieldType = "N"
        Me.ThucXuat.FieldView = "SoLuong"
        Me.ThucXuat.FormList = False
        Me.ThucXuat.KeyInsert = ""
        Me.ThucXuat.LocalDecimal = False
        Me.ThucXuat.Name = "ThucXuat"
        Me.ThucXuat.NoUpdate = ""
        Me.ThucXuat.NumberDecimal = 0
        Me.ThucXuat.OptionsColumn.ReadOnly = True
        Me.ThucXuat.ParentControl = ""
        Me.ThucXuat.RefreshSource = False
        Me.ThucXuat.Required = False
        Me.ThucXuat.ShowDataTime = False
        Me.ThucXuat.SQLString = ""
        Me.ThucXuat.UpdateIfNull = ""
        Me.ThucXuat.UpdateWhenFormLock = False
        Me.ThucXuat.ValidateValue = True
        Me.ThucXuat.Visible = True
        Me.ThucXuat.VisibleIndex = 3
        '
        'DonViTinh
        '
        Me.DonViTinh.AllowInsert = True
        Me.DonViTinh.AllowUpdate = True
        Me.DonViTinh.Caption = "ĐVT"
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
        Me.DonViTinh.FieldView = "DVT"
        Me.DonViTinh.FormList = False
        Me.DonViTinh.KeyInsert = ""
        Me.DonViTinh.LocalDecimal = False
        Me.DonViTinh.Name = "DonViTinh"
        Me.DonViTinh.NoUpdate = ""
        Me.DonViTinh.NumberDecimal = 0
        Me.DonViTinh.OptionsColumn.ReadOnly = True
        Me.DonViTinh.ParentControl = ""
        Me.DonViTinh.RefreshSource = False
        Me.DonViTinh.Required = False
        Me.DonViTinh.ShowDataTime = False
        Me.DonViTinh.SQLString = ""
        Me.DonViTinh.UpdateIfNull = ""
        Me.DonViTinh.UpdateWhenFormLock = False
        Me.DonViTinh.ValidateValue = True
        Me.DonViTinh.Visible = True
        Me.DonViTinh.VisibleIndex = 4
        '
        'NhietDo
        '
        Me.NhietDo.AllowInsert = True
        Me.NhietDo.AllowUpdate = True
        Me.NhietDo.Caption = "N.Độ"
        Me.NhietDo.CFLColumnHide = ""
        Me.NhietDo.CFLKeyField = ""
        Me.NhietDo.CFLPage = False
        Me.NhietDo.CFLReturn0 = ""
        Me.NhietDo.CFLReturn1 = ""
        Me.NhietDo.CFLReturn2 = ""
        Me.NhietDo.CFLReturn3 = ""
        Me.NhietDo.CFLReturn4 = ""
        Me.NhietDo.CFLReturn5 = ""
        Me.NhietDo.CFLReturn6 = ""
        Me.NhietDo.CFLReturn7 = ""
        Me.NhietDo.CFLShowLoad = False
        Me.NhietDo.ChangeFormStatus = True
        Me.NhietDo.ColumnKey = False
        Me.NhietDo.ComboLine = 5
        Me.NhietDo.CopyFromItem = ""
        Me.NhietDo.DefaultButtonClick = False
        Me.NhietDo.Digit = True
        Me.NhietDo.FieldType = "N"
        Me.NhietDo.FieldView = "NhietDo"
        Me.NhietDo.FormList = False
        Me.NhietDo.KeyInsert = ""
        Me.NhietDo.LocalDecimal = True
        Me.NhietDo.Name = "NhietDo"
        Me.NhietDo.NoUpdate = ""
        Me.NhietDo.NumberDecimal = 2
        Me.NhietDo.ParentControl = ""
        Me.NhietDo.RefreshSource = False
        Me.NhietDo.Required = False
        Me.NhietDo.ShowDataTime = False
        Me.NhietDo.SQLString = ""
        Me.NhietDo.UpdateIfNull = ""
        Me.NhietDo.UpdateWhenFormLock = False
        Me.NhietDo.ValidateValue = True
        Me.NhietDo.Visible = True
        Me.NhietDo.VisibleIndex = 5
        '
        'TyTrong
        '
        Me.TyTrong.AllowInsert = True
        Me.TyTrong.AllowUpdate = True
        Me.TyTrong.Caption = "T.Trọng"
        Me.TyTrong.CFLColumnHide = ""
        Me.TyTrong.CFLKeyField = ""
        Me.TyTrong.CFLPage = False
        Me.TyTrong.CFLReturn0 = ""
        Me.TyTrong.CFLReturn1 = ""
        Me.TyTrong.CFLReturn2 = ""
        Me.TyTrong.CFLReturn3 = ""
        Me.TyTrong.CFLReturn4 = ""
        Me.TyTrong.CFLReturn5 = ""
        Me.TyTrong.CFLReturn6 = ""
        Me.TyTrong.CFLReturn7 = ""
        Me.TyTrong.CFLShowLoad = False
        Me.TyTrong.ChangeFormStatus = True
        Me.TyTrong.ColumnKey = False
        Me.TyTrong.ComboLine = 5
        Me.TyTrong.CopyFromItem = ""
        Me.TyTrong.DefaultButtonClick = False
        Me.TyTrong.Digit = True
        Me.TyTrong.FieldType = "N"
        Me.TyTrong.FieldView = "TyTrong"
        Me.TyTrong.FormList = False
        Me.TyTrong.KeyInsert = ""
        Me.TyTrong.LocalDecimal = True
        Me.TyTrong.Name = "TyTrong"
        Me.TyTrong.NoUpdate = ""
        Me.TyTrong.NumberDecimal = 4
        Me.TyTrong.ParentControl = ""
        Me.TyTrong.RefreshSource = False
        Me.TyTrong.Required = False
        Me.TyTrong.ShowDataTime = False
        Me.TyTrong.SQLString = ""
        Me.TyTrong.UpdateIfNull = ""
        Me.TyTrong.UpdateWhenFormLock = False
        Me.TyTrong.ValidateValue = True
        Me.TyTrong.Visible = True
        Me.TyTrong.VisibleIndex = 6
        '
        'Ltt
        '
        Me.Ltt.AllowInsert = True
        Me.Ltt.AllowUpdate = True
        Me.Ltt.Caption = "Ltt"
        Me.Ltt.CFLColumnHide = ""
        Me.Ltt.CFLKeyField = ""
        Me.Ltt.CFLPage = False
        Me.Ltt.CFLReturn0 = ""
        Me.Ltt.CFLReturn1 = ""
        Me.Ltt.CFLReturn2 = ""
        Me.Ltt.CFLReturn3 = ""
        Me.Ltt.CFLReturn4 = ""
        Me.Ltt.CFLReturn5 = ""
        Me.Ltt.CFLReturn6 = ""
        Me.Ltt.CFLReturn7 = ""
        Me.Ltt.CFLShowLoad = False
        Me.Ltt.ChangeFormStatus = True
        Me.Ltt.ColumnKey = False
        Me.Ltt.ComboLine = 5
        Me.Ltt.CopyFromItem = ""
        Me.Ltt.DefaultButtonClick = False
        Me.Ltt.Digit = False
        Me.Ltt.FieldType = "N"
        Me.Ltt.FieldView = "Ltt"
        Me.Ltt.FormList = False
        Me.Ltt.KeyInsert = ""
        Me.Ltt.LocalDecimal = False
        Me.Ltt.Name = "Ltt"
        Me.Ltt.NoUpdate = ""
        Me.Ltt.NumberDecimal = 0
        Me.Ltt.OptionsColumn.ReadOnly = True
        Me.Ltt.ParentControl = ""
        Me.Ltt.RefreshSource = False
        Me.Ltt.Required = False
        Me.Ltt.ShowDataTime = False
        Me.Ltt.SQLString = ""
        Me.Ltt.UpdateIfNull = ""
        Me.Ltt.UpdateWhenFormLock = False
        Me.Ltt.ValidateValue = True
        Me.Ltt.Visible = True
        Me.Ltt.VisibleIndex = 7
        '
        'L15
        '
        Me.L15.AllowInsert = True
        Me.L15.AllowUpdate = True
        Me.L15.Caption = "L15"
        Me.L15.CFLColumnHide = ""
        Me.L15.CFLKeyField = ""
        Me.L15.CFLPage = False
        Me.L15.CFLReturn0 = ""
        Me.L15.CFLReturn1 = ""
        Me.L15.CFLReturn2 = ""
        Me.L15.CFLReturn3 = ""
        Me.L15.CFLReturn4 = ""
        Me.L15.CFLReturn5 = ""
        Me.L15.CFLReturn6 = ""
        Me.L15.CFLReturn7 = ""
        Me.L15.CFLShowLoad = False
        Me.L15.ChangeFormStatus = True
        Me.L15.ColumnKey = False
        Me.L15.ComboLine = 5
        Me.L15.CopyFromItem = ""
        Me.L15.DefaultButtonClick = False
        Me.L15.Digit = False
        Me.L15.FieldType = "N"
        Me.L15.FieldView = "L15"
        Me.L15.FormList = False
        Me.L15.KeyInsert = ""
        Me.L15.LocalDecimal = False
        Me.L15.Name = "L15"
        Me.L15.NoUpdate = ""
        Me.L15.NumberDecimal = 0
        Me.L15.OptionsColumn.ReadOnly = True
        Me.L15.ParentControl = ""
        Me.L15.RefreshSource = False
        Me.L15.Required = False
        Me.L15.ShowDataTime = False
        Me.L15.SQLString = ""
        Me.L15.UpdateIfNull = ""
        Me.L15.UpdateWhenFormLock = False
        Me.L15.ValidateValue = True
        Me.L15.Visible = True
        Me.L15.VisibleIndex = 8
        '
        'M15
        '
        Me.M15.AllowInsert = True
        Me.M15.AllowUpdate = True
        Me.M15.Caption = "M15"
        Me.M15.CFLColumnHide = ""
        Me.M15.CFLKeyField = ""
        Me.M15.CFLPage = False
        Me.M15.CFLReturn0 = ""
        Me.M15.CFLReturn1 = ""
        Me.M15.CFLReturn2 = ""
        Me.M15.CFLReturn3 = ""
        Me.M15.CFLReturn4 = ""
        Me.M15.CFLReturn5 = ""
        Me.M15.CFLReturn6 = ""
        Me.M15.CFLReturn7 = ""
        Me.M15.CFLShowLoad = False
        Me.M15.ChangeFormStatus = True
        Me.M15.ColumnKey = False
        Me.M15.ComboLine = 5
        Me.M15.CopyFromItem = ""
        Me.M15.DefaultButtonClick = False
        Me.M15.Digit = False
        Me.M15.FieldType = "N"
        Me.M15.FieldView = "M15"
        Me.M15.FormList = False
        Me.M15.KeyInsert = ""
        Me.M15.LocalDecimal = False
        Me.M15.Name = "M15"
        Me.M15.NoUpdate = ""
        Me.M15.NumberDecimal = 0
        Me.M15.OptionsColumn.ReadOnly = True
        Me.M15.ParentControl = ""
        Me.M15.RefreshSource = False
        Me.M15.Required = False
        Me.M15.ShowDataTime = False
        Me.M15.SQLString = ""
        Me.M15.UpdateIfNull = ""
        Me.M15.UpdateWhenFormLock = False
        Me.M15.ValidateValue = True
        Me.M15.Visible = True
        Me.M15.VisibleIndex = 9
        '
        'Kg
        '
        Me.Kg.AllowInsert = True
        Me.Kg.AllowUpdate = True
        Me.Kg.Caption = "Kg"
        Me.Kg.CFLColumnHide = ""
        Me.Kg.CFLKeyField = ""
        Me.Kg.CFLPage = False
        Me.Kg.CFLReturn0 = ""
        Me.Kg.CFLReturn1 = ""
        Me.Kg.CFLReturn2 = ""
        Me.Kg.CFLReturn3 = ""
        Me.Kg.CFLReturn4 = ""
        Me.Kg.CFLReturn5 = ""
        Me.Kg.CFLReturn6 = ""
        Me.Kg.CFLReturn7 = ""
        Me.Kg.CFLShowLoad = False
        Me.Kg.ChangeFormStatus = True
        Me.Kg.ColumnKey = False
        Me.Kg.ComboLine = 5
        Me.Kg.CopyFromItem = ""
        Me.Kg.DefaultButtonClick = False
        Me.Kg.Digit = False
        Me.Kg.FieldType = "N"
        Me.Kg.FieldView = "Kg"
        Me.Kg.FormList = False
        Me.Kg.KeyInsert = ""
        Me.Kg.LocalDecimal = False
        Me.Kg.Name = "Kg"
        Me.Kg.NoUpdate = ""
        Me.Kg.NumberDecimal = 0
        Me.Kg.OptionsColumn.ReadOnly = True
        Me.Kg.ParentControl = ""
        Me.Kg.RefreshSource = False
        Me.Kg.Required = False
        Me.Kg.ShowDataTime = False
        Me.Kg.SQLString = ""
        Me.Kg.UpdateIfNull = ""
        Me.Kg.UpdateWhenFormLock = False
        Me.Kg.ValidateValue = True
        Me.Kg.Visible = True
        Me.Kg.VisibleIndex = 10
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(786, 28)
        Me.ToolStrip2.TabIndex = 469
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(72, 25)
        Me.ToolStripButton7.Text = "&1. QCI"
        '
        'FrmQCIThuy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 266)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmQCIThuy"
        Me.Text = "Quy đổi thực xuất"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaNgan As U_TextBox.GridColumn
    Friend WithEvents MaHangHoa As U_TextBox.GridColumn
    Friend WithEvents ThucXuat As U_TextBox.GridColumn
    Friend WithEvents DonViTinh As U_TextBox.GridColumn
    Friend WithEvents NhietDo As U_TextBox.GridColumn
    Friend WithEvents TyTrong As U_TextBox.GridColumn
    Friend WithEvents Ltt As U_TextBox.GridColumn
    Friend WithEvents L15 As U_TextBox.GridColumn
    Friend WithEvents M15 As U_TextBox.GridColumn
    Friend WithEvents Kg As U_TextBox.GridColumn
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TenHangHoa As U_TextBox.GridColumn
End Class
