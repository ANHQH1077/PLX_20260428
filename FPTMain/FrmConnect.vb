
Public Class FrmConnect
    Dim g_PathXML As String
    Dim g_Config_XMLDatatable As DataTable


    Private Sub FrmConnect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetTypeConnectWCF()

    End Sub
    Private Sub GetTypeConnectWCF()

        Dim p_DataSet As New DataSet

        Dim p_Count As Integer
        Dim p_Name As String
        Dim p_Control() As Windows.Forms.Control
        Dim p_EditText As U_TextBox.U_TextBox
        Dim p_Arr() As DataRow
        Dim p_String As String
        Dim p_UserName As String = ""
        Try



            g_PathXML = Windows.Forms.Application.StartupPath & "\Config.xml"
            If Dir(g_PathXML) <> "" Then
                p_DataSet.ReadXml(g_PathXML)
                If Not p_DataSet Is Nothing Then
                    If p_DataSet.Tables.Count > 0 Then
                        g_Config_XMLDatatable = p_DataSet.Tables(0)
                        Try
                            ' p_Arr = g_Config_XMLDatatable.Select("")
                            p_UserName = g_Config_XMLDatatable(0).Item("DB_USER").ToString.Trim
                            For p_Count = 0 To g_Config_XMLDatatable.Columns.Count - 1
                                p_Name = UCase(g_Config_XMLDatatable.Columns.Item(p_Count).ColumnName)
                                p_Control = Me.Controls.Find(p_Name, True)

                                If Not p_Control Is Nothing Then
                                    If p_Control.Length > 0 Then

                                        p_EditText = CType(p_Control(0), U_TextBox.U_TextBox)
                                        If UCase(p_Name) = "DB_PASS" Then
                                            p_String = g_Config_XMLDatatable.Rows(0).Item(p_Count).ToString.Trim
                                            p_String = mdlCryptor_Decrypt(p_String, p_UserName)
                                            ' ElseIf UCase(p_Name) = "DB_USER" Then
                                            ' p_EditText.EditValue = p_String
                                        Else
                                            p_EditText.EditValue = g_Config_XMLDatatable.Rows(0).Item(p_Count).ToString.Trim
                                        End If
                                        'p_EditText.EditValue = g_Config_XMLDatatable.Rows(0).Item(p_Count).ToString.Trim
                                    End If

                                End If

                            Next

                        Catch ex As Exception
                            ' MsgBox(ex.Message)
                        End Try
                        ' g_Config_XMLDatatable.WriteXml(p_PathXML)
                    End If
                Else

                End If
                '
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub SaveToXML()
        Dim p_Count As Integer
        Dim p_Name As String
        Dim p_Control() As Windows.Forms.Control
        Dim p_EditText As U_TextBox.U_TextBox

        Dim e2md5 As New Encrypt2MD5()

        Dim p_StringPass As String
        Dim p_User As String

        p_StringPass = Me.DB_PASS.EditValue.ToString.Trim
        p_User = Me.DB_USER.EditValue.ToString.Trim

        p_StringPass = mdlCryptor_Encrypt(p_StringPass, p_User)

        ' p_StringPass = e2md5.Encrypt(p_StringPass)

        For p_Count = 0 To g_Config_XMLDatatable.Columns.Count - 1
            p_Name = UCase(g_Config_XMLDatatable.Columns.Item(p_Count).ColumnName)
            p_Control = Me.Controls.Find(p_Name, True)

            If Not p_Control Is Nothing Then
                If p_Control.Length > 0 Then
                    p_EditText = CType(p_Control(0), U_TextBox.U_TextBox)
                    If Not p_EditText Is Nothing Then
                        Try
                            If UCase(p_Name) = "DB_PASS" Then
                                g_Config_XMLDatatable.Rows(0).Item(p_Count) = p_StringPass
                            Else

                                g_Config_XMLDatatable.Rows(0).Item(p_Count) = p_EditText.EditValue.ToString.Trim
                            End If

                        Catch ex As Exception

                        End Try

                    End If

                End If

            End If

        Next
        If g_Config_XMLDatatable.Rows.Count > 0 Then
            Try
                g_Config_XMLDatatable.WriteXml(g_PathXML)
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_DataTable As New DataTable
        Dim p_SQL As String
        Dim p_desc As String = ""
        Dim p_ConStr As String
        Dim p_Connect As New OleDb.OleDbConnection

        'p_SQL = "select top 1 USER_ID from SYS_USER "

        Try


            If Me.DB_PORT.Text.ToString.Trim = "" Then
                p_ConStr = "Provider=SQLOLEDB;Data Source=" & Me.DB_IPADDRESS.EditValue.ToString.Trim & ";Persist Security Info=True;User ID=" & _
                    Me.DB_USER.EditValue.ToString.Trim & ";Password=" & Me.DB_PASS.EditValue.ToString.Trim & _
                    ";Initial Catalog=" & Me.DB_NAME.EditValue.ToString.Trim & ";Connect Timeout=300"
            Else
                p_ConStr = "Provider=SQLOLEDB;Server=" & Me.DB_IPADDRESS.EditValue.ToString.Trim & "," & Me.DB_PORT.EditValue.ToString.Trim & ";" & _
                        "Database=" & Me.DB_NAME.EditValue.ToString.Trim & ";User ID=" & Me.DB_USER.EditValue.ToString.Trim & ";Password=" & Me.DB_PASS.EditValue.ToString.Trim & ";" & _
                        "Trusted_Connection=False;Connect Timeout=300"
            End If

            Try
                p_Connect.ConnectionString = p_ConStr
                p_Connect.Open()
                p_Connect.Close()
                p_Connect.Dispose()
                SaveToXML()
                MsgBox("Kết nối thành công", MsgBoxStyle.Information, "Thông báo")
                'Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi kết nối đến máy chủ", MsgBoxStyle.Critical, "Thông báo")
            End Try



        Catch ex As Exception
            MsgBox("Lỗi kết nối đến máy chủ")
        End Try
    End Sub

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click
        Hide()
    End Sub
End Class