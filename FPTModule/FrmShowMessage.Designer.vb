<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShowMessage
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmShowMessage))
        Me.BtnNo = New U_TextBox.U_Button()
        Me.BtnCancel = New U_TextBox.U_Button()
        Me.BtnYes = New U_TextBox.U_Button()
        Me.U_MemmoEdit1 = New U_TextBox.U_MemmoEdit()
        Me.imgErr = New System.Windows.Forms.PictureBox()
        Me.imgWarn = New System.Windows.Forms.PictureBox()
        Me.imgInfor = New System.Windows.Forms.PictureBox()
        Me.imgSuccess = New System.Windows.Forms.PictureBox()
        CType(Me.U_MemmoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgErr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgWarn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgInfor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgSuccess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnNo
        '
        Me.BtnNo.DefaultUpdate = True
        Me.BtnNo.Location = New System.Drawing.Point(270, 89)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Size = New System.Drawing.Size(89, 23)
        Me.BtnNo.TabIndex = 2
        Me.BtnNo.Text = "No"
        Me.BtnNo.Visible = False
        '
        'BtnCancel
        '
        Me.BtnCancel.DefaultUpdate = True
        Me.BtnCancel.Location = New System.Drawing.Point(152, 89)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 23)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.Visible = False
        '
        'BtnYes
        '
        Me.BtnYes.DefaultUpdate = True
        Me.BtnYes.Location = New System.Drawing.Point(34, 89)
        Me.BtnYes.Name = "BtnYes"
        Me.BtnYes.Size = New System.Drawing.Size(89, 23)
        Me.BtnYes.TabIndex = 0
        Me.BtnYes.Text = "Yes"
        Me.BtnYes.Visible = False
        '
        'U_MemmoEdit1
        '
        Me.U_MemmoEdit1.AllowInsert = True
        Me.U_MemmoEdit1.AllowUpdate = True
        Me.U_MemmoEdit1.AutoKeyFix = ""
        Me.U_MemmoEdit1.AutoKeyName = ""
        Me.U_MemmoEdit1.BindingSourceName = ""
        Me.U_MemmoEdit1.ChangeFormStatus = True
        Me.U_MemmoEdit1.CopyFromItem = ""
        Me.U_MemmoEdit1.DefaultValue = ""
        Me.U_MemmoEdit1.FieldName = ""
        Me.U_MemmoEdit1.FieldType = ""
        Me.U_MemmoEdit1.KeyInsert = ""
        Me.U_MemmoEdit1.LinkLabel = ""
        Me.U_MemmoEdit1.Location = New System.Drawing.Point(43, 9)
        Me.U_MemmoEdit1.Name = "U_MemmoEdit1"
        Me.U_MemmoEdit1.NoUpdate = "N"
        Me.U_MemmoEdit1.PrimaryKey = ""
        Me.U_MemmoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.U_MemmoEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.U_MemmoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.U_MemmoEdit1.Properties.ReadOnly = True
        Me.U_MemmoEdit1.Required = ""
        Me.U_MemmoEdit1.Size = New System.Drawing.Size(351, 73)
        Me.U_MemmoEdit1.TabIndex = 3
        Me.U_MemmoEdit1.TableName = ""
        Me.U_MemmoEdit1.UpdateIfNull = ""
        Me.U_MemmoEdit1.UpdateWhenFormLock = False
        Me.U_MemmoEdit1.ViewName = ""
        '
        'imgErr
        '
        Me.imgErr.Image = CType(resources.GetObject("imgErr.Image"), System.Drawing.Image)
        Me.imgErr.Location = New System.Drawing.Point(5, 10)
        Me.imgErr.Name = "imgErr"
        Me.imgErr.Size = New System.Drawing.Size(32, 32)
        Me.imgErr.TabIndex = 4
        Me.imgErr.TabStop = False
        Me.imgErr.Visible = False
        '
        'imgWarn
        '
        Me.imgWarn.Image = CType(resources.GetObject("imgWarn.Image"), System.Drawing.Image)
        Me.imgWarn.Location = New System.Drawing.Point(5, 51)
        Me.imgWarn.Name = "imgWarn"
        Me.imgWarn.Size = New System.Drawing.Size(32, 32)
        Me.imgWarn.TabIndex = 5
        Me.imgWarn.TabStop = False
        Me.imgWarn.Visible = False
        '
        'imgInfor
        '
        Me.imgInfor.Image = CType(resources.GetObject("imgInfor.Image"), System.Drawing.Image)
        Me.imgInfor.Location = New System.Drawing.Point(79, 24)
        Me.imgInfor.Name = "imgInfor"
        Me.imgInfor.Size = New System.Drawing.Size(32, 32)
        Me.imgInfor.TabIndex = 6
        Me.imgInfor.TabStop = False
        Me.imgInfor.Visible = False
        '
        'imgSuccess
        '
        Me.imgSuccess.Image = CType(resources.GetObject("imgSuccess.Image"), System.Drawing.Image)
        Me.imgSuccess.Location = New System.Drawing.Point(183, 44)
        Me.imgSuccess.Name = "imgSuccess"
        Me.imgSuccess.Size = New System.Drawing.Size(32, 32)
        Me.imgSuccess.TabIndex = 7
        Me.imgSuccess.TabStop = False
        Me.imgSuccess.Visible = False
        '
        'FrmShowMessage
        '
        Me.AcceptButton = Me.BtnNo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 120)
        Me.Controls.Add(Me.imgSuccess)
        Me.Controls.Add(Me.imgInfor)
        Me.Controls.Add(Me.imgWarn)
        Me.Controls.Add(Me.imgErr)
        Me.Controls.Add(Me.U_MemmoEdit1)
        Me.Controls.Add(Me.BtnNo)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnYes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmShowMessage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Thông báo"
        CType(Me.U_MemmoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgErr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgWarn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgInfor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgSuccess, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnYes As U_TextBox.U_Button
    Friend WithEvents BtnCancel As U_TextBox.U_Button
    Friend WithEvents BtnNo As U_TextBox.U_Button
    Friend WithEvents U_MemmoEdit1 As U_TextBox.U_MemmoEdit
    Friend WithEvents imgErr As System.Windows.Forms.PictureBox
    Friend WithEvents imgWarn As System.Windows.Forms.PictureBox
    Friend WithEvents imgInfor As System.Windows.Forms.PictureBox
    Friend WithEvents imgSuccess As System.Windows.Forms.PictureBox
End Class
