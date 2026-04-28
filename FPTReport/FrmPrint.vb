Public Class FrmPrint 

    Private Sub FrmPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p_ShowReport()
    End Sub

    Sub p_ShowReport()
        ' Dim p_DataRow() As System.Data.DataRow
        Dim p_Count As Integer
        Dim p_PathRpt As String
        '  Dim p_Row As System.Data.DataRow
        ' Dim p_DataReader As OleDb.OleDbDataReader

        Dim p_Dataset As New DataSet
        'Dim p_Object As Object
        Dim p_Desc As String = ""
        Try

            Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
         

            CrystalReportViewer1.ActiveViewIndex = 0
            CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            CrystalReportViewer1.DisplayGroupTree = True
            CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
            CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
            CrystalReportViewer1.Name = "Chứng từ"

            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

            ' Dim p_Table As New DataTable

            'MsgBox(p_Execute_Query)
            'p_Table = mod_SYS_GET_DATATABLE(p_Execute_Query)

            p_PathRpt = Application.StartupPath & "\Reports\" & g_Print_ReportName
            'MsgBox(p_PathRpt)
            If IO.File.Exists(p_PathRpt) = False Then
                MsgBox("Không xác định được báo cáo " & g_Print_ReportName)
                Exit Sub

            End If
            '  Report.load
            p_Dataset = g_Services.mod_SYS_GET_DATASET(g_SQLPrintReport)
            If p_Desc.Trim <> "" Then
                MsgBox(p_Desc)
                Exit Sub
            End If
            'Report.Database.Tables(0).
            Report.Load(p_PathRpt)
            '  Report.SetDataSource(p_Dataset)
            For p_Count = 0 To p_Dataset.Tables.Count - 1
                Report.Database.Tables(p_Count).SetDataSource(p_Dataset.Tables(p_Count))
                'Report.Database.Tables(1).SetDataSource(p_Dataset.Tables(1))
                'Report.Database.Tables(2).SetDataSource(p_Dataset.Tables(2))
            Next
            CrystalReportViewer1.ReportSource = Report

            'Me.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class