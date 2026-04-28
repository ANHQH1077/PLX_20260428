<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMapcpLine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMapcpLine))
        Me.Navigator1 = New U_TextBox.Navigator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.colSTT = New U_TextBox.GridColumn()
        Me.colTableName = New U_TextBox.GridColumn()
        Me.colFromField = New U_TextBox.GridColumn()
        Me.colTableName_Thuy = New U_TextBox.GridColumn()
        Me.colBo = New U_TextBox.GridColumn()
        Me.colThuy = New U_TextBox.GridColumn()
        Me.colSat = New U_TextBox.GridColumn()
        Me.SWhere = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ID = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableName = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableName_Thuy = New U_TextBox.U_TextBox()
        Me.STT = New U_TextBox.U_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlagThuy = New U_TextBox.U_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FlagBo = New U_TextBox.U_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FlagFinishThuy = New U_TextBox.U_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.FlagFinishBo = New U_TextBox.U_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ServerScada = New U_TextBox.U_TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.UidScada = New U_TextBox.U_TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PwdScada = New U_TextBox.U_TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DatabaseScada = New U_TextBox.U_TextBox()
        Me.SqlScadaConnectionString = New U_TextBox.U_TextBox()
        Me.Flag = New U_TextBox.U_TextBox()
        Me.FlagFinish = New U_TextBox.U_TextBox()
        Me.Status = New U_TextBox.U_Combobox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableName_Thuy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlagThuy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlagBo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlagFinishThuy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlagFinishBo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServerScada.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UidScada.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PwdScada.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatabaseScada.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SqlScadaConnectionString.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flag.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlagFinish.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Status.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Navigator1
        '
        Me.Navigator1.Buttons.Append.Visible = False
        Me.Navigator1.Buttons.Remove.Visible = False
        Me.Navigator1.DefaultButton = True
        Me.Navigator1.Location = New System.Drawing.Point(533, 1)
        Me.Navigator1.Name = "Navigator1"
        Me.Navigator1.Size = New System.Drawing.Size(172, 24)
        Me.Navigator1.TabIndex = 454
        Me.Navigator1.Text = "Navigator1"
        Me.Navigator1.ViewName = "tblMap_cp"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(71, 25)
        Me.ToolStrip1.TabIndex = 468
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton8.Text = "&1. Lưu"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(4, 214)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(701, 314)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSTT, Me.colTableName, Me.colFromField, Me.colTableName_Thuy, Me.colBo, Me.colThuy, Me.colSat, Me.SWhere, Me.ID, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = True
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = "STT"
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "SYS_Map_cp_Line"
        Me.GridView1.ViewName = "FPT_SYS_Map_cp_Line"
        Me.GridView1.Where = "STT=:STT"
        '
        'colSTT
        '
        Me.colSTT.AllowInsert = True
        Me.colSTT.AllowUpdate = True
        Me.colSTT.ButtonClick = True
        Me.colSTT.Caption = "GridColumn1"
        Me.colSTT.CFLColumnHide = ""
        Me.colSTT.CFLKeyField = ""
        Me.colSTT.CFLPage = False
        Me.colSTT.CFLReturn0 = ""
        Me.colSTT.CFLReturn1 = ""
        Me.colSTT.CFLReturn2 = ""
        Me.colSTT.CFLReturn3 = ""
        Me.colSTT.CFLReturn4 = ""
        Me.colSTT.CFLReturn5 = ""
        Me.colSTT.CFLReturn6 = ""
        Me.colSTT.CFLReturn7 = ""
        Me.colSTT.CFLShowLoad = False
        Me.colSTT.ChangeFormStatus = True
        Me.colSTT.ColumnKey = False
        Me.colSTT.ComboLine = 5
        Me.colSTT.CopyFromItem = ":STT"
        Me.colSTT.DefaultButtonClick = False
        Me.colSTT.Digit = False
        Me.colSTT.FieldType = "N"
        Me.colSTT.FieldView = "STT"
        Me.colSTT.FormarNumber = True
        Me.colSTT.FormList = False
        Me.colSTT.KeyInsert = ""
        Me.colSTT.LocalDecimal = False
        Me.colSTT.Name = "colSTT"
        Me.colSTT.NoUpdate = ""
        Me.colSTT.NumberDecimal = 0
        Me.colSTT.ParentControl = ""
        Me.colSTT.RefreshSource = False
        Me.colSTT.Required = False
        Me.colSTT.SequenceName = ""
        Me.colSTT.ShowCalc = True
        Me.colSTT.ShowDataTime = False
        Me.colSTT.ShowOnlyTime = False
        Me.colSTT.SQLString = ""
        Me.colSTT.UpdateIfNull = ""
        Me.colSTT.UpdateWhenFormLock = False
        Me.colSTT.UpperValue = False
        Me.colSTT.ValidateValue = True
        Me.colSTT.Visible = True
        '
        'colTableName
        '
        Me.colTableName.AllowInsert = True
        Me.colTableName.AllowUpdate = True
        Me.colTableName.ButtonClick = True
        Me.colTableName.Caption = "GridColumn2"
        Me.colTableName.CFLColumnHide = ""
        Me.colTableName.CFLKeyField = ""
        Me.colTableName.CFLPage = False
        Me.colTableName.CFLReturn0 = ""
        Me.colTableName.CFLReturn1 = ""
        Me.colTableName.CFLReturn2 = ""
        Me.colTableName.CFLReturn3 = ""
        Me.colTableName.CFLReturn4 = ""
        Me.colTableName.CFLReturn5 = ""
        Me.colTableName.CFLReturn6 = ""
        Me.colTableName.CFLReturn7 = ""
        Me.colTableName.CFLShowLoad = False
        Me.colTableName.ChangeFormStatus = True
        Me.colTableName.ColumnKey = False
        Me.colTableName.ComboLine = 5
        Me.colTableName.CopyFromItem = ":TableName"
        Me.colTableName.DefaultButtonClick = False
        Me.colTableName.Digit = False
        Me.colTableName.FieldType = "C"
        Me.colTableName.FieldView = "TableName"
        Me.colTableName.FormarNumber = True
        Me.colTableName.FormList = False
        Me.colTableName.KeyInsert = ""
        Me.colTableName.LocalDecimal = False
        Me.colTableName.Name = "colTableName"
        Me.colTableName.NoUpdate = ""
        Me.colTableName.NumberDecimal = 0
        Me.colTableName.ParentControl = ""
        Me.colTableName.RefreshSource = False
        Me.colTableName.Required = False
        Me.colTableName.SequenceName = ""
        Me.colTableName.ShowCalc = True
        Me.colTableName.ShowDataTime = False
        Me.colTableName.ShowOnlyTime = False
        Me.colTableName.SQLString = ""
        Me.colTableName.UpdateIfNull = ""
        Me.colTableName.UpdateWhenFormLock = False
        Me.colTableName.UpperValue = False
        Me.colTableName.ValidateValue = True
        Me.colTableName.Visible = True
        '
        'colFromField
        '
        Me.colFromField.AllowInsert = True
        Me.colFromField.AllowUpdate = True
        Me.colFromField.ButtonClick = True
        Me.colFromField.Caption = "Trường HTTG"
        Me.colFromField.CFLColumnHide = ""
        Me.colFromField.CFLKeyField = ""
        Me.colFromField.CFLPage = False
        Me.colFromField.CFLReturn0 = ""
        Me.colFromField.CFLReturn1 = ""
        Me.colFromField.CFLReturn2 = ""
        Me.colFromField.CFLReturn3 = ""
        Me.colFromField.CFLReturn4 = ""
        Me.colFromField.CFLReturn5 = ""
        Me.colFromField.CFLReturn6 = ""
        Me.colFromField.CFLReturn7 = ""
        Me.colFromField.CFLShowLoad = False
        Me.colFromField.ChangeFormStatus = True
        Me.colFromField.ColumnKey = False
        Me.colFromField.ComboLine = 5
        Me.colFromField.CopyFromItem = ""
        Me.colFromField.DefaultButtonClick = False
        Me.colFromField.Digit = False
        Me.colFromField.FieldType = "C"
        Me.colFromField.FieldView = "FromField"
        Me.colFromField.FormarNumber = True
        Me.colFromField.FormList = False
        Me.colFromField.KeyInsert = ""
        Me.colFromField.LocalDecimal = False
        Me.colFromField.Name = "colFromField"
        Me.colFromField.NoUpdate = ""
        Me.colFromField.NumberDecimal = 0
        Me.colFromField.ParentControl = ""
        Me.colFromField.RefreshSource = False
        Me.colFromField.Required = False
        Me.colFromField.SequenceName = ""
        Me.colFromField.ShowCalc = True
        Me.colFromField.ShowDataTime = False
        Me.colFromField.ShowOnlyTime = False
        Me.colFromField.SQLString = ""
        Me.colFromField.UpdateIfNull = ""
        Me.colFromField.UpdateWhenFormLock = False
        Me.colFromField.UpperValue = False
        Me.colFromField.ValidateValue = True
        Me.colFromField.Visible = True
        Me.colFromField.VisibleIndex = 0
        '
        'colTableName_Thuy
        '
        Me.colTableName_Thuy.AllowInsert = True
        Me.colTableName_Thuy.AllowUpdate = True
        Me.colTableName_Thuy.ButtonClick = True
        Me.colTableName_Thuy.Caption = "GridColumn3"
        Me.colTableName_Thuy.CFLColumnHide = ""
        Me.colTableName_Thuy.CFLKeyField = ""
        Me.colTableName_Thuy.CFLPage = False
        Me.colTableName_Thuy.CFLReturn0 = ""
        Me.colTableName_Thuy.CFLReturn1 = ""
        Me.colTableName_Thuy.CFLReturn2 = ""
        Me.colTableName_Thuy.CFLReturn3 = ""
        Me.colTableName_Thuy.CFLReturn4 = ""
        Me.colTableName_Thuy.CFLReturn5 = ""
        Me.colTableName_Thuy.CFLReturn6 = ""
        Me.colTableName_Thuy.CFLReturn7 = ""
        Me.colTableName_Thuy.CFLShowLoad = False
        Me.colTableName_Thuy.ChangeFormStatus = True
        Me.colTableName_Thuy.ColumnKey = False
        Me.colTableName_Thuy.ComboLine = 5
        Me.colTableName_Thuy.CopyFromItem = ":TableName_Thuy"
        Me.colTableName_Thuy.DefaultButtonClick = False
        Me.colTableName_Thuy.Digit = False
        Me.colTableName_Thuy.FieldType = "C"
        Me.colTableName_Thuy.FieldView = "TableName_Thuy"
        Me.colTableName_Thuy.FormarNumber = True
        Me.colTableName_Thuy.FormList = False
        Me.colTableName_Thuy.KeyInsert = ""
        Me.colTableName_Thuy.LocalDecimal = False
        Me.colTableName_Thuy.Name = "colTableName_Thuy"
        Me.colTableName_Thuy.NoUpdate = ""
        Me.colTableName_Thuy.NumberDecimal = 0
        Me.colTableName_Thuy.ParentControl = ""
        Me.colTableName_Thuy.RefreshSource = False
        Me.colTableName_Thuy.Required = False
        Me.colTableName_Thuy.SequenceName = ""
        Me.colTableName_Thuy.ShowCalc = True
        Me.colTableName_Thuy.ShowDataTime = False
        Me.colTableName_Thuy.ShowOnlyTime = False
        Me.colTableName_Thuy.SQLString = ""
        Me.colTableName_Thuy.UpdateIfNull = ""
        Me.colTableName_Thuy.UpdateWhenFormLock = False
        Me.colTableName_Thuy.UpperValue = False
        Me.colTableName_Thuy.ValidateValue = True
        Me.colTableName_Thuy.Visible = True
        '
        'colBo
        '
        Me.colBo.AllowInsert = True
        Me.colBo.AllowUpdate = True
        Me.colBo.ButtonClick = True
        Me.colBo.Caption = "Bộ"
        Me.colBo.CFLColumnHide = ""
        Me.colBo.CFLKeyField = ""
        Me.colBo.CFLPage = False
        Me.colBo.CFLReturn0 = ""
        Me.colBo.CFLReturn1 = ""
        Me.colBo.CFLReturn2 = ""
        Me.colBo.CFLReturn3 = ""
        Me.colBo.CFLReturn4 = ""
        Me.colBo.CFLReturn5 = ""
        Me.colBo.CFLReturn6 = ""
        Me.colBo.CFLReturn7 = ""
        Me.colBo.CFLShowLoad = False
        Me.colBo.ChangeFormStatus = True
        Me.colBo.ColumnKey = False
        Me.colBo.ComboLine = 5
        Me.colBo.CopyFromItem = ""
        Me.colBo.DefaultButtonClick = False
        Me.colBo.Digit = False
        Me.colBo.FieldType = "C"
        Me.colBo.FieldView = "Bo"
        Me.colBo.FormarNumber = True
        Me.colBo.FormList = False
        Me.colBo.KeyInsert = ""
        Me.colBo.LocalDecimal = False
        Me.colBo.Name = "colBo"
        Me.colBo.NoUpdate = ""
        Me.colBo.NumberDecimal = 0
        Me.colBo.ParentControl = ""
        Me.colBo.RefreshSource = False
        Me.colBo.Required = False
        Me.colBo.SequenceName = ""
        Me.colBo.ShowCalc = True
        Me.colBo.ShowDataTime = False
        Me.colBo.ShowOnlyTime = False
        Me.colBo.SQLString = ""
        Me.colBo.UpdateIfNull = ""
        Me.colBo.UpdateWhenFormLock = False
        Me.colBo.UpperValue = False
        Me.colBo.ValidateValue = True
        Me.colBo.Visible = True
        Me.colBo.VisibleIndex = 1
        '
        'colThuy
        '
        Me.colThuy.AllowInsert = True
        Me.colThuy.AllowUpdate = True
        Me.colThuy.ButtonClick = True
        Me.colThuy.Caption = "Thủy"
        Me.colThuy.CFLColumnHide = ""
        Me.colThuy.CFLKeyField = ""
        Me.colThuy.CFLPage = False
        Me.colThuy.CFLReturn0 = ""
        Me.colThuy.CFLReturn1 = ""
        Me.colThuy.CFLReturn2 = ""
        Me.colThuy.CFLReturn3 = ""
        Me.colThuy.CFLReturn4 = ""
        Me.colThuy.CFLReturn5 = ""
        Me.colThuy.CFLReturn6 = ""
        Me.colThuy.CFLReturn7 = ""
        Me.colThuy.CFLShowLoad = False
        Me.colThuy.ChangeFormStatus = True
        Me.colThuy.ColumnKey = False
        Me.colThuy.ComboLine = 5
        Me.colThuy.CopyFromItem = ""
        Me.colThuy.DefaultButtonClick = False
        Me.colThuy.Digit = False
        Me.colThuy.FieldType = "C"
        Me.colThuy.FieldView = "Thuy"
        Me.colThuy.FormarNumber = True
        Me.colThuy.FormList = False
        Me.colThuy.KeyInsert = ""
        Me.colThuy.LocalDecimal = False
        Me.colThuy.Name = "colThuy"
        Me.colThuy.NoUpdate = ""
        Me.colThuy.NumberDecimal = 0
        Me.colThuy.ParentControl = ""
        Me.colThuy.RefreshSource = False
        Me.colThuy.Required = False
        Me.colThuy.SequenceName = ""
        Me.colThuy.ShowCalc = True
        Me.colThuy.ShowDataTime = False
        Me.colThuy.ShowOnlyTime = False
        Me.colThuy.SQLString = ""
        Me.colThuy.UpdateIfNull = ""
        Me.colThuy.UpdateWhenFormLock = False
        Me.colThuy.UpperValue = False
        Me.colThuy.ValidateValue = True
        Me.colThuy.Visible = True
        Me.colThuy.VisibleIndex = 2
        '
        'colSat
        '
        Me.colSat.AllowInsert = True
        Me.colSat.AllowUpdate = True
        Me.colSat.ButtonClick = True
        Me.colSat.Caption = "Sắt"
        Me.colSat.CFLColumnHide = ""
        Me.colSat.CFLKeyField = ""
        Me.colSat.CFLPage = False
        Me.colSat.CFLReturn0 = ""
        Me.colSat.CFLReturn1 = ""
        Me.colSat.CFLReturn2 = ""
        Me.colSat.CFLReturn3 = ""
        Me.colSat.CFLReturn4 = ""
        Me.colSat.CFLReturn5 = ""
        Me.colSat.CFLReturn6 = ""
        Me.colSat.CFLReturn7 = ""
        Me.colSat.CFLShowLoad = False
        Me.colSat.ChangeFormStatus = True
        Me.colSat.ColumnKey = False
        Me.colSat.ComboLine = 5
        Me.colSat.CopyFromItem = ""
        Me.colSat.DefaultButtonClick = False
        Me.colSat.Digit = False
        Me.colSat.FieldType = "C"
        Me.colSat.FieldView = "Sat"
        Me.colSat.FormarNumber = True
        Me.colSat.FormList = False
        Me.colSat.KeyInsert = ""
        Me.colSat.LocalDecimal = False
        Me.colSat.Name = "colSat"
        Me.colSat.NoUpdate = ""
        Me.colSat.NumberDecimal = 0
        Me.colSat.ParentControl = ""
        Me.colSat.RefreshSource = False
        Me.colSat.Required = False
        Me.colSat.SequenceName = ""
        Me.colSat.ShowCalc = True
        Me.colSat.ShowDataTime = False
        Me.colSat.ShowOnlyTime = False
        Me.colSat.SQLString = ""
        Me.colSat.UpdateIfNull = ""
        Me.colSat.UpdateWhenFormLock = False
        Me.colSat.UpperValue = False
        Me.colSat.ValidateValue = True
        Me.colSat.Visible = True
        Me.colSat.VisibleIndex = 3
        '
        'SWhere
        '
        Me.SWhere.AllowInsert = True
        Me.SWhere.AllowUpdate = True
        Me.SWhere.ButtonClick = True
        Me.SWhere.Caption = "Key"
        Me.SWhere.CFLColumnHide = ""
        Me.SWhere.CFLKeyField = ""
        Me.SWhere.CFLPage = False
        Me.SWhere.CFLReturn0 = ""
        Me.SWhere.CFLReturn1 = ""
        Me.SWhere.CFLReturn2 = ""
        Me.SWhere.CFLReturn3 = ""
        Me.SWhere.CFLReturn4 = ""
        Me.SWhere.CFLReturn5 = ""
        Me.SWhere.CFLReturn6 = ""
        Me.SWhere.CFLReturn7 = ""
        Me.SWhere.CFLShowLoad = False
        Me.SWhere.ChangeFormStatus = True
        Me.SWhere.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.SWhere.ColumnKey = False
        Me.SWhere.ComboLine = 5
        Me.SWhere.CopyFromItem = ""
        Me.SWhere.DefaultButtonClick = False
        Me.SWhere.Digit = False
        Me.SWhere.FieldType = "C"
        Me.SWhere.FieldView = "SWhere"
        Me.SWhere.FormarNumber = True
        Me.SWhere.FormList = False
        Me.SWhere.KeyInsert = ""
        Me.SWhere.LocalDecimal = False
        Me.SWhere.Name = "SWhere"
        Me.SWhere.NoUpdate = ""
        Me.SWhere.NumberDecimal = 0
        Me.SWhere.ParentControl = ""
        Me.SWhere.RefreshSource = False
        Me.SWhere.Required = False
        Me.SWhere.SequenceName = ""
        Me.SWhere.ShowCalc = True
        Me.SWhere.ShowDataTime = False
        Me.SWhere.ShowOnlyTime = False
        Me.SWhere.SQLString = ""
        Me.SWhere.UpdateIfNull = ""
        Me.SWhere.UpdateWhenFormLock = False
        Me.SWhere.UpperValue = False
        Me.SWhere.ValidateValue = True
        Me.SWhere.Visible = True
        Me.SWhere.VisibleIndex = 4
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.ButtonClick = True
        Me.ID.Caption = "GridColumn9"
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
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.ButtonClick = True
        Me.CHECKUPD.Caption = "GridColumn10"
        Me.CHECKUPD.CFLColumnHide = ""
        Me.CHECKUPD.CFLKeyField = ""
        Me.CHECKUPD.CFLPage = False
        Me.CHECKUPD.CFLReturn0 = ""
        Me.CHECKUPD.CFLReturn1 = ""
        Me.CHECKUPD.CFLReturn2 = ""
        Me.CHECKUPD.CFLReturn3 = ""
        Me.CHECKUPD.CFLReturn4 = ""
        Me.CHECKUPD.CFLReturn5 = ""
        Me.CHECKUPD.CFLReturn6 = ""
        Me.CHECKUPD.CFLReturn7 = ""
        Me.CHECKUPD.CFLShowLoad = False
        Me.CHECKUPD.ChangeFormStatus = True
        Me.CHECKUPD.ColumnKey = False
        Me.CHECKUPD.ComboLine = 5
        Me.CHECKUPD.CopyFromItem = ""
        Me.CHECKUPD.DefaultButtonClick = False
        Me.CHECKUPD.Digit = False
        Me.CHECKUPD.FieldType = "C"
        Me.CHECKUPD.FieldView = "CHECKUPD"
        Me.CHECKUPD.FormarNumber = True
        Me.CHECKUPD.FormList = False
        Me.CHECKUPD.KeyInsert = ""
        Me.CHECKUPD.LocalDecimal = False
        Me.CHECKUPD.Name = "CHECKUPD"
        Me.CHECKUPD.NoUpdate = ""
        Me.CHECKUPD.NumberDecimal = 0
        Me.CHECKUPD.ParentControl = ""
        Me.CHECKUPD.RefreshSource = False
        Me.CHECKUPD.Required = False
        Me.CHECKUPD.SequenceName = ""
        Me.CHECKUPD.ShowCalc = True
        Me.CHECKUPD.ShowDataTime = False
        Me.CHECKUPD.ShowOnlyTime = False
        Me.CHECKUPD.SQLString = ""
        Me.CHECKUPD.UpdateIfNull = ""
        Me.CHECKUPD.UpdateWhenFormLock = False
        Me.CHECKUPD.UpperValue = False
        Me.CHECKUPD.ValidateValue = True
        Me.CHECKUPD.Visible = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 470
        Me.Label1.Text = "Tên bảng"
        '
        'TableName
        '
        Me.TableName.AllowInsert = True
        Me.TableName.AllowUpdate = True
        Me.TableName.AutoKeyFix = ""
        Me.TableName.AutoKeyName = ""
        Me.TableName.BindingSourceName = ""
        Me.TableName.ChangeFormStatus = True
        Me.TableName.CopyFromItem = ""
        Me.TableName.DefaultValue = ""
        Me.TableName.FieldName = "TableName"
        Me.TableName.FieldType = "C"
        Me.TableName.KeyInsert = "N"
        Me.TableName.LinkLabel = ""
        Me.TableName.Location = New System.Drawing.Point(171, 51)
        Me.TableName.Name = "TableName"
        Me.TableName.NoUpdate = "N"
        Me.TableName.PrimaryKey = "N"
        Me.TableName.Properties.AutoHeight = False
        Me.TableName.Required = "Y"
        Me.TableName.Size = New System.Drawing.Size(181, 26)
        Me.TableName.TabIndex = 469
        Me.TableName.TableName = "tblMap_cp"
        Me.TableName.UpdateIfNull = "N"
        Me.TableName.UpdateWhenFormLock = False
        Me.TableName.UpperValue = False
        Me.TableName.ViewName = "tblMap_cp"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(356, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 472
        Me.Label2.Text = "Tên bảng"
        '
        'TableName_Thuy
        '
        Me.TableName_Thuy.AllowInsert = True
        Me.TableName_Thuy.AllowUpdate = True
        Me.TableName_Thuy.AutoKeyFix = ""
        Me.TableName_Thuy.AutoKeyName = ""
        Me.TableName_Thuy.BindingSourceName = ""
        Me.TableName_Thuy.ChangeFormStatus = True
        Me.TableName_Thuy.CopyFromItem = ""
        Me.TableName_Thuy.DefaultValue = ""
        Me.TableName_Thuy.FieldName = "TableName_Thuy"
        Me.TableName_Thuy.FieldType = "C"
        Me.TableName_Thuy.KeyInsert = "Y"
        Me.TableName_Thuy.LinkLabel = ""
        Me.TableName_Thuy.Location = New System.Drawing.Point(485, 51)
        Me.TableName_Thuy.Name = "TableName_Thuy"
        Me.TableName_Thuy.NoUpdate = "N"
        Me.TableName_Thuy.PrimaryKey = "N"
        Me.TableName_Thuy.Properties.AutoHeight = False
        Me.TableName_Thuy.Required = "Y"
        Me.TableName_Thuy.Size = New System.Drawing.Size(181, 26)
        Me.TableName_Thuy.TabIndex = 471
        Me.TableName_Thuy.TableName = "tblMap_cp"
        Me.TableName_Thuy.UpdateIfNull = "N"
        Me.TableName_Thuy.UpdateWhenFormLock = False
        Me.TableName_Thuy.UpperValue = False
        Me.TableName_Thuy.ViewName = "tblMap_cp"
        '
        'STT
        '
        Me.STT.AllowInsert = True
        Me.STT.AllowUpdate = False
        Me.STT.AutoKeyFix = ""
        Me.STT.AutoKeyName = ""
        Me.STT.BindingSourceName = ""
        Me.STT.ChangeFormStatus = True
        Me.STT.CopyFromItem = ""
        Me.STT.DefaultValue = ""
        Me.STT.FieldName = "STT"
        Me.STT.FieldType = "N"
        Me.STT.KeyInsert = "Y"
        Me.STT.LinkLabel = ""
        Me.STT.Location = New System.Drawing.Point(125, 5)
        Me.STT.Name = "STT"
        Me.STT.NoUpdate = "N"
        Me.STT.PrimaryKey = "Y"
        Me.STT.Properties.AutoHeight = False
        Me.STT.Required = "Y"
        Me.STT.Size = New System.Drawing.Size(40, 26)
        Me.STT.TabIndex = 473
        Me.STT.TableName = "tblMap_cp"
        Me.STT.UpdateIfNull = "Y"
        Me.STT.UpdateWhenFormLock = False
        Me.STT.UpperValue = False
        Me.STT.ViewName = "tblMap_cp"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(94, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 474
        Me.Label3.Text = "STT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(356, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 478
        Me.Label4.Text = "Tên cột trạng thái"
        '
        'FlagThuy
        '
        Me.FlagThuy.AllowInsert = True
        Me.FlagThuy.AllowUpdate = True
        Me.FlagThuy.AutoKeyFix = ""
        Me.FlagThuy.AutoKeyName = ""
        Me.FlagThuy.BindingSourceName = ""
        Me.FlagThuy.ChangeFormStatus = True
        Me.FlagThuy.CopyFromItem = ""
        Me.FlagThuy.DefaultValue = ""
        Me.FlagThuy.FieldName = ""
        Me.FlagThuy.FieldType = "C"
        Me.FlagThuy.KeyInsert = "Y"
        Me.FlagThuy.LinkLabel = ""
        Me.FlagThuy.Location = New System.Drawing.Point(485, 79)
        Me.FlagThuy.Name = "FlagThuy"
        Me.FlagThuy.NoUpdate = "N"
        Me.FlagThuy.PrimaryKey = "N"
        Me.FlagThuy.Properties.AutoHeight = False
        Me.FlagThuy.Required = "Y"
        Me.FlagThuy.Size = New System.Drawing.Size(181, 26)
        Me.FlagThuy.TabIndex = 477
        Me.FlagThuy.TableName = ""
        Me.FlagThuy.UpdateIfNull = "N"
        Me.FlagThuy.UpdateWhenFormLock = False
        Me.FlagThuy.UpperValue = False
        Me.FlagThuy.ViewName = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 476
        Me.Label5.Text = "Tên cột trạng thái"
        '
        'FlagBo
        '
        Me.FlagBo.AllowInsert = True
        Me.FlagBo.AllowUpdate = True
        Me.FlagBo.AutoKeyFix = ""
        Me.FlagBo.AutoKeyName = ""
        Me.FlagBo.BindingSourceName = ""
        Me.FlagBo.ChangeFormStatus = True
        Me.FlagBo.CopyFromItem = ""
        Me.FlagBo.DefaultValue = ""
        Me.FlagBo.FieldName = ""
        Me.FlagBo.FieldType = "C"
        Me.FlagBo.KeyInsert = "Y"
        Me.FlagBo.LinkLabel = ""
        Me.FlagBo.Location = New System.Drawing.Point(171, 79)
        Me.FlagBo.Name = "FlagBo"
        Me.FlagBo.NoUpdate = "N"
        Me.FlagBo.PrimaryKey = "N"
        Me.FlagBo.Properties.AutoHeight = False
        Me.FlagBo.Required = "Y"
        Me.FlagBo.Size = New System.Drawing.Size(181, 26)
        Me.FlagBo.TabIndex = 475
        Me.FlagBo.TableName = ""
        Me.FlagBo.UpdateIfNull = "N"
        Me.FlagBo.UpdateWhenFormLock = False
        Me.FlagBo.UpperValue = False
        Me.FlagBo.ViewName = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(356, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 13)
        Me.Label6.TabIndex = 482
        Me.Label6.Text = "Trạng thái đã xuất hàng"
        '
        'FlagFinishThuy
        '
        Me.FlagFinishThuy.AllowInsert = True
        Me.FlagFinishThuy.AllowUpdate = True
        Me.FlagFinishThuy.AutoKeyFix = ""
        Me.FlagFinishThuy.AutoKeyName = ""
        Me.FlagFinishThuy.BindingSourceName = ""
        Me.FlagFinishThuy.ChangeFormStatus = True
        Me.FlagFinishThuy.CopyFromItem = ""
        Me.FlagFinishThuy.DefaultValue = ""
        Me.FlagFinishThuy.FieldName = ""
        Me.FlagFinishThuy.FieldType = "C"
        Me.FlagFinishThuy.KeyInsert = "Y"
        Me.FlagFinishThuy.LinkLabel = ""
        Me.FlagFinishThuy.Location = New System.Drawing.Point(485, 107)
        Me.FlagFinishThuy.Name = "FlagFinishThuy"
        Me.FlagFinishThuy.NoUpdate = "N"
        Me.FlagFinishThuy.PrimaryKey = "N"
        Me.FlagFinishThuy.Properties.AutoHeight = False
        Me.FlagFinishThuy.Required = "Y"
        Me.FlagFinishThuy.Size = New System.Drawing.Size(42, 26)
        Me.FlagFinishThuy.TabIndex = 481
        Me.FlagFinishThuy.TableName = ""
        Me.FlagFinishThuy.UpdateIfNull = "N"
        Me.FlagFinishThuy.UpdateWhenFormLock = False
        Me.FlagFinishThuy.UpperValue = False
        Me.FlagFinishThuy.ViewName = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(42, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 13)
        Me.Label7.TabIndex = 480
        Me.Label7.Text = "Trạng thái đã xuất hàng"
        '
        'FlagFinishBo
        '
        Me.FlagFinishBo.AllowInsert = True
        Me.FlagFinishBo.AllowUpdate = True
        Me.FlagFinishBo.AutoKeyFix = ""
        Me.FlagFinishBo.AutoKeyName = ""
        Me.FlagFinishBo.BindingSourceName = ""
        Me.FlagFinishBo.ChangeFormStatus = True
        Me.FlagFinishBo.CopyFromItem = ""
        Me.FlagFinishBo.DefaultValue = ""
        Me.FlagFinishBo.FieldName = ""
        Me.FlagFinishBo.FieldType = "C"
        Me.FlagFinishBo.KeyInsert = "Y"
        Me.FlagFinishBo.LinkLabel = ""
        Me.FlagFinishBo.Location = New System.Drawing.Point(171, 107)
        Me.FlagFinishBo.Name = "FlagFinishBo"
        Me.FlagFinishBo.NoUpdate = "N"
        Me.FlagFinishBo.PrimaryKey = "N"
        Me.FlagFinishBo.Properties.AutoHeight = False
        Me.FlagFinishBo.Required = "Y"
        Me.FlagFinishBo.Size = New System.Drawing.Size(42, 26)
        Me.FlagFinishBo.TabIndex = 479
        Me.FlagFinishBo.TableName = ""
        Me.FlagFinishBo.UpdateIfNull = "N"
        Me.FlagFinishBo.UpdateWhenFormLock = False
        Me.FlagFinishBo.UpperValue = False
        Me.FlagFinishBo.ViewName = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(12, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 16)
        Me.Label8.TabIndex = 483
        Me.Label8.Text = "Xuất bộ"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(346, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 16)
        Me.Label9.TabIndex = 484
        Me.Label9.Text = "Xuất thủy"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(12, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 16)
        Me.Label10.TabIndex = 485
        Me.Label10.Text = "Cấu hình kết nối"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(42, 161)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 487
        Me.Label11.Text = "IP máy chủ"
        '
        'ServerScada
        '
        Me.ServerScada.AllowInsert = True
        Me.ServerScada.AllowUpdate = True
        Me.ServerScada.AutoKeyFix = ""
        Me.ServerScada.AutoKeyName = ""
        Me.ServerScada.BindingSourceName = ""
        Me.ServerScada.ChangeFormStatus = True
        Me.ServerScada.CopyFromItem = ""
        Me.ServerScada.DefaultValue = ""
        Me.ServerScada.FieldName = "ServerScada"
        Me.ServerScada.FieldType = "C"
        Me.ServerScada.KeyInsert = "Y"
        Me.ServerScada.LinkLabel = ""
        Me.ServerScada.Location = New System.Drawing.Point(171, 154)
        Me.ServerScada.Name = "ServerScada"
        Me.ServerScada.NoUpdate = "N"
        Me.ServerScada.PrimaryKey = "N"
        Me.ServerScada.Properties.AutoHeight = False
        Me.ServerScada.Required = "Y"
        Me.ServerScada.Size = New System.Drawing.Size(166, 26)
        Me.ServerScada.TabIndex = 486
        Me.ServerScada.TableName = "tblMap_cp"
        Me.ServerScada.UpdateIfNull = "N"
        Me.ServerScada.UpdateWhenFormLock = False
        Me.ServerScada.UpperValue = False
        Me.ServerScada.ViewName = "tblMap_cp"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(356, 157)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 489
        Me.Label12.Text = "User SQL"
        '
        'UidScada
        '
        Me.UidScada.AllowInsert = True
        Me.UidScada.AllowUpdate = True
        Me.UidScada.AutoKeyFix = ""
        Me.UidScada.AutoKeyName = ""
        Me.UidScada.BindingSourceName = ""
        Me.UidScada.ChangeFormStatus = True
        Me.UidScada.CopyFromItem = ""
        Me.UidScada.DefaultValue = ""
        Me.UidScada.FieldName = "UidScada"
        Me.UidScada.FieldType = "C"
        Me.UidScada.KeyInsert = "Y"
        Me.UidScada.LinkLabel = ""
        Me.UidScada.Location = New System.Drawing.Point(485, 154)
        Me.UidScada.Name = "UidScada"
        Me.UidScada.NoUpdate = "N"
        Me.UidScada.PrimaryKey = "N"
        Me.UidScada.Properties.AutoHeight = False
        Me.UidScada.Required = "Y"
        Me.UidScada.Size = New System.Drawing.Size(181, 26)
        Me.UidScada.TabIndex = 488
        Me.UidScada.TableName = "tblMap_cp"
        Me.UidScada.UpdateIfNull = "N"
        Me.UidScada.UpdateWhenFormLock = False
        Me.UidScada.UpperValue = False
        Me.UidScada.ViewName = "tblMap_cp"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(356, 186)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 491
        Me.Label13.Text = "Password SQL"
        '
        'PwdScada
        '
        Me.PwdScada.AllowInsert = True
        Me.PwdScada.AllowUpdate = True
        Me.PwdScada.AutoKeyFix = ""
        Me.PwdScada.AutoKeyName = ""
        Me.PwdScada.BindingSourceName = ""
        Me.PwdScada.ChangeFormStatus = True
        Me.PwdScada.CopyFromItem = ""
        Me.PwdScada.DefaultValue = ""
        Me.PwdScada.FieldName = "PwdScada"
        Me.PwdScada.FieldType = "C"
        Me.PwdScada.KeyInsert = "Y"
        Me.PwdScada.LinkLabel = ""
        Me.PwdScada.Location = New System.Drawing.Point(485, 183)
        Me.PwdScada.Name = "PwdScada"
        Me.PwdScada.NoUpdate = "N"
        Me.PwdScada.PrimaryKey = "N"
        Me.PwdScada.Properties.AutoHeight = False
        Me.PwdScada.Required = "Y"
        Me.PwdScada.Size = New System.Drawing.Size(181, 26)
        Me.PwdScada.TabIndex = 490
        Me.PwdScada.TableName = "tblMap_cp"
        Me.PwdScada.UpdateIfNull = "N"
        Me.PwdScada.UpdateWhenFormLock = False
        Me.PwdScada.UpperValue = False
        Me.PwdScada.ViewName = "tblMap_cp"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(42, 190)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 493
        Me.Label14.Text = "Database SQL"
        '
        'DatabaseScada
        '
        Me.DatabaseScada.AllowInsert = True
        Me.DatabaseScada.AllowUpdate = True
        Me.DatabaseScada.AutoKeyFix = ""
        Me.DatabaseScada.AutoKeyName = ""
        Me.DatabaseScada.BindingSourceName = ""
        Me.DatabaseScada.ChangeFormStatus = True
        Me.DatabaseScada.CopyFromItem = ""
        Me.DatabaseScada.DefaultValue = ""
        Me.DatabaseScada.FieldName = "DatabaseScada"
        Me.DatabaseScada.FieldType = "C"
        Me.DatabaseScada.KeyInsert = "Y"
        Me.DatabaseScada.LinkLabel = ""
        Me.DatabaseScada.Location = New System.Drawing.Point(171, 183)
        Me.DatabaseScada.Name = "DatabaseScada"
        Me.DatabaseScada.NoUpdate = "N"
        Me.DatabaseScada.PrimaryKey = "N"
        Me.DatabaseScada.Properties.AutoHeight = False
        Me.DatabaseScada.Required = "Y"
        Me.DatabaseScada.Size = New System.Drawing.Size(166, 26)
        Me.DatabaseScada.TabIndex = 492
        Me.DatabaseScada.TableName = "tblMap_cp"
        Me.DatabaseScada.UpdateIfNull = "N"
        Me.DatabaseScada.UpdateWhenFormLock = False
        Me.DatabaseScada.UpperValue = False
        Me.DatabaseScada.ViewName = "tblMap_cp"
        '
        'SqlScadaConnectionString
        '
        Me.SqlScadaConnectionString.AllowInsert = True
        Me.SqlScadaConnectionString.AllowUpdate = True
        Me.SqlScadaConnectionString.AutoKeyFix = ""
        Me.SqlScadaConnectionString.AutoKeyName = ""
        Me.SqlScadaConnectionString.BindingSourceName = ""
        Me.SqlScadaConnectionString.ChangeFormStatus = True
        Me.SqlScadaConnectionString.CopyFromItem = ""
        Me.SqlScadaConnectionString.DefaultValue = ""
        Me.SqlScadaConnectionString.FieldName = "SqlScadaConnectionString"
        Me.SqlScadaConnectionString.FieldType = "C"
        Me.SqlScadaConnectionString.KeyInsert = "Y"
        Me.SqlScadaConnectionString.LinkLabel = ""
        Me.SqlScadaConnectionString.Location = New System.Drawing.Point(273, 133)
        Me.SqlScadaConnectionString.Name = "SqlScadaConnectionString"
        Me.SqlScadaConnectionString.NoUpdate = "N"
        Me.SqlScadaConnectionString.PrimaryKey = "N"
        Me.SqlScadaConnectionString.Required = "Y"
        Me.SqlScadaConnectionString.Size = New System.Drawing.Size(0, 20)
        Me.SqlScadaConnectionString.TabIndex = 494
        Me.SqlScadaConnectionString.TableName = "tblMap_cp"
        Me.SqlScadaConnectionString.TabStop = False
        Me.SqlScadaConnectionString.UpdateIfNull = "Y"
        Me.SqlScadaConnectionString.UpdateWhenFormLock = False
        Me.SqlScadaConnectionString.UpperValue = False
        Me.SqlScadaConnectionString.ViewName = "tblMap_cp"
        '
        'Flag
        '
        Me.Flag.AllowInsert = False
        Me.Flag.AllowUpdate = False
        Me.Flag.AutoKeyFix = ""
        Me.Flag.AutoKeyName = ""
        Me.Flag.BindingSourceName = ""
        Me.Flag.ChangeFormStatus = True
        Me.Flag.CopyFromItem = ""
        Me.Flag.DefaultValue = ""
        Me.Flag.FieldName = "Flag"
        Me.Flag.FieldType = "C"
        Me.Flag.KeyInsert = "Y"
        Me.Flag.LinkLabel = ""
        Me.Flag.Location = New System.Drawing.Point(238, 109)
        Me.Flag.Name = "Flag"
        Me.Flag.NoUpdate = "N"
        Me.Flag.PrimaryKey = "N"
        Me.Flag.Required = "Y"
        Me.Flag.Size = New System.Drawing.Size(0, 20)
        Me.Flag.TabIndex = 495
        Me.Flag.TableName = "tblMap_cp"
        Me.Flag.TabStop = False
        Me.Flag.UpdateIfNull = "N"
        Me.Flag.UpdateWhenFormLock = False
        Me.Flag.UpperValue = False
        Me.Flag.ViewName = "tblMap_cp"
        '
        'FlagFinish
        '
        Me.FlagFinish.AllowInsert = False
        Me.FlagFinish.AllowUpdate = False
        Me.FlagFinish.AutoKeyFix = ""
        Me.FlagFinish.AutoKeyName = ""
        Me.FlagFinish.BindingSourceName = ""
        Me.FlagFinish.ChangeFormStatus = True
        Me.FlagFinish.CopyFromItem = ""
        Me.FlagFinish.DefaultValue = ""
        Me.FlagFinish.FieldName = "FlagFinish"
        Me.FlagFinish.FieldType = "C"
        Me.FlagFinish.KeyInsert = "Y"
        Me.FlagFinish.LinkLabel = ""
        Me.FlagFinish.Location = New System.Drawing.Point(183, 135)
        Me.FlagFinish.Name = "FlagFinish"
        Me.FlagFinish.NoUpdate = "N"
        Me.FlagFinish.PrimaryKey = "N"
        Me.FlagFinish.Required = "Y"
        Me.FlagFinish.Size = New System.Drawing.Size(0, 20)
        Me.FlagFinish.TabIndex = 496
        Me.FlagFinish.TableName = "tblMap_cp"
        Me.FlagFinish.TabStop = False
        Me.FlagFinish.UpdateIfNull = "N"
        Me.FlagFinish.UpdateWhenFormLock = False
        Me.FlagFinish.UpperValue = False
        Me.FlagFinish.ViewName = "tblMap_cp"
        '
        'Status
        '
        Me.Status.AllowInsert = True
        Me.Status.AllowUpdate = True
        Me.Status.BindingSourceName = ""
        Me.Status.ChangeFormStatus = True
        Me.Status.CopyFromItem = ""
        Me.Status.DefaultValue = ""
        Me.Status.DisplayField = "name"
        Me.Status.DropDownRow = 10
        Me.Status.FieldName = "Status"
        Me.Status.FieldType = "C"
        Me.Status.ItemValue = ""
        Me.Status.KeyInsert = ""
        Me.Status.LinkLabel = ""
        Me.Status.Location = New System.Drawing.Point(254, 5)
        Me.Status.Name = "Status"
        Me.Status.NoUpdate = ""
        Me.Status.PrimaryKey = ""
        Me.Status.Properties.AutoHeight = False
        Me.Status.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Status.Properties.NullText = ""
        Me.Status.Properties.ReadOnly = True
        Me.Status.Properties.ShowHeader = False
        Me.Status.Required = ""
        Me.Status.ShowHeader = False
        Me.Status.Size = New System.Drawing.Size(260, 26)
        Me.Status.SQL_String = "select 'out' as Code, N'HTTG->Scadar' as  name union all select 'in' as Code, N'S" & _
            "cadar->HTTG' as  name"
        Me.Status.TabIndex = 497
        Me.Status.TableName = "tblMap_cp"
        Me.Status.UpdateIfNull = ""
        Me.Status.UpdateWhenFormLock = False
        Me.Status.ValueField = "Code"
        Me.Status.ViewName = "tblMap_cp"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(174, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 13)
        Me.Label15.TabIndex = 498
        Me.Label15.Text = "Luồng dữ liệu"
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = False
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(547, 534)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(158, 26)
        Me.U_ButtonCus1.TabIndex = 499
        Me.U_ButtonCus1.Text = "Maping hàng hóa"
        '
        'FrmMapcpLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 578)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.FlagFinish)
        Me.Controls.Add(Me.Flag)
        Me.Controls.Add(Me.SqlScadaConnectionString)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.DatabaseScada)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PwdScada)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.UidScada)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ServerScada)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FlagFinishThuy)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.FlagFinishBo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FlagThuy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.FlagBo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.STT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TableName_Thuy)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableName)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.Navigator1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.DefaultSave = False
        Me.HeaderSource = "tblMap_cp"
        Me.Name = "FrmMapcpLine"
        Me.ShowFormMessage = True
        Me.Text = "Cấu hình bảng Map Scadar"
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.Navigator1, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.TableName, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TableName_Thuy, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.STT, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.FlagBo, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.FlagThuy, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.FlagFinishBo, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.FlagFinishThuy, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.ServerScada, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.UidScada, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.PwdScada, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.DatabaseScada, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.SqlScadaConnectionString, 0)
        Me.Controls.SetChildIndex(Me.Flag, 0)
        Me.Controls.SetChildIndex(Me.FlagFinish, 0)
        Me.Controls.SetChildIndex(Me.Status, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableName_Thuy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlagThuy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlagBo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlagFinishThuy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlagFinishBo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServerScada.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UidScada.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PwdScada.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatabaseScada.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SqlScadaConnectionString.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Flag.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlagFinish.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Status.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Navigator1 As U_TextBox.Navigator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableName As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableName_Thuy As U_TextBox.U_TextBox
    Friend WithEvents STT As U_TextBox.U_TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FlagThuy As U_TextBox.U_TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FlagBo As U_TextBox.U_TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FlagFinishThuy As U_TextBox.U_TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FlagFinishBo As U_TextBox.U_TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ServerScada As U_TextBox.U_TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents UidScada As U_TextBox.U_TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PwdScada As U_TextBox.U_TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DatabaseScada As U_TextBox.U_TextBox
    Friend WithEvents SqlScadaConnectionString As U_TextBox.U_TextBox
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents colSTT As U_TextBox.GridColumn
    Friend WithEvents colTableName As U_TextBox.GridColumn
    Friend WithEvents colTableName_Thuy As U_TextBox.GridColumn
    Friend WithEvents colFromField As U_TextBox.GridColumn
    Friend WithEvents colBo As U_TextBox.GridColumn
    Friend WithEvents colThuy As U_TextBox.GridColumn
    Friend WithEvents colSat As U_TextBox.GridColumn
    Friend WithEvents SWhere As U_TextBox.GridColumn
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Flag As U_TextBox.U_TextBox
    Friend WithEvents FlagFinish As U_TextBox.U_TextBox
    Friend WithEvents Status As U_TextBox.U_Combobox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
End Class
