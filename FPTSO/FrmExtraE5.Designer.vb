<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExtraE5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmExtraE5))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.VCF = New U_TextBox.U_NumericEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.VCF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 37)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1008, 253)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblLenhXuatChiTietE5"
        Me.GridView1.ViewName = "FPT_tblLenhXuatChiTietE5_V"
        Me.GridView1.Where = Nothing
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1013, 28)
        Me.ToolStrip2.TabIndex = 469
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 25)
        Me.ToolStripButton1.Text = "&1. Lưu"
        '
        'VCF
        '
        Me.VCF.AllowInsert = True
        Me.VCF.AllowUpdate = True
        Me.VCF.AutoKeyFix = ""
        Me.VCF.AutoKeyName = ""
        Me.VCF.BindingSourceName = ""
        Me.VCF.ChangeFormStatus = True
        Me.VCF.CopyFromItem = ""
        Me.VCF.DefaultValue = ""
        Me.VCF.Digit = True
        Me.VCF.FieldName = ""
        Me.VCF.FieldType = "N"
        Me.VCF.KeyInsert = ""
        Me.VCF.LinkLabel = ""
        Me.VCF.LocalDecimal = False
        Me.VCF.Location = New System.Drawing.Point(124, 296)
        Me.VCF.Name = "VCF"
        Me.VCF.NoUpdate = ""
        Me.VCF.NumberDecimal = 0
        Me.VCF.PrimaryKey = ""
        Me.VCF.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.VCF.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.VCF.Properties.AppearanceDisabled.Options.UseFont = True
        Me.VCF.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.VCF.Properties.AppearanceFocused.Options.UseFont = True
        Me.VCF.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.VCF.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.VCF.Properties.AutoHeight = False
        Me.VCF.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.VCF.Properties.ReadOnly = True
        Me.VCF.Required = ""
        Me.VCF.ShowCalc = True
        Me.VCF.Size = New System.Drawing.Size(104, 30)
        Me.VCF.TabIndex = 470
        Me.VCF.TableName = ""
        Me.VCF.UpdateIfNull = ""
        Me.VCF.UpdateWhenFormLock = False
        Me.VCF.ViewName = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 301)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 19)
        Me.Label1.TabIndex = 471
        Me.Label1.Text = "VCF"
        '
        'FrmExtraE5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 359)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.VCF)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmExtraE5"
        Me.ShowFormMessage = True
        Me.Text = "Cập nhật thông tin E5"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.VCF, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.VCF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents VCF As U_TextBox.U_NumericEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
