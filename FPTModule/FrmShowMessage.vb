Public Class FrmShowMessage 
    Private pv_ErrNumber As String = ""
    Private pv_ErrString = ""
    'Private pv_BtnYes As U_TextBox.U_Button = Nothing
    'Private pv_BtnNo As U_TextBox.U_Button = Nothing
    'Private pv_BtnCancel As U_TextBox.U_Button = Nothing

    Private pv_BtnYes As Boolean = False
    Private pv_TextYes As String = ""
    Private pv_BtnNo As Boolean = False
    Private pv_TextNo As String = ""
    Private pv_BtnCancel As Boolean = False
    Private pv_TextCancel As String = ""
    Private pv_DefaultButton As Integer = 0

    Private pv_Type As Integer = 0

    Private Sub FrmShowMessage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        ' MsgBox(Asc(e.KeyChar))
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmShowMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_imgTop As Integer = 5
        Dim p_imgLeft As Integer = 5

        Dim p_Count As Integer = 0

        If pv_ErrNumber <> "" Then
            Dim p_Datatable As DataTable
            Dim p_SQL As String
            Me.DialogResult = Windows.Forms.DialogResult.None
            Me.U_MemmoEdit1.BackColor = Me.BackColor
            Try
                p_SQL = "SELECT * FROM FPTMESSAGE WHERE ERRNUM='" & pv_ErrNumber & "'"
                p_Datatable = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If p_SQL = "" Then
                    If Not p_Datatable Is Nothing Then
                        If p_Datatable.Rows.Count > 0 Then
                            If p_Datatable.Rows(0).Item("ERRDESC").ToString.Trim <> "" Then
                                pv_ErrString = p_Datatable.Rows(0).Item("ERRDESC").ToString.Trim
                            End If
                            If p_Datatable.Rows(0).Item("BtnYes").ToString.Trim = "Y" Then
                                Me.BtnYes.Visible = True
                                ' p_Count = p_Count + 1
                            End If
                            If p_Datatable.Rows(0).Item("TextYes").ToString.Trim <> "" Then
                                Me.BtnYes.Text = p_Datatable.Rows(0).Item("TextYes").ToString.Trim
                            End If

                            If p_Datatable.Rows(0).Item("BtnNo").ToString.Trim = "Y" Then
                                Me.BtnNo.Visible = True
                                ' p_Count = p_Count + 1
                            End If
                            If p_Datatable.Rows(0).Item("TextNo").ToString.Trim <> "" Then
                                Me.BtnNo.Text = p_Datatable.Rows(0).Item("TextNo").ToString.Trim
                            End If

                            If p_Datatable.Rows(0).Item("BtnCanCel").ToString.Trim = "Y" Then
                                Me.BtnCancel.Visible = True
                                '_Count = p_Count + 1
                            End If
                            If p_Datatable.Rows(0).Item("TextCancel").ToString.Trim <> "" Then
                                Me.BtnCancel.Text = p_Datatable.Rows(0).Item("TextCancel").ToString.Trim
                            End If

                            If p_Datatable.Rows(0).Item("BtnNo").ToString.Trim <> "Y" And p_Datatable.Rows(0).Item("BtnCanCel").ToString.Trim <> "Y" Then
                                Me.BtnYes.Left = Me.BtnCancel.Left
                            End If
                            Me.U_MemmoEdit1.Text = pv_ErrString
                        Else
                            Me.U_MemmoEdit1.Text = pv_ErrNumber & "-" & pv_ErrString
                            Me.BtnYes.Visible = False
                            Me.BtnNo.Visible = False
                            Me.BtnCancel.Visible = False

                            If pv_BtnYes = True Then
                                p_Count = p_Count + 1
                                Me.BtnYes.Visible = True
                                If pv_TextYes <> "" Then
                                    Me.BtnYes.Text = pv_TextYes
                                End If
                            End If

                            If pv_BtnNo = True Then
                                p_Count = p_Count + 1
                                Me.BtnNo.Visible = True
                                If pv_TextNo <> "" Then
                                    Me.BtnNo.Text = pv_TextNo
                                End If
                            End If

                            If pv_BtnCancel = True Then
                                p_Count = p_Count + 1
                                Me.BtnCancel.Visible = True
                                If pv_TextCancel <> "" Then
                                    Me.BtnCancel.Text = pv_TextCancel
                                End If
                            End If

                            Select Case pv_DefaultButton
                                Case 1
                                    Me.AcceptButton = Me.BtnYes
                                Case 2
                                    Me.AcceptButton = Me.BtnNo
                                    ' Me.CancelButton = Me.BtnNo
                                Case 3
                                    Me.AcceptButton = Me.BtnCancel
                            End Select
                            If pv_BtnCancel = False And pv_BtnNo = False And pv_BtnYes = True Then
                                Me.BtnYes.Left = Me.BtnCancel.Left
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
            If p_Count > 1 Then
                imgInfor.Visible = True
                imgInfor.Top = p_imgTop
                imgInfor.Left = p_imgLeft
            Else
                Select Case pv_Type
                    Case 0   'imgSuccess   
                        imgSuccess.Visible = True
                        imgSuccess.Top = p_imgTop
                        imgSuccess.Left = p_imgLeft
                    Case 1   'imgInfor  
                        imgInfor.Visible = True
                        imgInfor.Top = p_imgTop
                        imgInfor.Left = p_imgLeft
                    Case 2   'mgWarn
                        imgWarn.Visible = True
                        imgWarn.Top = p_imgTop
                        imgWarn.Left = p_imgLeft
                    Case 3  'imgError
                        imgErr.Visible = True
                        imgErr.Top = p_imgTop
                        imgErr.Left = p_imgLeft
                    Case Else


                End Select
            End If
            Exit Sub
        End If



        Me.U_MemmoEdit1.Text = pv_ErrString
        Me.BtnYes.Visible = False
        Me.BtnNo.Visible = False
        Me.BtnCancel.Visible = False

        If pv_BtnYes = True Then
            p_Count = p_Count + 1
            Me.BtnYes.Visible = True
            If pv_TextYes <> "" Then
                Me.BtnYes.Text = pv_TextYes
            End If
        End If

        If pv_BtnNo = True Then
            p_Count = p_Count + 1
            Me.BtnNo.Visible = True
            If pv_TextNo <> "" Then
                Me.BtnNo.Text = pv_TextNo
            End If
        End If

        If pv_BtnCancel = True Then
            p_Count = p_Count + 1
            Me.BtnCancel.Visible = True
            If pv_TextCancel <> "" Then
                Me.BtnCancel.Text = pv_TextCancel
            End If
        End If

        Select Case pv_DefaultButton
            Case 1
                Me.AcceptButton = Me.BtnYes
            Case 2
                Me.AcceptButton = Me.BtnNo
                ' Me.CancelButton = Me.BtnNo
            Case 3
                Me.AcceptButton = Me.BtnCancel
        End Select
        If pv_BtnCancel = False And pv_BtnNo = False And pv_BtnYes = True Then
            Me.BtnYes.Left = Me.BtnCancel.Left
        End If
        If p_Count > 1 Then
            imgInfor.Visible = True
            imgInfor.Top = p_imgTop
            imgInfor.Left = p_imgLeft
        Else
            Select Case pv_Type
                Case 0   'imgSuccess   
                    imgSuccess.Visible = True
                    imgSuccess.Top = p_imgTop
                    imgSuccess.Left = p_imgLeft
                Case 1   'imgInfor  
                    imgInfor.Visible = True
                    imgInfor.Top = p_imgTop
                    imgInfor.Left = p_imgLeft
                Case 2   'mgWarn
                    imgWarn.Visible = True
                    imgWarn.Top = p_imgTop
                    imgWarn.Left = p_imgLeft
                Case 3  'imgError
                    imgErr.Visible = True
                    imgErr.Top = p_imgTop
                    imgErr.Left = p_imgLeft
                Case Else


            End Select
        End If


       
        Exit Sub
       
    End Sub

    Public Sub New(Optional ByVal p_ErrNumber As String = "", _
                    Optional ByVal p_Message As String = "", _
                    Optional ByVal p_BtnYes As Boolean = False, _
                    Optional ByVal p_TextYes As String = "", _
                    Optional ByVal p_BtnNo As Boolean = False, _
                    Optional ByVal p_TextNo As String = "", _
                    Optional ByVal p_BtnCancel As Boolean = False, _
                    Optional ByVal p_TextCancel As String = "", _
                    Optional ByVal p_DefaultButton As Integer = 0, _
                    Optional ByVal p_Type As Integer = 0)
        pv_ErrNumber = p_ErrNumber
        pv_ErrString = p_Message
        pv_BtnYes = p_BtnYes
        pv_TextYes = p_TextYes
        pv_BtnNo = p_BtnNo
        pv_TextNo = p_TextNo
        pv_BtnCancel = p_BtnCancel
        pv_TextCancel = p_TextCancel
        pv_DefaultButton = p_DefaultButton
        pv_Type = p_Type
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub BtnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnYes.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNo.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub
End Class