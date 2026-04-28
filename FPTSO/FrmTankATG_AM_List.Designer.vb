<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankATG_AM_List
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
        Me.TankList = New U_TextBox.U_ButtonEdit()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Client = New U_TextBox.U_ButtonEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TankList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(33, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 19)
        Me.Label7.TabIndex = 494
        Me.Label7.Text = "Bể đo"
        '
        'TankList
        '
        Me.TankList.AllowInsert = True
        Me.TankList.AllowUpdate = True
        Me.TankList.AutoWidth = False
        Me.TankList.BindingSourceName = ""
        Me.TankList.ChangeFormStatus = True
        Me.TankList.CopyFromItem = ""
        Me.TankList.DefaultButtonClick = True
        Me.TankList.DefaultValue = ""
        Me.TankList.FieldName = ""
        Me.TankList.FieldType = "C"
        Me.TankList.FormList = True
        Me.TankList.ItemReturn1 = ""
        Me.TankList.ItemReturn2 = ""
        Me.TankList.ItemReturn3 = ""
        Me.TankList.KeyInsert = ""
        Me.TankList.LinkLabel = ""
        Me.TankList.Location = New System.Drawing.Point(87, 40)
        Me.TankList.MultiSelect = False
        Me.TankList.Name = "TankList"
        Me.TankList.NoUpdate = "N"
        Me.TankList.OrderbyEx = ""
        Me.TankList.PrimaryKey = ""
        Me.TankList.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankList.Properties.Appearance.Options.UseFont = True
        Me.TankList.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankList.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TankList.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankList.Properties.AppearanceFocused.Options.UseFont = True
        Me.TankList.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankList.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TankList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TankList.Required = ""
        Me.TankList.ShowLoad = True
        Me.TankList.Size = New System.Drawing.Size(150, 26)
        Me.TankList.SqlFielKey = ""
        Me.TankList.SqlString = ""
        Me.TankList.TabIndex = 1
        Me.TankList.TableName = ""
        Me.TankList.UpdateIfNull = ""
        Me.TankList.UpdateWhenFormLock = False
        Me.TankList.UpperValue = True
        Me.TankList.ValidateValue = False
        Me.TankList.ViewName = ""
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(166, 80)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(110, 33)
        Me.U_ButtonCus1.TabIndex = 2
        Me.U_ButtonCus1.Text = "&1. Thực hiện"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 19)
        Me.Label1.TabIndex = 497
        Me.Label1.Text = "Kho"
        '
        'Client
        '
        Me.Client.AllowInsert = True
        Me.Client.AllowUpdate = True
        Me.Client.AutoWidth = False
        Me.Client.BindingSourceName = ""
        Me.Client.ChangeFormStatus = True
        Me.Client.CopyFromItem = ""
        Me.Client.DefaultButtonClick = True
        Me.Client.DefaultValue = ""
        Me.Client.FieldName = ""
        Me.Client.FieldType = ""
        Me.Client.FormList = True
        Me.Client.ItemReturn1 = ""
        Me.Client.ItemReturn2 = ""
        Me.Client.ItemReturn3 = ""
        Me.Client.KeyInsert = ""
        Me.Client.LinkLabel = ""
        Me.Client.Location = New System.Drawing.Point(87, 8)
        Me.Client.MultiSelect = False
        Me.Client.Name = "Client"
        Me.Client.NoUpdate = "N"
        Me.Client.OrderbyEx = ""
        Me.Client.PrimaryKey = ""
        Me.Client.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.Appearance.Options.UseFont = True
        Me.Client.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceDisabled.Options.UseFont = True
        Me.Client.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceFocused.Options.UseFont = True
        Me.Client.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Client.Required = ""
        Me.Client.ShowLoad = True
        Me.Client.Size = New System.Drawing.Size(83, 26)
        Me.Client.SqlFielKey = "Kho"
        Me.Client.SqlString = ""
        Me.Client.TabIndex = 0
        Me.Client.TableName = ""
        Me.Client.UpdateIfNull = ""
        Me.Client.UpdateWhenFormLock = False
        Me.Client.UpperValue = True
        Me.Client.ValidateValue = False
        Me.Client.ViewName = ""
        '
        'FrmTankATG_AM_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 142)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Client)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TankList)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTankATG_AM_List"
        Me.Text = "Đồng bộ TBĐMTĐ chuyển đo tay"
        Me.Controls.SetChildIndex(Me.TankList, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.Client, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TankList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TankList As U_TextBox.U_ButtonEdit
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Client As U_TextBox.U_ButtonEdit
End Class
