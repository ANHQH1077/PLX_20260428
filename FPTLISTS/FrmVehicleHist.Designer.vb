<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehicleHist
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.GridColumn1 = New U_TextBox.GridColumn()
        Me.SoNgan = New U_TextBox.GridColumn()
        Me.iweight = New U_TextBox.GridColumn()
        Me.NgayBatDau1 = New U_TextBox.GridColumn()
        Me.NgayHieuLuc1 = New U_TextBox.GridColumn()
        Me.Date22 = New U_TextBox.GridColumn()
        Me.Createby = New U_TextBox.GridColumn()
        Me.SyncDate = New U_TextBox.GridColumn()
        Me.TrueDBGrid2 = New U_TextBox.TrueDBGrid()
        Me.GridView2 = New U_TextBox.GridView()
        Me.MaNgan = New U_TextBox.GridColumn()
        Me.SoLuongMax = New U_TextBox.GridColumn()
        Me.Createby11 = New U_TextBox.GridColumn()
        Me.SyncDate11 = New U_TextBox.GridColumn()
        Me.UpdStatus11 = New U_TextBox.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(775, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(211, 19)
        Me.Label2.TabIndex = 479
        Me.Label2.Text = "Thông tin thay đổi dung tích"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 19)
        Me.Label1.TabIndex = 478
        Me.Label1.Text = "Thông tin thay đổi phương tiện"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(6, 43)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(686, 445)
        Me.TrueDBGrid1.TabIndex = 480
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.SoNgan, Me.iweight, Me.NgayBatDau1, Me.NgayHieuLuc1, Me.Date22, Me.Createby, Me.SyncDate})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = False
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "Row# desc"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "tblPhuongTien_Hist_V"
        Me.GridView1.Where = Nothing
        '
        'GridColumn1
        '
        Me.GridColumn1.AllowInsert = True
        Me.GridColumn1.AllowUpdate = True
        Me.GridColumn1.ButtonClick = True
        Me.GridColumn1.Caption = "Lần  cập nhật"
        Me.GridColumn1.CFLColumnHide = ""
        Me.GridColumn1.CFLKeyField = ""
        Me.GridColumn1.CFLPage = False
        Me.GridColumn1.CFLReturn0 = ""
        Me.GridColumn1.CFLReturn1 = ""
        Me.GridColumn1.CFLReturn2 = ""
        Me.GridColumn1.CFLReturn3 = ""
        Me.GridColumn1.CFLReturn4 = ""
        Me.GridColumn1.CFLReturn5 = ""
        Me.GridColumn1.CFLReturn6 = ""
        Me.GridColumn1.CFLReturn7 = ""
        Me.GridColumn1.CFLShowLoad = False
        Me.GridColumn1.ChangeFormStatus = True
        Me.GridColumn1.ColumnKey = False
        Me.GridColumn1.ComboLine = 5
        Me.GridColumn1.CopyFromItem = ""
        Me.GridColumn1.DefaultButtonClick = False
        Me.GridColumn1.Digit = False
        Me.GridColumn1.FieldType = "N"
        Me.GridColumn1.FieldView = "Row#"
        Me.GridColumn1.FormarNumber = True
        Me.GridColumn1.FormList = False
        Me.GridColumn1.KeyInsert = ""
        Me.GridColumn1.LocalDecimal = False
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.NoUpdate = ""
        Me.GridColumn1.NumberDecimal = 0
        Me.GridColumn1.ParentControl = ""
        Me.GridColumn1.RefreshSource = False
        Me.GridColumn1.Required = False
        Me.GridColumn1.SequenceName = ""
        Me.GridColumn1.ShowCalc = True
        Me.GridColumn1.ShowDataTime = False
        Me.GridColumn1.ShowOnlyTime = False
        Me.GridColumn1.SQLString = ""
        Me.GridColumn1.UpdateIfNull = ""
        Me.GridColumn1.UpdateWhenFormLock = False
        Me.GridColumn1.ValidateValue = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 70
        '
        'SoNgan
        '
        Me.SoNgan.AllowInsert = True
        Me.SoNgan.AllowUpdate = True
        Me.SoNgan.ButtonClick = True
        Me.SoNgan.Caption = "Số ngăn "
        Me.SoNgan.CFLColumnHide = ""
        Me.SoNgan.CFLKeyField = ""
        Me.SoNgan.CFLPage = False
        Me.SoNgan.CFLReturn0 = ""
        Me.SoNgan.CFLReturn1 = ""
        Me.SoNgan.CFLReturn2 = ""
        Me.SoNgan.CFLReturn3 = ""
        Me.SoNgan.CFLReturn4 = ""
        Me.SoNgan.CFLReturn5 = ""
        Me.SoNgan.CFLReturn6 = ""
        Me.SoNgan.CFLReturn7 = ""
        Me.SoNgan.CFLShowLoad = False
        Me.SoNgan.ChangeFormStatus = True
        Me.SoNgan.ColumnKey = False
        Me.SoNgan.ComboLine = 5
        Me.SoNgan.CopyFromItem = ""
        Me.SoNgan.DefaultButtonClick = False
        Me.SoNgan.Digit = False
        Me.SoNgan.FieldType = "C"
        Me.SoNgan.FieldView = "SoNgan"
        Me.SoNgan.FormarNumber = True
        Me.SoNgan.FormList = False
        Me.SoNgan.KeyInsert = ""
        Me.SoNgan.LocalDecimal = False
        Me.SoNgan.Name = "SoNgan"
        Me.SoNgan.NoUpdate = ""
        Me.SoNgan.NumberDecimal = 0
        Me.SoNgan.ParentControl = ""
        Me.SoNgan.RefreshSource = False
        Me.SoNgan.Required = False
        Me.SoNgan.SequenceName = ""
        Me.SoNgan.ShowCalc = True
        Me.SoNgan.ShowDataTime = False
        Me.SoNgan.ShowOnlyTime = False
        Me.SoNgan.SQLString = ""
        Me.SoNgan.UpdateIfNull = ""
        Me.SoNgan.UpdateWhenFormLock = False
        Me.SoNgan.ValidateValue = True
        Me.SoNgan.Visible = True
        Me.SoNgan.VisibleIndex = 1
        Me.SoNgan.Width = 80
        '
        'iweight
        '
        Me.iweight.AllowInsert = True
        Me.iweight.AllowUpdate = True
        Me.iweight.ButtonClick = True
        Me.iweight.Caption = "Tải trọng"
        Me.iweight.CFLColumnHide = ""
        Me.iweight.CFLKeyField = ""
        Me.iweight.CFLPage = False
        Me.iweight.CFLReturn0 = ""
        Me.iweight.CFLReturn1 = ""
        Me.iweight.CFLReturn2 = ""
        Me.iweight.CFLReturn3 = ""
        Me.iweight.CFLReturn4 = ""
        Me.iweight.CFLReturn5 = ""
        Me.iweight.CFLReturn6 = ""
        Me.iweight.CFLReturn7 = ""
        Me.iweight.CFLShowLoad = False
        Me.iweight.ChangeFormStatus = True
        Me.iweight.ColumnKey = False
        Me.iweight.ComboLine = 5
        Me.iweight.CopyFromItem = ""
        Me.iweight.DefaultButtonClick = False
        Me.iweight.Digit = False
        Me.iweight.FieldType = "N"
        Me.iweight.FieldView = "iweight"
        Me.iweight.FormarNumber = True
        Me.iweight.FormList = False
        Me.iweight.KeyInsert = ""
        Me.iweight.LocalDecimal = False
        Me.iweight.Name = "iweight"
        Me.iweight.NoUpdate = ""
        Me.iweight.NumberDecimal = 0
        Me.iweight.ParentControl = ""
        Me.iweight.RefreshSource = False
        Me.iweight.Required = False
        Me.iweight.SequenceName = ""
        Me.iweight.ShowCalc = True
        Me.iweight.ShowDataTime = False
        Me.iweight.ShowOnlyTime = False
        Me.iweight.SQLString = ""
        Me.iweight.UpdateIfNull = ""
        Me.iweight.UpdateWhenFormLock = False
        Me.iweight.ValidateValue = True
        Me.iweight.Visible = True
        Me.iweight.VisibleIndex = 2
        Me.iweight.Width = 90
        '
        'NgayBatDau1
        '
        Me.NgayBatDau1.AllowInsert = True
        Me.NgayBatDau1.AllowUpdate = True
        Me.NgayBatDau1.ButtonClick = True
        Me.NgayBatDau1.Caption = "Ngày hiệu lực"
        Me.NgayBatDau1.CFLColumnHide = ""
        Me.NgayBatDau1.CFLKeyField = ""
        Me.NgayBatDau1.CFLPage = False
        Me.NgayBatDau1.CFLReturn0 = ""
        Me.NgayBatDau1.CFLReturn1 = ""
        Me.NgayBatDau1.CFLReturn2 = ""
        Me.NgayBatDau1.CFLReturn3 = ""
        Me.NgayBatDau1.CFLReturn4 = ""
        Me.NgayBatDau1.CFLReturn5 = ""
        Me.NgayBatDau1.CFLReturn6 = ""
        Me.NgayBatDau1.CFLReturn7 = ""
        Me.NgayBatDau1.CFLShowLoad = False
        Me.NgayBatDau1.ChangeFormStatus = True
        Me.NgayBatDau1.ColumnKey = False
        Me.NgayBatDau1.ComboLine = 5
        Me.NgayBatDau1.CopyFromItem = ""
        Me.NgayBatDau1.DefaultButtonClick = False
        Me.NgayBatDau1.Digit = False
        Me.NgayBatDau1.FieldType = "D"
        Me.NgayBatDau1.FieldView = "NgayBatDau1"
        Me.NgayBatDau1.FormarNumber = True
        Me.NgayBatDau1.FormList = False
        Me.NgayBatDau1.KeyInsert = ""
        Me.NgayBatDau1.LocalDecimal = False
        Me.NgayBatDau1.Name = "NgayBatDau1"
        Me.NgayBatDau1.NoUpdate = ""
        Me.NgayBatDau1.NumberDecimal = 0
        Me.NgayBatDau1.ParentControl = ""
        Me.NgayBatDau1.RefreshSource = False
        Me.NgayBatDau1.Required = False
        Me.NgayBatDau1.SequenceName = ""
        Me.NgayBatDau1.ShowCalc = True
        Me.NgayBatDau1.ShowDataTime = False
        Me.NgayBatDau1.ShowOnlyTime = False
        Me.NgayBatDau1.SQLString = ""
        Me.NgayBatDau1.UpdateIfNull = ""
        Me.NgayBatDau1.UpdateWhenFormLock = False
        Me.NgayBatDau1.ValidateValue = True
        Me.NgayBatDau1.Visible = True
        Me.NgayBatDau1.VisibleIndex = 3
        Me.NgayBatDau1.Width = 100
        '
        'NgayHieuLuc1
        '
        Me.NgayHieuLuc1.AllowInsert = True
        Me.NgayHieuLuc1.AllowUpdate = True
        Me.NgayHieuLuc1.ButtonClick = True
        Me.NgayHieuLuc1.Caption = "Ngày hết hiệu lực"
        Me.NgayHieuLuc1.CFLColumnHide = ""
        Me.NgayHieuLuc1.CFLKeyField = ""
        Me.NgayHieuLuc1.CFLPage = False
        Me.NgayHieuLuc1.CFLReturn0 = ""
        Me.NgayHieuLuc1.CFLReturn1 = ""
        Me.NgayHieuLuc1.CFLReturn2 = ""
        Me.NgayHieuLuc1.CFLReturn3 = ""
        Me.NgayHieuLuc1.CFLReturn4 = ""
        Me.NgayHieuLuc1.CFLReturn5 = ""
        Me.NgayHieuLuc1.CFLReturn6 = ""
        Me.NgayHieuLuc1.CFLReturn7 = ""
        Me.NgayHieuLuc1.CFLShowLoad = False
        Me.NgayHieuLuc1.ChangeFormStatus = True
        Me.NgayHieuLuc1.ColumnKey = False
        Me.NgayHieuLuc1.ComboLine = 5
        Me.NgayHieuLuc1.CopyFromItem = ""
        Me.NgayHieuLuc1.DefaultButtonClick = False
        Me.NgayHieuLuc1.Digit = False
        Me.NgayHieuLuc1.FieldType = "D"
        Me.NgayHieuLuc1.FieldView = "NgayHieuLuc1"
        Me.NgayHieuLuc1.FormarNumber = True
        Me.NgayHieuLuc1.FormList = False
        Me.NgayHieuLuc1.KeyInsert = ""
        Me.NgayHieuLuc1.LocalDecimal = False
        Me.NgayHieuLuc1.Name = "NgayHieuLuc1"
        Me.NgayHieuLuc1.NoUpdate = ""
        Me.NgayHieuLuc1.NumberDecimal = 0
        Me.NgayHieuLuc1.ParentControl = ""
        Me.NgayHieuLuc1.RefreshSource = False
        Me.NgayHieuLuc1.Required = False
        Me.NgayHieuLuc1.SequenceName = ""
        Me.NgayHieuLuc1.ShowCalc = True
        Me.NgayHieuLuc1.ShowDataTime = False
        Me.NgayHieuLuc1.ShowOnlyTime = False
        Me.NgayHieuLuc1.SQLString = ""
        Me.NgayHieuLuc1.UpdateIfNull = ""
        Me.NgayHieuLuc1.UpdateWhenFormLock = False
        Me.NgayHieuLuc1.ValidateValue = True
        Me.NgayHieuLuc1.Visible = True
        Me.NgayHieuLuc1.VisibleIndex = 4
        Me.NgayHieuLuc1.Width = 120
        '
        'Date22
        '
        Me.Date22.AllowInsert = True
        Me.Date22.AllowUpdate = True
        Me.Date22.ButtonClick = True
        Me.Date22.Caption = "Xuất hàng gần nhất"
        Me.Date22.CFLColumnHide = ""
        Me.Date22.CFLKeyField = ""
        Me.Date22.CFLPage = False
        Me.Date22.CFLReturn0 = ""
        Me.Date22.CFLReturn1 = ""
        Me.Date22.CFLReturn2 = ""
        Me.Date22.CFLReturn3 = ""
        Me.Date22.CFLReturn4 = ""
        Me.Date22.CFLReturn5 = ""
        Me.Date22.CFLReturn6 = ""
        Me.Date22.CFLReturn7 = ""
        Me.Date22.CFLShowLoad = False
        Me.Date22.ChangeFormStatus = True
        Me.Date22.ColumnKey = False
        Me.Date22.ComboLine = 5
        Me.Date22.CopyFromItem = ""
        Me.Date22.DefaultButtonClick = False
        Me.Date22.Digit = False
        Me.Date22.FieldType = "D"
        Me.Date22.FieldView = "Date22"
        Me.Date22.FormarNumber = True
        Me.Date22.FormList = False
        Me.Date22.KeyInsert = ""
        Me.Date22.LocalDecimal = False
        Me.Date22.Name = "Date22"
        Me.Date22.NoUpdate = ""
        Me.Date22.NumberDecimal = 0
        Me.Date22.ParentControl = ""
        Me.Date22.RefreshSource = False
        Me.Date22.Required = False
        Me.Date22.SequenceName = ""
        Me.Date22.ShowCalc = True
        Me.Date22.ShowDataTime = False
        Me.Date22.ShowOnlyTime = False
        Me.Date22.SQLString = ""
        Me.Date22.UpdateIfNull = ""
        Me.Date22.UpdateWhenFormLock = False
        Me.Date22.ValidateValue = True
        Me.Date22.Visible = True
        Me.Date22.VisibleIndex = 5
        Me.Date22.Width = 150
        '
        'Createby
        '
        Me.Createby.AllowInsert = True
        Me.Createby.AllowUpdate = True
        Me.Createby.ButtonClick = True
        Me.Createby.Caption = "Người sửa"
        Me.Createby.CFLColumnHide = ""
        Me.Createby.CFLKeyField = ""
        Me.Createby.CFLPage = False
        Me.Createby.CFLReturn0 = ""
        Me.Createby.CFLReturn1 = ""
        Me.Createby.CFLReturn2 = ""
        Me.Createby.CFLReturn3 = ""
        Me.Createby.CFLReturn4 = ""
        Me.Createby.CFLReturn5 = ""
        Me.Createby.CFLReturn6 = ""
        Me.Createby.CFLReturn7 = ""
        Me.Createby.CFLShowLoad = False
        Me.Createby.ChangeFormStatus = True
        Me.Createby.ColumnKey = False
        Me.Createby.ComboLine = 5
        Me.Createby.CopyFromItem = ""
        Me.Createby.DefaultButtonClick = False
        Me.Createby.Digit = False
        Me.Createby.FieldType = "C"
        Me.Createby.FieldView = "Createby"
        Me.Createby.FormarNumber = True
        Me.Createby.FormList = False
        Me.Createby.KeyInsert = ""
        Me.Createby.LocalDecimal = False
        Me.Createby.Name = "Createby"
        Me.Createby.NoUpdate = ""
        Me.Createby.NumberDecimal = 0
        Me.Createby.ParentControl = ""
        Me.Createby.RefreshSource = False
        Me.Createby.Required = False
        Me.Createby.SequenceName = ""
        Me.Createby.ShowCalc = True
        Me.Createby.ShowDataTime = False
        Me.Createby.ShowOnlyTime = False
        Me.Createby.SQLString = ""
        Me.Createby.UpdateIfNull = ""
        Me.Createby.UpdateWhenFormLock = False
        Me.Createby.ValidateValue = True
        Me.Createby.Visible = True
        Me.Createby.VisibleIndex = 6
        Me.Createby.Width = 100
        '
        'SyncDate
        '
        Me.SyncDate.AllowInsert = True
        Me.SyncDate.AllowUpdate = True
        Me.SyncDate.ButtonClick = True
        Me.SyncDate.Caption = "Ngày sửa"
        Me.SyncDate.CFLColumnHide = ""
        Me.SyncDate.CFLKeyField = ""
        Me.SyncDate.CFLPage = False
        Me.SyncDate.CFLReturn0 = ""
        Me.SyncDate.CFLReturn1 = ""
        Me.SyncDate.CFLReturn2 = ""
        Me.SyncDate.CFLReturn3 = ""
        Me.SyncDate.CFLReturn4 = ""
        Me.SyncDate.CFLReturn5 = ""
        Me.SyncDate.CFLReturn6 = ""
        Me.SyncDate.CFLReturn7 = ""
        Me.SyncDate.CFLShowLoad = False
        Me.SyncDate.ChangeFormStatus = True
        Me.SyncDate.ColumnKey = False
        Me.SyncDate.ComboLine = 5
        Me.SyncDate.CopyFromItem = ""
        Me.SyncDate.DefaultButtonClick = False
        Me.SyncDate.Digit = False
        Me.SyncDate.FieldType = "D"
        Me.SyncDate.FieldView = "SyncDate"
        Me.SyncDate.FormarNumber = True
        Me.SyncDate.FormList = False
        Me.SyncDate.KeyInsert = ""
        Me.SyncDate.LocalDecimal = False
        Me.SyncDate.Name = "SyncDate"
        Me.SyncDate.NoUpdate = ""
        Me.SyncDate.NumberDecimal = 0
        Me.SyncDate.ParentControl = ""
        Me.SyncDate.RefreshSource = False
        Me.SyncDate.Required = False
        Me.SyncDate.SequenceName = ""
        Me.SyncDate.ShowCalc = True
        Me.SyncDate.ShowDataTime = True
        Me.SyncDate.ShowOnlyTime = False
        Me.SyncDate.SQLString = ""
        Me.SyncDate.UpdateIfNull = ""
        Me.SyncDate.UpdateWhenFormLock = False
        Me.SyncDate.ValidateValue = True
        Me.SyncDate.Visible = True
        Me.SyncDate.VisibleIndex = 7
        Me.SyncDate.Width = 200
        '
        'TrueDBGrid2
        '
        Me.TrueDBGrid2.DefaultRemove = True
        Me.TrueDBGrid2.Location = New System.Drawing.Point(698, 43)
        Me.TrueDBGrid2.MainView = Me.GridView2
        Me.TrueDBGrid2.Name = "TrueDBGrid2"
        Me.TrueDBGrid2.Size = New System.Drawing.Size(426, 445)
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
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MaNgan, Me.SoLuongMax, Me.Createby11, Me.SyncDate11, Me.UpdStatus11})
        Me.GridView2.CompanyCode = ""
        Me.GridView2.DefaultRemove = True
        Me.GridView2.GetB1 = False
        Me.GridView2.GridControl = Me.TrueDBGrid2
        Me.GridView2.LastQuery = ""
        Me.GridView2.Name = "GridView2"
        Me.GridView2.ObjectChild = False
        Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.ReadOnly = True
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OrderBy = "SyncDate desc"
        Me.GridView2.ParentItem = Nothing
        Me.GridView2.RowNumber = ""
        Me.GridView2.TableName = ""
        Me.GridView2.ViewName = "tblChiTietPhuongTien_Hist_V"
        Me.GridView2.Where = Nothing
        '
        'MaNgan
        '
        Me.MaNgan.AllowInsert = True
        Me.MaNgan.AllowUpdate = True
        Me.MaNgan.ButtonClick = True
        Me.MaNgan.Caption = "Mã ngăn"
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
        Me.MaNgan.FormarNumber = True
        Me.MaNgan.FormList = False
        Me.MaNgan.KeyInsert = ""
        Me.MaNgan.LocalDecimal = False
        Me.MaNgan.Name = "MaNgan"
        Me.MaNgan.NoUpdate = ""
        Me.MaNgan.NumberDecimal = 0
        Me.MaNgan.ParentControl = ""
        Me.MaNgan.RefreshSource = False
        Me.MaNgan.Required = False
        Me.MaNgan.SequenceName = ""
        Me.MaNgan.ShowCalc = True
        Me.MaNgan.ShowDataTime = False
        Me.MaNgan.ShowOnlyTime = False
        Me.MaNgan.SQLString = ""
        Me.MaNgan.UpdateIfNull = ""
        Me.MaNgan.UpdateWhenFormLock = False
        Me.MaNgan.ValidateValue = True
        Me.MaNgan.Visible = True
        Me.MaNgan.VisibleIndex = 0
        Me.MaNgan.Width = 80
        '
        'SoLuongMax
        '
        Me.SoLuongMax.AllowInsert = True
        Me.SoLuongMax.AllowUpdate = True
        Me.SoLuongMax.ButtonClick = True
        Me.SoLuongMax.Caption = "Dung tích"
        Me.SoLuongMax.CFLColumnHide = ""
        Me.SoLuongMax.CFLKeyField = ""
        Me.SoLuongMax.CFLPage = False
        Me.SoLuongMax.CFLReturn0 = ""
        Me.SoLuongMax.CFLReturn1 = ""
        Me.SoLuongMax.CFLReturn2 = ""
        Me.SoLuongMax.CFLReturn3 = ""
        Me.SoLuongMax.CFLReturn4 = ""
        Me.SoLuongMax.CFLReturn5 = ""
        Me.SoLuongMax.CFLReturn6 = ""
        Me.SoLuongMax.CFLReturn7 = ""
        Me.SoLuongMax.CFLShowLoad = False
        Me.SoLuongMax.ChangeFormStatus = True
        Me.SoLuongMax.ColumnKey = False
        Me.SoLuongMax.ComboLine = 5
        Me.SoLuongMax.CopyFromItem = ""
        Me.SoLuongMax.DefaultButtonClick = False
        Me.SoLuongMax.Digit = False
        Me.SoLuongMax.FieldType = "N"
        Me.SoLuongMax.FieldView = "SoLuongMax"
        Me.SoLuongMax.FormarNumber = True
        Me.SoLuongMax.FormList = False
        Me.SoLuongMax.KeyInsert = ""
        Me.SoLuongMax.LocalDecimal = False
        Me.SoLuongMax.Name = "SoLuongMax"
        Me.SoLuongMax.NoUpdate = ""
        Me.SoLuongMax.NumberDecimal = 0
        Me.SoLuongMax.ParentControl = ""
        Me.SoLuongMax.RefreshSource = False
        Me.SoLuongMax.Required = False
        Me.SoLuongMax.SequenceName = ""
        Me.SoLuongMax.ShowCalc = True
        Me.SoLuongMax.ShowDataTime = False
        Me.SoLuongMax.ShowOnlyTime = False
        Me.SoLuongMax.SQLString = ""
        Me.SoLuongMax.UpdateIfNull = ""
        Me.SoLuongMax.UpdateWhenFormLock = False
        Me.SoLuongMax.ValidateValue = True
        Me.SoLuongMax.Visible = True
        Me.SoLuongMax.VisibleIndex = 1
        Me.SoLuongMax.Width = 100
        '
        'Createby11
        '
        Me.Createby11.AllowInsert = True
        Me.Createby11.AllowUpdate = True
        Me.Createby11.ButtonClick = True
        Me.Createby11.Caption = "Người sửa"
        Me.Createby11.CFLColumnHide = ""
        Me.Createby11.CFLKeyField = ""
        Me.Createby11.CFLPage = False
        Me.Createby11.CFLReturn0 = ""
        Me.Createby11.CFLReturn1 = ""
        Me.Createby11.CFLReturn2 = ""
        Me.Createby11.CFLReturn3 = ""
        Me.Createby11.CFLReturn4 = ""
        Me.Createby11.CFLReturn5 = ""
        Me.Createby11.CFLReturn6 = ""
        Me.Createby11.CFLReturn7 = ""
        Me.Createby11.CFLShowLoad = False
        Me.Createby11.ChangeFormStatus = True
        Me.Createby11.ColumnKey = False
        Me.Createby11.ComboLine = 5
        Me.Createby11.CopyFromItem = ""
        Me.Createby11.DefaultButtonClick = False
        Me.Createby11.Digit = False
        Me.Createby11.FieldType = "C"
        Me.Createby11.FieldView = "Createby"
        Me.Createby11.FormarNumber = True
        Me.Createby11.FormList = False
        Me.Createby11.KeyInsert = ""
        Me.Createby11.LocalDecimal = False
        Me.Createby11.Name = "Createby11"
        Me.Createby11.NoUpdate = ""
        Me.Createby11.NumberDecimal = 0
        Me.Createby11.ParentControl = ""
        Me.Createby11.RefreshSource = False
        Me.Createby11.Required = False
        Me.Createby11.SequenceName = ""
        Me.Createby11.ShowCalc = True
        Me.Createby11.ShowDataTime = False
        Me.Createby11.ShowOnlyTime = False
        Me.Createby11.SQLString = ""
        Me.Createby11.UpdateIfNull = ""
        Me.Createby11.UpdateWhenFormLock = False
        Me.Createby11.ValidateValue = True
        Me.Createby11.Visible = True
        Me.Createby11.VisibleIndex = 2
        Me.Createby11.Width = 100
        '
        'SyncDate11
        '
        Me.SyncDate11.AllowInsert = True
        Me.SyncDate11.AllowUpdate = True
        Me.SyncDate11.ButtonClick = True
        Me.SyncDate11.Caption = "Ngày sửa"
        Me.SyncDate11.CFLColumnHide = ""
        Me.SyncDate11.CFLKeyField = ""
        Me.SyncDate11.CFLPage = False
        Me.SyncDate11.CFLReturn0 = ""
        Me.SyncDate11.CFLReturn1 = ""
        Me.SyncDate11.CFLReturn2 = ""
        Me.SyncDate11.CFLReturn3 = ""
        Me.SyncDate11.CFLReturn4 = ""
        Me.SyncDate11.CFLReturn5 = ""
        Me.SyncDate11.CFLReturn6 = ""
        Me.SyncDate11.CFLReturn7 = ""
        Me.SyncDate11.CFLShowLoad = False
        Me.SyncDate11.ChangeFormStatus = True
        Me.SyncDate11.ColumnKey = False
        Me.SyncDate11.ComboLine = 5
        Me.SyncDate11.CopyFromItem = ""
        Me.SyncDate11.DefaultButtonClick = False
        Me.SyncDate11.Digit = False
        Me.SyncDate11.FieldType = "D"
        Me.SyncDate11.FieldView = "SyncDate"
        Me.SyncDate11.FormarNumber = True
        Me.SyncDate11.FormList = False
        Me.SyncDate11.KeyInsert = ""
        Me.SyncDate11.LocalDecimal = False
        Me.SyncDate11.Name = "SyncDate11"
        Me.SyncDate11.NoUpdate = ""
        Me.SyncDate11.NumberDecimal = 0
        Me.SyncDate11.ParentControl = ""
        Me.SyncDate11.RefreshSource = False
        Me.SyncDate11.Required = False
        Me.SyncDate11.SequenceName = ""
        Me.SyncDate11.ShowCalc = True
        Me.SyncDate11.ShowDataTime = True
        Me.SyncDate11.ShowOnlyTime = False
        Me.SyncDate11.SQLString = ""
        Me.SyncDate11.UpdateIfNull = ""
        Me.SyncDate11.UpdateWhenFormLock = False
        Me.SyncDate11.ValidateValue = True
        Me.SyncDate11.Visible = True
        Me.SyncDate11.VisibleIndex = 3
        Me.SyncDate11.Width = 200
        '
        'UpdStatus11
        '
        Me.UpdStatus11.AllowInsert = True
        Me.UpdStatus11.AllowUpdate = True
        Me.UpdStatus11.ButtonClick = True
        Me.UpdStatus11.Caption = "Trạng thái"
        Me.UpdStatus11.CFLColumnHide = ""
        Me.UpdStatus11.CFLKeyField = ""
        Me.UpdStatus11.CFLPage = False
        Me.UpdStatus11.CFLReturn0 = ""
        Me.UpdStatus11.CFLReturn1 = ""
        Me.UpdStatus11.CFLReturn2 = ""
        Me.UpdStatus11.CFLReturn3 = ""
        Me.UpdStatus11.CFLReturn4 = ""
        Me.UpdStatus11.CFLReturn5 = ""
        Me.UpdStatus11.CFLReturn6 = ""
        Me.UpdStatus11.CFLReturn7 = ""
        Me.UpdStatus11.CFLShowLoad = False
        Me.UpdStatus11.ChangeFormStatus = True
        Me.UpdStatus11.ColumnKey = False
        Me.UpdStatus11.ComboLine = 5
        Me.UpdStatus11.CopyFromItem = ""
        Me.UpdStatus11.DefaultButtonClick = False
        Me.UpdStatus11.Digit = False
        Me.UpdStatus11.FieldType = "C"
        Me.UpdStatus11.FieldView = "UpdStatus"
        Me.UpdStatus11.FormarNumber = True
        Me.UpdStatus11.FormList = False
        Me.UpdStatus11.KeyInsert = ""
        Me.UpdStatus11.LocalDecimal = False
        Me.UpdStatus11.Name = "UpdStatus11"
        Me.UpdStatus11.NoUpdate = ""
        Me.UpdStatus11.NumberDecimal = 0
        Me.UpdStatus11.ParentControl = ""
        Me.UpdStatus11.RefreshSource = False
        Me.UpdStatus11.Required = False
        Me.UpdStatus11.SequenceName = ""
        Me.UpdStatus11.ShowCalc = True
        Me.UpdStatus11.ShowDataTime = False
        Me.UpdStatus11.ShowOnlyTime = False
        Me.UpdStatus11.SQLString = ""
        Me.UpdStatus11.UpdateIfNull = ""
        Me.UpdStatus11.UpdateWhenFormLock = False
        Me.UpdStatus11.ValidateValue = True
        Me.UpdStatus11.Visible = True
        Me.UpdStatus11.VisibleIndex = 4
        Me.UpdStatus11.Width = 100
        '
        'FrmVehicleHist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 500)
        Me.Controls.Add(Me.TrueDBGrid2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.FormEdit = False
        Me.MaximizeBox = False
        Me.Name = "FrmVehicleHist"
        Me.Text = "Lịch sử Barem phương tiện"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    'riend WithEvents U_TrueDBGrid1 As U_TextBox.U_TrueDBGrid
    'Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents TrueDBGrid2 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents GridColumn1 As U_TextBox.GridColumn
    Friend WithEvents SoNgan As U_TextBox.GridColumn
    Friend WithEvents iweight As U_TextBox.GridColumn
    Friend WithEvents NgayBatDau1 As U_TextBox.GridColumn
    Friend WithEvents NgayHieuLuc1 As U_TextBox.GridColumn
    Friend WithEvents Date22 As U_TextBox.GridColumn
    Friend WithEvents Createby As U_TextBox.GridColumn
    Friend WithEvents SyncDate As U_TextBox.GridColumn
    Friend WithEvents GridView2 As U_TextBox.GridView
    Friend WithEvents MaNgan As U_TextBox.GridColumn
    Friend WithEvents SoLuongMax As U_TextBox.GridColumn
    Friend WithEvents Createby11 As U_TextBox.GridColumn
    Friend WithEvents SyncDate11 As U_TextBox.GridColumn
    Friend WithEvents UpdStatus11 As U_TextBox.GridColumn
End Class
