<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSoLenhAuto_Hist
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayXuat = New U_TextBox.U_DateEdit()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.colSoLenh = New U_TextBox.GridColumn()
        Me.NgayThang = New U_TextBox.GridColumn()
        Me.sStatus = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.sDesc = New U_TextBox.GridColumn()
        Me.Createby = New U_TextBox.GridColumn()
        Me.CreateDate = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SoLenh = New U_TextBox.U_TextBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(338, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 471
        Me.Label2.Text = "Ngày tháng"
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = True
        Me.NgayXuat.AllowUpdate = True
        Me.NgayXuat.BindingSourceName = ""
        Me.NgayXuat.ChangeFormStatus = False
        Me.NgayXuat.CopyFromItem = ""
        Me.NgayXuat.DefaultValue = ""
        Me.NgayXuat.EditValue = Nothing
        Me.NgayXuat.FieldName = ""
        Me.NgayXuat.FieldType = "D"
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LinkLabel = ""
        Me.NgayXuat.Location = New System.Drawing.Point(440, 37)
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.PrimaryKey = ""
        Me.NgayXuat.Properties.AutoHeight = False
        Me.NgayXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayXuat.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayXuat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayXuat.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayXuat.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayXuat.Required = "N"
        Me.NgayXuat.ShowDateTime = False
        Me.NgayXuat.Size = New System.Drawing.Size(150, 26)
        Me.NgayXuat.TabIndex = 1
        Me.NgayXuat.TableName = ""
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.ViewName = ""
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.Location = New System.Drawing.Point(596, 37)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(90, 26)
        Me.U_ButtonCus1.TabIndex = 2
        Me.U_ButtonCus1.Text = "Tìm &kiếm"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(6, 76)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(986, 452)
        Me.TrueDBGrid1.TabIndex = 473
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSoLenh, Me.NgayThang, Me.sStatus, Me.sDesc, Me.Createby, Me.CreateDate})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = False
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
        Me.GridView1.TableName = "FPT_SoLenh_Auto_HIST"
        Me.GridView1.ViewName = "FPT_SoLenh_Auto_HIST"
        Me.GridView1.Where = Nothing
        '
        'colSoLenh
        '
        Me.colSoLenh.AllowInsert = True
        Me.colSoLenh.AllowUpdate = True
        Me.colSoLenh.Caption = "Số lệnh"
        Me.colSoLenh.CFLColumnHide = ""
        Me.colSoLenh.CFLKeyField = ""
        Me.colSoLenh.CFLPage = False
        Me.colSoLenh.CFLReturn0 = ""
        Me.colSoLenh.CFLReturn1 = ""
        Me.colSoLenh.CFLReturn2 = ""
        Me.colSoLenh.CFLReturn3 = ""
        Me.colSoLenh.CFLReturn4 = ""
        Me.colSoLenh.CFLReturn5 = ""
        Me.colSoLenh.CFLReturn6 = ""
        Me.colSoLenh.CFLReturn7 = ""
        Me.colSoLenh.CFLShowLoad = False
        Me.colSoLenh.ChangeFormStatus = True
        Me.colSoLenh.ColumnKey = False
        Me.colSoLenh.ComboLine = 5
        Me.colSoLenh.CopyFromItem = ""
        Me.colSoLenh.DefaultButtonClick = False
        Me.colSoLenh.Digit = False
        Me.colSoLenh.FieldType = "C"
        Me.colSoLenh.FieldView = "SoLenh"
        Me.colSoLenh.FormList = False
        Me.colSoLenh.KeyInsert = ""
        Me.colSoLenh.LocalDecimal = False
        Me.colSoLenh.Name = "colSoLenh"
        Me.colSoLenh.NoUpdate = ""
        Me.colSoLenh.NumberDecimal = 0
        Me.colSoLenh.OptionsColumn.ReadOnly = True
        Me.colSoLenh.ParentControl = ""
        Me.colSoLenh.RefreshSource = False
        Me.colSoLenh.Required = False
        Me.colSoLenh.ShowDataTime = False
        Me.colSoLenh.SQLString = ""
        Me.colSoLenh.UpdateIfNull = ""
        Me.colSoLenh.UpdateWhenFormLock = False
        Me.colSoLenh.ValidateValue = True
        Me.colSoLenh.Visible = True
        Me.colSoLenh.VisibleIndex = 0
        Me.colSoLenh.Width = 130
        '
        'NgayThang
        '
        Me.NgayThang.AllowInsert = True
        Me.NgayThang.AllowUpdate = True
        Me.NgayThang.Caption = "Thời gian thực hiện"
        Me.NgayThang.CFLColumnHide = ""
        Me.NgayThang.CFLKeyField = ""
        Me.NgayThang.CFLPage = False
        Me.NgayThang.CFLReturn0 = ""
        Me.NgayThang.CFLReturn1 = ""
        Me.NgayThang.CFLReturn2 = ""
        Me.NgayThang.CFLReturn3 = ""
        Me.NgayThang.CFLReturn4 = ""
        Me.NgayThang.CFLReturn5 = ""
        Me.NgayThang.CFLReturn6 = ""
        Me.NgayThang.CFLReturn7 = ""
        Me.NgayThang.CFLShowLoad = False
        Me.NgayThang.ChangeFormStatus = True
        Me.NgayThang.ColumnKey = False
        Me.NgayThang.ComboLine = 5
        Me.NgayThang.CopyFromItem = ""
        Me.NgayThang.DefaultButtonClick = False
        Me.NgayThang.Digit = False
        Me.NgayThang.FieldType = "D"
        Me.NgayThang.FieldView = "NgayThang"
        Me.NgayThang.FormList = False
        Me.NgayThang.KeyInsert = ""
        Me.NgayThang.LocalDecimal = False
        Me.NgayThang.Name = "NgayThang"
        Me.NgayThang.NoUpdate = ""
        Me.NgayThang.NumberDecimal = 0
        Me.NgayThang.OptionsColumn.ReadOnly = True
        Me.NgayThang.ParentControl = ""
        Me.NgayThang.RefreshSource = False
        Me.NgayThang.Required = False
        Me.NgayThang.ShowDataTime = True
        Me.NgayThang.SQLString = ""
        Me.NgayThang.UpdateIfNull = ""
        Me.NgayThang.UpdateWhenFormLock = False
        Me.NgayThang.ValidateValue = True
        Me.NgayThang.Visible = True
        Me.NgayThang.VisibleIndex = 1
        Me.NgayThang.Width = 150
        '
        'sStatus
        '
        Me.sStatus.AllowInsert = True
        Me.sStatus.AllowUpdate = True
        Me.sStatus.Caption = "Trạng thái"
        Me.sStatus.CFLColumnHide = ""
        Me.sStatus.CFLKeyField = ""
        Me.sStatus.CFLPage = False
        Me.sStatus.CFLReturn0 = ""
        Me.sStatus.CFLReturn1 = ""
        Me.sStatus.CFLReturn2 = ""
        Me.sStatus.CFLReturn3 = ""
        Me.sStatus.CFLReturn4 = ""
        Me.sStatus.CFLReturn5 = ""
        Me.sStatus.CFLReturn6 = ""
        Me.sStatus.CFLReturn7 = ""
        Me.sStatus.CFLShowLoad = False
        Me.sStatus.ChangeFormStatus = True
        Me.sStatus.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.sStatus.ColumnKey = False
        Me.sStatus.ComboLine = 5
        Me.sStatus.CopyFromItem = ""
        Me.sStatus.DefaultButtonClick = False
        Me.sStatus.Digit = False
        Me.sStatus.FieldType = "C"
        Me.sStatus.FieldView = "TrangThai"
        Me.sStatus.FormList = False
        Me.sStatus.KeyInsert = ""
        Me.sStatus.LocalDecimal = False
        Me.sStatus.Name = "sStatus"
        Me.sStatus.NoUpdate = ""
        Me.sStatus.NumberDecimal = 0
        Me.sStatus.OptionsColumn.ReadOnly = True
        Me.sStatus.ParentControl = ""
        Me.sStatus.RefreshSource = False
        Me.sStatus.Required = False
        Me.sStatus.ShowDataTime = False
        Me.sStatus.SQLString = ""
        Me.sStatus.UpdateIfNull = ""
        Me.sStatus.UpdateWhenFormLock = False
        Me.sStatus.ValidateValue = True
        Me.sStatus.Visible = True
        Me.sStatus.VisibleIndex = 2
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'sDesc
        '
        Me.sDesc.AllowInsert = True
        Me.sDesc.AllowUpdate = True
        Me.sDesc.Caption = "Ghi chú"
        Me.sDesc.CFLColumnHide = ""
        Me.sDesc.CFLKeyField = ""
        Me.sDesc.CFLPage = False
        Me.sDesc.CFLReturn0 = ""
        Me.sDesc.CFLReturn1 = ""
        Me.sDesc.CFLReturn2 = ""
        Me.sDesc.CFLReturn3 = ""
        Me.sDesc.CFLReturn4 = ""
        Me.sDesc.CFLReturn5 = ""
        Me.sDesc.CFLReturn6 = ""
        Me.sDesc.CFLReturn7 = ""
        Me.sDesc.CFLShowLoad = False
        Me.sDesc.ChangeFormStatus = True
        Me.sDesc.ColumnKey = False
        Me.sDesc.ComboLine = 5
        Me.sDesc.CopyFromItem = ""
        Me.sDesc.DefaultButtonClick = False
        Me.sDesc.Digit = False
        Me.sDesc.FieldType = "C"
        Me.sDesc.FieldView = "sDesc"
        Me.sDesc.FormList = False
        Me.sDesc.KeyInsert = ""
        Me.sDesc.LocalDecimal = False
        Me.sDesc.Name = "sDesc"
        Me.sDesc.NoUpdate = ""
        Me.sDesc.NumberDecimal = 0
        Me.sDesc.OptionsColumn.ReadOnly = True
        Me.sDesc.ParentControl = ""
        Me.sDesc.RefreshSource = False
        Me.sDesc.Required = False
        Me.sDesc.ShowDataTime = False
        Me.sDesc.SQLString = ""
        Me.sDesc.UpdateIfNull = ""
        Me.sDesc.UpdateWhenFormLock = False
        Me.sDesc.ValidateValue = True
        Me.sDesc.Visible = True
        Me.sDesc.VisibleIndex = 3
        Me.sDesc.Width = 350
        '
        'Createby
        '
        Me.Createby.AllowInsert = True
        Me.Createby.AllowUpdate = True
        Me.Createby.Caption = "Người thực hiện"
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
        Me.Createby.FieldView = ""
        Me.Createby.FormList = False
        Me.Createby.KeyInsert = ""
        Me.Createby.LocalDecimal = False
        Me.Createby.Name = "Createby"
        Me.Createby.NoUpdate = ""
        Me.Createby.NumberDecimal = 0
        Me.Createby.ParentControl = ""
        Me.Createby.RefreshSource = False
        Me.Createby.Required = False
        Me.Createby.ShowDataTime = False
        Me.Createby.SQLString = ""
        Me.Createby.UpdateIfNull = ""
        Me.Createby.UpdateWhenFormLock = False
        Me.Createby.ValidateValue = True
        Me.Createby.Visible = True
        Me.Createby.VisibleIndex = 4
        Me.Createby.Width = 120
        '
        'CreateDate
        '
        Me.CreateDate.AllowInsert = True
        Me.CreateDate.AllowUpdate = True
        Me.CreateDate.Caption = "Ngày thực hiện"
        Me.CreateDate.CFLColumnHide = ""
        Me.CreateDate.CFLKeyField = ""
        Me.CreateDate.CFLPage = False
        Me.CreateDate.CFLReturn0 = ""
        Me.CreateDate.CFLReturn1 = ""
        Me.CreateDate.CFLReturn2 = ""
        Me.CreateDate.CFLReturn3 = ""
        Me.CreateDate.CFLReturn4 = ""
        Me.CreateDate.CFLReturn5 = ""
        Me.CreateDate.CFLReturn6 = ""
        Me.CreateDate.CFLReturn7 = ""
        Me.CreateDate.CFLShowLoad = False
        Me.CreateDate.ChangeFormStatus = True
        Me.CreateDate.ColumnKey = False
        Me.CreateDate.ComboLine = 5
        Me.CreateDate.CopyFromItem = ""
        Me.CreateDate.DefaultButtonClick = False
        Me.CreateDate.Digit = False
        Me.CreateDate.FieldType = "C"
        Me.CreateDate.FieldView = ""
        Me.CreateDate.FormList = False
        Me.CreateDate.KeyInsert = ""
        Me.CreateDate.LocalDecimal = False
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.NoUpdate = ""
        Me.CreateDate.NumberDecimal = 0
        Me.CreateDate.ParentControl = ""
        Me.CreateDate.RefreshSource = False
        Me.CreateDate.Required = False
        Me.CreateDate.ShowDataTime = False
        Me.CreateDate.SQLString = ""
        Me.CreateDate.UpdateIfNull = ""
        Me.CreateDate.UpdateWhenFormLock = False
        Me.CreateDate.ValidateValue = True
        Me.CreateDate.Visible = True
        Me.CreateDate.VisibleIndex = 5
        Me.CreateDate.Width = 120
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Y"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "N"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 19)
        Me.Label1.TabIndex = 475
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
        Me.SoLenh.Location = New System.Drawing.Point(114, 37)
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = "N"
        Me.SoLenh.PrimaryKey = "Y"
        Me.SoLenh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoLenh.Properties.Appearance.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoLenh.Properties.AutoHeight = False
        Me.SoLenh.Properties.MaxLength = 10
        Me.SoLenh.Required = "N"
        Me.SoLenh.Size = New System.Drawing.Size(137, 26)
        Me.SoLenh.TabIndex = 0
        Me.SoLenh.TableName = ""
        Me.SoLenh.UpdateIfNull = "N"
        Me.SoLenh.UpdateWhenFormLock = False
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ViewName = ""
        '
        'FrmSoLenhAuto_Hist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 557)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SoLenh)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayXuat)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSoLenhAuto_Hist"
        Me.ShowFormMessage = True
        Me.Text = "Rút lệnh xuất hàng loạt"
        Me.Controls.SetChildIndex(Me.NgayXuat, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.SoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayXuat As U_TextBox.U_DateEdit
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents colSoLenh As U_TextBox.GridColumn
    Friend WithEvents NgayThang As U_TextBox.GridColumn
    Friend WithEvents sDesc As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SoLenh As U_TextBox.U_TextBox
    Friend WithEvents sStatus As U_TextBox.GridColumn
    Friend WithEvents Createby As U_TextBox.GridColumn
    Friend WithEvents CreateDate As U_TextBox.GridColumn
End Class
