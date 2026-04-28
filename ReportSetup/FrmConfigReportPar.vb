Public Class FrmConfigReportPar
    Private p_RptCode As String = ""
    Public Property RptCode() As String
        Get
            Return p_RptCode
        End Get
        Set(ByVal value As String)
            p_RptCode = value
        End Set
    End Property

    Private p_SQL_ColumnName As String = ""
    Public Property SQL_ColumnName() As String
        Get
            Return p_SQL_ColumnName
        End Get
        Set(ByVal value As String)
            p_SQL_ColumnName = value
        End Set
    End Property

    Private Sub FrmConfigReportPar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_Where As String
        Dim p_Column As New U_TextBox.GridColumn
        p_Where = "ReportCode='" & p_RptCode & "'"
        Me.GridView1.Where = p_Where
        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)
        Me.DefaultFormLoad = False
        p_Column = Me.GridView1.Columns.Item("FieldName")
        p_Column.SQLString = p_SQL_ColumnName
    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging

        If UCase(e.Column.FieldName.ToString.Trim) <> "CHECKUPD" Then
            Me.GridView1.SetFocusedRowCellValue("ReportCode", p_RptCode)
        End If
    End Sub
End Class