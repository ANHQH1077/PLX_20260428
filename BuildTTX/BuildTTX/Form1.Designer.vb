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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.U_IP = New System.Windows.Forms.TextBox()
        Me.U_Db = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.U_User = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.U_Pass = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.U_Proc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(22, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Build Ttx"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP Server"
        '
        'U_IP
        '
        Me.U_IP.Location = New System.Drawing.Point(130, 12)
        Me.U_IP.Name = "U_IP"
        Me.U_IP.Size = New System.Drawing.Size(198, 20)
        Me.U_IP.TabIndex = 2
        '
        'U_Db
        '
        Me.U_Db.Location = New System.Drawing.Point(130, 38)
        Me.U_Db.Name = "U_Db"
        Me.U_Db.Size = New System.Drawing.Size(198, 20)
        Me.U_Db.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Database"
        '
        'U_User
        '
        Me.U_User.Location = New System.Drawing.Point(130, 64)
        Me.U_User.Name = "U_User"
        Me.U_User.Size = New System.Drawing.Size(198, 20)
        Me.U_User.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "User Name"
        '
        'U_Pass
        '
        Me.U_Pass.Location = New System.Drawing.Point(130, 90)
        Me.U_Pass.Name = "U_Pass"
        Me.U_Pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.U_Pass.Size = New System.Drawing.Size(198, 20)
        Me.U_Pass.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Password"
        '
        'U_Proc
        '
        Me.U_Proc.Location = New System.Drawing.Point(130, 116)
        Me.U_Proc.Name = "U_Proc"
        Me.U_Proc.Size = New System.Drawing.Size(411, 20)
        Me.U_Proc.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Exec Procedure"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 237)
        Me.Controls.Add(Me.U_Proc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.U_Pass)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.U_User)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.U_Db)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.U_IP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents U_IP As System.Windows.Forms.TextBox
    Friend WithEvents U_Db As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents U_User As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents U_Pass As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents U_Proc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
