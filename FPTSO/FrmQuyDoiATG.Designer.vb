<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBarem
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
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.KG = New U_TextBox.U_NumericEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.L15 = New U_TextBox.U_NumericEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.VCF = New U_TextBox.U_NumericEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ThucXuat = New U_TextBox.U_NumericEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TyTrong = New U_TextBox.U_NumericEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NhietDo = New U_TextBox.U_NumericEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TankCode = New U_TextBox.U_ButtonEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TankHeight = New U_TextBox.U_NumericEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.MaBe = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.MaHang = New U_TextBox.GridColumn()
        Me.CCaoDau = New U_TextBox.GridColumn()
        Me.cNhietDo = New U_TextBox.GridColumn()
        Me.cTyTrong = New U_TextBox.GridColumn()
        Me.cVCF = New U_TextBox.GridColumn()
        Me.cLtt = New U_TextBox.GridColumn()
        Me.cL15 = New U_TextBox.GridColumn()
        Me.cKg = New U_TextBox.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.L15.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VCF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThucXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TyTrong.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NhietDo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TankCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TankHeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(881, 273)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(109, 27)
        Me.U_ButtonCus1.TabIndex = 461
        Me.U_ButtonCus1.Text = "Thực hiện"
        Me.U_ButtonCus1.Visible = False
        '
        'KG
        '
        Me.KG.AllowInsert = True
        Me.KG.AllowUpdate = True
        Me.KG.AutoKeyFix = ""
        Me.KG.AutoKeyName = ""
        Me.KG.BindingSourceName = ""
        Me.KG.ChangeFormStatus = False
        Me.KG.CopyFromItem = ""
        Me.KG.DefaultValue = ""
        Me.KG.Digit = True
        Me.KG.FieldName = ""
        Me.KG.FieldType = "N"
        Me.KG.KeyInsert = ""
        Me.KG.LinkLabel = ""
        Me.KG.LocalDecimal = False
        Me.KG.Location = New System.Drawing.Point(710, 280)
        Me.KG.Name = "KG"
        Me.KG.NoUpdate = ""
        Me.KG.NumberDecimal = 0
        Me.KG.PrimaryKey = ""
        Me.KG.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.KG.Properties.Appearance.Options.UseFont = True
        Me.KG.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.KG.Properties.AppearanceDisabled.Options.UseFont = True
        Me.KG.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.KG.Properties.AppearanceFocused.Options.UseFont = True
        Me.KG.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.KG.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.KG.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.KG.Properties.ReadOnly = True
        Me.KG.Required = ""
        Me.KG.ShowCalc = True
        Me.KG.Size = New System.Drawing.Size(163, 26)
        Me.KG.TabIndex = 6
        Me.KG.TableName = ""
        Me.KG.UpdateIfNull = ""
        Me.KG.UpdateWhenFormLock = False
        Me.KG.ViewName = ""
        Me.KG.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(596, 283)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 19)
        Me.Label6.TabIndex = 459
        Me.Label6.Text = "Lượng KG"
        Me.Label6.Visible = False
        '
        'L15
        '
        Me.L15.AllowInsert = True
        Me.L15.AllowUpdate = True
        Me.L15.AutoKeyFix = ""
        Me.L15.AutoKeyName = ""
        Me.L15.BindingSourceName = ""
        Me.L15.ChangeFormStatus = False
        Me.L15.CopyFromItem = ""
        Me.L15.DefaultValue = ""
        Me.L15.Digit = True
        Me.L15.FieldName = ""
        Me.L15.FieldType = "N"
        Me.L15.KeyInsert = ""
        Me.L15.LinkLabel = ""
        Me.L15.LocalDecimal = False
        Me.L15.Location = New System.Drawing.Point(710, 248)
        Me.L15.Name = "L15"
        Me.L15.NoUpdate = ""
        Me.L15.NumberDecimal = 0
        Me.L15.PrimaryKey = ""
        Me.L15.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.L15.Properties.Appearance.Options.UseFont = True
        Me.L15.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.L15.Properties.AppearanceDisabled.Options.UseFont = True
        Me.L15.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.L15.Properties.AppearanceFocused.Options.UseFont = True
        Me.L15.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.L15.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.L15.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.L15.Properties.ReadOnly = True
        Me.L15.Required = ""
        Me.L15.ShowCalc = True
        Me.L15.Size = New System.Drawing.Size(163, 26)
        Me.L15.TabIndex = 5
        Me.L15.TableName = ""
        Me.L15.UpdateIfNull = ""
        Me.L15.UpdateWhenFormLock = False
        Me.L15.ViewName = ""
        Me.L15.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(596, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 19)
        Me.Label5.TabIndex = 457
        Me.Label5.Text = "Lượng L15"
        Me.Label5.Visible = False
        '
        'VCF
        '
        Me.VCF.AllowInsert = True
        Me.VCF.AllowUpdate = True
        Me.VCF.AutoKeyFix = ""
        Me.VCF.AutoKeyName = ""
        Me.VCF.BindingSourceName = ""
        Me.VCF.ChangeFormStatus = False
        Me.VCF.CopyFromItem = ""
        Me.VCF.DefaultValue = ""
        Me.VCF.Digit = True
        Me.VCF.FieldName = ""
        Me.VCF.FieldType = "N"
        Me.VCF.KeyInsert = ""
        Me.VCF.LinkLabel = ""
        Me.VCF.LocalDecimal = False
        Me.VCF.Location = New System.Drawing.Point(710, 216)
        Me.VCF.Name = "VCF"
        Me.VCF.NoUpdate = ""
        Me.VCF.NumberDecimal = 0
        Me.VCF.PrimaryKey = ""
        Me.VCF.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.VCF.Properties.Appearance.Options.UseFont = True
        Me.VCF.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.VCF.Properties.AppearanceDisabled.Options.UseFont = True
        Me.VCF.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.VCF.Properties.AppearanceFocused.Options.UseFont = True
        Me.VCF.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.VCF.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.VCF.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.VCF.Properties.ReadOnly = True
        Me.VCF.Required = ""
        Me.VCF.ShowCalc = True
        Me.VCF.Size = New System.Drawing.Size(163, 26)
        Me.VCF.TabIndex = 4
        Me.VCF.TableName = ""
        Me.VCF.UpdateIfNull = ""
        Me.VCF.UpdateWhenFormLock = False
        Me.VCF.ViewName = ""
        Me.VCF.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(596, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 19)
        Me.Label4.TabIndex = 455
        Me.Label4.Text = "VCF"
        Me.Label4.Visible = False
        '
        'ThucXuat
        '
        Me.ThucXuat.AllowInsert = True
        Me.ThucXuat.AllowUpdate = True
        Me.ThucXuat.AutoKeyFix = ""
        Me.ThucXuat.AutoKeyName = ""
        Me.ThucXuat.BindingSourceName = ""
        Me.ThucXuat.ChangeFormStatus = False
        Me.ThucXuat.CopyFromItem = ""
        Me.ThucXuat.DefaultValue = ""
        Me.ThucXuat.Digit = True
        Me.ThucXuat.FieldName = ""
        Me.ThucXuat.FieldType = "N"
        Me.ThucXuat.KeyInsert = ""
        Me.ThucXuat.LinkLabel = ""
        Me.ThucXuat.LocalDecimal = False
        Me.ThucXuat.Location = New System.Drawing.Point(710, 105)
        Me.ThucXuat.Name = "ThucXuat"
        Me.ThucXuat.NoUpdate = ""
        Me.ThucXuat.NumberDecimal = 0
        Me.ThucXuat.PrimaryKey = ""
        Me.ThucXuat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ThucXuat.Properties.Appearance.Options.UseFont = True
        Me.ThucXuat.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ThucXuat.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ThucXuat.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ThucXuat.Properties.AppearanceFocused.Options.UseFont = True
        Me.ThucXuat.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ThucXuat.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ThucXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ThucXuat.Properties.ReadOnly = True
        Me.ThucXuat.Required = ""
        Me.ThucXuat.ShowCalc = True
        Me.ThucXuat.Size = New System.Drawing.Size(163, 26)
        Me.ThucXuat.TabIndex = 3
        Me.ThucXuat.TableName = ""
        Me.ThucXuat.UpdateIfNull = ""
        Me.ThucXuat.UpdateWhenFormLock = False
        Me.ThucXuat.ViewName = ""
        Me.ThucXuat.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(596, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 19)
        Me.Label3.TabIndex = 453
        Me.Label3.Text = "Thể tích"
        Me.Label3.Visible = False
        '
        'TyTrong
        '
        Me.TyTrong.AllowInsert = True
        Me.TyTrong.AllowUpdate = True
        Me.TyTrong.AutoKeyFix = ""
        Me.TyTrong.AutoKeyName = ""
        Me.TyTrong.BindingSourceName = ""
        Me.TyTrong.ChangeFormStatus = False
        Me.TyTrong.CopyFromItem = ""
        Me.TyTrong.DefaultValue = ""
        Me.TyTrong.Digit = True
        Me.TyTrong.FieldName = ""
        Me.TyTrong.FieldType = "N"
        Me.TyTrong.KeyInsert = ""
        Me.TyTrong.LinkLabel = ""
        Me.TyTrong.LocalDecimal = False
        Me.TyTrong.Location = New System.Drawing.Point(710, 182)
        Me.TyTrong.Name = "TyTrong"
        Me.TyTrong.NoUpdate = ""
        Me.TyTrong.NumberDecimal = 0
        Me.TyTrong.PrimaryKey = ""
        Me.TyTrong.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TyTrong.Properties.Appearance.Options.UseFont = True
        Me.TyTrong.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TyTrong.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TyTrong.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TyTrong.Properties.AppearanceFocused.Options.UseFont = True
        Me.TyTrong.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TyTrong.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TyTrong.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TyTrong.Required = ""
        Me.TyTrong.ShowCalc = True
        Me.TyTrong.Size = New System.Drawing.Size(125, 26)
        Me.TyTrong.TabIndex = 2
        Me.TyTrong.TableName = ""
        Me.TyTrong.UpdateIfNull = ""
        Me.TyTrong.UpdateWhenFormLock = False
        Me.TyTrong.ViewName = ""
        Me.TyTrong.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(596, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 19)
        Me.Label2.TabIndex = 451
        Me.Label2.Text = "Tỷ trọng"
        Me.Label2.Visible = False
        '
        'NhietDo
        '
        Me.NhietDo.AllowInsert = True
        Me.NhietDo.AllowUpdate = True
        Me.NhietDo.AutoKeyFix = ""
        Me.NhietDo.AutoKeyName = ""
        Me.NhietDo.BindingSourceName = ""
        Me.NhietDo.ChangeFormStatus = False
        Me.NhietDo.CopyFromItem = ""
        Me.NhietDo.DefaultValue = ""
        Me.NhietDo.Digit = True
        Me.NhietDo.FieldName = ""
        Me.NhietDo.FieldType = "N"
        Me.NhietDo.KeyInsert = ""
        Me.NhietDo.LinkLabel = ""
        Me.NhietDo.LocalDecimal = False
        Me.NhietDo.Location = New System.Drawing.Point(710, 150)
        Me.NhietDo.Name = "NhietDo"
        Me.NhietDo.NoUpdate = ""
        Me.NhietDo.NumberDecimal = 0
        Me.NhietDo.PrimaryKey = ""
        Me.NhietDo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NhietDo.Properties.Appearance.Options.UseFont = True
        Me.NhietDo.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NhietDo.Properties.AppearanceDisabled.Options.UseFont = True
        Me.NhietDo.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NhietDo.Properties.AppearanceFocused.Options.UseFont = True
        Me.NhietDo.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NhietDo.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.NhietDo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NhietDo.Required = ""
        Me.NhietDo.ShowCalc = True
        Me.NhietDo.Size = New System.Drawing.Size(125, 26)
        Me.NhietDo.TabIndex = 1
        Me.NhietDo.TableName = ""
        Me.NhietDo.UpdateIfNull = ""
        Me.NhietDo.UpdateWhenFormLock = False
        Me.NhietDo.ViewName = ""
        Me.NhietDo.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(596, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 19)
        Me.Label1.TabIndex = 449
        Me.Label1.Text = "Nhiệt độ"
        Me.Label1.Visible = False
        '
        'TankCode
        '
        Me.TankCode.AllowInsert = True
        Me.TankCode.AllowUpdate = True
        Me.TankCode.AutoWidth = False
        Me.TankCode.BindingSourceName = ""
        Me.TankCode.ChangeFormStatus = True
        Me.TankCode.CopyFromItem = ""
        Me.TankCode.DefaultButtonClick = True
        Me.TankCode.DefaultValue = ""
        Me.TankCode.FieldName = ""
        Me.TankCode.FieldType = ""
        Me.TankCode.FormList = False
        Me.TankCode.ItemReturn1 = ""
        Me.TankCode.ItemReturn2 = ""
        Me.TankCode.ItemReturn3 = ""
        Me.TankCode.KeyInsert = ""
        Me.TankCode.LinkLabel = ""
        Me.TankCode.Location = New System.Drawing.Point(710, 41)
        Me.TankCode.MultiSelect = False
        Me.TankCode.Name = "TankCode"
        Me.TankCode.NoUpdate = "N"
        Me.TankCode.PrimaryKey = ""
        Me.TankCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankCode.Properties.Appearance.Options.UseFont = True
        Me.TankCode.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankCode.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TankCode.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankCode.Properties.AppearanceFocused.Options.UseFont = True
        Me.TankCode.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankCode.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TankCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TankCode.Required = ""
        Me.TankCode.ShowLoad = False
        Me.TankCode.Size = New System.Drawing.Size(100, 26)
        Me.TankCode.SqlFielKey = ""
        Me.TankCode.SqlString = ""
        Me.TankCode.TabIndex = 0
        Me.TankCode.TableName = ""
        Me.TankCode.UpdateIfNull = ""
        Me.TankCode.UpdateWhenFormLock = False
        Me.TankCode.UpperValue = False
        Me.TankCode.ValidateValue = True
        Me.TankCode.ViewName = ""
        Me.TankCode.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(596, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 19)
        Me.Label7.TabIndex = 463
        Me.Label7.Text = "Bồn bể"
        Me.Label7.Visible = False
        '
        'TankHeight
        '
        Me.TankHeight.AllowInsert = True
        Me.TankHeight.AllowUpdate = True
        Me.TankHeight.AutoKeyFix = ""
        Me.TankHeight.AutoKeyName = ""
        Me.TankHeight.BindingSourceName = ""
        Me.TankHeight.ChangeFormStatus = False
        Me.TankHeight.CopyFromItem = ""
        Me.TankHeight.DefaultValue = ""
        Me.TankHeight.Digit = True
        Me.TankHeight.FieldName = ""
        Me.TankHeight.FieldType = "N"
        Me.TankHeight.KeyInsert = ""
        Me.TankHeight.LinkLabel = ""
        Me.TankHeight.LocalDecimal = False
        Me.TankHeight.Location = New System.Drawing.Point(710, 73)
        Me.TankHeight.Name = "TankHeight"
        Me.TankHeight.NoUpdate = ""
        Me.TankHeight.NumberDecimal = 0
        Me.TankHeight.PrimaryKey = ""
        Me.TankHeight.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankHeight.Properties.Appearance.Options.UseFont = True
        Me.TankHeight.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankHeight.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TankHeight.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankHeight.Properties.AppearanceFocused.Options.UseFont = True
        Me.TankHeight.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankHeight.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TankHeight.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TankHeight.Required = ""
        Me.TankHeight.ShowCalc = True
        Me.TankHeight.Size = New System.Drawing.Size(163, 26)
        Me.TankHeight.TabIndex = 1
        Me.TankHeight.TableName = ""
        Me.TankHeight.UpdateIfNull = ""
        Me.TankHeight.UpdateWhenFormLock = False
        Me.TankHeight.ViewName = ""
        Me.TankHeight.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(596, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 19)
        Me.Label8.TabIndex = 465
        Me.Label8.Text = "Chiều cao dầu"
        Me.Label8.Visible = False
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 5)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(882, 391)
        Me.TrueDBGrid1.TabIndex = 466
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MaBe, Me.MaHang, Me.CCaoDau, Me.cNhietDo, Me.cTyTrong, Me.cVCF, Me.cLtt, Me.cL15, Me.cKg})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = ""
        Me.GridView1.Where = Nothing
        '
        'MaBe
        '
        Me.MaBe.AllowInsert = True
        Me.MaBe.AllowUpdate = True
        Me.MaBe.ButtonClick = True
        Me.MaBe.Caption = "Bồn xuất"
        Me.MaBe.CFLColumnHide = ""
        Me.MaBe.CFLKeyField = ""
        Me.MaBe.CFLPage = False
        Me.MaBe.CFLReturn0 = "MaBe"
        Me.MaBe.CFLReturn1 = "MaHang"
        Me.MaBe.CFLReturn2 = ""
        Me.MaBe.CFLReturn3 = ""
        Me.MaBe.CFLReturn4 = ""
        Me.MaBe.CFLReturn5 = ""
        Me.MaBe.CFLReturn6 = ""
        Me.MaBe.CFLReturn7 = ""
        Me.MaBe.CFLShowLoad = True
        Me.MaBe.ChangeFormStatus = True
        Me.MaBe.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.MaBe.ColumnKey = False
        Me.MaBe.ComboLine = 5
        Me.MaBe.CopyFromItem = ""
        Me.MaBe.DefaultButtonClick = False
        Me.MaBe.Digit = False
        Me.MaBe.FieldType = "C"
        Me.MaBe.FieldView = ""
        Me.MaBe.FormarNumber = True
        Me.MaBe.FormList = False
        Me.MaBe.KeyInsert = ""
        Me.MaBe.LocalDecimal = False
        Me.MaBe.Name = "MaBe"
        Me.MaBe.NoUpdate = ""
        Me.MaBe.NumberDecimal = 0
        Me.MaBe.ParentControl = ""
        Me.MaBe.RefreshSource = False
        Me.MaBe.Required = False
        Me.MaBe.SequenceName = ""
        Me.MaBe.ShowCalc = True
        Me.MaBe.ShowDataTime = False
        Me.MaBe.ShowOnlyTime = False
        Me.MaBe.SQLString = ""
        Me.MaBe.UpdateIfNull = ""
        Me.MaBe.UpdateWhenFormLock = False
        Me.MaBe.UpperValue = False
        Me.MaBe.ValidateValue = True
        Me.MaBe.Visible = True
        Me.MaBe.VisibleIndex = 0
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'MaHang
        '
        Me.MaHang.AllowInsert = True
        Me.MaHang.AllowUpdate = True
        Me.MaHang.ButtonClick = True
        Me.MaHang.Caption = "Hàng hóa"
        Me.MaHang.CFLColumnHide = ""
        Me.MaHang.CFLKeyField = ""
        Me.MaHang.CFLPage = False
        Me.MaHang.CFLReturn0 = ""
        Me.MaHang.CFLReturn1 = ""
        Me.MaHang.CFLReturn2 = ""
        Me.MaHang.CFLReturn3 = ""
        Me.MaHang.CFLReturn4 = ""
        Me.MaHang.CFLReturn5 = ""
        Me.MaHang.CFLReturn6 = ""
        Me.MaHang.CFLReturn7 = ""
        Me.MaHang.CFLShowLoad = False
        Me.MaHang.ChangeFormStatus = True
        Me.MaHang.ColumnKey = False
        Me.MaHang.ComboLine = 5
        Me.MaHang.CopyFromItem = ""
        Me.MaHang.DefaultButtonClick = False
        Me.MaHang.Digit = False
        Me.MaHang.FieldType = "C"
        Me.MaHang.FieldView = ""
        Me.MaHang.FormarNumber = True
        Me.MaHang.FormList = False
        Me.MaHang.KeyInsert = ""
        Me.MaHang.LocalDecimal = False
        Me.MaHang.Name = "MaHang"
        Me.MaHang.NoUpdate = ""
        Me.MaHang.NumberDecimal = 0
        Me.MaHang.OptionsColumn.ReadOnly = True
        Me.MaHang.ParentControl = ""
        Me.MaHang.RefreshSource = False
        Me.MaHang.Required = False
        Me.MaHang.SequenceName = ""
        Me.MaHang.ShowCalc = True
        Me.MaHang.ShowDataTime = False
        Me.MaHang.ShowOnlyTime = False
        Me.MaHang.SQLString = ""
        Me.MaHang.UpdateIfNull = ""
        Me.MaHang.UpdateWhenFormLock = False
        Me.MaHang.UpperValue = False
        Me.MaHang.ValidateValue = True
        Me.MaHang.Visible = True
        Me.MaHang.VisibleIndex = 1
        '
        'CCaoDau
        '
        Me.CCaoDau.AllowInsert = True
        Me.CCaoDau.AllowUpdate = True
        Me.CCaoDau.ButtonClick = True
        Me.CCaoDau.Caption = "Chiều cao dầu"
        Me.CCaoDau.CFLColumnHide = ""
        Me.CCaoDau.CFLKeyField = ""
        Me.CCaoDau.CFLPage = False
        Me.CCaoDau.CFLReturn0 = ""
        Me.CCaoDau.CFLReturn1 = ""
        Me.CCaoDau.CFLReturn2 = ""
        Me.CCaoDau.CFLReturn3 = ""
        Me.CCaoDau.CFLReturn4 = ""
        Me.CCaoDau.CFLReturn5 = ""
        Me.CCaoDau.CFLReturn6 = ""
        Me.CCaoDau.CFLReturn7 = ""
        Me.CCaoDau.CFLShowLoad = False
        Me.CCaoDau.ChangeFormStatus = True
        Me.CCaoDau.ColumnKey = False
        Me.CCaoDau.ComboLine = 5
        Me.CCaoDau.CopyFromItem = ""
        Me.CCaoDau.DefaultButtonClick = False
        Me.CCaoDau.Digit = True
        Me.CCaoDau.FieldType = "N"
        Me.CCaoDau.FieldView = ""
        Me.CCaoDau.FormarNumber = True
        Me.CCaoDau.FormList = False
        Me.CCaoDau.KeyInsert = ""
        Me.CCaoDau.LocalDecimal = True
        Me.CCaoDau.Name = "CCaoDau"
        Me.CCaoDau.NoUpdate = ""
        Me.CCaoDau.NumberDecimal = 0
        Me.CCaoDau.ParentControl = ""
        Me.CCaoDau.RefreshSource = False
        Me.CCaoDau.Required = False
        Me.CCaoDau.SequenceName = ""
        Me.CCaoDau.ShowCalc = True
        Me.CCaoDau.ShowDataTime = False
        Me.CCaoDau.ShowOnlyTime = False
        Me.CCaoDau.SQLString = ""
        Me.CCaoDau.UpdateIfNull = ""
        Me.CCaoDau.UpdateWhenFormLock = False
        Me.CCaoDau.UpperValue = False
        Me.CCaoDau.ValidateValue = True
        Me.CCaoDau.Visible = True
        Me.CCaoDau.VisibleIndex = 2
        Me.CCaoDau.Width = 130
        '
        'cNhietDo
        '
        Me.cNhietDo.AllowInsert = True
        Me.cNhietDo.AllowUpdate = True
        Me.cNhietDo.ButtonClick = True
        Me.cNhietDo.Caption = "Nhiệt độ"
        Me.cNhietDo.CFLColumnHide = ""
        Me.cNhietDo.CFLKeyField = ""
        Me.cNhietDo.CFLPage = False
        Me.cNhietDo.CFLReturn0 = ""
        Me.cNhietDo.CFLReturn1 = ""
        Me.cNhietDo.CFLReturn2 = ""
        Me.cNhietDo.CFLReturn3 = ""
        Me.cNhietDo.CFLReturn4 = ""
        Me.cNhietDo.CFLReturn5 = ""
        Me.cNhietDo.CFLReturn6 = ""
        Me.cNhietDo.CFLReturn7 = ""
        Me.cNhietDo.CFLShowLoad = False
        Me.cNhietDo.ChangeFormStatus = True
        Me.cNhietDo.ColumnKey = False
        Me.cNhietDo.ComboLine = 5
        Me.cNhietDo.CopyFromItem = ""
        Me.cNhietDo.DefaultButtonClick = False
        Me.cNhietDo.Digit = True
        Me.cNhietDo.FieldType = "N"
        Me.cNhietDo.FieldView = ""
        Me.cNhietDo.FormarNumber = True
        Me.cNhietDo.FormList = False
        Me.cNhietDo.KeyInsert = ""
        Me.cNhietDo.LocalDecimal = True
        Me.cNhietDo.Name = "cNhietDo"
        Me.cNhietDo.NoUpdate = ""
        Me.cNhietDo.NumberDecimal = 2
        Me.cNhietDo.ParentControl = ""
        Me.cNhietDo.RefreshSource = False
        Me.cNhietDo.Required = False
        Me.cNhietDo.SequenceName = ""
        Me.cNhietDo.ShowCalc = True
        Me.cNhietDo.ShowDataTime = False
        Me.cNhietDo.ShowOnlyTime = False
        Me.cNhietDo.SQLString = ""
        Me.cNhietDo.UpdateIfNull = ""
        Me.cNhietDo.UpdateWhenFormLock = False
        Me.cNhietDo.UpperValue = False
        Me.cNhietDo.ValidateValue = True
        Me.cNhietDo.Visible = True
        Me.cNhietDo.VisibleIndex = 3
        '
        'cTyTrong
        '
        Me.cTyTrong.AllowInsert = True
        Me.cTyTrong.AllowUpdate = True
        Me.cTyTrong.ButtonClick = True
        Me.cTyTrong.Caption = "Tỷ trọng"
        Me.cTyTrong.CFLColumnHide = ""
        Me.cTyTrong.CFLKeyField = ""
        Me.cTyTrong.CFLPage = False
        Me.cTyTrong.CFLReturn0 = ""
        Me.cTyTrong.CFLReturn1 = ""
        Me.cTyTrong.CFLReturn2 = ""
        Me.cTyTrong.CFLReturn3 = ""
        Me.cTyTrong.CFLReturn4 = ""
        Me.cTyTrong.CFLReturn5 = ""
        Me.cTyTrong.CFLReturn6 = ""
        Me.cTyTrong.CFLReturn7 = ""
        Me.cTyTrong.CFLShowLoad = False
        Me.cTyTrong.ChangeFormStatus = True
        Me.cTyTrong.ColumnKey = False
        Me.cTyTrong.ComboLine = 5
        Me.cTyTrong.CopyFromItem = ""
        Me.cTyTrong.DefaultButtonClick = False
        Me.cTyTrong.Digit = True
        Me.cTyTrong.FieldType = "N"
        Me.cTyTrong.FieldView = ""
        Me.cTyTrong.FormarNumber = True
        Me.cTyTrong.FormList = False
        Me.cTyTrong.KeyInsert = ""
        Me.cTyTrong.LocalDecimal = True
        Me.cTyTrong.Name = "cTyTrong"
        Me.cTyTrong.NoUpdate = ""
        Me.cTyTrong.NumberDecimal = 4
        Me.cTyTrong.ParentControl = ""
        Me.cTyTrong.RefreshSource = False
        Me.cTyTrong.Required = False
        Me.cTyTrong.SequenceName = ""
        Me.cTyTrong.ShowCalc = True
        Me.cTyTrong.ShowDataTime = False
        Me.cTyTrong.ShowOnlyTime = False
        Me.cTyTrong.SQLString = ""
        Me.cTyTrong.UpdateIfNull = ""
        Me.cTyTrong.UpdateWhenFormLock = False
        Me.cTyTrong.UpperValue = False
        Me.cTyTrong.ValidateValue = True
        Me.cTyTrong.Visible = True
        Me.cTyTrong.VisibleIndex = 4
        '
        'cVCF
        '
        Me.cVCF.AllowInsert = True
        Me.cVCF.AllowUpdate = True
        Me.cVCF.ButtonClick = True
        Me.cVCF.Caption = "VCF"
        Me.cVCF.CFLColumnHide = ""
        Me.cVCF.CFLKeyField = ""
        Me.cVCF.CFLPage = False
        Me.cVCF.CFLReturn0 = ""
        Me.cVCF.CFLReturn1 = ""
        Me.cVCF.CFLReturn2 = ""
        Me.cVCF.CFLReturn3 = ""
        Me.cVCF.CFLReturn4 = ""
        Me.cVCF.CFLReturn5 = ""
        Me.cVCF.CFLReturn6 = ""
        Me.cVCF.CFLReturn7 = ""
        Me.cVCF.CFLShowLoad = False
        Me.cVCF.ChangeFormStatus = True
        Me.cVCF.ColumnKey = False
        Me.cVCF.ComboLine = 5
        Me.cVCF.CopyFromItem = ""
        Me.cVCF.DefaultButtonClick = False
        Me.cVCF.Digit = True
        Me.cVCF.FieldType = "N"
        Me.cVCF.FieldView = ""
        Me.cVCF.FormarNumber = True
        Me.cVCF.FormList = False
        Me.cVCF.KeyInsert = ""
        Me.cVCF.LocalDecimal = True
        Me.cVCF.Name = "cVCF"
        Me.cVCF.NoUpdate = ""
        Me.cVCF.NumberDecimal = 4
        Me.cVCF.OptionsColumn.ReadOnly = True
        Me.cVCF.ParentControl = ""
        Me.cVCF.RefreshSource = False
        Me.cVCF.Required = False
        Me.cVCF.SequenceName = ""
        Me.cVCF.ShowCalc = True
        Me.cVCF.ShowDataTime = False
        Me.cVCF.ShowOnlyTime = False
        Me.cVCF.SQLString = ""
        Me.cVCF.UpdateIfNull = ""
        Me.cVCF.UpdateWhenFormLock = False
        Me.cVCF.UpperValue = False
        Me.cVCF.ValidateValue = True
        Me.cVCF.Visible = True
        Me.cVCF.VisibleIndex = 5
        '
        'cLtt
        '
        Me.cLtt.AllowInsert = True
        Me.cLtt.AllowUpdate = True
        Me.cLtt.ButtonClick = True
        Me.cLtt.Caption = "Ltt"
        Me.cLtt.CFLColumnHide = ""
        Me.cLtt.CFLKeyField = ""
        Me.cLtt.CFLPage = False
        Me.cLtt.CFLReturn0 = ""
        Me.cLtt.CFLReturn1 = ""
        Me.cLtt.CFLReturn2 = ""
        Me.cLtt.CFLReturn3 = ""
        Me.cLtt.CFLReturn4 = ""
        Me.cLtt.CFLReturn5 = ""
        Me.cLtt.CFLReturn6 = ""
        Me.cLtt.CFLReturn7 = ""
        Me.cLtt.CFLShowLoad = False
        Me.cLtt.ChangeFormStatus = True
        Me.cLtt.ColumnKey = False
        Me.cLtt.ComboLine = 5
        Me.cLtt.CopyFromItem = ""
        Me.cLtt.DefaultButtonClick = False
        Me.cLtt.Digit = True
        Me.cLtt.FieldType = "N"
        Me.cLtt.FieldView = ""
        Me.cLtt.FormarNumber = True
        Me.cLtt.FormList = False
        Me.cLtt.KeyInsert = ""
        Me.cLtt.LocalDecimal = True
        Me.cLtt.Name = "cLtt"
        Me.cLtt.NoUpdate = ""
        Me.cLtt.NumberDecimal = 0
        Me.cLtt.OptionsColumn.ReadOnly = True
        Me.cLtt.ParentControl = ""
        Me.cLtt.RefreshSource = False
        Me.cLtt.Required = False
        Me.cLtt.SequenceName = ""
        Me.cLtt.ShowCalc = True
        Me.cLtt.ShowDataTime = False
        Me.cLtt.ShowOnlyTime = False
        Me.cLtt.SQLString = ""
        Me.cLtt.UpdateIfNull = ""
        Me.cLtt.UpdateWhenFormLock = False
        Me.cLtt.UpperValue = False
        Me.cLtt.ValidateValue = True
        Me.cLtt.Visible = True
        Me.cLtt.VisibleIndex = 6
        Me.cLtt.Width = 110
        '
        'cL15
        '
        Me.cL15.AllowInsert = True
        Me.cL15.AllowUpdate = True
        Me.cL15.ButtonClick = True
        Me.cL15.Caption = "L15"
        Me.cL15.CFLColumnHide = ""
        Me.cL15.CFLKeyField = ""
        Me.cL15.CFLPage = False
        Me.cL15.CFLReturn0 = ""
        Me.cL15.CFLReturn1 = ""
        Me.cL15.CFLReturn2 = ""
        Me.cL15.CFLReturn3 = ""
        Me.cL15.CFLReturn4 = ""
        Me.cL15.CFLReturn5 = ""
        Me.cL15.CFLReturn6 = ""
        Me.cL15.CFLReturn7 = ""
        Me.cL15.CFLShowLoad = False
        Me.cL15.ChangeFormStatus = True
        Me.cL15.ColumnKey = False
        Me.cL15.ComboLine = 5
        Me.cL15.CopyFromItem = ""
        Me.cL15.DefaultButtonClick = False
        Me.cL15.Digit = True
        Me.cL15.FieldType = "N"
        Me.cL15.FieldView = ""
        Me.cL15.FormarNumber = True
        Me.cL15.FormList = False
        Me.cL15.KeyInsert = ""
        Me.cL15.LocalDecimal = True
        Me.cL15.Name = "cL15"
        Me.cL15.NoUpdate = ""
        Me.cL15.NumberDecimal = 0
        Me.cL15.OptionsColumn.ReadOnly = True
        Me.cL15.ParentControl = ""
        Me.cL15.RefreshSource = False
        Me.cL15.Required = False
        Me.cL15.SequenceName = ""
        Me.cL15.ShowCalc = True
        Me.cL15.ShowDataTime = False
        Me.cL15.ShowOnlyTime = False
        Me.cL15.SQLString = ""
        Me.cL15.UpdateIfNull = ""
        Me.cL15.UpdateWhenFormLock = False
        Me.cL15.UpperValue = False
        Me.cL15.ValidateValue = True
        Me.cL15.Visible = True
        Me.cL15.VisibleIndex = 7
        Me.cL15.Width = 110
        '
        'cKg
        '
        Me.cKg.AllowInsert = True
        Me.cKg.AllowUpdate = True
        Me.cKg.ButtonClick = True
        Me.cKg.Caption = "KG"
        Me.cKg.CFLColumnHide = ""
        Me.cKg.CFLKeyField = ""
        Me.cKg.CFLPage = False
        Me.cKg.CFLReturn0 = ""
        Me.cKg.CFLReturn1 = ""
        Me.cKg.CFLReturn2 = ""
        Me.cKg.CFLReturn3 = ""
        Me.cKg.CFLReturn4 = ""
        Me.cKg.CFLReturn5 = ""
        Me.cKg.CFLReturn6 = ""
        Me.cKg.CFLReturn7 = ""
        Me.cKg.CFLShowLoad = False
        Me.cKg.ChangeFormStatus = True
        Me.cKg.ColumnKey = False
        Me.cKg.ComboLine = 5
        Me.cKg.CopyFromItem = ""
        Me.cKg.DefaultButtonClick = False
        Me.cKg.Digit = True
        Me.cKg.FieldType = "N"
        Me.cKg.FieldView = ""
        Me.cKg.FormarNumber = True
        Me.cKg.FormList = False
        Me.cKg.KeyInsert = ""
        Me.cKg.LocalDecimal = True
        Me.cKg.Name = "cKg"
        Me.cKg.NoUpdate = ""
        Me.cKg.NumberDecimal = 0
        Me.cKg.OptionsColumn.ReadOnly = True
        Me.cKg.ParentControl = ""
        Me.cKg.RefreshSource = False
        Me.cKg.Required = False
        Me.cKg.SequenceName = ""
        Me.cKg.ShowCalc = True
        Me.cKg.ShowDataTime = False
        Me.cKg.ShowOnlyTime = False
        Me.cKg.SQLString = ""
        Me.cKg.UpdateIfNull = ""
        Me.cKg.UpdateWhenFormLock = False
        Me.cKg.UpperValue = False
        Me.cKg.ValidateValue = True
        Me.cKg.Visible = True
        Me.cKg.VisibleIndex = 8
        Me.cKg.Width = 110
        '
        'FrmBarem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 403)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.TankHeight)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TankCode)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.KG)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.L15)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.VCF)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ThucXuat)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TyTrong)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NhietDo)
        Me.Controls.Add(Me.Label1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBarem"
        Me.Text = "Quy đổi"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.NhietDo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TyTrong, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ThucXuat, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.VCF, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.L15, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.KG, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.TankCode, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.TankHeight, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.L15.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VCF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThucXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TyTrong.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NhietDo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TankCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TankHeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents KG As U_TextBox.U_NumericEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents L15 As U_TextBox.U_NumericEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents VCF As U_TextBox.U_NumericEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ThucXuat As U_TextBox.U_NumericEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TyTrong As U_TextBox.U_NumericEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NhietDo As U_TextBox.U_NumericEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TankCode As U_TextBox.U_ButtonEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TankHeight As U_TextBox.U_NumericEdit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents MaBe As U_TextBox.GridColumn
    Friend WithEvents MaHang As U_TextBox.GridColumn
    Friend WithEvents CCaoDau As U_TextBox.GridColumn
    Friend WithEvents cNhietDo As U_TextBox.GridColumn
    Friend WithEvents cTyTrong As U_TextBox.GridColumn
    Friend WithEvents cVCF As U_TextBox.GridColumn
    Friend WithEvents cLtt As U_TextBox.GridColumn
    Friend WithEvents cL15 As U_TextBox.GridColumn
    Friend WithEvents cKg As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
