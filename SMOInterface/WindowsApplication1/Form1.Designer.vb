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
        Me.button6 = New System.Windows.Forms.Button()
        Me.txtToken = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'button6
        '
        Me.button6.Location = New System.Drawing.Point(27, 240)
        Me.button6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.button6.Name = "button6"
        Me.button6.Size = New System.Drawing.Size(198, 48)
        Me.button6.TabIndex = 27
        Me.button6.Text = "Gửi trạng thái lệnh xuất"
        Me.button6.UseVisualStyleBackColor = True
        '
        'txtToken
        '
        Me.txtToken.Location = New System.Drawing.Point(27, 134)
        Me.txtToken.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtToken.Multiline = True
        Me.txtToken.Name = "txtToken"
        Me.txtToken.Size = New System.Drawing.Size(1207, 95)
        Me.txtToken.TabIndex = 26
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(22, 95)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(89, 20)
        Me.label3.TabIndex = 25
        Me.label3.Text = "JWT Token"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(132, 54)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(228, 26)
        Me.txtPassword.TabIndex = 23
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(132, 14)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(228, 26)
        Me.txtUserName.TabIndex = 22
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(22, 59)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(78, 20)
        Me.label2.TabIndex = 21
        Me.label2.Text = "Password"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(22, 19)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(83, 20)
        Me.label1.TabIndex = 20
        Me.label1.Text = "Username"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(779, 19)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 48)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Đăng nhập"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1261, 608)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.button6)
        Me.Controls.Add(Me.txtToken)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents button6 As Button
    Private WithEvents txtToken As TextBox
    Private WithEvents label3 As Label
    Private WithEvents txtPassword As TextBox
    Private WithEvents txtUserName As TextBox
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Private WithEvents Button1 As Button
End Class
