<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrderSapUpd
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
        Me.Status = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FromDate = New U_TextBox.U_DateEdit()
        Me.U_TextBox1 = New U_TextBox.U_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToDate = New U_TextBox.U_DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SoLenh = New U_TextBox.U_TextBox()
        Me.CmdSMO = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Status.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Status
        '
        Me.Status.AllowInsert = True
        Me.Status.AllowUpdate = True
        Me.Status.AutoKeyFix = ""
        Me.Status.AutoKeyName = ""
        Me.Status.BindingSourceName = ""
        Me.Status.ChangeFormStatus = True
        Me.Status.CopyFromItem = ""
        Me.Status.DefaultValue = ""
        Me.Status.FieldName = "Status"
        Me.Status.FieldType = "C"
        Me.Status.KeyInsert = ""
        Me.Status.LinkLabel = ""
        Me.Status.Location = New System.Drawing.Point(109, 11)
        Me.Status.Name = "Status"
        Me.Status.NoUpdate = "N"
        Me.Status.PrimaryKey = ""
        Me.Status.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.Appearance.Options.UseFont = True
        Me.Status.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.AppearanceDisabled.Options.UseFont = True
        Me.Status.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.AppearanceFocused.Options.UseFont = True
        Me.Status.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.Status.Properties.AutoHeight = False
        Me.Status.Required = ""
        Me.Status.Size = New System.Drawing.Size(0, 20)
        Me.Status.TabIndex = 448
        Me.Status.TableName = "tblLenhXuatE5"
        Me.Status.TabStop = False
        Me.Status.UpdateIfNull = ""
        Me.Status.UpdateWhenFormLock = False
        Me.Status.UpperValue = False
        Me.Status.ViewName = "FPT_tblLenhXuatE5_V"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 447
        Me.Label2.Text = "Từ ngày"
        '
        'FromDate
        '
        Me.FromDate.AllowInsert = False
        Me.FromDate.AllowUpdate = True
        Me.FromDate.BindingSourceName = ""
        Me.FromDate.ChangeFormStatus = True
        Me.FromDate.CopyFromItem = ""
        Me.FromDate.DefaultValue = ""
        Me.FromDate.EditValue = Nothing
        Me.FromDate.FieldName = ""
        Me.FromDate.FieldType = "D"
        Me.FromDate.KeyInsert = ""
        Me.FromDate.LinkLabel = ""
        Me.FromDate.Location = New System.Drawing.Point(109, 12)
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
        Me.FromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.FromDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FromDate.Required = ""
        Me.FromDate.ShowDateTime = False
        Me.FromDate.Size = New System.Drawing.Size(122, 26)
        Me.FromDate.TabIndex = 0
        Me.FromDate.TableName = ""
        Me.FromDate.UpdateIfNull = ""
        Me.FromDate.UpdateWhenFormLock = False
        Me.FromDate.ViewName = ""
        '
        'U_TextBox1
        '
        Me.U_TextBox1.AllowInsert = True
        Me.U_TextBox1.AllowUpdate = True
        Me.U_TextBox1.AutoKeyFix = ""
        Me.U_TextBox1.AutoKeyName = ""
        Me.U_TextBox1.BindingSourceName = ""
        Me.U_TextBox1.ChangeFormStatus = True
        Me.U_TextBox1.CopyFromItem = ""
        Me.U_TextBox1.DefaultValue = ""
        Me.U_TextBox1.FieldName = "Status"
        Me.U_TextBox1.FieldType = "C"
        Me.U_TextBox1.KeyInsert = ""
        Me.U_TextBox1.LinkLabel = ""
        Me.U_TextBox1.Location = New System.Drawing.Point(109, 43)
        Me.U_TextBox1.Name = "U_TextBox1"
        Me.U_TextBox1.NoUpdate = "N"
        Me.U_TextBox1.PrimaryKey = ""
        Me.U_TextBox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.Appearance.Options.UseFont = True
        Me.U_TextBox1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_TextBox1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_TextBox1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_TextBox1.Properties.AutoHeight = False
        Me.U_TextBox1.Required = ""
        Me.U_TextBox1.Size = New System.Drawing.Size(0, 20)
        Me.U_TextBox1.TabIndex = 451
        Me.U_TextBox1.TableName = "tblLenhXuatE5"
        Me.U_TextBox1.TabStop = False
        Me.U_TextBox1.UpdateIfNull = ""
        Me.U_TextBox1.UpdateWhenFormLock = False
        Me.U_TextBox1.UpperValue = False
        Me.U_TextBox1.ViewName = "FPT_tblLenhXuatE5_V"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 19)
        Me.Label1.TabIndex = 450
        Me.Label1.Text = "Đến ngày"
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = False
        Me.ToDate.AllowUpdate = True
        Me.ToDate.BindingSourceName = ""
        Me.ToDate.ChangeFormStatus = True
        Me.ToDate.CopyFromItem = ""
        Me.ToDate.DefaultValue = ""
        Me.ToDate.EditValue = Nothing
        Me.ToDate.FieldName = "NgayXuat"
        Me.ToDate.FieldType = "D"
        Me.ToDate.KeyInsert = ""
        Me.ToDate.LinkLabel = ""
        Me.ToDate.Location = New System.Drawing.Point(109, 44)
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
        Me.ToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.ToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.ToDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ToDate.Required = "Y"
        Me.ToDate.ShowDateTime = False
        Me.ToDate.Size = New System.Drawing.Size(122, 26)
        Me.ToDate.TabIndex = 1
        Me.ToDate.TableName = "tblLenhXuatE5"
        Me.ToDate.UpdateIfNull = ""
        Me.ToDate.UpdateWhenFormLock = False
        Me.ToDate.ViewName = "FPT_tblLenhXuatE5_V"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 19)
        Me.Label3.TabIndex = 453
        Me.Label3.Text = "Số lệnh"
        '
        'SoLenh
        '
        Me.SoLenh.AllowInsert = False
        Me.SoLenh.AllowUpdate = False
        Me.SoLenh.AutoKeyFix = ""
        Me.SoLenh.AutoKeyName = ""
        Me.SoLenh.BindingSourceName = ""
        Me.SoLenh.ChangeFormStatus = False
        Me.SoLenh.CopyFromItem = ""
        Me.SoLenh.DefaultValue = ""
        Me.SoLenh.FieldName = ""
        Me.SoLenh.FieldType = "C"
        Me.SoLenh.KeyInsert = "Y"
        Me.SoLenh.LinkLabel = ""
        Me.SoLenh.Location = New System.Drawing.Point(109, 76)
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = "N"
        Me.SoLenh.PrimaryKey = "Y"
        Me.SoLenh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.Appearance.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoLenh.Properties.AutoHeight = False
        Me.SoLenh.Properties.MaxLength = 10
        Me.SoLenh.Required = "Y"
        Me.SoLenh.Size = New System.Drawing.Size(122, 26)
        Me.SoLenh.TabIndex = 2
        Me.SoLenh.TableName = ""
        Me.SoLenh.UpdateIfNull = "N"
        Me.SoLenh.UpdateWhenFormLock = True
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ViewName = ""
        '
        'CmdSMO
        '
        Me.CmdSMO.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSMO.Appearance.Options.UseFont = True
        Me.CmdSMO.DefaultUpdate = True
        Me.CmdSMO.EnableWhenFormLock = False
        Me.CmdSMO.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.CmdSMO.Location = New System.Drawing.Point(199, 116)
        Me.CmdSMO.Name = "CmdSMO"
        Me.CmdSMO.Size = New System.Drawing.Size(94, 26)
        Me.CmdSMO.TabIndex = 541
        Me.CmdSMO.TabStop = False
        Me.CmdSMO.Text = "Thực hiện"
        '
        'FrmOrderSapUpd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 149)
        Me.Controls.Add(Me.CmdSMO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SoLenh)
        Me.Controls.Add(Me.U_TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FromDate)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmOrderSapUpd"
        Me.Text = "Cập nhật trạng thái đồng bộ SAP"
        Me.Controls.SetChildIndex(Me.FromDate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Status, 0)
        Me.Controls.SetChildIndex(Me.ToDate, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.U_TextBox1, 0)
        Me.Controls.SetChildIndex(Me.SoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.CmdSMO, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Status.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Status As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FromDate As U_TextBox.U_DateEdit
    Friend WithEvents U_TextBox1 As U_TextBox.U_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToDate As U_TextBox.U_DateEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SoLenh As U_TextBox.U_TextBox
    Friend WithEvents CmdSMO As U_TextBox.U_ButtonCus
End Class
