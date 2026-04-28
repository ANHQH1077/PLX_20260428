<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInChungTu
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
        Me.rdoLenhXuat = New System.Windows.Forms.RadioButton()
        Me.rdoHoaDon = New System.Windows.Forms.RadioButton()
        Me.rdoTaiXuat = New System.Windows.Forms.RadioButton()
        Me.rdoPXK = New System.Windows.Forms.RadioButton()
        Me.rdoPXKHanggiuho = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SoLenh = New U_TextBox.U_TextBox()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus()
        Me.U_CheckBox1 = New U_TextBox.U_CheckBox()
        Me.rdoTaiXuatGTGT = New System.Windows.Forms.RadioButton()
        Me.rdoTaiXuatGTGT1 = New System.Windows.Forms.RadioButton()
        Me.rdoLenhXKTheoPhoi = New System.Windows.Forms.RadioButton()
        Me.rdoPXK_NBN = New System.Windows.Forms.RadioButton()
        Me.rdoPXK_CIF = New System.Windows.Forms.RadioButton()
        Me.rdoLenhXuatKDD = New System.Windows.Forms.RadioButton()
        Me.rdoLenhXuatKDDA4 = New System.Windows.Forms.RadioButton()
        Me.rdoHoaDonCT = New System.Windows.Forms.RadioButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdoLenhXuat
        '
        Me.rdoLenhXuat.AutoSize = True
        Me.rdoLenhXuat.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoLenhXuat.Location = New System.Drawing.Point(14, 74)
        Me.rdoLenhXuat.Name = "rdoLenhXuat"
        Me.rdoLenhXuat.Size = New System.Drawing.Size(199, 23)
        Me.rdoLenhXuat.TabIndex = 1
        Me.rdoLenhXuat.TabStop = True
        Me.rdoLenhXuat.Text = "2. In lệnh xuất kho (A4)"
        Me.rdoLenhXuat.UseVisualStyleBackColor = True
        '
        'rdoHoaDon
        '
        Me.rdoHoaDon.AutoSize = True
        Me.rdoHoaDon.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoHoaDon.Location = New System.Drawing.Point(14, 167)
        Me.rdoHoaDon.Name = "rdoHoaDon"
        Me.rdoHoaDon.Size = New System.Drawing.Size(124, 23)
        Me.rdoHoaDon.TabIndex = 4
        Me.rdoHoaDon.TabStop = True
        Me.rdoHoaDon.Text = "5. In hóa đơn"
        Me.rdoHoaDon.UseVisualStyleBackColor = True
        '
        'rdoTaiXuat
        '
        Me.rdoTaiXuat.AutoSize = True
        Me.rdoTaiXuat.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoTaiXuat.Location = New System.Drawing.Point(14, 229)
        Me.rdoTaiXuat.Name = "rdoTaiXuat"
        Me.rdoTaiXuat.Size = New System.Drawing.Size(181, 23)
        Me.rdoTaiXuat.TabIndex = 5
        Me.rdoTaiXuat.TabStop = True
        Me.rdoTaiXuat.Text = "6. In hóa đơn tái xuất"
        Me.rdoTaiXuat.UseVisualStyleBackColor = True
        '
        'rdoPXK
        '
        Me.rdoPXK.AutoSize = True
        Me.rdoPXK.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPXK.Location = New System.Drawing.Point(14, 353)
        Me.rdoPXK.Name = "rdoPXK"
        Me.rdoPXK.Size = New System.Drawing.Size(329, 23)
        Me.rdoPXK.TabIndex = 9
        Me.rdoPXK.TabStop = True
        Me.rdoPXK.Text = "10. In PXK kiêm VC nội bộ (Nội bộ ngành)"
        Me.rdoPXK.UseVisualStyleBackColor = True
        '
        'rdoPXKHanggiuho
        '
        Me.rdoPXKHanggiuho.AutoSize = True
        Me.rdoPXKHanggiuho.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPXKHanggiuho.Location = New System.Drawing.Point(14, 322)
        Me.rdoPXKHanggiuho.Name = "rdoPXKHanggiuho"
        Me.rdoPXKHanggiuho.Size = New System.Drawing.Size(262, 23)
        Me.rdoPXKHanggiuho.TabIndex = 8
        Me.rdoPXKHanggiuho.TabStop = True
        Me.rdoPXKHanggiuho.Text = "9. In phiếu xuất kho hàng giữ hộ"
        Me.rdoPXKHanggiuho.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 19)
        Me.Label1.TabIndex = 424
        Me.Label1.Text = "Số lệnh"
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
        Me.SoLenh.Location = New System.Drawing.Point(98, 7)
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = "N"
        Me.SoLenh.PrimaryKey = "Y"
        Me.SoLenh.Properties.AutoHeight = False
        Me.SoLenh.Properties.MaxLength = 10
        Me.SoLenh.Required = "Y"
        Me.SoLenh.Size = New System.Drawing.Size(119, 26)
        Me.SoLenh.TabIndex = 423
        Me.SoLenh.TableName = ""
        Me.SoLenh.UpdateIfNull = "Y"
        Me.SoLenh.UpdateWhenFormLock = False
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ViewName = ""
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(13, 451)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(75, 26)
        Me.U_ButtonCus1.TabIndex = 425
        Me.U_ButtonCus1.Text = "In"
        '
        'U_CheckBox1
        '
        Me.U_CheckBox1.AllowInsert = True
        Me.U_CheckBox1.AllowUpdate = True
        Me.U_CheckBox1.BindingSourceName = ""
        Me.U_CheckBox1.ChangeFormStatus = False
        Me.U_CheckBox1.CheckValue = "Y"
        Me.U_CheckBox1.CopyFromItem = ""
        Me.U_CheckBox1.DefaultValue = ""
        Me.U_CheckBox1.FieldName = ""
        Me.U_CheckBox1.FieldType = ""
        Me.U_CheckBox1.ItemValue = ""
        Me.U_CheckBox1.KeyInsert = ""
        Me.U_CheckBox1.LinkLabel = ""
        Me.U_CheckBox1.Location = New System.Drawing.Point(116, 453)
        Me.U_CheckBox1.Name = "U_CheckBox1"
        Me.U_CheckBox1.NoUpdate = ""
        Me.U_CheckBox1.PrimaryKey = ""
        Me.U_CheckBox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_CheckBox1.Properties.Appearance.Options.UseFont = True
        Me.U_CheckBox1.Properties.Caption = "In không cần xem lại"
        Me.U_CheckBox1.Required = ""
        Me.U_CheckBox1.Size = New System.Drawing.Size(186, 24)
        Me.U_CheckBox1.TabIndex = 469
        Me.U_CheckBox1.TableName = ""
        Me.U_CheckBox1.UnCheckValue = "N"
        Me.U_CheckBox1.UpdateIfNull = ""
        Me.U_CheckBox1.UpdateWhenFormLock = False
        Me.U_CheckBox1.ViewName = ""
        Me.U_CheckBox1.Visible = False
        '
        'rdoTaiXuatGTGT
        '
        Me.rdoTaiXuatGTGT.AutoSize = True
        Me.rdoTaiXuatGTGT.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoTaiXuatGTGT.Location = New System.Drawing.Point(14, 260)
        Me.rdoTaiXuatGTGT.Name = "rdoTaiXuatGTGT"
        Me.rdoTaiXuatGTGT.Size = New System.Drawing.Size(266, 23)
        Me.rdoTaiXuatGTGT.TabIndex = 6
        Me.rdoTaiXuatGTGT.TabStop = True
        Me.rdoTaiXuatGTGT.Text = "7. In hóa đơn tái xuất GTGT (VN)"
        Me.rdoTaiXuatGTGT.UseVisualStyleBackColor = True
        '
        'rdoTaiXuatGTGT1
        '
        Me.rdoTaiXuatGTGT1.AutoSize = True
        Me.rdoTaiXuatGTGT1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoTaiXuatGTGT1.Location = New System.Drawing.Point(14, 291)
        Me.rdoTaiXuatGTGT1.Name = "rdoTaiXuatGTGT1"
        Me.rdoTaiXuatGTGT1.Size = New System.Drawing.Size(265, 23)
        Me.rdoTaiXuatGTGT1.TabIndex = 7
        Me.rdoTaiXuatGTGT1.TabStop = True
        Me.rdoTaiXuatGTGT1.Text = "8. In hóa đơn tái xuất GTGT (EN)"
        Me.rdoTaiXuatGTGT1.UseVisualStyleBackColor = True
        '
        'rdoLenhXKTheoPhoi
        '
        Me.rdoLenhXKTheoPhoi.AutoSize = True
        Me.rdoLenhXKTheoPhoi.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoLenhXKTheoPhoi.Location = New System.Drawing.Point(14, 43)
        Me.rdoLenhXKTheoPhoi.Name = "rdoLenhXKTheoPhoi"
        Me.rdoLenhXKTheoPhoi.Size = New System.Drawing.Size(162, 23)
        Me.rdoLenhXKTheoPhoi.TabIndex = 0
        Me.rdoLenhXKTheoPhoi.TabStop = True
        Me.rdoLenhXKTheoPhoi.Text = "1. In lệnh xuất kho"
        Me.rdoLenhXKTheoPhoi.UseVisualStyleBackColor = True
        '
        'rdoPXK_NBN
        '
        Me.rdoPXK_NBN.AutoSize = True
        Me.rdoPXK_NBN.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPXK_NBN.Location = New System.Drawing.Point(14, 384)
        Me.rdoPXK_NBN.Name = "rdoPXK_NBN"
        Me.rdoPXK_NBN.Size = New System.Drawing.Size(318, 23)
        Me.rdoPXK_NBN.TabIndex = 10
        Me.rdoPXK_NBN.TabStop = True
        Me.rdoPXK_NBN.Text = "11. In PXK kiêm VC nội bộ (Đi cửa hàng)"
        Me.rdoPXK_NBN.UseVisualStyleBackColor = True
        '
        'rdoPXK_CIF
        '
        Me.rdoPXK_CIF.AutoSize = True
        Me.rdoPXK_CIF.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPXK_CIF.Location = New System.Drawing.Point(14, 415)
        Me.rdoPXK_CIF.Name = "rdoPXK_CIF"
        Me.rdoPXK_CIF.Size = New System.Drawing.Size(323, 23)
        Me.rdoPXK_CIF.TabIndex = 11
        Me.rdoPXK_CIF.TabStop = True
        Me.rdoPXK_CIF.Text = "12. In PXK kiêm VC nội bộ (lệnh bán CIF)"
        Me.rdoPXK_CIF.UseVisualStyleBackColor = True
        '
        'rdoLenhXuatKDD
        '
        Me.rdoLenhXuatKDD.AutoSize = True
        Me.rdoLenhXuatKDD.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoLenhXuatKDD.Location = New System.Drawing.Point(14, 105)
        Me.rdoLenhXuatKDD.Name = "rdoLenhXuatKDD"
        Me.rdoLenhXuatKDD.Size = New System.Drawing.Size(277, 23)
        Me.rdoLenhXuatKDD.TabIndex = 2
        Me.rdoLenhXuatKDD.TabStop = True
        Me.rdoLenhXuatKDD.Text = "3. In lệnh xuất kho kiêm điều động"
        Me.rdoLenhXuatKDD.UseVisualStyleBackColor = True
        '
        'rdoLenhXuatKDDA4
        '
        Me.rdoLenhXuatKDDA4.AutoSize = True
        Me.rdoLenhXuatKDDA4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoLenhXuatKDDA4.Location = New System.Drawing.Point(14, 136)
        Me.rdoLenhXuatKDDA4.Name = "rdoLenhXuatKDDA4"
        Me.rdoLenhXuatKDDA4.Size = New System.Drawing.Size(314, 23)
        Me.rdoLenhXuatKDDA4.TabIndex = 3
        Me.rdoLenhXuatKDDA4.TabStop = True
        Me.rdoLenhXuatKDDA4.Text = "4. In lệnh xuất kho kiêm điều động (A4)"
        Me.rdoLenhXuatKDDA4.UseVisualStyleBackColor = True
        '
        'rdoHoaDonCT
        '
        Me.rdoHoaDonCT.AutoSize = True
        Me.rdoHoaDonCT.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoHoaDonCT.Location = New System.Drawing.Point(14, 198)
        Me.rdoHoaDonCT.Name = "rdoHoaDonCT"
        Me.rdoHoaDonCT.Size = New System.Drawing.Size(238, 23)
        Me.rdoHoaDonCT.TabIndex = 470
        Me.rdoHoaDonCT.TabStop = True
        Me.rdoHoaDonCT.Text = "5.1. In hóa đơn chuyển thẳng"
        Me.rdoHoaDonCT.UseVisualStyleBackColor = True
        Me.rdoHoaDonCT.Visible = False
        '
        'FrmInChungTu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 505)
        Me.Controls.Add(Me.rdoHoaDonCT)
        Me.Controls.Add(Me.rdoLenhXuatKDDA4)
        Me.Controls.Add(Me.rdoLenhXuatKDD)
        Me.Controls.Add(Me.rdoPXK_CIF)
        Me.Controls.Add(Me.rdoPXK_NBN)
        Me.Controls.Add(Me.rdoLenhXKTheoPhoi)
        Me.Controls.Add(Me.rdoTaiXuatGTGT1)
        Me.Controls.Add(Me.rdoTaiXuatGTGT)
        Me.Controls.Add(Me.U_CheckBox1)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SoLenh)
        Me.Controls.Add(Me.rdoPXKHanggiuho)
        Me.Controls.Add(Me.rdoPXK)
        Me.Controls.Add(Me.rdoTaiXuat)
        Me.Controls.Add(Me.rdoHoaDon)
        Me.Controls.Add(Me.rdoLenhXuat)
        Me.DefaultFormLoad = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmInChungTu"
        Me.Text = "Hóa đơn - Chứng từ"
        Me.Controls.SetChildIndex(Me.rdoLenhXuat, 0)
        Me.Controls.SetChildIndex(Me.rdoHoaDon, 0)
        Me.Controls.SetChildIndex(Me.rdoTaiXuat, 0)
        Me.Controls.SetChildIndex(Me.rdoPXK, 0)
        Me.Controls.SetChildIndex(Me.rdoPXKHanggiuho, 0)
        Me.Controls.SetChildIndex(Me.SoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.rdoTaiXuatGTGT, 0)
        Me.Controls.SetChildIndex(Me.rdoTaiXuatGTGT1, 0)
        Me.Controls.SetChildIndex(Me.rdoLenhXKTheoPhoi, 0)
        Me.Controls.SetChildIndex(Me.rdoPXK_NBN, 0)
        Me.Controls.SetChildIndex(Me.rdoPXK_CIF, 0)
        Me.Controls.SetChildIndex(Me.rdoLenhXuatKDD, 0)
        Me.Controls.SetChildIndex(Me.rdoLenhXuatKDDA4, 0)
        Me.Controls.SetChildIndex(Me.rdoHoaDonCT, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdoLenhXuat As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHoaDon As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTaiXuat As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPXK As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPXKHanggiuho As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SoLenh As U_TextBox.U_TextBox
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents U_CheckBox1 As U_TextBox.U_CheckBox
    Friend WithEvents rdoTaiXuatGTGT As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTaiXuatGTGT1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLenhXKTheoPhoi As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPXK_NBN As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPXK_CIF As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLenhXuatKDD As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLenhXuatKDDA4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHoaDonCT As System.Windows.Forms.RadioButton
End Class
