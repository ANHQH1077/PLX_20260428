Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic
Public Class FrmShowReport
    Public p_FormName As String
    Public p_ReportName As String = ""
    Public p_Execute_Query As String = ""
    Public p_DisplayGroupTree As Boolean = False
    Public p_FormReport As System.Windows.Forms.Form
    Public p_RptCode As String = ""

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p_ShowReport()
    End Sub

    Sub p_ShowReport()
        Dim p_DataRow() As System.Data.DataRow
        Dim p_Count As Integer
        Dim p_PathRpt As String
        Dim p_Row As System.Data.DataRow
        Dim p_DataReader As OleDb.OleDbDataReader

        Dim p_Object As Object
        Try

            Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            ''Dim paramDiscreteValue1 As CrystalDecisions.Shared.ParameterDiscreteValue
            'Dim paramFields As CrystalDecisions.Shared.ParameterFields = New CrystalDecisions.Shared.ParameterFields()
            ''Dim paramField3 As CrystalDecisions.Shared.ParameterField

            'Dim paramField As New CrystalDecisions.Shared.ParameterField
            'Dim paramDiscreteValue As CrystalDecisions.Shared.ParameterDiscreteValue
            'Dim paramValues As CrystalDecisions.Shared.ParameterValues
            'rpt.DataDefinition.RecordSelectionFormula = "{Emp.name} like '" & Trim(txtName.Text) & "*'"
            CrystalReportViewer.ActiveViewIndex = 0
            CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            CrystalReportViewer.DisplayGroupTree = True
            CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
            CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
            CrystalReportViewer.Name = "RptViewer"

            CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

            Dim p_Table As New DataTable

            'MsgBox(p_Execute_Query)
            ' p_Table = mod_SYS_GET_DATATABLE(p_Execute_Query)

            p_PathRpt = Application.StartupPath & "\" & p_ReportName
            'MsgBox(p_PathRpt)
            If IO.File.Exists(p_PathRpt) = False Then
                MsgBox("Không xác định được báo cáo " & p_ReportName)
                Exit Sub

            End If
            Report.Load(p_PathRpt)

            ' Dim DataSet As New DataSet
            'Dim DataSet As New DataSet

            '' p_Table.TableName = "FI_0204_V3"
            'p_DataReader = mod_SYS_GET_DATAREADER(p_Execute_Query)


            'DataSet.Tables.Add(mod_SYS_GET_DATATABLE(p_Execute_Query))
            'DataSet.Tables(0).TableName = "FI0204_V3"

            'DataSet.Tables.Add(mod_SYS_GET_DATATABLE("SELECT * FROM FPT_NDHT"))
            'DataSet.Tables(1).TableName = "FPT_NDHT"

            'p_Table = mod_SYS_GET_DATATABLE("SELECT * FROM FPT_NDHT")
            'p_Table.TableName = "FPT_NDHT"
            'DataSet.Tables.Add(p_Table)
            ' If Not p_Table Is Nothing Then
            'If p_Table.Rows.Count > 0 Then



            'Report.OpenSubreport("FI0204_Sub.rpt")

            ''Report.Subreports.Item(0).SetDataSource(p_Table)
            ''Set Parameter cho bao cao

            'p_Table = mod_SYS_GET_DATATABLE("SELECT * FROM FPT_NDHT")
            'Report.Subreports.Item("FI0204_Sub.rpt").SetDataSource(p_Table)

            'Report.Subreports[0].SetDataSource (p_Table)
            p_Table = mod_SYS_GET_DATATABLE(p_Execute_Query)

            If p_Table Is Nothing Then
                Exit Sub
            End If
            Report.SetDataSource(p_Table)

            For p_Count = 0 To p_FormReport.Controls.Count - 1
                p_Object = p_FormReport.Controls.Item(p_Count)

                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                    If p_Object.TableName <> "" Then
                        Try
                            If Not p_Object.EditValue Is Nothing Then
                                If p_Object.EditValue.ToString.Trim <> "" Then
                                    Report.SetParameterValue(p_Object.TableName, p_Object.EditValue)
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                    End If

                End If
            Next

           
            CrystalReportViewer.ReportSource = Report



            Me.Text = p_FormName
            'Me.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
End Class