<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserQLvb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUserQLvb))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.USER_ID = New U_TextBox.GridColumn()
        Me.USER_NAME = New U_TextBox.GridColumn()
        Me.DESCRIPTION = New U_TextBox.GridColumn()
        Me.START_DATE = New U_TextBox.GridColumn()
        Me.END_DATE = New U_TextBox.GridColumn()
        Me.CmdAdd = New U_TextBox.U_Button()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(518, 354)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "USER_ID"
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.USER_ID, Me.USER_NAME, Me.DESCRIPTION, Me.START_DATE, Me.END_DATE})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "USER_NAME"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "SYS_USER"
        Me.GridView1.ViewName = "SYS_USER"
        Me.GridView1.Where = "USER_NAME not like 'SYSADMIN%' and USER_NAME not like 'sysadmin%'"
        '
        'USER_ID
        '
        Me.USER_ID.AllowInsert = True
        Me.USER_ID.AllowUpdate = True
        Me.USER_ID.ButtonClick = True
        Me.USER_ID.Caption = "GridColumn1"
        Me.USER_ID.CFLColumnHide = ""
        Me.USER_ID.CFLKeyField = ""
        Me.USER_ID.CFLPage = False
        Me.USER_ID.CFLReturn0 = ""
        Me.USER_ID.CFLReturn1 = ""
        Me.USER_ID.CFLReturn2 = ""
        Me.USER_ID.CFLReturn3 = ""
        Me.USER_ID.CFLReturn4 = ""
        Me.USER_ID.CFLReturn5 = ""
        Me.USER_ID.CFLReturn6 = ""
        Me.USER_ID.CFLReturn7 = ""
        Me.USER_ID.CFLShowLoad = False
        Me.USER_ID.ChangeFormStatus = True
        Me.USER_ID.ColumnKey = True
        Me.USER_ID.ComboLine = 5
        Me.USER_ID.CopyFromItem = ""
        Me.USER_ID.DefaultButtonClick = False
        Me.USER_ID.Digit = False
        Me.USER_ID.FieldType = "N"
        Me.USER_ID.FieldView = "USER_ID"
        Me.USER_ID.FormarNumber = True
        Me.USER_ID.FormList = False
        Me.USER_ID.KeyInsert = ""
        Me.USER_ID.LocalDecimal = False
        Me.USER_ID.Name = "USER_ID"
        Me.USER_ID.NoUpdate = ""
        Me.USER_ID.NumberDecimal = 0
        Me.USER_ID.ParentControl = ""
        Me.USER_ID.RefreshSource = False
        Me.USER_ID.Required = False
        Me.USER_ID.SequenceName = ""
        Me.USER_ID.ShowCalc = True
        Me.USER_ID.ShowDataTime = False
        Me.USER_ID.ShowOnlyTime = False
        Me.USER_ID.SQLString = ""
        Me.USER_ID.UpdateIfNull = ""
        Me.USER_ID.UpdateWhenFormLock = False
        Me.USER_ID.UpperValue = False
        Me.USER_ID.ValidateValue = True
        Me.USER_ID.Visible = True
        '
        'USER_NAME
        '
        Me.USER_NAME.AllowInsert = True
        Me.USER_NAME.AllowUpdate = True
        Me.USER_NAME.ButtonClick = True
        Me.USER_NAME.Caption = "Tên người dùng"
        Me.USER_NAME.CFLColumnHide = ""
        Me.USER_NAME.CFLKeyField = ""
        Me.USER_NAME.CFLPage = False
        Me.USER_NAME.CFLReturn0 = ""
        Me.USER_NAME.CFLReturn1 = ""
        Me.USER_NAME.CFLReturn2 = ""
        Me.USER_NAME.CFLReturn3 = ""
        Me.USER_NAME.CFLReturn4 = ""
        Me.USER_NAME.CFLReturn5 = ""
        Me.USER_NAME.CFLReturn6 = ""
        Me.USER_NAME.CFLReturn7 = ""
        Me.USER_NAME.CFLShowLoad = False
        Me.USER_NAME.ChangeFormStatus = True
        Me.USER_NAME.ColumnKey = False
        Me.USER_NAME.ComboLine = 5
        Me.USER_NAME.CopyFromItem = ""
        Me.USER_NAME.DefaultButtonClick = False
        Me.USER_NAME.Digit = False
        Me.USER_NAME.FieldType = "C"
        Me.USER_NAME.FieldView = "USER_NAME"
        Me.USER_NAME.FormarNumber = True
        Me.USER_NAME.FormList = False
        Me.USER_NAME.KeyInsert = ""
        Me.USER_NAME.LocalDecimal = False
        Me.USER_NAME.Name = "USER_NAME"
        Me.USER_NAME.NoUpdate = ""
        Me.USER_NAME.NumberDecimal = 0
        Me.USER_NAME.ParentControl = ""
        Me.USER_NAME.RefreshSource = False
        Me.USER_NAME.Required = False
        Me.USER_NAME.SequenceName = ""
        Me.USER_NAME.ShowCalc = True
        Me.USER_NAME.ShowDataTime = False
        Me.USER_NAME.ShowOnlyTime = False
        Me.USER_NAME.SQLString = ""
        Me.USER_NAME.UpdateIfNull = ""
        Me.USER_NAME.UpdateWhenFormLock = False
        Me.USER_NAME.UpperValue = False
        Me.USER_NAME.ValidateValue = True
        Me.USER_NAME.Visible = True
        Me.USER_NAME.VisibleIndex = 0
        Me.USER_NAME.Width = 85
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.AllowInsert = True
        Me.DESCRIPTION.AllowUpdate = True
        Me.DESCRIPTION.ButtonClick = True
        Me.DESCRIPTION.Caption = "Ghi chú"
        Me.DESCRIPTION.CFLColumnHide = ""
        Me.DESCRIPTION.CFLKeyField = ""
        Me.DESCRIPTION.CFLPage = False
        Me.DESCRIPTION.CFLReturn0 = ""
        Me.DESCRIPTION.CFLReturn1 = ""
        Me.DESCRIPTION.CFLReturn2 = ""
        Me.DESCRIPTION.CFLReturn3 = ""
        Me.DESCRIPTION.CFLReturn4 = ""
        Me.DESCRIPTION.CFLReturn5 = ""
        Me.DESCRIPTION.CFLReturn6 = ""
        Me.DESCRIPTION.CFLReturn7 = ""
        Me.DESCRIPTION.CFLShowLoad = False
        Me.DESCRIPTION.ChangeFormStatus = True
        Me.DESCRIPTION.ColumnKey = False
        Me.DESCRIPTION.ComboLine = 5
        Me.DESCRIPTION.CopyFromItem = ""
        Me.DESCRIPTION.DefaultButtonClick = False
        Me.DESCRIPTION.Digit = False
        Me.DESCRIPTION.FieldType = "C"
        Me.DESCRIPTION.FieldView = "DESCRIPTION"
        Me.DESCRIPTION.FormarNumber = True
        Me.DESCRIPTION.FormList = False
        Me.DESCRIPTION.KeyInsert = ""
        Me.DESCRIPTION.LocalDecimal = False
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.NoUpdate = ""
        Me.DESCRIPTION.NumberDecimal = 0
        Me.DESCRIPTION.ParentControl = ""
        Me.DESCRIPTION.RefreshSource = False
        Me.DESCRIPTION.Required = False
        Me.DESCRIPTION.SequenceName = ""
        Me.DESCRIPTION.ShowCalc = True
        Me.DESCRIPTION.ShowDataTime = False
        Me.DESCRIPTION.ShowOnlyTime = False
        Me.DESCRIPTION.SQLString = ""
        Me.DESCRIPTION.UpdateIfNull = ""
        Me.DESCRIPTION.UpdateWhenFormLock = False
        Me.DESCRIPTION.UpperValue = False
        Me.DESCRIPTION.ValidateValue = True
        Me.DESCRIPTION.Visible = True
        Me.DESCRIPTION.VisibleIndex = 1
        Me.DESCRIPTION.Width = 200
        '
        'START_DATE
        '
        Me.START_DATE.AllowInsert = True
        Me.START_DATE.AllowUpdate = True
        Me.START_DATE.ButtonClick = True
        Me.START_DATE.Caption = "Ngày hiệu lực"
        Me.START_DATE.CFLColumnHide = ""
        Me.START_DATE.CFLKeyField = ""
        Me.START_DATE.CFLPage = False
        Me.START_DATE.CFLReturn0 = ""
        Me.START_DATE.CFLReturn1 = ""
        Me.START_DATE.CFLReturn2 = ""
        Me.START_DATE.CFLReturn3 = ""
        Me.START_DATE.CFLReturn4 = ""
        Me.START_DATE.CFLReturn5 = ""
        Me.START_DATE.CFLReturn6 = ""
        Me.START_DATE.CFLReturn7 = ""
        Me.START_DATE.CFLShowLoad = False
        Me.START_DATE.ChangeFormStatus = True
        Me.START_DATE.ColumnKey = False
        Me.START_DATE.ComboLine = 5
        Me.START_DATE.CopyFromItem = ""
        Me.START_DATE.DefaultButtonClick = False
        Me.START_DATE.Digit = False
        Me.START_DATE.FieldType = "D"
        Me.START_DATE.FieldView = "START_DATE"
        Me.START_DATE.FormarNumber = True
        Me.START_DATE.FormList = False
        Me.START_DATE.KeyInsert = ""
        Me.START_DATE.LocalDecimal = False
        Me.START_DATE.Name = "START_DATE"
        Me.START_DATE.NoUpdate = ""
        Me.START_DATE.NumberDecimal = 0
        Me.START_DATE.ParentControl = ""
        Me.START_DATE.RefreshSource = False
        Me.START_DATE.Required = False
        Me.START_DATE.SequenceName = ""
        Me.START_DATE.ShowCalc = True
        Me.START_DATE.ShowDataTime = False
        Me.START_DATE.ShowOnlyTime = False
        Me.START_DATE.SQLString = ""
        Me.START_DATE.UpdateIfNull = ""
        Me.START_DATE.UpdateWhenFormLock = False
        Me.START_DATE.UpperValue = False
        Me.START_DATE.ValidateValue = True
        Me.START_DATE.Visible = True
        Me.START_DATE.VisibleIndex = 2
        Me.START_DATE.Width = 90
        '
        'END_DATE
        '
        Me.END_DATE.AllowInsert = True
        Me.END_DATE.AllowUpdate = True
        Me.END_DATE.ButtonClick = True
        Me.END_DATE.Caption = "Ngày hết hiệu lực"
        Me.END_DATE.CFLColumnHide = ""
        Me.END_DATE.CFLKeyField = ""
        Me.END_DATE.CFLPage = False
        Me.END_DATE.CFLReturn0 = ""
        Me.END_DATE.CFLReturn1 = ""
        Me.END_DATE.CFLReturn2 = ""
        Me.END_DATE.CFLReturn3 = ""
        Me.END_DATE.CFLReturn4 = ""
        Me.END_DATE.CFLReturn5 = ""
        Me.END_DATE.CFLReturn6 = ""
        Me.END_DATE.CFLReturn7 = ""
        Me.END_DATE.CFLShowLoad = False
        Me.END_DATE.ChangeFormStatus = True
        Me.END_DATE.ColumnKey = False
        Me.END_DATE.ComboLine = 5
        Me.END_DATE.CopyFromItem = ""
        Me.END_DATE.DefaultButtonClick = False
        Me.END_DATE.Digit = False
        Me.END_DATE.FieldType = "D"
        Me.END_DATE.FieldView = "END_DATE"
        Me.END_DATE.FormarNumber = True
        Me.END_DATE.FormList = False
        Me.END_DATE.KeyInsert = ""
        Me.END_DATE.LocalDecimal = False
        Me.END_DATE.Name = "END_DATE"
        Me.END_DATE.NoUpdate = ""
        Me.END_DATE.NumberDecimal = 0
        Me.END_DATE.ParentControl = ""
        Me.END_DATE.RefreshSource = False
        Me.END_DATE.Required = False
        Me.END_DATE.SequenceName = ""
        Me.END_DATE.ShowCalc = True
        Me.END_DATE.ShowDataTime = False
        Me.END_DATE.ShowOnlyTime = False
        Me.END_DATE.SQLString = ""
        Me.END_DATE.UpdateIfNull = ""
        Me.END_DATE.UpdateWhenFormLock = False
        Me.END_DATE.UpperValue = False
        Me.END_DATE.ValidateValue = True
        Me.END_DATE.Visible = True
        Me.END_DATE.VisibleIndex = 3
        Me.END_DATE.Width = 100
        '
        'CmdAdd
        '
        Me.CmdAdd.DefaultUpdate = True
        Me.CmdAdd.Location = New System.Drawing.Point(12, 391)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.CmdAdd.TabIndex = 300
        Me.CmdAdd.Text = "&1. Thêm mới"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(525, 28)
        Me.ToolStrip2.TabIndex = 471
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
        'FrmUserQLvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 443)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.FormEdit = False
        Me.MaximizeBox = False
        Me.Name = "FrmUserQLvb"
        Me.ShowFormMessage = True
        Me.Text = "Quản trị người dùng"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.CmdAdd, 0)
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
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents USER_ID As U_TextBox.GridColumn
    Friend WithEvents USER_NAME As U_TextBox.GridColumn
    Friend WithEvents DESCRIPTION As U_TextBox.GridColumn
    Friend WithEvents START_DATE As U_TextBox.GridColumn
    Friend WithEvents END_DATE As U_TextBox.GridColumn
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents CmdAdd As U_TextBox.U_Button
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
