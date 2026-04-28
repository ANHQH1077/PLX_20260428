<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenu
    Inherits U_CusForm.XtraCusForm1

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
        Me.components = New System.ComponentModel.Container()
        Me.U_TrueDBGrid1 = New U_TextBox.U_TrueDBGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnOk = New U_TextBox.U_Button(Me.components)
        Me.U_TextBox6 = New U_TextBox.U_TextBox()
        Me.U_TextBox2 = New U_TextBox.U_TextBox()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.U_DateEdit2 = New U_TextBox.U_DateEdit()
        Me.U_DateEdit1 = New U_TextBox.U_DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.MENU_ID = New U_TextBox.U_TextBox()
        Me.U_TextBox4 = New U_TextBox.U_TextBox()
        Me.MENU_NAME = New U_TextBox.U_TextBox()
        Me.MENU_CODE = New U_TextBox.U_TextBox()
        ' CType(Me.p_XtraBindingSourceHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateEdit2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENU_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENU_NAME.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENU_CODE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_TrueDBGrid1
        '
        Me.U_TrueDBGrid1.AllowInsert = "Y"
        Me.U_TrueDBGrid1.ColumnAutoWidth = "Y"
        Me.U_TrueDBGrid1.ColumnEnableUpdate = "A"
        Me.U_TrueDBGrid1.ColumnKey = "RESPONSIBILITY_MENU_ID"
        Me.U_TrueDBGrid1.ColumnKeyIns = "N"
        Me.U_TrueDBGrid1.ColumnKeyType = "N"
        Me.U_TrueDBGrid1.ColumnVisibleUpdate = "A"
        Me.U_TrueDBGrid1.LastQuery = Nothing
        Me.U_TrueDBGrid1.LoadFromStored = False
        Me.U_TrueDBGrid1.Location = New System.Drawing.Point(3, 112)
        Me.U_TrueDBGrid1.MainView = Me.GridView1
        Me.U_TrueDBGrid1.Name = "U_TrueDBGrid1"
        Me.U_TrueDBGrid1.ObjectChild = True
        Me.U_TrueDBGrid1.OrderBy = "ORDER_NUM"
        Me.U_TrueDBGrid1.ParentItem = ""
        Me.U_TrueDBGrid1.Size = New System.Drawing.Size(773, 327)
        Me.U_TrueDBGrid1.TabIndex = 5
        Me.U_TrueDBGrid1.TableName = "SYS_RESPONSIBILITY_MENU"
        Me.U_TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.U_TrueDBGrid1.ViewName = "SYS_RESPONSIBILITY_MENU_V"
        Me.U_TrueDBGrid1.Where = "MENU_CODE=:MENU_CODE"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.U_TrueDBGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'BtnOk
        '
        Me.BtnOk.DefaultUpdate = True
        Me.BtnOk.Location = New System.Drawing.Point(7, 445)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnOk.TabIndex = 1
        Me.BtnOk.Text = "Ok"
        '
        'U_TextBox6
        '
        Me.U_TextBox6.ChangeFormStatus = True
        Me.U_TextBox6.CopyFromItem = ""
        Me.U_TextBox6.FieldName = "IP_ADDRESS"
        Me.U_TextBox6.FieldType = "C"
        Me.U_TextBox6.KeyInsert = ""
        Me.U_TextBox6.Location = New System.Drawing.Point(318, 86)
        Me.U_TextBox6.Name = "U_TextBox6"
        Me.U_TextBox6.NoUpdate = "N"
        Me.U_TextBox6.PrimaryKey = ""
        Me.U_TextBox6.Required = ""
        Me.U_TextBox6.Size = New System.Drawing.Size(230, 20)
        Me.U_TextBox6.TabIndex = 118
        Me.U_TextBox6.TableName = "SYS_MENU"
        Me.U_TextBox6.ToolTip = "NAME(U_TextBox) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (IP_ADDRESS)"
        Me.U_TextBox6.UpdateIfNull = ""
        Me.U_TextBox6.UpdateWhenFormLock = False
        Me.U_TextBox6.ViewName = "SYS_MENU"
        Me.U_TextBox6.Visible = False
        '
        'U_TextBox2
        '
        Me.U_TextBox2.ChangeFormStatus = True
        Me.U_TextBox2.CopyFromItem = ""
        Me.U_TextBox2.FieldName = "WORK_STATION"
        Me.U_TextBox2.FieldType = "C"
        Me.U_TextBox2.KeyInsert = ""
        Me.U_TextBox2.Location = New System.Drawing.Point(332, 65)
        Me.U_TextBox2.Name = "U_TextBox2"
        Me.U_TextBox2.NoUpdate = "N"
        Me.U_TextBox2.PrimaryKey = ""
        Me.U_TextBox2.Required = ""
        Me.U_TextBox2.Size = New System.Drawing.Size(230, 20)
        Me.U_TextBox2.TabIndex = 117
        Me.U_TextBox2.TableName = "SYS_MENU"
        Me.U_TextBox2.ToolTip = "NAME(U_TextBox) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (WORK_STATION)"
        Me.U_TextBox2.UpdateIfNull = ""
        Me.U_TextBox2.UpdateWhenFormLock = False
        Me.U_TextBox2.ViewName = "SYS_MENU"
        Me.U_TextBox2.Visible = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 89)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl5.TabIndex = 116
        Me.LabelControl5.Text = "Ngày hết hiệu lực"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 68)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl4.TabIndex = 115
        Me.LabelControl4.Text = "Ngày hiệu lực"
        '
        'U_DateEdit2
        '
        Me.U_DateEdit2.ChangeFormStatus = True
        Me.U_DateEdit2.CopyFromItem = ""
        Me.U_DateEdit2.EditValue = Nothing
        Me.U_DateEdit2.FieldName = "TO_DATE"
        Me.U_DateEdit2.FieldType = "D"
        Me.U_DateEdit2.KeyInsert = ""
        Me.U_DateEdit2.Location = New System.Drawing.Point(110, 86)
        Me.U_DateEdit2.Name = "U_DateEdit2"
        Me.U_DateEdit2.NoUpdate = ""
        Me.U_DateEdit2.PrimaryKey = ""
        Me.U_DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_DateEdit2.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_DateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_DateEdit2.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_DateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_DateEdit2.Required = ""
        Me.U_DateEdit2.Size = New System.Drawing.Size(151, 20)
        Me.U_DateEdit2.TabIndex = 4
        Me.U_DateEdit2.TableName = "SYS_MENU"
        Me.U_DateEdit2.ToolTip = "NAME(U_DateEdit2) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (TO_DATE)"
        Me.U_DateEdit2.UpdateIfNull = ""
        Me.U_DateEdit2.UpdateWhenFormLock = False
        Me.U_DateEdit2.ViewName = "SYS_MENU"
        '
        'U_DateEdit1
        '
        Me.U_DateEdit1.ChangeFormStatus = True
        Me.U_DateEdit1.CopyFromItem = ""
        Me.U_DateEdit1.EditValue = Nothing
        Me.U_DateEdit1.FieldName = "FROM_DATE"
        Me.U_DateEdit1.FieldType = "D"
        Me.U_DateEdit1.KeyInsert = ""
        Me.U_DateEdit1.Location = New System.Drawing.Point(110, 65)
        Me.U_DateEdit1.Name = "U_DateEdit1"
        Me.U_DateEdit1.NoUpdate = ""
        Me.U_DateEdit1.PrimaryKey = ""
        Me.U_DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_DateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_DateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_DateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_DateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_DateEdit1.Required = ""
        Me.U_DateEdit1.Size = New System.Drawing.Size(151, 20)
        Me.U_DateEdit1.TabIndex = 3
        Me.U_DateEdit1.TableName = "SYS_MENU"
        Me.U_DateEdit1.ToolTip = "NAME(U_DateEdit1) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (FROM_DATE)"
        Me.U_DateEdit1.UpdateIfNull = ""
        Me.U_DateEdit1.UpdateWhenFormLock = False
        Me.U_DateEdit1.ViewName = "SYS_MENU"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 47)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl3.TabIndex = 112
        Me.LabelControl3.Text = "Ghi chú"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 26)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl2.TabIndex = 111
        Me.LabelControl2.Text = "Tên Menu"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl1.TabIndex = 110
        Me.LabelControl1.Text = "Mã Menu"
        '
        'MENU_ID
        '
        Me.MENU_ID.ChangeFormStatus = True
        Me.MENU_ID.CopyFromItem = ""
        Me.MENU_ID.FieldName = "MENU_ID"
        Me.MENU_ID.FieldType = "N"
        Me.MENU_ID.KeyInsert = ""
        Me.MENU_ID.Location = New System.Drawing.Point(389, 2)
        Me.MENU_ID.Name = "MENU_ID"
        Me.MENU_ID.NoUpdate = "Y"
        Me.MENU_ID.PrimaryKey = "Y"
        Me.MENU_ID.Required = ""
        Me.MENU_ID.Size = New System.Drawing.Size(0, 20)
        Me.MENU_ID.TabIndex = 109
        Me.MENU_ID.TableName = "SYS_MENU"
        Me.MENU_ID.ToolTip = "NAME(U_TextBox) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (MENU_ID)"
        Me.MENU_ID.UpdateIfNull = ""
        Me.MENU_ID.UpdateWhenFormLock = False
        Me.MENU_ID.ViewName = "SYS_MENU"
        '
        'U_TextBox4
        '
        Me.U_TextBox4.ChangeFormStatus = True
        Me.U_TextBox4.CopyFromItem = ""
        Me.U_TextBox4.FieldName = "DESCRIPTION"
        Me.U_TextBox4.FieldType = "C"
        Me.U_TextBox4.KeyInsert = ""
        Me.U_TextBox4.Location = New System.Drawing.Point(110, 44)
        Me.U_TextBox4.Name = "U_TextBox4"
        Me.U_TextBox4.NoUpdate = "N"
        Me.U_TextBox4.PrimaryKey = ""
        Me.U_TextBox4.Required = ""
        Me.U_TextBox4.Size = New System.Drawing.Size(509, 20)
        Me.U_TextBox4.TabIndex = 2
        Me.U_TextBox4.TableName = "SYS_MENU"
        Me.U_TextBox4.ToolTip = "NAME(U_TextBox) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (DESCRIPTION)"
        Me.U_TextBox4.UpdateIfNull = ""
        Me.U_TextBox4.UpdateWhenFormLock = False
        Me.U_TextBox4.ViewName = "SYS_MENU"
        '
        'MENU_NAME
        '
        Me.MENU_NAME.ChangeFormStatus = True
        Me.MENU_NAME.CopyFromItem = ""
        Me.MENU_NAME.FieldName = "MENU_NAME"
        Me.MENU_NAME.FieldType = "C"
        Me.MENU_NAME.KeyInsert = ""
        Me.MENU_NAME.Location = New System.Drawing.Point(110, 23)
        Me.MENU_NAME.Name = "MENU_NAME"
        Me.MENU_NAME.NoUpdate = "N"
        Me.MENU_NAME.PrimaryKey = ""
        Me.MENU_NAME.Required = "Y"
        Me.MENU_NAME.Size = New System.Drawing.Size(509, 20)
        Me.MENU_NAME.TabIndex = 1
        Me.MENU_NAME.TableName = "SYS_MENU"
        Me.MENU_NAME.ToolTip = "NAME(U_TextBox) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (MENU_NAME)"
        Me.MENU_NAME.UpdateIfNull = ""
        Me.MENU_NAME.UpdateWhenFormLock = False
        Me.MENU_NAME.ViewName = "SYS_MENU"
        '
        'MENU_CODE
        '
        Me.MENU_CODE.ChangeFormStatus = True
        Me.MENU_CODE.CopyFromItem = ""
        Me.MENU_CODE.FieldName = "MENU_CODE"
        Me.MENU_CODE.FieldType = "C"
        Me.MENU_CODE.KeyInsert = "Y"
        Me.MENU_CODE.Location = New System.Drawing.Point(110, 2)
        Me.MENU_CODE.Name = "MENU_CODE"
        Me.MENU_CODE.NoUpdate = "Y"
        Me.MENU_CODE.PrimaryKey = "Y"
        Me.MENU_CODE.Required = "Y"
        Me.MENU_CODE.Size = New System.Drawing.Size(151, 20)
        Me.MENU_CODE.TabIndex = 0
        Me.MENU_CODE.TableName = "SYS_MENU"
        Me.MENU_CODE.TabStop = False
        Me.MENU_CODE.ToolTip = "NAME(U_TextBox) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (MENU_CODE)"
        Me.MENU_CODE.UpdateIfNull = "Y"
        Me.MENU_CODE.UpdateWhenFormLock = False
        Me.MENU_CODE.ViewName = "SYS_MENU"
        '
        'FrmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionAdd = "Ok"
        Me.ClientSize = New System.Drawing.Size(779, 474)
        Me.Controls.Add(Me.U_TextBox6)
        Me.Controls.Add(Me.U_TextBox2)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.U_DateEdit2)
        Me.Controls.Add(Me.U_DateEdit1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MENU_ID)
        Me.Controls.Add(Me.U_TextBox4)
        Me.Controls.Add(Me.MENU_NAME)
        Me.Controls.Add(Me.MENU_CODE)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.U_TrueDBGrid1)
        Me.FormItemKey = "MENU_CODE"
        Me.HeaderSource = "SYS_MENU"
        Me.Name = "FrmMenu"
        Me.SetSourceItem = True
        Me.Text = "Danh sách Menu"
        'CType(Me.p_XtraBindingSourceHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateEdit2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENU_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENU_NAME.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENU_CODE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents U_TrueDBGrid1 As U_TextBox.U_TrueDBGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnOk As U_TextBox.U_Button
    Friend WithEvents U_TextBox6 As U_TextBox.U_TextBox
    Friend WithEvents U_TextBox2 As U_TextBox.U_TextBox
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents U_DateEdit2 As U_TextBox.U_DateEdit
    Friend WithEvents U_DateEdit1 As U_TextBox.U_DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENU_ID As U_TextBox.U_TextBox
    Friend WithEvents U_TextBox4 As U_TextBox.U_TextBox
    Friend WithEvents MENU_NAME As U_TextBox.U_TextBox
    Friend WithEvents MENU_CODE As U_TextBox.U_TextBox
End Class
