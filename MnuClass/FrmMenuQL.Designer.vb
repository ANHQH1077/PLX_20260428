<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuQL
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
        Me.CmdAdd = New U_TextBox.U_Button(Me.components)
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.MENU_ID = New U_TextBox.GridColumn()
        Me.MENU_CODE = New U_TextBox.GridColumn()
        Me.MENU_NAME = New U_TextBox.GridColumn()
        Me.DESCRIPTION = New U_TextBox.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdAdd
        '
        Me.CmdAdd.DefaultUpdate = True
        Me.CmdAdd.Location = New System.Drawing.Point(4, 350)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.CmdAdd.TabIndex = 299
        Me.CmdAdd.Text = "&1. Thêm mới"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 2)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(638, 342)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "MENU_ID"
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MENU_ID, Me.MENU_CODE, Me.MENU_NAME, Me.DESCRIPTION})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = False
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "MENU_CODE"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "SYS_MENU"
        Me.GridView1.ViewName = "SYS_MENU"
        Me.GridView1.Where = Nothing
        '
        'MENU_ID
        '
        Me.MENU_ID.AllowInsert = True
        Me.MENU_ID.AllowUpdate = True
        Me.MENU_ID.Caption = "MENU_ID"
        Me.MENU_ID.CFLColumnHide = ""
        Me.MENU_ID.CFLKeyField = ""
        Me.MENU_ID.CFLPage = False
        Me.MENU_ID.CFLReturn0 = ""
        Me.MENU_ID.CFLReturn1 = ""
        Me.MENU_ID.CFLReturn2 = ""
        Me.MENU_ID.CFLReturn3 = ""
        Me.MENU_ID.CFLReturn4 = ""
        Me.MENU_ID.CFLShowLoad = False
        Me.MENU_ID.ChangeFormStatus = True
        Me.MENU_ID.ColumnKey = False
        Me.MENU_ID.ComboLine = 5
        Me.MENU_ID.CopyFromItem = ""
        Me.MENU_ID.DefaultButtonClick = False
        Me.MENU_ID.Digit = False
        Me.MENU_ID.FieldType = "N"
        Me.MENU_ID.FieldView = "MENU_ID"
        Me.MENU_ID.FormList = False
        Me.MENU_ID.KeyInsert = ""
        Me.MENU_ID.LocalDecimal = False
        Me.MENU_ID.Name = "MENU_ID"
        Me.MENU_ID.NoUpdate = ""
        Me.MENU_ID.NumberDecimal = 0
        Me.MENU_ID.ParentControl = ""
        Me.MENU_ID.RefreshSource = False
        Me.MENU_ID.Required = False
        Me.MENU_ID.ShowDataTime = False
        Me.MENU_ID.SQLString = ""
        Me.MENU_ID.UpdateIfNull = ""
        Me.MENU_ID.UpdateWhenFormLock = False
        Me.MENU_ID.ValidateValue = True
        Me.MENU_ID.Visible = True
        '
        'MENU_CODE
        '
        Me.MENU_CODE.AllowInsert = True
        Me.MENU_CODE.AllowUpdate = True
        Me.MENU_CODE.Caption = "Mã Menu"
        Me.MENU_CODE.CFLColumnHide = ""
        Me.MENU_CODE.CFLKeyField = ""
        Me.MENU_CODE.CFLPage = False
        Me.MENU_CODE.CFLReturn0 = ""
        Me.MENU_CODE.CFLReturn1 = ""
        Me.MENU_CODE.CFLReturn2 = ""
        Me.MENU_CODE.CFLReturn3 = ""
        Me.MENU_CODE.CFLReturn4 = ""
        Me.MENU_CODE.CFLShowLoad = False
        Me.MENU_CODE.ChangeFormStatus = True
        Me.MENU_CODE.ColumnKey = False
        Me.MENU_CODE.ComboLine = 5
        Me.MENU_CODE.CopyFromItem = ""
        Me.MENU_CODE.DefaultButtonClick = False
        Me.MENU_CODE.Digit = False
        Me.MENU_CODE.FieldType = "C"
        Me.MENU_CODE.FieldView = "MENU_CODE"
        Me.MENU_CODE.FormList = False
        Me.MENU_CODE.KeyInsert = ""
        Me.MENU_CODE.LocalDecimal = False
        Me.MENU_CODE.Name = "MENU_CODE"
        Me.MENU_CODE.NoUpdate = ""
        Me.MENU_CODE.NumberDecimal = 0
        Me.MENU_CODE.ParentControl = ""
        Me.MENU_CODE.RefreshSource = False
        Me.MENU_CODE.Required = False
        Me.MENU_CODE.ShowDataTime = False
        Me.MENU_CODE.SQLString = ""
        Me.MENU_CODE.UpdateIfNull = ""
        Me.MENU_CODE.UpdateWhenFormLock = False
        Me.MENU_CODE.ValidateValue = True
        Me.MENU_CODE.Visible = True
        Me.MENU_CODE.VisibleIndex = 0
        '
        'MENU_NAME
        '
        Me.MENU_NAME.AllowInsert = True
        Me.MENU_NAME.AllowUpdate = True
        Me.MENU_NAME.Caption = "Tên Menu"
        Me.MENU_NAME.CFLColumnHide = ""
        Me.MENU_NAME.CFLKeyField = ""
        Me.MENU_NAME.CFLPage = False
        Me.MENU_NAME.CFLReturn0 = ""
        Me.MENU_NAME.CFLReturn1 = ""
        Me.MENU_NAME.CFLReturn2 = ""
        Me.MENU_NAME.CFLReturn3 = ""
        Me.MENU_NAME.CFLReturn4 = ""
        Me.MENU_NAME.CFLShowLoad = False
        Me.MENU_NAME.ChangeFormStatus = True
        Me.MENU_NAME.ColumnKey = False
        Me.MENU_NAME.ComboLine = 5
        Me.MENU_NAME.CopyFromItem = ""
        Me.MENU_NAME.DefaultButtonClick = False
        Me.MENU_NAME.Digit = False
        Me.MENU_NAME.FieldType = "C"
        Me.MENU_NAME.FieldView = "MENU_NAME"
        Me.MENU_NAME.FormList = False
        Me.MENU_NAME.KeyInsert = ""
        Me.MENU_NAME.LocalDecimal = False
        Me.MENU_NAME.Name = "MENU_NAME"
        Me.MENU_NAME.NoUpdate = ""
        Me.MENU_NAME.NumberDecimal = 0
        Me.MENU_NAME.ParentControl = ""
        Me.MENU_NAME.RefreshSource = False
        Me.MENU_NAME.Required = False
        Me.MENU_NAME.ShowDataTime = False
        Me.MENU_NAME.SQLString = ""
        Me.MENU_NAME.UpdateIfNull = ""
        Me.MENU_NAME.UpdateWhenFormLock = False
        Me.MENU_NAME.ValidateValue = True
        Me.MENU_NAME.Visible = True
        Me.MENU_NAME.VisibleIndex = 1
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
        '
        'FrmMenuQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ButtonSave = ""
        Me.ClientSize = New System.Drawing.Size(643, 378)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.CmdAdd)
        Me.DefaultFormLoad = False
        Me.KeyPreview = True
        Me.Name = "FrmMenuQL"
        Me.Text = "Quản lý danh sách Menu"
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmdAdd As U_TextBox.U_Button
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents MENU_ID As U_TextBox.GridColumn
    Friend WithEvents MENU_CODE As U_TextBox.GridColumn
    Friend WithEvents MENU_NAME As U_TextBox.GridColumn
    Friend WithEvents DESCRIPTION As U_TextBox.GridColumn
End Class
