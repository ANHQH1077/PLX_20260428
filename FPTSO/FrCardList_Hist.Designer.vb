<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrCardList_Hist
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
        Me.CardNum = New U_TextBox.GridColumn()
        Me.sDesc = New U_TextBox.GridColumn()
        Me.FromDate = New U_TextBox.GridColumn()
        Me.ToDate = New U_TextBox.GridColumn()
        Me.Status = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.sUser = New U_TextBox.GridColumn()
        Me.GridColumn1 = New U_TextBox.GridColumn()
        Me.colType = New U_TextBox.GridColumn()
        Me.CardData = New U_TextBox.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 5)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(888, 384)
        Me.TrueDBGrid1.TabIndex = 2
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "CardNum"
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "C"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CardNum, Me.CardData, Me.sDesc, Me.FromDate, Me.ToDate, Me.Status, Me.sUser, Me.GridColumn1, Me.colType})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "cDate"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "zCardLists_Hist"
        Me.GridView1.Where = ""
        '
        'CardNum
        '
        Me.CardNum.AllowInsert = True
        Me.CardNum.AllowUpdate = False
        Me.CardNum.ButtonClick = True
        Me.CardNum.Caption = "Số thẻ"
        Me.CardNum.CFLColumnHide = ""
        Me.CardNum.CFLKeyField = ""
        Me.CardNum.CFLPage = False
        Me.CardNum.CFLReturn0 = ""
        Me.CardNum.CFLReturn1 = ""
        Me.CardNum.CFLReturn2 = ""
        Me.CardNum.CFLReturn3 = ""
        Me.CardNum.CFLReturn4 = ""
        Me.CardNum.CFLReturn5 = ""
        Me.CardNum.CFLReturn6 = ""
        Me.CardNum.CFLReturn7 = ""
        Me.CardNum.CFLShowLoad = False
        Me.CardNum.ChangeFormStatus = True
        Me.CardNum.ColumnKey = True
        Me.CardNum.ComboLine = 5
        Me.CardNum.CopyFromItem = ""
        Me.CardNum.DefaultButtonClick = False
        Me.CardNum.Digit = False
        Me.CardNum.FieldType = "C"
        Me.CardNum.FieldView = "CardNum"
        Me.CardNum.FormarNumber = True
        Me.CardNum.FormList = False
        Me.CardNum.KeyInsert = ""
        Me.CardNum.LocalDecimal = False
        Me.CardNum.Name = "CardNum"
        Me.CardNum.NoUpdate = ""
        Me.CardNum.NumberDecimal = 0
        Me.CardNum.OptionsColumn.ReadOnly = True
        Me.CardNum.ParentControl = ""
        Me.CardNum.RefreshSource = False
        Me.CardNum.Required = True
        Me.CardNum.SequenceName = ""
        Me.CardNum.ShowCalc = True
        Me.CardNum.ShowDataTime = False
        Me.CardNum.ShowOnlyTime = False
        Me.CardNum.SQLString = ""
        Me.CardNum.UpdateIfNull = ""
        Me.CardNum.UpdateWhenFormLock = False
        Me.CardNum.UpperValue = False
        Me.CardNum.ValidateValue = True
        Me.CardNum.Visible = True
        Me.CardNum.VisibleIndex = 0
        Me.CardNum.Width = 150
        '
        'sDesc
        '
        Me.sDesc.AllowInsert = True
        Me.sDesc.AllowUpdate = True
        Me.sDesc.ButtonClick = True
        Me.sDesc.Caption = "Nội dung"
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
        Me.sDesc.FormarNumber = True
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
        Me.sDesc.SequenceName = ""
        Me.sDesc.ShowCalc = True
        Me.sDesc.ShowDataTime = False
        Me.sDesc.ShowOnlyTime = False
        Me.sDesc.SQLString = ""
        Me.sDesc.UpdateIfNull = ""
        Me.sDesc.UpdateWhenFormLock = False
        Me.sDesc.UpperValue = False
        Me.sDesc.ValidateValue = True
        Me.sDesc.Visible = True
        Me.sDesc.VisibleIndex = 2
        Me.sDesc.Width = 150
        '
        'FromDate
        '
        Me.FromDate.AllowInsert = True
        Me.FromDate.AllowUpdate = True
        Me.FromDate.ButtonClick = True
        Me.FromDate.Caption = "Ngày hiệu lực"
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
        Me.FromDate.ShowDataTime = False
        Me.FromDate.ShowOnlyTime = False
        Me.FromDate.SQLString = ""
        Me.FromDate.UpdateIfNull = ""
        Me.FromDate.UpdateWhenFormLock = False
        Me.FromDate.UpperValue = False
        Me.FromDate.ValidateValue = True
        Me.FromDate.Visible = True
        Me.FromDate.VisibleIndex = 3
        Me.FromDate.Width = 90
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = True
        Me.ToDate.AllowUpdate = True
        Me.ToDate.ButtonClick = True
        Me.ToDate.Caption = "Ngày hết hiệu lực"
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
        Me.ToDate.ShowDataTime = False
        Me.ToDate.ShowOnlyTime = False
        Me.ToDate.SQLString = ""
        Me.ToDate.UpdateIfNull = ""
        Me.ToDate.UpdateWhenFormLock = False
        Me.ToDate.UpperValue = False
        Me.ToDate.ValidateValue = True
        Me.ToDate.Visible = True
        Me.ToDate.VisibleIndex = 4
        Me.ToDate.Width = 100
        '
        'Status
        '
        Me.Status.AllowInsert = True
        Me.Status.AllowUpdate = True
        Me.Status.ButtonClick = True
        Me.Status.Caption = "Sử dụng"
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
        Me.Status.ColumnEdit = Me.RepositoryItemCheckEdit1
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
        Me.Status.VisibleIndex = 5
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'sUser
        '
        Me.sUser.AllowInsert = True
        Me.sUser.AllowUpdate = True
        Me.sUser.ButtonClick = True
        Me.sUser.Caption = "User"
        Me.sUser.CFLColumnHide = ""
        Me.sUser.CFLKeyField = ""
        Me.sUser.CFLPage = False
        Me.sUser.CFLReturn0 = ""
        Me.sUser.CFLReturn1 = ""
        Me.sUser.CFLReturn2 = ""
        Me.sUser.CFLReturn3 = ""
        Me.sUser.CFLReturn4 = ""
        Me.sUser.CFLReturn5 = ""
        Me.sUser.CFLReturn6 = ""
        Me.sUser.CFLReturn7 = ""
        Me.sUser.CFLShowLoad = False
        Me.sUser.ChangeFormStatus = True
        Me.sUser.ColumnKey = False
        Me.sUser.ComboLine = 5
        Me.sUser.CopyFromItem = ""
        Me.sUser.DefaultButtonClick = False
        Me.sUser.Digit = False
        Me.sUser.FieldType = "C"
        Me.sUser.FieldView = "UpdatedBy"
        Me.sUser.FormarNumber = True
        Me.sUser.FormList = False
        Me.sUser.KeyInsert = ""
        Me.sUser.LocalDecimal = False
        Me.sUser.Name = "sUser"
        Me.sUser.NoUpdate = ""
        Me.sUser.NumberDecimal = 0
        Me.sUser.OptionsColumn.ReadOnly = True
        Me.sUser.ParentControl = ""
        Me.sUser.RefreshSource = False
        Me.sUser.Required = False
        Me.sUser.SequenceName = ""
        Me.sUser.ShowCalc = True
        Me.sUser.ShowDataTime = False
        Me.sUser.ShowOnlyTime = False
        Me.sUser.SQLString = ""
        Me.sUser.UpdateIfNull = ""
        Me.sUser.UpdateWhenFormLock = False
        Me.sUser.UpperValue = False
        Me.sUser.ValidateValue = True
        Me.sUser.Visible = True
        Me.sUser.VisibleIndex = 6
        '
        'GridColumn1
        '
        Me.GridColumn1.AllowInsert = True
        Me.GridColumn1.AllowUpdate = True
        Me.GridColumn1.ButtonClick = True
        Me.GridColumn1.Caption = "Ngày cập nhật"
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
        Me.GridColumn1.FieldType = "D"
        Me.GridColumn1.FieldView = "cDate"
        Me.GridColumn1.FormarNumber = True
        Me.GridColumn1.FormList = False
        Me.GridColumn1.KeyInsert = ""
        Me.GridColumn1.LocalDecimal = False
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.NoUpdate = ""
        Me.GridColumn1.NumberDecimal = 0
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.ParentControl = ""
        Me.GridColumn1.RefreshSource = False
        Me.GridColumn1.Required = False
        Me.GridColumn1.SequenceName = ""
        Me.GridColumn1.ShowCalc = True
        Me.GridColumn1.ShowDataTime = True
        Me.GridColumn1.ShowOnlyTime = False
        Me.GridColumn1.SQLString = ""
        Me.GridColumn1.UpdateIfNull = ""
        Me.GridColumn1.UpdateWhenFormLock = False
        Me.GridColumn1.UpperValue = False
        Me.GridColumn1.ValidateValue = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 7
        Me.GridColumn1.Width = 190
        '
        'colType
        '
        Me.colType.AllowInsert = True
        Me.colType.AllowUpdate = True
        Me.colType.ButtonClick = True
        Me.colType.Caption = "Type"
        Me.colType.CFLColumnHide = ""
        Me.colType.CFLKeyField = ""
        Me.colType.CFLPage = False
        Me.colType.CFLReturn0 = ""
        Me.colType.CFLReturn1 = ""
        Me.colType.CFLReturn2 = ""
        Me.colType.CFLReturn3 = ""
        Me.colType.CFLReturn4 = ""
        Me.colType.CFLReturn5 = ""
        Me.colType.CFLReturn6 = ""
        Me.colType.CFLReturn7 = ""
        Me.colType.CFLShowLoad = False
        Me.colType.ChangeFormStatus = True
        Me.colType.ColumnKey = False
        Me.colType.ComboLine = 5
        Me.colType.CopyFromItem = ""
        Me.colType.DefaultButtonClick = False
        Me.colType.Digit = False
        Me.colType.FieldType = "C"
        Me.colType.FieldView = "cType"
        Me.colType.FormarNumber = True
        Me.colType.FormList = False
        Me.colType.KeyInsert = ""
        Me.colType.LocalDecimal = False
        Me.colType.Name = "colType"
        Me.colType.NoUpdate = ""
        Me.colType.NumberDecimal = 0
        Me.colType.OptionsColumn.ReadOnly = True
        Me.colType.ParentControl = ""
        Me.colType.RefreshSource = False
        Me.colType.Required = False
        Me.colType.SequenceName = ""
        Me.colType.ShowCalc = True
        Me.colType.ShowDataTime = False
        Me.colType.ShowOnlyTime = False
        Me.colType.SQLString = ""
        Me.colType.UpdateIfNull = ""
        Me.colType.UpdateWhenFormLock = False
        Me.colType.UpperValue = False
        Me.colType.ValidateValue = True
        Me.colType.Visible = True
        Me.colType.VisibleIndex = 8
        '
        'CardData
        '
        Me.CardData.AllowInsert = True
        Me.CardData.AllowUpdate = True
        Me.CardData.ButtonClick = True
        Me.CardData.Caption = "Data"
        Me.CardData.CFLColumnHide = ""
        Me.CardData.CFLKeyField = ""
        Me.CardData.CFLPage = False
        Me.CardData.CFLReturn0 = ""
        Me.CardData.CFLReturn1 = ""
        Me.CardData.CFLReturn2 = ""
        Me.CardData.CFLReturn3 = ""
        Me.CardData.CFLReturn4 = ""
        Me.CardData.CFLReturn5 = ""
        Me.CardData.CFLReturn6 = ""
        Me.CardData.CFLReturn7 = ""
        Me.CardData.CFLShowLoad = False
        Me.CardData.ChangeFormStatus = True
        Me.CardData.ColumnKey = False
        Me.CardData.ComboLine = 5
        Me.CardData.CopyFromItem = ""
        Me.CardData.DefaultButtonClick = False
        Me.CardData.Digit = False
        Me.CardData.FieldType = "C"
        Me.CardData.FieldView = "CardData"
        Me.CardData.FormarNumber = True
        Me.CardData.FormList = False
        Me.CardData.KeyInsert = ""
        Me.CardData.LocalDecimal = False
        Me.CardData.Name = "CardData"
        Me.CardData.NoUpdate = ""
        Me.CardData.NumberDecimal = 0
        Me.CardData.OptionsColumn.ReadOnly = True
        Me.CardData.ParentControl = ""
        Me.CardData.RefreshSource = False
        Me.CardData.Required = False
        Me.CardData.SequenceName = ""
        Me.CardData.ShowCalc = True
        Me.CardData.ShowDataTime = False
        Me.CardData.ShowOnlyTime = False
        Me.CardData.SQLString = ""
        Me.CardData.UpdateIfNull = ""
        Me.CardData.UpdateWhenFormLock = False
        Me.CardData.UpperValue = False
        Me.CardData.ValidateValue = True
        Me.CardData.Visible = True
        Me.CardData.VisibleIndex = 1
        Me.CardData.Width = 150
        '
        'FrCardList_Hist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 389)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrCardList_Hist"
        Me.Text = "Lịch sử thay đổi"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents CardNum As U_TextBox.GridColumn
    Friend WithEvents sDesc As U_TextBox.GridColumn
    Friend WithEvents FromDate As U_TextBox.GridColumn
    Friend WithEvents ToDate As U_TextBox.GridColumn
    Friend WithEvents Status As U_TextBox.GridColumn
    Friend WithEvents sUser As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colType As U_TextBox.GridColumn
    Friend WithEvents GridColumn1 As U_TextBox.GridColumn
    Friend WithEvents CardData As U_TextBox.GridColumn
End Class
