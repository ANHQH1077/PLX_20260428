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
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.USER_ID = New U_TextBox.GridColumn()
        Me.USER_NAME = New U_TextBox.GridColumn()
        Me.DESCRIPTION = New U_TextBox.GridColumn()
        Me.START_DATE = New U_TextBox.GridColumn()
        Me.END_DATE = New U_TextBox.GridColumn()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 5)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(518, 380)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
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
        Me.GridView1.Where = Nothing
        '
        'USER_ID
        '
        Me.USER_ID.AllowInsert = True
        Me.USER_ID.AllowUpdate = True
        Me.USER_ID.Caption = "GridColumn1"
        Me.USER_ID.CFLColumnHide = ""
        Me.USER_ID.CFLKeyField = ""
        Me.USER_ID.CFLPage = False
        Me.USER_ID.CFLReturn0 = ""
        Me.USER_ID.CFLReturn1 = ""
        Me.USER_ID.CFLReturn2 = ""
        Me.USER_ID.CFLReturn3 = ""
        Me.USER_ID.CFLReturn4 = ""
        Me.USER_ID.CFLShowLoad = False
        Me.USER_ID.ChangeFormStatus = True
        Me.USER_ID.ColumnKey = False
        Me.USER_ID.ComboLine = 5
        Me.USER_ID.CopyFromItem = ""
        Me.USER_ID.DefaultButtonClick = False
        Me.USER_ID.Digit = False
        Me.USER_ID.FieldType = "N"
        Me.USER_ID.FieldView = "USER_ID"
        Me.USER_ID.FormList = False
        Me.USER_ID.KeyInsert = ""
        Me.USER_ID.LocalDecimal = False
        Me.USER_ID.Name = "USER_ID"
        Me.USER_ID.NoUpdate = ""
        Me.USER_ID.NumberDecimal = 0
        Me.USER_ID.ParentControl = ""
        Me.USER_ID.RefreshSource = False
        Me.USER_ID.Required = False
        Me.USER_ID.ShowDataTime = False
        Me.USER_ID.SQLString = ""
        Me.USER_ID.UpdateIfNull = ""
        Me.USER_ID.UpdateWhenFormLock = False
        '
        'USER_NAME
        '
        Me.USER_NAME.AllowInsert = True
        Me.USER_NAME.AllowUpdate = True
        Me.USER_NAME.Caption = "Tên người dùng"
        Me.USER_NAME.CFLColumnHide = ""
        Me.USER_NAME.CFLKeyField = ""
        Me.USER_NAME.CFLPage = False
        Me.USER_NAME.CFLReturn0 = ""
        Me.USER_NAME.CFLReturn1 = ""
        Me.USER_NAME.CFLReturn2 = ""
        Me.USER_NAME.CFLReturn3 = ""
        Me.USER_NAME.CFLReturn4 = ""
        Me.USER_NAME.CFLShowLoad = False
        Me.USER_NAME.ChangeFormStatus = True
        Me.USER_NAME.ColumnKey = False
        Me.USER_NAME.ComboLine = 5
        Me.USER_NAME.CopyFromItem = ""
        Me.USER_NAME.DefaultButtonClick = False
        Me.USER_NAME.Digit = False
        Me.USER_NAME.FieldType = "C"
        Me.USER_NAME.FieldView = "USER_NAME"
        Me.USER_NAME.FormList = False
        Me.USER_NAME.KeyInsert = ""
        Me.USER_NAME.LocalDecimal = False
        Me.USER_NAME.Name = "USER_NAME"
        Me.USER_NAME.NoUpdate = ""
        Me.USER_NAME.NumberDecimal = 0
        Me.USER_NAME.ParentControl = ""
        Me.USER_NAME.RefreshSource = False
        Me.USER_NAME.Required = False
        Me.USER_NAME.ShowDataTime = False
        Me.USER_NAME.SQLString = ""
        Me.USER_NAME.UpdateIfNull = ""
        Me.USER_NAME.UpdateWhenFormLock = False
        Me.USER_NAME.Visible = True
        Me.USER_NAME.VisibleIndex = 0
        Me.USER_NAME.Width = 85
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.AllowInsert = True
        Me.DESCRIPTION.AllowUpdate = True
        Me.DESCRIPTION.Caption = "Ghi chú"
        Me.DESCRIPTION.CFLColumnHide = ""
        Me.DESCRIPTION.CFLKeyField = ""
        Me.DESCRIPTION.CFLPage = False
        Me.DESCRIPTION.CFLReturn0 = ""
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
        Me.DESCRIPTION.FormList = False
        Me.DESCRIPTION.KeyInsert = ""
        Me.DESCRIPTION.LocalDecimal = False
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.NoUpdate = ""
        Me.DESCRIPTION.NumberDecimal = 0
        Me.DESCRIPTION.ParentControl = ""
        Me.DESCRIPTION.RefreshSource = False
        Me.DESCRIPTION.Required = False
        Me.DESCRIPTION.ShowDataTime = False
        Me.DESCRIPTION.SQLString = ""
        Me.DESCRIPTION.UpdateIfNull = ""
        Me.DESCRIPTION.UpdateWhenFormLock = False
        Me.DESCRIPTION.Visible = True
        Me.DESCRIPTION.VisibleIndex = 1
        Me.DESCRIPTION.Width = 200
        '
        'START_DATE
        '
        Me.START_DATE.AllowInsert = True
        Me.START_DATE.AllowUpdate = True
        Me.START_DATE.Caption = "Ngày hiệu lực"
        Me.START_DATE.CFLColumnHide = ""
        Me.START_DATE.CFLKeyField = ""
        Me.START_DATE.CFLPage = False
        Me.START_DATE.CFLReturn0 = ""
        Me.START_DATE.CFLReturn1 = ""
        Me.START_DATE.CFLReturn2 = ""
        Me.START_DATE.CFLReturn3 = ""
        Me.START_DATE.CFLReturn4 = ""
        Me.START_DATE.CFLShowLoad = False
        Me.START_DATE.ChangeFormStatus = True
        Me.START_DATE.ColumnKey = False
        Me.START_DATE.ComboLine = 5
        Me.START_DATE.CopyFromItem = ""
        Me.START_DATE.DefaultButtonClick = False
        Me.START_DATE.Digit = False
        Me.START_DATE.FieldType = "D"
        Me.START_DATE.FieldView = "START_DATE"
        Me.START_DATE.FormList = False
        Me.START_DATE.KeyInsert = ""
        Me.START_DATE.LocalDecimal = False
        Me.START_DATE.Name = "START_DATE"
        Me.START_DATE.NoUpdate = ""
        Me.START_DATE.NumberDecimal = 0
        Me.START_DATE.ParentControl = ""
        Me.START_DATE.RefreshSource = False
        Me.START_DATE.Required = False
        Me.START_DATE.ShowDataTime = False
        Me.START_DATE.SQLString = ""
        Me.START_DATE.UpdateIfNull = ""
        Me.START_DATE.UpdateWhenFormLock = False
        Me.START_DATE.Visible = True
        Me.START_DATE.VisibleIndex = 2
        Me.START_DATE.Width = 90
        '
        'END_DATE
        '
        Me.END_DATE.AllowInsert = True
        Me.END_DATE.AllowUpdate = True
        Me.END_DATE.Caption = "Ngày hết hiệu lực"
        Me.END_DATE.CFLColumnHide = ""
        Me.END_DATE.CFLKeyField = ""
        Me.END_DATE.CFLPage = False
        Me.END_DATE.CFLReturn0 = ""
        Me.END_DATE.CFLReturn1 = ""
        Me.END_DATE.CFLReturn2 = ""
        Me.END_DATE.CFLReturn3 = ""
        Me.END_DATE.CFLReturn4 = ""
        Me.END_DATE.CFLShowLoad = False
        Me.END_DATE.ChangeFormStatus = True
        Me.END_DATE.ColumnKey = False
        Me.END_DATE.ComboLine = 5
        Me.END_DATE.CopyFromItem = ""
        Me.END_DATE.DefaultButtonClick = False
        Me.END_DATE.Digit = False
        Me.END_DATE.FieldType = "D"
        Me.END_DATE.FieldView = "END_DATE"
        Me.END_DATE.FormList = False
        Me.END_DATE.KeyInsert = ""
        Me.END_DATE.LocalDecimal = False
        Me.END_DATE.Name = "END_DATE"
        Me.END_DATE.NoUpdate = ""
        Me.END_DATE.NumberDecimal = 0
        Me.END_DATE.ParentControl = ""
        Me.END_DATE.RefreshSource = False
        Me.END_DATE.Required = False
        Me.END_DATE.ShowDataTime = False
        Me.END_DATE.SQLString = ""
        Me.END_DATE.UpdateIfNull = ""
        Me.END_DATE.UpdateWhenFormLock = False
        Me.END_DATE.Visible = True
        Me.END_DATE.VisibleIndex = 3
        Me.END_DATE.Width = 100
        '
        'FrmUserQLvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 389)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultSave = False
        Me.FormEdit = False
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmUserQLvb"
        Me.Text = "Quản trị người dùng"
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
End Class
