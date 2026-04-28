Public Class XtraReport1

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub XtraReport1_DesignerLoaded(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs) Handles Me.DesignerLoaded

    End Sub

    Private Sub XtraReport1_ParametersRequestSubmit(ByVal sender As Object, ByVal e As DevExpress.XtraReports.Parameters.ParametersRequestEventArgs) Handles Me.ParametersRequestSubmit
        ' Me.GetFilterCriteria("PROJECT_CODE='" & Parameter1.Value & "'")
        If Parameter1.Value.ToString.Trim <> "" Then
            Me.FilterString = "PROJECT_CODE='" & Parameter1.Value & "'"
        Else
            Me.FilterString = ""
        End If
        Me.ApplyFiltering()
    End Sub
End Class