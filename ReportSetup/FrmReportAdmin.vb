Public Class FrmReportAdmin
    Const p_Start_Caption_X As Integer = 12
    Const p_Start_Caption_Y As Integer = 79
    Const p_Start_Item_X As Integer = 60
    'Const p_Start_Item_Y As Integer = 79
    Const p_Date_Width As Integer = 120
    Const p_Text_Width As Integer = 250

    Private p_ItemDate As U_TextBox.U_DateEdit
    Private p_ItemText As U_TextBox.U_TextBox
    Private p_ButtonEdit As U_TextBox.U_ButtonEdit
    Private p_Combobox As U_TextBox.U_Combobox
    Private p_ItemNumber As U_TextBox.U_NumericEdit
    'Private p_ItemNumber As U_TextBox.U_NumericEdit
    Private p_Cation As Label
    Private p_SYS_CONFIG_RPT_PARA As DataTable
    Private p_SYS_CONFIG_RPT As DataTable
    Private p_SYS_CONFIG_RPT_FIELD As DataTable

    Private Sub FrmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        p_SQL = "select * from   SYS_CONFIG_RPT_PARA; select * from SYS_CONFIG_RPT_FIELD; select * from SYS_CONFIG_RPT;"
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)
        p_SYS_CONFIG_RPT_PARA = p_DataSet.Tables(0)
        p_SYS_CONFIG_RPT_FIELD = p_DataSet.Tables(1)
        p_SYS_CONFIG_RPT = p_DataSet.Tables(2)

        Me.VerticalScroll.Visible = True
        Me.VScroll = True

        Me.HorizontalScroll.Visible = True
        Me.HScroll = True

    End Sub


    Private Sub CreateParameter()
        Dim p_Datatable As DataTable
        Dim p_SQL As String
        Dim p_ReportCode As String = ""
        Dim p_ArrRow() As DataRow
        Dim p_Count As Integer
        Dim p_ITop As Integer
        Dim p_ILeft As Integer

        Dim p_CTop As Integer
        Dim p_CLeft As Integer
        Dim p_Required As String
        Dim p_ItemToLeft As Integer
        Dim p_TabIndex As Integer = 0

        Dim p_ItemWidth As Integer
        Dim p_ItemType As String
        Dim p_ViewName As String

        p_ItemWidth = Me.ReportName.Width

        'p_CTop = p_Start_Caption_Y
        p_CLeft = p_Start_Caption_X

        p_ILeft = p_Start_Item_X
        p_ITop = p_Start_Caption_Y

        If Not Me.ReportCode.EditValue Is Nothing Then
            p_ReportCode = Me.ReportCode.EditValue.ToString.Trim
        End If
        If p_ReportCode = "" Then
            ShowMessageBox("", "Báo cáo không xác định")
            Exit Sub
        End If

        p_ArrRow = p_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        p_ViewName = p_ArrRow(0).Item("ViewName").ToString.Trim

        p_ArrRow = p_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "'", "STT")


        For p_Count = 0 To p_ArrRow.Length - 1
            p_Required = p_ArrRow(p_Count).Item("Required").ToString.Trim
            p_Cation = Nothing
            p_ItemDate = Nothing
            p_ItemText = Nothing
            p_ItemNumber = Nothing

            p_ButtonEdit = Nothing
            p_Combobox = Nothing


            p_Cation = New Label()
            p_Cation.Top = p_ITop
            p_Cation.Left = p_CLeft
            p_Cation.Name = "lbl" & p_ArrRow(p_Count).Item("ItemName").ToString.Trim  'hieptd4 add 20160802
            p_Cation.Text = p_ArrRow(p_Count).Item("ItemDesc").ToString.Trim
            Me.Controls.Add(p_Cation)
            p_TabIndex = p_TabIndex + 1

            p_ItemType = p_ArrRow(p_Count).Item("ItemType").ToString.Trim

            Select Case UCase(p_ArrRow(p_Count).Item("ItemValue").ToString.Trim)

                Case UCase("Time") 'hieptd4 add (hour : minute)
                    p_ItemDate = New U_TextBox.U_DateEdit()
                    p_ItemDate.Properties.Buttons(0).Visible = False
                    p_ItemDate.Width = 20
                    p_ITop = p_ITop + p_ItemDate.Height - 5
                    p_ItemDate.Top = p_ITop
                    p_ItemDate.Left = p_ILeft
                    p_ItemDate.Name = p_ArrRow(p_Count).Item("ItemName").ToString.Trim
                    If p_Required = "Y" Then
                        p_ItemDate.Required = "Y"
                        p_ItemDate.BackColor = pv_Required_Back_Color
                    End If
                    p_ItemDate.TabIndex = p_TabIndex
                    p_ItemDate.TabStop = True
                    p_ItemDate.ChangeFormStatus = False

                    Me.Controls.Add(p_ItemDate)
                    'If UCase(p_ArrRow(p_Count).Item("ItemValue").ToString.Trim) = "DATETIME" Then
                    'p_ItemDate.EditValue = Now.Date
                    'p_ItemDate.Text = Format(Now, "hh:mm") 

                    p_ItemDate.Properties.DisplayFormat.FormatString = "HH:mm:ss"
                    p_ItemDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                    p_ItemDate.Properties.EditMask = "HH:mm:ss"
                    p_ItemDate.ShowDateTime = True
                    'p_ItemDate.Text = Format(Now.Date.AddHours(0).AddMinutes(0).AddSeconds(0), "HH:mm")

                    p_ItemDate.EditValue = Now.Date
                    p_ItemDate.Width = p_ItemDate.Width + 70
                    p_ItemDate.Font = New Font("Tahoma", 9, FontStyle.Regular)
                    p_ItemDate.Properties.Appearance.Options.UseFont = False
                    p_ItemDate.Properties.Appearance.Font = p_ItemDate.Font
                    p_ItemDate.Properties.AppearanceDisabled.Options.UseFont = False
                    p_ItemDate.Properties.AppearanceDisabled.Font = p_ItemDate.Font
                    p_ItemDate.Properties.AppearanceFocused.Options.UseFont = False
                    p_ItemDate.Properties.AppearanceFocused.Font = p_ItemDate.Font
                    p_ItemDate.Properties.AppearanceReadOnly.Options.UseFont = False
                    p_ItemDate.Properties.AppearanceReadOnly.Font = p_ItemDate.Font
                    'End If

                    If p_ArrRow(p_Count).Item("ToItemName").ToString.Trim <> "" Then
                        p_Cation = Nothing
                        p_Cation = New Label()
                        p_Cation.Top = p_ITop
                        p_Cation.Left = p_ILeft + 3 + p_ItemDate.Width
                        p_Cation.Text = "to"
                        ' p_Cation.AutoSize = True
                        p_Cation.Width = 15
                        Me.Controls.Add(p_Cation)

                        p_ItemDate = Nothing
                        p_ItemDate = New U_TextBox.U_DateEdit()
                        p_ItemDate.Properties.Buttons(0).Visible = False
                        p_ItemDate.Width = 20
                        p_ItemDate.Top = p_ITop
                        p_ItemDate.Left = p_Cation.Left + 3 + p_Cation.Width
                        p_ItemDate.Name = p_ArrRow(p_Count).Item("ToItemName").ToString.Trim
                        If p_Required = "Y" Then
                            p_ItemDate.Required = "Y"
                            p_ItemDate.BackColor = pv_Required_Back_Color
                        End If

                        'If UCase(p_ArrRow(p_Count).Item("ItemValue").ToString.Trim) = "DATETIME" Then

                        p_ItemDate.Properties.DisplayFormat.FormatString = "HH:mm:ss"
                        p_ItemDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        p_ItemDate.Properties.EditMask = "HH:mm:ss"
                        p_ItemDate.ShowDateTime = True
                        p_ItemDate.Font = New Font("Tahoma", 9, FontStyle.Regular)
                        'p_ItemDate.Text = Format(Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59), "HH:mm")
                        Dim p_Lastime As DateTime
                        p_Lastime = Now.Date
                        p_Lastime = DateAdd(DateInterval.Hour, 23, p_Lastime)
                        p_Lastime = DateAdd(DateInterval.Minute, 59, p_Lastime)
                        p_Lastime = DateAdd(DateInterval.Second, 59, p_Lastime)
                        p_ItemDate.EditValue = p_Lastime
                        p_ItemDate.Width = p_ItemDate.Width + 70
                        'p_ItemDate.ShowDateTime = True
                        'p_ItemDate.Width = p_ItemDate.Width + 20
                        'p_ItemDate.Font = New Font("Tahoma", 9, FontStyle.Regular)
                        p_ItemDate.Properties.Appearance.Options.UseFont = False
                        p_ItemDate.Properties.Appearance.Font = p_ItemDate.Font
                        p_ItemDate.Properties.AppearanceDisabled.Options.UseFont = False
                        p_ItemDate.Properties.AppearanceDisabled.Font = p_ItemDate.Font
                        p_ItemDate.Properties.AppearanceFocused.Options.UseFont = False
                        p_ItemDate.Properties.AppearanceFocused.Font = p_ItemDate.Font
                        p_ItemDate.Properties.AppearanceReadOnly.Options.UseFont = False
                        p_ItemDate.Properties.AppearanceReadOnly.Font = p_ItemDate.Font
                        'End If


                        p_TabIndex = p_TabIndex + 1
                        p_ItemDate.TabIndex = p_TabIndex
                        p_ItemDate.TabStop = True
                        p_ItemDate.ChangeFormStatus = False
                        Me.Controls.Add(p_ItemDate)
                    End If
                    p_ITop = p_ITop + p_ItemDate.Height + 5



                Case UCase("Date"), UCase("Datetime")
                    p_ItemDate = New U_TextBox.U_DateEdit()

                    p_ItemDate.Width = 130
                    p_ITop = p_ITop + p_ItemDate.Height + 5
                    p_ItemDate.Top = p_ITop
                    p_ItemDate.Left = p_ILeft
                    p_ItemDate.Name = p_ArrRow(p_Count).Item("ItemName").ToString.Trim
                    If p_Required = "Y" Then
                        p_ItemDate.Required = "Y"
                        p_ItemDate.BackColor = pv_Required_Back_Color
                    End If
                    p_ItemDate.TabIndex = p_TabIndex
                    p_ItemDate.TabStop = True
                    p_ItemDate.ChangeFormStatus = False

                    p_ItemDate.FieldType = "D"
                    Me.Controls.Add(p_ItemDate)
                    If UCase(p_ArrRow(p_Count).Item("ItemValue").ToString.Trim) = "DATETIME" Then
                        p_ItemDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
                        p_ItemDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        p_ItemDate.Properties.EditMask = "dd/MM/yyyy hh:mm:ss tt"

                        p_ItemDate.ShowDateTime = True
                        p_ItemDate.Width = p_ItemDate.Width + 30
                        p_ItemDate.Font = New Font("Tahoma", 9, FontStyle.Regular)
                        p_ItemDate.Properties.Appearance.Options.UseFont = False
                        p_ItemDate.Properties.Appearance.Font = p_ItemDate.Font
                        p_ItemDate.Properties.AppearanceDisabled.Options.UseFont = False
                        p_ItemDate.Properties.AppearanceDisabled.Font = p_ItemDate.Font
                        p_ItemDate.Properties.AppearanceFocused.Options.UseFont = False
                        p_ItemDate.Properties.AppearanceFocused.Font = p_ItemDate.Font
                        p_ItemDate.Properties.AppearanceReadOnly.Options.UseFont = False
                        p_ItemDate.Properties.AppearanceReadOnly.Font = p_ItemDate.Font
                    End If

                    'If UCase(p_ArrRow(p_Count).Item("ItemValue").ToString.Trim) = "TIME" Then
                    '    p_ItemDate.Properties.DisplayFormat.FormatString = "hh:mm:ss tt"
                    '    p_ItemDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                    '    p_ItemDate.Properties.EditMask = "hh:mm:ss tt"

                    '    p_ItemDate.ShowDateTime = True
                    '    p_ItemDate.Width = p_ItemDate.Width
                    '    ' p_ItemDate.Font = New Font("Tahoma", 9, FontStyle.Regular)
                    '    p_ItemDate.Properties.Appearance.Options.UseFont = False
                    '    p_ItemDate.Properties.Appearance.Font = p_ItemDate.Font
                    '    p_ItemDate.Properties.AppearanceDisabled.Options.UseFont = False
                    '    p_ItemDate.Properties.AppearanceDisabled.Font = p_ItemDate.Font
                    '    p_ItemDate.Properties.AppearanceFocused.Options.UseFont = False
                    '    p_ItemDate.Properties.AppearanceFocused.Font = p_ItemDate.Font
                    '    p_ItemDate.Properties.AppearanceReadOnly.Options.UseFont = False
                    '    p_ItemDate.Properties.AppearanceReadOnly.Font = p_ItemDate.Font
                    'End If

                    If p_ArrRow(p_Count).Item("ToItemName").ToString.Trim <> "" Then
                        p_Cation = Nothing
                        p_Cation = New Label()
                        p_Cation.Top = p_ITop
                        p_Cation.Left = p_ILeft + 3 + p_ItemDate.Width
                        p_Cation.Text = "to"
                        ' p_Cation.AutoSize = True
                        p_Cation.Width = 15
                        Me.Controls.Add(p_Cation)

                        p_ItemDate = Nothing
                        p_ItemDate = New U_TextBox.U_DateEdit()
                        p_ItemDate.Width = 130
                        p_ItemDate.Top = p_ITop
                        p_ItemDate.Left = p_Cation.Left + 3 + p_Cation.Width
                        p_ItemDate.Name = p_ArrRow(p_Count).Item("ToItemName").ToString.Trim
                        If p_Required = "Y" Then
                            p_ItemDate.Required = "Y"
                            p_ItemDate.BackColor = pv_Required_Back_Color
                        End If

                        If UCase(p_ArrRow(p_Count).Item("ItemValue").ToString.Trim) = "DATETIME" Then
                            p_ItemDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
                            p_ItemDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            p_ItemDate.Properties.EditMask = "dd/MM/yyyy hh:mm:ss tt"
                            p_ItemDate.ShowDateTime = True
                            p_ItemDate.Font = New Font("Tahoma", 9, FontStyle.Regular)
                            p_ItemDate.Width = p_ItemDate.Width + 20

                            p_ItemDate.ShowDateTime = True
                            p_ItemDate.Width = p_ItemDate.Width + 20
                            p_ItemDate.Font = New Font("Tahoma", 9, FontStyle.Regular)
                            p_ItemDate.Properties.Appearance.Options.UseFont = False
                            p_ItemDate.Properties.Appearance.Font = p_ItemDate.Font
                            p_ItemDate.Properties.AppearanceDisabled.Options.UseFont = False
                            p_ItemDate.Properties.AppearanceDisabled.Font = p_ItemDate.Font
                            p_ItemDate.Properties.AppearanceFocused.Options.UseFont = False
                            p_ItemDate.Properties.AppearanceFocused.Font = p_ItemDate.Font
                            p_ItemDate.Properties.AppearanceReadOnly.Options.UseFont = False
                            p_ItemDate.Properties.AppearanceReadOnly.Font = p_ItemDate.Font


                        End If

                        'If UCase(p_ArrRow(p_Count).Item("ItemValue").ToString.Trim) = "TIME" Then
                        '    p_ItemDate.Properties.DisplayFormat.FormatString = "hh:mm:ss tt"
                        '    p_ItemDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        '    p_ItemDate.Properties.EditMask = "hh:mm:ss tt"

                        '    p_ItemDate.ShowDateTime = True
                        '    p_ItemDate.Width = p_ItemDate.Width
                        '    ' p_ItemDate.Font = New Font("Tahoma", 9, FontStyle.Regular)
                        '    p_ItemDate.Properties.Appearance.Options.UseFont = False
                        '    p_ItemDate.Properties.Appearance.Font = p_ItemDate.Font
                        '    p_ItemDate.Properties.AppearanceDisabled.Options.UseFont = False
                        '    p_ItemDate.Properties.AppearanceDisabled.Font = p_ItemDate.Font
                        '    p_ItemDate.Properties.AppearanceFocused.Options.UseFont = False
                        '    p_ItemDate.Properties.AppearanceFocused.Font = p_ItemDate.Font
                        '    p_ItemDate.Properties.AppearanceReadOnly.Options.UseFont = False
                        '    p_ItemDate.Properties.AppearanceReadOnly.Font = p_ItemDate.Font
                        'End If


                        p_ItemDate.FieldType = "D"

                        p_TabIndex = p_TabIndex + 1
                        p_ItemDate.TabIndex = p_TabIndex
                        p_ItemDate.TabStop = True
                        p_ItemDate.ChangeFormStatus = False
                        Me.Controls.Add(p_ItemDate)
                    End If
                    p_ITop = p_ITop + p_ItemDate.Height + 5
                Case UCase("TEXT")
                    Select Case UCase(p_ItemType)
                        Case "LIST"
                            p_ButtonEdit = New U_TextBox.U_ButtonEdit
                            p_ITop = p_ITop + p_ButtonEdit.Height + 3
                            p_ButtonEdit.Top = p_ITop
                            p_ButtonEdit.Left = p_ILeft
                            p_ButtonEdit.SqlString = p_ArrRow(p_Count).Item("ItemSQL").ToString.Trim
                            p_ButtonEdit.SqlFielKey = p_ArrRow(p_Count).Item("FieldKey").ToString.Trim
                            p_ButtonEdit.LinkLabel = p_Cation.Name  'hieptd4 add 20160802
                            p_ButtonEdit.Name = p_ArrRow(p_Count).Item("ItemName").ToString.Trim
                            If p_Required = "Y" Then
                                p_ButtonEdit.Required = "Y"
                                p_ButtonEdit.BackColor = pv_Required_Back_Color
                            End If
                            p_ButtonEdit.TabIndex = p_TabIndex
                            p_ButtonEdit.DefaultButtonClick = True
                            p_ButtonEdit.TabStop = True
                            p_ButtonEdit.ShowLoad = True
                            p_ButtonEdit.ChangeFormStatus = False
                            p_ButtonEdit.FieldType = "C"
                            Me.Controls.Add(p_ButtonEdit)
                            p_ITop = p_ITop + p_ButtonEdit.Height + 5
                        Case "COMBOX"
                            p_Combobox = New U_TextBox.U_Combobox
                            p_ITop = p_ITop + p_Combobox.Height + 5
                            p_Combobox.Top = p_ITop
                            p_Combobox.Left = p_ILeft
                            p_Combobox.SQL_String = p_ArrRow(p_Count).Item("ItemSQL").ToString.Trim

                            p_Combobox.LinkLabel = p_Cation.Name  'hieptd4 add 20160802
                            p_Combobox.Name = p_ArrRow(p_Count).Item("ItemName").ToString.Trim
                            If p_Required = "Y" Then
                                p_Combobox.Required = "Y"
                                p_Combobox.BackColor = pv_Required_Back_Color
                            End If
                            p_Combobox.TabIndex = p_TabIndex
                            p_Combobox.TabStop = True
                            p_Combobox.ChangeFormStatus = False
                            GetSourceCombobox(Me, p_Combobox)
                            p_Combobox.FieldType = "C"
                            Me.Controls.Add(p_Combobox)
                            p_ITop = p_ITop + p_Combobox.Height + 5
                        Case Else
                            p_ItemText = New U_TextBox.U_TextBox()
                            p_ITop = p_ITop + p_ItemText.Height + 5
                            p_ItemText.Top = p_ITop
                            p_ItemText.Left = p_ILeft
                            p_ItemText.LinkLabel = p_Cation.Name  'hieptd4 add 20160802
                            p_ItemText.Name = p_ArrRow(p_Count).Item("ItemName").ToString.Trim
                            If p_Required = "Y" Then
                                p_ItemText.Required = "Y"
                                p_ItemText.BackColor = pv_Required_Back_Color
                            End If
                            p_ItemText.TabIndex = p_TabIndex
                            p_ItemText.TabStop = True
                            p_ItemText.ChangeFormStatus = False
                            p_ItemText.FieldType = "C"
                            Me.Controls.Add(p_ItemText)
                            p_ITop = p_ITop + p_ItemText.Height + 5
                    End Select
                Case Else  'Number
                    Select Case UCase(p_ItemType)
                        Case "LIST"
                            p_ButtonEdit = New U_TextBox.U_ButtonEdit
                            p_ITop = p_ITop + p_ButtonEdit.Height + 5
                            p_ButtonEdit.Top = p_ITop
                            p_ButtonEdit.Left = p_ILeft
                            p_ButtonEdit.SqlString = p_ArrRow(p_Count).Item("ItemSQL").ToString.Trim
                            p_ButtonEdit.SqlFielKey = p_ArrRow(p_Count).Item("FieldKey").ToString.Trim

                            p_ButtonEdit.Name = p_ArrRow(p_Count).Item("ItemName").ToString.Trim
                            If p_Required = "Y" Then
                                p_ButtonEdit.Required = "Y"
                                p_ButtonEdit.BackColor = pv_Required_Back_Color
                            End If
                            p_ButtonEdit.ShowLoad = True
                            p_ButtonEdit.TabIndex = p_TabIndex
                            p_ButtonEdit.DefaultButtonClick = True
                            p_ButtonEdit.TabStop = True
                            p_ButtonEdit.ChangeFormStatus = False
                            p_ButtonEdit.FieldType = "N"

                            Me.Controls.Add(p_ButtonEdit)
                            p_ITop = p_ITop + p_ButtonEdit.Height + 5
                        Case "COMBOX"
                            p_Combobox = New U_TextBox.U_Combobox
                            p_ITop = p_ITop + p_Combobox.Height + 5
                            p_Combobox.Top = p_ITop
                            p_Combobox.Left = p_ILeft
                            p_Combobox.SQL_String = p_ArrRow(p_Count).Item("ItemSQL").ToString.Trim


                            p_Combobox.Name = p_ArrRow(p_Count).Item("ItemName").ToString.Trim
                            If p_Required = "Y" Then
                                p_Combobox.Required = "Y"
                                p_Combobox.BackColor = pv_Required_Back_Color
                            End If
                            p_Combobox.TabIndex = p_TabIndex
                            p_Combobox.TabStop = True
                            p_Combobox.ChangeFormStatus = False
                            GetSourceCombobox(Me, p_Combobox)
                            p_Combobox.FieldType = "N"

                            Me.Controls.Add(p_Combobox)
                            p_ITop = p_ITop + p_Combobox.Height + 5
                        Case Else
                            p_ItemNumber = New U_TextBox.U_NumericEdit()
                            p_ITop = p_ITop + p_ItemNumber.Height + 5
                            p_ItemNumber.Top = p_ITop
                            p_ItemNumber.Left = p_ILeft
                            p_ItemNumber.Name = p_ArrRow(p_Count).Item("ItemName").ToString.Trim
                            If p_Required = "Y" Then
                                p_ItemNumber.Required = "Y"
                                p_ItemNumber.BackColor = pv_Required_Back_Color
                            End If
                            p_ItemNumber.TabIndex = p_TabIndex
                            p_ItemNumber.TabStop = True
                            p_ItemNumber.ChangeFormStatus = False
                            p_ItemNumber.FieldType = "N"

                            Me.Controls.Add(p_ItemNumber)
                            p_ITop = p_ITop + p_ItemNumber.Height + 5
                    End Select
            End Select
        Next


        'CreateColumn(p_ReportCode, p_ViewName)

    End Sub

    '
    Private Sub ClearParameter()
        Dim p_ItemName As String
        Dim p_count As Integer
        Dim p_Item As Object
        ' For Each p_Item In Me.Controls
        For p_count = Me.Controls.Count - 1 To 0 Step -1
            p_Item = Me.Controls(p_count)
            If UCase(p_Item.name.ToString.Trim) <> UCase("ReportCode") _
                And UCase(p_Item.name.ToString.Trim) <> UCase("ReportName") _
                And UCase(p_Item.name.ToString.Trim) <> UCase("CReportCode") _
                And UCase(p_Item.name.ToString.Trim) <> UCase("TrueDBGrid1") _
                And UCase(p_Item.name.ToString.Trim) <> UCase("cmdexcel") _
                And UCase(p_Item.name.ToString.Trim) <> UCase("cmdrun") _
                And UCase(p_Item.name.ToString.Trim) <> UCase("CmdReport") _
                And UCase(p_Item.name.ToString.Trim) <> UCase("ToolStrip2") _
                And UCase(p_Item.name.ToString.Trim) <> UCase("ToolStrip1") Then
                Me.Controls.Remove(p_Item)
            End If

        Next
        ' Next
        Me.ReportCode.Focus()
    End Sub

    Private Sub CreateColumn(ByVal p_ReportCode As String, ByVal p_ViewName As String)
        Dim p_Column As Object
        Dim p_Count As Integer
        Dim p_ArrRow() As DataRow
        Dim p_SQL As String
        Dim p_Tbl0, p_Tbl1 As DataTable
        Dim p_bindingSource As New U_TextBox.U_BindingSource
        Dim p_Col As DataColumn
        Dim p_Col_width As Double
        Dim p_Width_Default As Integer = 150


        If Me.GridView1.Columns.Count > 0 Then
            Try
                'For p_Count = Me.GridView1.Columns.Count - 1 To 0 Step -1
                '    p_Column = Me.GridView1.Columns(p_Count)
                '    Me.GridView1.Columns.Remove(p_Column)
                'Next

                For Each p_Column In Me.GridView1.Columns
                    ' p_Column = Me.GridView1.Columns(p_Count)
                    Me.GridView1.Columns.Remove(p_Column)
                Next

            Catch ex As Exception

            End Try

        End If

        Me.GridView1.ViewName = p_ViewName
        p_SQL = "select * from " & p_ViewName & " where 1=0"
        p_Tbl0 = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)


        p_ArrRow = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "'", "STT")

        p_Tbl1 = New DataTable("Tbl1")
        For p_Count = 0 To p_ArrRow.Length - 1
            p_Col = New DataColumn
            p_Col.ColumnName = p_Tbl0.Columns.Item(p_ArrRow(p_Count).Item("FieldName")).ColumnName
            p_Col.DataType = p_Tbl0.Columns.Item(p_ArrRow(p_Count).Item("FieldName")).DataType
            p_Tbl1.Columns.Add(p_Col)

        Next
        p_bindingSource.DataSource = p_Tbl1
        Me.TrueDBGrid1.DataSource = p_bindingSource

        'Me.TrueDBGrid1.Refresh()
        For p_Count = 0 To p_ArrRow.Length - 1
            p_Col_width = 1
            If p_ArrRow(p_Count).Item("FieldWidth").ToString.Trim <> "" Then
                p_Col_width = p_ArrRow(p_Count).Item("FieldWidth").ToString.Trim
            End If
            Me.GridView1.Columns.Item(p_Count).Width = p_Col_width * p_Width_Default
            Me.GridView1.Columns.Item(p_Count).FieldName = p_ArrRow(p_Count).Item("FieldName").ToString.Trim
            Me.GridView1.Columns.Item(p_Count).Caption = p_ArrRow(p_Count).Item("FieldDesc").ToString.Trim
            Me.GridView1.Columns.Item(p_Count).OptionsColumn.AllowEdit = False
        Next
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.ClearGrouping()
        Me.TrueDBGrid1.Refresh()
        Me.TrueDBGrid1.RefreshDataSource()
    End Sub


    Private Sub ReportCode_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles ReportCode.EditValueChanging


    End Sub

    Private Sub ReportCode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportCode.EditValueChanged
        'Dim p_NewValue As String = ""
        ' Dim p_OldValue As String = ""

        Try
            If Not Me.ReportCode.EditValue Is Nothing Then
                ClearParameter()
                CreateParameter()

                ' Me.TrueDBGrid1.
                'For Each p_Column In Me.GridView1.Columns
                '    GridView1.Columns.Remove(p_Column)
                ' Next
                ' Me.TrueDBGrid1.Refresh()

                'Me.DefaultFormLoad = True
                'Me.XtraForm1_Load()
                'Me.DefaultFormLoad = False


            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        Dim p_SQL As String
        Dim p_BaoCao As String = ""
        Dim p_LoaiBaoCao As String = "V"
        Dim p_RowArr() As DataRow
        Dim p_ProcedureName As String
        Dim p_TableReturn As DataTable
        Dim p_Dynamic As String = "N"
        If Not Me.ReportCode.EditValue Is Nothing Then
            p_BaoCao = Me.ReportCode.EditValue.ToString.Trim
        End If

        If p_BaoCao = "" Then
            Exit Sub
        End If

        p_RowArr = p_SYS_CONFIG_RPT.Select("ReportCode='" & p_BaoCao & "'")
        If p_RowArr.Length > 0 Then
            p_LoaiBaoCao = p_RowArr(0).Item("SourceType").ToString.Trim
            p_Dynamic = IIf(p_RowArr(0).Item("RptDynamic").ToString.Trim = "", "N", p_RowArr(0).Item("RptDynamic").ToString.Trim)
        End If
        If p_Dynamic = "N" Then
            If p_LoaiBaoCao = "V" Then
                QueryData(True, p_SQL, p_TableReturn)
            Else
                p_ProcedureName = p_RowArr(0).Item("ViewName").ToString.Trim
                ExeProcedureData(True, p_SQL, p_BaoCao, p_ProcedureName, p_TableReturn)
            End If
        Else
            If p_LoaiBaoCao = "V" Then
                QueryData(False, p_SQL, p_TableReturn)
            Else
                p_ProcedureName = p_RowArr(0).Item("ViewName").ToString.Trim
                ExeProcedureData(False, p_SQL, p_BaoCao, p_ProcedureName, p_TableReturn)
            End If
        End If

        Cursor = Cursors.Default

    End Sub


    Sub QueryData(ByVal p_RunReport As Boolean, ByRef p_SQLReturn As String, ByRef p_TableReturn As DataTable)
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_BindingSource As New U_TextBox.U_BindingSource
        Dim p_ReportCode As String = ""
        Dim p_ArrRow() As DataRow
        Dim p_count As Integer
        Dim p_Object As Object
        Dim p_Where As String = ""
        Dim p_Value As String
        Dim item1 As DevExpress.XtraGrid.GridGroupSummaryItem

        Try
            If p_TableReturn Is Nothing Then
                p_TableReturn = New DataTable
            End If
            If Not Me.ReportCode.EditValue Is Nothing Then
                p_ReportCode = Me.ReportCode.EditValue.ToString.Trim
            End If
            If p_ReportCode = "" Then
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor


            p_ArrRow = p_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "'", "STT")
            For p_count = 0 To p_ArrRow.Length - 1
                p_Object = Me.Controls.Find(p_ArrRow(p_count).Item("ItemName"), True)
                If Not p_Object Is Nothing Then
                    If Not p_Object(0).editValue Is Nothing Then
                        p_Value = p_Object(0).editValue.ToString.Trim
                        If p_Object(0).required = "Y" Then
                            If p_Value = "" Then
                                ShowMessageBox("", p_ArrRow(p_count).Item("ItemDesc") & "- chưa nhập giá trị")
                                Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If
                        If p_Value <> "" Then
                            Select Case UCase(p_ArrRow(p_count).Item("ItemValue"))
                                Case "DATE"
                                    If p_Where = "" Then
                                        p_Where = p_ArrRow(p_count).Item("FieldName") & IIf(p_ArrRow(p_count).Item("ToItemName").ToString.Trim <> "", ">=", "=") & "'" & CDate(p_Object(0).editValue).ToString("yyyyMMdd") & "'"
                                    Else
                                        p_Where = p_Where & " AND " & p_ArrRow(p_count).Item("FieldName") & IIf(p_ArrRow(p_count).Item("ToItemName").ToString.Trim <> "", ">=", "=") & "'" & CDate(p_Object(0).editValue).ToString("yyyyMMdd") & "'"
                                    End If
                                Case "TEXT"
                                    If p_Where = "" Then
                                        p_Where = p_ArrRow(p_count).Item("FieldName") & IIf(p_ArrRow(p_count).Item("ToItemName").ToString.Trim <> "", ">=", "=") & "'" & p_Object(0).editValue.ToString.Trim & "'"
                                    Else
                                        p_Where = p_Where & " AND " & p_ArrRow(p_count).Item("FieldName") & IIf(p_ArrRow(p_count).Item("ToItemName").ToString.Trim <> "", ">=", "=") & "'" & p_Object(0).editValue.ToString.Trim & "'"
                                    End If
                                Case Else
                                    If p_Where = "" Then
                                        p_Where = p_ArrRow(p_count).Item("FieldName") & IIf(p_ArrRow(p_count).Item("ToItemName").ToString.Trim <> "", ">=", "=") & "" & p_Object(0).editValue.ToString.Trim
                                    Else
                                        p_Where = p_Where & " AND " & p_ArrRow(p_count).Item("FieldName") & IIf(p_ArrRow(p_count).Item("ToItemName").ToString.Trim <> "", ">=", "=") & "" & p_Object(0).editValue.ToString.Trim
                                    End If
                            End Select
                        End If
                    End If
                End If

                'To value
                If p_ArrRow(p_count).Item("ToItemName").ToString.Trim <> "" Then
                    p_Object = Me.Controls.Find(p_ArrRow(p_count).Item("ToItemName"), True)
                    If Not p_Object Is Nothing Then
                        If Not p_Object(0).editValue Is Nothing Then
                            p_Value = p_Object(0).editValue.ToString.Trim
                            If p_Object(0).required = "Y" Then
                                If p_Value = "" Then
                                    ShowMessageBox("", p_ArrRow(p_count).Item("ItemDesc") & "- chưa nhập giá trị")
                                    Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If
                            If p_Value <> "" Then
                                Select Case UCase(p_ArrRow(p_count).Item("ItemValue"))
                                    Case "DATE"
                                        If p_Where = "" Then
                                            p_Where = p_ArrRow(p_count).Item("FieldName") & "<='" & CDate(p_Object(0).editValue).ToString("yyyyMMdd") & "'"
                                        Else
                                            p_Where = p_Where & " AND " & p_ArrRow(p_count).Item("FieldName") & "<='" & CDate(p_Object(0).editValue).ToString("yyyyMMdd") & "'"
                                        End If
                                    Case "TEXT"
                                        If p_Where = "" Then
                                            p_Where = p_ArrRow(p_count).Item("FieldName") & "<='" & p_Object(0).editValue.ToString.Trim & "'"
                                        Else
                                            p_Where = p_Where & " AND " & p_ArrRow(p_count).Item("FieldName") & "<='" & p_Object(0).editValue.ToString.Trim & "'"
                                        End If
                                    Case Else
                                        If p_Where = "" Then
                                            p_Where = p_ArrRow(p_count).Item("FieldName") & "<=" & p_Object(0).editValue.ToString.Trim
                                        Else
                                            p_Where = p_Where & " AND " & p_ArrRow(p_count).Item("FieldName") & "<=" & p_Object(0).editValue.ToString.Trim
                                        End If
                                End Select
                            End If
                        End If
                    End If

                End If
            Next
            If p_Where <> "" Then
                p_Where = " WHERE " & p_Where
            End If

            p_SQL = BuildSelect(p_ReportCode)

            p_SQL = "SELECT " & p_SQL & "  from " & Me.GridView1.ViewName & " " & p_Where

            p_Table = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If p_RunReport = True Then
                p_SQLReturn = p_SQL
                p_TableReturn = p_Table
                Exit Sub
            End If


            p_BindingSource.DataSource = p_Table
            Me.TrueDBGrid1.DataSource = p_BindingSource
            Me.GridView1.OptionsView.ColumnAutoWidth = False
            Me.TrueDBGrid1.Refresh()
            Me.TrueDBGrid1.RefreshDataSource()
            Me.TrueDBGrid1.Views(0).PopulateColumns()
            ' Me.GridView1.RefreshData()


            Me.GridView1.OptionsCustomization.AllowGroup = True
            If Me.GridView1.RowCount > 0 Then
                p_ArrRow = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "'", "GroupSTT")
                For p_count = 0 To p_ArrRow.Length - 1
                    Me.GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim).Width = 80 * IIf(p_ArrRow(p_count).Item("FieldWidth").ToString.Trim = "", 1, p_ArrRow(p_count).Item("FieldWidth").ToString.Trim)
                    Me.GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim).Caption = p_ArrRow(p_count).Item("FieldDesc").ToString.Trim
                    If p_ArrRow(p_count).Item("Groupfield").ToString.Trim = "Y" Then
                        Me.GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim).Group()
                    End If
                    If p_ArrRow(p_count).Item("GroupType").ToString.Trim <> "" And p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim = "Y" Then

                        Select Case UCase(p_ArrRow(p_count).Item("GroupType").ToString.Trim)
                            Case "SUM"
                                'GridView1.Columns(p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim).Summary.Add(DevExpress.Data.SummaryItemType.Sum, p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim, "{0:0}")
                                item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
                                item1.FieldName = p_ArrRow(p_count).Item("FieldName").ToString.Trim
                                item1.SummaryType = DevExpress.Data.SummaryItemType.Sum


                                'Me.GridView1.GroupPanelText = "sdfsdsfs"

                            Case "AVG"
                                ' GridView1.Columns(p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim).Summary.Add(DevExpress.Data.SummaryItemType.Average, p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim, "{0:0}")
                                item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
                                item1.FieldName = p_ArrRow(p_count).Item("FieldName").ToString.Trim
                                item1.SummaryType = DevExpress.Data.SummaryItemType.Average

                            Case "COUNT"
                                'GridView1.Columns(p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim).Summary.Add(DevExpress.Data.SummaryItemType.Count, p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim, "{0:0}")
                                item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
                                item1.FieldName = p_ArrRow(p_count).Item("FieldName").ToString.Trim
                                item1.SummaryType = DevExpress.Data.SummaryItemType.Count

                            Case "MIN"
                                'GridView1.Columns(p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim).Summary.Add(DevExpress.Data.SummaryItemType.Min, p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim, "{0:0}")
                                item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
                                item1.FieldName = p_ArrRow(p_count).Item("FieldName").ToString.Trim
                                item1.SummaryType = DevExpress.Data.SummaryItemType.Min

                            Case "MAX"
                                'GridView1.Columns(p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim).Summary.Add(DevExpress.Data.SummaryItemType.Max, p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim, "{0:0}")
                                item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
                                item1.FieldName = p_ArrRow(p_count).Item("FieldName").ToString.Trim
                                item1.SummaryType = DevExpress.Data.SummaryItemType.Max

                            Case Else
                                Continue For
                        End Select

                        'item1.DisplayFormat = "{0}"
                        ' item1.DisplayFormat = "{0:0}"
                        item1.DisplayFormat = "{0:#,###}"
                        '  item1.DisplayFormat = "#,###0."
                        GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim).DisplayFormat.FormatString = "#,###0."

                        item1.ShowInGroupColumnFooter = GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim)
                        GridView1.GroupSummary.Add(item1)
                    End If
                    'End If
                Next
            End If
            Me.GridView1.ExpandAllGroups()

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            ShowMessageBox(Err.Number.ToString, ex.Message)
        End Try
    End Sub


    Sub ExeProcedureData(ByVal p_RunReport As Boolean, ByRef p_SQLReturn As String, ByVal p_ReportCode As String,
                            ByVal p_ProcedureName As String, ByRef p_TableReturn As DataTable)
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_BindingSource As New U_TextBox.U_BindingSource
        ' Dim p_ReportCode As String = ""
        Dim p_ArrRow() As DataRow
        Dim p_count As Integer
        Dim p_Object As Object
        Dim p_Where As String = ""
        Dim p_Value As String
        Dim item1 As DevExpress.XtraGrid.GridGroupSummaryItem

        Try
            If p_TableReturn Is Nothing Then
                p_TableReturn = New DataTable
            End If
            'If Not Me.ReportCode.EditValue Is Nothing Then
            '    p_ReportCode = Me.ReportCode.EditValue.ToString.Trim
            'End If
            If p_ReportCode = "" Then
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor


            p_ArrRow = p_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "'", "STT")
            For p_count = 0 To p_ArrRow.Length - 1
                p_Object = Me.Controls.Find(p_ArrRow(p_count).Item("ItemName"), True)
                If Not p_Object Is Nothing Then
                    If Not p_Object(0).editValue Is Nothing Then
                        p_Value = p_Object(0).editValue.ToString.Trim
                        If p_Object(0).required = "Y" Then
                            If p_Value = "" Then
                                ShowMessageBox("", p_ArrRow(p_count).Item("ItemDesc") & "- chưa nhập giá trị")
                                Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If
                        If p_Value <> "" Then
                            Select Case UCase(p_ArrRow(p_count).Item("ItemValue"))
                                'Case "TIME"
                                '    If p_Where = "" Then
                                '        p_Where = "'" & CDate(p_Object(0).editValue).ToString("HH:mm") & "'"
                                '    Else
                                '        p_Where = p_Where & ",'" & CDate(p_Object(0).editValue).ToString("HH:mm") & "'"
                                '    End If

                                Case "DATE"
                                    If p_Where = "" Then
                                        p_Where = "'" & CDate(p_Object(0).editValue).ToString("yyyyMMdd") & "'"
                                    Else
                                        p_Where = p_Where & ",'" & CDate(p_Object(0).editValue).ToString("yyyyMMdd") & "'"
                                    End If
                                Case "TEXT"
                                    If p_Where = "" Then
                                        p_Where = "'" & p_Object(0).editValue.ToString.Trim & "'"
                                    Else
                                        p_Where = p_Where & ",'" & p_Object(0).editValue.ToString.Trim & "'"
                                    End If
                                Case "TIME"
                                    If p_Where = "" Then
                                        p_Where = "'" & p_Object(0).editValue.ToString.Trim & "'"
                                    Else
                                        p_Where = p_Where & ",'" & p_Object(0).editValue.ToString.Trim & "'"
                                    End If
                                Case Else
                                    If p_Where = "" Then
                                        p_Where = p_Object(0).editValue.ToString.Trim
                                    Else
                                        p_Where = p_Where & "," & p_Object(0).editValue.ToString.Trim
                                    End If
                            End Select
                        Else
                            If p_Where = "" Then
                                p_Where = "Null"
                            Else
                                p_Where = p_Where & ",Null"
                            End If
                        End If
                    Else
                        If p_Where = "" Then
                            p_Where = "Null"
                        Else
                            p_Where = p_Where & ",Null"
                        End If
                    End If
                End If

                'To value
                If p_ArrRow(p_count).Item("ToItemName").ToString.Trim <> "" Then
                    p_Object = Me.Controls.Find(p_ArrRow(p_count).Item("ToItemName"), True)
                    If Not p_Object Is Nothing Then
                        If Not p_Object(0).editValue Is Nothing Then
                            p_Value = p_Object(0).editValue.ToString.Trim
                            If p_Object(0).required = "Y" Then
                                If p_Value = "" Then
                                    ShowMessageBox("", p_ArrRow(p_count).Item("ItemDesc") & "- chưa nhập giá trị")
                                    Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If
                            If p_Value <> "" Then
                                Select Case UCase(p_ArrRow(p_count).Item("ItemValue"))
                                    Case "TIME"
                                        If p_Where = "" Then
                                            p_Where = "'" & CDate(p_Object(0).editValue).ToString("HH:mm") & "'"
                                        Else
                                            p_Where = p_Where & ",'" & CDate(p_Object(0).editValue).ToString("HH:mm") & "'"
                                        End If

                                    Case "DATE"
                                        If p_Where = "" Then
                                            p_Where = "'" & CDate(p_Object(0).editValue).ToString("yyyyMMdd") & "'"
                                        Else
                                            p_Where = p_Where & ",'" & CDate(p_Object(0).editValue).ToString("yyyyMMdd") & "'"
                                        End If
                                    Case "TEXT"
                                        If p_Where = "" Then
                                            p_Where = "'" & p_Object(0).editValue.ToString.Trim & "'"
                                        Else
                                            p_Where = p_Where & " ,'" & p_Object(0).editValue.ToString.Trim & "'"
                                        End If
                                    Case "TIME"
                                        If p_Where = "" Then
                                            p_Where = "'" & p_Object(0).editValue.ToString.Trim & "'"
                                        Else
                                            p_Where = p_Where & ",'" & p_Object(0).editValue.ToString.Trim & "'"
                                        End If
                                    Case Else
                                        If p_Where = "" Then
                                            p_Where = p_Object(0).editValue.ToString.Trim
                                        Else
                                            p_Where = p_Where & " ," & p_Object(0).editValue.ToString.Trim
                                        End If
                                End Select
                            Else
                                If p_Where = "" Then
                                    p_Where = "Null"
                                Else
                                    p_Where = p_Where & ",Null"
                                End If
                            End If
                        Else
                            If p_Where = "" Then
                                p_Where = "Null"
                            Else
                                p_Where = p_Where & ",Null"
                            End If
                        End If
                    End If

                End If
            Next


            If p_Where <> "" Then
                p_Where = " exec  " & p_ProcedureName & " " & p_Where
            End If


            'Exit Sub

            p_SQL = p_Where

            'p_SQL = BuildSelect(p_ReportCode)

            'p_SQL = "SELECT " & p_SQL & "  from " & Me.GridView1.ViewName & " " & p_Where

            p_Table = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

            If p_RunReport = True Then
                p_SQLReturn = p_SQL
                p_TableReturn = p_Table
                Exit Sub
            End If


            p_BindingSource.DataSource = p_Table
            Me.TrueDBGrid1.DataSource = p_BindingSource
            Me.GridView1.OptionsView.ColumnAutoWidth = False
            Me.TrueDBGrid1.Refresh()
            Me.TrueDBGrid1.RefreshDataSource()
            Me.TrueDBGrid1.Views(0).PopulateColumns()
            ' Me.GridView1.RefreshData()


            Me.GridView1.OptionsCustomization.AllowGroup = True
            If Me.GridView1.RowCount > 0 Then
                p_ArrRow = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "'", "GroupSTT")
                For p_count = 0 To p_ArrRow.Length - 1
                    If p_ArrRow(p_count).Item("GroupSTT").ToString.Trim = "0" Then
                        Continue For
                    End If
                    Me.GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim).Width = 80 * IIf(p_ArrRow(p_count).Item("FieldWidth").ToString.Trim = "", 1, p_ArrRow(p_count).Item("FieldWidth").ToString.Trim)
                    Me.GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim).Caption = p_ArrRow(p_count).Item("FieldDesc").ToString.Trim

                    Try

                        If p_ArrRow(p_count).Item("Groupfield").ToString.Trim = "Y" Then
                            Me.GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim).Group()
                        End If
                        If p_ArrRow(p_count).Item("GroupType").ToString.Trim <> "" And p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim = "Y" Then

                            Select Case UCase(p_ArrRow(p_count).Item("GroupType").ToString.Trim)
                                Case "SUM"
                                    'GridView1.Columns(p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim).Summary.Add(DevExpress.Data.SummaryItemType.Sum, p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim, "{0:0}")
                                    item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
                                    item1.FieldName = p_ArrRow(p_count).Item("FieldName").ToString.Trim
                                    item1.SummaryType = DevExpress.Data.SummaryItemType.Sum


                                    'Me.GridView1.GroupPanelText = "sdfsdsfs"

                                Case "AVG"
                                    ' GridView1.Columns(p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim).Summary.Add(DevExpress.Data.SummaryItemType.Average, p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim, "{0:0}")
                                    item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
                                    item1.FieldName = p_ArrRow(p_count).Item("FieldName").ToString.Trim
                                    item1.SummaryType = DevExpress.Data.SummaryItemType.Average

                                Case "COUNT"
                                    'GridView1.Columns(p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim).Summary.Add(DevExpress.Data.SummaryItemType.Count, p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim, "{0:0}")
                                    item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
                                    item1.FieldName = p_ArrRow(p_count).Item("FieldName").ToString.Trim
                                    item1.SummaryType = DevExpress.Data.SummaryItemType.Count

                                Case "MIN"
                                    'GridView1.Columns(p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim).Summary.Add(DevExpress.Data.SummaryItemType.Min, p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim, "{0:0}")
                                    item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
                                    item1.FieldName = p_ArrRow(p_count).Item("FieldName").ToString.Trim
                                    item1.SummaryType = DevExpress.Data.SummaryItemType.Min

                                Case "MAX"
                                    'GridView1.Columns(p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim).Summary.Add(DevExpress.Data.SummaryItemType.Max, p_ArrRow(p_count).Item("GroupValueCol").ToString.Trim, "{0:0}")
                                    item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
                                    item1.FieldName = p_ArrRow(p_count).Item("FieldName").ToString.Trim
                                    item1.SummaryType = DevExpress.Data.SummaryItemType.Max

                                Case Else
                                    Continue For
                            End Select

                            'item1.DisplayFormat = "{0}"
                            ' item1.DisplayFormat = "{0:0}"
                            item1.DisplayFormat = "{0:#,###}"
                            '  item1.DisplayFormat = "#,###0."
                            GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim).DisplayFormat.FormatString = "#,###0."

                            item1.ShowInGroupColumnFooter = GridView1.Columns(p_ArrRow(p_count).Item("FieldName").ToString.Trim)
                            GridView1.GroupSummary.Add(item1)
                        End If
                    Catch ex As Exception

                    End Try
                    'End If
                Next
            End If
            Me.GridView1.ExpandAllGroups()

            For p_count = 0 To Me.GridView1.Columns.Count - 1
                p_ArrRow = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "' and  FieldName='" & GridView1.Columns(p_count).FieldName & "'")
                If p_ArrRow.Length > 0 Then
                    GridView1.Columns(p_count).Caption = p_ArrRow(0).Item("FieldDesc").ToString.Trim
                Else
                    GridView1.Columns(p_count).Visible = False
                End If
            Next
            GridView1.BestFitColumns()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            ShowMessageBox(Err.Number.ToString, ex.Message)
        End Try
    End Sub

    'Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
    '    Dim p_Err As String


    '    If p_XtraModuleObj.p_ModGridExportToExcelNew(Me.TrueDBGrid1, p_Err) = False Then
    '        ShowMessageBox("", p_Err)
    '    Else
    '        MsgBox("Đã thực hiện xong")
    '    End If
    'End Sub

    Function BuildSelect(ByVal p_ReportCode As String) As String
        Dim p_RowArr() As DataRow
        Dim p_Count As Integer
        BuildSelect = ""
        Try
            '"ReportCode='" & p_ReportCode & "'", "STT"
            p_RowArr = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "'", "STT")
            For p_Count = 0 To p_RowArr.Length - 1
                BuildSelect = BuildSelect & "," & p_RowArr(p_Count).Item("FieldName").ToString.Trim
            Next
            If Len(BuildSelect) > 0 Then
                BuildSelect = Mid(BuildSelect, 2)
            End If
        Catch ex As Exception
            ShowMessageBox("", "BuildSelect: " & ex.Message)
            BuildSelect = ""
        End Try
        'p_SYS_CONFIG_RPT_FIELD
    End Function

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReport.Click
        'hieptd4 add
        If Me.Check_Control_Required = False Then
            Exit Sub
        End If

        Dim p_SQL As String
        Dim p_BaoCao As String = ""
        Dim p_LoaiBaoCao As String = "V"
        Dim p_RowArr1() As DataRow
        Dim p_ProcedureName As String
        Dim p_TableReturn As DataTable
        Dim p_Dynamic As String = "N"
        Dim p_DataSetReturn As DataSet
        If Not Me.ReportCode.EditValue Is Nothing Then
            p_BaoCao = Me.ReportCode.EditValue.ToString.Trim
        End If

        If p_BaoCao = "" Then
            Exit Sub
        End If

        p_RowArr1 = p_SYS_CONFIG_RPT.Select("ReportCode='" & p_BaoCao & "'")
        If p_RowArr1.Length > 0 Then
            p_LoaiBaoCao = p_RowArr1(0).Item("SourceType").ToString.Trim
            p_Dynamic = IIf(p_RowArr1(0).Item("RptDynamic").ToString.Trim = "", "N", p_RowArr1(0).Item("RptDynamic").ToString.Trim)
        End If

        'If p_LoaiBaoCao = "V" Then
        '    QueryData(True, p_SQL, p_TableReturn)
        'Else
        '    p_ProcedureName = p_RowArr1(0).Item("ViewName").ToString.Trim
        '    ExeProcedureData(True, p_SQL, p_BaoCao, p_ProcedureName, p_TableReturn)
        'End If
        If p_Dynamic = "N" Then
            If p_LoaiBaoCao = "V" Then
                QueryData(True, p_SQL, p_TableReturn)
                'Exit Sub
            Else
                p_ProcedureName = p_RowArr1(0).Item("ViewName").ToString.Trim
                ExeProcedureData(True, p_SQL, p_BaoCao, p_ProcedureName, p_TableReturn)

            End If
            ' CreateReportNew(p_TableReturn)
            'Exit Sub
        Else
            If p_LoaiBaoCao = "V" Then
                QueryData(True, p_SQL, p_TableReturn)
            Else
                p_ProcedureName = p_RowArr1(0).Item("ViewName").ToString.Trim
                ExeProcedureData(True, p_SQL, p_BaoCao, p_ProcedureName, p_TableReturn)
            End If
            CreateReportNew(p_TableReturn)
            Cursor = Cursors.Default

            Exit Sub
        End If

        If p_Dynamic = "N" Then
            'Dim p_TichKeKV2 As New K4810.Class1(g_Config_XMLDatatable, _
            '                                                     g_Company_Code, _
            '                                                     g_WareHouse, g_Services, "", "", "", g_Company_Host, _
            '                                                     g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
            '                                                     g_DBPass, g_CompanyAPI)
            'p_TichKeKV2.clsInBaoCao(p_TableReturn, p_BaoCao)
            'Exit Sub

            Select Case g_Company_Code
                Case "4110"   'Quang binh
                    Dim p_QuangBinh As New QB_Report.Class1(g_Config_XMLDatatable, _
                                                                         g_Company_Code, _
                                                                         g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                                         g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                                         g_DBPass, g_CompanyAPI)
                    p_QuangBinh.clsInBaoCaoNew(Me, p_TableReturn, p_BaoCao, p_SYS_CONFIG_RPT_PARA, p_SYS_CONFIG_RPT, p_SYS_CONFIG_RPT_FIELD)

                Case "6610"   'KV2
                    Dim p_KV2 As New KV_2_Report.Class1(g_Config_XMLDatatable, _
                                                                         g_Company_Code, _
                                                                         g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                                         g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                                         g_DBPass, g_CompanyAPI)
                    p_KV2.clsInBaoCaoNew(Me, p_TableReturn, p_BaoCao, p_SYS_CONFIG_RPT_PARA, p_SYS_CONFIG_RPT, p_SYS_CONFIG_RPT_FIELD, p_DataSetReturn)

            End Select


        End If
        Cursor = Cursors.Default
        Exit Sub






        Dim p_Report As New RptReport1
        Dim p_Table As DevExpress.XtraReports.UI.XRTable

        Dim p_TableCell As DevExpress.XtraReports.UI.XRTableCell
        Dim p_TableRow As DevExpress.XtraReports.UI.XRTableRow
        Dim p_DataTable As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        'Dim p_Row As Integer
        'Dim p_Col As Integer
        'Dim p_DataRow As DataRow
        'Dim p_Gridview As U_TextBox.GridView
        Dim p_RowArr() As DataRow
        Dim tableWidth As Integer
        Dim padding As Integer = 5
        Dim p_ReportCode As String



        Cursor = Cursors.WaitCursor
        CreateReport()
        Cursor = Cursors.Default



        Exit Sub
        p_Binding = Me.TrueDBGrid1.DataSource
        p_DataTable = CType(p_Binding.DataSource, DataTable)

        tableWidth = p_Report.PageWidth - p_Report.Margins.Left - p_Report.Margins.Right - padding * 2


        Dim GroupHeader As New DevExpress.XtraReports.UI.GroupHeaderBand()

        Dim groupField As New DevExpress.XtraReports.UI.GroupField("SoLenh", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)
        Dim labelGroup As New DevExpress.XtraReports.UI.XRLabel


        GroupHeader.Controls.Add(labelGroup)
        GroupHeader.GroupFields.Add(groupField)
        p_Report.Bands.Add(GroupHeader)





        If Not Me.ReportCode.EditValue Is Nothing Then
            p_ReportCode = Me.ReportCode.EditValue.ToString.Trim
        End If
        If p_ReportCode = "" Then
            Exit Sub
        End If

        p_RowArr = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "'", "STT")



        p_Table = New DevExpress.XtraReports.UI.XRTable()
        p_Table.Name = "TblHeader"
        p_TableRow = New DevExpress.XtraReports.UI.XRTableRow

        p_Table.Font = New System.Drawing.Font("Arial", 10.0F, FontStyle.Bold)

        p_Table.WidthF = tableWidth

        p_Table.BorderWidth = 1

        p_Table.LeftF = 5

        p_Table.Borders = DevExpress.XtraPrinting.BorderSide.All

        p_Table.CanGrow = False
        'Tao Header
        For p_Count = 0 To p_RowArr.Length - 1

            p_TableCell = New DevExpress.XtraReports.UI.XRTableCell()

            p_TableCell.Text = p_RowArr(p_Count).Item("FieldDesc").ToString.Trim


            p_TableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter

            p_TableRow.Cells.Add(p_TableCell)
            'Next
        Next
        p_TableRow.BackColor = Color.LightGray
        p_Table.Rows.Add(p_TableRow)

        p_Table.TopF = p_Report.ReportHeader.HeightF - p_TableRow.HeightF

        p_Report.ReportHeader.Controls.Add(p_Table)


        'Tao Row Detail
        p_Table = New DevExpress.XtraReports.UI.XRTable()
        p_Table.Name = "TblDetail"
        p_TableRow = New DevExpress.XtraReports.UI.XRTableRow

        p_Table.Font = New System.Drawing.Font("Arial", 9.0F)

        p_Table.WidthF = tableWidth

        p_Table.BorderWidth = 1
        p_Table.TopF = 0
        p_Table.LeftF = 5

        p_Table.Borders = DevExpress.XtraPrinting.BorderSide.All

        p_Table.CanGrow = False
        For p_Count = 0 To p_RowArr.Length - 1
            p_TableCell = New DevExpress.XtraReports.UI.XRTableCell()

            p_TableCell.Text = p_RowArr(p_Count).Item("FieldDesc").ToString.Trim
            Select Case p_RowArr(p_Count).Item("FieldFormat").ToString.Trim
                Case "DATE"
                    p_TableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    p_TableCell.DataBindings.Add("Text", p_DataTable, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "dd/MM/yyyy")

                Case "NUMBER"
                    p_TableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    p_TableCell.DataBindings.Add("Text", p_DataTable, p_RowArr(p_Count).Item("FieldName").ToString.Trim)
                Case Else
                    p_TableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    p_TableCell.DataBindings.Add("Text", p_DataTable, p_RowArr(p_Count).Item("FieldName").ToString.Trim)
            End Select



            'p_TableCell.Borders=
            p_TableRow.Cells.Add(p_TableCell)
        Next

        p_Table.Rows.Add(p_TableRow)

        'p_Report.Detail1.Controls.Add(p_Table)




        p_Report.Detail.HeightF = p_Table.Rows(0).HeightF
        p_Report.DataSource = p_DataTable
        p_Report.ShowPreviewDialog()
    End Sub

    Sub CreatePivot(ByVal p_Dt As System.Data.DataTable, ByRef p_Report As RptReport1)
        Dim pivotGrid As New DevExpress.XtraReports.UI.XRPivotGrid()



        'Dim pivotGrid As New DevExpress.
        Dim p_fieldName As New DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField
        Dim p_Count As Integer
        Dim p_XRPivotGridField() As DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField
        '  Dim p_fieldName1 As DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField   '("Country", PivotArea.ColumnArea)
        ' Bind the pivot grid to data.

        ' pivotGrid.DataMember = "SalesPerson"
        ReDim p_XRPivotGridField(0 To p_Dt.Columns.Count - 1)
        For p_Count = 0 To p_Dt.Columns.Count - 1
            If p_Dt.Columns(p_Count).ColumnName.ToString.Trim = "SoLuongDuXuat" Then
                'p_fieldName = New DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField("Col" & p_Dt.Columns(p_Count).ColumnName.ToString.Trim, DevExpress.XtraPivotGrid.PivotArea.ColumnArea)
                p_fieldName = New DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField("Col" & p_Dt.Columns(p_Count).ColumnName.ToString.Trim, DevExpress.XtraPivotGrid.PivotArea.RowArea)
                p_fieldName.FieldName = p_Dt.Columns(p_Count).ColumnName.ToString.Trim
                p_XRPivotGridField(p_Count) = p_fieldName
            Else
                p_fieldName = New DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField("Col" & p_Dt.Columns(p_Count).ColumnName.ToString.Trim, DevExpress.XtraPivotGrid.PivotArea.RowArea)
                'p_fieldName.Name = "Col" & p_Dt.Columns(p_Count).ColumnName.ToString.Trim
                p_fieldName.FieldName = p_Dt.Columns(p_Count).ColumnName.ToString.Trim
                p_XRPivotGridField(p_Count) = p_fieldName
            End If


        Next
        'pivotGrid.
        pivotGrid.Fields.AddRange(p_XRPivotGridField)
        pivotGrid.OptionsDataField.Area = DevExpress.XtraPivotGrid.PivotDataArea.None
        pivotGrid.DataSource = p_Report.DataSource

        p_Report.Detail.Controls.Add(pivotGrid)
        p_Report.PaperKind = Printing.PaperKind.A4
        p_Report.Landscape = True
    End Sub




    Sub CreateReport()
        Dim p_Report As New RptReport1
        Dim p_DataTable As DataTable
        Dim p_DataTable1 As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim tableWidth As Integer
        Dim p_RowArr() As DataRow
        Dim p_RowArr1() As DataRow
        Dim p_Row As DataRow
        Dim p_ReportCode As String
        Dim p_Count As Integer
        Dim p_Count1 As Integer
        Dim p_SQL As String = ""
        Dim xrtableheader As New DevExpress.XtraReports.UI.XRTable()
        Dim xrtable As New DevExpress.XtraReports.UI.XRTable()
        Dim xrrowheader As New DevExpress.XtraReports.UI.XRTableRow()
        Dim xrrow As New DevExpress.XtraReports.UI.XRTableRow()
        Dim p_ReportName As String
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel

        'Dim labelDetailtOTAL As DevExpress.XtraReports.UI.XRLabel


        Dim labelGroup As DevExpress.XtraReports.UI.XRLabel
        Dim p_Text As DevExpress.XtraReports.UI.XRLabel

        Dim p_Left_Title As Double
        Dim p_Top_Title As Double
        Dim p_Width As Double
        Dim p_Object() As Object
        Dim StrParameter As String
        Dim p_NgangGiay As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_ShowParentCompany As Boolean = False

        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet

        Dim p_xrSummary1 As DevExpress.XtraReports.UI.XRSummary
        Dim p_LabelGroupWidth As Double = 0
        Dim p_LabelGroupLeft As Double = 0
        Dim p_TableReturn As DataTable


        If Not Me.ReportName.EditValue Is Nothing Then
            p_ReportName = Me.ReportName.EditValue.ToString.Trim
        End If


        If Not Me.ReportCode.EditValue Is Nothing Then
            p_ReportCode = Me.ReportCode.EditValue.ToString.Trim
        End If
        If p_ReportCode = "" Then
            Exit Sub
        End If


        QueryData(True, p_SQL, p_TableReturn)

        If p_SQL = "" Then
            ShowMessageBox("", "Dữ liệu không có")
            Exit Sub
        End If
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If p_DataTable Is Nothing Then
            ShowMessageBox("", "Dữ liệu không có")
            Exit Sub
        End If





        With p_Report

            'Lay cac gia tri khac neu co
            p_RowArr = p_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
            If p_RowArr.Length > 0 Then
                If p_RowArr(0).Item("Landscape").ToString.Trim = "Y" Then
                    p_NgangGiay = True
                End If

                If p_RowArr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                    p_ShowCompany = True
                End If
                If p_RowArr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                    p_ShowParentCompany = True
                End If

                Try
                    If p_RowArr(0).Item("PageType").ToString.Trim <> "" Then
                        Select Case p_RowArr(0).Item("PageType").ToString.Trim
                            Case "A4"
                                .PaperKind = Printing.PaperKind.A4
                            Case "A3"
                                .PaperKind = Printing.PaperKind.A3
                            Case "A5"
                                .PaperKind = Printing.PaperKind.A5
                        End Select

                    End If
                Catch ex As Exception

                End Try
            End If
            'If p_NgangGiay = True Then
            .Landscape = p_NgangGiay
            'End If


            tableWidth = .PageWidth - .Margins.Left - .Margins.Right - 20 '* 2

            xrrowheader.Name = "RowHeader"
            xrrow.Name = "Row"

            p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

            'If Not p_TableCompany Is Nothing Then
            '    If p_TableCompany.Rows.Count > 0 Then
            '        p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
            '        p_SQL = p_SQL & "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
            '        p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
            '        If Not p_DataSetCompany Is Nothing Then
            '            If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
            '                p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
            '            End If

            '            If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
            '                p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenKho").ToString.Trim)
            '            End If

            '        End If
            '    End If
            '    p_Top_Title = .XrPictureBox1.TopF
            '    If p_ShowParentCompany = True Then
            '        p_Text = New DevExpress.XtraReports.UI.XRLabel
            '        p_Text.WidthF = tableWidth / 2
            '        p_Text.LeftF = .XrPictureBox1.LeftF
            '        p_Text.Text = p_ParentCompanyName
            '        p_Text.TopF = p_Top_Title
            '        p_Text.Font = New Font("Tahoma", 12.0F, FontStyle.Bold)
            '        p_Text.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        p_Text.HeightF = p_Text.HeightF + (p_Text.HeightF * 0.2)
            '        .ReportHeader.Controls.Add(p_Text)
            '        p_Top_Title = p_Top_Title + p_Text.HeightF
            '    End If
            '    If p_ShowCompany = True Then
            '        p_Text = New DevExpress.XtraReports.UI.XRLabel
            '        p_Text.WidthF = tableWidth / 2
            '        p_Text.LeftF = .XrPictureBox1.LeftF
            '        p_Text.Text = p_CompanyName
            '        p_Text.TopF = p_Top_Title
            '        p_Text.Font = New Font("Tahoma", 10.0F, FontStyle.Regular)
            '        p_Text.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        p_Text.HeightF = p_Text.HeightF + (p_Text.HeightF * 0.2)
            '        .ReportHeader.Controls.Add(p_Text)
            '        p_Top_Title = p_Top_Title + p_Text.HeightF
            '    End If

            'End If

            p_Top_Title = p_Top_Title + 10
            .XrPictureBox1.TopF = p_Top_Title
            .XrPictureBox1.LeftF = .XrPictureBox1.LeftF + (.XrPictureBox1.WidthF / 2)

            p_Top_Title = .XrPictureBox1.TopF + .XrPictureBox1.HeightF
            p_Top_Title = p_Top_Title + (.XrLabel1.HeightF / 2)
            .XrLabel1.TopF = p_Top_Title
            .XrLabel1.Text = p_ReportName
            .XrLabel1.WidthF = tableWidth


            p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            p_Left_Title = .XrLabel1.LeftF

            'Lay ra cac tham so co the treo len bao cao
            p_RowArr = p_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_RowArr.Length > 0 Then
                For p_Count = 0 To p_RowArr.Length - 1
                    p_Row = p_RowArr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = Me.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString(g_Format_Date)
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If

                        p_Object = Me.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " đến " & CDate(p_Object(0).editvalue).ToString(g_Format_Date)
                                Else
                                    StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                                End If

                            End If
                        End If

                    End If

                    If StrParameter <> "" Then
                        p_Text = New DevExpress.XtraReports.UI.XRLabel
                        p_Text.WidthF = tableWidth
                        p_Text.LeftF = p_Left_Title
                        p_Text.Text = StrParameter
                        p_Text.TopF = p_Top_Title
                        p_Text.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        p_Text.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        p_Text.HeightF = p_Text.HeightF + (p_Text.HeightF * 0.5)
                        .ReportHeader.Controls.Add(p_Text)
                        .ReportHeader.HeightF = .ReportHeader.HeightF + p_Text.HeightF
                    End If
                Next
            End If
            '.DataSource = p_DataTable
            p_RowArr = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "'", "STT")

            ' .Bands.Remove(.Detail1)
            For p_Count = 0 To p_RowArr.Length - 1

                Dim xrcellheader As New DevExpress.XtraReports.UI.XRTableCell()
                Dim xrcell As New DevExpress.XtraReports.UI.XRTableCell()
                xrcellheader.Name = "CellHeader" & p_Count
                xrcell.Name = "Cell" & p_RowArr(p_Count).Item("FieldName").ToString.Trim
                xrcellheader.Text = p_RowArr(p_Count).Item("FieldDesc").ToString.Trim
                xrcellheader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                Select Case UCase(p_RowArr(p_Count).Item("FieldForMat").ToString.Trim)
                    Case "TEXT"
                        xrcell.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim)
                        xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    Case "DATE"
                        xrcell.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        ' xrcellheader.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")

                        xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    Case "DATETIME"
                        xrcell.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        'xrcellheader.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    Case Else
                        xrcell.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim)   ', "{0:#,###}")
                        xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                End Select
                xrcellheader.Font = New Font("Tahoma", 10.0F, FontStyle.Bold)
                xrcell.Font = New Font("Tahoma", 10.0F, FontStyle.Regular)
                xrrowheader.Cells.Add(xrcellheader)
                xrrow.Cells.Add(xrcell)

            Next

            xrtableheader.WidthF = tableWidth ' .PageWidth - 40
            xrtableheader.BorderWidth = 1
            xrtableheader.LeftF = 10
            xrtableheader.TopF = .ReportHeader.HeightF - xrrowheader.HeightF
            xrtableheader.Borders = DevExpress.XtraPrinting.BorderSide.All
            xrtableheader.Rows.Add(xrrowheader)


            xrtable.LeftF = 10
            xrtable.WidthF = tableWidth  '.PageWidth - 40
            xrtable.BorderWidth = 1
            xrtable.Borders = DevExpress.XtraPrinting.BorderSide.All
            xrtable.Rows.Add(xrrow)

            .ReportHeader.Controls.Add(xrtableheader)

            .Detail.Controls.Add(xrtable)
            '.DetailReport.Controls.Add(xrtable)

            '  .DetailReport.Bands.Add(xrtable)
            '  .Detail1.Visible = True
            '  .DataSource = p_DataTable
            p_RowArr = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "' and GroupField='Y'", "GroupSTT")
            For p_Count = 0 To p_RowArr.Length - 1
                Dim GroupHeader As New DevExpress.XtraReports.UI.GroupHeaderBand()

                Dim GroupFooter As New DevExpress.XtraReports.UI.GroupFooterBand()

                Dim groupField As New DevExpress.XtraReports.UI.GroupField(p_RowArr(p_Count).Item("FieldName").ToString.Trim, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)
                labelGroup = New DevExpress.XtraReports.UI.XRLabel
                GroupHeader.HeightF = 40

                GroupFooter.HeightF = 40

                labelGroup.LeftF = 10 '20

                GroupHeader.BackColor = Color.LightCyan
                GroupFooter.BackColor = Color.LightCyan

                GroupHeader.Level = p_Count



                p_RowArr1 = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "' AND (GROUPTYPE='SUM' OR GROUPTYPE='COUNT' OR GROUPTYPE='MIN' OR GROUPTYPE='MAX')", "STT")


                GroupHeader.GroupFields.Add(groupField)

                p_LabelGroupWidth = 0

                p_LabelGroupLeft = tableWidth

                For p_Count1 = 0 To p_RowArr1.Length - 1
                    ' labelDetail = Nothing
                    labelDetail = New DevExpress.XtraReports.UI.XRLabel

                    ' p_xrSummary1 = New DevExpress.XtraReports.UI.XRSummary
                    'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.Left

                    labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
                    labelDetail.SendToBack()
                    'labelDetail.DataBindings.Add("Text", .DataSource, p_RowArr1(p_Count1).Item("FieldName").ToString.Trim, "{0:#,###}")
                    labelDetail.DataBindings.Add("Text", Nothing, p_RowArr1(p_Count1).Item("FieldName").ToString.Trim)
                    'labelDetail.Summary = New DevExpress.XtraReports.UI.XRSummary(DevExpress.XtraReports.UI.SummaryRunning.Group, _
                    '                                                                DevExpress.XtraReports.UI.SummaryFunc.Sum, String.Empty)

                    '  labelDetail.Summary.GetResult()

                    Select Case p_RowArr1(p_Count1).Item("GROUPTYPE").ToString.Trim
                        Case "SUM"

                            '    labelDetail.Summary.Func = SummaryFunc.Sum
                            'summary.Running = SummaryRunning.Group;
                            'summary.IgnoreNullValues = true;
                            'summary.FormatString = "{0:c2}";
                            'cell.Text = summary.GetResult().ToString();
                            'p_xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                            'p_xrSummary1.IgnoreNullValues = True
                            'p_xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum  ' = DevExpress.XtraReports.UI.SummaryRunning.Group


                            'labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum    ' DevExpress.XtraReports.UI.SummaryFunc.RunningSum
                            labelDetail.Summary.IgnoreNullValues = True
                            labelDetail.Summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                            labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum

                        Case "COUNT"
                            labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
                            labelDetail.Summary.IgnoreNullValues = True
                            labelDetail.Summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                        Case "AVG"
                            labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
                            labelDetail.Summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                            labelDetail.Summary.IgnoreNullValues = True
                        Case "MIN"
                            labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Min
                            labelDetail.Summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                            labelDetail.Summary.IgnoreNullValues = True
                        Case "MAX"
                            labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
                            labelDetail.Summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                            labelDetail.Summary.IgnoreNullValues = True
                    End Select
                    ' labelDetail.Summary = p_xrSummary1
                    'GroupHeader.Controls.Add(p_xrSummary1)
                    '  labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.DSum

                    labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight



                    labelDetail.WidthF = xrtable.Rows(0).Cells.Item("Cell" & p_RowArr1(p_Count1).Item("FieldName").ToString.Trim).WidthF + 1


                    labelDetail.LeftF = xrtable.Rows(0).Cells.Item("Cell" & p_RowArr1(p_Count1).Item("FieldName").ToString.Trim).LeftF + 9


                    ' labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
                    labelDetail.Summary.FormatString = "{0:#,###}"
                    'Summary.FormatString = "{0:$0.00}"

                    'abelDetail.LeftF = tableWidth - 100
                    labelDetail.HeightF = GroupHeader.HeightF
                    ' p_LabelGroupWidth = p_LabelGroupWidth + labelDetail.WidthF

                    p_LabelGroupWidth = labelDetail.LeftF
                    GroupHeader.Controls.Add(labelDetail)

                    ' GroupFooter.Controls.Add(labelDetail)
                Next

                Select Case UCase(p_RowArr(p_Count).Item("FieldForMat").ToString.Trim)

                    Case "DATE"
                        labelGroup.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        ' xrcellheader.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")

                    Case "DATETIME"
                        labelGroup.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        'xrcellheader.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        'xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    Case Else
                        labelGroup.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim)
                        'xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                End Select




                'labelGroup.DataBindings.Add("Text", p_Report.DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim)


                labelGroup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                labelGroup.HeightF = GroupHeader.HeightF



                GroupHeader.Borders = DevExpress.XtraPrinting.BorderSide.All
                GroupHeader.BorderWidth = 1
                ' GroupHeader.KeepTogether = True

                GroupHeader.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
                labelGroup.BringToFront()
                GroupHeader.Controls.Add(labelGroup)

                'GroupFooter.Borders = DevExpress.XtraPrinting.BorderSide.All
                'GroupFooter.BorderWidth = 1
                'GroupFooter.KeepTogether = True
                'GroupFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                'GroupFooter.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)


                labelGroup.WidthF = tableWidth

                'GroupHeader.Level = p_RowArr(p_Count).Item("GroupSTT")

                'Treo footer

                .Bands.Add(GroupHeader)
                ' p_Report.Bands.Add(GroupFooter)
            Next


            p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
            p_DataTable1 = GetDataTable(p_SQL, p_SQL)


            If Not p_DataTable1 Is Nothing Then
                p_Count1 = p_DataTable1.Rows.Count
                If p_Count1 > 0 Then
                    p_Width = tableWidth / p_Count1
                    p_Left_Title = 0
                    p_Top_Title = 50
                    For p_Count = 0 To p_Count1 - 1
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        labelDetail.WidthF = p_Width
                        labelDetail.LeftF = p_Left_Title
                        labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
                        labelDetail.TopF = p_Top_Title
                        .ReportFooter.Controls.Add(labelDetail)


                        p_Left_Title = p_Left_Title + labelDetail.WidthF
                    Next
                End If

            End If



            .DataSource = p_DataTable
            .FillDataSource()
            'Them dong tong cong
            p_Top_Title = 0

            p_RowArr = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "' AND (GROUPTYPE='SUM' OR GROUPTYPE='COUNT' OR GROUPTYPE='MIN' OR GROUPTYPE='MAX')", "STT")

            .ShowPreviewDialog()


        End With
    End Sub






    Sub CreateReportNew(ByVal p_TableReturn As DataTable)
        Dim p_Report As New RptReport1
        Dim p_DataTable As DataTable
        Dim p_DataTable1 As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim tableWidth As Integer
        Dim p_RowArr() As DataRow
        Dim p_RowArr1() As DataRow
        Dim p_Row As DataRow
        Dim p_ReportCode As String
        Dim p_Count As Integer
        Dim p_Count1 As Integer
        Dim p_SQL As String = ""
        Dim xrtableheader As New DevExpress.XtraReports.UI.XRTable()
        Dim xrtable As New DevExpress.XtraReports.UI.XRTable()
        Dim xrrowheader As New DevExpress.XtraReports.UI.XRTableRow()
        Dim xrrow As New DevExpress.XtraReports.UI.XRTableRow()
        Dim p_ReportName As String
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel

        'Dim labelDetailtOTAL As DevExpress.XtraReports.UI.XRLabel


        Dim labelGroup As DevExpress.XtraReports.UI.XRLabel
        Dim TextGroup As DevExpress.XtraReports.UI.XRLabel
        Dim p_Text As DevExpress.XtraReports.UI.XRLabel

        Dim p_Left_Title As Double
        Dim p_Top_Title As Double
        Dim p_Width As Double
        Dim p_Object() As Object
        Dim StrParameter As String
        Dim p_NgangGiay As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_ShowParentCompany As Boolean = False

        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet

        Dim p_xrSummary1 As DevExpress.XtraReports.UI.XRSummary
        Dim p_LabelGroupWidth As Double = 0
        Dim p_LabelGroupLeft As Double = 0
        ' Dim p_TableReturn As DataTable
        Dim p_DetailHide As Boolean = False

        If Not Me.ReportName.EditValue Is Nothing Then
            p_ReportName = Me.ReportName.EditValue.ToString.Trim
        End If


        If Not Me.ReportCode.EditValue Is Nothing Then
            p_ReportCode = Me.ReportCode.EditValue.ToString.Trim
        End If
        If p_ReportCode = "" Then
            Exit Sub
        End If


        '  QueryData(True, p_SQL, p_TableReturn)

        'If p_SQL = "" Then
        '    ShowMessageBox("", "Dữ liệu không có")
        '    Exit Sub
        'End If
        p_DataTable = p_TableReturn   ' GetDataTable(p_SQL, p_SQL)
        If p_DataTable Is Nothing Then
            ShowMessageBox("", "Dữ liệu không có")
            Exit Sub
        End If





        With p_Report

            'Lay cac gia tri khac neu co
            p_RowArr = p_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
            If p_RowArr.Length > 0 Then
                If p_RowArr(0).Item("Landscape").ToString.Trim = "Y" Then
                    p_NgangGiay = True
                End If

                If p_RowArr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                    p_ShowCompany = True
                End If
                If p_RowArr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                    p_ShowParentCompany = True
                End If

                If p_RowArr(0).Item("DetailHide").ToString.Trim = "Y" Then
                    p_DetailHide = True
                End If

                Try
                    If p_RowArr(0).Item("PageType").ToString.Trim <> "" Then
                        Select Case p_RowArr(0).Item("PageType").ToString.Trim
                            Case "A4"
                                .PaperKind = Printing.PaperKind.A4
                            Case "A3"
                                .PaperKind = Printing.PaperKind.A3
                            Case "A5"
                                .PaperKind = Printing.PaperKind.A5
                        End Select

                    End If
                Catch ex As Exception

                End Try
            End If
            'If p_NgangGiay = True Then
            .Landscape = p_NgangGiay
            'End If


            tableWidth = .PageWidth - .Margins.Left - .Margins.Right - 20 '* 2

            xrrowheader.Name = "RowHeader"
            xrrow.Name = "Row"

            p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

            If Not p_TableCompany Is Nothing Then
                If p_TableCompany.Rows.Count > 0 Then
                    p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                    p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                    p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                    If Not p_DataSetCompany Is Nothing Then
                        If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                            p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                        End If

                        If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                            p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                        End If

                    End If
                End If
                p_Top_Title = .XrPictureBox1.TopF
                If p_ShowParentCompany = True Then
                    p_Text = New DevExpress.XtraReports.UI.XRLabel
                    p_Text.WidthF = tableWidth / 2
                    p_Text.LeftF = .XrPictureBox1.LeftF
                    p_Text.Text = p_ParentCompanyName
                    p_Text.TopF = p_Top_Title
                    p_Text.Font = New Font("Tahoma", 12.0F, FontStyle.Bold)
                    p_Text.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    p_Text.HeightF = p_Text.HeightF + (p_Text.HeightF * 0.2)
                    .ReportHeader.Controls.Add(p_Text)
                    p_Top_Title = p_Top_Title + p_Text.HeightF
                End If
                If p_ShowCompany = True Then
                    p_Text = New DevExpress.XtraReports.UI.XRLabel
                    p_Text.WidthF = tableWidth / 2
                    p_Text.LeftF = .XrPictureBox1.LeftF
                    p_Text.Text = p_CompanyName
                    p_Text.TopF = p_Top_Title
                    p_Text.Font = New Font("Tahoma", 10.0F, FontStyle.Regular)
                    p_Text.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    p_Text.HeightF = p_Text.HeightF + (p_Text.HeightF * 0.2)
                    .ReportHeader.Controls.Add(p_Text)
                    p_Top_Title = p_Top_Title + p_Text.HeightF
                End If

            End If


            p_Top_Title = p_Top_Title + 10
            .XrPictureBox1.TopF = p_Top_Title
            .XrPictureBox1.LeftF = .XrPictureBox1.LeftF + (.XrPictureBox1.WidthF / 2)

            p_Top_Title = .XrPictureBox1.TopF   ' .XrPictureBox1.TopF + .XrPictureBox1.HeightF
            p_Top_Title = p_Top_Title + (.XrLabel1.HeightF / 2)
            .XrLabel1.TopF = p_Top_Title
            .XrLabel1.LeftF = .XrPictureBox1.LeftF '+ .XrPictureBox1.WidthF
            .XrLabel1.Text = p_ReportName
            .XrLabel1.WidthF = tableWidth - 20


            p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            p_Left_Title = .XrLabel1.LeftF

            'Lay ra cac tham so co the treo len bao cao
            p_RowArr = p_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_RowArr.Length > 0 Then
                For p_Count = 0 To p_RowArr.Length - 1
                    p_Row = p_RowArr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = Me.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString(g_Format_Date)
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If

                        p_Object = Me.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " đến " & CDate(p_Object(0).editvalue).ToString(g_Format_Date)
                                Else
                                    StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                                End If

                            End If
                        End If

                    End If

                    If StrParameter <> "" Then
                        p_Text = New DevExpress.XtraReports.UI.XRLabel
                        p_Text.WidthF = tableWidth
                        p_Text.LeftF = p_Left_Title
                        p_Text.Text = StrParameter
                        p_Text.TopF = p_Top_Title
                        p_Text.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        p_Text.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        p_Text.HeightF = p_Text.HeightF + (p_Text.HeightF * 0.5)
                        .ReportHeader.Controls.Add(p_Text)
                        .ReportHeader.HeightF = .ReportHeader.HeightF + p_Text.HeightF
                    End If
                Next
            End If
            '.DataSource = p_DataTable
            p_RowArr = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "'", "STT")

            ' .Bands.Remove(.Detail1)
            For p_Count = 0 To p_RowArr.Length - 1

                Dim xrcellheader As New DevExpress.XtraReports.UI.XRTableCell()
                Dim xrcell As New DevExpress.XtraReports.UI.XRTableCell()
                xrcellheader.Name = "CellHeader" & p_Count
                xrcell.Name = "Cell" & p_RowArr(p_Count).Item("FieldName").ToString.Trim
                xrcellheader.Text = p_RowArr(p_Count).Item("FieldDesc").ToString.Trim
                '  xrcellheader.HeightF = xrcellheader.HeightF * 1.5
                xrcellheader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                Select Case UCase(p_RowArr(p_Count).Item("FieldForMat").ToString.Trim)
                    Case "TEXT"
                        xrcell.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim)
                        xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    Case "DATE"
                        xrcell.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        ' xrcellheader.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")

                        xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    Case "DATETIME"
                        xrcell.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        'xrcellheader.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    Case Else
                        xrcell.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim)   ', "{0:#,###}")
                        xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                End Select
                xrcellheader.Font = New Font("Tahoma", 10.0F, FontStyle.Bold)
                xrcell.Font = New Font("Tahoma", 10.0F, FontStyle.Regular)
                xrcellheader.HeightF = xrcellheader.HeightF * 2
                xrrowheader.Cells.Add(xrcellheader)
                'If p_DetailHide = True Then
                '    xrcell.Visible = False
                'Else
                xrrow.Cells.Add(xrcell)
                'End If



            Next

            xrrowheader.HeightF = xrrowheader.HeightF * 2

            xrtableheader.HeightF = xrrowheader.HeightF
            xrtableheader.WidthF = tableWidth ' .PageWidth - 40
            xrtableheader.BorderWidth = 1
            xrtableheader.LeftF = 10
            xrtableheader.TopF = .ReportHeader.HeightF - xrrowheader.HeightF + 20
            xrtableheader.Borders = DevExpress.XtraPrinting.BorderSide.All
            xrtableheader.Rows.Add(xrrowheader)


            xrtable.LeftF = 10
            xrtable.WidthF = tableWidth  '.PageWidth - 40
            xrtable.BorderWidth = 1
            xrtable.Borders = DevExpress.XtraPrinting.BorderSide.All
            xrtable.Rows.Add(xrrow)

            .ReportHeader.Controls.Add(xrtableheader)

            .Detail.Controls.Add(xrtable)
            '.DetailReport.Controls.Add(xrtable)

            '  .DetailReport.Bands.Add(xrtable)
            '  .Detail1.Visible = True
            '  .DataSource = p_DataTable
            p_RowArr = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "' and GroupField='Y'", "GroupSTT")
            For p_Count = 0 To p_RowArr.Length - 1
                Dim GroupHeader As New DevExpress.XtraReports.UI.GroupHeaderBand()

                Dim GroupFooter As New DevExpress.XtraReports.UI.GroupFooterBand()

                Dim groupField As New DevExpress.XtraReports.UI.GroupField(p_RowArr(p_Count).Item("FieldName").ToString.Trim, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)
                labelGroup = New DevExpress.XtraReports.UI.XRLabel

                ' labelGroup.Text = "aaaaa:"
                GroupHeader.HeightF = 40

                GroupFooter.HeightF = 40

                labelGroup.LeftF = 10 '20

                GroupHeader.BackColor = Color.LightCyan
                GroupFooter.BackColor = Color.LightCyan



                GroupHeader.Level = p_Count



                p_RowArr1 = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "' AND (GROUPTYPE='SUM' OR GROUPTYPE='COUNT' OR GROUPTYPE='MIN' OR GROUPTYPE='MAX')", "STT")


                GroupHeader.GroupFields.Add(groupField)

                p_LabelGroupWidth = 0

                p_LabelGroupLeft = tableWidth

                For p_Count1 = 0 To p_RowArr1.Length - 1
                    ' labelDetail = Nothing
                    labelDetail = New DevExpress.XtraReports.UI.XRLabel

                    ' p_xrSummary1 = New DevExpress.XtraReports.UI.XRSummary
                    'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.Left

                    labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.Right
                    labelDetail.SendToBack()
                    'labelDetail.DataBindings.Add("Text", .DataSource, p_RowArr1(p_Count1).Item("FieldName").ToString.Trim, "{0:#,###}")
                    labelDetail.DataBindings.Add("Text", Nothing, p_RowArr1(p_Count1).Item("FieldName").ToString.Trim)
                    'labelDetail.Summary = New DevExpress.XtraReports.UI.XRSummary(DevExpress.XtraReports.UI.SummaryRunning.Group, _
                    '                                                                DevExpress.XtraReports.UI.SummaryFunc.Sum, String.Empty)

                    '  labelDetail.Summary.GetResult()

                    Select Case p_RowArr1(p_Count1).Item("GROUPTYPE").ToString.Trim
                        Case "SUM"

                            '    labelDetail.Summary.Func = SummaryFunc.Sum
                            'summary.Running = SummaryRunning.Group;
                            'summary.IgnoreNullValues = true;
                            'summary.FormatString = "{0:c2}";
                            'cell.Text = summary.GetResult().ToString();
                            'p_xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                            'p_xrSummary1.IgnoreNullValues = True
                            'p_xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum  ' = DevExpress.XtraReports.UI.SummaryRunning.Group


                            'labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum    ' DevExpress.XtraReports.UI.SummaryFunc.RunningSum
                            labelDetail.Summary.IgnoreNullValues = True
                            labelDetail.Summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                            labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum

                        Case "COUNT"
                            labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
                            labelDetail.Summary.IgnoreNullValues = True
                            labelDetail.Summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                        Case "AVG"
                            labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
                            labelDetail.Summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                            labelDetail.Summary.IgnoreNullValues = True
                        Case "MIN"
                            labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Min
                            labelDetail.Summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                            labelDetail.Summary.IgnoreNullValues = True
                        Case "MAX"
                            labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
                            labelDetail.Summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
                            labelDetail.Summary.IgnoreNullValues = True
                    End Select
                    ' labelDetail.Summary = p_xrSummary1
                    'GroupHeader.Controls.Add(p_xrSummary1)
                    '  labelDetail.Summary.Func = DevExpress.XtraReports.UI.SummaryFunc.DSum

                    labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight






                    labelDetail.LeftF = xrtable.Rows(0).Cells.Item("Cell" & p_RowArr1(p_Count1).Item("FieldName").ToString.Trim).LeftF + 9
                    labelDetail.WidthF = xrtable.Rows(0).Cells.Item("Cell" & p_RowArr1(p_Count1).Item("FieldName").ToString.Trim).WidthF + 1

                    'If labelDetail.LeftF + labelDetail.WidthF > tableWidth Then
                    '    labelDetail.WidthF = tableWidth - labelDetail.LeftF
                    'End If
                    ' labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
                    labelDetail.Summary.FormatString = "{0:#,###}"
                    'Summary.FormatString = "{0:$0.00}"

                    'abelDetail.LeftF = tableWidth - 100
                    labelDetail.HeightF = GroupHeader.HeightF
                    ' p_LabelGroupWidth = p_LabelGroupWidth + labelDetail.WidthF

                    p_LabelGroupWidth = labelDetail.LeftF
                    GroupHeader.Controls.Add(labelDetail)

                    ' GroupFooter.Controls.Add(labelDetail)
                Next

                Select Case UCase(p_RowArr(p_Count).Item("FieldForMat").ToString.Trim)

                    Case "DATE"
                        labelGroup.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        ' xrcellheader.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")

                    Case "DATETIME"
                        labelGroup.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        'xrcellheader.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim, "{0:dd'/'MM'/'yyyy}")
                        'xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    Case Else
                        labelGroup.DataBindings.Add("Text", .DataSource, p_RowArr(p_Count).Item("FieldName").ToString.Trim)
                        'xrcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                End Select

                TextGroup = New DevExpress.XtraReports.UI.XRLabel
                TextGroup.Text = p_RowArr(p_Count).Item("FieldDesc").ToString.Trim & ": "

                labelGroup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                labelGroup.HeightF = GroupHeader.HeightF

                labelGroup.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
                TextGroup.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)

                GroupHeader.Borders = DevExpress.XtraPrinting.BorderSide.All
                GroupHeader.BorderWidth = 1
                ' GroupHeader.KeepTogether = True

                GroupHeader.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
                'labelGroup.BringToFront()
                TextGroup.TopF = labelGroup.TopF
                TextGroup.LeftF = labelGroup.LeftF
                TextGroup.HeightF = labelGroup.HeightF
                TextGroup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                TextGroup.Borders = DevExpress.XtraPrinting.BorderSide.Left
                GroupHeader.Controls.Add(TextGroup)

                labelGroup.LeftF = TextGroup.LeftF + TextGroup.WidthF

                labelGroup.Borders = DevExpress.XtraPrinting.BorderSide.None
                labelGroup.WidthF = xrtable.Rows(0).Cells.Item("Cell" & p_RowArr1(0).Item("FieldName").ToString.Trim).LeftF + 10 - labelGroup.LeftF
                ' labelGroup.BringToFront()
                '  labelGroup.WidthF = 50
                'labelGroup.Borders = DevExpress.XtraPrinting.BorderSide.Right
                GroupHeader.Controls.Add(labelGroup)

                GroupFooter.Borders = DevExpress.XtraPrinting.BorderSide.All
                GroupFooter.BorderWidth = 1
                GroupFooter.KeepTogether = True

                'GroupFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                GroupFooter.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
                p_Report.Bands.Add(GroupFooter)

                ' labelGroup.WidthF = tableWidth

                'GroupHeader.Level = p_RowArr(p_Count).Item("GroupSTT")

                'Treo footer
                ' GroupHeader()
                GroupHeader.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                GroupHeader.Borders = DevExpress.XtraPrinting.BorderSide.All
                .Bands.Add(GroupHeader)



                ' p_Report.Bands.Add(GroupFooter)
            Next

            If p_DetailHide = True Then
                .Detail.Visible = False
            End If

            p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
            p_DataTable1 = GetDataTable(p_SQL, p_SQL)

            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            p_Width = tableWidth - 20
            labelDetail.HeightF = 1
            labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
            labelDetail.WidthF = p_Width
            labelDetail.LeftF = 10
            .ReportFooter.Controls.Add(labelDetail)
            If Not p_DataTable1 Is Nothing Then
                p_Count1 = p_DataTable1.Rows.Count
                If p_Count1 > 0 Then
                    p_Width = tableWidth / p_Count1
                    p_Left_Title = 0
                    p_Top_Title = 50
                    For p_Count = 0 To p_Count1 - 1
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        labelDetail.WidthF = p_Width
                        labelDetail.LeftF = p_Left_Title
                        labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
                        labelDetail.TopF = p_Top_Title
                        .ReportFooter.Controls.Add(labelDetail)


                        p_Left_Title = p_Left_Title + labelDetail.WidthF
                    Next
                End If

            End If



            .DataSource = p_DataTable
            .FillDataSource()
            'Them dong tong cong
            p_Top_Title = 0

            p_RowArr = p_SYS_CONFIG_RPT_FIELD.Select("ReportCode='" & p_ReportCode & "' AND (GROUPTYPE='SUM' OR GROUPTYPE='COUNT' OR GROUPTYPE='MIN' OR GROUPTYPE='MAX')", "STT")

            .ShowPreviewDialog()


        End With
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_Err As String
        If p_XtraModuleObj.p_ModGridExportToExcelNew(Me.TrueDBGrid1, p_Err) = False Then
            ShowMessageBox("", p_Err)
        Else
            MsgBox("Đã thực hiện xong")
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        'hieptd4 add
        If Me.Check_Control_Required = False Then
            Exit Sub
        End If

        Dim p_SQL As String
        Dim p_BaoCao As String = ""
        Dim p_LoaiBaoCao As String = "V"
        Dim p_RowArr1() As DataRow
        Dim p_ProcedureName As String
        Dim p_TableReturn As DataTable
        Dim p_Dynamic As String = "N"

        If Not Me.ReportCode.EditValue Is Nothing Then
            p_BaoCao = Me.ReportCode.EditValue.ToString.Trim
        End If

        If p_BaoCao = "" Then
            Exit Sub
        End If

        p_RowArr1 = p_SYS_CONFIG_RPT.Select("ReportCode='" & p_BaoCao & "'")
        If p_RowArr1.Length > 0 Then
            p_LoaiBaoCao = p_RowArr1(0).Item("SourceType").ToString.Trim
            p_Dynamic = IIf(p_RowArr1(0).Item("RptDynamic").ToString.Trim = "", "N", p_RowArr1(0).Item("RptDynamic").ToString.Trim)
        End If

        'If p_LoaiBaoCao = "V" Then
        '    QueryData(True, p_SQL, p_TableReturn)
        'Else
        '    p_ProcedureName = p_RowArr1(0).Item("ViewName").ToString.Trim
        '    ExeProcedureData(True, p_SQL, p_BaoCao, p_ProcedureName, p_TableReturn)
        'End If
        If p_Dynamic = "N" Then
            If p_LoaiBaoCao = "V" Then
                QueryData(True, p_SQL, p_TableReturn)
                'Exit Sub
            Else
                p_ProcedureName = p_RowArr1(0).Item("ViewName").ToString.Trim
                ExeProcedureData(True, p_SQL, p_BaoCao, p_ProcedureName, p_TableReturn)


            End If

            If Not p_TableReturn Is Nothing Then
                Dim p_Binding As New U_TextBox.U_BindingSource
                p_Binding.DataSource = p_TableReturn

                Do While Me.GridView1.Columns.Count <> 0 'hieptd4 add
                    Try
                        Me.GridView1.Columns.Remove(Me.GridView1.Columns.Item(0))
                    Catch ex As Exception

                    End Try
                Loop

                Me.TrueDBGrid1.DataSource = p_Binding
                Me.GridView1.RefreshData()
                Dim p_Error As String

                If p_XtraModuleObj.p_ModGridExportToExcelNew(TrueDBGrid1, _
                                                  p_Error) = True Then

                End If
            Else
                Exit Sub
            End If
            ' CreateReportNew(p_TableReturn)
            'Exit Sub
        Else
            If p_LoaiBaoCao = "V" Then
                QueryData(True, p_SQL, p_TableReturn)
            Else
                p_ProcedureName = p_RowArr1(0).Item("ViewName").ToString.Trim
                ExeProcedureData(True, p_SQL, p_BaoCao, p_ProcedureName, p_TableReturn)
            End If
            CreateReportNew(p_TableReturn)
            Cursor = Cursors.Default

            Exit Sub
        End If



        Cursor = Cursors.Default
        Exit Sub

    End Sub


End Class