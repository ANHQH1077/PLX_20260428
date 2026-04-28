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
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ID = New U_TextBox.GridColumn()
        Me.Code = New U_TextBox.GridColumn()
        Me.cName = New U_TextBox.GridColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
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
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(477, 377)
        Me.TrueDBGrid1.TabIndex = 2
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.Code, Me.cName})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "Code"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "zPurpose"
        Me.GridView1.Where = Nothing
        '
        'ID
        '
        Me.ID.AllowInsert = True
        Me.ID.AllowUpdate = True
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
        '
        'Name
        '
        Me.cName.AllowInsert = True
        Me.cName.AllowUpdate = True
        Me.cName.ButtonClick = True
        Me.cName.Caption = "Mục đích đo"
        Me.cName.CFLColumnHide = ""
        Me.cName.CFLKeyField = ""
        Me.cName.CFLPage = False
        Me.cName.CFLReturn0 = ""
        Me.cName.CFLReturn1 = ""
        Me.cName.CFLReturn2 = ""
        Me.cName.CFLReturn3 = ""
        Me.cName.CFLReturn4 = ""
        Me.cName.CFLReturn5 = ""
        Me.cName.CFLReturn6 = ""
        Me.cName.CFLReturn7 = ""
        Me.cName.CFLShowLoad = False
        Me.cName.ChangeFormStatus = True
        Me.cName.ColumnKey = False
        Me.cName.ComboLine = 5
        Me.cName.CopyFromItem = ""
        Me.cName.DefaultButtonClick = False
        Me.cName.Digit = False
        Me.cName.FieldType = "C"
        Me.cName.FieldView = "Name"
        Me.cName.FormarNumber = True
        Me.cName.FormList = False
        Me.cName.KeyInsert = ""
        Me.cName.LocalDecimal = False
        Me.cName.Name = "Name"
        Me.cName.NoUpdate = ""
        Me.cName.NumberDecimal = 0
        Me.cName.OptionsColumn.ReadOnly = True
        Me.cName.ParentControl = ""
        Me.cName.RefreshSource = False
        Me.cName.Required = False
        Me.cName.SequenceName = ""
        Me.cName.ShowCalc = True
        Me.cName.ShowDataTime = False
        Me.cName.ShowOnlyTime = False
        Me.cName.SQLString = ""
        Me.cName.UpdateIfNull = ""
        Me.cName.UpdateWhenFormLock = False
        Me.cName.ValidateValue = True
        Me.cName.Visible = True
        Me.cName.VisibleIndex = 1
        Me.cName.Width = 360
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(483, 28)
        Me.ToolStrip2.TabIndex = 471
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(153, 25)
        Me.ToolStripButton3.Text = "Rút số liệu từ SAP"
        '
        'FrmPurpose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 414)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultSave = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmPurpose"
        Me.Text = "Thông tin Mục đích đo bể"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
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
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents Code As U_TextBox.GridColumn
    Friend WithEvents cName As U_TextBox.GridColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
End Class
