Imports System.Windows.Forms

Public Class FrmMessage
    Public p_Show_OK As Boolean = False
    Public p_Show_Cancel As Boolean = False

    Public p_Show_OK_Text As String = "OK"
    Public p_Show_Cancel_Text As String = "CanCel"

    Public p_Window_Title As String = "Thông báo"
    Public p_Message_Text As String = ""
    Public p_Value_Return As Integer
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        p_Value_Return = 1
        Me.Close()
        'Me.
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        p_Value_Return = 2
        Me.Close()

    End Sub

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = p_Window_Title
        Me.Label1.Text = p_Message_Text
        Me.OK_Button.Text = p_Show_OK_Text
        Me.Cancel_Button.Text = p_Show_Cancel_Text
        Me.OK_Button.Visible = p_Show_OK
        Me.Cancel_Button.Visible = p_Show_Cancel
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
