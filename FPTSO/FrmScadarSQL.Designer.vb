<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScadarSQL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmScadarSQL))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableID = New U_TextBox.U_TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayXuat = New U_TextBox.U_DateEdit()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.Client = New U_TextBox.U_ComboboxEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MaVanChuyen = New U_TextBox.U_ComboboxEdit()
        Me.TrueDBGrid2 = New U_TextBox.TrueDBGrid()
        Me.GridView2 = New U_TextBox.GridView()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaVanChuyen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(6, 65)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1267, 534)
        Me.TrueDBGrid1.TabIndex = 1
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
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
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = ""
        Me.GridView1.Where = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(281, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 19)
        Me.Label1.TabIndex = 480
        Me.Label1.Text = "Số lệnh"
        '
        'TableID
        '
        Me.TableID.AllowInsert = False
        Me.TableID.AllowUpdate = False
        Me.TableID.AutoKeyFix = ""
        Me.TableID.AutoKeyName = ""
        Me.TableID.BindingSourceName = ""
        Me.TableID.ChangeFormStatus = False
        Me.TableID.CopyFromItem = ""
        Me.TableID.DefaultValue = ""
        Me.TableID.FieldName = ""
        Me.TableID.FieldType = "C"
        Me.TableID.KeyInsert = "Y"
        Me.TableID.LinkLabel = ""
        Me.TableID.Location = New System.Drawing.Point(352, 25)
        Me.TableID.Name = "TableID"
        Me.TableID.NoUpdate = "N"
        Me.TableID.PrimaryKey = ""
        Me.TableID.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableID.Properties.Appearance.Options.UseFont = True
        Me.TableID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TableID.Properties.AppearanceFocused.Options.UseFont = True
        Me.TableID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TableID.Properties.AutoHeight = False
        Me.TableID.Properties.MaxLength = 10
        Me.TableID.Required = ""
        Me.TableID.Size = New System.Drawing.Size(137, 26)
        Me.TableID.TabIndex = 479
        Me.TableID.TableName = ""
        Me.TableID.UpdateIfNull = "N"
        Me.TableID.UpdateWhenFormLock = False
        Me.TableID.UpperValue = False
        Me.TableID.ViewName = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1279, 25)
        Me.ToolStrip1.TabIndex = 478
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
        Me.ToolStripButton2.Text = "&1. Làm mới"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 19)
        Me.Label2.TabIndex = 477
        Me.Label2.Text = "Ngày xuất"
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = False
        Me.NgayXuat.AllowUpdate = False
        Me.NgayXuat.BindingSourceName = ""
        Me.NgayXuat.ChangeFormStatus = False
        Me.NgayXuat.CopyFromItem = ""
        Me.NgayXuat.DefaultValue = ""
        Me.NgayXuat.EditValue = Nothing
        Me.NgayXuat.FieldName = ""
        Me.NgayXuat.FieldType = "D"
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LinkLabel = ""
        Me.NgayXuat.Location = New System.Drawing.Point(137, 25)
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.PrimaryKey = ""
        Me.NgayXuat.Properties.AutoHeight = False
        Me.NgayXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayXuat.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayXuat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayXuat.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayXuat.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayXuat.Required = "Y"
        Me.NgayXuat.ShowDateTime = False
        Me.NgayXuat.Size = New System.Drawing.Size(137, 26)
        Me.NgayXuat.TabIndex = 476
        Me.NgayXuat.TableName = ""
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.ViewName = ""
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.Location = New System.Drawing.Point(1158, 26)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(95, 29)
        Me.SimpleButton7.TabIndex = 481
        Me.SimpleButton7.Text = "&Tìm kiếm"
        '
        'Client
        '
        Me.Client.AllowInsert = True
        Me.Client.AllowUpdate = True
        Me.Client.BindingSourceName = ""
        Me.Client.ChangeFormStatus = True
        Me.Client.CopyFromItem = ""
        Me.Client.DefaultValue = ""
        Me.Client.DisplayField = ""
        Me.Client.FieldName = ""
        Me.Client.FieldType = ""
        Me.Client.ItemValue = ""
        Me.Client.KeyInsert = ""
        Me.Client.LinkLabel = ""
        Me.Client.Location = New System.Drawing.Point(606, 25)
        Me.Client.Name = "Client"
        Me.Client.NoUpdate = ""
        Me.Client.PrimaryKey = ""
        Me.Client.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.Appearance.Options.UseFont = True
        Me.Client.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceDisabled.Options.UseFont = True
        Me.Client.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceFocused.Options.UseFont = True
        Me.Client.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.Client.Properties.AutoHeight = False
        Me.Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Client.Required = ""
        Me.Client.Size = New System.Drawing.Size(144, 30)
        Me.Client.SQL_String = ""
        Me.Client.TabIndex = 482
        Me.Client.TableName = ""
        Me.Client.UpdateIfNull = ""
        Me.Client.UpdateWhenFormLock = False
        Me.Client.ValueField = ""
        Me.Client.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(538, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 19)
        Me.Label3.TabIndex = 483
        Me.Label3.Text = "Loại"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(779, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 19)
        Me.Label4.TabIndex = 485
        Me.Label4.Text = "Loại vận tải"
        '
        'MaVanChuyen
        '
        Me.MaVanChuyen.AllowInsert = True
        Me.MaVanChuyen.AllowUpdate = True
        Me.MaVanChuyen.BindingSourceName = ""
        Me.MaVanChuyen.ChangeFormStatus = True
        Me.MaVanChuyen.CopyFromItem = ""
        Me.MaVanChuyen.DefaultValue = ""
        Me.MaVanChuyen.DisplayField = ""
        Me.MaVanChuyen.FieldName = ""
        Me.MaVanChuyen.FieldType = ""
        Me.MaVanChuyen.ItemValue = ""
        Me.MaVanChuyen.KeyInsert = ""
        Me.MaVanChuyen.LinkLabel = ""
        Me.MaVanChuyen.Location = New System.Drawing.Point(882, 25)
        Me.MaVanChuyen.Name = "MaVanChuyen"
        Me.MaVanChuyen.NoUpdate = ""
        Me.MaVanChuyen.PrimaryKey = ""
        Me.MaVanChuyen.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaVanChuyen.Properties.Appearance.Options.UseFont = True
        Me.MaVanChuyen.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaVanChuyen.Properties.AppearanceDisabled.Options.UseFont = True
        Me.MaVanChuyen.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaVanChuyen.Properties.AppearanceFocused.Options.UseFont = True
        Me.MaVanChuyen.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaVanChuyen.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.MaVanChuyen.Properties.AutoHeight = False
        Me.MaVanChuyen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MaVanChuyen.Required = ""
        Me.MaVanChuyen.Size = New System.Drawing.Size(89, 30)
        Me.MaVanChuyen.SQL_String = ""
        Me.MaVanChuyen.TabIndex = 484
        Me.MaVanChuyen.TableName = ""
        Me.MaVanChuyen.UpdateIfNull = ""
        Me.MaVanChuyen.UpdateWhenFormLock = False
        Me.MaVanChuyen.ValueField = ""
        Me.MaVanChuyen.ViewName = ""
        '
        'TrueDBGrid2
        '
        Me.TrueDBGrid2.DefaultRemove = True
        Me.TrueDBGrid2.Location = New System.Drawing.Point(6, 68)
        Me.TrueDBGrid2.MainView = Me.GridView2
        Me.TrueDBGrid2.Name = "TrueDBGrid2"
        Me.TrueDBGrid2.Size = New System.Drawing.Size(1267, 534)
        Me.TrueDBGrid2.TabIndex = 486
        Me.TrueDBGrid2.UseEmbeddedNavigator = True
        Me.TrueDBGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        Me.TrueDBGrid2.Visible = False
        '
        'GridView2
        '
        Me.GridView2.AllowInsert = False
        Me.GridView2.CheckUpd = True
        Me.GridView2.ColumnAutoWidth = False
        Me.GridView2.ColumnKey = ""
        Me.GridView2.ColumnKeyIns = True
        Me.GridView2.ColumnKeyType = "N"
        Me.GridView2.CompanyCode = ""
        Me.GridView2.DefaultRemove = True
        Me.GridView2.GetB1 = False
        Me.GridView2.GridControl = Me.TrueDBGrid2
        Me.GridView2.LastQuery = ""
        Me.GridView2.Name = "GridView2"
        Me.GridView2.ObjectChild = False
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OrderBy = ""
        Me.GridView2.ParentItem = Nothing
        Me.GridView2.RowNumber = ""
        Me.GridView2.TableName = ""
        Me.GridView2.ViewName = ""
        Me.GridView2.Where = Nothing
        '
        'FrmScadarSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1279, 611)
        Me.Controls.Add(Me.TrueDBGrid2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MaVanChuyen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Client)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableID)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayXuat)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.MaximizeBox = False
        Me.Name = "FrmScadarSQL"
        Me.Text = "FrmScadarSQL"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.NgayXuat, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.TableID, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.Client, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.MaVanChuyen, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaVanChuyen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableID As U_TextBox.U_TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayXuat As U_TextBox.U_DateEdit
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Client As U_TextBox.U_ComboboxEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MaVanChuyen As U_TextBox.U_ComboboxEdit
    Friend WithEvents TrueDBGrid2 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView2 As U_TextBox.GridView
End Class
