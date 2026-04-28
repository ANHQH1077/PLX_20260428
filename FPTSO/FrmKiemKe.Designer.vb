<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKiemKe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKiemKe))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdSave = New System.Windows.Forms.ToolStripButton()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ID = New U_TextBox.GridColumn()
        Me.GhiChu = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.NgayGio = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(516, 28)
        Me.ToolStrip1.TabIndex = 470
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdSave
        '
        Me.cmdSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(72, 25)
        Me.cmdSave.Text = "&4. Lưu"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(512, 502)
        Me.TrueDBGrid1.TabIndex = 471
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = True
        Me.GridView1.ColumnKey = "ID"
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.NgayGio, Me.GhiChu, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "NgayGio"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblThoiGianKiemke"
        Me.GridView1.ViewName = "fpt_tblThoiGianKiemke_v"
        Me.GridView1.Where = Nothing
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.ButtonClick = True
        Me.ID.Caption = "GridColumn1"
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
        Me.ID.ColumnKey = True
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
        Me.ID.UpperValue = False
        Me.ID.ValidateValue = True
        '
        'GhiChu
        '
        Me.GhiChu.AllowInsert = True
        Me.GhiChu.AllowUpdate = True
        Me.GhiChu.ButtonClick = True
        Me.GhiChu.Caption = "Ghi chú"
        Me.GhiChu.CFLColumnHide = ""
        Me.GhiChu.CFLKeyField = ""
        Me.GhiChu.CFLPage = False
        Me.GhiChu.CFLReturn0 = ""
        Me.GhiChu.CFLReturn1 = ""
        Me.GhiChu.CFLReturn2 = ""
        Me.GhiChu.CFLReturn3 = ""
        Me.GhiChu.CFLReturn4 = ""
        Me.GhiChu.CFLReturn5 = ""
        Me.GhiChu.CFLReturn6 = ""
        Me.GhiChu.CFLReturn7 = ""
        Me.GhiChu.CFLShowLoad = True
        Me.GhiChu.ChangeFormStatus = True
        Me.GhiChu.ColumnKey = False
        Me.GhiChu.ComboLine = 5
        Me.GhiChu.CopyFromItem = ""
        Me.GhiChu.DefaultButtonClick = True
        Me.GhiChu.Digit = False
        Me.GhiChu.FieldType = "C"
        Me.GhiChu.FieldView = "GhiChu"
        Me.GhiChu.FormarNumber = True
        Me.GhiChu.FormList = False
        Me.GhiChu.KeyInsert = ""
        Me.GhiChu.LocalDecimal = False
        Me.GhiChu.Name = "GhiChu"
        Me.GhiChu.NoUpdate = ""
        Me.GhiChu.NumberDecimal = 0
        Me.GhiChu.ParentControl = ""
        Me.GhiChu.RefreshSource = False
        Me.GhiChu.Required = False
        Me.GhiChu.SequenceName = ""
        Me.GhiChu.ShowCalc = True
        Me.GhiChu.ShowDataTime = False
        Me.GhiChu.ShowOnlyTime = False
        Me.GhiChu.SQLString = ""
        Me.GhiChu.UpdateIfNull = ""
        Me.GhiChu.UpdateWhenFormLock = False
        Me.GhiChu.UpperValue = False
        Me.GhiChu.ValidateValue = True
        Me.GhiChu.Visible = True
        Me.GhiChu.VisibleIndex = 1
        Me.GhiChu.Width = 345
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'NgayGio
        '
        Me.NgayGio.AllowInsert = True
        Me.NgayGio.AllowUpdate = True
        Me.NgayGio.ButtonClick = True
        Me.NgayGio.Caption = "Thời gian kiểm kê"
        Me.NgayGio.CFLColumnHide = ""
        Me.NgayGio.CFLKeyField = ""
        Me.NgayGio.CFLPage = False
        Me.NgayGio.CFLReturn0 = ""
        Me.NgayGio.CFLReturn1 = ""
        Me.NgayGio.CFLReturn2 = ""
        Me.NgayGio.CFLReturn3 = ""
        Me.NgayGio.CFLReturn4 = ""
        Me.NgayGio.CFLReturn5 = ""
        Me.NgayGio.CFLReturn6 = ""
        Me.NgayGio.CFLReturn7 = ""
        Me.NgayGio.CFLShowLoad = False
        Me.NgayGio.ChangeFormStatus = True
        Me.NgayGio.ColumnKey = False
        Me.NgayGio.ComboLine = 5
        Me.NgayGio.CopyFromItem = ""
        Me.NgayGio.DefaultButtonClick = False
        Me.NgayGio.Digit = False
        Me.NgayGio.FieldType = "D"
        Me.NgayGio.FieldView = "NgayGio"
        Me.NgayGio.FormarNumber = True
        Me.NgayGio.FormList = False
        Me.NgayGio.KeyInsert = ""
        Me.NgayGio.LocalDecimal = False
        Me.NgayGio.Name = "NgayGio"
        Me.NgayGio.NoUpdate = ""
        Me.NgayGio.NumberDecimal = 0
        Me.NgayGio.ParentControl = ""
        Me.NgayGio.RefreshSource = False
        Me.NgayGio.Required = False
        Me.NgayGio.SequenceName = ""
        Me.NgayGio.ShowCalc = True
        Me.NgayGio.ShowDataTime = True
        Me.NgayGio.ShowOnlyTime = False
        Me.NgayGio.SQLString = ""
        Me.NgayGio.UpdateIfNull = ""
        Me.NgayGio.UpdateWhenFormLock = False
        Me.NgayGio.UpperValue = False
        Me.NgayGio.ValidateValue = True
        Me.NgayGio.Visible = True
        Me.NgayGio.VisibleIndex = 0
        Me.NgayGio.Width = 130
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.ButtonClick = True
        Me.CHECKUPD.Caption = "GridColumn6"
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
        Me.CHECKUPD.FormarNumber = True
        Me.CHECKUPD.FormList = False
        Me.CHECKUPD.KeyInsert = ""
        Me.CHECKUPD.LocalDecimal = False
        Me.CHECKUPD.Name = "CHECKUPD"
        Me.CHECKUPD.NoUpdate = ""
        Me.CHECKUPD.NumberDecimal = 0
        Me.CHECKUPD.ParentControl = ""
        Me.CHECKUPD.RefreshSource = False
        Me.CHECKUPD.Required = False
        Me.CHECKUPD.SequenceName = ""
        Me.CHECKUPD.ShowCalc = True
        Me.CHECKUPD.ShowDataTime = False
        Me.CHECKUPD.ShowOnlyTime = False
        Me.CHECKUPD.SQLString = ""
        Me.CHECKUPD.UpdateIfNull = ""
        Me.CHECKUPD.UpdateWhenFormLock = False
        Me.CHECKUPD.UpperValue = False
        Me.CHECKUPD.ValidateValue = True
        '
        'FrmKiemKe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 562)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.DefaultSave = False
        Me.Name = "FrmKiemKe"
        Me.Text = "Thời gian kiểm kê"
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents GhiChu As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents NgayGio As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
End Class
