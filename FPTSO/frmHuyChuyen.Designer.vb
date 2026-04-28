<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHuyChuyen
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pTien = New U_TextBox.U_ButtonEdit()
        Me.U_ButtonCus3 = New U_TextBox.U_ButtonCus(Me.components)
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.ID = New U_TextBox.U_ButtonEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NgayVaoKho = New U_TextBox.U_DateEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pTien.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayVaoKho.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayVaoKho.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(37, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 19)
        Me.Label7.TabIndex = 902
        Me.Label7.Text = "Số P.Tiện"
        '
        'pTien
        '
        Me.pTien.AllowInsert = False
        Me.pTien.AllowUpdate = False
        Me.pTien.AutoWidth = False
        Me.pTien.BindingSourceName = ""
        Me.pTien.ChangeFormStatus = False
        Me.pTien.CopyFromItem = ""
        Me.pTien.DefaultButtonClick = True
        Me.pTien.DefaultValue = ""
        Me.pTien.FieldName = ""
        Me.pTien.FieldType = "C"
        Me.pTien.FormList = False
        Me.pTien.ItemReturn1 = "NgayVaoKho"
        Me.pTien.ItemReturn2 = ""
        Me.pTien.ItemReturn3 = "ID"
        Me.pTien.KeyInsert = ""
        Me.pTien.LinkLabel = ""
        Me.pTien.Location = New System.Drawing.Point(120, 12)
        Me.pTien.MultiSelect = False
        Me.pTien.Name = "pTien"
        Me.pTien.NoUpdate = "N"
        Me.pTien.OrderbyEx = "NgayVaoKho desc, MaPhuongTien"
        Me.pTien.PrimaryKey = ""
        Me.pTien.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.pTien.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.pTien.Properties.Appearance.Options.UseFont = True
        Me.pTien.Properties.Appearance.Options.UseForeColor = True
        Me.pTien.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.pTien.Properties.AppearanceDisabled.Options.UseFont = True
        Me.pTien.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.pTien.Properties.AppearanceFocused.Options.UseFont = True
        Me.pTien.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.pTien.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.pTien.Properties.AutoHeight = False
        Me.pTien.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.pTien.Required = "N"
        Me.pTien.ShowLoad = True
        Me.pTien.Size = New System.Drawing.Size(124, 26)
        Me.pTien.SqlFielKey = "MaPhuongTien"
        Me.pTien.SqlString = "select  MaPhuongTien, NgayVaoKho, SoLenh, ID  from dbo.tblSMO_INT a with (nolock)" & _
    " where  isnull(TrangThai_SMO,'')  = '99' "
        Me.pTien.TabIndex = 0
        Me.pTien.TableName = ""
        Me.pTien.TabStop = False
        Me.pTien.UpdateIfNull = ""
        Me.pTien.UpdateWhenFormLock = False
        Me.pTien.UpperValue = True
        Me.pTien.ValidateValue = True
        Me.pTien.ViewName = ""
        '
        'U_ButtonCus3
        '
        Me.U_ButtonCus3.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.U_ButtonCus3.Appearance.Options.UseForeColor = True
        Me.U_ButtonCus3.DefaultUpdate = True
        Me.U_ButtonCus3.EnableWhenFormLock = False
        Me.U_ButtonCus3.Location = New System.Drawing.Point(45, 94)
        Me.U_ButtonCus3.Name = "U_ButtonCus3"
        Me.U_ButtonCus3.Size = New System.Drawing.Size(109, 29)
        Me.U_ButtonCus3.TabIndex = 906
        Me.U_ButtonCus3.TabStop = False
        Me.U_ButtonCus3.Text = "Thự&c hiện"
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.U_ButtonCus1.Appearance.Options.UseForeColor = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(280, 94)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(109, 29)
        Me.U_ButtonCus1.TabIndex = 907
        Me.U_ButtonCus1.TabStop = False
        Me.U_ButtonCus1.Text = "Thoát"
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.AutoWidth = False
        Me.ID.BindingSourceName = ""
        Me.ID.ChangeFormStatus = False
        Me.ID.CopyFromItem = ""
        Me.ID.DefaultButtonClick = True
        Me.ID.DefaultValue = ""
        Me.ID.Enabled = False
        Me.ID.FieldName = ""
        Me.ID.FieldType = "N"
        Me.ID.FormList = True
        Me.ID.ItemReturn1 = ""
        Me.ID.ItemReturn2 = ""
        Me.ID.ItemReturn3 = ""
        Me.ID.KeyInsert = ""
        Me.ID.LinkLabel = ""
        Me.ID.Location = New System.Drawing.Point(365, 44)
        Me.ID.MultiSelect = False
        Me.ID.Name = "ID"
        Me.ID.NoUpdate = "N"
        Me.ID.OrderbyEx = ""
        Me.ID.PrimaryKey = ""
        Me.ID.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ID.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ID.Properties.Appearance.Options.UseFont = True
        Me.ID.Properties.Appearance.Options.UseForeColor = True
        Me.ID.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ID.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ID.Properties.AppearanceFocused.Options.UseFont = True
        Me.ID.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ID.Properties.AutoHeight = False
        Me.ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ID.Required = "N"
        Me.ID.ShowLoad = True
        Me.ID.Size = New System.Drawing.Size(53, 26)
        Me.ID.SqlFielKey = ""
        Me.ID.SqlString = ""
        Me.ID.TabIndex = 910
        Me.ID.TableName = ""
        Me.ID.TabStop = False
        Me.ID.UpdateIfNull = ""
        Me.ID.UpdateWhenFormLock = False
        Me.ID.UpperValue = True
        Me.ID.ValidateValue = True
        Me.ID.ViewName = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(20, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 19)
        Me.Label10.TabIndex = 909
        Me.Label10.Text = "Giờ vào kho"
        '
        'NgayVaoKho
        '
        Me.NgayVaoKho.AllowInsert = False
        Me.NgayVaoKho.AllowUpdate = True
        Me.NgayVaoKho.BindingSourceName = ""
        Me.NgayVaoKho.ChangeFormStatus = True
        Me.NgayVaoKho.CopyFromItem = ""
        Me.NgayVaoKho.DefaultValue = ""
        Me.NgayVaoKho.EditValue = Nothing
        Me.NgayVaoKho.FieldName = ""
        Me.NgayVaoKho.FieldType = "D"
        Me.NgayVaoKho.KeyInsert = ""
        Me.NgayVaoKho.LinkLabel = ""
        Me.NgayVaoKho.Location = New System.Drawing.Point(120, 44)
        Me.NgayVaoKho.Name = "NgayVaoKho"
        Me.NgayVaoKho.NoUpdate = ""
        Me.NgayVaoKho.PrimaryKey = ""
        Me.NgayVaoKho.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayVaoKho.Properties.Appearance.Options.UseFont = True
        Me.NgayVaoKho.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayVaoKho.Properties.AppearanceDisabled.Options.UseFont = True
        Me.NgayVaoKho.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayVaoKho.Properties.AppearanceFocused.Options.UseFont = True
        Me.NgayVaoKho.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayVaoKho.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.NgayVaoKho.Properties.AutoHeight = False
        Me.NgayVaoKho.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayVaoKho.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.NgayVaoKho.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayVaoKho.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss"
        Me.NgayVaoKho.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayVaoKho.Required = ""
        Me.NgayVaoKho.ShowDateTime = True
        Me.NgayVaoKho.Size = New System.Drawing.Size(239, 26)
        Me.NgayVaoKho.TabIndex = 908
        Me.NgayVaoKho.TableName = ""
        Me.NgayVaoKho.TabStop = False
        Me.NgayVaoKho.UpdateIfNull = ""
        Me.NgayVaoKho.UpdateWhenFormLock = False
        Me.NgayVaoKho.ViewName = ""
        '
        'frmHuyChuyen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 151)
        Me.ControlBox = False
        Me.Controls.Add(Me.ID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.NgayVaoKho)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.U_ButtonCus3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.pTien)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Caramel"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHuyChuyen"
        Me.ShowFormMessage = True
        Me.Text = "Hủy chuyến"
        Me.Controls.SetChildIndex(Me.pTien, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus3, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.NgayVaoKho, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.ID, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pTien.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayVaoKho.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayVaoKho.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pTien As U_TextBox.U_ButtonEdit
    Friend WithEvents U_ButtonCus3 As U_TextBox.U_ButtonCus
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents ID As U_TextBox.U_ButtonEdit
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents NgayVaoKho As U_TextBox.U_DateEdit
End Class
