<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReport
    'Inherits DevExpress.XtraEditors.XtraForm
    Inherits U_Form.XtraForm1

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
        Me.LabelRpt = New System.Windows.Forms.Label()
        Me.ReportName = New U_TextBox.U_TextBox()
        Me.ReportCode = New U_TextBox.U_ButtonEdit()
        Me.U_ProName = New U_TextBox.U_TextBox()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ReportName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ProName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelRpt
        '
        Me.LabelRpt.AutoSize = True
        Me.LabelRpt.Location = New System.Drawing.Point(29, 10)
        Me.LabelRpt.Name = "LabelRpt"
        Me.LabelRpt.Size = New System.Drawing.Size(45, 13)
        Me.LabelRpt.TabIndex = 292
        Me.LabelRpt.Text = "Báo cáo"
        '
        'ReportName
        '
        Me.ReportName.ChangeFormStatus = True
        Me.ReportName.CopyFromItem = ""
        Me.ReportName.FieldName = ""
        Me.ReportName.FieldType = "C"
        Me.ReportName.KeyInsert = ""
        Me.ReportName.Location = New System.Drawing.Point(202, 7)
        Me.ReportName.Name = "ReportName"
        Me.ReportName.NoUpdate = "N"
        Me.ReportName.PrimaryKey = ""
        Me.ReportName.Properties.ReadOnly = True
        Me.ReportName.Required = ""
        Me.ReportName.Size = New System.Drawing.Size(312, 20)
        Me.ReportName.TabIndex = 1
        Me.ReportName.TableName = ""
        Me.ReportName.UpdateIfNull = ""
        Me.ReportName.UpdateWhenFormLock = False
        Me.ReportName.ViewName = ""
        '
        'ReportCode
        '
        Me.ReportCode.ChangeFormStatus = True
        Me.ReportCode.CopyFromItem = ""
        Me.ReportCode.FieldName = ""
        Me.ReportCode.FieldType = "C"
        Me.ReportCode.ItemReturn1 = "ReportName"
        Me.ReportCode.ItemReturn2 = "U_ProName"
        Me.ReportCode.ItemReturn3 = ""
        Me.ReportCode.KeyInsert = ""
        Me.ReportCode.Location = New System.Drawing.Point(96, 7)
        Me.ReportCode.Name = "ReportCode"
        Me.ReportCode.NoUpdate = "N"
        Me.ReportCode.PrimaryKey = ""
        Me.ReportCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ReportCode.Properties.ReadOnly = True
        Me.ReportCode.Properties.Tag = ""
        Me.ReportCode.Required = "Y"
        Me.ReportCode.ShowLoad = True
        Me.ReportCode.Size = New System.Drawing.Size(100, 20)
        Me.ReportCode.SqlFielKey = "Code"
        Me.ReportCode.SqlString = "select Code, Name, U_ProName  from  [FPTORPT]  where U_Status='Y'"
        Me.ReportCode.TabIndex = 0
        Me.ReportCode.TableName = ""
        Me.ReportCode.UpdateIfNull = ""
        Me.ReportCode.UpdateWhenFormLock = False
        Me.ReportCode.ViewName = ""
        '
        'U_ProName
        '
        Me.U_ProName.ChangeFormStatus = True
        Me.U_ProName.CopyFromItem = ""
        Me.U_ProName.FieldName = ""
        Me.U_ProName.FieldType = "C"
        Me.U_ProName.KeyInsert = ""
        Me.U_ProName.Location = New System.Drawing.Point(473, 33)
        Me.U_ProName.Name = "U_ProName"
        Me.U_ProName.NoUpdate = "N"
        Me.U_ProName.PrimaryKey = ""
        Me.U_ProName.Properties.ReadOnly = True
        Me.U_ProName.Required = ""
        Me.U_ProName.Size = New System.Drawing.Size(0, 20)
        Me.U_ProName.TabIndex = 305
        Me.U_ProName.TableName = ""
        Me.U_ProName.ToolTip = "NAME(U_TextBox) VIEW() TAB() FIELD ()"
        Me.U_ProName.UpdateIfNull = ""
        Me.U_ProName.UpdateWhenFormLock = False
        Me.U_ProName.ViewName = ""
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(520, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 330
        Me.btnOK.Text = "&Xem báo cáo"
        '
        'FrmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ' Me.AutoScroll = True
        Me.AutoScrollMargin = New System.Drawing.Size(0, 10)
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(631, 356)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.U_ProName)
        Me.Controls.Add(Me.LabelRpt)
        Me.Controls.Add(Me.ReportName)
        Me.Controls.Add(Me.ReportCode)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(400, 180)
        Me.Name = "FrmReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Báo cáo"
        CType(Me.ReportName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ProName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportCode As U_TextBox.U_ButtonEdit
    Friend WithEvents ReportName As U_TextBox.U_TextBox
    Friend WithEvents LabelRpt As System.Windows.Forms.Label
    Friend WithEvents U_ProName As U_TextBox.U_TextBox
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
End Class
