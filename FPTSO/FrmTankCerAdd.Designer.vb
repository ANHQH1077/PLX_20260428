<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankCerAdd
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HoVaTen = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayNhap = New U_TextBox.U_DateEdit()
        Me.U_ButtonCus2 = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GioNhap = New U_TextBox.U_DateEdit()
        Me.ThoiGianOnDinh = New U_TextBox.U_NumericEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChucDanh = New U_TextBox.U_TextBox()
        Me.MaBe = New U_TextBox.U_ButtonEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HoVaTen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayNhap.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayNhap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GioNhap.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GioNhap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThoiGianOnDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChucDanh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaBe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(107, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 19)
        Me.Label1.TabIndex = 424
        Me.Label1.Text = "Họ và tên"
        '
        'HoVaTen
        '
        Me.HoVaTen.AllowInsert = True
        Me.HoVaTen.AllowUpdate = True
        Me.HoVaTen.AutoKeyFix = ""
        Me.HoVaTen.AutoKeyName = ""
        Me.HoVaTen.BindingSourceName = ""
        Me.HoVaTen.ChangeFormStatus = True
        Me.HoVaTen.CopyFromItem = ""
        Me.HoVaTen.DefaultValue = ""
        Me.HoVaTen.FieldName = ""
        Me.HoVaTen.FieldType = "C"
        Me.HoVaTen.KeyInsert = "Y"
        Me.HoVaTen.LinkLabel = ""
        Me.HoVaTen.Location = New System.Drawing.Point(198, 144)
        Me.HoVaTen.Name = "HoVaTen"
        Me.HoVaTen.NoUpdate = "N"
        Me.HoVaTen.PrimaryKey = "Y"
        Me.HoVaTen.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.HoVaTen.Properties.Appearance.Options.UseFont = True
        Me.HoVaTen.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.HoVaTen.Properties.AppearanceDisabled.Options.UseFont = True
        Me.HoVaTen.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.HoVaTen.Properties.AppearanceFocused.Options.UseFont = True
        Me.HoVaTen.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.HoVaTen.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.HoVaTen.Properties.AutoHeight = False
        Me.HoVaTen.Required = "Y"
        Me.HoVaTen.Size = New System.Drawing.Size(279, 26)
        Me.HoVaTen.TabIndex = 4
        Me.HoVaTen.TableName = ""
        Me.HoVaTen.UpdateIfNull = "Y"
        Me.HoVaTen.UpdateWhenFormLock = False
        Me.HoVaTen.UpperValue = False
        Me.HoVaTen.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 19)
        Me.Label2.TabIndex = 426
        Me.Label2.Text = "Ngày kết thúc nhập"
        '
        'NgayNhap
        '
        Me.NgayNhap.AllowInsert = True
        Me.NgayNhap.AllowUpdate = True
        Me.NgayNhap.BindingSourceName = ""
        Me.NgayNhap.ChangeFormStatus = True
        Me.NgayNhap.CopyFromItem = ""
        Me.NgayNhap.DefaultValue = ""
        Me.NgayNhap.EditValue = Nothing
        Me.NgayNhap.FieldName = ""
        Me.NgayNhap.FieldType = "D"
        Me.NgayNhap.KeyInsert = ""
        Me.NgayNhap.LinkLabel = ""
        Me.NgayNhap.Location = New System.Drawing.Point(198, 41)
        Me.NgayNhap.Name = "NgayNhap"
        Me.NgayNhap.NoUpdate = ""
        Me.NgayNhap.PrimaryKey = ""
        Me.NgayNhap.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayNhap.Properties.Appearance.Options.UseFont = True
        Me.NgayNhap.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayNhap.Properties.AppearanceDisabled.Options.UseFont = True
        Me.NgayNhap.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayNhap.Properties.AppearanceFocused.Options.UseFont = True
        Me.NgayNhap.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayNhap.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.NgayNhap.Properties.AutoHeight = False
        Me.NgayNhap.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayNhap.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayNhap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayNhap.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayNhap.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayNhap.Required = "Y"
        Me.NgayNhap.ShowDateTime = False
        Me.NgayNhap.Size = New System.Drawing.Size(118, 26)
        Me.NgayNhap.TabIndex = 1
        Me.NgayNhap.TableName = ""
        Me.NgayNhap.TabStop = False
        Me.NgayNhap.UpdateIfNull = "Y"
        Me.NgayNhap.UpdateWhenFormLock = False
        Me.NgayNhap.ViewName = ""
        '
        'U_ButtonCus2
        '
        Me.U_ButtonCus2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus2.Appearance.Options.UseFont = True
        Me.U_ButtonCus2.DefaultUpdate = True
        Me.U_ButtonCus2.EnableWhenFormLock = False
        Me.U_ButtonCus2.Location = New System.Drawing.Point(12, 227)
        Me.U_ButtonCus2.Name = "U_ButtonCus2"
        Me.U_ButtonCus2.Size = New System.Drawing.Size(184, 36)
        Me.U_ButtonCus2.TabIndex = 6
        Me.U_ButtonCus2.Text = "In chứng chỉ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 19)
        Me.Label3.TabIndex = 428
        Me.Label3.Text = "Mã bể (Ví dụ: B14)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 19)
        Me.Label4.TabIndex = 430
        Me.Label4.Text = "Giờ kết thúc nhập"
        '
        'GioNhap
        '
        Me.GioNhap.AllowInsert = True
        Me.GioNhap.AllowUpdate = True
        Me.GioNhap.BindingSourceName = ""
        Me.GioNhap.ChangeFormStatus = True
        Me.GioNhap.CopyFromItem = ""
        Me.GioNhap.DefaultValue = ""
        Me.GioNhap.EditValue = Nothing
        Me.GioNhap.FieldName = ""
        Me.GioNhap.FieldType = "D"
        Me.GioNhap.KeyInsert = ""
        Me.GioNhap.LinkLabel = ""
        Me.GioNhap.Location = New System.Drawing.Point(198, 70)
        Me.GioNhap.Name = "GioNhap"
        Me.GioNhap.NoUpdate = ""
        Me.GioNhap.PrimaryKey = ""
        Me.GioNhap.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GioNhap.Properties.Appearance.Options.UseFont = True
        Me.GioNhap.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GioNhap.Properties.AppearanceDisabled.Options.UseFont = True
        Me.GioNhap.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GioNhap.Properties.AppearanceFocused.Options.UseFont = True
        Me.GioNhap.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GioNhap.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.GioNhap.Properties.AutoHeight = False
        Me.GioNhap.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.GioNhap.Properties.DisplayFormat.FormatString = "HH:mm:ss"
        Me.GioNhap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GioNhap.Properties.Mask.EditMask = "HH:mm:ss"
        Me.GioNhap.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.GioNhap.Required = "Y"
        Me.GioNhap.ShowDateTime = False
        Me.GioNhap.Size = New System.Drawing.Size(118, 26)
        Me.GioNhap.TabIndex = 2
        Me.GioNhap.TableName = ""
        Me.GioNhap.TabStop = False
        Me.GioNhap.UpdateIfNull = "Y"
        Me.GioNhap.UpdateWhenFormLock = False
        Me.GioNhap.ViewName = ""
        '
        'ThoiGianOnDinh
        '
        Me.ThoiGianOnDinh.AllowInsert = True
        Me.ThoiGianOnDinh.AllowUpdate = True
        Me.ThoiGianOnDinh.AutoKeyFix = ""
        Me.ThoiGianOnDinh.AutoKeyName = ""
        Me.ThoiGianOnDinh.BindingSourceName = ""
        Me.ThoiGianOnDinh.ChangeFormStatus = True
        Me.ThoiGianOnDinh.CopyFromItem = ""
        Me.ThoiGianOnDinh.DefaultValue = ""
        Me.ThoiGianOnDinh.Digit = False
        Me.ThoiGianOnDinh.FieldName = ""
        Me.ThoiGianOnDinh.FieldType = "N"
        Me.ThoiGianOnDinh.KeyInsert = ""
        Me.ThoiGianOnDinh.LinkLabel = ""
        Me.ThoiGianOnDinh.LocalDecimal = False
        Me.ThoiGianOnDinh.Location = New System.Drawing.Point(198, 100)
        Me.ThoiGianOnDinh.Name = "ThoiGianOnDinh"
        Me.ThoiGianOnDinh.NoUpdate = ""
        Me.ThoiGianOnDinh.NumberDecimal = 0
        Me.ThoiGianOnDinh.PrimaryKey = ""
        Me.ThoiGianOnDinh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ThoiGianOnDinh.Properties.Appearance.Options.UseFont = True
        Me.ThoiGianOnDinh.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ThoiGianOnDinh.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ThoiGianOnDinh.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ThoiGianOnDinh.Properties.AppearanceFocused.Options.UseFont = True
        Me.ThoiGianOnDinh.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ThoiGianOnDinh.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ThoiGianOnDinh.Properties.AutoHeight = False
        Me.ThoiGianOnDinh.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ThoiGianOnDinh.Required = ""
        Me.ThoiGianOnDinh.ShowCalc = False
        Me.ThoiGianOnDinh.Size = New System.Drawing.Size(69, 24)
        Me.ThoiGianOnDinh.TabIndex = 3
        Me.ThoiGianOnDinh.TableName = ""
        Me.ThoiGianOnDinh.UpdateIfNull = ""
        Me.ThoiGianOnDinh.UpdateWhenFormLock = True
        Me.ThoiGianOnDinh.ViewName = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(38, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 19)
        Me.Label5.TabIndex = 489
        Me.Label5.Text = "Thời gian ổn định"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(107, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 19)
        Me.Label6.TabIndex = 491
        Me.Label6.Text = "Chức danh"
        '
        'ChucDanh
        '
        Me.ChucDanh.AllowInsert = True
        Me.ChucDanh.AllowUpdate = True
        Me.ChucDanh.AutoKeyFix = ""
        Me.ChucDanh.AutoKeyName = ""
        Me.ChucDanh.BindingSourceName = ""
        Me.ChucDanh.ChangeFormStatus = True
        Me.ChucDanh.CopyFromItem = ""
        Me.ChucDanh.DefaultValue = ""
        Me.ChucDanh.FieldName = ""
        Me.ChucDanh.FieldType = "C"
        Me.ChucDanh.KeyInsert = "Y"
        Me.ChucDanh.LinkLabel = ""
        Me.ChucDanh.Location = New System.Drawing.Point(198, 176)
        Me.ChucDanh.Name = "ChucDanh"
        Me.ChucDanh.NoUpdate = "N"
        Me.ChucDanh.PrimaryKey = "Y"
        Me.ChucDanh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ChucDanh.Properties.Appearance.Options.UseFont = True
        Me.ChucDanh.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ChucDanh.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ChucDanh.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ChucDanh.Properties.AppearanceFocused.Options.UseFont = True
        Me.ChucDanh.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ChucDanh.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ChucDanh.Properties.AutoHeight = False
        Me.ChucDanh.Required = "Y"
        Me.ChucDanh.Size = New System.Drawing.Size(279, 26)
        Me.ChucDanh.TabIndex = 5
        Me.ChucDanh.TableName = ""
        Me.ChucDanh.UpdateIfNull = "Y"
        Me.ChucDanh.UpdateWhenFormLock = False
        Me.ChucDanh.UpperValue = False
        Me.ChucDanh.ViewName = ""
        '
        'MaBe
        '
        Me.MaBe.AllowInsert = True
        Me.MaBe.AllowUpdate = True
        Me.MaBe.AutoWidth = False
        Me.MaBe.BindingSourceName = ""
        Me.MaBe.ChangeFormStatus = False
        Me.MaBe.CopyFromItem = ""
        Me.MaBe.DefaultButtonClick = True
        Me.MaBe.DefaultValue = ""
        Me.MaBe.FieldName = ""
        Me.MaBe.FieldType = "C"
        Me.MaBe.FormList = True
        Me.MaBe.ItemReturn1 = ""
        Me.MaBe.ItemReturn2 = ""
        Me.MaBe.ItemReturn3 = ""
        Me.MaBe.KeyInsert = ""
        Me.MaBe.LinkLabel = "Label9"
        Me.MaBe.Location = New System.Drawing.Point(198, 12)
        Me.MaBe.MultiSelect = False
        Me.MaBe.Name = "MaBe"
        Me.MaBe.NoUpdate = "N"
        Me.MaBe.OrderbyEx = ""
        Me.MaBe.PrimaryKey = ""
        Me.MaBe.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaBe.Properties.Appearance.Options.UseFont = True
        Me.MaBe.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaBe.Properties.AppearanceDisabled.Options.UseFont = True
        Me.MaBe.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaBe.Properties.AppearanceFocused.Options.UseFont = True
        Me.MaBe.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaBe.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.MaBe.Properties.AutoHeight = False
        Me.MaBe.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.MaBe.Required = "Y"
        Me.MaBe.ShowLoad = True
        Me.MaBe.Size = New System.Drawing.Size(118, 26)
        Me.MaBe.SqlFielKey = "Map_sap"
        Me.MaBe.SqlString = "select Map_sap from tblTank  where Product_nd = '0101002'  and isnull(Map_sap,'')" & _
            " <> '' "
        Me.MaBe.TabIndex = 0
        Me.MaBe.TableName = ""
        Me.MaBe.UpdateIfNull = ""
        Me.MaBe.UpdateWhenFormLock = False
        Me.MaBe.UpperValue = True
        Me.MaBe.ValidateValue = True
        Me.MaBe.ViewName = "FPT_tblLenhXuatE5_V"
        '
        'FrmTankCerAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 285)
        Me.Controls.Add(Me.MaBe)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ChucDanh)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ThoiGianOnDinh)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GioNhap)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.U_ButtonCus2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayNhap)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.HoVaTen)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmTankCerAdd"
        Me.Text = "Chứng chỉ bồn"
        Me.Controls.SetChildIndex(Me.HoVaTen, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.NgayNhap, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.GioNhap, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.ThoiGianOnDinh, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.ChucDanh, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.MaBe, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HoVaTen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayNhap.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayNhap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GioNhap.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GioNhap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThoiGianOnDinh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChucDanh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaBe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HoVaTen As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayNhap As U_TextBox.U_DateEdit
    Friend WithEvents U_ButtonCus2 As U_TextBox.U_ButtonCus
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GioNhap As U_TextBox.U_DateEdit
    Friend WithEvents ThoiGianOnDinh As U_TextBox.U_NumericEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChucDanh As U_TextBox.U_TextBox
    Friend WithEvents MaBe As U_TextBox.U_ButtonEdit
End Class
