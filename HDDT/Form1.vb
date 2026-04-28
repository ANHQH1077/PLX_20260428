Imports System.IO
Public Class Form1
    Public g_HoaDonValue As String = ""
    Public g_HoaDonValue2 As MemoryStream
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.WebBrowser1.DocumentText
        '   Dim p_URL As New System.Uri("C:\Users\VirtualPC\Favorites")
        WebBrowser1.DocumentText = g_HoaDonValue  '.Write(p_String)

        'WebBrowser1.Url = p_URL   ' "C:\Users\VirtualPC\Favorites"
        WebBrowser1.AllowNavigation = True
        ' WebBrowser1.Navigate(New Uri("C:\Users\VirtualPC\Favorites\A20MEGE2H.html"))
        ' WebBrowser1.SuspendLayout()
        ' WebBrowser1.ObjectForScripting
        WebBrowser1.ScriptErrorsSuppressed = True
        'WebBrowser1.Document.Write(g_HoaDonValue)
        ' WebBrowser1.WebBrowserShortcutsEnabled = False

        WebBrowser1.ShowPrintPreviewDialog()


    End Sub
End Class