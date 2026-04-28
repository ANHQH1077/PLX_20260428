<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmATG_Exp
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
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Client = New U_TextBox.U_ButtonEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FromDate = New U_TextBox.U_DateEdit()
        Me.PurposeName = New U_TextBox.U_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PurposeCode = New U_TextBox.U_ButtonEdit()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus()
        Me.U_ButtonCus2 = New U_TextBox.U_ButtonCus()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DocEntry = New U_TextBox.U_NumericEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToDate = New U_TextBox.U_DateEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurposeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurposeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocEntry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 71)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1117, 425)
        Me.TrueDBGrid1.TabIndex = 2
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 19)
        Me.Label1.TabIndex = 494
        Me.Label1.Text = "Kho"
        '
        'Client
        '
        Me.Client.AllowInsert = True
        Me.Client.AllowUpdate = True
        Me.Client.AutoWidth = False
        Me.Client.BindingSourceName = ""
        Me.Client.ChangeFormStatus = True
        Me.Client.CopyFromItem = ""
        Me.Client.DefaultButtonClick = True
        Me.Client.DefaultValue = ""
        Me.Client.FieldName = ""
        Me.Client.FieldType = "C"
        Me.Client.FormList = True
        Me.Client.ItemReturn1 = ""
        Me.Client.ItemReturn2 = ""
        Me.Client.ItemReturn3 = ""
        Me.Client.KeyInsert = ""
        Me.Client.LinkLabel = ""
        Me.Client.Location = New System.Drawing.Point(115, 35)
        Me.Client.MultiSelect = False
        Me.Client.Name = "Client"
        Me.Client.NoUpdate = "N"
        Me.Client.OrderbyEx = ""
        Me.Client.PrimaryKey = ""
        Me.Client.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.Appearance.Options.UseFont = True
        Me.Client.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceDisabled.Options.UseFont = True
        Me.Client.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceFocused.Options.UseFont = True
        Me.Client.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Client.Required = ""
        Me.Client.ShowLoad = True
        Me.Client.Size = New System.Drawing.Size(83, 26)
        Me.Client.SqlFielKey = "Kho"
        Me.Client.SqlString = ""
        Me.Client.TabIndex = 0
        Me.Client.TableName = ""
        Me.Client.UpdateIfNull = ""
        Me.Client.UpdateWhenFormLock = False
        Me.Client.UpperValue = True
        Me.Client.ValidateValue = False
        Me.Client.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(204, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 498
        Me.Label2.Text = "Từ ngày"
        '
        'FromDate
        '
        Me.FromDate.AllowInsert = True
        Me.FromDate.AllowUpdate = True
        Me.FromDate.BindingSourceName = ""
        Me.FromDate.ChangeFormStatus = True
        Me.FromDate.CopyFromItem = ""
        Me.FromDate.DefaultValue = ""
        Me.FromDate.EditValue = Nothing
        Me.FromDate.FieldName = ""
        Me.FromDate.FieldType = "D"
        Me.FromDate.KeyInsert = ""
        Me.FromDate.LinkLabel = "Label2"
        Me.FromDate.Location = New System.Drawing.Point(305, 35)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.NoUpdate = ""
        Me.FromDate.PrimaryKey = ""
        Me.FromDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromDate.Properties.Appearance.Options.UseFont = True
        Me.FromDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.FromDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.FromDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.FromDate.Properties.AutoHeight = False
        Me.FromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromDate.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss"
        Me.FromDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FromDate.Required = "Y"
        Me.FromDate.ShowDateTime = False
        Me.FromDate.Size = New System.Drawing.Size(253, 26)
        Me.FromDate.TabIndex = 2
        Me.FromDate.TableName = ""
        Me.FromDate.TabStop = False
        Me.FromDate.UpdateIfNull = ""
        Me.FromDate.UpdateWhenFormLock = False
        Me.FromDate.ViewName = ""
        '
        'PurposeName
        '
        Me.PurposeName.AllowInsert = False
        Me.PurposeName.AllowUpdate = False
        Me.PurposeName.AutoKeyFix = ""
        Me.PurposeName.AutoKeyName = ""
        Me.PurposeName.BindingSourceName = ""
        Me.PurposeName.ChangeFormStatus = False
        Me.PurposeName.CopyFromItem = ""
        Me.PurposeName.DefaultValue = ""
        Me.PurposeName.FieldName = ""
        Me.PurposeName.FieldType = "C"
        Me.PurposeName.KeyInsert = ""
        Me.PurposeName.LinkLabel = ""
        Me.PurposeName.Location = New System.Drawing.Point(368, 3)
        Me.PurposeName.Name = "PurposeName"
        Me.PurposeName.NoUpdate = "N"
        Me.PurposeName.PrimaryKey = ""
        Me.PurposeName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.PurposeName.Properties.Appearance.Options.UseFont = True
        Me.PurposeName.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.PurposeName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.PurposeName.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.PurposeName.Properties.AppearanceFocused.Options.UseFont = True
        Me.PurposeName.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.PurposeName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.PurposeName.Properties.AutoHeight = False
        Me.PurposeName.Properties.ReadOnly = True
        Me.PurposeName.Required = ""
        Me.PurposeName.Size = New System.Drawing.Size(244, 26)
        Me.PurposeName.TabIndex = 501
        Me.PurposeName.TableName = ""
        Me.PurposeName.UpdateIfNull = ""
        Me.PurposeName.UpdateWhenFormLock = False
        Me.PurposeName.UpperValue = False
        Me.PurposeName.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(204, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 19)
        Me.Label3.TabIndex = 500
        Me.Label3.Text = "Mục đích đo"
        '
        'PurposeCode
        '
        Me.PurposeCode.AllowInsert = False
        Me.PurposeCode.AllowUpdate = False
        Me.PurposeCode.AutoWidth = False
        Me.PurposeCode.BindingSourceName = ""
        Me.PurposeCode.ChangeFormStatus = False
        Me.PurposeCode.CopyFromItem = ""
        Me.PurposeCode.DefaultButtonClick = True
        Me.PurposeCode.DefaultValue = ""
        Me.PurposeCode.FieldName = ""
        Me.PurposeCode.FieldType = "C"
        Me.PurposeCode.FormList = False
        Me.PurposeCode.ItemReturn1 = "PurposeName"
        Me.PurposeCode.ItemReturn2 = ""
        Me.PurposeCode.ItemReturn3 = ""
        Me.PurposeCode.KeyInsert = ""
        Me.PurposeCode.LinkLabel = ""
        Me.PurposeCode.Location = New System.Drawing.Point(305, 3)
        Me.PurposeCode.MultiSelect = False
        Me.PurposeCode.Name = "PurposeCode"
        Me.PurposeCode.NoUpdate = "N"
        Me.PurposeCode.OrderbyEx = ""
        Me.PurposeCode.PrimaryKey = ""
        Me.PurposeCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.PurposeCode.Properties.Appearance.Options.UseFont = True
        Me.PurposeCode.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.PurposeCode.Properties.AppearanceDisabled.Options.UseFont = True
        Me.PurposeCode.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.PurposeCode.Properties.AppearanceFocused.Options.UseFont = True
        Me.PurposeCode.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.PurposeCode.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.PurposeCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.PurposeCode.Required = ""
        Me.PurposeCode.ShowLoad = True
        Me.PurposeCode.Size = New System.Drawing.Size(57, 26)
        Me.PurposeCode.SqlFielKey = "Code"
        Me.PurposeCode.SqlString = "SELECT[Code] ,[Name] FROM [zPurpose] where isnull([Status],'Y') ='Y'"
        Me.PurposeCode.TabIndex = 3
        Me.PurposeCode.TableName = ""
        Me.PurposeCode.UpdateIfNull = ""
        Me.PurposeCode.UpdateWhenFormLock = False
        Me.PurposeCode.UpperValue = True
        Me.PurposeCode.ValidateValue = True
        Me.PurposeCode.ViewName = ""
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(813, 3)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(99, 23)
        Me.U_ButtonCus1.TabIndex = 502
        Me.U_ButtonCus1.Text = "Tìm kiếm"
        '
        'U_ButtonCus2
        '
        Me.U_ButtonCus2.DefaultUpdate = True
        Me.U_ButtonCus2.EnableWhenFormLock = False
        Me.U_ButtonCus2.Location = New System.Drawing.Point(917, 3)
        Me.U_ButtonCus2.Name = "U_ButtonCus2"
        Me.U_ButtonCus2.Size = New System.Drawing.Size(99, 23)
        Me.U_ButtonCus2.TabIndex = 503
        Me.U_ButtonCus2.Text = "Export excel"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 19)
        Me.Label4.TabIndex = 505
        Me.Label4.Text = "Số giao dịch"
        '
        'DocEntry
        '
        Me.DocEntry.AllowInsert = False
        Me.DocEntry.AllowUpdate = False
        Me.DocEntry.AutoKeyFix = ""
        Me.DocEntry.AutoKeyName = ""
        Me.DocEntry.BindingSourceName = ""
        Me.DocEntry.ChangeFormStatus = True
        Me.DocEntry.CopyFromItem = ""
        Me.DocEntry.DefaultValue = ""
        Me.DocEntry.Digit = True
        Me.DocEntry.FieldName = "DocEntry"
        Me.DocEntry.FieldType = "N"
        Me.DocEntry.KeyInsert = ""
        Me.DocEntry.LinkLabel = "Label4"
        Me.DocEntry.LocalDecimal = False
        Me.DocEntry.Location = New System.Drawing.Point(115, 3)
        Me.DocEntry.Name = "DocEntry"
        Me.DocEntry.NoUpdate = ""
        Me.DocEntry.NumberDecimal = 0
        Me.DocEntry.PrimaryKey = ""
        Me.DocEntry.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DocEntry.Properties.Appearance.Options.UseFont = True
        Me.DocEntry.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DocEntry.Properties.AppearanceDisabled.Options.UseFont = True
        Me.DocEntry.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DocEntry.Properties.AppearanceFocused.Options.UseFont = True
        Me.DocEntry.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DocEntry.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.DocEntry.Properties.AutoHeight = False
        Me.DocEntry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocEntry.Required = ""
        Me.DocEntry.ShowCalc = True
        Me.DocEntry.Size = New System.Drawing.Size(83, 26)
        Me.DocEntry.TabIndex = 504
        Me.DocEntry.TableName = ""
        Me.DocEntry.TabStop = False
        Me.DocEntry.UpdateIfNull = ""
        Me.DocEntry.UpdateWhenFormLock = False
        Me.DocEntry.ViewName = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(572, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 19)
        Me.Label5.TabIndex = 507
        Me.Label5.Text = "Đến ngày"
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = True
        Me.ToDate.AllowUpdate = True
        Me.ToDate.BindingSourceName = ""
        Me.ToDate.ChangeFormStatus = True
        Me.ToDate.CopyFromItem = ""
        Me.ToDate.DefaultValue = ""
        Me.ToDate.EditValue = Nothing
        Me.ToDate.FieldName = ""
        Me.ToDate.FieldType = "D"
        Me.ToDate.KeyInsert = ""
        Me.ToDate.LinkLabel = "Label2"
        Me.ToDate.Location = New System.Drawing.Point(673, 36)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.NoUpdate = ""
        Me.ToDate.PrimaryKey = ""
        Me.ToDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToDate.Properties.Appearance.Options.UseFont = True
        Me.ToDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ToDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.ToDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ToDate.Properties.AutoHeight = False
        Me.ToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.ToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToDate.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss"
        Me.ToDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ToDate.Required = "Y"
        Me.ToDate.ShowDateTime = False
        Me.ToDate.Size = New System.Drawing.Size(239, 26)
        Me.ToDate.TabIndex = 506
        Me.ToDate.TableName = ""
        Me.ToDate.TabStop = False
        Me.ToDate.UpdateIfNull = ""
        Me.ToDate.UpdateWhenFormLock = False
        Me.ToDate.ViewName = ""
        '
        'FrmATG_Exp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 496)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DocEntry)
        Me.Controls.Add(Me.U_ButtonCus2)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.PurposeName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PurposeCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Client)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmATG_Exp"
        Me.Text = "Thông tin TGĐB vào SAP"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.Client, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.FromDate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.PurposeCode, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.PurposeName, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus2, 0)
        Me.Controls.SetChildIndex(Me.DocEntry, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.ToDate, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurposeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurposeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocEntry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Client As U_TextBox.U_ButtonEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FromDate As U_TextBox.U_DateEdit
    Friend WithEvents PurposeName As U_TextBox.U_TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PurposeCode As U_TextBox.U_ButtonEdit
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents U_ButtonCus2 As U_TextBox.U_ButtonCus
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DocEntry As U_TextBox.U_NumericEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToDate As U_TextBox.U_DateEdit
End Class
