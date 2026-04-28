<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUpdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUpdate))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.X = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.FileName = New U_TextBox.GridColumn()
        Me.PathFile = New U_TextBox.GridColumn()
        Me.FullVersion = New U_TextBox.GridColumn()
        Me.FileMajor = New U_TextBox.GridColumn()
        Me.FileMinor = New U_TextBox.GridColumn()
        Me.FileBuild = New U_TextBox.GridColumn()
        Me.FileRevision = New U_TextBox.GridColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.First.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Last.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Next.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Prev.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(4, 40)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(349, 367)
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.X, Me.FileName, Me.PathFile, Me.FullVersion, Me.FileMajor, Me.FileMinor, Me.FileBuild, Me.FileRevision})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
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
        Me.GridView1.TableName = "SYS_VERSION"
        Me.GridView1.ViewName = "FPT_SYS_VERSION"
        Me.GridView1.Where = Nothing
        '
        'X
        '
        Me.X.AllowInsert = True
        Me.X.AllowUpdate = True
        Me.X.Caption = "X"
        Me.X.CFLColumnHide = ""
        Me.X.CFLKeyField = ""
        Me.X.CFLPage = False
        Me.X.CFLReturn0 = ""
        Me.X.CFLReturn1 = ""
        Me.X.CFLReturn2 = ""
        Me.X.CFLReturn3 = ""
        Me.X.CFLReturn4 = ""
        Me.X.CFLShowLoad = False
        Me.X.ChangeFormStatus = False
        Me.X.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.X.ColumnKey = False
        Me.X.ComboLine = 5
        Me.X.CopyFromItem = ""
        Me.X.DefaultButtonClick = False
        Me.X.Digit = False
        Me.X.FieldType = "C"
        Me.X.FieldView = "X"
        Me.X.FormList = False
        Me.X.KeyInsert = ""
        Me.X.LocalDecimal = False
        Me.X.Name = "X"
        Me.X.NoUpdate = ""
        Me.X.NumberDecimal = 0
        Me.X.ParentControl = ""
        Me.X.RefreshSource = False
        Me.X.Required = False
        Me.X.ShowDataTime = False
        Me.X.SQLString = ""
        Me.X.UpdateIfNull = ""
        Me.X.UpdateWhenFormLock = False
        Me.X.Visible = True
        Me.X.VisibleIndex = 0
        Me.X.Width = 30
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'FileName
        '
        Me.FileName.AllowInsert = True
        Me.FileName.AllowUpdate = True
        Me.FileName.Caption = "File cập nhật"
        Me.FileName.CFLColumnHide = ""
        Me.FileName.CFLKeyField = ""
        Me.FileName.CFLPage = False
        Me.FileName.CFLReturn0 = ""
        Me.FileName.CFLReturn1 = ""
        Me.FileName.CFLReturn2 = ""
        Me.FileName.CFLReturn3 = ""
        Me.FileName.CFLReturn4 = ""
        Me.FileName.CFLShowLoad = False
        Me.FileName.ChangeFormStatus = False
        Me.FileName.ColumnKey = False
        Me.FileName.ComboLine = 5
        Me.FileName.CopyFromItem = ""
        Me.FileName.DefaultButtonClick = False
        Me.FileName.Digit = False
        Me.FileName.FieldType = "C"
        Me.FileName.FieldView = "FileName"
        Me.FileName.FormList = False
        Me.FileName.KeyInsert = ""
        Me.FileName.LocalDecimal = False
        Me.FileName.Name = "FileName"
        Me.FileName.NoUpdate = ""
        Me.FileName.NumberDecimal = 0
        Me.FileName.OptionsColumn.ReadOnly = True
        Me.FileName.ParentControl = ""
        Me.FileName.RefreshSource = False
        Me.FileName.Required = False
        Me.FileName.ShowDataTime = False
        Me.FileName.SQLString = ""
        Me.FileName.UpdateIfNull = ""
        Me.FileName.UpdateWhenFormLock = False
        Me.FileName.Visible = True
        Me.FileName.VisibleIndex = 1
        Me.FileName.Width = 200
        '
        'PathFile
        '
        Me.PathFile.AllowInsert = True
        Me.PathFile.AllowUpdate = True
        Me.PathFile.Caption = "PathFile"
        Me.PathFile.CFLColumnHide = ""
        Me.PathFile.CFLKeyField = ""
        Me.PathFile.CFLPage = False
        Me.PathFile.CFLReturn0 = ""
        Me.PathFile.CFLReturn1 = ""
        Me.PathFile.CFLReturn2 = ""
        Me.PathFile.CFLReturn3 = ""
        Me.PathFile.CFLReturn4 = ""
        Me.PathFile.CFLShowLoad = False
        Me.PathFile.ChangeFormStatus = True
        Me.PathFile.ColumnKey = False
        Me.PathFile.ComboLine = 5
        Me.PathFile.CopyFromItem = ""
        Me.PathFile.DefaultButtonClick = False
        Me.PathFile.Digit = False
        Me.PathFile.FieldType = "C"
        Me.PathFile.FieldView = "FilePath"
        Me.PathFile.FormList = False
        Me.PathFile.KeyInsert = ""
        Me.PathFile.LocalDecimal = False
        Me.PathFile.Name = "PathFile"
        Me.PathFile.NoUpdate = ""
        Me.PathFile.NumberDecimal = 0
        Me.PathFile.ParentControl = ""
        Me.PathFile.RefreshSource = False
        Me.PathFile.Required = False
        Me.PathFile.ShowDataTime = False
        Me.PathFile.SQLString = ""
        Me.PathFile.UpdateIfNull = ""
        Me.PathFile.UpdateWhenFormLock = False
        Me.PathFile.Visible = True
        '
        'FullVersion
        '
        Me.FullVersion.AllowInsert = True
        Me.FullVersion.AllowUpdate = True
        Me.FullVersion.Caption = "Phiên bản"
        Me.FullVersion.CFLColumnHide = ""
        Me.FullVersion.CFLKeyField = ""
        Me.FullVersion.CFLPage = False
        Me.FullVersion.CFLReturn0 = ""
        Me.FullVersion.CFLReturn1 = ""
        Me.FullVersion.CFLReturn2 = ""
        Me.FullVersion.CFLReturn3 = ""
        Me.FullVersion.CFLReturn4 = ""
        Me.FullVersion.CFLShowLoad = False
        Me.FullVersion.ChangeFormStatus = True
        Me.FullVersion.ColumnKey = False
        Me.FullVersion.ComboLine = 5
        Me.FullVersion.CopyFromItem = ""
        Me.FullVersion.DefaultButtonClick = False
        Me.FullVersion.Digit = False
        Me.FullVersion.FieldType = "C"
        Me.FullVersion.FieldView = "FullVersion"
        Me.FullVersion.FormList = False
        Me.FullVersion.KeyInsert = ""
        Me.FullVersion.LocalDecimal = False
        Me.FullVersion.Name = "FullVersion"
        Me.FullVersion.NoUpdate = ""
        Me.FullVersion.NumberDecimal = 0
        Me.FullVersion.OptionsColumn.ReadOnly = True
        Me.FullVersion.ParentControl = ""
        Me.FullVersion.RefreshSource = False
        Me.FullVersion.Required = False
        Me.FullVersion.ShowDataTime = False
        Me.FullVersion.SQLString = ""
        Me.FullVersion.UpdateIfNull = ""
        Me.FullVersion.UpdateWhenFormLock = False
        Me.FullVersion.Visible = True
        Me.FullVersion.VisibleIndex = 2
        '
        'FileMajor
        '
        Me.FileMajor.AllowInsert = True
        Me.FileMajor.AllowUpdate = True
        Me.FileMajor.Caption = "FileMajor"
        Me.FileMajor.CFLColumnHide = ""
        Me.FileMajor.CFLKeyField = ""
        Me.FileMajor.CFLPage = False
        Me.FileMajor.CFLReturn0 = ""
        Me.FileMajor.CFLReturn1 = ""
        Me.FileMajor.CFLReturn2 = ""
        Me.FileMajor.CFLReturn3 = ""
        Me.FileMajor.CFLReturn4 = ""
        Me.FileMajor.CFLShowLoad = False
        Me.FileMajor.ChangeFormStatus = True
        Me.FileMajor.ColumnKey = False
        Me.FileMajor.ComboLine = 5
        Me.FileMajor.CopyFromItem = ""
        Me.FileMajor.DefaultButtonClick = False
        Me.FileMajor.Digit = False
        Me.FileMajor.FieldType = "N"
        Me.FileMajor.FieldView = "FileMajor"
        Me.FileMajor.FormList = False
        Me.FileMajor.KeyInsert = ""
        Me.FileMajor.LocalDecimal = False
        Me.FileMajor.Name = "FileMajor"
        Me.FileMajor.NoUpdate = ""
        Me.FileMajor.NumberDecimal = 0
        Me.FileMajor.ParentControl = ""
        Me.FileMajor.RefreshSource = False
        Me.FileMajor.Required = False
        Me.FileMajor.ShowDataTime = False
        Me.FileMajor.SQLString = ""
        Me.FileMajor.UpdateIfNull = ""
        Me.FileMajor.UpdateWhenFormLock = False
        '
        'FileMinor
        '
        Me.FileMinor.AllowInsert = True
        Me.FileMinor.AllowUpdate = True
        Me.FileMinor.Caption = "FileMinor"
        Me.FileMinor.CFLColumnHide = ""
        Me.FileMinor.CFLKeyField = ""
        Me.FileMinor.CFLPage = False
        Me.FileMinor.CFLReturn0 = ""
        Me.FileMinor.CFLReturn1 = ""
        Me.FileMinor.CFLReturn2 = ""
        Me.FileMinor.CFLReturn3 = ""
        Me.FileMinor.CFLReturn4 = ""
        Me.FileMinor.CFLShowLoad = False
        Me.FileMinor.ChangeFormStatus = True
        Me.FileMinor.ColumnKey = False
        Me.FileMinor.ComboLine = 5
        Me.FileMinor.CopyFromItem = ""
        Me.FileMinor.DefaultButtonClick = False
        Me.FileMinor.Digit = False
        Me.FileMinor.FieldType = "N"
        Me.FileMinor.FieldView = "FileMinor"
        Me.FileMinor.FormList = False
        Me.FileMinor.KeyInsert = ""
        Me.FileMinor.LocalDecimal = False
        Me.FileMinor.Name = "FileMinor"
        Me.FileMinor.NoUpdate = ""
        Me.FileMinor.NumberDecimal = 0
        Me.FileMinor.ParentControl = ""
        Me.FileMinor.RefreshSource = False
        Me.FileMinor.Required = False
        Me.FileMinor.ShowDataTime = False
        Me.FileMinor.SQLString = ""
        Me.FileMinor.UpdateIfNull = ""
        Me.FileMinor.UpdateWhenFormLock = False
        '
        'FileBuild
        '
        Me.FileBuild.AllowInsert = True
        Me.FileBuild.AllowUpdate = True
        Me.FileBuild.Caption = "FileBuild"
        Me.FileBuild.CFLColumnHide = ""
        Me.FileBuild.CFLKeyField = ""
        Me.FileBuild.CFLPage = False
        Me.FileBuild.CFLReturn0 = ""
        Me.FileBuild.CFLReturn1 = ""
        Me.FileBuild.CFLReturn2 = ""
        Me.FileBuild.CFLReturn3 = ""
        Me.FileBuild.CFLReturn4 = ""
        Me.FileBuild.CFLShowLoad = False
        Me.FileBuild.ChangeFormStatus = True
        Me.FileBuild.ColumnKey = False
        Me.FileBuild.ComboLine = 5
        Me.FileBuild.CopyFromItem = ""
        Me.FileBuild.DefaultButtonClick = False
        Me.FileBuild.Digit = False
        Me.FileBuild.FieldType = "N"
        Me.FileBuild.FieldView = "FileBuild"
        Me.FileBuild.FormList = False
        Me.FileBuild.KeyInsert = ""
        Me.FileBuild.LocalDecimal = False
        Me.FileBuild.Name = "FileBuild"
        Me.FileBuild.NoUpdate = ""
        Me.FileBuild.NumberDecimal = 0
        Me.FileBuild.ParentControl = ""
        Me.FileBuild.RefreshSource = False
        Me.FileBuild.Required = False
        Me.FileBuild.ShowDataTime = False
        Me.FileBuild.SQLString = ""
        Me.FileBuild.UpdateIfNull = ""
        Me.FileBuild.UpdateWhenFormLock = False
        '
        'FileRevision
        '
        Me.FileRevision.AllowInsert = True
        Me.FileRevision.AllowUpdate = True
        Me.FileRevision.Caption = "FileRevision"
        Me.FileRevision.CFLColumnHide = ""
        Me.FileRevision.CFLKeyField = ""
        Me.FileRevision.CFLPage = False
        Me.FileRevision.CFLReturn0 = ""
        Me.FileRevision.CFLReturn1 = ""
        Me.FileRevision.CFLReturn2 = ""
        Me.FileRevision.CFLReturn3 = ""
        Me.FileRevision.CFLReturn4 = ""
        Me.FileRevision.CFLShowLoad = False
        Me.FileRevision.ChangeFormStatus = True
        Me.FileRevision.ColumnKey = False
        Me.FileRevision.ComboLine = 5
        Me.FileRevision.CopyFromItem = ""
        Me.FileRevision.DefaultButtonClick = False
        Me.FileRevision.Digit = False
        Me.FileRevision.FieldType = "N"
        Me.FileRevision.FieldView = "FileRevision"
        Me.FileRevision.FormList = False
        Me.FileRevision.KeyInsert = ""
        Me.FileRevision.LocalDecimal = False
        Me.FileRevision.Name = "FileRevision"
        Me.FileRevision.NoUpdate = ""
        Me.FileRevision.NumberDecimal = 0
        Me.FileRevision.ParentControl = ""
        Me.FileRevision.RefreshSource = False
        Me.FileRevision.Required = False
        Me.FileRevision.ShowDataTime = False
        Me.FileRevision.SQLString = ""
        Me.FileRevision.UpdateIfNull = ""
        Me.FileRevision.UpdateWhenFormLock = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(358, 25)
        Me.ToolStrip2.TabIndex = 469
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripButton1.Text = "&1. Thực hiện"
        '
        'FrmUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 411)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.Name = "FrmUpdate"
        Me.Text = "Cập nhật phiên bản"
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents X As U_TextBox.GridColumn
    Friend WithEvents FileName As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PathFile As U_TextBox.GridColumn
    Friend WithEvents FullVersion As U_TextBox.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FileMajor As U_TextBox.GridColumn
    Friend WithEvents FileMinor As U_TextBox.GridColumn
    Friend WithEvents FileBuild As U_TextBox.GridColumn
    Friend WithEvents FileRevision As U_TextBox.GridColumn
End Class
