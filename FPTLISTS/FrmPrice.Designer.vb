<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrice
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
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.GridColumn2 = New U_TextBox.GridColumn()
        Me.GridColumn4 = New U_TextBox.GridColumn()
        Me.GridColumn5 = New U_TextBox.GridColumn()
        Me.GridColumn6 = New U_TextBox.GridColumn()
        Me.GridColumn8 = New U_TextBox.GridColumn()
        Me.GridColumn10 = New U_TextBox.GridColumn()
        Me.GridColumn11 = New U_TextBox.GridColumn()
        Me.GridColumn14 = New U_TextBox.GridColumn()
        Me.GridColumn15 = New U_TextBox.GridColumn()
        Me.GridColumn16 = New U_TextBox.GridColumn()
        Me.GridColumn17 = New U_TextBox.GridColumn()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 2)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(974, 441)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = True
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn8, Me.GridColumn10, Me.GridColumn11, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "tblDonGia"
        Me.GridView1.Where = Nothing
        '
        'GridColumn2
        '
        Me.GridColumn2.AllowInsert = True
        Me.GridColumn2.AllowUpdate = True
        Me.GridColumn2.ButtonClick = True
        Me.GridColumn2.Caption = "Condition Type"
        Me.GridColumn2.CFLColumnHide = ""
        Me.GridColumn2.CFLKeyField = ""
        Me.GridColumn2.CFLPage = False
        Me.GridColumn2.CFLReturn0 = ""
        Me.GridColumn2.CFLReturn1 = ""
        Me.GridColumn2.CFLReturn2 = ""
        Me.GridColumn2.CFLReturn3 = ""
        Me.GridColumn2.CFLReturn4 = ""
        Me.GridColumn2.CFLReturn5 = ""
        Me.GridColumn2.CFLReturn6 = ""
        Me.GridColumn2.CFLReturn7 = ""
        Me.GridColumn2.CFLShowLoad = False
        Me.GridColumn2.ChangeFormStatus = True
        Me.GridColumn2.ColumnKey = False
        Me.GridColumn2.ComboLine = 5
        Me.GridColumn2.CopyFromItem = ""
        Me.GridColumn2.DefaultButtonClick = False
        Me.GridColumn2.Digit = False
        Me.GridColumn2.FieldType = "C"
        Me.GridColumn2.FieldView = "KSCHL"
        Me.GridColumn2.FormarNumber = True
        Me.GridColumn2.FormList = False
        Me.GridColumn2.KeyInsert = ""
        Me.GridColumn2.LocalDecimal = False
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.NoUpdate = ""
        Me.GridColumn2.NumberDecimal = 0
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
        Me.GridColumn2.ValidateValue = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.AllowInsert = True
        Me.GridColumn4.AllowUpdate = True
        Me.GridColumn4.ButtonClick = True
        Me.GridColumn4.Caption = "Distribution Chanel"
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
        Me.GridColumn4.FieldView = "VTWEG"
        Me.GridColumn4.FormarNumber = True
        Me.GridColumn4.FormList = False
        Me.GridColumn4.KeyInsert = ""
        Me.GridColumn4.LocalDecimal = False
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.NoUpdate = ""
        Me.GridColumn4.NumberDecimal = 0
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
        Me.GridColumn4.ValidateValue = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumn5
        '
        Me.GridColumn5.AllowInsert = True
        Me.GridColumn5.AllowUpdate = True
        Me.GridColumn5.ButtonClick = True
        Me.GridColumn5.Caption = "Customer"
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
        Me.GridColumn5.FieldView = "KUNNR"
        Me.GridColumn5.FormarNumber = True
        Me.GridColumn5.FormList = False
        Me.GridColumn5.KeyInsert = ""
        Me.GridColumn5.LocalDecimal = False
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.NoUpdate = ""
        Me.GridColumn5.NumberDecimal = 0
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
        Me.GridColumn5.ValidateValue = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        '
        'GridColumn6
        '
        Me.GridColumn6.AllowInsert = True
        Me.GridColumn6.AllowUpdate = True
        Me.GridColumn6.ButtonClick = True
        Me.GridColumn6.Caption = "Material"
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
        Me.GridColumn6.FieldView = "MATNR"
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
        Me.GridColumn6.ValidateValue = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        '
        'GridColumn8
        '
        Me.GridColumn8.AllowInsert = True
        Me.GridColumn8.AllowUpdate = True
        Me.GridColumn8.ButtonClick = True
        Me.GridColumn8.Caption = "Term of payment"
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
        Me.GridColumn8.FieldView = "ZTERM"
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
        Me.GridColumn8.ValidateValue = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 4
        '
        'GridColumn10
        '
        Me.GridColumn10.AllowInsert = True
        Me.GridColumn10.AllowUpdate = True
        Me.GridColumn10.ButtonClick = True
        Me.GridColumn10.Caption = "Start Date"
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
        Me.GridColumn10.FieldView = "DATAB"
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
        Me.GridColumn10.ValidateValue = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 5
        '
        'GridColumn11
        '
        Me.GridColumn11.AllowInsert = True
        Me.GridColumn11.AllowUpdate = True
        Me.GridColumn11.ButtonClick = True
        Me.GridColumn11.Caption = "End Date"
        Me.GridColumn11.CFLColumnHide = ""
        Me.GridColumn11.CFLKeyField = ""
        Me.GridColumn11.CFLPage = False
        Me.GridColumn11.CFLReturn0 = ""
        Me.GridColumn11.CFLReturn1 = ""
        Me.GridColumn11.CFLReturn2 = ""
        Me.GridColumn11.CFLReturn3 = ""
        Me.GridColumn11.CFLReturn4 = ""
        Me.GridColumn11.CFLReturn5 = ""
        Me.GridColumn11.CFLReturn6 = ""
        Me.GridColumn11.CFLReturn7 = ""
        Me.GridColumn11.CFLShowLoad = False
        Me.GridColumn11.ChangeFormStatus = True
        Me.GridColumn11.ColumnKey = False
        Me.GridColumn11.ComboLine = 5
        Me.GridColumn11.CopyFromItem = ""
        Me.GridColumn11.DefaultButtonClick = False
        Me.GridColumn11.Digit = False
        Me.GridColumn11.FieldType = "C"
        Me.GridColumn11.FieldView = "DATBI"
        Me.GridColumn11.FormarNumber = True
        Me.GridColumn11.FormList = False
        Me.GridColumn11.KeyInsert = ""
        Me.GridColumn11.LocalDecimal = False
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.NoUpdate = ""
        Me.GridColumn11.NumberDecimal = 0
        Me.GridColumn11.ParentControl = ""
        Me.GridColumn11.RefreshSource = False
        Me.GridColumn11.Required = False
        Me.GridColumn11.SequenceName = ""
        Me.GridColumn11.ShowCalc = True
        Me.GridColumn11.ShowDataTime = False
        Me.GridColumn11.ShowOnlyTime = False
        Me.GridColumn11.SQLString = ""
        Me.GridColumn11.UpdateIfNull = ""
        Me.GridColumn11.UpdateWhenFormLock = False
        Me.GridColumn11.ValidateValue = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 6
        '
        'GridColumn14
        '
        Me.GridColumn14.AllowInsert = True
        Me.GridColumn14.AllowUpdate = True
        Me.GridColumn14.ButtonClick = True
        Me.GridColumn14.Caption = "Amount"
        Me.GridColumn14.CFLColumnHide = ""
        Me.GridColumn14.CFLKeyField = ""
        Me.GridColumn14.CFLPage = False
        Me.GridColumn14.CFLReturn0 = ""
        Me.GridColumn14.CFLReturn1 = ""
        Me.GridColumn14.CFLReturn2 = ""
        Me.GridColumn14.CFLReturn3 = ""
        Me.GridColumn14.CFLReturn4 = ""
        Me.GridColumn14.CFLReturn5 = ""
        Me.GridColumn14.CFLReturn6 = ""
        Me.GridColumn14.CFLReturn7 = ""
        Me.GridColumn14.CFLShowLoad = False
        Me.GridColumn14.ChangeFormStatus = True
        Me.GridColumn14.ColumnKey = False
        Me.GridColumn14.ComboLine = 5
        Me.GridColumn14.CopyFromItem = ""
        Me.GridColumn14.DefaultButtonClick = False
        Me.GridColumn14.Digit = False
        Me.GridColumn14.FieldType = "C"
        Me.GridColumn14.FieldView = "KBETR"
        Me.GridColumn14.FormarNumber = True
        Me.GridColumn14.FormList = False
        Me.GridColumn14.KeyInsert = ""
        Me.GridColumn14.LocalDecimal = False
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.NoUpdate = ""
        Me.GridColumn14.NumberDecimal = 0
        Me.GridColumn14.ParentControl = ""
        Me.GridColumn14.RefreshSource = False
        Me.GridColumn14.Required = False
        Me.GridColumn14.SequenceName = ""
        Me.GridColumn14.ShowCalc = True
        Me.GridColumn14.ShowDataTime = False
        Me.GridColumn14.ShowOnlyTime = False
        Me.GridColumn14.SQLString = ""
        Me.GridColumn14.UpdateIfNull = ""
        Me.GridColumn14.UpdateWhenFormLock = False
        Me.GridColumn14.ValidateValue = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 7
        '
        'GridColumn15
        '
        Me.GridColumn15.AllowInsert = True
        Me.GridColumn15.AllowUpdate = True
        Me.GridColumn15.ButtonClick = True
        Me.GridColumn15.Caption = "Unit"
        Me.GridColumn15.CFLColumnHide = ""
        Me.GridColumn15.CFLKeyField = ""
        Me.GridColumn15.CFLPage = False
        Me.GridColumn15.CFLReturn0 = ""
        Me.GridColumn15.CFLReturn1 = ""
        Me.GridColumn15.CFLReturn2 = ""
        Me.GridColumn15.CFLReturn3 = ""
        Me.GridColumn15.CFLReturn4 = ""
        Me.GridColumn15.CFLReturn5 = ""
        Me.GridColumn15.CFLReturn6 = ""
        Me.GridColumn15.CFLReturn7 = ""
        Me.GridColumn15.CFLShowLoad = False
        Me.GridColumn15.ChangeFormStatus = True
        Me.GridColumn15.ColumnKey = False
        Me.GridColumn15.ComboLine = 5
        Me.GridColumn15.CopyFromItem = ""
        Me.GridColumn15.DefaultButtonClick = False
        Me.GridColumn15.Digit = False
        Me.GridColumn15.FieldType = "C"
        Me.GridColumn15.FieldView = "WAERS"
        Me.GridColumn15.FormarNumber = True
        Me.GridColumn15.FormList = False
        Me.GridColumn15.KeyInsert = ""
        Me.GridColumn15.LocalDecimal = False
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.NoUpdate = ""
        Me.GridColumn15.NumberDecimal = 0
        Me.GridColumn15.ParentControl = ""
        Me.GridColumn15.RefreshSource = False
        Me.GridColumn15.Required = False
        Me.GridColumn15.SequenceName = ""
        Me.GridColumn15.ShowCalc = True
        Me.GridColumn15.ShowDataTime = False
        Me.GridColumn15.ShowOnlyTime = False
        Me.GridColumn15.SQLString = ""
        Me.GridColumn15.UpdateIfNull = ""
        Me.GridColumn15.UpdateWhenFormLock = False
        Me.GridColumn15.ValidateValue = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 8
        '
        'GridColumn16
        '
        Me.GridColumn16.AllowInsert = True
        Me.GridColumn16.AllowUpdate = True
        Me.GridColumn16.ButtonClick = True
        Me.GridColumn16.Caption = "per"
        Me.GridColumn16.CFLColumnHide = ""
        Me.GridColumn16.CFLKeyField = ""
        Me.GridColumn16.CFLPage = False
        Me.GridColumn16.CFLReturn0 = ""
        Me.GridColumn16.CFLReturn1 = ""
        Me.GridColumn16.CFLReturn2 = ""
        Me.GridColumn16.CFLReturn3 = ""
        Me.GridColumn16.CFLReturn4 = ""
        Me.GridColumn16.CFLReturn5 = ""
        Me.GridColumn16.CFLReturn6 = ""
        Me.GridColumn16.CFLReturn7 = ""
        Me.GridColumn16.CFLShowLoad = False
        Me.GridColumn16.ChangeFormStatus = True
        Me.GridColumn16.ColumnKey = False
        Me.GridColumn16.ComboLine = 5
        Me.GridColumn16.CopyFromItem = ""
        Me.GridColumn16.DefaultButtonClick = False
        Me.GridColumn16.Digit = False
        Me.GridColumn16.FieldType = "C"
        Me.GridColumn16.FieldView = "KPEIN"
        Me.GridColumn16.FormarNumber = True
        Me.GridColumn16.FormList = False
        Me.GridColumn16.KeyInsert = ""
        Me.GridColumn16.LocalDecimal = False
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.NoUpdate = ""
        Me.GridColumn16.NumberDecimal = 0
        Me.GridColumn16.ParentControl = ""
        Me.GridColumn16.RefreshSource = False
        Me.GridColumn16.Required = False
        Me.GridColumn16.SequenceName = ""
        Me.GridColumn16.ShowCalc = True
        Me.GridColumn16.ShowDataTime = False
        Me.GridColumn16.ShowOnlyTime = False
        Me.GridColumn16.SQLString = ""
        Me.GridColumn16.UpdateIfNull = ""
        Me.GridColumn16.UpdateWhenFormLock = False
        Me.GridColumn16.ValidateValue = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 9
        '
        'GridColumn17
        '
        Me.GridColumn17.AllowInsert = True
        Me.GridColumn17.AllowUpdate = True
        Me.GridColumn17.ButtonClick = True
        Me.GridColumn17.Caption = "UoM"
        Me.GridColumn17.CFLColumnHide = ""
        Me.GridColumn17.CFLKeyField = ""
        Me.GridColumn17.CFLPage = False
        Me.GridColumn17.CFLReturn0 = ""
        Me.GridColumn17.CFLReturn1 = ""
        Me.GridColumn17.CFLReturn2 = ""
        Me.GridColumn17.CFLReturn3 = ""
        Me.GridColumn17.CFLReturn4 = ""
        Me.GridColumn17.CFLReturn5 = ""
        Me.GridColumn17.CFLReturn6 = ""
        Me.GridColumn17.CFLReturn7 = ""
        Me.GridColumn17.CFLShowLoad = False
        Me.GridColumn17.ChangeFormStatus = True
        Me.GridColumn17.ColumnKey = False
        Me.GridColumn17.ComboLine = 5
        Me.GridColumn17.CopyFromItem = ""
        Me.GridColumn17.DefaultButtonClick = False
        Me.GridColumn17.Digit = False
        Me.GridColumn17.FieldType = "C"
        Me.GridColumn17.FieldView = "KMEIN"
        Me.GridColumn17.FormarNumber = True
        Me.GridColumn17.FormList = False
        Me.GridColumn17.KeyInsert = ""
        Me.GridColumn17.LocalDecimal = False
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.NoUpdate = ""
        Me.GridColumn17.NumberDecimal = 0
        Me.GridColumn17.ParentControl = ""
        Me.GridColumn17.RefreshSource = False
        Me.GridColumn17.Required = False
        Me.GridColumn17.SequenceName = ""
        Me.GridColumn17.ShowCalc = True
        Me.GridColumn17.ShowDataTime = False
        Me.GridColumn17.ShowOnlyTime = False
        Me.GridColumn17.SQLString = ""
        Me.GridColumn17.UpdateIfNull = ""
        Me.GridColumn17.UpdateWhenFormLock = False
        Me.GridColumn17.ValidateValue = True
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 10
        '
        'FrmPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 445)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Name = "FrmPrice"
        Me.Text = "Danh sách đơn giá"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
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
    Friend WithEvents GridColumn2 As U_TextBox.GridColumn
    Friend WithEvents GridColumn4 As U_TextBox.GridColumn
    Friend WithEvents GridColumn5 As U_TextBox.GridColumn
    Friend WithEvents GridColumn6 As U_TextBox.GridColumn
    Friend WithEvents GridColumn8 As U_TextBox.GridColumn
    Friend WithEvents GridColumn10 As U_TextBox.GridColumn
    Friend WithEvents GridColumn11 As U_TextBox.GridColumn
    Friend WithEvents GridColumn14 As U_TextBox.GridColumn
    Friend WithEvents GridColumn15 As U_TextBox.GridColumn
    Friend WithEvents GridColumn16 As U_TextBox.GridColumn
    Friend WithEvents GridColumn17 As U_TextBox.GridColumn
End Class
