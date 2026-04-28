<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFormObj
    Inherits U_CusForm.XtraCusForm1

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
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
        Me.FORM_ID = New U_TextBox.GridColumn()
        Me.GridColumn6 = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.FORM_NAME = New U_TextBox.GridColumn()
        Me.DESCRIPTION = New U_TextBox.GridColumn()
        Me.FROM_DATE = New U_TextBox.GridColumn()
        Me.TO_DATE = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 2)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(994, 538)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "FORM_ID"
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FORM_ID, Me.GridColumn6, Me.FORM_NAME, Me.DESCRIPTION, Me.FROM_DATE, Me.TO_DATE, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OrderBy = "FORM_ID"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "SYS_FORMS"
        Me.GridView1.ViewName = "SYS_FORMS_V"
        Me.GridView1.Where = Nothing
        '
        'FORM_ID
        '
        Me.FORM_ID.AllowInsert = True
        Me.FORM_ID.AllowUpdate = True
        Me.FORM_ID.Caption = "FORM_ID"
        Me.FORM_ID.CFLKeyField = ""
        Me.FORM_ID.CFLPage = False
        Me.FORM_ID.CFLReturn1 = ""
        Me.FORM_ID.CFLReturn2 = ""
        Me.FORM_ID.CFLReturn3 = ""
        Me.FORM_ID.CFLReturn4 = ""
        Me.FORM_ID.CFLShowLoad = False
        Me.FORM_ID.ChangeFormStatus = True
        Me.FORM_ID.ColumnKey = True
        Me.FORM_ID.ComboLine = 5
        Me.FORM_ID.CopyFromItem = ""
        Me.FORM_ID.DefaultButtonClick = False
        Me.FORM_ID.Digit = False
        Me.FORM_ID.FieldType = "N"
        Me.FORM_ID.FieldView = "FORM_ID"
        Me.FORM_ID.KeyInsert = ""
        Me.FORM_ID.LocalDecimal = False
        Me.FORM_ID.Name = "FORM_ID"
        Me.FORM_ID.NoUpdate = ""
        Me.FORM_ID.ParentControl = ""
        Me.FORM_ID.Required = False
        Me.FORM_ID.SQLString = ""
        Me.FORM_ID.UpdateIfNull = ""
        Me.FORM_ID.UpdateWhenFormLock = False
        Me.FORM_ID.Visible = True
        Me.FORM_ID.VisibleIndex = 0
        '
        'GridColumn6
        '
        Me.GridColumn6.AllowInsert = True
        Me.GridColumn6.AllowUpdate = True
        Me.GridColumn6.Caption = "Module"
        Me.GridColumn6.CFLKeyField = ""
        Me.GridColumn6.CFLPage = False
        Me.GridColumn6.CFLReturn1 = ""
        Me.GridColumn6.CFLReturn2 = ""
        Me.GridColumn6.CFLReturn3 = ""
        Me.GridColumn6.CFLReturn4 = ""
        Me.GridColumn6.CFLShowLoad = False
        Me.GridColumn6.ChangeFormStatus = True
        Me.GridColumn6.ColumnEdit = Me.RepositoryItemComboBox1
        Me.GridColumn6.ColumnKey = False
        Me.GridColumn6.ComboLine = 5
        Me.GridColumn6.CopyFromItem = ""
        Me.GridColumn6.DefaultButtonClick = False
        Me.GridColumn6.Digit = False
        Me.GridColumn6.FieldType = "C"
        Me.GridColumn6.FieldView = "PROJECT_CODE"
        Me.GridColumn6.KeyInsert = ""
        Me.GridColumn6.LocalDecimal = False
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.NoUpdate = ""
        Me.GridColumn6.ParentControl = ""
        Me.GridColumn6.Required = False
        Me.GridColumn6.SQLString = "SELECT PROJECT_CODE, PROJECT_NAME   FROM SYS_PROJECTS WHERE nvl(ENABLE_FLAG,'Y')=" & _
            "'Y' ORDER BY PROJECT_CODE"
        Me.GridColumn6.UpdateIfNull = ""
        Me.GridColumn6.UpdateWhenFormLock = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'FORM_NAME
        '
        Me.FORM_NAME.AllowInsert = True
        Me.FORM_NAME.AllowUpdate = True
        Me.FORM_NAME.Caption = "Tên Form"
        Me.FORM_NAME.CFLKeyField = ""
        Me.FORM_NAME.CFLPage = False
        Me.FORM_NAME.CFLReturn1 = ""
        Me.FORM_NAME.CFLReturn2 = ""
        Me.FORM_NAME.CFLReturn3 = ""
        Me.FORM_NAME.CFLReturn4 = ""
        Me.FORM_NAME.CFLShowLoad = False
        Me.FORM_NAME.ChangeFormStatus = True
        Me.FORM_NAME.ColumnKey = False
        Me.FORM_NAME.ComboLine = 5
        Me.FORM_NAME.CopyFromItem = ""
        Me.FORM_NAME.DefaultButtonClick = False
        Me.FORM_NAME.Digit = False
        Me.FORM_NAME.FieldType = "C"
        Me.FORM_NAME.FieldView = "FORM_NAME"
        Me.FORM_NAME.KeyInsert = ""
        Me.FORM_NAME.LocalDecimal = False
        Me.FORM_NAME.Name = "FORM_NAME"
        Me.FORM_NAME.NoUpdate = ""
        Me.FORM_NAME.ParentControl = ""
        Me.FORM_NAME.Required = False
        Me.FORM_NAME.SQLString = ""
        Me.FORM_NAME.UpdateIfNull = ""
        Me.FORM_NAME.UpdateWhenFormLock = False
        Me.FORM_NAME.Visible = True
        Me.FORM_NAME.VisibleIndex = 2
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.AllowInsert = True
        Me.DESCRIPTION.AllowUpdate = True
        Me.DESCRIPTION.Caption = "Ghi chú"
        Me.DESCRIPTION.CFLKeyField = ""
        Me.DESCRIPTION.CFLPage = False
        Me.DESCRIPTION.CFLReturn1 = ""
        Me.DESCRIPTION.CFLReturn2 = ""
        Me.DESCRIPTION.CFLReturn3 = ""
        Me.DESCRIPTION.CFLReturn4 = ""
        Me.DESCRIPTION.CFLShowLoad = False
        Me.DESCRIPTION.ChangeFormStatus = True
        Me.DESCRIPTION.ColumnKey = False
        Me.DESCRIPTION.ComboLine = 5
        Me.DESCRIPTION.CopyFromItem = ""
        Me.DESCRIPTION.DefaultButtonClick = False
        Me.DESCRIPTION.Digit = False
        Me.DESCRIPTION.FieldType = "C"
        Me.DESCRIPTION.FieldView = "DESCRIPTION"
        Me.DESCRIPTION.KeyInsert = ""
        Me.DESCRIPTION.LocalDecimal = False
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.NoUpdate = ""
        Me.DESCRIPTION.ParentControl = ""
        Me.DESCRIPTION.Required = False
        Me.DESCRIPTION.SQLString = ""
        Me.DESCRIPTION.UpdateIfNull = ""
        Me.DESCRIPTION.UpdateWhenFormLock = False
        Me.DESCRIPTION.Visible = True
        Me.DESCRIPTION.VisibleIndex = 3
        '
        'FROM_DATE
        '
        Me.FROM_DATE.AllowInsert = True
        Me.FROM_DATE.AllowUpdate = True
        Me.FROM_DATE.Caption = "Ngày hiệu lực"
        Me.FROM_DATE.CFLKeyField = ""
        Me.FROM_DATE.CFLPage = False
        Me.FROM_DATE.CFLReturn1 = ""
        Me.FROM_DATE.CFLReturn2 = ""
        Me.FROM_DATE.CFLReturn3 = ""
        Me.FROM_DATE.CFLReturn4 = ""
        Me.FROM_DATE.CFLShowLoad = False
        Me.FROM_DATE.ChangeFormStatus = True
        Me.FROM_DATE.ColumnKey = False
        Me.FROM_DATE.ComboLine = 5
        Me.FROM_DATE.CopyFromItem = ""
        Me.FROM_DATE.DefaultButtonClick = False
        Me.FROM_DATE.Digit = False
        Me.FROM_DATE.FieldType = "D"
        Me.FROM_DATE.FieldView = "FROM_DATE"
        Me.FROM_DATE.KeyInsert = ""
        Me.FROM_DATE.LocalDecimal = False
        Me.FROM_DATE.Name = "FROM_DATE"
        Me.FROM_DATE.NoUpdate = ""
        Me.FROM_DATE.ParentControl = ""
        Me.FROM_DATE.Required = False
        Me.FROM_DATE.SQLString = ""
        Me.FROM_DATE.UpdateIfNull = ""
        Me.FROM_DATE.UpdateWhenFormLock = False
        Me.FROM_DATE.Visible = True
        Me.FROM_DATE.VisibleIndex = 4
        '
        'TO_DATE
        '
        Me.TO_DATE.AllowInsert = True
        Me.TO_DATE.AllowUpdate = True
        Me.TO_DATE.Caption = "Ngày hết hiệu lực"
        Me.TO_DATE.CFLKeyField = ""
        Me.TO_DATE.CFLPage = False
        Me.TO_DATE.CFLReturn1 = ""
        Me.TO_DATE.CFLReturn2 = ""
        Me.TO_DATE.CFLReturn3 = ""
        Me.TO_DATE.CFLReturn4 = ""
        Me.TO_DATE.CFLShowLoad = False
        Me.TO_DATE.ChangeFormStatus = True
        Me.TO_DATE.ColumnKey = False
        Me.TO_DATE.ComboLine = 5
        Me.TO_DATE.CopyFromItem = ""
        Me.TO_DATE.DefaultButtonClick = False
        Me.TO_DATE.Digit = False
        Me.TO_DATE.FieldType = "D"
        Me.TO_DATE.FieldView = "TO_DATE"
        Me.TO_DATE.KeyInsert = ""
        Me.TO_DATE.LocalDecimal = False
        Me.TO_DATE.Name = "TO_DATE"
        Me.TO_DATE.NoUpdate = ""
        Me.TO_DATE.ParentControl = ""
        Me.TO_DATE.Required = False
        Me.TO_DATE.SQLString = ""
        Me.TO_DATE.UpdateIfNull = ""
        Me.TO_DATE.UpdateWhenFormLock = False
        Me.TO_DATE.Visible = True
        Me.TO_DATE.VisibleIndex = 5
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.Caption = "CHECKUPD"
        Me.CHECKUPD.CFLKeyField = ""
        Me.CHECKUPD.CFLPage = False
        Me.CHECKUPD.CFLReturn1 = ""
        Me.CHECKUPD.CFLReturn2 = ""
        Me.CHECKUPD.CFLReturn3 = ""
        Me.CHECKUPD.CFLReturn4 = ""
        Me.CHECKUPD.CFLShowLoad = False
        Me.CHECKUPD.ChangeFormStatus = True
        Me.CHECKUPD.ColumnKey = False
        Me.CHECKUPD.ComboLine = 5
        Me.CHECKUPD.CopyFromItem = ""
        Me.CHECKUPD.DefaultButtonClick = False
        Me.CHECKUPD.Digit = False
        Me.CHECKUPD.FieldType = "C"
        Me.CHECKUPD.FieldView = "CHECKUPD"
        Me.CHECKUPD.KeyInsert = ""
        Me.CHECKUPD.LocalDecimal = False
        Me.CHECKUPD.Name = "CHECKUPD"
        Me.CHECKUPD.NoUpdate = ""
        Me.CHECKUPD.ParentControl = ""
        Me.CHECKUPD.Required = False
        Me.CHECKUPD.SQLString = ""
        Me.CHECKUPD.UpdateIfNull = ""
        Me.CHECKUPD.UpdateWhenFormLock = False
        Me.CHECKUPD.Visible = True
        Me.CHECKUPD.VisibleIndex = 6
        '
        'FrmFormObj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 543)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.KeyPreview = True
        Me.Name = "FrmFormObj"
        Me.Text = "Danh sách Form"
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FORM_ID As U_TextBox.GridColumn
    Friend WithEvents FORM_NAME As U_TextBox.GridColumn
    Friend WithEvents DESCRIPTION As U_TextBox.GridColumn
    Friend WithEvents FROM_DATE As U_TextBox.GridColumn
    Friend WithEvents TO_DATE As U_TextBox.GridColumn
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents GridColumn6 As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
