Imports System.IO
Imports System.Windows.Forms
Public Class MainClass

    Public Sub New(ByVal p_Services As Object)
        g_Services = p_Services
    End Sub



    Public Sub ShowMainForm()
        Dim nIcon = New NotifyIcon()
        Dim frmMain As New FPTMain.MDIMainForm()
        nIcon.Icon = frmMain.Icon
        nIcon.Visible = True
        nIcon.Text = Application.ProductName
        'p_frmMain = frmMain
        '  WriteToRam()

        Application.Run(frmMain)
        'frmMain.Show()


    End Sub
End Class
