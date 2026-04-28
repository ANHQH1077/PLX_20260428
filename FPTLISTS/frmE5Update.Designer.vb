<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmE5Update
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmE5Update))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.vOrder = New U_TextBox.GridColumn()
        Me.FieldName = New U_TextBox.GridColumn()
        Me.sNote = New U_TextBox.GridColumn()
        Me.UnVisible = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.Locked = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(644, 470)
        Me.TrueDBGrid1.TabIndex = 1
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.vOrder, Me.FieldName, Me.sNote, Me.UnVisible, Me.CHECKUPD, Me.Locked})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "vOrder"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblLenhXuatChiTietE5_Info"
        Me.GridView1.ViewName = "FPT_LenhXuatChiTietE5_Info_v"
        Me.GridView1.Where = Nothing
        '
        'vOrder
        '
        Me.vOrder.AllowInsert = True
        Me.vOrder.AllowUpdate = True
        Me.vOrder.Caption = "STT"
        Me.vOrder.CFLColumnHide = ""
        Me.vOrder.CFLKeyField = ""
        Me.vOrder.CFLPage = False
        Me.vOrder.CFLReturn0 = ""
        Me.vOrder.CFLReturn1 = ""
        Me.vOrder.CFLReturn2 = ""
        Me.vOrder.CFLReturn3 = ""
        Me.vOrder.CFLReturn4 = ""
        Me.vOrder.CFLReturn5 = ""
        Me.vOrder.CFLReturn6 = ""
        Me.vOrder.CFLReturn7 = ""
        Me.vOrder.CFLShowLoad = False
        Me.vOrder.ChangeFormStatus = True
        Me.vOrder.ColumnKey = False
        Me.vOrder.ComboLine = 5
        Me.vOrder.CopyFromItem = ""
        Me.vOrder.DefaultButtonClick = False
        Me.vOrder.Digit = False
        Me.vOrder.FieldType = "N"
        Me.vOrder.FieldView = "vOrder"
        Me.vOrder.FormList = False
        Me.vOrder.KeyInsert = ""
        Me.vOrder.LocalDecimal = False
        Me.vOrder.Name = "vOrder"
        Me.vOrder.NoUpdate = ""
        Me.vOrder.NumberDecimal = 0
        Me.vOrder.ParentControl = ""
        Me.vOrder.RefreshSource = False
        Me.vOrder.Required = False
        Me.vOrder.ShowDataTime = False
        Me.vOrder.SQLString = ""
        Me.vOrder.UpdateIfNull = ""
        Me.vOrder.UpdateWhenFormLock = False
        Me.vOrder.ValidateValue = True
        Me.vOrder.Visible = True
        Me.vOrder.VisibleIndex = 0
        '
        'FieldName
        '
        Me.FieldName.AllowInsert = True
        Me.FieldName.AllowUpdate = True
        Me.FieldName.Caption = "Tên trường"
        Me.FieldName.CFLColumnHide = ""
        Me.FieldName.CFLKeyField = ""
        Me.FieldName.CFLPage = False
        Me.FieldName.CFLReturn0 = ""
        Me.FieldName.CFLReturn1 = ""
        Me.FieldName.CFLReturn2 = ""
        Me.FieldName.CFLReturn3 = ""
        Me.FieldName.CFLReturn4 = ""
        Me.FieldName.CFLReturn5 = ""
        Me.FieldName.CFLReturn6 = ""
        Me.FieldName.CFLReturn7 = ""
        Me.FieldName.CFLShowLoad = False
        Me.FieldName.ChangeFormStatus = True
        Me.FieldName.ColumnKey = True
        Me.FieldName.ComboLine = 5
        Me.FieldName.CopyFromItem = ""
        Me.FieldName.DefaultButtonClick = False
        Me.FieldName.Digit = False
        Me.FieldName.FieldType = "C"
        Me.FieldName.FieldView = "FieldName"
        Me.FieldName.FormList = False
        Me.FieldName.KeyInsert = ""
        Me.FieldName.LocalDecimal = False
        Me.FieldName.Name = "FieldName"
        Me.FieldName.NoUpdate = ""
        Me.FieldName.NumberDecimal = 0
        Me.FieldName.OptionsColumn.AllowEdit = False
        Me.FieldName.ParentControl = ""
        Me.FieldName.RefreshSource = False
        Me.FieldName.Required = False
        Me.FieldName.ShowDataTime = False
        Me.FieldName.SQLString = ""
        Me.FieldName.UpdateIfNull = ""
        Me.FieldName.UpdateWhenFormLock = False
        Me.FieldName.ValidateValue = True
        Me.FieldName.Visible = True
        Me.FieldName.VisibleIndex = 1
        Me.FieldName.Width = 90
        '
        'sNote
        '
        Me.sNote.AllowInsert = True
        Me.sNote.AllowUpdate = True
        Me.sNote.Caption = "Mô tả"
        Me.sNote.CFLColumnHide = ""
        Me.sNote.CFLKeyField = ""
        Me.sNote.CFLPage = False
        Me.sNote.CFLReturn0 = ""
        Me.sNote.CFLReturn1 = ""
        Me.sNote.CFLReturn2 = ""
        Me.sNote.CFLReturn3 = ""
        Me.sNote.CFLReturn4 = ""
        Me.sNote.CFLReturn5 = ""
        Me.sNote.CFLReturn6 = ""
        Me.sNote.CFLReturn7 = ""
        Me.sNote.CFLShowLoad = False
        Me.sNote.ChangeFormStatus = True
        Me.sNote.ColumnKey = False
        Me.sNote.ComboLine = 5
        Me.sNote.CopyFromItem = ""
        Me.sNote.DefaultButtonClick = False
        Me.sNote.Digit = False
        Me.sNote.FieldType = "C"
        Me.sNote.FieldView = "sNote"
        Me.sNote.FormList = False
        Me.sNote.KeyInsert = ""
        Me.sNote.LocalDecimal = False
        Me.sNote.Name = "sNote"
        Me.sNote.NoUpdate = ""
        Me.sNote.NumberDecimal = 0
        Me.sNote.ParentControl = ""
        Me.sNote.RefreshSource = False
        Me.sNote.Required = False
        Me.sNote.ShowDataTime = False
        Me.sNote.SQLString = ""
        Me.sNote.UpdateIfNull = ""
        Me.sNote.UpdateWhenFormLock = False
        Me.sNote.ValidateValue = True
        Me.sNote.Visible = True
        Me.sNote.VisibleIndex = 2
        Me.sNote.Width = 250
        '
        'UnVisible
        '
        Me.UnVisible.AllowInsert = True
        Me.UnVisible.AllowUpdate = True
        Me.UnVisible.Caption = "Trường ẩn"
        Me.UnVisible.CFLColumnHide = ""
        Me.UnVisible.CFLKeyField = ""
        Me.UnVisible.CFLPage = False
        Me.UnVisible.CFLReturn0 = ""
        Me.UnVisible.CFLReturn1 = ""
        Me.UnVisible.CFLReturn2 = ""
        Me.UnVisible.CFLReturn3 = ""
        Me.UnVisible.CFLReturn4 = ""
        Me.UnVisible.CFLReturn5 = ""
        Me.UnVisible.CFLReturn6 = ""
        Me.UnVisible.CFLReturn7 = ""
        Me.UnVisible.CFLShowLoad = False
        Me.UnVisible.ChangeFormStatus = True
        Me.UnVisible.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.UnVisible.ColumnKey = False
        Me.UnVisible.ComboLine = 5
        Me.UnVisible.CopyFromItem = ""
        Me.UnVisible.DefaultButtonClick = False
        Me.UnVisible.Digit = True
        Me.UnVisible.FieldType = "C"
        Me.UnVisible.FieldView = "UnVisible"
        Me.UnVisible.FormList = False
        Me.UnVisible.KeyInsert = ""
        Me.UnVisible.LocalDecimal = True
        Me.UnVisible.Name = "UnVisible"
        Me.UnVisible.NoUpdate = ""
        Me.UnVisible.NumberDecimal = 2
        Me.UnVisible.ParentControl = ""
        Me.UnVisible.RefreshSource = False
        Me.UnVisible.Required = False
        Me.UnVisible.ShowDataTime = False
        Me.UnVisible.SQLString = ""
        Me.UnVisible.UpdateIfNull = ""
        Me.UnVisible.UpdateWhenFormLock = False
        Me.UnVisible.ValidateValue = True
        Me.UnVisible.Visible = True
        Me.UnVisible.VisibleIndex = 3
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
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
        '
        'Locked
        '
        Me.Locked.AllowInsert = True
        Me.Locked.AllowUpdate = True
        Me.Locked.Caption = "Chỉ xem"
        Me.Locked.CFLColumnHide = ""
        Me.Locked.CFLKeyField = ""
        Me.Locked.CFLPage = False
        Me.Locked.CFLReturn0 = ""
        Me.Locked.CFLReturn1 = ""
        Me.Locked.CFLReturn2 = ""
        Me.Locked.CFLReturn3 = ""
        Me.Locked.CFLReturn4 = ""
        Me.Locked.CFLReturn5 = ""
        Me.Locked.CFLReturn6 = ""
        Me.Locked.CFLReturn7 = ""
        Me.Locked.CFLShowLoad = False
        Me.Locked.ChangeFormStatus = True
        Me.Locked.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.Locked.ColumnKey = False
        Me.Locked.ComboLine = 5
        Me.Locked.CopyFromItem = ""
        Me.Locked.DefaultButtonClick = False
        Me.Locked.Digit = False
        Me.Locked.FieldType = "C"
        Me.Locked.FieldView = "Locked"
        Me.Locked.FormList = False
        Me.Locked.KeyInsert = ""
        Me.Locked.LocalDecimal = False
        Me.Locked.Name = "Locked"
        Me.Locked.NoUpdate = ""
        Me.Locked.NumberDecimal = 0
        Me.Locked.ParentControl = ""
        Me.Locked.RefreshSource = False
        Me.Locked.Required = False
        Me.Locked.ShowDataTime = False
        Me.Locked.SQLString = ""
        Me.Locked.UpdateIfNull = ""
        Me.Locked.UpdateWhenFormLock = False
        Me.Locked.ValidateValue = True
        Me.Locked.Visible = True
        Me.Locked.VisibleIndex = 4
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(650, 28)
        Me.ToolStrip2.TabIndex = 470
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
        'frmE5Update
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 524)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmE5Update"
        Me.ShowFormMessage = True
        Me.Text = "Cấu hình cập nhật xăng pha chế"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents FieldName As U_TextBox.GridColumn
    Friend WithEvents sNote As U_TextBox.GridColumn
    Friend WithEvents UnVisible As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents vOrder As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Locked As U_TextBox.GridColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
