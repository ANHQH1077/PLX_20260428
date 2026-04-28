<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankATG
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTankATG))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ID = New U_TextBox.GridColumn()
        Me.Plant = New U_TextBox.GridColumn()
        Me.Client = New U_TextBox.GridColumn()
        Me.TankCode = New U_TextBox.GridColumn()
        Me.MinHeight = New U_TextBox.GridColumn()
        Me.MinVolume = New U_TextBox.GridColumn()
        Me.SafeHeight = New U_TextBox.GridColumn()
        Me.SafeVolume = New U_TextBox.GridColumn()
        Me.SynDate = New U_TextBox.GridColumn()
        Me.SynUser = New U_TextBox.GridColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(940, 377)
        Me.TrueDBGrid1.TabIndex = 2
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.Plant, Me.Client, Me.TankCode, Me.MinHeight, Me.MinVolume, Me.SafeHeight, Me.SafeVolume, Me.SynDate, Me.SynUser})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OrderBy = "Client, TankCode"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "ztblTankInfor"
        Me.GridView1.Where = Nothing
        '
        'ID
        '
        Me.ID.AllowInsert = True
        Me.ID.AllowUpdate = True
        Me.ID.ButtonClick = True
        Me.ID.Caption = "GridColumn1"
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
        Me.ID.FieldType = "N"
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
        Me.ID.Visible = True
        '
        'Plant
        '
        Me.Plant.AllowInsert = True
        Me.Plant.AllowUpdate = True
        Me.Plant.ButtonClick = True
        Me.Plant.Caption = "GridColumn3"
        Me.Plant.CFLColumnHide = ""
        Me.Plant.CFLKeyField = ""
        Me.Plant.CFLPage = False
        Me.Plant.CFLReturn0 = ""
        Me.Plant.CFLReturn1 = ""
        Me.Plant.CFLReturn2 = ""
        Me.Plant.CFLReturn3 = ""
        Me.Plant.CFLReturn4 = ""
        Me.Plant.CFLReturn5 = ""
        Me.Plant.CFLReturn6 = ""
        Me.Plant.CFLReturn7 = ""
        Me.Plant.CFLShowLoad = False
        Me.Plant.ChangeFormStatus = True
        Me.Plant.ColumnKey = False
        Me.Plant.ComboLine = 5
        Me.Plant.CopyFromItem = ""
        Me.Plant.DefaultButtonClick = False
        Me.Plant.Digit = False
        Me.Plant.FieldType = "C"
        Me.Plant.FieldView = "Plant"
        Me.Plant.FormarNumber = True
        Me.Plant.FormList = False
        Me.Plant.KeyInsert = ""
        Me.Plant.LocalDecimal = False
        Me.Plant.Name = "Plant"
        Me.Plant.NoUpdate = ""
        Me.Plant.NumberDecimal = 0
        Me.Plant.OptionsColumn.ReadOnly = True
        Me.Plant.ParentControl = ""
        Me.Plant.RefreshSource = False
        Me.Plant.Required = False
        Me.Plant.SequenceName = ""
        Me.Plant.ShowCalc = True
        Me.Plant.ShowDataTime = False
        Me.Plant.ShowOnlyTime = False
        Me.Plant.SQLString = ""
        Me.Plant.UpdateIfNull = ""
        Me.Plant.UpdateWhenFormLock = False
        Me.Plant.UpperValue = False
        Me.Plant.ValidateValue = True
        Me.Plant.Visible = True
        '
        'Client
        '
        Me.Client.AllowInsert = True
        Me.Client.AllowUpdate = True
        Me.Client.ButtonClick = True
        Me.Client.Caption = "Kho"
        Me.Client.CFLColumnHide = ""
        Me.Client.CFLKeyField = ""
        Me.Client.CFLPage = False
        Me.Client.CFLReturn0 = ""
        Me.Client.CFLReturn1 = ""
        Me.Client.CFLReturn2 = ""
        Me.Client.CFLReturn3 = ""
        Me.Client.CFLReturn4 = ""
        Me.Client.CFLReturn5 = ""
        Me.Client.CFLReturn6 = ""
        Me.Client.CFLReturn7 = ""
        Me.Client.CFLShowLoad = False
        Me.Client.ChangeFormStatus = True
        Me.Client.ColumnKey = False
        Me.Client.ComboLine = 5
        Me.Client.CopyFromItem = ""
        Me.Client.DefaultButtonClick = False
        Me.Client.Digit = False
        Me.Client.FieldType = "C"
        Me.Client.FieldView = "Client"
        Me.Client.FormarNumber = True
        Me.Client.FormList = False
        Me.Client.KeyInsert = ""
        Me.Client.LocalDecimal = False
        Me.Client.Name = "Client"
        Me.Client.NoUpdate = ""
        Me.Client.NumberDecimal = 0
        Me.Client.OptionsColumn.ReadOnly = True
        Me.Client.ParentControl = ""
        Me.Client.RefreshSource = False
        Me.Client.Required = False
        Me.Client.SequenceName = ""
        Me.Client.ShowCalc = True
        Me.Client.ShowDataTime = False
        Me.Client.ShowOnlyTime = False
        Me.Client.SQLString = ""
        Me.Client.UpdateIfNull = ""
        Me.Client.UpdateWhenFormLock = False
        Me.Client.UpperValue = False
        Me.Client.ValidateValue = True
        Me.Client.Visible = True
        Me.Client.VisibleIndex = 0
        '
        'TankCode
        '
        Me.TankCode.AllowInsert = True
        Me.TankCode.AllowUpdate = True
        Me.TankCode.ButtonClick = True
        Me.TankCode.Caption = "Bể xuất"
        Me.TankCode.CFLColumnHide = ""
        Me.TankCode.CFLKeyField = ""
        Me.TankCode.CFLPage = False
        Me.TankCode.CFLReturn0 = ""
        Me.TankCode.CFLReturn1 = ""
        Me.TankCode.CFLReturn2 = ""
        Me.TankCode.CFLReturn3 = ""
        Me.TankCode.CFLReturn4 = ""
        Me.TankCode.CFLReturn5 = ""
        Me.TankCode.CFLReturn6 = ""
        Me.TankCode.CFLReturn7 = ""
        Me.TankCode.CFLShowLoad = False
        Me.TankCode.ChangeFormStatus = True
        Me.TankCode.ColumnKey = False
        Me.TankCode.ComboLine = 5
        Me.TankCode.CopyFromItem = ""
        Me.TankCode.DefaultButtonClick = False
        Me.TankCode.Digit = False
        Me.TankCode.FieldType = "C"
        Me.TankCode.FieldView = "TankCode"
        Me.TankCode.FormarNumber = True
        Me.TankCode.FormList = False
        Me.TankCode.KeyInsert = ""
        Me.TankCode.LocalDecimal = False
        Me.TankCode.Name = "TankCode"
        Me.TankCode.NoUpdate = ""
        Me.TankCode.NumberDecimal = 0
        Me.TankCode.OptionsColumn.ReadOnly = True
        Me.TankCode.ParentControl = ""
        Me.TankCode.RefreshSource = False
        Me.TankCode.Required = False
        Me.TankCode.SequenceName = ""
        Me.TankCode.ShowCalc = True
        Me.TankCode.ShowDataTime = False
        Me.TankCode.ShowOnlyTime = False
        Me.TankCode.SQLString = ""
        Me.TankCode.UpdateIfNull = ""
        Me.TankCode.UpdateWhenFormLock = False
        Me.TankCode.UpperValue = False
        Me.TankCode.ValidateValue = True
        Me.TankCode.Visible = True
        Me.TankCode.VisibleIndex = 1
        '
        'MinHeight
        '
        Me.MinHeight.AllowInsert = True
        Me.MinHeight.AllowUpdate = True
        Me.MinHeight.ButtonClick = True
        Me.MinHeight.Caption = "Chiều cao xuất Min"
        Me.MinHeight.CFLColumnHide = ""
        Me.MinHeight.CFLKeyField = ""
        Me.MinHeight.CFLPage = False
        Me.MinHeight.CFLReturn0 = ""
        Me.MinHeight.CFLReturn1 = ""
        Me.MinHeight.CFLReturn2 = ""
        Me.MinHeight.CFLReturn3 = ""
        Me.MinHeight.CFLReturn4 = ""
        Me.MinHeight.CFLReturn5 = ""
        Me.MinHeight.CFLReturn6 = ""
        Me.MinHeight.CFLReturn7 = ""
        Me.MinHeight.CFLShowLoad = False
        Me.MinHeight.ChangeFormStatus = True
        Me.MinHeight.ColumnKey = False
        Me.MinHeight.ComboLine = 5
        Me.MinHeight.CopyFromItem = ""
        Me.MinHeight.DefaultButtonClick = False
        Me.MinHeight.Digit = True
        Me.MinHeight.FieldType = "N"
        Me.MinHeight.FieldView = "MinHeight"
        Me.MinHeight.FormarNumber = True
        Me.MinHeight.FormList = False
        Me.MinHeight.KeyInsert = ""
        Me.MinHeight.LocalDecimal = True
        Me.MinHeight.Name = "MinHeight"
        Me.MinHeight.NoUpdate = ""
        Me.MinHeight.NumberDecimal = 2
        Me.MinHeight.OptionsColumn.ReadOnly = True
        Me.MinHeight.ParentControl = ""
        Me.MinHeight.RefreshSource = False
        Me.MinHeight.Required = False
        Me.MinHeight.SequenceName = ""
        Me.MinHeight.ShowCalc = True
        Me.MinHeight.ShowDataTime = False
        Me.MinHeight.ShowOnlyTime = False
        Me.MinHeight.SQLString = ""
        Me.MinHeight.UpdateIfNull = ""
        Me.MinHeight.UpdateWhenFormLock = False
        Me.MinHeight.UpperValue = False
        Me.MinHeight.ValidateValue = True
        Me.MinHeight.Visible = True
        Me.MinHeight.VisibleIndex = 2
        '
        'MinVolume
        '
        Me.MinVolume.AllowInsert = True
        Me.MinVolume.AllowUpdate = True
        Me.MinVolume.ButtonClick = True
        Me.MinVolume.Caption = "Thể tích xuất Min"
        Me.MinVolume.CFLColumnHide = ""
        Me.MinVolume.CFLKeyField = ""
        Me.MinVolume.CFLPage = False
        Me.MinVolume.CFLReturn0 = ""
        Me.MinVolume.CFLReturn1 = ""
        Me.MinVolume.CFLReturn2 = ""
        Me.MinVolume.CFLReturn3 = ""
        Me.MinVolume.CFLReturn4 = ""
        Me.MinVolume.CFLReturn5 = ""
        Me.MinVolume.CFLReturn6 = ""
        Me.MinVolume.CFLReturn7 = ""
        Me.MinVolume.CFLShowLoad = False
        Me.MinVolume.ChangeFormStatus = True
        Me.MinVolume.ColumnKey = False
        Me.MinVolume.ComboLine = 5
        Me.MinVolume.CopyFromItem = ""
        Me.MinVolume.DefaultButtonClick = False
        Me.MinVolume.Digit = True
        Me.MinVolume.FieldType = "N"
        Me.MinVolume.FieldView = "MinVolume"
        Me.MinVolume.FormarNumber = True
        Me.MinVolume.FormList = False
        Me.MinVolume.KeyInsert = ""
        Me.MinVolume.LocalDecimal = True
        Me.MinVolume.Name = "MinVolume"
        Me.MinVolume.NoUpdate = ""
        Me.MinVolume.NumberDecimal = 2
        Me.MinVolume.OptionsColumn.ReadOnly = True
        Me.MinVolume.ParentControl = ""
        Me.MinVolume.RefreshSource = False
        Me.MinVolume.Required = False
        Me.MinVolume.SequenceName = ""
        Me.MinVolume.ShowCalc = True
        Me.MinVolume.ShowDataTime = False
        Me.MinVolume.ShowOnlyTime = False
        Me.MinVolume.SQLString = ""
        Me.MinVolume.UpdateIfNull = ""
        Me.MinVolume.UpdateWhenFormLock = False
        Me.MinVolume.UpperValue = False
        Me.MinVolume.ValidateValue = True
        Me.MinVolume.Visible = True
        Me.MinVolume.VisibleIndex = 3
        '
        'SafeHeight
        '
        Me.SafeHeight.AllowInsert = True
        Me.SafeHeight.AllowUpdate = True
        Me.SafeHeight.ButtonClick = True
        Me.SafeHeight.Caption = "Chiều cao an toàn"
        Me.SafeHeight.CFLColumnHide = ""
        Me.SafeHeight.CFLKeyField = ""
        Me.SafeHeight.CFLPage = False
        Me.SafeHeight.CFLReturn0 = ""
        Me.SafeHeight.CFLReturn1 = ""
        Me.SafeHeight.CFLReturn2 = ""
        Me.SafeHeight.CFLReturn3 = ""
        Me.SafeHeight.CFLReturn4 = ""
        Me.SafeHeight.CFLReturn5 = ""
        Me.SafeHeight.CFLReturn6 = ""
        Me.SafeHeight.CFLReturn7 = ""
        Me.SafeHeight.CFLShowLoad = False
        Me.SafeHeight.ChangeFormStatus = True
        Me.SafeHeight.ColumnKey = False
        Me.SafeHeight.ComboLine = 5
        Me.SafeHeight.CopyFromItem = ""
        Me.SafeHeight.DefaultButtonClick = False
        Me.SafeHeight.Digit = True
        Me.SafeHeight.FieldType = "N"
        Me.SafeHeight.FieldView = "SafeHeight"
        Me.SafeHeight.FormarNumber = True
        Me.SafeHeight.FormList = False
        Me.SafeHeight.KeyInsert = ""
        Me.SafeHeight.LocalDecimal = True
        Me.SafeHeight.Name = "SafeHeight"
        Me.SafeHeight.NoUpdate = ""
        Me.SafeHeight.NumberDecimal = 2
        Me.SafeHeight.OptionsColumn.ReadOnly = True
        Me.SafeHeight.ParentControl = ""
        Me.SafeHeight.RefreshSource = False
        Me.SafeHeight.Required = False
        Me.SafeHeight.SequenceName = ""
        Me.SafeHeight.ShowCalc = True
        Me.SafeHeight.ShowDataTime = False
        Me.SafeHeight.ShowOnlyTime = False
        Me.SafeHeight.SQLString = ""
        Me.SafeHeight.UpdateIfNull = ""
        Me.SafeHeight.UpdateWhenFormLock = False
        Me.SafeHeight.UpperValue = False
        Me.SafeHeight.ValidateValue = True
        Me.SafeHeight.Visible = True
        Me.SafeHeight.VisibleIndex = 4
        '
        'SafeVolume
        '
        Me.SafeVolume.AllowInsert = True
        Me.SafeVolume.AllowUpdate = True
        Me.SafeVolume.ButtonClick = True
        Me.SafeVolume.Caption = "Thể tich an toàn"
        Me.SafeVolume.CFLColumnHide = ""
        Me.SafeVolume.CFLKeyField = ""
        Me.SafeVolume.CFLPage = False
        Me.SafeVolume.CFLReturn0 = ""
        Me.SafeVolume.CFLReturn1 = ""
        Me.SafeVolume.CFLReturn2 = ""
        Me.SafeVolume.CFLReturn3 = ""
        Me.SafeVolume.CFLReturn4 = ""
        Me.SafeVolume.CFLReturn5 = ""
        Me.SafeVolume.CFLReturn6 = ""
        Me.SafeVolume.CFLReturn7 = ""
        Me.SafeVolume.CFLShowLoad = False
        Me.SafeVolume.ChangeFormStatus = True
        Me.SafeVolume.ColumnKey = False
        Me.SafeVolume.ComboLine = 5
        Me.SafeVolume.CopyFromItem = ""
        Me.SafeVolume.DefaultButtonClick = False
        Me.SafeVolume.Digit = True
        Me.SafeVolume.FieldType = "N"
        Me.SafeVolume.FieldView = "SafeVolume"
        Me.SafeVolume.FormarNumber = True
        Me.SafeVolume.FormList = False
        Me.SafeVolume.KeyInsert = ""
        Me.SafeVolume.LocalDecimal = True
        Me.SafeVolume.Name = "SafeVolume"
        Me.SafeVolume.NoUpdate = ""
        Me.SafeVolume.NumberDecimal = 2
        Me.SafeVolume.OptionsColumn.ReadOnly = True
        Me.SafeVolume.ParentControl = ""
        Me.SafeVolume.RefreshSource = False
        Me.SafeVolume.Required = False
        Me.SafeVolume.SequenceName = ""
        Me.SafeVolume.ShowCalc = True
        Me.SafeVolume.ShowDataTime = False
        Me.SafeVolume.ShowOnlyTime = False
        Me.SafeVolume.SQLString = ""
        Me.SafeVolume.UpdateIfNull = ""
        Me.SafeVolume.UpdateWhenFormLock = False
        Me.SafeVolume.UpperValue = False
        Me.SafeVolume.ValidateValue = True
        Me.SafeVolume.Visible = True
        Me.SafeVolume.VisibleIndex = 5
        '
        'SynDate
        '
        Me.SynDate.AllowInsert = True
        Me.SynDate.AllowUpdate = True
        Me.SynDate.ButtonClick = True
        Me.SynDate.Caption = "Ngày đồng bộ"
        Me.SynDate.CFLColumnHide = ""
        Me.SynDate.CFLKeyField = ""
        Me.SynDate.CFLPage = False
        Me.SynDate.CFLReturn0 = ""
        Me.SynDate.CFLReturn1 = ""
        Me.SynDate.CFLReturn2 = ""
        Me.SynDate.CFLReturn3 = ""
        Me.SynDate.CFLReturn4 = ""
        Me.SynDate.CFLReturn5 = ""
        Me.SynDate.CFLReturn6 = ""
        Me.SynDate.CFLReturn7 = ""
        Me.SynDate.CFLShowLoad = False
        Me.SynDate.ChangeFormStatus = True
        Me.SynDate.ColumnKey = False
        Me.SynDate.ComboLine = 5
        Me.SynDate.CopyFromItem = ""
        Me.SynDate.DefaultButtonClick = False
        Me.SynDate.Digit = False
        Me.SynDate.FieldType = "D"
        Me.SynDate.FieldView = "SynDate"
        Me.SynDate.FormarNumber = True
        Me.SynDate.FormList = False
        Me.SynDate.KeyInsert = ""
        Me.SynDate.LocalDecimal = False
        Me.SynDate.Name = "SynDate"
        Me.SynDate.NoUpdate = ""
        Me.SynDate.NumberDecimal = 0
        Me.SynDate.OptionsColumn.ReadOnly = True
        Me.SynDate.ParentControl = ""
        Me.SynDate.RefreshSource = False
        Me.SynDate.Required = False
        Me.SynDate.SequenceName = ""
        Me.SynDate.ShowCalc = True
        Me.SynDate.ShowDataTime = True
        Me.SynDate.ShowOnlyTime = False
        Me.SynDate.SQLString = ""
        Me.SynDate.UpdateIfNull = ""
        Me.SynDate.UpdateWhenFormLock = False
        Me.SynDate.UpperValue = False
        Me.SynDate.ValidateValue = True
        Me.SynDate.Visible = True
        '
        'SynUser
        '
        Me.SynUser.AllowInsert = True
        Me.SynUser.AllowUpdate = True
        Me.SynUser.ButtonClick = True
        Me.SynUser.Caption = "User"
        Me.SynUser.CFLColumnHide = ""
        Me.SynUser.CFLKeyField = ""
        Me.SynUser.CFLPage = False
        Me.SynUser.CFLReturn0 = ""
        Me.SynUser.CFLReturn1 = ""
        Me.SynUser.CFLReturn2 = ""
        Me.SynUser.CFLReturn3 = ""
        Me.SynUser.CFLReturn4 = ""
        Me.SynUser.CFLReturn5 = ""
        Me.SynUser.CFLReturn6 = ""
        Me.SynUser.CFLReturn7 = ""
        Me.SynUser.CFLShowLoad = False
        Me.SynUser.ChangeFormStatus = True
        Me.SynUser.ColumnKey = False
        Me.SynUser.ComboLine = 5
        Me.SynUser.CopyFromItem = ""
        Me.SynUser.DefaultButtonClick = False
        Me.SynUser.Digit = False
        Me.SynUser.FieldType = "C"
        Me.SynUser.FieldView = "SynUser"
        Me.SynUser.FormarNumber = True
        Me.SynUser.FormList = False
        Me.SynUser.KeyInsert = ""
        Me.SynUser.LocalDecimal = False
        Me.SynUser.Name = "SynUser"
        Me.SynUser.NoUpdate = ""
        Me.SynUser.NumberDecimal = 0
        Me.SynUser.OptionsColumn.ReadOnly = True
        Me.SynUser.ParentControl = ""
        Me.SynUser.RefreshSource = False
        Me.SynUser.Required = False
        Me.SynUser.SequenceName = ""
        Me.SynUser.ShowCalc = True
        Me.SynUser.ShowDataTime = False
        Me.SynUser.ShowOnlyTime = False
        Me.SynUser.SQLString = ""
        Me.SynUser.UpdateIfNull = ""
        Me.SynUser.UpdateWhenFormLock = False
        Me.SynUser.UpperValue = False
        Me.SynUser.ValidateValue = True
        Me.SynUser.Visible = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(948, 28)
        Me.ToolStrip2.TabIndex = 471
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(153, 25)
        Me.ToolStripButton3.Text = "Rút số liệu từ SAP"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(160, 25)
        Me.ToolStripButton1.Text = "Đồng bộ Barem bể"
        '
        'FrmTankATG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 414)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmTankATG"
        Me.Text = "Thông tin hồ sơ dung tích bể xuất"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents Plant As U_TextBox.GridColumn
    Friend WithEvents Client As U_TextBox.GridColumn
    Friend WithEvents TankCode As U_TextBox.GridColumn
    Friend WithEvents MinHeight As U_TextBox.GridColumn
    Friend WithEvents MinVolume As U_TextBox.GridColumn
    Friend WithEvents SafeHeight As U_TextBox.GridColumn
    Friend WithEvents SafeVolume As U_TextBox.GridColumn
    Friend WithEvents SynDate As U_TextBox.GridColumn
    Friend WithEvents SynUser As U_TextBox.GridColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
