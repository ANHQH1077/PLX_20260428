<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehicle
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
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.MaPhuongTien = New U_TextBox.GridColumn()
        Me.LaiXe = New U_TextBox.GridColumn()
        Me.TuText = New U_TextBox.GridColumn()
        Me.SoNgan = New U_TextBox.GridColumn()
        Me.NgayBatDau = New U_TextBox.GridColumn()
        Me.NgayHieuLuc = New U_TextBox.GridColumn()
        Me.NgayBatDau1 = New U_TextBox.GridColumn()
        Me.NgayHieuLuc1 = New U_TextBox.GridColumn()
        Me.Status = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.U_ButtonCus2 = New U_TextBox.U_ButtonCus(Me.components)
        Me.U_ButtonCus3 = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TrueDBGrid1.Location = New System.Drawing.Point(4, 3)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(719, 480)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "MaPhuongTien"
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MaPhuongTien, Me.LaiXe, Me.TuText, Me.SoNgan, Me.NgayBatDau, Me.NgayHieuLuc, Me.NgayBatDau1, Me.NgayHieuLuc1, Me.Status, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "MaPhuongTien"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblPhuongTien"
        Me.GridView1.ViewName = "FPT_tblPhuongTien_V"
        Me.GridView1.Where = ""
        '
        'MaPhuongTien
        '
        Me.MaPhuongTien.AllowInsert = True
        Me.MaPhuongTien.AllowUpdate = True
        Me.MaPhuongTien.ButtonClick = True
        Me.MaPhuongTien.Caption = "Mã phương tiện"
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
        Me.MaPhuongTien.ColumnKey = True
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
        Me.MaPhuongTien.OptionsColumn.AllowEdit = False
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
        Me.MaPhuongTien.VisibleIndex = 0
        '
        'LaiXe
        '
        Me.LaiXe.AllowInsert = True
        Me.LaiXe.AllowUpdate = True
        Me.LaiXe.ButtonClick = True
        Me.LaiXe.Caption = "LaiXe"
        Me.LaiXe.CFLColumnHide = ""
        Me.LaiXe.CFLKeyField = ""
        Me.LaiXe.CFLPage = False
        Me.LaiXe.CFLReturn0 = ""
        Me.LaiXe.CFLReturn1 = ""
        Me.LaiXe.CFLReturn2 = ""
        Me.LaiXe.CFLReturn3 = ""
        Me.LaiXe.CFLReturn4 = ""
        Me.LaiXe.CFLReturn5 = ""
        Me.LaiXe.CFLReturn6 = ""
        Me.LaiXe.CFLReturn7 = ""
        Me.LaiXe.CFLShowLoad = False
        Me.LaiXe.ChangeFormStatus = True
        Me.LaiXe.ColumnKey = False
        Me.LaiXe.ComboLine = 5
        Me.LaiXe.CopyFromItem = ""
        Me.LaiXe.DefaultButtonClick = False
        Me.LaiXe.Digit = False
        Me.LaiXe.FieldType = "C"
        Me.LaiXe.FieldView = "LaiXe"
        Me.LaiXe.FormarNumber = True
        Me.LaiXe.FormList = False
        Me.LaiXe.KeyInsert = ""
        Me.LaiXe.LocalDecimal = False
        Me.LaiXe.Name = "LaiXe"
        Me.LaiXe.NoUpdate = ""
        Me.LaiXe.NumberDecimal = 0
        Me.LaiXe.OptionsColumn.AllowEdit = False
        Me.LaiXe.ParentControl = ""
        Me.LaiXe.RefreshSource = False
        Me.LaiXe.Required = False
        Me.LaiXe.SequenceName = ""
        Me.LaiXe.ShowCalc = True
        Me.LaiXe.ShowDataTime = False
        Me.LaiXe.ShowOnlyTime = False
        Me.LaiXe.SQLString = ""
        Me.LaiXe.UpdateIfNull = ""
        Me.LaiXe.UpdateWhenFormLock = False
        Me.LaiXe.UpperValue = False
        Me.LaiXe.ValidateValue = True
        Me.LaiXe.Visible = True
        '
        'TuText
        '
        Me.TuText.AllowInsert = True
        Me.TuText.AllowUpdate = True
        Me.TuText.ButtonClick = True
        Me.TuText.Caption = "Loại phương tiện"
        Me.TuText.CFLColumnHide = ""
        Me.TuText.CFLKeyField = ""
        Me.TuText.CFLPage = False
        Me.TuText.CFLReturn0 = ""
        Me.TuText.CFLReturn1 = ""
        Me.TuText.CFLReturn2 = ""
        Me.TuText.CFLReturn3 = ""
        Me.TuText.CFLReturn4 = ""
        Me.TuText.CFLReturn5 = ""
        Me.TuText.CFLReturn6 = ""
        Me.TuText.CFLReturn7 = ""
        Me.TuText.CFLShowLoad = False
        Me.TuText.ChangeFormStatus = True
        Me.TuText.ColumnKey = False
        Me.TuText.ComboLine = 5
        Me.TuText.CopyFromItem = ""
        Me.TuText.DefaultButtonClick = False
        Me.TuText.Digit = False
        Me.TuText.FieldType = "C"
        Me.TuText.FieldView = "TuText"
        Me.TuText.FormarNumber = True
        Me.TuText.FormList = False
        Me.TuText.KeyInsert = ""
        Me.TuText.LocalDecimal = False
        Me.TuText.Name = "TuText"
        Me.TuText.NoUpdate = ""
        Me.TuText.NumberDecimal = 0
        Me.TuText.OptionsColumn.AllowEdit = False
        Me.TuText.ParentControl = ""
        Me.TuText.RefreshSource = False
        Me.TuText.Required = False
        Me.TuText.SequenceName = ""
        Me.TuText.ShowCalc = True
        Me.TuText.ShowDataTime = False
        Me.TuText.ShowOnlyTime = False
        Me.TuText.SQLString = ""
        Me.TuText.UpdateIfNull = ""
        Me.TuText.UpdateWhenFormLock = False
        Me.TuText.UpperValue = False
        Me.TuText.ValidateValue = True
        Me.TuText.Visible = True
        Me.TuText.VisibleIndex = 1
        '
        'SoNgan
        '
        Me.SoNgan.AllowInsert = True
        Me.SoNgan.AllowUpdate = True
        Me.SoNgan.ButtonClick = True
        Me.SoNgan.Caption = "Số ngăn"
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
        Me.SoNgan.FieldType = "N"
        Me.SoNgan.FieldView = "SoNgan"
        Me.SoNgan.FormarNumber = True
        Me.SoNgan.FormList = False
        Me.SoNgan.KeyInsert = ""
        Me.SoNgan.LocalDecimal = False
        Me.SoNgan.Name = "SoNgan"
        Me.SoNgan.NoUpdate = ""
        Me.SoNgan.NumberDecimal = 0
        Me.SoNgan.OptionsColumn.AllowEdit = False
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
        Me.SoNgan.UpperValue = False
        Me.SoNgan.ValidateValue = True
        Me.SoNgan.Visible = True
        Me.SoNgan.VisibleIndex = 2
        '
        'NgayBatDau
        '
        Me.NgayBatDau.AllowInsert = True
        Me.NgayBatDau.AllowUpdate = True
        Me.NgayBatDau.ButtonClick = True
        Me.NgayBatDau.Caption = "NgayBatDau"
        Me.NgayBatDau.CFLColumnHide = ""
        Me.NgayBatDau.CFLKeyField = ""
        Me.NgayBatDau.CFLPage = False
        Me.NgayBatDau.CFLReturn0 = ""
        Me.NgayBatDau.CFLReturn1 = ""
        Me.NgayBatDau.CFLReturn2 = ""
        Me.NgayBatDau.CFLReturn3 = ""
        Me.NgayBatDau.CFLReturn4 = ""
        Me.NgayBatDau.CFLReturn5 = ""
        Me.NgayBatDau.CFLReturn6 = ""
        Me.NgayBatDau.CFLReturn7 = ""
        Me.NgayBatDau.CFLShowLoad = False
        Me.NgayBatDau.ChangeFormStatus = True
        Me.NgayBatDau.ColumnKey = False
        Me.NgayBatDau.ComboLine = 5
        Me.NgayBatDau.CopyFromItem = ""
        Me.NgayBatDau.DefaultButtonClick = False
        Me.NgayBatDau.Digit = False
        Me.NgayBatDau.FieldType = "C"
        Me.NgayBatDau.FieldView = "NgayBatDau"
        Me.NgayBatDau.FormarNumber = True
        Me.NgayBatDau.FormList = False
        Me.NgayBatDau.KeyInsert = ""
        Me.NgayBatDau.LocalDecimal = False
        Me.NgayBatDau.Name = "NgayBatDau"
        Me.NgayBatDau.NoUpdate = ""
        Me.NgayBatDau.NumberDecimal = 0
        Me.NgayBatDau.ParentControl = ""
        Me.NgayBatDau.RefreshSource = False
        Me.NgayBatDau.Required = False
        Me.NgayBatDau.SequenceName = ""
        Me.NgayBatDau.ShowCalc = True
        Me.NgayBatDau.ShowDataTime = False
        Me.NgayBatDau.ShowOnlyTime = False
        Me.NgayBatDau.SQLString = ""
        Me.NgayBatDau.UpdateIfNull = ""
        Me.NgayBatDau.UpdateWhenFormLock = False
        Me.NgayBatDau.UpperValue = False
        Me.NgayBatDau.ValidateValue = True
        Me.NgayBatDau.Visible = True
        '
        'NgayHieuLuc
        '
        Me.NgayHieuLuc.AllowInsert = True
        Me.NgayHieuLuc.AllowUpdate = True
        Me.NgayHieuLuc.ButtonClick = True
        Me.NgayHieuLuc.Caption = "NgayHieuLuc"
        Me.NgayHieuLuc.CFLColumnHide = ""
        Me.NgayHieuLuc.CFLKeyField = ""
        Me.NgayHieuLuc.CFLPage = False
        Me.NgayHieuLuc.CFLReturn0 = ""
        Me.NgayHieuLuc.CFLReturn1 = ""
        Me.NgayHieuLuc.CFLReturn2 = ""
        Me.NgayHieuLuc.CFLReturn3 = ""
        Me.NgayHieuLuc.CFLReturn4 = ""
        Me.NgayHieuLuc.CFLReturn5 = ""
        Me.NgayHieuLuc.CFLReturn6 = ""
        Me.NgayHieuLuc.CFLReturn7 = ""
        Me.NgayHieuLuc.CFLShowLoad = False
        Me.NgayHieuLuc.ChangeFormStatus = True
        Me.NgayHieuLuc.ColumnKey = False
        Me.NgayHieuLuc.ComboLine = 5
        Me.NgayHieuLuc.CopyFromItem = ""
        Me.NgayHieuLuc.DefaultButtonClick = False
        Me.NgayHieuLuc.Digit = False
        Me.NgayHieuLuc.FieldType = "C"
        Me.NgayHieuLuc.FieldView = "NgayHieuLuc"
        Me.NgayHieuLuc.FormarNumber = True
        Me.NgayHieuLuc.FormList = False
        Me.NgayHieuLuc.KeyInsert = ""
        Me.NgayHieuLuc.LocalDecimal = False
        Me.NgayHieuLuc.Name = "NgayHieuLuc"
        Me.NgayHieuLuc.NoUpdate = ""
        Me.NgayHieuLuc.NumberDecimal = 0
        Me.NgayHieuLuc.ParentControl = ""
        Me.NgayHieuLuc.RefreshSource = False
        Me.NgayHieuLuc.Required = False
        Me.NgayHieuLuc.SequenceName = ""
        Me.NgayHieuLuc.ShowCalc = True
        Me.NgayHieuLuc.ShowDataTime = False
        Me.NgayHieuLuc.ShowOnlyTime = False
        Me.NgayHieuLuc.SQLString = ""
        Me.NgayHieuLuc.UpdateIfNull = ""
        Me.NgayHieuLuc.UpdateWhenFormLock = False
        Me.NgayHieuLuc.UpperValue = False
        Me.NgayHieuLuc.ValidateValue = True
        Me.NgayHieuLuc.Visible = True
        '
        'NgayBatDau1
        '
        Me.NgayBatDau1.AllowInsert = True
        Me.NgayBatDau1.AllowUpdate = True
        Me.NgayBatDau1.ButtonClick = True
        Me.NgayBatDau1.Caption = "Ngày hiệu lực"
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
        Me.NgayBatDau1.OptionsColumn.AllowEdit = False
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
        Me.NgayBatDau1.UpperValue = False
        Me.NgayBatDau1.ValidateValue = True
        Me.NgayBatDau1.Visible = True
        Me.NgayBatDau1.VisibleIndex = 3
        '
        'NgayHieuLuc1
        '
        Me.NgayHieuLuc1.AllowInsert = True
        Me.NgayHieuLuc1.AllowUpdate = True
        Me.NgayHieuLuc1.ButtonClick = True
        Me.NgayHieuLuc1.Caption = "Ngày hết hiệu lực"
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
        Me.NgayHieuLuc1.OptionsColumn.AllowEdit = False
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
        Me.NgayHieuLuc1.UpperValue = False
        Me.NgayHieuLuc1.ValidateValue = True
        Me.NgayHieuLuc1.Visible = True
        Me.NgayHieuLuc1.VisibleIndex = 4
        '
        'Status
        '
        Me.Status.AllowInsert = True
        Me.Status.AllowUpdate = True
        Me.Status.ButtonClick = True
        Me.Status.Caption = "Status"
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
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(7, 495)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(80, 25)
        Me.U_ButtonCus1.TabIndex = 1
        Me.U_ButtonCus1.Text = "&Thêm mới"
        Me.U_ButtonCus1.Visible = False
        '
        'U_ButtonCus2
        '
        Me.U_ButtonCus2.DefaultUpdate = True
        Me.U_ButtonCus2.EnableWhenFormLock = False
        Me.U_ButtonCus2.Location = New System.Drawing.Point(110, 495)
        Me.U_ButtonCus2.Name = "U_ButtonCus2"
        Me.U_ButtonCus2.Size = New System.Drawing.Size(151, 25)
        Me.U_ButtonCus2.TabIndex = 2
        Me.U_ButtonCus2.Text = "&Cập nhật thông tin lái xe"
        Me.U_ButtonCus2.Visible = False
        '
        'U_ButtonCus3
        '
        Me.U_ButtonCus3.DefaultUpdate = True
        Me.U_ButtonCus3.EnableWhenFormLock = False
        Me.U_ButtonCus3.Location = New System.Drawing.Point(462, 495)
        Me.U_ButtonCus3.Name = "U_ButtonCus3"
        Me.U_ButtonCus3.Size = New System.Drawing.Size(252, 25)
        Me.U_ButtonCus3.TabIndex = 3
        Me.U_ButtonCus3.Text = "Đồng bộ chi tiết phương tiện từ SAP->HTTG"
        '
        'FrmVehicle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 526)
        Me.Controls.Add(Me.U_ButtonCus3)
        Me.Controls.Add(Me.U_ButtonCus2)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.Name = "FrmVehicle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Thông tin Phương tiện vận tải"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus2, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus3, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents MaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents LaiXe As U_TextBox.GridColumn
    Friend WithEvents TuText As U_TextBox.GridColumn
    Friend WithEvents SoNgan As U_TextBox.GridColumn
    Friend WithEvents NgayBatDau As U_TextBox.GridColumn
    Friend WithEvents NgayHieuLuc As U_TextBox.GridColumn
    Friend WithEvents NgayBatDau1 As U_TextBox.GridColumn
    Friend WithEvents NgayHieuLuc1 As U_TextBox.GridColumn
    Friend WithEvents Status As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents U_ButtonCus2 As U_TextBox.U_ButtonCus
    Friend WithEvents U_ButtonCus3 As U_TextBox.U_ButtonCus
End Class
