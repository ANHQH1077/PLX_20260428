<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExport
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FromDate = New U_TextBox.U_DateEdit()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SoLenh = New U_TextBox.U_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToDate = New U_TextBox.U_DateEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 208
        Me.Label2.Text = "Từ ngày"
        '
        'FromDate
        '
        Me.FromDate.AllowInsert = True
        Me.FromDate.AllowUpdate = True
        Me.FromDate.BindingSourceName = ""
        Me.FromDate.ChangeFormStatus = False
        Me.FromDate.CopyFromItem = ""
        Me.FromDate.DefaultValue = ""
        Me.FromDate.EditValue = Nothing
        Me.FromDate.FieldName = ""
        Me.FromDate.FieldType = "D"
        Me.FromDate.KeyInsert = ""
        Me.FromDate.LinkLabel = ""
        Me.FromDate.Location = New System.Drawing.Point(98, 15)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.NoUpdate = ""
        Me.FromDate.PrimaryKey = ""
        Me.FromDate.Properties.AutoHeight = False
        Me.FromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.FromDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FromDate.Required = ""
        Me.FromDate.ShowDateTime = False
        Me.FromDate.Size = New System.Drawing.Size(148, 26)
        Me.FromDate.TabIndex = 0
        Me.FromDate.TableName = ""
        Me.FromDate.UpdateIfNull = ""
        Me.FromDate.UpdateWhenFormLock = False
        Me.FromDate.ViewName = ""
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.Location = New System.Drawing.Point(772, 15)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(90, 26)
        Me.SimpleButton7.TabIndex = 3
        Me.SimpleButton7.Text = "&Tìm kiếm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(511, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 19)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "Số lệnh"
        '
        'SoLenh
        '
        Me.SoLenh.AllowInsert = True
        Me.SoLenh.AllowUpdate = True
        Me.SoLenh.AutoKeyFix = ""
        Me.SoLenh.AutoKeyName = ""
        Me.SoLenh.BindingSourceName = ""
        Me.SoLenh.ChangeFormStatus = False
        Me.SoLenh.CopyFromItem = ""
        Me.SoLenh.DefaultValue = ""
        Me.SoLenh.FieldName = ""
        Me.SoLenh.FieldType = ""
        Me.SoLenh.KeyInsert = ""
        Me.SoLenh.LinkLabel = ""
        Me.SoLenh.Location = New System.Drawing.Point(596, 15)
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = "N"
        Me.SoLenh.PrimaryKey = ""
        Me.SoLenh.Properties.AutoHeight = False
        Me.SoLenh.Properties.MaxLength = 10
        Me.SoLenh.Required = ""
        Me.SoLenh.Size = New System.Drawing.Size(148, 26)
        Me.SoLenh.TabIndex = 2
        Me.SoLenh.TableName = ""
        Me.SoLenh.UpdateIfNull = ""
        Me.SoLenh.UpdateWhenFormLock = False
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(252, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 210
        Me.Label3.Text = "Đến ngày"
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = True
        Me.ToDate.AllowUpdate = True
        Me.ToDate.BindingSourceName = ""
        Me.ToDate.ChangeFormStatus = False
        Me.ToDate.CopyFromItem = ""
        Me.ToDate.DefaultValue = ""
        Me.ToDate.EditValue = Nothing
        Me.ToDate.FieldName = ""
        Me.ToDate.FieldType = "D"
        Me.ToDate.KeyInsert = ""
        Me.ToDate.LinkLabel = ""
        Me.ToDate.Location = New System.Drawing.Point(341, 15)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.NoUpdate = ""
        Me.ToDate.PrimaryKey = ""
        Me.ToDate.Properties.AutoHeight = False
        Me.ToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.ToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.ToDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ToDate.Required = ""
        Me.ToDate.ShowDateTime = False
        Me.ToDate.Size = New System.Drawing.Size(148, 26)
        Me.ToDate.TabIndex = 1
        Me.ToDate.TableName = ""
        Me.ToDate.UpdateIfNull = ""
        Me.ToDate.UpdateWhenFormLock = False
        Me.ToDate.ViewName = ""
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Location = New System.Drawing.Point(880, 15)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(116, 26)
        Me.SimpleButton1.TabIndex = 211
        Me.SimpleButton1.Text = "Xuất &ra excel"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 47)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1159, 560)
        Me.TrueDBGrid1.TabIndex = 212
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsPrint.PrintPreview = True
        '
        'FrmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1164, 611)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SoLenh)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.Name = "FrmExport"
        Me.Text = "Kiết xuất lệnh ra excel"
        Me.Controls.SetChildIndex(Me.SoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.FromDate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.ToDate, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton1, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FromDate As U_TextBox.U_DateEdit
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SoLenh As U_TextBox.U_TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToDate As U_TextBox.U_DateEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
