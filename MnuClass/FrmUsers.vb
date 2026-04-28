Imports System.Security.Cryptography
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraEditors
Public Class FrmUsers

    Public p_FormQL As Object = Nothing
    Private p_ShowApp3000 As Boolean = False

    Sub save()
        Dim p_Value As Boolean = False
        Dim p_Mess_Done As String = ""
        Dim p_Mess_Err As String = ""
        Dim p_Des As String = ""
        Dim p_Header_Ins As Boolean
        Dim p_Done As String

        Dim encoder As New System.Text.UTF8Encoding()
        Dim p_PassStr_Arr As Byte()
        Dim p_PassStr As String
        Dim md5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim p_ENCRYPTED_USER_PASSWORD As String
        Dim p_ArRow() As DataRow
        Dim p_DataRow As DataRow
        Dim p_Pass As String = ""
        Dim p_Repass As String = ""

        Dim p_Row As DataRow

        Dim p_FromDate As Date = DateAdd(DateInterval.Day, -15, Now.Date)
        Dim p_ToDate As Date = DateAdd(DateInterval.Day, 15, Now.Date)

        'If Me.g_FormAddnew = False Then
        '    GoTo Line_TT
        'End If

        p_ENCRYPTED_USER_PASSWORD = ""
        If Not Me.PassWord.EditValue Is Nothing Then
            p_Pass = Me.PassWord.EditValue
        End If

        If Not Me.RePassWord.EditValue Is Nothing Then
            p_Repass = Me.RePassWord.EditValue
        End If
        If Not Me.ENCRYPTED_USER_PASSWORD.EditValue Is Nothing Then
            p_ENCRYPTED_USER_PASSWORD = Me.ENCRYPTED_USER_PASSWORD.Text.ToString
        End If
        '
        'If Me.PassWord.EditValue Is Nothing Or Me.RePassWord.EditValue Is Nothing Then
        'Else
        If p_Pass <> "" Or p_Repass <> "" Then
            ' If pv_Passchange = True Then
            Try
                If p_Pass.Trim <> p_Repass.Trim Then
                    MsgBox("Mật khẩu không hợp lệ hoặc không giống nhau", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    'ENCRYPTED_USER_PASSWORD
                    Using myRijndael = Rijndael.Create()
                        p_PassStr_Arr = md5Hasher.ComputeHash(encoder.GetBytes(p_Pass))
                        p_PassStr = Convert.ToBase64String(p_PassStr_Arr)
                        p_ENCRYPTED_USER_PASSWORD = p_PassStr
                        Me.ENCRYPTED_USER_PASSWORD.EditValue = p_ENCRYPTED_USER_PASSWORD
                        p_ArRow = pv_TableEdit.Select("TableEdit='" & Me.HeaderSource & "'")
                        If p_ArRow.Length <= 0 Then
                            p_DataRow = pv_TableEdit.NewRow
                            p_DataRow.Item(0) = Me.HeaderSource
                            pv_TableEdit.Rows.Add(p_DataRow)
                        End If
                    End Using
                End If
            Catch ex As Exception
                MsgBox("Mật khẩu không hợp lệ hoặc không giống nhau", MsgBoxStyle.Critical)
                Exit Sub
            End Try
        End If
        ' End If
        If p_ENCRYPTED_USER_PASSWORD = "" And p_Pass = "" Then
            MsgBox("Bạn chưa nhập mật khẩu")
            Exit Sub
        End If
Line_TT:

        If Not Me.U_DateEdit3.EditValue Is Nothing Then
            If Me.U_DateEdit3.EditValue.ToString.Trim <> "" Then
                p_FromDate = Me.U_DateEdit3.EditValue
            End If
        End If


        If Not Me.U_DateEdit1.EditValue Is Nothing Then
            If Me.U_DateEdit1.EditValue.ToString.Trim <> "" Then
                p_ToDate = Me.U_DateEdit1.EditValue
            End If
        End If

        If p_FromDate > p_ToDate Then
            MsgBox("Ngày hiệu lực phải <= Ngày hết hiệu lực")
            Exit Sub
        End If

        Me.DefaultSave = True
        '  Me.Update()
        UpdateToDatabase(Me, "")
        Me.DefaultSave = False

        If Not p_FormQL Is Nothing Then
            p_FormQL.DefaultFormLoad = True
            p_FormQL.XtraForm1_Load()
            p_FormQL.DefaultFormLoad = False
        End If

        ' e.Handled = True
    End Sub
    Private Sub FrmUsers_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'Dim p_Value As Boolean = False
        'Dim p_Mess_Done As String = ""
        'Dim p_Mess_Err As String = ""
        'Dim p_Des As String = ""
        'Dim p_Header_Ins As Boolean
        'Dim p_Done As String
        'Dim p_ArRow() As DataRow
        'Dim p_DataRow As DataRow

        'Dim encoder As New System.Text.UTF8Encoding()
        'Dim p_PassStr_Arr As Byte()
        'Dim p_PassStr As String
        'Dim md5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider()
        'Dim p_ENCRYPTED_USER_PASSWORD As String

        'Dim p_Pass As String = ""
        'Dim p_Repass As String = ""



        If Asc(e.KeyChar) = 19 Then
            'Exit Sub
            save()
        End If
        'p_ENCRYPTED_USER_PASSWORD = ""
        'If Not Me.PassWord.EditValue Is Nothing Then
        '    p_Pass = Me.PassWord.EditValue
        'End If

        'If Not Me.RePassWord.EditValue Is Nothing Then
        '    p_Repass = Me.RePassWord.EditValue
        'End If
        'If Not Me.ENCRYPTED_USER_PASSWORD.EditValue Is Nothing Then
        '    p_ENCRYPTED_USER_PASSWORD = Me.ENCRYPTED_USER_PASSWORD.Text.ToString
        'End If
        ''
        ''If Me.PassWord.EditValue Is Nothing Or Me.RePassWord.EditValue Is Nothing Then
        ''Else
        'If p_Pass <> "" Or p_Repass <> "" Then
        '    ' If pv_Passchange = True Then
        '    Try
        '        If p_Pass.Trim <> p_Repass.Trim Then
        '            MsgBox("Mật khẩu không hợp lệ hoặc không giống nhau", MsgBoxStyle.Critical)
        '            Exit Sub
        '        Else
        '            'ENCRYPTED_USER_PASSWORD
        '            Using myRijndael = Rijndael.Create()
        '                p_PassStr_Arr = md5Hasher.ComputeHash(encoder.GetBytes(p_Pass))
        '                p_PassStr = Convert.ToBase64String(p_PassStr_Arr)
        '                p_ENCRYPTED_USER_PASSWORD = p_PassStr
        '                Me.ENCRYPTED_USER_PASSWORD.EditValue = p_ENCRYPTED_USER_PASSWORD
        '                p_ArRow = pv_TableEdit.Select("TableEdit='" & Me.HeaderSource & "'")
        '                If p_ArRow.Length <= 0 Then
        '                    p_DataRow = pv_TableEdit.NewRow
        '                    p_DataRow.Item(0) = Me.HeaderSource
        '                    pv_TableEdit.Rows.Add(p_DataRow)
        '                End If
        '            End Using
        '        End If
        '    Catch ex As Exception
        '        MsgBox("Mật khẩu không hợp lệ hoặc không giống nhau", MsgBoxStyle.Critical)
        '        Exit Sub
        '    End Try
        'End If
        '' End If
        'If p_ENCRYPTED_USER_PASSWORD = "" And p_Pass = "" Then
        '    MsgBox("Bạn chưa nhập mật khẩu")
        '    Exit Sub
        'End If

        'Me.DefaultSave = True
        ''  Me.Update()
        'UpdateToDatabase(Me, Me.ButtonSave)
        'Me.DefaultSave = False
        'e.Handled = True
    End Sub



    Private Sub FrmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FUNCTION_NAME.SQLString = "select  bb.DESCRIPTION as [Tên chức năng], aa.FUNCTION_ID from SYS_RESPONSIBILITY_MENU AA, SYS_FUNCTION BB " & _
                 "where aa.MENU_CODE  in (select b.MENU_CODE from SYS_USER_RESPONDS A, SYS_MENU b where USER_ID=:USER_ID " & _
                 "and a.MENU_ID=b.Menu_ID) and ISNULL(aa.submenu,'')='' " & _
                 "and AA.FUNCTION_ID=BB.FUNCTION_ID " & _
                 "and not exists (select  1 from SYS_USER_MENU_EXP CC where USER_ID=:USER_ID and cc.FUNCTION_ID=AA.FUNCTION_ID ) " & _
                "union " & _
                "select  bb.DESCRIPTION, aa.FUNCTION_ID as [Mã] from dbo.SYS_RESPONSIBILITY_MENU AA, SYS_FUNCTION BB " & _
             "where aa.MENU_CODE  in ( " & _
           "select submenu from dbo.SYS_RESPONSIBILITY_MENU AA " & _
        "where aa.MENU_CODE  in (select b.MENU_CODE from SYS_USER_RESPONDS A, SYS_MENU b where USER_ID=:USER_ID " & _
        "and a.MENU_ID=b.Menu_ID) and ISNULL(aa.submenu,'')<>'') and AA.FUNCTION_ID=BB.FUNCTION_ID " & _
                    "and not exists (select  1 from SYS_USER_MENU_EXP CC where USER_ID=:USER_ID and cc.FUNCTION_ID=AA.FUNCTION_ID )	"
        ' Me.FormStatus = True

        Dim p_Table As DataTable
        Dim p_SQL As String

        Me.ReportGroup.Visible = False
        Me.LabelControl7.Visible = False


        p_SQL = "select * from sys_config where upper(KeyCode)='" & UCase("GROUPREPORT") & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    'p_ShowApp3000 = True
                    Me.ReportGroup.Visible = True
                    Me.LabelControl7.Visible = True
                End If
            End If
        End If

        Me.NhomBeXuat.Visible = False
        Me.BeXuat.Visible = False
        p_SQL = "select * from sys_config where upper(KeyCode)='" & UCase("TANK_GROUP") & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    'p_ShowApp3000 = True
                    Me.NhomBeXuat.Visible = True
                    Me.BeXuat.Visible = True
                End If
            End If
        End If


        p_SQL = "select * from sys_config where upper(KeyCode)='" & UCase("TANKAPPROVED") & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    'p_ShowApp3000 = True
                    ' Me.ReportGroup.Visible = True
                    ' Me.LabelControl7.Visible = True
                    Me.Tank_App.Visible = True
                End If
            End If
        End If

        p_SQL = "select * from sys_config where upper(KeyCode)='" & UCase("ShowApp3000") & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    p_ShowApp3000 = True
                End If
            End If
        End If

        If g_FormAddnew = True Then
            Dim p_Date As Date = Nothing
            Dim p_Time As Integer
            p_GetDateTime(p_Date, p_Time)
            U_DateEdit3.EditValue = p_Date
            Me.USER_NAME.Focus()
        End If

        If g_Company_Code = "6610" Or p_ShowApp3000 = True Then
            Me.App3000.Visible = True
        End If

    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub U_CheckBox11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles App_Grid.CheckedChanged

    End Sub

    Private Sub Navigator1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Navigator1.Click
        
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        save()
    End Sub

    Private Sub USER_NAME_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USER_NAME.EditValueChanged

    End Sub

    Private Sub USER_NAME_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles USER_NAME.EditValueChanging
        Dim p_Date As Date = Nothing
        Dim p_Time As Integer
        Dim p_Check As Boolean = False

        If Not U_DateEdit3.EditValue Is Nothing Then
            p_Check = True
        End If
        If p_Check = False Then
            p_GetDateTime(p_Date, p_Time)
            U_DateEdit3.EditValue = p_Date
        End If
    End Sub
   
    Private Sub PassWord_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PassWord.EditValueChanged

    End Sub

    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click
        Dim p_UserID As Integer
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_DataSet As New DataSet
        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        Dim p_FormRoll As New FrmCopyRoll
        Dim p_Control() As Object
        Dim p_ItemName As String
        Dim p_Count As Integer
        Dim p_CountCol As Integer
        Dim p_DataRowArr() As DataRow
        Dim p_DataRow As DataRow
        p_FormRoll.p_XtraModuleObj = Me.p_XtraModuleObj
        p_FormRoll.ShowDialog(Me)
        p_UserID = p_FormRoll.p_USerID

        If p_UserID = 0 Then

            MsgBox("User không xác định")
        Else
            p_ValueMess = p_XtraModuleObj.ShowMessage(Me, "", _
                       "Bạn có chắc chắn muốn thực hiện không? ", _
                       True, _
                        "Có", _
                       True, _
                       "Không", _
                       False, _
                       "", _
                        0)
            If p_ValueMess = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            p_SQL = "exec FPT_CopyRollUser " & p_UserID

            p_DataSet = GetDataSet(p_SQL, p_SQL)
            If Not p_DataSet Is Nothing Then
                If p_DataSet.Tables.Count > 0 Then
                    p_DataTable = p_DataSet.Tables(0)
                    For p_Count = 0 To p_DataTable.Columns.Count - 1
                        p_ItemName = p_DataTable.Columns(p_Count).ColumnName.ToString.Trim
                        p_Control = Me.Controls.Find(p_ItemName, True)
                        If p_Control.Length > 0 Then
                            If InStr(UCase(p_Control(0).GetType.ToString), ".U_CHECKBOX", CompareMethod.Text) > 0 Then
                                If p_DataTable.Rows(0).Item(p_ItemName).ToString.Trim = "Y" Then
                                    p_Control(0).Checked = True
                                Else
                                    p_Control(0).Checked = False
                                End If

                            Else
                                p_Control(0).editvalue = p_DataTable.Rows(0).Item(p_ItemName).ToString.Trim
                            End If
                        End If
                    Next

                    p_DataTable = p_DataSet.Tables(1)
                    For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
                        GridView1.MoveLast()
                        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.DoClick(Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove)
                    Next

                    For p_Count = 0 To p_DataTable.Rows.Count - 1
                        GridView1.AddNewRow()
                        For p_CountCol = 0 To p_DataTable.Columns.Count - 1
                            If p_DataTable.Rows(p_Count).Item(p_CountCol).ToString.Trim <> "" Then
                                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, p_DataTable.Columns.Item(p_CountCol).ColumnName.ToString.Trim, _
                                                       p_DataTable.Rows(p_Count).Item(p_CountCol).ToString.Trim)
                            End If

                        Next

                    Next

                    p_DataTable = p_DataSet.Tables(2)
                    For p_Count = Me.GridView2.RowCount - 1 To 0 Step -1
                        GridView2.MoveLast()
                        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.DoClick(Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove)
                    Next

                    For p_Count = 0 To p_DataTable.Rows.Count - 1
                        GridView2.AddNewRow()
                        For p_CountCol = 0 To p_DataTable.Columns.Count - 1
                            If p_DataTable.Rows(p_Count).Item(p_CountCol).ToString.Trim <> "" Then
                                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, p_DataTable.Columns.Item(p_CountCol).ColumnName.ToString.Trim, _
                                                       p_DataTable.Rows(p_Count).Item(p_CountCol).ToString.Trim)
                            End If

                        Next

                    Next

                    ' If p_Control.tablename.ToString.Trim <> "" Then
                    p_DataRowArr = Me.pv_TableEdit.Select("TableEdit='SYS_USER'")
                    If p_DataRowArr.Length <= 0 Then
                        p_DataRow = Me.pv_TableEdit.NewRow
                        p_DataRow.Item(0) = "SYS_USER"
                        Me.pv_TableEdit.Rows.Add(p_DataRow)
                    End If

                    'End If

                End If
        End If
        End If
        Me.GridView1.BestFitColumns()
        Me.GridView2.BestFitColumns()

    End Sub

    Private Sub MaPhuongTien_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ReportGroup.ButtonClick
        Dim p_Form As New FrmReportGrp
        p_Form.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        p_Form.g_XtraServicesObj = g_XtraServicesObj

        p_Form.p_XtraToolTripLabel = g_ToolStripStatus
        p_Form.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        p_Form.p_XtraMessageStatusl = g_MessageStatus
        If Not Me.ReportGroup.EditValue Is Nothing Then
            p_Form.g_RptGroup = Me.ReportGroup.EditValue.ToString.Trim
        End If

        p_Form.ShowDialog(Me)

        Me.ReportGroup.EditValue = p_Form.g_RptGroup
    End Sub

    Private Sub MaPhuongTien_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles ReportGroup.EditValueChanged

    End Sub
End Class
