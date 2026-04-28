Imports System.Runtime.InteropServices
Imports System.Threading


Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports DevExpress.XtraCharts

Public Class FrmReport

    Public Shared Function CoWaitForMultipleHandles(ByVal dwFlags As Int32, _
    ByVal dwTimeout As Int32, ByVal cHandles As Int32, ByVal pHandles() As IntPtr, _
    ByRef lpdwindex As Int32) As Int32
    End Function


    Private p_LoadData As DataTable
    Private p_DataTableParameter As New DataTable

    Private Const g_BCaptionLeft As Integer = 70
    Private Const g_BControlLeft As Integer = 200

    Private Const g_BCaptionTop As Integer = 60
    Private Const g_BControlTop As Integer = 55


    Private g_CaptionLeft As Integer = 70
    Private g_ControlLeft As Integer = 200

    Private g_CaptionTop As Integer = 60
    Private g_ControlTop As Integer = 55

    Private Const p_LableName As String = "Caption"
    Private Const p_ControlName As String = "Control"

    Private Const p_DisplayControlName As String = "Display"
    Private g_FormWidth As Integer = 0

    Private pv_FormName As String
    Private pv_ReportName As String
    Private pv_RptCode As String
    Private pv_Execute_Query As String
    Private pv_FormReport As System.Windows.Forms.Form


    Private pv_FormHeight As Integer
    Private pv_FormWidth As Integer

    Private Sub FrmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_Err As String = ""
        '  Dim p_Value As Integer
        If p_Set_Control_Required(Me, p_Err) = False Then
            MsgBox(p_Err)
        End If
        Me.g_FormLoad = True
        pv_FormHeight = Me.Height
        pv_FormWidth = Me.Width

        p_DataTableParameter.Columns.Add("U_Order", Type.GetType("System.Double"))
        p_DataTableParameter.Columns.Add("Parameter", Type.GetType("System.String"))


        '    Dim mainScreen As Screen = Screen.FromPoint(Me.Location)


        '   Me.HScroll = True
        
        'Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        'Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        'Me.WindowState = FormWindowState.Normal
        'Me.StartPosition = FormStartPosition.Manual
        ' Me.Location = New System.Drawing.Point(X, Y)

        'Me.StartPosition = FormStartPosition.CenterScreen
        'p_Value = Screen.PrimaryScreen.Bounds.Left + Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2
        ' Me.Location.X = 100
        'Me.Location.Y = Screen.PrimaryScreen.Bounds.Top + Me.Height / 2
        Me.g_FormLoad = False
    End Sub

    Public Sub Shop_Column_Button_Click(ByVal p_Item As U_TextBox.U_ButtonEdit, ByRef p_RptForm As System.Windows.Forms.Form)
        Dim p_Form As New FrmSearch
        Dim p_ShpCod As String = ""
        Dim p_Databale As New DataTable
        Dim p_RptCode As String = ""
        Dim p_EditText As New DevExpress.XtraEditors.TextEdit
        Dim p_SQL As String = ""

        Dim p_FptModule As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName, g_CurrencyDtl, g_Currency)


        Try

           

            If p_Item.SqlString <> "" And p_Item.SqlFielKey <> "" Then

                If p_Item.Name = "ReportCode" Then
                    p_HideParameter(p_RptForm)
                End If
                p_SQL = p_Item.SqlString

                p_SQL = p_Parameter_Item_Report(Me, p_SQL, p_DataTableParameter)
                p_Form.FptSQLString = p_SQL   'Replace(p_Item.SqlString, "@DATABASE", g_DatabaseName, 1)
                'p_Parameter_Item
                p_Form.FptFieldKey = p_Item.SqlFielKey
                p_Form.Fpt_Object = p_Item
                'p_Form.FptB1Get = False
                p_Form.FptPageNum = 1
                p_Form.FptLineOfPage = 1000
                p_Form.FptLoadPage = True
                p_Form.FptItemPosition = p_Item
                p_Form.FptTypePosition = "C"
                p_Form.FptParentForm = p_RptForm
                p_Form.FptShowLoad = p_Item.ShowLoad
                p_Form.FptRowID = 0

                p_Form.p_ObjSearchReturn(0) = p_Item.Name

                If p_Item.ItemReturn1 <> "" Then
                    p_Form.p_ObjSearchReturn(1) = p_Item.ItemReturn1
                End If
                If p_Item.ItemReturn2 <> "" Then
                    p_Form.p_ObjSearchReturn(2) = p_Item.ItemReturn2
                End If

                If p_Item.ItemReturn3 <> "" Then
                    p_Form.p_ObjSearchReturn(3) = p_Item.ItemReturn3
                End If


                p_Form.p_ColumnWidth(0) = "20"
                p_Form.p_ColumnWidth(1) = "80"
                p_Form.p_ChooseRecord = p_EditText
                p_Form.ShowDialog(p_RptForm)

                If UCase(p_Item.Name) = UCase("ReportCode") Then
                    If Not Me.ReportCode.EditValue Is Nothing Then
                        p_RptCode = Me.ReportCode.EditValue.ToString.Trim
                    End If
                    p_ShowParameter(p_RptForm, p_RptCode)
                End If
            End If
            p_FptModule = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            p_FptModule = Nothing
        End Try
    End Sub

    Private Sub ReportCode_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ReportCode.ButtonClick
        Shop_Column_Button_Click(Me.ReportCode, Me)

    End Sub

    Sub p_HideParameter(ByRef p_Form As System.Windows.Forms.Form)
        Dim p_Control_Ind As Integer
        Dim p_Object As Object
        Try
            '
            For p_Control_Ind = p_Form.Controls.Count - 1 To 0 Step -1
                p_Object = p_Form.Controls.Item(p_Control_Ind)
                If UCase(p_Object.name) <> UCase("LabelRpt") And UCase(p_Object.name) <> UCase("ReportCode") And UCase(p_Object.name) <> _
                        UCase("ReportName") And UCase(p_Object.name) <> UCase("U_ProName") _
                        And UCase(p_Object.name) <> UCase("ChartControl1") _
                        And (InStr(p_Object.name, p_LableName, CompareMethod.Text) > 0 Or InStr(p_Object.name, p_ControlName, CompareMethod.Text) > 0 _
                            Or InStr(p_Object.name, p_DisplayControlName, CompareMethod.Text) > 0) Then
                    ' p_Object.visible = False
                    p_Form.Controls.Remove(p_Object)
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If Me.Height <> pv_FormHeight Or Me.Width <> pv_FormWidth Then
            Me.Height = pv_FormHeight
            Me.Width = pv_FormWidth
        End If
       

    End Sub

    Sub p_ShowParameter(ByRef p_Form As System.Windows.Forms.Form, ByVal p_RptCode As String)
        Dim p_DataRow() As DataRow

        Dim p_DataTable As New System.Data.DataTable

        Dim p_Row As DataRow
        Dim p_Count As Integer
        '  Dim p_RptCode As String = ""
        Dim p_SQL As String
        Dim p_Err As String = ""
        Dim p_RowTmp As DataRow

        Dim p_ControlDate As U_TextBox.U_DateEdit
        Dim p_EditText As U_TextBox.U_TextBox
        Dim p_ButtonEdit As U_TextBox.U_ButtonEdit
        Dim p_Number As U_TextBox.U_NumericEdit

        Dim p_ControlLable As System.Windows.Forms.Label
        Try
            p_RptCode = ""
            '  Me.
            If Not Me.ReportCode.EditValue Is Nothing Then
                p_RptCode = Me.ReportCode.EditValue.ToString.Trim
            End If
            p_DataRow = g_ReportParameter.Select("Code='" & p_RptCode & "'", "U_Order")


            p_DataTableParameter.Clear()

            For p_Count = 0 To p_DataRow.Length - 1
                p_Row = p_DataRow(p_Count)

                p_RowTmp = p_DataTableParameter.NewRow


                If g_CaptionTop + 60 > Me.Height Or g_ControlTop + 60 > Me.Height Then
                    g_CaptionLeft = g_CaptionLeft + 400
                    g_ControlLeft = g_ControlLeft + 400
                    g_ControlTop = 55
                    g_CaptionTop = 60
                End If
                If p_Row.Item("U_CFL").ToString.Trim = "" Or p_Row.Item("U_CFL").ToString.Trim = "N" Or p_Row.Item("U_CFL").ToString.Trim = "NULL" Then
                    'AddHandler p_ButtonEdit.ButtonClick, AddressOf p_ButtonClick

                    Select Case p_Row.Item("U_ItmType").ToString.Trim
                        Case "D"
                            If p_Row.Item("U_VISIBLE").ToString.Trim = "Y" Then

                                p_ControlLable = New System.Windows.Forms.Label
                                p_ControlLable.Left = g_CaptionLeft
                                p_ControlLable.Top = g_CaptionTop
                                p_ControlLable.Name = p_LableName & p_Count
                                p_ControlLable.Text = p_Row.Item("U_ItmDes").ToString.Trim
                                g_CaptionTop = g_CaptionTop + p_ControlLable.Height
                                p_Form.Controls.Add(p_ControlLable)
                            End If
                            p_ControlDate = New U_TextBox.U_DateEdit
                            p_ControlDate.Left = g_ControlLeft
                            p_ControlDate.Top = g_ControlTop + 3
                            p_ControlDate.FieldType = p_Row.Item("U_ItmType").ToString.Trim
                            p_ControlDate.Name = p_ControlName & p_Count
                            If p_Row.Item("U_VISIBLE").ToString.Trim = "Y" Then
                                g_ControlTop = g_ControlTop + p_ControlDate.Height + 3
                            End If
                            'U_ReQuired
                            If p_Row.Item("U_ReQuired").ToString.Trim = "Y" Then
                                p_ControlDate.Required = "Y"
                            End If
                            If p_Row.Item("U_ParCode").ToString.Trim <> "" And p_Row.Item("U_ParCode").ToString.Trim <> "NULL" Then
                                p_ControlDate.TableName = p_Row.Item("U_ParCode").ToString.Trim
                            End If
                            If p_Row.Item("U_VISIBLE").ToString.Trim <> "Y" Then
                                p_ControlDate.Width = 0
                            Else
                                If p_Row.Item("ItemWidth") > 0 Then
                                    p_ControlDate.Width = p_Row.Item("ItemWidth")
                                End If
                            End If
                            p_RowTmp.Item("U_Order") = p_Row.Item("U_Order").ToString.Trim
                            p_RowTmp.Item("Parameter") = p_ControlDate.Name
                            p_DataTableParameter.Rows.Add(p_RowTmp)
                            p_Form.Controls.Add(p_ControlDate)
                        Case "C"
                            If p_Row.Item("U_VISIBLE").ToString.Trim = "Y" Then

                                p_ControlLable = New System.Windows.Forms.Label
                                p_ControlLable.Left = g_CaptionLeft
                                p_ControlLable.Top = g_CaptionTop
                                p_ControlLable.Name = p_LableName & p_Count
                                p_ControlLable.Text = p_Row.Item("U_ItmDes").ToString.Trim
                                g_CaptionTop = g_CaptionTop + p_ControlLable.Height
                                p_Form.Controls.Add(p_ControlLable)
                            End If


                            p_EditText = New U_TextBox.U_TextBox
                            p_EditText.Left = g_ControlLeft
                            p_EditText.Top = g_ControlTop + 3
                            p_EditText.FieldType = p_Row.Item("U_ItmType").ToString.Trim
                            p_EditText.Name = p_ControlName & p_Count
                            If p_Row.Item("U_VISIBLE").ToString.Trim = "Y" Then
                                g_ControlTop = g_ControlTop + p_EditText.Height + 3
                            End If
                            'U_ReQuired
                            If p_Row.Item("U_ReQuired").ToString.Trim = "Y" Then
                                p_EditText.Required = "Y"
                            End If

                            If p_Row.Item("U_ParCode").ToString.Trim <> "" And p_Row.Item("U_ParCode").ToString.Trim <> "NULL" Then
                                p_EditText.TableName = p_Row.Item("U_ParCode").ToString.Trim
                            End If
                            If p_Row.Item("U_VISIBLE").ToString.Trim <> "Y" Then
                                p_EditText.Width = 0
                            Else
                                If p_Row.Item("ItemWidth") > 0 Then
                                    p_EditText.Width = p_Row.Item("ItemWidth")
                                End If
                            End If

                            If p_Row.Item("U_DEFAULT").ToString.Trim <> "" Then
                                p_EditText.EditValue = p_Row.Item("U_DEFAULT").ToString.Trim
                            End If

                            If p_Row.Item("U_DEFAULTSQL").ToString.Trim <> "" Then
                                p_SQL = Replace(p_Row.Item("U_DEFAULTSQL").ToString.Trim, "@DATABASE", g_DatabaseName, 1)
                                p_DataTable = mod_SYS_GET_DATATABLE(p_SQL)
                                If Not p_DataTable Is Nothing Then
                                    If p_DataTable.Rows.Count > 0 Then
                                        p_EditText.EditValue = p_DataTable.Rows(0).Item(0)
                                    End If
                                End If
                            End If


                            p_Form.Controls.Add(p_EditText)
                            p_RowTmp.Item("U_Order") = p_Row.Item("U_Order").ToString.Trim
                            p_RowTmp.Item("Parameter") = p_EditText.Name
                            p_DataTableParameter.Rows.Add(p_RowTmp)
                        Case "N"
                            If p_Row.Item("U_VISIBLE").ToString.Trim = "Y" Then
                                p_ControlLable = New System.Windows.Forms.Label
                                p_ControlLable.Left = g_CaptionLeft
                                p_ControlLable.Top = g_CaptionTop
                                p_ControlLable.Name = p_LableName & p_Count
                                p_ControlLable.Text = p_Row.Item("U_ItmDes").ToString.Trim
                                g_CaptionTop = g_CaptionTop + p_ControlLable.Height
                                p_Form.Controls.Add(p_ControlLable)
                            End If
                            p_Number = New U_TextBox.U_NumericEdit
                            p_Number.Left = g_ControlLeft
                            p_Number.Top = g_ControlTop + 3
                            p_Number.FieldType = p_Row.Item("U_ItmType").ToString.Trim
                            p_Number.Name = p_ControlName & p_Count
                            If p_Row.Item("U_VISIBLE").ToString.Trim = "Y" Then
                                g_ControlTop = g_ControlTop + p_Number.Height + 3
                            End If
                            'U_ReQuired
                            If p_Row.Item("U_ReQuired").ToString.Trim = "Y" Then
                                p_Number.Required = "Y"
                            End If
                            If p_Row.Item("U_ParCode").ToString.Trim <> "" And p_Row.Item("U_ParCode").ToString.Trim <> "NULL" Then
                                p_Number.TableName = p_Row.Item("U_ParCode").ToString.Trim
                            End If
                            If p_Row.Item("U_VISIBLE").ToString.Trim <> "Y" Then
                                p_Number.Width = 0
                            Else
                                If p_Row.Item("ItemWidth") > 0 Then
                                    p_Number.Width = p_Row.Item("ItemWidth")
                                End If
                            End If
                            If p_Row.Item("U_DEFAULT").ToString.Trim <> "" Then
                                p_Number.EditValue = p_Row.Item("U_DEFAULT").ToString.Trim
                            End If

                            If p_Row.Item("U_DEFAULTSQL").ToString.Trim <> "" Then
                                p_SQL = Replace(p_Row.Item("U_DEFAULTSQL").ToString.Trim, "@DATABASE", g_DatabaseName, 1)
                                p_DataTable = mod_SYS_GET_DATATABLE(p_SQL)
                                If Not p_DataTable Is Nothing Then
                                    If p_DataTable.Rows.Count > 0 Then
                                        p_Number.EditValue = p_DataTable.Rows(0).Item(0)
                                    End If
                                End If
                            End If


                            p_Form.Controls.Add(p_Number)
                            p_RowTmp.Item("U_Order") = p_Row.Item("U_Order").ToString.Trim
                            p_RowTmp.Item("Parameter") = p_Number.Name
                            p_DataTableParameter.Rows.Add(p_RowTmp)
                    End Select
                Else   'Button Edit

                    p_ControlLable = New System.Windows.Forms.Label
                    p_ControlLable.Left = g_CaptionLeft
                    p_ControlLable.Top = g_CaptionTop
                    p_ControlLable.Name = p_LableName & p_Count
                    p_ControlLable.Text = p_Row.Item("U_ItmDes").ToString.Trim
                    g_CaptionTop = g_CaptionTop + p_ControlLable.Height
                    p_Form.Controls.Add(p_ControlLable)

                    p_ButtonEdit = New U_TextBox.U_ButtonEdit
                    p_ButtonEdit.Left = g_ControlLeft
                    p_ButtonEdit.Top = g_ControlTop + 3
                    p_ButtonEdit.Name = p_ControlName & p_Count
                    p_ButtonEdit.FieldType = p_Row.Item("U_ItmType").ToString.Trim
                    p_ButtonEdit.SqlString = p_Row.Item("U_SQL").ToString.Trim
                    'U_FieldKey
                    p_ButtonEdit.SqlFielKey = p_Row.Item("U_FieldKey").ToString.Trim

                    If p_Row.Item("U_SHOWLOAD").ToString.Trim = "Y" Then
                        p_ButtonEdit.ShowLoad = True
                    End If

                    If p_Row.Item("U_ReQuired").ToString.Trim = "Y" Then
                        p_ButtonEdit.Required = "Y"
                    End If
                    If p_Row.Item("U_ParCode").ToString.Trim <> "" And p_Row.Item("U_ParCode").ToString.Trim <> "NULL" Then
                        p_ButtonEdit.TableName = p_Row.Item("U_ParCode").ToString.Trim
                    End If
                    If p_Row.Item("U_DEFAULT").ToString.Trim <> "" Then
                        p_ButtonEdit.EditValue = p_Row.Item("U_DEFAULT").ToString.Trim
                    End If
                    If p_Row.Item("U_VISIBLE").ToString.Trim = "Y" Then
                        If p_Row.Item("ItemWidth") > 0 Then
                            p_ButtonEdit.Width = p_Row.Item("ItemWidth")
                        End If
                    End If
                    'p_EditText = New U_TextBox.U_TextBox
                    'p_EditText.Name = p_DisplayControlName & p_Count

                    'p_ButtonEdit.ItemReturn1 = p_EditText.Name

                    AddHandler p_ButtonEdit.ButtonClick, AddressOf p_ButtonClick
                    p_Form.Controls.Add(p_ButtonEdit)
                    p_RowTmp.Item("U_Order") = p_Row.Item("U_Order").ToString.Trim
                    p_RowTmp.Item("Parameter") = p_ButtonEdit.Name
                    p_DataTableParameter.Rows.Add(p_RowTmp)

                    'p_EditText.Left = g_ControlLeft + p_ButtonEdit.Width
                    'p_EditText.Top = g_ControlTop + 3
                    'p_EditText.Width = 300

                    'If g_FormWidth > Me.Width Then
                    '    Me.Width = g_FormWidth + 20
                    'Else
                    '    g_FormWidth = p_EditText.Left + p_EditText.Width + 20
                    'End If

                    'p_EditText.Properties.ReadOnly = True
                    'p_Form.Controls.Add(p_EditText)
                    If p_Row.Item("U_VISIBLE").ToString.Trim = "Y" Then
                        g_ControlTop = g_ControlTop + p_ButtonEdit.Height + 3



                    End If
                    End If
            Next

            g_CaptionLeft = g_BCaptionLeft
            g_ControlLeft = g_BControlLeft

            g_CaptionTop = g_BCaptionTop
            g_ControlTop = g_BControlTop
            If p_Set_Control_Required(p_Form, p_Err) = False Then
                MsgBox(p_Err)
            End If

            Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
            Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
            Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top

            Me.StartPosition = FormStartPosition.Manual
            Me.Location = New System.Drawing.Point(X, Y)


            ' Me.DefaultApp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub p_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Shop_Column_Button_Click(sender, Me)
    End Sub


    Public Sub p_ShowFormReportView()
        Dim p_FormReport As New FrmShowReport
        'Application.DoEvents()
        p_FormReport.TopMost = True
        p_FormReport.p_FormName = pv_FormName
        p_FormReport.p_ReportName = pv_ReportName
        p_FormReport.p_RptCode = pv_RptCode
        p_FormReport.p_Execute_Query = pv_Execute_Query
        p_FormReport.p_FormReport = pv_FormReport
        p_FormReport.WindowState = FormWindowState.Maximized
        ' p_FormReport.StartPosition = FormStartPosition.CenterScreen
        'p_FormReport.Show()
        p_FormReport.ShowDialog()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim p_Datatable As DataTable
        ' Dim p_Form As New FrmShowReport
        Dim p_FormName As String = ""
        Dim p_ReportName As String = ""
        Dim p_SQL As String
        Dim p_ProName As String = ""
        Dim p_Desc As String = ""
        Dim p_Dtb As DataTable


        Dim p_Report As New XtraReport1

        p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des("SELECT  [FORM_NAME],[DESCRIPTION] ,[WORK_STATION] ,[IP_ADDRESS] , PROJECT_CODE FROM [FPTRETAIL].[dbo].[SYS_FORMS]", p_Desc)
        'p_Report.DataTable1 = p_Datatable
        p_Report.DataSource = p_Datatable
        ' p_Report.Parameter1.Value = 123456
        p_Report.Parameter2.Visible = False
        ' p_Report.DataSet1.Tables(0).Merge(p_Datatable)
        p_Report.ShowPreviewDialog()

        Exit Sub

        If Not Me.ReportName.EditValue Is Nothing Then
            p_FormName = Me.ReportName.EditValue.ToString
        End If

        If Not Me.ReportCode.EditValue Is Nothing Then
            p_ReportName = Me.ReportCode.EditValue.ToString
        End If
        If p_ReportName = "" Then
            Exit Sub
        End If


        If Not Me.U_ProName.EditValue Is Nothing Then
            p_ProName = Me.U_ProName.EditValue.ToString
        End If
        If p_ProName = "" Then
            Exit Sub
        End If

        If p_Check_Control_Required(Me, p_Desc) = False Then
            MsgBox(p_Desc)
            Exit Sub
        End If


        p_SQL = p_ExecuteReport(Me, p_ReportName, p_ProName)
        '  p_Dtb = mod_SYS_GET_DATATABLE(p_SQL)
        'GenTTXFile("Test", p_Dtb)

        pv_FormName = p_FormName
        pv_ReportName = p_ReportName & ".rpt"
        pv_RptCode = p_ReportName
        pv_Execute_Query = p_SQL
        pv_FormReport = Me



        Dim trd As Threading.Thread

        Dim evt As ManualResetEvent = New ManualResetEvent(False)
        Dim waitHandles(0) As IntPtr

        Dim index As Int32
        Dim ret As Int32
        waitHandles(0) = evt.SafeWaitHandle.DangerousGetHandle

        ret = CoWaitForMultipleHandles(0, 0, waitHandles.Length, waitHandles, index)

        trd = New Threading.Thread(AddressOf p_ShowFormReportView)
        trd.Name = "ReportView"
        trd.IsBackground = True
        trd.SetApartmentState(Threading.ApartmentState.MTA)


        trd.Start()

    End Sub


    ''Private Sub ShowChart()
    'Private Sub ShowChart()
    '    ' Create an empty chart.
    '    'Dim sideBySideBarChart As ChartControl()
    '    Dim p_SQL As String = ""
    '    Dim p_DataTable As DataTable
    '    Dim p_Count As Integer
    '    Dim p_TypeChart As String

    '    Dim series1 As Series

    '    ' Create the first side-by-side bar series and add points to it.
    '    'Dim series1 As New Series("Side-by-Side Bar Series 1", ViewType.Pie3D)
    '    If GridView1.GroupCount <= 0 Then
    '        Exit Sub
    '    End If

    '    ChartControl1.Series.Clear()

    '    If Not Me.U_Combobox2.EditValue Is Nothing Then
    '        p_TypeChart = Me.U_Combobox2.EditValue.ToString.Trim
    '    End If

    '    Select Case p_TypeChart
    '        Case "Pie"
    '            series1 = New Series("", ViewType.Pie)
    '        Case "Pie3D"
    '            series1 = New Series("", ViewType.Pie3D)
    '        Case "Line"
    '            series1 = New Series("", ViewType.Line)
    '        Case "Line3D"
    '            series1 = New Series("", ViewType.Line3D)
    '    End Select

    '    If series1 Is Nothing Then
    '        Exit Sub
    '    End If
    '    'ChartControl1.Series.Add(series1)
    '    Me.ChartControl1.DataSource = p_LoadData
    '    'ChartControl1.Titles.Clear()

    '    'series1.ValueDataMembers.AddRange(New String() {Me.GridView1.GroupSummary.Item(0).SummaryValue})
    '    series1.ValueDataMembers.AddRange(New String() {Me.GridView1.GroupSummary.Item(0).FieldName})
    '    series1.ArgumentDataMember = Me.GridView1.GroupedColumns.Item(0).FieldName

    '    series1.PointOptions.PointView = PointView.ArgumentAndValues
    '    series1.LegendPointOptions.PointView = PointView.ArgumentAndValues

    '    Me.ChartControl1.Series.Add(series1)
    '    ChartControl1.Legend.Visible = True

    '    ChartControl1.Visible = True






    '    Exit Sub







    '    Me.ChartControl1.DataSource = p_LoadData

    '    ChartControl1.SeriesDataMember = Me.GridView1.GroupedColumns.Item(0).FieldName
    '    ChartControl1.SeriesTemplate.ArgumentDataMember = GridView1.GroupSummary.Item(0).FieldName ' Me.GridView1.GroupedColumns.Item(0).FieldName
    '    ChartControl1.SeriesTemplate.ValueDataMembers.AddRange(New String() {Me.GridView1.GroupSummary.Item(0).FieldName})
    '    'ChartControl1.SeriesTemplate.PointOptions.PointView

    '    ChartControl1.Visible = True

    'End Sub


    Function p_ExecuteReport(ByVal p_form As System.Windows.Forms.Form, ByVal p_ReportCode As String, ByVal p_ReportProcedure As String) As String
        'Dim p_Control_Ind As Integer
        Dim p_Object() As Object
        Dim p_DataRow() As System.Data.DataRow
        Dim p_Row As System.Data.DataRow
        Dim p_Count As Integer
        Dim p_ControlDate As U_TextBox.U_DateEdit
        Dim p_EditText As U_TextBox.U_TextBox
        Dim p_ButtonEdit As U_TextBox.U_ButtonEdit
        Dim p_NumberEdit As U_TextBox.U_NumericEdit
        Dim p_ObjName As String
        Dim p_SQLExec As String = " Exec " & p_ReportProcedure & ""
        Dim p_Parameter As String = ""
        Dim p_DataTable As New System.Data.DataTable

        Dim p_FrmShow As New FrmShowReport
        Try

            p_DataRow = g_ReportParameter.Select("Code='" & p_ReportCode & "'", "U_Order")
            For p_Count = 0 To p_DataRow.Length - 1
                p_Row = p_DataRow(p_Count)

                If p_Row.Item("ParameterInput").ToString.Trim <> "N" Then


                    p_ObjName = p_ControlName & p_Count

                    p_Object = p_form.Controls.Find(p_ObjName, True)
                    If Not p_Object Is Nothing Then
                        If p_Row.Item("U_CFL").ToString.Trim = "" Or p_Row.Item("U_CFL").ToString.Trim = "N" Or p_Row.Item("U_CFL").ToString.Trim = "NULL" Then
                            'AddHandler p_ButtonEdit.ButtonClick, AddressOf p_ButtonClick
                            Select Case p_Row.Item("U_ItmType").ToString.Trim
                                Case "D"
                                    p_ControlDate = p_Object(0)
                                    If Not p_ControlDate.EditValue Is Nothing Then
                                        p_Parameter = p_Parameter & ",'" & CDate(p_ControlDate.EditValue).ToString("yyyyMMdd") & "'"
                                    Else
                                        p_Parameter = p_Parameter & ",''"
                                    End If
                                Case "C"
                                    p_EditText = p_Object(0)
                                    If Not p_EditText.EditValue Is Nothing Then
                                        If p_EditText.EditValue.ToString.Trim = "" Then
                                            p_Parameter = p_Parameter & ",'All'"
                                        Else
                                            p_Parameter = p_Parameter & ",'" & p_EditText.EditValue & "'"
                                        End If

                                    Else
                                        p_Parameter = p_Parameter & ",'All'"
                                    End If
                                Case "N"
                                    p_NumberEdit = p_Object(0)
                                    If Not p_NumberEdit.EditValue Is Nothing Then
                                        If p_NumberEdit.EditValue.ToString.Trim = "" Then
                                            p_Parameter = p_Parameter & ",-999"
                                        Else
                                            p_Parameter = p_Parameter & "," & p_NumberEdit.EditValue & ""
                                        End If

                                    Else
                                        p_Parameter = p_Parameter & ",-999"
                                    End If
                            End Select
                        Else   'Button Edit
                            p_ButtonEdit = p_Object(0)
                            If Not p_ButtonEdit.EditValue Is Nothing Then
                                If p_ButtonEdit.EditValue.ToString.Trim = "" Then
                                    If p_Row.Item("U_ItmType").ToString.Trim = "N" Then
                                        p_Parameter = p_Parameter & ",-999"
                                    Else
                                        p_Parameter = p_Parameter & ",'All'"
                                    End If
                                Else
                                    If p_Row.Item("U_ItmType").ToString.Trim = "N" Then
                                        p_Parameter = p_Parameter & "," & p_ButtonEdit.EditValue & ""
                                    Else
                                        p_Parameter = p_Parameter & ",'" & p_ButtonEdit.EditValue & "'"
                                    End If
                                End If

                            Else
                                'p_Parameter = p_Parameter & ",Null"
                                If p_Row.Item("U_ItmType").ToString.Trim = "N" Then
                                    p_Parameter = p_Parameter & ",-999"
                                Else
                                    p_Parameter = p_Parameter & ",'All'"
                                End If
                            End If
                        End If

                    End If

                End If
            Next
            p_Parameter = " " & p_Parameter.Trim(",") & " "
            p_SQLExec = p_SQLExec & " " & p_Parameter
            Return p_SQLExec
            '  p_DataTable = mod_SYS_GET_DATATABLE(p_SQLExec)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try

    End Function




    Private Sub FrmReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim p_Top As Integer
        Dim p_Left As Integer
        Dim p_FormHeight As Integer
        Dim p_FormWidth As Integer
        p_FormHeight = Me.Height
        p_FormWidth = Me.Width
    End Sub

    Private Sub ReportCode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportCode.EditValueChanged
        If Not Me.ReportCode.EditValue Is Nothing Then
            If Me.ReportCode.EditValue.ToString.Trim <> "" Then
                p_ShowParameter(Me, Me.ReportCode.EditValue.ToString.Trim)
                
            End If
        End If
    End Sub
End Class