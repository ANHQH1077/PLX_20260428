<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSMOLenh
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
        Me.TrueDBGrid3 = New U_TextBox.TrueDBGrid()
        Me.GridView3 = New U_TextBox.GridView()
        Me.Col3SoLenh = New U_TextBox.GridColumn()
        Me.col3Status = New U_TextBox.GridColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SoTichKe = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayXuat = New U_TextBox.U_DateEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoTichKe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid3
        '
        Me.TrueDBGrid3.DefaultRemove = True
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.First.Visible = False
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.Last.Visible = False
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.Next.Visible = False
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.Prev.Visible = False
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.TrueDBGrid3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid3.Location = New System.Drawing.Point(0, 45)
        Me.TrueDBGrid3.MainView = Me.GridView3
        Me.TrueDBGrid3.Name = "TrueDBGrid3"
        Me.TrueDBGrid3.Size = New System.Drawing.Size(299, 164)
        Me.TrueDBGrid3.TabIndex = 2
        Me.TrueDBGrid3.UseEmbeddedNavigator = True
        Me.TrueDBGrid3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.AllowInsert = False
        Me.GridView3.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.DetailTip.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GridView3.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.GridView3.Appearance.Empty.BorderColor = System.Drawing.Color.White
        Me.GridView3.Appearance.Empty.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.Empty.Options.UseBackColor = True
        Me.GridView3.Appearance.Empty.Options.UseBorderColor = True
        Me.GridView3.Appearance.EvenRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.FilterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.FocusedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.GroupButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.GroupFooter.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.GroupPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.HorzLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.OddRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.RowSeparator.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.SelectedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.TopNewRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.VertLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView3.CheckUpd = True
        Me.GridView3.ColumnAutoWidth = False
        Me.GridView3.ColumnKey = ""
        Me.GridView3.ColumnKeyIns = True
        Me.GridView3.ColumnKeyType = "N"
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Col3SoLenh, Me.col3Status})
        Me.GridView3.CompanyCode = ""
        Me.GridView3.DefaultRemove = True
        Me.GridView3.GetB1 = False
        Me.GridView3.GridControl = Me.TrueDBGrid3
        Me.GridView3.LastQuery = ""
        Me.GridView3.Name = "GridView3"
        Me.GridView3.ObjectChild = False
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        Me.GridView3.OrderBy = ""
        Me.GridView3.ParentItem = Nothing
        Me.GridView3.RowHeight = 35
        Me.GridView3.RowNumber = ""
        Me.GridView3.TableName = ""
        Me.GridView3.ViewName = ""
        Me.GridView3.Where = Nothing
        '
        'Col3SoLenh
        '
        Me.Col3SoLenh.AllowInsert = True
        Me.Col3SoLenh.AllowUpdate = True
        Me.Col3SoLenh.ButtonClick = True
        Me.Col3SoLenh.Caption = "Số lệnh"
        Me.Col3SoLenh.CFLColumnHide = ""
        Me.Col3SoLenh.CFLKeyField = ""
        Me.Col3SoLenh.CFLPage = False
        Me.Col3SoLenh.CFLReturn0 = ""
        Me.Col3SoLenh.CFLReturn1 = ""
        Me.Col3SoLenh.CFLReturn2 = ""
        Me.Col3SoLenh.CFLReturn3 = ""
        Me.Col3SoLenh.CFLReturn4 = ""
        Me.Col3SoLenh.CFLReturn5 = ""
        Me.Col3SoLenh.CFLReturn6 = ""
        Me.Col3SoLenh.CFLReturn7 = ""
        Me.Col3SoLenh.CFLShowLoad = False
        Me.Col3SoLenh.ChangeFormStatus = True
        Me.Col3SoLenh.ColumnKey = False
        Me.Col3SoLenh.ComboLine = 5
        Me.Col3SoLenh.CopyFromItem = ""
        Me.Col3SoLenh.DefaultButtonClick = False
        Me.Col3SoLenh.Digit = False
        Me.Col3SoLenh.FieldType = "C"
        Me.Col3SoLenh.FieldView = "SoLenh"
        Me.Col3SoLenh.FormarNumber = True
        Me.Col3SoLenh.FormList = False
        Me.Col3SoLenh.KeyInsert = ""
        Me.Col3SoLenh.LocalDecimal = False
        Me.Col3SoLenh.Name = "Col3SoLenh"
        Me.Col3SoLenh.NoUpdate = ""
        Me.Col3SoLenh.NumberDecimal = 0
        Me.Col3SoLenh.OptionsColumn.AllowEdit = False
        Me.Col3SoLenh.ParentControl = ""
        Me.Col3SoLenh.RefreshSource = False
        Me.Col3SoLenh.Required = False
        Me.Col3SoLenh.SequenceName = ""
        Me.Col3SoLenh.ShowCalc = True
        Me.Col3SoLenh.ShowDataTime = False
        Me.Col3SoLenh.ShowOnlyTime = False
        Me.Col3SoLenh.SQLString = ""
        Me.Col3SoLenh.UpdateIfNull = ""
        Me.Col3SoLenh.UpdateWhenFormLock = False
        Me.Col3SoLenh.UpperValue = False
        Me.Col3SoLenh.ValidateValue = True
        Me.Col3SoLenh.Visible = True
        Me.Col3SoLenh.VisibleIndex = 0
        Me.Col3SoLenh.Width = 100
        '
        'col3Status
        '
        Me.col3Status.AllowInsert = True
        Me.col3Status.AllowUpdate = True
        Me.col3Status.ButtonClick = True
        Me.col3Status.Caption = "Trạng thái"
        Me.col3Status.CFLColumnHide = ""
        Me.col3Status.CFLKeyField = ""
        Me.col3Status.CFLPage = False
        Me.col3Status.CFLReturn0 = ""
        Me.col3Status.CFLReturn1 = ""
        Me.col3Status.CFLReturn2 = ""
        Me.col3Status.CFLReturn3 = ""
        Me.col3Status.CFLReturn4 = ""
        Me.col3Status.CFLReturn5 = ""
        Me.col3Status.CFLReturn6 = ""
        Me.col3Status.CFLReturn7 = ""
        Me.col3Status.CFLShowLoad = False
        Me.col3Status.ChangeFormStatus = True
        Me.col3Status.ColumnKey = False
        Me.col3Status.ComboLine = 5
        Me.col3Status.CopyFromItem = ""
        Me.col3Status.DefaultButtonClick = False
        Me.col3Status.Digit = False
        Me.col3Status.FieldType = "C"
        Me.col3Status.FieldView = "Status_Name"
        Me.col3Status.FormarNumber = True
        Me.col3Status.FormList = False
        Me.col3Status.KeyInsert = ""
        Me.col3Status.LocalDecimal = False
        Me.col3Status.Name = "col3Status"
        Me.col3Status.NoUpdate = ""
        Me.col3Status.NumberDecimal = 0
        Me.col3Status.OptionsColumn.AllowEdit = False
        Me.col3Status.ParentControl = ""
        Me.col3Status.RefreshSource = False
        Me.col3Status.Required = False
        Me.col3Status.SequenceName = ""
        Me.col3Status.ShowCalc = True
        Me.col3Status.ShowDataTime = False
        Me.col3Status.ShowOnlyTime = False
        Me.col3Status.SQLString = ""
        Me.col3Status.UpdateIfNull = ""
        Me.col3Status.UpdateWhenFormLock = False
        Me.col3Status.UpperValue = False
        Me.col3Status.ValidateValue = True
        Me.col3Status.Visible = True
        Me.col3Status.VisibleIndex = 1
        Me.col3Status.Width = 160
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 19)
        Me.Label5.TabIndex = 479
        Me.Label5.Text = "TKê"
        '
        'SoTichKe
        '
        Me.SoTichKe.AllowInsert = False
        Me.SoTichKe.AllowUpdate = False
        Me.SoTichKe.AutoKeyFix = ""
        Me.SoTichKe.AutoKeyName = ""
        Me.SoTichKe.BindingSourceName = ""
        Me.SoTichKe.ChangeFormStatus = True
        Me.SoTichKe.CopyFromItem = ""
        Me.SoTichKe.DefaultValue = ""
        Me.SoTichKe.FieldName = ""
        Me.SoTichKe.FieldType = ""
        Me.SoTichKe.KeyInsert = ""
        Me.SoTichKe.LinkLabel = ""
        Me.SoTichKe.Location = New System.Drawing.Point(44, 12)
        Me.SoTichKe.Name = "SoTichKe"
        Me.SoTichKe.NoUpdate = "N"
        Me.SoTichKe.PrimaryKey = ""
        Me.SoTichKe.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.Appearance.Options.UseFont = True
        Me.SoTichKe.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoTichKe.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoTichKe.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoTichKe.Properties.AutoHeight = False
        Me.SoTichKe.Required = ""
        Me.SoTichKe.Size = New System.Drawing.Size(68, 26)
        Me.SoTichKe.TabIndex = 478
        Me.SoTichKe.TableName = ""
        Me.SoTichKe.UpdateIfNull = ""
        Me.SoTichKe.UpdateWhenFormLock = False
        Me.SoTichKe.UpperValue = False
        Me.SoTichKe.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(118, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 19)
        Me.Label2.TabIndex = 543
        Me.Label2.Text = "Ngày"
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = False
        Me.NgayXuat.AllowUpdate = True
        Me.NgayXuat.BindingSourceName = ""
        Me.NgayXuat.ChangeFormStatus = True
        Me.NgayXuat.CopyFromItem = ""
        Me.NgayXuat.DefaultValue = ""
        Me.NgayXuat.EditValue = Nothing
        Me.NgayXuat.FieldName = ""
        Me.NgayXuat.FieldType = "D"
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LinkLabel = ""
        Me.NgayXuat.Location = New System.Drawing.Point(167, 12)
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.PrimaryKey = ""
        Me.NgayXuat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.Appearance.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceDisabled.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceFocused.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.NgayXuat.Properties.AutoHeight = False
        Me.NgayXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayXuat.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayXuat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayXuat.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayXuat.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayXuat.Required = ""
        Me.NgayXuat.ShowDateTime = False
        Me.NgayXuat.Size = New System.Drawing.Size(113, 26)
        Me.NgayXuat.TabIndex = 542
        Me.NgayXuat.TableName = ""
        Me.NgayXuat.TabStop = False
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.ViewName = ""
        '
        'FrmSMOLenh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 213)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayXuat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.SoTichKe)
        Me.Controls.Add(Me.TrueDBGrid3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmSMOLenh"
        Me.ShowInTaskbar = True
        Me.Controls.SetChildIndex(Me.TrueDBGrid3, 0)
        Me.Controls.SetChildIndex(Me.SoTichKe, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.NgayXuat, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoTichKe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid3 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView3 As U_TextBox.GridView
    Friend WithEvents Col3SoLenh As U_TextBox.GridColumn
    Friend WithEvents col3Status As U_TextBox.GridColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SoTichKe As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayXuat As U_TextBox.U_DateEdit
End Class
