<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFormNew
    Inherits U_CusForm.XtraCusForm1  ' System.Windows.Forms.Form

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
        Me.GRIDVIEW1 = New U_TextBox.GridView()
        Me.FORM_ID = New U_TextBox.GridColumn()
        Me.PROJECT_CODE = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.FORM_NAME = New U_TextBox.GridColumn()
        Me.DESCRIPTION = New U_TextBox.GridColumn()
        Me.FROM_DATE = New U_TextBox.GridColumn()
        Me.TO_DATE = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.Icon_File = New U_TextBox.GridColumn()
        Me.BtnOk = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDVIEW1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(1, 1)
        Me.TrueDBGrid1.MainView = Me.GRIDVIEW1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(840, 445)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDVIEW1})
        '
        'GRIDVIEW1
        '
        Me.GRIDVIEW1.AllowInsert = True
        Me.GRIDVIEW1.CheckUpd = True
        Me.GRIDVIEW1.ColumnAutoWidth = False
        Me.GRIDVIEW1.ColumnKey = "FORM_ID"
        Me.GRIDVIEW1.ColumnKeyIns = False
        Me.GRIDVIEW1.ColumnKeyType = "N"
        Me.GRIDVIEW1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FORM_ID, Me.PROJECT_CODE, Me.FORM_NAME, Me.DESCRIPTION, Me.FROM_DATE, Me.TO_DATE, Me.CHECKUPD, Me.Icon_File})
        Me.GRIDVIEW1.CompanyCode = ""
        Me.GRIDVIEW1.DefaultRemove = True
        Me.GRIDVIEW1.GetB1 = False
        Me.GRIDVIEW1.GridControl = Me.TrueDBGrid1
        Me.GRIDVIEW1.LastQuery = ""
        Me.GRIDVIEW1.Name = "GRIDVIEW1"
        Me.GRIDVIEW1.ObjectChild = False
        Me.GRIDVIEW1.OrderBy = "PROJECT_CODE, FORM_NAME"
        Me.GRIDVIEW1.ParentItem = Nothing
        Me.GRIDVIEW1.RowNumber = ""
        Me.GRIDVIEW1.TableName = "SYS_FORMS"
        Me.GRIDVIEW1.ViewName = "SYS_FORMS_V"
        Me.GRIDVIEW1.Where = Nothing
        '
        'FORM_ID
        '
        Me.FORM_ID.AllowInsert = False
        Me.FORM_ID.AllowUpdate = True
        Me.FORM_ID.Caption = "FORM_ID"
        Me.FORM_ID.CFLColumnHide = ""
        Me.FORM_ID.CFLKeyField = ""
        Me.FORM_ID.CFLPage = False
        Me.FORM_ID.CFLReturn0 = ""
        Me.FORM_ID.CFLReturn1 = ""
        Me.FORM_ID.CFLReturn2 = ""
        Me.FORM_ID.CFLReturn3 = ""
        Me.FORM_ID.CFLReturn4 = ""
        Me.FORM_ID.CFLReturn5 = ""
        Me.FORM_ID.CFLReturn6 = ""
        Me.FORM_ID.CFLReturn7 = ""
        Me.FORM_ID.CFLShowLoad = False
        Me.FORM_ID.ChangeFormStatus = True
        Me.FORM_ID.ColumnKey = True
        Me.FORM_ID.ComboLine = 5
        Me.FORM_ID.CopyFromItem = ""
        Me.FORM_ID.DefaultButtonClick = False
        Me.FORM_ID.Digit = False
        Me.FORM_ID.FieldType = "N"
        Me.FORM_ID.FieldView = "FORM_ID"
        Me.FORM_ID.FormList = False
        Me.FORM_ID.KeyInsert = "N"
        Me.FORM_ID.LocalDecimal = False
        Me.FORM_ID.Name = "FORM_ID"
        Me.FORM_ID.NoUpdate = ""
        Me.FORM_ID.NumberDecimal = 0
        Me.FORM_ID.ParentControl = ""
        Me.FORM_ID.RefreshSource = False
        Me.FORM_ID.Required = False
        Me.FORM_ID.ShowDataTime = False
        Me.FORM_ID.SQLString = ""
        Me.FORM_ID.UpdateIfNull = ""
        Me.FORM_ID.UpdateWhenFormLock = False
        Me.FORM_ID.ValidateValue = True
        Me.FORM_ID.Visible = True
        '
        'PROJECT_CODE
        '
        Me.PROJECT_CODE.AllowInsert = True
        Me.PROJECT_CODE.AllowUpdate = True
        Me.PROJECT_CODE.Caption = "Module"
        Me.PROJECT_CODE.CFLColumnHide = ""
        Me.PROJECT_CODE.CFLKeyField = "PROJECT_CODE"
        Me.PROJECT_CODE.CFLPage = False
        Me.PROJECT_CODE.CFLReturn0 = ""
        Me.PROJECT_CODE.CFLReturn1 = ""
        Me.PROJECT_CODE.CFLReturn2 = ""
        Me.PROJECT_CODE.CFLReturn3 = ""
        Me.PROJECT_CODE.CFLReturn4 = ""
        Me.PROJECT_CODE.CFLReturn5 = ""
        Me.PROJECT_CODE.CFLReturn6 = ""
        Me.PROJECT_CODE.CFLReturn7 = ""
        Me.PROJECT_CODE.CFLShowLoad = False
        Me.PROJECT_CODE.ChangeFormStatus = True
        Me.PROJECT_CODE.ColumnEdit = Me.RepositoryItemComboBox1
        Me.PROJECT_CODE.ColumnKey = False
        Me.PROJECT_CODE.ComboLine = 5
        Me.PROJECT_CODE.CopyFromItem = ""
        Me.PROJECT_CODE.DefaultButtonClick = False
        Me.PROJECT_CODE.Digit = False
        Me.PROJECT_CODE.FieldType = "C"
        Me.PROJECT_CODE.FieldView = "PROJECT_CODE"
        Me.PROJECT_CODE.FormList = False
        Me.PROJECT_CODE.KeyInsert = ""
        Me.PROJECT_CODE.LocalDecimal = False
        Me.PROJECT_CODE.Name = "PROJECT_CODE"
        Me.PROJECT_CODE.NoUpdate = ""
        Me.PROJECT_CODE.NumberDecimal = 0
        Me.PROJECT_CODE.ParentControl = ""
        Me.PROJECT_CODE.RefreshSource = False
        Me.PROJECT_CODE.Required = False
        Me.PROJECT_CODE.ShowDataTime = False
        Me.PROJECT_CODE.SQLString = "SELECT PROJECT_CODE FROM SYS_PROJECTS WHERE isnull(ENABLE_FLAG,'Y') ='Y'"
        Me.PROJECT_CODE.UpdateIfNull = ""
        Me.PROJECT_CODE.UpdateWhenFormLock = False
        Me.PROJECT_CODE.ValidateValue = True
        Me.PROJECT_CODE.Visible = True
        Me.PROJECT_CODE.VisibleIndex = 0
        Me.PROJECT_CODE.Width = 137
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
        Me.FORM_NAME.Caption = "Tên form"
        Me.FORM_NAME.CFLColumnHide = ""
        Me.FORM_NAME.CFLKeyField = ""
        Me.FORM_NAME.CFLPage = False
        Me.FORM_NAME.CFLReturn0 = ""
        Me.FORM_NAME.CFLReturn1 = ""
        Me.FORM_NAME.CFLReturn2 = ""
        Me.FORM_NAME.CFLReturn3 = ""
        Me.FORM_NAME.CFLReturn4 = ""
        Me.FORM_NAME.CFLReturn5 = ""
        Me.FORM_NAME.CFLReturn6 = ""
        Me.FORM_NAME.CFLReturn7 = ""
        Me.FORM_NAME.CFLShowLoad = False
        Me.FORM_NAME.ChangeFormStatus = True
        Me.FORM_NAME.ColumnKey = False
        Me.FORM_NAME.ComboLine = 5
        Me.FORM_NAME.CopyFromItem = ""
        Me.FORM_NAME.DefaultButtonClick = False
        Me.FORM_NAME.Digit = False
        Me.FORM_NAME.FieldType = "C"
        Me.FORM_NAME.FieldView = "FORM_NAME"
        Me.FORM_NAME.FormList = False
        Me.FORM_NAME.KeyInsert = ""
        Me.FORM_NAME.LocalDecimal = False
        Me.FORM_NAME.Name = "FORM_NAME"
        Me.FORM_NAME.NoUpdate = ""
        Me.FORM_NAME.NumberDecimal = 0
        Me.FORM_NAME.ParentControl = ""
        Me.FORM_NAME.RefreshSource = False
        Me.FORM_NAME.Required = False
        Me.FORM_NAME.ShowDataTime = False
        Me.FORM_NAME.SQLString = ""
        Me.FORM_NAME.UpdateIfNull = ""
        Me.FORM_NAME.UpdateWhenFormLock = False
        Me.FORM_NAME.ValidateValue = True
        Me.FORM_NAME.Visible = True
        Me.FORM_NAME.VisibleIndex = 1
        Me.FORM_NAME.Width = 137
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.AllowInsert = True
        Me.DESCRIPTION.AllowUpdate = True
        Me.DESCRIPTION.Caption = "Ghi chú"
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
        Me.DESCRIPTION.ValidateValue = True
        Me.DESCRIPTION.Visible = True
        Me.DESCRIPTION.VisibleIndex = 2
        Me.DESCRIPTION.Width = 137
        '
        'FROM_DATE
        '
        Me.FROM_DATE.AllowInsert = True
        Me.FROM_DATE.AllowUpdate = True
        Me.FROM_DATE.Caption = "Ngày hiệu lực"
        Me.FROM_DATE.CFLColumnHide = ""
        Me.FROM_DATE.CFLKeyField = ""
        Me.FROM_DATE.CFLPage = False
        Me.FROM_DATE.CFLReturn0 = ""
        Me.FROM_DATE.CFLReturn1 = ""
        Me.FROM_DATE.CFLReturn2 = ""
        Me.FROM_DATE.CFLReturn3 = ""
        Me.FROM_DATE.CFLReturn4 = ""
        Me.FROM_DATE.CFLReturn5 = ""
        Me.FROM_DATE.CFLReturn6 = ""
        Me.FROM_DATE.CFLReturn7 = ""
        Me.FROM_DATE.CFLShowLoad = False
        Me.FROM_DATE.ChangeFormStatus = True
        Me.FROM_DATE.ColumnKey = False
        Me.FROM_DATE.ComboLine = 5
        Me.FROM_DATE.CopyFromItem = ""
        Me.FROM_DATE.DefaultButtonClick = False
        Me.FROM_DATE.Digit = False
        Me.FROM_DATE.FieldType = "D"
        Me.FROM_DATE.FieldView = "FROM_DATE"
        Me.FROM_DATE.FormList = False
        Me.FROM_DATE.KeyInsert = ""
        Me.FROM_DATE.LocalDecimal = False
        Me.FROM_DATE.Name = "FROM_DATE"
        Me.FROM_DATE.NoUpdate = ""
        Me.FROM_DATE.NumberDecimal = 0
        Me.FROM_DATE.ParentControl = ""
        Me.FROM_DATE.RefreshSource = False
        Me.FROM_DATE.Required = False
        Me.FROM_DATE.ShowDataTime = False
        Me.FROM_DATE.SQLString = ""
        Me.FROM_DATE.UpdateIfNull = ""
        Me.FROM_DATE.UpdateWhenFormLock = False
        Me.FROM_DATE.ValidateValue = True
        Me.FROM_DATE.Visible = True
        Me.FROM_DATE.VisibleIndex = 3
        Me.FROM_DATE.Width = 137
        '
        'TO_DATE
        '
        Me.TO_DATE.AllowInsert = True
        Me.TO_DATE.AllowUpdate = True
        Me.TO_DATE.Caption = "Ngày hết hiệu lực"
        Me.TO_DATE.CFLColumnHide = ""
        Me.TO_DATE.CFLKeyField = ""
        Me.TO_DATE.CFLPage = False
        Me.TO_DATE.CFLReturn0 = ""
        Me.TO_DATE.CFLReturn1 = ""
        Me.TO_DATE.CFLReturn2 = ""
        Me.TO_DATE.CFLReturn3 = ""
        Me.TO_DATE.CFLReturn4 = ""
        Me.TO_DATE.CFLReturn5 = ""
        Me.TO_DATE.CFLReturn6 = ""
        Me.TO_DATE.CFLReturn7 = ""
        Me.TO_DATE.CFLShowLoad = False
        Me.TO_DATE.ChangeFormStatus = True
        Me.TO_DATE.ColumnKey = False
        Me.TO_DATE.ComboLine = 5
        Me.TO_DATE.CopyFromItem = ""
        Me.TO_DATE.DefaultButtonClick = False
        Me.TO_DATE.Digit = False
        Me.TO_DATE.FieldType = "D"
        Me.TO_DATE.FieldView = "TO_DATE"
        Me.TO_DATE.FormList = False
        Me.TO_DATE.KeyInsert = ""
        Me.TO_DATE.LocalDecimal = False
        Me.TO_DATE.Name = "TO_DATE"
        Me.TO_DATE.NoUpdate = ""
        Me.TO_DATE.NumberDecimal = 0
        Me.TO_DATE.ParentControl = ""
        Me.TO_DATE.RefreshSource = False
        Me.TO_DATE.Required = False
        Me.TO_DATE.ShowDataTime = False
        Me.TO_DATE.SQLString = ""
        Me.TO_DATE.UpdateIfNull = ""
        Me.TO_DATE.UpdateWhenFormLock = False
        Me.TO_DATE.ValidateValue = True
        Me.TO_DATE.Visible = True
        Me.TO_DATE.VisibleIndex = 4
        Me.TO_DATE.Width = 137
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.Caption = "GridColumn1"
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
        Me.CHECKUPD.FormList = False
        Me.CHECKUPD.KeyInsert = ""
        Me.CHECKUPD.LocalDecimal = False
        Me.CHECKUPD.Name = "CHECKUPD"
        Me.CHECKUPD.NoUpdate = ""
        Me.CHECKUPD.NumberDecimal = 0
        Me.CHECKUPD.ParentControl = ""
        Me.CHECKUPD.RefreshSource = False
        Me.CHECKUPD.Required = False
        Me.CHECKUPD.ShowDataTime = False
        Me.CHECKUPD.SQLString = ""
        Me.CHECKUPD.UpdateIfNull = ""
        Me.CHECKUPD.UpdateWhenFormLock = False
        Me.CHECKUPD.ValidateValue = True
        Me.CHECKUPD.Visible = True
        Me.CHECKUPD.Width = 20
        '
        'Icon_File
        '
        Me.Icon_File.AllowInsert = True
        Me.Icon_File.AllowUpdate = True
        Me.Icon_File.Caption = "File ảnh"
        Me.Icon_File.CFLColumnHide = ""
        Me.Icon_File.CFLKeyField = ""
        Me.Icon_File.CFLPage = False
        Me.Icon_File.CFLReturn0 = ""
        Me.Icon_File.CFLReturn1 = ""
        Me.Icon_File.CFLReturn2 = ""
        Me.Icon_File.CFLReturn3 = ""
        Me.Icon_File.CFLReturn4 = ""
        Me.Icon_File.CFLReturn5 = ""
        Me.Icon_File.CFLReturn6 = ""
        Me.Icon_File.CFLReturn7 = ""
        Me.Icon_File.CFLShowLoad = False
        Me.Icon_File.ChangeFormStatus = True
        Me.Icon_File.ColumnKey = False
        Me.Icon_File.ComboLine = 5
        Me.Icon_File.CopyFromItem = ""
        Me.Icon_File.DefaultButtonClick = False
        Me.Icon_File.Digit = False
        Me.Icon_File.FieldType = "C"
        Me.Icon_File.FieldView = "Icon_File"
        Me.Icon_File.FormList = False
        Me.Icon_File.KeyInsert = ""
        Me.Icon_File.LocalDecimal = False
        Me.Icon_File.Name = "Icon_File"
        Me.Icon_File.NoUpdate = ""
        Me.Icon_File.NumberDecimal = 0
        Me.Icon_File.ParentControl = ""
        Me.Icon_File.RefreshSource = False
        Me.Icon_File.Required = False
        Me.Icon_File.ShowDataTime = False
        Me.Icon_File.SQLString = ""
        Me.Icon_File.UpdateIfNull = ""
        Me.Icon_File.UpdateWhenFormLock = False
        Me.Icon_File.ValidateValue = True
        Me.Icon_File.Visible = True
        Me.Icon_File.VisibleIndex = 5
        '
        'BtnOk
        '
        Me.BtnOk.DefaultUpdate = True
        Me.BtnOk.Location = New System.Drawing.Point(12, 452)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(107, 23)
        Me.BtnOk.TabIndex = 1
        Me.BtnOk.Text = "Ok"
        '
        'FrmFormNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionAdd = "Ok"
        Me.ClientSize = New System.Drawing.Size(842, 480)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.KeyPreview = True
        Me.Name = "FrmFormNew"
        Me.Text = "Danh sách Form"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.BtnOk, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDVIEW1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    ' Friend WithEvents BtnOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GRIDVIEW1 As U_TextBox.GridView
    Friend WithEvents FORM_ID As U_TextBox.GridColumn
    Friend WithEvents PROJECT_CODE As U_TextBox.GridColumn
    Friend WithEvents FORM_NAME As U_TextBox.GridColumn
    Friend WithEvents DESCRIPTION As U_TextBox.GridColumn
    Friend WithEvents FROM_DATE As U_TextBox.GridColumn
    Friend WithEvents TO_DATE As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents BtnOk As U_TextBox.U_ButtonCus
    Friend WithEvents Icon_File As U_TextBox.GridColumn
End Class
