<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearchLov
    'Inherits System.Windows.Forms.Form
    Inherits DevExpress.XtraEditors.XtraForm



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
        Me.U_TrueDBGrid1 = New U_TextBox.U_TrueDBGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnMultiCheck = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.U_TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_TrueDBGrid1
        '
        Me.U_TrueDBGrid1.AllowInsert = "Y"
        Me.U_TrueDBGrid1.ColumnAutoWidth = "Y"
        Me.U_TrueDBGrid1.ColumnEnableUpdate = "A"
        Me.U_TrueDBGrid1.ColumnKey = ""
        Me.U_TrueDBGrid1.ColumnKeyIns = "Y"
        Me.U_TrueDBGrid1.ColumnKeyType = ""
        Me.U_TrueDBGrid1.ColumnVisibleUpdate = "A"
        Me.U_TrueDBGrid1.DefaultRemove = True
        Me.U_TrueDBGrid1.LastQuery = Nothing
        Me.U_TrueDBGrid1.LoadFromStored = False
        Me.U_TrueDBGrid1.Location = New System.Drawing.Point(3, 3)
        Me.U_TrueDBGrid1.MainView = Me.GridView1
        Me.U_TrueDBGrid1.Name = "U_TrueDBGrid1"
        Me.U_TrueDBGrid1.ObjectChild = False
        Me.U_TrueDBGrid1.OrderBy = ""
        Me.U_TrueDBGrid1.ParentItem = ""
        Me.U_TrueDBGrid1.Size = New System.Drawing.Size(229, 239)
        Me.U_TrueDBGrid1.TabIndex = 1
        Me.U_TrueDBGrid1.TableName = ""
        Me.U_TrueDBGrid1.UseEmbeddedNavigator = True
        Me.U_TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.U_TrueDBGrid1.ViewName = ""
        Me.U_TrueDBGrid1.Where = ""
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.U_TrueDBGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'BtnMultiCheck
        '
        Me.BtnMultiCheck.Location = New System.Drawing.Point(525, 403)
        Me.BtnMultiCheck.Name = "BtnMultiCheck"
        Me.BtnMultiCheck.Size = New System.Drawing.Size(79, 23)
        Me.BtnMultiCheck.TabIndex = 197
        Me.BtnMultiCheck.Text = "&Chọn"
        '
        'FrmSearchLov
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(235, 244)
        Me.Controls.Add(Me.BtnMultiCheck)
        Me.Controls.Add(Me.U_TrueDBGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(632, 469)
        Me.MinimizeBox = False
        Me.Name = "FrmSearchLov"
        Me.Text = "Tìm kiếm"
        CType(Me.U_TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents U_TrueDBGrid1 As U_TextBox.U_TrueDBGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnMultiCheck As DevExpress.XtraEditors.SimpleButton
End Class
