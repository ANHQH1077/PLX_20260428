<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPurpose
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPurpose))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ID = New U_TextBox.GridColumn()
        Me.Code = New U_TextBox.GridColumn()
        Me.colName = New U_TextBox.GridColumn()
        Me.Status = New U_TextBox.GridColumn()
        Me.CreateDate = New U_TextBox.GridColumn()
        Me.SynDate = New U_TextBox.GridColumn()
        Me.SynUser = New U_TextBox.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(630, 28)
        Me.ToolStrip2.TabIndex = 475
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(106, 25)
        Me.ToolStripButton3.Text = "&3. Đồng bộ"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(0, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(630, 365)
        Me.TrueDBGrid1.TabIndex = 476
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.Code, Me.colName, Me.Status, Me.CreateDate, Me.SynDate, Me.SynUser})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "Code"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "zPurpose_v"
        Me.GridView1.Where = Nothing
        '
        'ID
        '
        Me.ID.AllowInsert = True
        Me.ID.AllowUpdate = True
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
        Me.ID.ColumnKey = False
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
        Me.ID.ValidateValue = True
        Me.ID.Visible = True
        '
        'Code
        '
        Me.Code.AllowInsert = True
        Me.Code.AllowUpdate = True
        Me.Code.ButtonClick = True
        Me.Code.Caption = "Mã"
        Me.Code.CFLColumnHide = ""
        Me.Code.CFLKeyField = ""
        Me.Code.CFLPage = False
        Me.Code.CFLReturn0 = ""
        Me.Code.CFLReturn1 = ""
        Me.Code.CFLReturn2 = ""
        Me.Code.CFLReturn3 = ""
        Me.Code.CFLReturn4 = ""
        Me.Code.CFLReturn5 = ""
        Me.Code.CFLReturn6 = ""
        Me.Code.CFLReturn7 = ""
        Me.Code.CFLShowLoad = False
        Me.Code.ChangeFormStatus = True
        Me.Code.ColumnKey = False
        Me.Code.ComboLine = 5
        Me.Code.CopyFromItem = ""
        Me.Code.DefaultButtonClick = False
        Me.Code.Digit = False
        Me.Code.FieldType = "C"
        Me.Code.FieldView = "Code"
        Me.Code.FormarNumber = True
        Me.Code.FormList = False
        Me.Code.KeyInsert = ""
        Me.Code.LocalDecimal = False
        Me.Code.Name = "Code"
        Me.Code.NoUpdate = ""
        Me.Code.NumberDecimal = 0
        Me.Code.OptionsColumn.ReadOnly = True
        Me.Code.ParentControl = ""
        Me.Code.RefreshSource = False
        Me.Code.Required = False
        Me.Code.SequenceName = ""
        Me.Code.ShowCalc = True
        Me.Code.ShowDataTime = False
        Me.Code.ShowOnlyTime = False
        Me.Code.SQLString = ""
        Me.Code.UpdateIfNull = ""
        Me.Code.UpdateWhenFormLock = False
        Me.Code.ValidateValue = True
        Me.Code.Visible = True
        Me.Code.VisibleIndex = 0
        Me.Code.Width = 60
        '
        'colName
        '
        Me.colName.AllowInsert = True
        Me.colName.AllowUpdate = True
        Me.colName.ButtonClick = True
        Me.colName.Caption = "Mô tả"
        Me.colName.CFLColumnHide = ""
        Me.colName.CFLKeyField = ""
        Me.colName.CFLPage = False
        Me.colName.CFLReturn0 = ""
        Me.colName.CFLReturn1 = ""
        Me.colName.CFLReturn2 = ""
        Me.colName.CFLReturn3 = ""
        Me.colName.CFLReturn4 = ""
        Me.colName.CFLReturn5 = ""
        Me.colName.CFLReturn6 = ""
        Me.colName.CFLReturn7 = ""
        Me.colName.CFLShowLoad = False
        Me.colName.ChangeFormStatus = True
        Me.colName.ColumnKey = False
        Me.colName.ComboLine = 5
        Me.colName.CopyFromItem = ""
        Me.colName.DefaultButtonClick = False
        Me.colName.Digit = False
        Me.colName.FieldType = "C"
        Me.colName.FieldView = "Name"
        Me.colName.FormarNumber = True
        Me.colName.FormList = False
        Me.colName.KeyInsert = ""
        Me.colName.LocalDecimal = False
        Me.colName.Name = "colName"
        Me.colName.NoUpdate = ""
        Me.colName.NumberDecimal = 0
        Me.colName.OptionsColumn.ReadOnly = True
        Me.colName.ParentControl = ""
        Me.colName.RefreshSource = False
        Me.colName.Required = False
        Me.colName.SequenceName = ""
        Me.colName.ShowCalc = True
        Me.colName.ShowDataTime = False
        Me.colName.ShowOnlyTime = False
        Me.colName.SQLString = ""
        Me.colName.UpdateIfNull = ""
        Me.colName.UpdateWhenFormLock = False
        Me.colName.ValidateValue = True
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 1
        Me.colName.Width = 200
        '
        'Status
        '
        Me.Status.AllowInsert = True
        Me.Status.AllowUpdate = True
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
        Me.Status.ValidateValue = True
        Me.Status.Visible = True
        '
        'CreateDate
        '
        Me.CreateDate.AllowInsert = True
        Me.CreateDate.AllowUpdate = True
        Me.CreateDate.ButtonClick = True
        Me.CreateDate.Caption = "GridColumn2"
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
        Me.CreateDate.FieldType = "D"
        Me.CreateDate.FieldView = "CreateDate"
        Me.CreateDate.FormarNumber = True
        Me.CreateDate.FormList = False
        Me.CreateDate.KeyInsert = ""
        Me.CreateDate.LocalDecimal = False
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.NoUpdate = ""
        Me.CreateDate.NumberDecimal = 0
        Me.CreateDate.OptionsColumn.ReadOnly = True
        Me.CreateDate.ParentControl = ""
        Me.CreateDate.RefreshSource = False
        Me.CreateDate.Required = False
        Me.CreateDate.SequenceName = ""
        Me.CreateDate.ShowCalc = True
        Me.CreateDate.ShowDataTime = False
        Me.CreateDate.ShowOnlyTime = False
        Me.CreateDate.SQLString = ""
        Me.CreateDate.UpdateIfNull = ""
        Me.CreateDate.UpdateWhenFormLock = False
        Me.CreateDate.ValidateValue = True
        Me.CreateDate.Visible = True
        '
        'SynDate
        '
        Me.SynDate.AllowInsert = True
        Me.SynDate.AllowUpdate = True
        Me.SynDate.ButtonClick = True
        Me.SynDate.Caption = "GridColumn3"
        Me.SynDate.CFLColumnHide = ""
        Me.SynDate.CFLKeyField = ""
        Me.SynDate.CFLPage = False
        Me.SynDate.CFLReturn0 = ""
        Me.SynDate.CFLReturn1 = ""
        Me.SynDate.CFLReturn2 = ""
        Me.SynDate.CFLReturn3 = ""
        Me.SynDate.CFLReturn4 = ""
        Me.SynDate.CFLReturn5 = ""
        Me.SynDate.CFLReturn6 = ""
        Me.SynDate.CFLReturn7 = ""
        Me.SynDate.CFLShowLoad = False
        Me.SynDate.ChangeFormStatus = True
        Me.SynDate.ColumnKey = False
        Me.SynDate.ComboLine = 5
        Me.SynDate.CopyFromItem = ""
        Me.SynDate.DefaultButtonClick = False
        Me.SynDate.Digit = False
        Me.SynDate.FieldType = "D"
        Me.SynDate.FieldView = "SynDate"
        Me.SynDate.FormarNumber = True
        Me.SynDate.FormList = False
        Me.SynDate.KeyInsert = ""
        Me.SynDate.LocalDecimal = False
        Me.SynDate.Name = "SynDate"
        Me.SynDate.NoUpdate = ""
        Me.SynDate.NumberDecimal = 0
        Me.SynDate.OptionsColumn.ReadOnly = True
        Me.SynDate.ParentControl = ""
        Me.SynDate.RefreshSource = False
        Me.SynDate.Required = False
        Me.SynDate.SequenceName = ""
        Me.SynDate.ShowCalc = True
        Me.SynDate.ShowDataTime = False
        Me.SynDate.ShowOnlyTime = False
        Me.SynDate.SQLString = ""
        Me.SynDate.UpdateIfNull = ""
        Me.SynDate.UpdateWhenFormLock = False
        Me.SynDate.ValidateValue = True
        Me.SynDate.Visible = True
        '
        'SynUser
        '
        Me.SynUser.AllowInsert = True
        Me.SynUser.AllowUpdate = True
        Me.SynUser.ButtonClick = True
        Me.SynUser.Caption = "GridColumn1"
        Me.SynUser.CFLColumnHide = ""
        Me.SynUser.CFLKeyField = ""
        Me.SynUser.CFLPage = False
        Me.SynUser.CFLReturn0 = ""
        Me.SynUser.CFLReturn1 = ""
        Me.SynUser.CFLReturn2 = ""
        Me.SynUser.CFLReturn3 = ""
        Me.SynUser.CFLReturn4 = ""
        Me.SynUser.CFLReturn5 = ""
        Me.SynUser.CFLReturn6 = ""
        Me.SynUser.CFLReturn7 = ""
        Me.SynUser.CFLShowLoad = False
        Me.SynUser.ChangeFormStatus = True
        Me.SynUser.ColumnKey = False
        Me.SynUser.ComboLine = 5
        Me.SynUser.CopyFromItem = ""
        Me.SynUser.DefaultButtonClick = False
        Me.SynUser.Digit = False
        Me.SynUser.FieldType = "C"
        Me.SynUser.FieldView = "SynUser"
        Me.SynUser.FormarNumber = True
        Me.SynUser.FormList = False
        Me.SynUser.KeyInsert = ""
        Me.SynUser.LocalDecimal = False
        Me.SynUser.Name = "SynUser"
        Me.SynUser.NoUpdate = ""
        Me.SynUser.NumberDecimal = 0
        Me.SynUser.OptionsColumn.ReadOnly = True
        Me.SynUser.ParentControl = ""
        Me.SynUser.RefreshSource = False
        Me.SynUser.Required = False
        Me.SynUser.SequenceName = ""
        Me.SynUser.ShowCalc = True
        Me.SynUser.ShowDataTime = False
        Me.SynUser.ShowOnlyTime = False
        Me.SynUser.SQLString = ""
        Me.SynUser.UpdateIfNull = ""
        Me.SynUser.UpdateWhenFormLock = False
        Me.SynUser.ValidateValue = True
        Me.SynUser.Visible = True
        '
        'FrmPurpose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 397)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.DefaultSave = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmPurpose"
        Me.Text = "Mục đích đo"
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents Code As U_TextBox.GridColumn
    Friend WithEvents cName As U_TextBox.GridColumn
    Friend WithEvents Status As U_TextBox.GridColumn
    Friend WithEvents CreateDate As U_TextBox.GridColumn
    Friend WithEvents SynDate As U_TextBox.GridColumn
    Friend WithEvents SynUser As U_TextBox.GridColumn
    Friend WithEvents colName As U_TextBox.GridColumn
    'Friend WithEvents Name As U_TextBox.GridColumn
End Class
