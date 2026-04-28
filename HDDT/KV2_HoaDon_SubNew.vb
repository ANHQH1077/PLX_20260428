Public Class KV2_HoaDon_SubNew
    Private p_Item As DevExpress.XtraReports.UI.XRLabel
    Private Sub XrLabel1_AfterPrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles XrLabel1.AfterPrint
        If Me.XrLabel1.Text = "" Or Me.XrLabel1.Text Is Nothing Then
            ' Me.XrLabel1.SendToBack()
            'Me.XrLabel1.Visible = False
            'Me.XrLabel14.Visible = True
            'Me.XrLabel15.Visible = True
            'Me.XrLabel16.Visible = True
            'Me.XrLabel17.Visible = True
            'Me.XrLabel18.Visible = True


        Else
            'Me.XrLabel14.Visible = False
            'Me.XrLabel15.Visible = False
            'Me.XrLabel16.Visible = False
            'Me.XrLabel17.Visible = False
            'Me.XrLabel18.Visible = False


            ''Me.XrLabel1.Visible = True
            'p_Item = New DevExpress.XtraReports.UI.XRLabel
            'p_Item.TopF = Me.XrLabel1.TopF
            'p_Item.LeftF = Me.XrLabel1.LeftF
            'p_Item.HeightF = Me.XrLabel1.HeightF
            'p_Item.WidthF = Me.XrLabel1.WidthF
            'p_Item.Text = Me.XrLabel1.Text
            ''   Me.Detail.Controls.Add(p_Item)
            'Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {p_Item})

            '' Me.XrLabel1.BringToFront()
        End If
    End Sub

    Private Sub XrLabel1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabel1.BeforePrint
        'If Me.XrLabel1.Text = "" Or Me.XrLabel1.Text Is Nothing Then
        '    Me.XrLabel1.SendToBack()
        '    Me.XrLabel1.Visible = False
        '    Me.XrLabel14.Visible = True
        '    Me.XrLabel15.Visible = True
        '    Me.XrLabel16.Visible = True
        '    Me.XrLabel17.Visible = True
        '    Me.XrLabel18.Visible = True


        'Else
        '    Me.XrLabel14.Visible = False
        '    Me.XrLabel15.Visible = False
        '    Me.XrLabel16.Visible = False
        '    Me.XrLabel17.Visible = False
        '    Me.XrLabel18.Visible = False
        '    Me.XrLabel1.Visible = True

        '    Me.XrLabel1.BringToFront()
        'End If
    End Sub

    Private Sub XrLabel1_EvaluateBinding(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UI.BindingEventArgs) Handles XrLabel1.EvaluateBinding
        'If Me.XrLabel1.Text = "" Or Me.XrLabel1.Text Is Nothing Then
        'Me.XrLabel1.SendToBack()
        'Me.XrLabel1.Visible = False
        'Me.XrLabel14.Visible = True
        'Me.XrLabel15.Visible = True
        'Me.XrLabel16.Visible = True
        'Me.XrLabel17.Visible = True
        'Me.XrLabel18.Visible = True


        'Else
        '    Me.XrLabel14.Visible = False
        '    Me.XrLabel15.Visible = False
        '    Me.XrLabel16.Visible = False
        '    Me.XrLabel17.Visible = False
        '    Me.XrLabel18.Visible = False
        '    Me.XrLabel1.Visible = True

        '    Me.XrLabel1.BringToFront()
        'End If
    End Sub
End Class