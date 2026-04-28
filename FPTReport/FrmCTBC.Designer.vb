<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCTBC
    Inherits U_Form.XtraForm1

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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.btnOK = New U_TextBox.U_Button(Me.components)
        Me.MABC = New U_TextBox.U_TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.U_TextBox2 = New U_TextBox.U_TextBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.U_TextBox3 = New U_TextBox.U_TextBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.U_TextBox4 = New U_TextBox.U_TextBox()
        CType(Me.p_XtraBindingSourceHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.MABC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_TrueDBGrid1
        '
        Me.U_TrueDBGrid1.AllowInsert = "Y"
        Me.U_TrueDBGrid1.ColumnAutoWidth = "Y"
        Me.U_TrueDBGrid1.ColumnEnableUpdate = "A"
        Me.U_TrueDBGrid1.ColumnKey = "N"
        Me.U_TrueDBGrid1.ColumnKeyIns = "N"
        Me.U_TrueDBGrid1.ColumnKeyType = "N"
        Me.U_TrueDBGrid1.ColumnVisibleUpdate = "A"
        Me.U_TrueDBGrid1.LastQuery = Nothing
        Me.U_TrueDBGrid1.LoadFromStored = False
        Me.U_TrueDBGrid1.Location = New System.Drawing.Point(-1, 3)
        Me.U_TrueDBGrid1.MainView = Me.GridView1
        Me.U_TrueDBGrid1.Name = "U_TrueDBGrid1"
        Me.U_TrueDBGrid1.ObjectChild = True
        Me.U_TrueDBGrid1.OrderBy = ""
        Me.U_TrueDBGrid1.ParentItem = ""
        Me.U_TrueDBGrid1.Size = New System.Drawing.Size(939, 440)
        Me.U_TrueDBGrid1.TabIndex = 0
        Me.U_TrueDBGrid1.TableName = "RPTCTBC1"
        Me.U_TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.U_TrueDBGrid1.ViewName = "RPTCTBC1"
        Me.U_TrueDBGrid1.Where = "MABC = :MABC"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.U_TrueDBGrid1
        Me.GridView1.Name = "GridView1"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(2, 59)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(944, 472)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.U_TrueDBGrid1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(938, 446)
        Me.XtraTabPage1.Text = "XtraTabPage1"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(938, 446)
        Me.XtraTabPage2.Text = "XtraTabPage2"
        '
        'btnOK
        '
        Me.btnOK.DefaultUpdate = True
        Me.btnOK.Location = New System.Drawing.Point(12, 537)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 443
        Me.btnOK.Text = "&1. Thêm mới"
        '
        'MABC
        '
        Me.MABC.ChangeFormStatus = True
        Me.MABC.CopyFromItem = ""
        Me.MABC.FieldName = "MABC"
        Me.MABC.FieldType = "C"
        Me.MABC.KeyInsert = ""
        Me.MABC.Location = New System.Drawing.Point(86, 12)
        Me.MABC.Name = "MABC"
        Me.MABC.NoUpdate = "N"
        Me.MABC.PrimaryKey = "Y"
        Me.MABC.Required = "Y"
        Me.MABC.Size = New System.Drawing.Size(105, 20)
        Me.MABC.TabIndex = 444
        Me.MABC.TableName = "RPTCTBC"
        Me.MABC.UpdateIfNull = ""
        Me.MABC.UpdateWhenFormLock = False
        Me.MABC.ViewName = "RPTCTBC"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl1.TabIndex = 445
        Me.LabelControl1.Text = "Mã báo cáo"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl2.TabIndex = 447
        Me.LabelControl2.Text = "Tên báo cáo"
        '
        'U_TextBox2
        '
        Me.U_TextBox2.ChangeFormStatus = True
        Me.U_TextBox2.CopyFromItem = ""
        Me.U_TextBox2.FieldName = "TENBC"
        Me.U_TextBox2.FieldType = "C"
        Me.U_TextBox2.KeyInsert = ""
        Me.U_TextBox2.Location = New System.Drawing.Point(86, 33)
        Me.U_TextBox2.Name = "U_TextBox2"
        Me.U_TextBox2.NoUpdate = "N"
        Me.U_TextBox2.PrimaryKey = ""
        Me.U_TextBox2.Required = "Y"
        Me.U_TextBox2.Size = New System.Drawing.Size(319, 20)
        Me.U_TextBox2.TabIndex = 446
        Me.U_TextBox2.TableName = "RPTCTBC"
        Me.U_TextBox2.UpdateIfNull = ""
        Me.U_TextBox2.UpdateWhenFormLock = False
        Me.U_TextBox2.ViewName = "RPTCTBC"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(682, 33)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl3.TabIndex = 451
        Me.LabelControl3.Text = "Ngày hết hiệu lực"
        '
        'U_TextBox3
        '
        Me.U_TextBox3.ChangeFormStatus = True
        Me.U_TextBox3.CopyFromItem = ""
        Me.U_TextBox3.FieldName = "NGAYHETHL"
        Me.U_TextBox3.FieldType = "D"
        Me.U_TextBox3.KeyInsert = ""
        Me.U_TextBox3.Location = New System.Drawing.Point(777, 33)
        Me.U_TextBox3.Name = "U_TextBox3"
        Me.U_TextBox3.NoUpdate = "N"
        Me.U_TextBox3.PrimaryKey = ""
        Me.U_TextBox3.Required = ""
        Me.U_TextBox3.Size = New System.Drawing.Size(160, 20)
        Me.U_TextBox3.TabIndex = 450
        Me.U_TextBox3.TableName = "RPTCTBC"
        Me.U_TextBox3.UpdateIfNull = ""
        Me.U_TextBox3.UpdateWhenFormLock = False
        Me.U_TextBox3.ViewName = "RPTCTBC"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(682, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl4.TabIndex = 449
        Me.LabelControl4.Text = "Ngày hiệu lực"
        '
        'U_TextBox4
        '
        Me.U_TextBox4.ChangeFormStatus = True
        Me.U_TextBox4.CopyFromItem = ""
        Me.U_TextBox4.FieldName = "NGAYHL"
        Me.U_TextBox4.FieldType = "D"
        Me.U_TextBox4.KeyInsert = ""
        Me.U_TextBox4.Location = New System.Drawing.Point(777, 12)
        Me.U_TextBox4.Name = "U_TextBox4"
        Me.U_TextBox4.NoUpdate = "N"
        Me.U_TextBox4.PrimaryKey = ""
        Me.U_TextBox4.Required = ""
        Me.U_TextBox4.Size = New System.Drawing.Size(160, 20)
        Me.U_TextBox4.TabIndex = 448
        Me.U_TextBox4.TableName = "RPTCTBC"
        Me.U_TextBox4.UpdateIfNull = ""
        Me.U_TextBox4.UpdateWhenFormLock = False
        Me.U_TextBox4.ViewName = "RPTCTBC"
        '
        'FrmCTBC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 566)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.U_TextBox3)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.U_TextBox4)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.U_TextBox2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MABC)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.DefaultWhere = "where MABC = """""
        Me.Name = "FrmCTBC"
        Me.SetSourceItem = True
        Me.Text = "Cấu trúc báo cáo"
        CType(Me.p_XtraBindingSourceHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.MABC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents U_TrueDBGrid1 As U_TextBox.U_TrueDBGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnOK As U_TextBox.U_Button
    Friend WithEvents MABC As U_TextBox.U_TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents U_TextBox2 As U_TextBox.U_TextBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents U_TextBox3 As U_TextBox.U_TextBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents U_TextBox4 As U_TextBox.U_TextBox
End Class
