<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHangHoaE5
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
        Me.MaHangHoa = New U_TextBox.GridColumn()
        Me.TenHangHoa = New U_TextBox.GridColumn()
        Me.ERate_Start = New U_TextBox.GridColumn()
        Me.ERate_End = New U_TextBox.GridColumn()
        Me.ID = New U_TextBox.GridColumn()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(5, 6)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(502, 421)
        Me.TrueDBGrid1.TabIndex = 1
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MaHangHoa, Me.TenHangHoa, Me.ERate_Start, Me.ERate_End, Me.ID})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "MaHangHoa"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblHangHoaE5"
        Me.GridView1.ViewName = "tblHangHoaE5"
        Me.GridView1.Where = Nothing
        '
        'MaHangHoa
        '
        Me.MaHangHoa.AllowInsert = True
        Me.MaHangHoa.AllowUpdate = True
        Me.MaHangHoa.ButtonClick = True
        Me.MaHangHoa.Caption = "Mã hàng hóa"
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
        Me.MaHangHoa.FormarNumber = True
        Me.MaHangHoa.FormList = False
        Me.MaHangHoa.KeyInsert = ""
        Me.MaHangHoa.LocalDecimal = False
        Me.MaHangHoa.Name = "MaHangHoa"
        Me.MaHangHoa.NoUpdate = ""
        Me.MaHangHoa.NumberDecimal = 0
        Me.MaHangHoa.ParentControl = ""
        Me.MaHangHoa.RefreshSource = False
        Me.MaHangHoa.Required = False
        Me.MaHangHoa.SequenceName = ""
        Me.MaHangHoa.ShowCalc = True
        Me.MaHangHoa.ShowDataTime = False
        Me.MaHangHoa.ShowOnlyTime = False
        Me.MaHangHoa.SQLString = ""
        Me.MaHangHoa.UpdateIfNull = ""
        Me.MaHangHoa.UpdateWhenFormLock = False
        Me.MaHangHoa.UpperValue = False
        Me.MaHangHoa.ValidateValue = True
        Me.MaHangHoa.Visible = True
        Me.MaHangHoa.VisibleIndex = 0
        Me.MaHangHoa.Width = 100
        '
        'TenHangHoa
        '
        Me.TenHangHoa.AllowInsert = True
        Me.TenHangHoa.AllowUpdate = True
        Me.TenHangHoa.ButtonClick = True
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
        Me.TenHangHoa.FormarNumber = True
        Me.TenHangHoa.FormList = False
        Me.TenHangHoa.KeyInsert = ""
        Me.TenHangHoa.LocalDecimal = False
        Me.TenHangHoa.Name = "TenHangHoa"
        Me.TenHangHoa.NoUpdate = ""
        Me.TenHangHoa.NumberDecimal = 0
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
        Me.TenHangHoa.VisibleIndex = 1
        Me.TenHangHoa.Width = 200
        '
        'ERate_Start
        '
        Me.ERate_Start.AllowInsert = True
        Me.ERate_Start.AllowUpdate = True
        Me.ERate_Start.ButtonClick = True
        Me.ERate_Start.Caption = "Từ tỷ lệ"
        Me.ERate_Start.CFLColumnHide = ""
        Me.ERate_Start.CFLKeyField = ""
        Me.ERate_Start.CFLPage = False
        Me.ERate_Start.CFLReturn0 = ""
        Me.ERate_Start.CFLReturn1 = ""
        Me.ERate_Start.CFLReturn2 = ""
        Me.ERate_Start.CFLReturn3 = ""
        Me.ERate_Start.CFLReturn4 = ""
        Me.ERate_Start.CFLReturn5 = ""
        Me.ERate_Start.CFLReturn6 = ""
        Me.ERate_Start.CFLReturn7 = ""
        Me.ERate_Start.CFLShowLoad = False
        Me.ERate_Start.ChangeFormStatus = True
        Me.ERate_Start.ColumnKey = False
        Me.ERate_Start.ComboLine = 5
        Me.ERate_Start.CopyFromItem = ""
        Me.ERate_Start.DefaultButtonClick = False
        Me.ERate_Start.Digit = False
        Me.ERate_Start.FieldType = "N"
        Me.ERate_Start.FieldView = "ERate_Start"
        Me.ERate_Start.FormarNumber = True
        Me.ERate_Start.FormList = False
        Me.ERate_Start.KeyInsert = ""
        Me.ERate_Start.LocalDecimal = True
        Me.ERate_Start.Name = "ERate_Start"
        Me.ERate_Start.NoUpdate = ""
        Me.ERate_Start.NumberDecimal = 2
        Me.ERate_Start.ParentControl = ""
        Me.ERate_Start.RefreshSource = False
        Me.ERate_Start.Required = False
        Me.ERate_Start.SequenceName = ""
        Me.ERate_Start.ShowCalc = True
        Me.ERate_Start.ShowDataTime = False
        Me.ERate_Start.ShowOnlyTime = False
        Me.ERate_Start.SQLString = ""
        Me.ERate_Start.UpdateIfNull = ""
        Me.ERate_Start.UpdateWhenFormLock = False
        Me.ERate_Start.UpperValue = False
        Me.ERate_Start.ValidateValue = True
        Me.ERate_Start.Visible = True
        Me.ERate_Start.VisibleIndex = 2
        '
        'ERate_End
        '
        Me.ERate_End.AllowInsert = True
        Me.ERate_End.AllowUpdate = True
        Me.ERate_End.ButtonClick = True
        Me.ERate_End.Caption = "Đến tỷ lệ"
        Me.ERate_End.CFLColumnHide = ""
        Me.ERate_End.CFLKeyField = ""
        Me.ERate_End.CFLPage = False
        Me.ERate_End.CFLReturn0 = ""
        Me.ERate_End.CFLReturn1 = ""
        Me.ERate_End.CFLReturn2 = ""
        Me.ERate_End.CFLReturn3 = ""
        Me.ERate_End.CFLReturn4 = ""
        Me.ERate_End.CFLReturn5 = ""
        Me.ERate_End.CFLReturn6 = ""
        Me.ERate_End.CFLReturn7 = ""
        Me.ERate_End.CFLShowLoad = False
        Me.ERate_End.ChangeFormStatus = True
        Me.ERate_End.ColumnKey = False
        Me.ERate_End.ComboLine = 5
        Me.ERate_End.CopyFromItem = ""
        Me.ERate_End.DefaultButtonClick = False
        Me.ERate_End.Digit = False
        Me.ERate_End.FieldType = "N"
        Me.ERate_End.FieldView = "ERate_End"
        Me.ERate_End.FormarNumber = True
        Me.ERate_End.FormList = False
        Me.ERate_End.KeyInsert = ""
        Me.ERate_End.LocalDecimal = True
        Me.ERate_End.Name = "ERate_End"
        Me.ERate_End.NoUpdate = ""
        Me.ERate_End.NumberDecimal = 2
        Me.ERate_End.ParentControl = ""
        Me.ERate_End.RefreshSource = False
        Me.ERate_End.Required = False
        Me.ERate_End.SequenceName = ""
        Me.ERate_End.ShowCalc = True
        Me.ERate_End.ShowDataTime = False
        Me.ERate_End.ShowOnlyTime = False
        Me.ERate_End.SQLString = ""
        Me.ERate_End.UpdateIfNull = ""
        Me.ERate_End.UpdateWhenFormLock = False
        Me.ERate_End.UpperValue = False
        Me.ERate_End.ValidateValue = True
        Me.ERate_End.Visible = True
        Me.ERate_End.VisibleIndex = 3
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.ButtonClick = True
        Me.ID.Caption = "ID"
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
        Me.ID.OptionsColumn.ReadOnly = True
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
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = False
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(387, 436)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(103, 26)
        Me.U_ButtonCus1.TabIndex = 501
        Me.U_ButtonCus1.Text = "Lưu"
        '
        'FrmHangHoaE5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 474)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Name = "FrmHangHoaE5"
        Me.Text = "Thông tin phối trộn"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
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
    Friend WithEvents ERate_End As U_TextBox.GridColumn
    Friend WithEvents MaHangHoa As U_TextBox.GridColumn
    Friend WithEvents TenHangHoa As U_TextBox.GridColumn
    Friend WithEvents ERate_Start As U_TextBox.GridColumn
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
End Class
