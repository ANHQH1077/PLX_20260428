<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearch
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
        Me.U_TextBox1 = New U_TextBox.U_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.U_TrueDBGrid1 = New U_TextBox.U_TrueDBGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnMultiCheck = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_TextBox1
        '
        Me.U_TextBox1.AllowInsert = True
        Me.U_TextBox1.AllowUpdate = True
        Me.U_TextBox1.AutoKeyFix = ""
        Me.U_TextBox1.AutoKeyName = ""
        Me.U_TextBox1.BindingSourceName = ""
        Me.U_TextBox1.ChangeFormStatus = True
        Me.U_TextBox1.CopyFromItem = ""
        Me.U_TextBox1.DefaultValue = ""
        Me.U_TextBox1.FieldName = ""
        Me.U_TextBox1.FieldType = ""
        Me.U_TextBox1.KeyInsert = ""
        Me.U_TextBox1.LinkLabel = ""
        Me.U_TextBox1.Location = New System.Drawing.Point(70, 12)
        Me.U_TextBox1.Name = "U_TextBox1"
        Me.U_TextBox1.NoUpdate = "N"
        Me.U_TextBox1.PrimaryKey = ""
        Me.U_TextBox1.Properties.AutoHeight = False
        Me.U_TextBox1.Required = ""
        Me.U_TextBox1.Size = New System.Drawing.Size(449, 26)
        Me.U_TextBox1.TabIndex = 0
        Me.U_TextBox1.TableName = ""
        Me.U_TextBox1.ToolTip = "NAME(U_TextBox) VIEW() TAB() FIELD ()"
        Me.U_TextBox1.UpdateIfNull = ""
        Me.U_TextBox1.UpdateWhenFormLock = False
        Me.U_TextBox1.UpperValue = False
        Me.U_TextBox1.ViewName = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 19)
        Me.Label1.TabIndex = 196
        Me.Label1.Text = "Giá trị"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.Location = New System.Drawing.Point(525, 9)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(88, 33)
        Me.SimpleButton7.TabIndex = 2
        Me.SimpleButton7.Text = "&Tìm kiếm"
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
        Me.U_TrueDBGrid1.Location = New System.Drawing.Point(3, 48)
        Me.U_TrueDBGrid1.MainView = Me.GridView1
        Me.U_TrueDBGrid1.Name = "U_TrueDBGrid1"
        Me.U_TrueDBGrid1.ObjectChild = False
        Me.U_TrueDBGrid1.OrderBy = ""
        Me.U_TrueDBGrid1.ParentItem = ""
        Me.U_TrueDBGrid1.Size = New System.Drawing.Size(610, 349)
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
        '
        'BtnMultiCheck
        '
        Me.BtnMultiCheck.Location = New System.Drawing.Point(525, 403)
        Me.BtnMultiCheck.Name = "BtnMultiCheck"
        Me.BtnMultiCheck.Size = New System.Drawing.Size(79, 23)
        Me.BtnMultiCheck.TabIndex = 197
        Me.BtnMultiCheck.Text = "&Chọn"
        '
        'FrmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 402)
        Me.Controls.Add(Me.BtnMultiCheck)
        Me.Controls.Add(Me.U_TrueDBGrid1)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.U_TextBox1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(632, 469)
        Me.MinimizeBox = False
        Me.Name = "FrmSearch"
        Me.Text = "Tìm kiếm"
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents U_TextBox1 As U_TextBox.U_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents U_TrueDBGrid1 As U_TextBox.U_TrueDBGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnMultiCheck As DevExpress.XtraEditors.SimpleButton
End Class
