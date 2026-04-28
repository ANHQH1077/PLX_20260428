<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGiaoNhan
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
        Me.GridColumn1 = New U_TextBox.GridColumn()
        Me.GridColumn2 = New U_TextBox.GridColumn()
        Me.GridColumn3 = New U_TextBox.GridColumn()
        Me.GridColumn4 = New U_TextBox.GridColumn()
        Me.GridColumn5 = New U_TextBox.GridColumn()
        Me.GridColumn6 = New U_TextBox.GridColumn()
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
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(1, 0)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(953, 552)
        Me.TrueDBGrid1.TabIndex = 0
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "MaTuyenDuong"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "tblGiaoNhan"
        Me.GridView1.Where = Nothing
        '
        'GridColumn1
        '
        Me.GridColumn1.AllowInsert = True
        Me.GridColumn1.AllowUpdate = True
        Me.GridColumn1.ButtonClick = True
        Me.GridColumn1.Caption = "Mã tuyến đường"
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
        Me.GridColumn1.FieldType = "C"
        Me.GridColumn1.FieldView = "MaTuyenDuong"
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
        Me.GridColumn1.UpperValue = False
        Me.GridColumn1.ValidateValue = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 130
        '
        'GridColumn2
        '
        Me.GridColumn2.AllowInsert = True
        Me.GridColumn2.AllowUpdate = True
        Me.GridColumn2.ButtonClick = True
        Me.GridColumn2.Caption = "Tên tuyến đường"
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
        Me.GridColumn2.FieldView = "DGTuyenDuong"
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
        Me.GridColumn2.UpperValue = False
        Me.GridColumn2.ValidateValue = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 200
        '
        'GridColumn3
        '
        Me.GridColumn3.AllowInsert = True
        Me.GridColumn3.AllowUpdate = True
        Me.GridColumn3.ButtonClick = True
        Me.GridColumn3.Caption = "Điểm khởi hành"
        Me.GridColumn3.CFLColumnHide = ""
        Me.GridColumn3.CFLKeyField = ""
        Me.GridColumn3.CFLPage = False
        Me.GridColumn3.CFLReturn0 = ""
        Me.GridColumn3.CFLReturn1 = ""
        Me.GridColumn3.CFLReturn2 = ""
        Me.GridColumn3.CFLReturn3 = ""
        Me.GridColumn3.CFLReturn4 = ""
        Me.GridColumn3.CFLReturn5 = ""
        Me.GridColumn3.CFLReturn6 = ""
        Me.GridColumn3.CFLReturn7 = ""
        Me.GridColumn3.CFLShowLoad = False
        Me.GridColumn3.ChangeFormStatus = True
        Me.GridColumn3.ColumnKey = False
        Me.GridColumn3.ComboLine = 5
        Me.GridColumn3.CopyFromItem = ""
        Me.GridColumn3.DefaultButtonClick = False
        Me.GridColumn3.Digit = False
        Me.GridColumn3.FieldType = "C"
        Me.GridColumn3.FieldView = "DiemKhoiHanh"
        Me.GridColumn3.FormarNumber = True
        Me.GridColumn3.FormList = False
        Me.GridColumn3.KeyInsert = ""
        Me.GridColumn3.LocalDecimal = False
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.NoUpdate = ""
        Me.GridColumn3.NumberDecimal = 0
        Me.GridColumn3.ParentControl = ""
        Me.GridColumn3.RefreshSource = False
        Me.GridColumn3.Required = False
        Me.GridColumn3.SequenceName = ""
        Me.GridColumn3.ShowCalc = True
        Me.GridColumn3.ShowDataTime = False
        Me.GridColumn3.ShowOnlyTime = False
        Me.GridColumn3.SQLString = ""
        Me.GridColumn3.UpdateIfNull = ""
        Me.GridColumn3.UpdateWhenFormLock = False
        Me.GridColumn3.UpperValue = False
        Me.GridColumn3.ValidateValue = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 100
        '
        'GridColumn4
        '
        Me.GridColumn4.AllowInsert = True
        Me.GridColumn4.AllowUpdate = True
        Me.GridColumn4.ButtonClick = True
        Me.GridColumn4.Caption = "Tên điểm khởi hành"
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
        Me.GridColumn4.FieldView = "DGDiemKhoiHanh"
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
        Me.GridColumn4.UpperValue = False
        Me.GridColumn4.ValidateValue = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 200
        '
        'GridColumn5
        '
        Me.GridColumn5.AllowInsert = True
        Me.GridColumn5.AllowUpdate = True
        Me.GridColumn5.ButtonClick = True
        Me.GridColumn5.Caption = "Điểm đến"
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
        Me.GridColumn5.FieldView = "DiemDen"
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
        Me.GridColumn5.UpperValue = False
        Me.GridColumn5.ValidateValue = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 100
        '
        'GridColumn6
        '
        Me.GridColumn6.AllowInsert = True
        Me.GridColumn6.AllowUpdate = True
        Me.GridColumn6.ButtonClick = True
        Me.GridColumn6.Caption = "Tên điểm đến"
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
        Me.GridColumn6.FieldView = "DGDiemDen"
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
        Me.GridColumn6.UpperValue = False
        Me.GridColumn6.ValidateValue = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 200
        '
        'FrmGiaoNhan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 552)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Name = "FrmGiaoNhan"
        Me.Text = "Map Tuyến đường - Điểm giao nhận"
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
    Friend WithEvents GridColumn1 As U_TextBox.GridColumn
    Friend WithEvents GridColumn2 As U_TextBox.GridColumn
    Friend WithEvents GridColumn3 As U_TextBox.GridColumn
    Friend WithEvents GridColumn4 As U_TextBox.GridColumn
    Friend WithEvents GridColumn5 As U_TextBox.GridColumn
    Friend WithEvents GridColumn6 As U_TextBox.GridColumn
End Class
