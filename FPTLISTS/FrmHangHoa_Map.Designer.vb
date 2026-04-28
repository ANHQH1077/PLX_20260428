<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHangHoa_Map
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
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.STT = New U_TextBox.GridColumn()
        Me.MaHangHoa_Sap = New U_TextBox.GridColumn()
        Me.TenHangHoa_Scada = New U_TextBox.GridColumn()
        Me.MaHangHoa_Scada = New U_TextBox.GridColumn()
        Me.ID = New U_TextBox.GridColumn()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(5, 4)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(537, 421)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.STT, Me.MaHangHoa_Sap, Me.TenHangHoa_Scada, Me.MaHangHoa_Scada, Me.ID})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "STT"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblMap_MaHangHoa"
        Me.GridView1.ViewName = "tblMap_MaHangHoa"
        Me.GridView1.Where = Nothing
        '
        'STT
        '
        Me.STT.AllowInsert = True
        Me.STT.AllowUpdate = True
        Me.STT.ButtonClick = True
        Me.STT.Caption = "STT"
        Me.STT.CFLColumnHide = ""
        Me.STT.CFLKeyField = ""
        Me.STT.CFLPage = False
        Me.STT.CFLReturn0 = ""
        Me.STT.CFLReturn1 = ""
        Me.STT.CFLReturn2 = ""
        Me.STT.CFLReturn3 = ""
        Me.STT.CFLReturn4 = ""
        Me.STT.CFLReturn5 = ""
        Me.STT.CFLReturn6 = ""
        Me.STT.CFLReturn7 = ""
        Me.STT.CFLShowLoad = False
        Me.STT.ChangeFormStatus = True
        Me.STT.ColumnKey = False
        Me.STT.ComboLine = 5
        Me.STT.CopyFromItem = ""
        Me.STT.DefaultButtonClick = False
        Me.STT.Digit = False
        Me.STT.FieldType = "C"
        Me.STT.FieldView = "STT"
        Me.STT.FormarNumber = True
        Me.STT.FormList = False
        Me.STT.KeyInsert = ""
        Me.STT.LocalDecimal = False
        Me.STT.Name = "STT"
        Me.STT.NoUpdate = ""
        Me.STT.NumberDecimal = 0
        Me.STT.ParentControl = ""
        Me.STT.RefreshSource = False
        Me.STT.Required = False
        Me.STT.SequenceName = ""
        Me.STT.ShowCalc = True
        Me.STT.ShowDataTime = False
        Me.STT.ShowOnlyTime = False
        Me.STT.SQLString = ""
        Me.STT.UpdateIfNull = ""
        Me.STT.UpdateWhenFormLock = False
        Me.STT.UpperValue = False
        Me.STT.ValidateValue = True
        Me.STT.Visible = True
        Me.STT.VisibleIndex = 0
        '
        'MaHangHoa_Sap
        '
        Me.MaHangHoa_Sap.AllowInsert = True
        Me.MaHangHoa_Sap.AllowUpdate = True
        Me.MaHangHoa_Sap.ButtonClick = True
        Me.MaHangHoa_Sap.Caption = "Mã hàng hóa"
        Me.MaHangHoa_Sap.CFLColumnHide = ""
        Me.MaHangHoa_Sap.CFLKeyField = ""
        Me.MaHangHoa_Sap.CFLPage = False
        Me.MaHangHoa_Sap.CFLReturn0 = ""
        Me.MaHangHoa_Sap.CFLReturn1 = ""
        Me.MaHangHoa_Sap.CFLReturn2 = ""
        Me.MaHangHoa_Sap.CFLReturn3 = ""
        Me.MaHangHoa_Sap.CFLReturn4 = ""
        Me.MaHangHoa_Sap.CFLReturn5 = ""
        Me.MaHangHoa_Sap.CFLReturn6 = ""
        Me.MaHangHoa_Sap.CFLReturn7 = ""
        Me.MaHangHoa_Sap.CFLShowLoad = False
        Me.MaHangHoa_Sap.ChangeFormStatus = True
        Me.MaHangHoa_Sap.ColumnKey = False
        Me.MaHangHoa_Sap.ComboLine = 5
        Me.MaHangHoa_Sap.CopyFromItem = ""
        Me.MaHangHoa_Sap.DefaultButtonClick = False
        Me.MaHangHoa_Sap.Digit = False
        Me.MaHangHoa_Sap.FieldType = "C"
        Me.MaHangHoa_Sap.FieldView = "MaHangHoa_Sap"
        Me.MaHangHoa_Sap.FormarNumber = True
        Me.MaHangHoa_Sap.FormList = False
        Me.MaHangHoa_Sap.KeyInsert = ""
        Me.MaHangHoa_Sap.LocalDecimal = False
        Me.MaHangHoa_Sap.Name = "MaHangHoa_Sap"
        Me.MaHangHoa_Sap.NoUpdate = ""
        Me.MaHangHoa_Sap.NumberDecimal = 0
        Me.MaHangHoa_Sap.ParentControl = ""
        Me.MaHangHoa_Sap.RefreshSource = False
        Me.MaHangHoa_Sap.Required = False
        Me.MaHangHoa_Sap.SequenceName = ""
        Me.MaHangHoa_Sap.ShowCalc = True
        Me.MaHangHoa_Sap.ShowDataTime = False
        Me.MaHangHoa_Sap.ShowOnlyTime = False
        Me.MaHangHoa_Sap.SQLString = ""
        Me.MaHangHoa_Sap.UpdateIfNull = ""
        Me.MaHangHoa_Sap.UpdateWhenFormLock = False
        Me.MaHangHoa_Sap.UpperValue = False
        Me.MaHangHoa_Sap.ValidateValue = True
        Me.MaHangHoa_Sap.Visible = True
        Me.MaHangHoa_Sap.VisibleIndex = 1
        Me.MaHangHoa_Sap.Width = 100
        '
        'TenHangHoa_Scada
        '
        Me.TenHangHoa_Scada.AllowInsert = True
        Me.TenHangHoa_Scada.AllowUpdate = True
        Me.TenHangHoa_Scada.ButtonClick = True
        Me.TenHangHoa_Scada.Caption = "Tên hàng hóa"
        Me.TenHangHoa_Scada.CFLColumnHide = ""
        Me.TenHangHoa_Scada.CFLKeyField = ""
        Me.TenHangHoa_Scada.CFLPage = False
        Me.TenHangHoa_Scada.CFLReturn0 = ""
        Me.TenHangHoa_Scada.CFLReturn1 = ""
        Me.TenHangHoa_Scada.CFLReturn2 = ""
        Me.TenHangHoa_Scada.CFLReturn3 = ""
        Me.TenHangHoa_Scada.CFLReturn4 = ""
        Me.TenHangHoa_Scada.CFLReturn5 = ""
        Me.TenHangHoa_Scada.CFLReturn6 = ""
        Me.TenHangHoa_Scada.CFLReturn7 = ""
        Me.TenHangHoa_Scada.CFLShowLoad = False
        Me.TenHangHoa_Scada.ChangeFormStatus = True
        Me.TenHangHoa_Scada.ColumnKey = False
        Me.TenHangHoa_Scada.ComboLine = 5
        Me.TenHangHoa_Scada.CopyFromItem = ""
        Me.TenHangHoa_Scada.DefaultButtonClick = False
        Me.TenHangHoa_Scada.Digit = False
        Me.TenHangHoa_Scada.FieldType = "C"
        Me.TenHangHoa_Scada.FieldView = "TenHangHoa_Scada"
        Me.TenHangHoa_Scada.FormarNumber = True
        Me.TenHangHoa_Scada.FormList = False
        Me.TenHangHoa_Scada.KeyInsert = ""
        Me.TenHangHoa_Scada.LocalDecimal = False
        Me.TenHangHoa_Scada.Name = "TenHangHoa_Scada"
        Me.TenHangHoa_Scada.NoUpdate = ""
        Me.TenHangHoa_Scada.NumberDecimal = 0
        Me.TenHangHoa_Scada.ParentControl = ""
        Me.TenHangHoa_Scada.RefreshSource = False
        Me.TenHangHoa_Scada.Required = False
        Me.TenHangHoa_Scada.SequenceName = ""
        Me.TenHangHoa_Scada.ShowCalc = True
        Me.TenHangHoa_Scada.ShowDataTime = False
        Me.TenHangHoa_Scada.ShowOnlyTime = False
        Me.TenHangHoa_Scada.SQLString = ""
        Me.TenHangHoa_Scada.UpdateIfNull = ""
        Me.TenHangHoa_Scada.UpdateWhenFormLock = False
        Me.TenHangHoa_Scada.UpperValue = False
        Me.TenHangHoa_Scada.ValidateValue = True
        Me.TenHangHoa_Scada.Visible = True
        Me.TenHangHoa_Scada.VisibleIndex = 2
        Me.TenHangHoa_Scada.Width = 150
        '
        'MaHangHoa_Scada
        '
        Me.MaHangHoa_Scada.AllowInsert = True
        Me.MaHangHoa_Scada.AllowUpdate = True
        Me.MaHangHoa_Scada.ButtonClick = True
        Me.MaHangHoa_Scada.Caption = "Mã scadar"
        Me.MaHangHoa_Scada.CFLColumnHide = ""
        Me.MaHangHoa_Scada.CFLKeyField = ""
        Me.MaHangHoa_Scada.CFLPage = False
        Me.MaHangHoa_Scada.CFLReturn0 = ""
        Me.MaHangHoa_Scada.CFLReturn1 = ""
        Me.MaHangHoa_Scada.CFLReturn2 = ""
        Me.MaHangHoa_Scada.CFLReturn3 = ""
        Me.MaHangHoa_Scada.CFLReturn4 = ""
        Me.MaHangHoa_Scada.CFLReturn5 = ""
        Me.MaHangHoa_Scada.CFLReturn6 = ""
        Me.MaHangHoa_Scada.CFLReturn7 = ""
        Me.MaHangHoa_Scada.CFLShowLoad = False
        Me.MaHangHoa_Scada.ChangeFormStatus = True
        Me.MaHangHoa_Scada.ColumnKey = False
        Me.MaHangHoa_Scada.ComboLine = 5
        Me.MaHangHoa_Scada.CopyFromItem = ""
        Me.MaHangHoa_Scada.DefaultButtonClick = False
        Me.MaHangHoa_Scada.Digit = False
        Me.MaHangHoa_Scada.FieldType = "C"
        Me.MaHangHoa_Scada.FieldView = "MaHangHoa_Scada"
        Me.MaHangHoa_Scada.FormarNumber = True
        Me.MaHangHoa_Scada.FormList = False
        Me.MaHangHoa_Scada.KeyInsert = ""
        Me.MaHangHoa_Scada.LocalDecimal = False
        Me.MaHangHoa_Scada.Name = "MaHangHoa_Scada"
        Me.MaHangHoa_Scada.NoUpdate = ""
        Me.MaHangHoa_Scada.NumberDecimal = 0
        Me.MaHangHoa_Scada.ParentControl = ""
        Me.MaHangHoa_Scada.RefreshSource = False
        Me.MaHangHoa_Scada.Required = False
        Me.MaHangHoa_Scada.SequenceName = ""
        Me.MaHangHoa_Scada.ShowCalc = True
        Me.MaHangHoa_Scada.ShowDataTime = False
        Me.MaHangHoa_Scada.ShowOnlyTime = False
        Me.MaHangHoa_Scada.SQLString = ""
        Me.MaHangHoa_Scada.UpdateIfNull = ""
        Me.MaHangHoa_Scada.UpdateWhenFormLock = False
        Me.MaHangHoa_Scada.UpperValue = False
        Me.MaHangHoa_Scada.ValidateValue = True
        Me.MaHangHoa_Scada.Visible = True
        Me.MaHangHoa_Scada.VisibleIndex = 3
        Me.MaHangHoa_Scada.Width = 150
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.ButtonClick = True
        Me.ID.Caption = "ID"
        Me.ID.CFLColumnHide = ""
        Me.ID.CFLKeyField = ""
        Me.ID.CFLPage = False
        Me.ID.CFLReturn0 = ""
        Me.ID.CFLReturn1 = ""
        Me.ID.CFLReturn2 = ""
        Me.ID.CFLReturn3 = ""
        Me.ID.CFLReturn4 = ""
        Me.ID.CFLReturn5 = ""
        Me.ID.CFLReturn6 = ""
        Me.ID.CFLReturn7 = ""
        Me.ID.CFLShowLoad = False
        Me.ID.ChangeFormStatus = True
        Me.ID.ColumnKey = True
        Me.ID.ComboLine = 5
        Me.ID.CopyFromItem = ""
        Me.ID.DefaultButtonClick = False
        Me.ID.Digit = False
        Me.ID.FieldType = "C"
        Me.ID.FieldView = "ID"
        Me.ID.FormarNumber = True
        Me.ID.FormList = False
        Me.ID.KeyInsert = ""
        Me.ID.LocalDecimal = False
        Me.ID.Name = "ID"
        Me.ID.NoUpdate = ""
        Me.ID.NumberDecimal = 0
        Me.ID.OptionsColumn.ReadOnly = True
        Me.ID.ParentControl = ""
        Me.ID.RefreshSource = False
        Me.ID.Required = False
        Me.ID.SequenceName = ""
        Me.ID.ShowCalc = True
        Me.ID.ShowDataTime = False
        Me.ID.ShowOnlyTime = False
        Me.ID.SQLString = ""
        Me.ID.UpdateIfNull = ""
        Me.ID.UpdateWhenFormLock = False
        Me.ID.UpperValue = False
        Me.ID.ValidateValue = True
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = False
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(431, 431)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(103, 26)
        Me.U_ButtonCus1.TabIndex = 500
        Me.U_ButtonCus1.Text = "Lưu"
        '
        'FrmHangHoa_Map
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 469)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Name = "FrmHangHoa_Map"
        Me.ShowFormMessage = True
        Me.Text = "Danh mục hàng hóa-scadar"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents TenHangHoa_Scada As U_TextBox.GridColumn
    Friend WithEvents MaHangHoa_Scada As U_TextBox.GridColumn
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents STT As U_TextBox.GridColumn
    Friend WithEvents MaHangHoa_Sap As U_TextBox.GridColumn
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
End Class
