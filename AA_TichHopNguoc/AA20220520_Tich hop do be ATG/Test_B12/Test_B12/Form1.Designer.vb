<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pDate = New System.Windows.Forms.DateTimePicker()
        Me.p_Tank = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ThoiDiem = New System.Windows.Forms.DateTimePicker()
        Me.ChieuCao = New System.Windows.Forms.TextBox()
        Me.NhietDo = New System.Windows.Forms.TextBox()
        Me.ChieuCaoNuoc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Kho = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(281, 296)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pDate
        '
        Me.pDate.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.pDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.pDate.Location = New System.Drawing.Point(128, 29)
        Me.pDate.Name = "pDate"
        Me.pDate.Size = New System.Drawing.Size(228, 22)
        Me.pDate.TabIndex = 1
        '
        'p_Tank
        '
        Me.p_Tank.Location = New System.Drawing.Point(128, 57)
        Me.p_Tank.Name = "p_Tank"
        Me.p_Tank.Size = New System.Drawing.Size(100, 22)
        Me.p_Tank.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Thời gian"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Bể xuất"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Chiều cao"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nhiệt độ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Chiều cao nước"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 17)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Thời điểm"
        '
        'ThoiDiem
        '
        Me.ThoiDiem.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.ThoiDiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ThoiDiem.Location = New System.Drawing.Point(128, 116)
        Me.ThoiDiem.Name = "ThoiDiem"
        Me.ThoiDiem.Size = New System.Drawing.Size(228, 22)
        Me.ThoiDiem.TabIndex = 4
        Me.ThoiDiem.Value = New Date(1900, 7, 4, 18, 29, 0, 0)
        '
        'ChieuCao
        '
        Me.ChieuCao.Location = New System.Drawing.Point(128, 146)
        Me.ChieuCao.Name = "ChieuCao"
        Me.ChieuCao.Size = New System.Drawing.Size(100, 22)
        Me.ChieuCao.TabIndex = 5
        '
        'NhietDo
        '
        Me.NhietDo.Location = New System.Drawing.Point(128, 174)
        Me.NhietDo.Name = "NhietDo"
        Me.NhietDo.Size = New System.Drawing.Size(100, 22)
        Me.NhietDo.TabIndex = 6
        '
        'ChieuCaoNuoc
        '
        Me.ChieuCaoNuoc.Location = New System.Drawing.Point(128, 200)
        Me.ChieuCaoNuoc.Name = "ChieuCaoNuoc"
        Me.ChieuCaoNuoc.Size = New System.Drawing.Size(100, 22)
        Me.ChieuCaoNuoc.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 17)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Plant"
        '
        'Kho
        '
        Me.Kho.Location = New System.Drawing.Point(128, 85)
        Me.Kho.Name = "Kho"
        Me.Kho.Size = New System.Drawing.Size(100, 22)
        Me.Kho.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 331)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Kho)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ThoiDiem)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChieuCaoNuoc)
        Me.Controls.Add(Me.NhietDo)
        Me.Controls.Add(Me.ChieuCao)
        Me.Controls.Add(Me.p_Tank)
        Me.Controls.Add(Me.pDate)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents pDate As DateTimePicker
    Friend WithEvents p_Tank As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ThoiDiem As DateTimePicker
    Friend WithEvents ChieuCao As TextBox
    Friend WithEvents NhietDo As TextBox
    Friend WithEvents ChieuCaoNuoc As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Kho As TextBox
End Class
