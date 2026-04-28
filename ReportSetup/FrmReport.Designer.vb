<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReport))
        Me.CReportCode = New System.Windows.Forms.Label()
        Me.ReportCode = New U_TextBox.U_ButtonEdit()
        Me.ReportName = New U_TextBox.U_TextBox()
        Me.CmdReport = New U_TextBox.U_ButtonCus(Me.components)
        Me.cmdRun = New U_TextBox.U_ButtonCus(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.GridView1 = New U_TextBox.GridView()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CReportCode
        '
        Me.CReportCode.AutoSize = True
        Me.CReportCode.Location = New System.Drawing.Point(12, 32)
        Me.CReportCode.Name = "CReportCode"
        Me.CReportCode.Size = New System.Drawing.Size(45, 13)
        Me.CReportCode.TabIndex = 423
        Me.CReportCode.Text = "Báo cáo"
        '
        'ReportCode
        '
        Me.ReportCode.AllowInsert = True
        Me.ReportCode.AllowUpdate = True
        Me.ReportCode.BindingSourceName = ""
        Me.ReportCode.ChangeFormStatus = False
        Me.ReportCode.CopyFromItem = ""
        Me.ReportCode.DefaultButtonClick = True
        Me.ReportCode.DefaultValue = ""
        Me.ReportCode.FieldName = ""
        Me.ReportCode.FieldType = ""
        Me.ReportCode.FormList = False
        Me.ReportCode.ItemReturn1 = "ReportName"
        Me.ReportCode.ItemReturn2 = ""
        Me.ReportCode.ItemReturn3 = ""
        Me.ReportCode.KeyInsert = ""
        Me.ReportCode.LinkLabel = "CReportCode"
        Me.ReportCode.Location = New System.Drawing.Point(63, 29)
        Me.ReportCode.MultiSelect = False
        Me.ReportCode.Name = "ReportCode"
        Me.ReportCode.NoUpdate = "N"
        Me.ReportCode.PrimaryKey = ""
        Me.ReportCode.Properties.AutoHeight = False
        Me.ReportCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ReportCode.Required = "Y"
        Me.ReportCode.ShowLoad = True
        Me.ReportCode.Size = New System.Drawing.Size(196, 26)
        Me.ReportCode.SqlFielKey = "STT"
        Me.ReportCode.SqlString = "select ReportCode,ReportName, STT from SYS_CONFIG_RPT where isnull(RptAdmin,'')='" & _
            "'"
        Me.ReportCode.TabIndex = 424
        Me.ReportCode.TableName = ""
        Me.ReportCode.UpdateIfNull = ""
        Me.ReportCode.UpdateWhenFormLock = False
        Me.ReportCode.UpperValue = False
        Me.ReportCode.ValidateValue = True
        Me.ReportCode.ViewName = ""
        '
        'ReportName
        '
        Me.ReportName.AllowInsert = False
        Me.ReportName.AllowUpdate = False
        Me.ReportName.AutoKeyFix = ""
        Me.ReportName.AutoKeyName = ""
        Me.ReportName.BindingSourceName = ""
        Me.ReportName.ChangeFormStatus = False
        Me.ReportName.CopyFromItem = ""
        Me.ReportName.DefaultValue = ""
        Me.ReportName.FieldName = ""
        Me.ReportName.FieldType = "C"
        Me.ReportName.KeyInsert = ""
        Me.ReportName.LinkLabel = ""
        Me.ReportName.Location = New System.Drawing.Point(63, 58)
        Me.ReportName.Name = "ReportName"
        Me.ReportName.NoUpdate = "N"
        Me.ReportName.PrimaryKey = ""
        Me.ReportName.Properties.AutoHeight = False
        Me.ReportName.Properties.ReadOnly = True
        Me.ReportName.Required = ""
        Me.ReportName.Size = New System.Drawing.Size(322, 26)
        Me.ReportName.TabIndex = 425
        Me.ReportName.TableName = ""
        Me.ReportName.UpdateIfNull = ""
        Me.ReportName.UpdateWhenFormLock = False
        Me.ReportName.UpperValue = False
        Me.ReportName.ViewName = ""
        '
        'CmdReport
        '
        Me.CmdReport.DefaultUpdate = True
        Me.CmdReport.Location = New System.Drawing.Point(310, 32)
        Me.CmdReport.Name = "CmdReport"
        Me.CmdReport.Size = New System.Drawing.Size(75, 23)
        Me.CmdReport.TabIndex = 426
        Me.CmdReport.Text = "In &báo cáo"
        '
        'cmdRun
        '
        Me.cmdRun.DefaultUpdate = True
        Me.cmdRun.Location = New System.Drawing.Point(12, 558)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(75, 23)
        Me.cmdRun.TabIndex = 1
        Me.cmdRun.Text = "Xe&m"
        Me.cmdRun.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripButton1.Text = "&2. Xuất ra excel"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(6, 6)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(101, 25)
        Me.ToolStrip2.TabIndex = 469
        Me.ToolStrip2.Text = "ToolStrip2"
        Me.ToolStrip2.Visible = False
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = ""
        Me.GridView1.Where = Nothing
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(392, 23)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(402, 586)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.TrueDBGrid1.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(794, 25)
        Me.ToolStrip1.TabIndex = 470
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "&1. Excel"
        '
        'FrmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(435, 610)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.CmdReport)
        Me.Controls.Add(Me.ReportName)
        Me.Controls.Add(Me.ReportCode)
        Me.Controls.Add(Me.CReportCode)
        Me.Controls.Add(Me.cmdRun)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.MaximizeBox = False
        Me.Name = "FrmReport"
        Me.Text = "Báo cáo"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.cmdRun, 0)
        Me.Controls.SetChildIndex(Me.CReportCode, 0)
        Me.Controls.SetChildIndex(Me.ReportCode, 0)
        Me.Controls.SetChildIndex(Me.ReportName, 0)
        Me.Controls.SetChildIndex(Me.CmdReport, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CReportCode As System.Windows.Forms.Label
    Friend WithEvents ReportCode As U_TextBox.U_ButtonEdit
    Friend WithEvents ReportName As U_TextBox.U_TextBox
    Friend WithEvents CmdReport As U_TextBox.U_ButtonCus
    Friend WithEvents cmdRun As U_TextBox.U_ButtonCus
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
End Class
