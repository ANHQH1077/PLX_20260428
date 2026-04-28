Imports System.Windows.Forms
Imports System.Reflection

Public Class XtraCusForm1
    Public g_XtraServicesObj As Object = Nothing
    Public p_XtraModuleObj As Object = Nothing
    Public p_XtraUserName As String = ""
    Public p_XtraComCode As String = ""
    'Public p_FptSericeObj As Object
    Public p_XtraDataSet_TrueGird As DataSet = Nothing
    ' Public p_XtraBindingSourceHeader As New System.Windows.Forms.BindingSource
    Public p_XtraPageNum As Integer
    Public g_XtraParameterArray(0 To 20) As String
    Public p_XtraToolTripLabel As New System.Windows.Forms.ToolStripStatusLabel
    Public p_XtraMessageStatusl As New System.Windows.Forms.ToolStripStatusLabel

    ' Public p_XtraMenuIcon As ToolStrip


    Public g_XtraFunctionID As Integer
    Public g_FormLoad As Boolean = False

    Public g_RecodeMove As Boolean = False

    Public g_FormAddnew As Boolean = False

    'Private p_TrueGirdLineAdd2(0 To 2000) As Boolean  'Dung mảng để lưu các line number trong TrueGrid khi thêm bản ghi
    'Private p_TrueGirdLineUpd2(0 To 2000) As Boolean  'Dung mảng để lưu các line number trong TrueGrid khi update bản ghi
    'Private p_TrueGirdLineDel2(0 To 2000) As String   'Dung mảng để lưu gia tri trong TrueGrid khi delete bản ghi
    '=====================================================

    Public g_ObjectUpdateIsNull(0 To 100) As String

    Public g_ObjectUpdateIsNullColor(0 To 100) As System.Drawing.Color

    Private p_GridViewUpdateValue As Boolean = False

    Public pv_Back_Color As System.Drawing.Color = System.Drawing.Color.White
    Public pv_Required_Back_Color As System.Drawing.Color = System.Drawing.Color.LightGoldenrodYellow
    Public pv_Locked_Back_Color As System.Drawing.Color = System.Drawing.Color.LightGray '   System.Drawing.Color.LightCyan

    Public pv_LineRemove As New DataTable("Table01")
    Public pv_TableEdit As New DataTable("Table01")
    Public pv_GridViewEdit As New DataTable("Table01")


    Public Sub SetValueType()
        g_ValueType = 0
    End Sub

    Private Sub XtraCusForm1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        'Dim p_Object As Object
        '' Exit Sub       
        ''Me.Owner.Controls.Item(g_OwnerMenuStrip.Name).Dock = DockStyle.Top
        ''  Me.Owner.Controls.Item("ToolStrip1").Location = New System.Drawing.Point(0, 24)       

        'If Me.MenuEdit = False And Me.MenuNavigator = False Then
        '    Me.Location = New System.Drawing.Point(0, 48)
        '    Exit Sub
        'Else
        '    If Me.Owner.Controls.Item(UCase(Me.ProductName & "_" & Me.Name)).Created = True Then
        '        ' p_Object = Me.Owner.Controls.Find(UCase(Me.ProductName & "_" & Me.Name), True)
        '        p_Object = Me.Owner.Controls.Item(UCase(Me.ProductName & "_" & Me.Name))
        '        ' If p_Object.Length > 0 Then
        '        If p_Object.visible = False Then
        '            Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).Visible = True
        '            Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).Dock = DockStyle.None
        '            Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).Location = New System.Drawing.Point(0, 25)
        '            '   Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).Width = Me.Owner.Controls.Item(g_OwnerMenuStrip.Name).Width
        '            SendBackForm(Me.Name.ToString.Trim, Me.Top, True)
        '            ' Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).TabStop = True
        '            Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).Show()
        '            'Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).Select()
        '        Else
        '            SendBackForm(Me.Name.ToString.Trim, Me.Top, True)
        '            Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).Show()
        '            'Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).Select()
        '        End If
        '        If Me.StartPosition = FormStartPosition.CenterScreen Or Me.StartPosition = FormStartPosition.CenterParent Then
        '        Else
        '            Me.Location = New System.Drawing.Point(0, 72)
        '        End If
        '        'Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).MaximumSize.Wid = Me.Owner.Controls.Item("ToolStrip1").Width
        '        '  Me.Location = New System.Drawing.Point(0, 72)
        '        'Me.Owner.Controls.Item(Me.ProductName & "_" & Me.Name).Dock = DockStyle.Top
        '        'End If
        '    End If

        'End If

        g_Form = Me
    End Sub


    Private Sub SetMenuEdit()
        Dim p_MenuName As String = ""
        CreateIconMenu(Me.Owner, UCase(Me.ProductName.ToString.Trim), UCase(Me.Name.ToString.Trim))
        'If Me.MenuEdit = True And Not p_XtraMenuIcon Is Nothing Then

        '    p_MenuName = UCase(Me.ProductName & "_" & Me.Name)
        '    If p_XtraMenuIcon.Name <> p_MenuName Then
        '        p_XtraMenuIcon.Name = p_MenuName

        '    Else
        '        SetmenuIcon(Me.FormStatus)
        '    End If
        'End If
    End Sub

    Public Sub SetmenuIcon(ByVal p_FormStatus As Boolean)
        Dim p_MenuEdit As ToolStrip
        Exit Sub
        If Me.Owner.Controls.Item(UCase(Me.ProductName & "_" & Me.Name)).Created = True Then
            p_MenuEdit = Me.Owner.Controls.Item(UCase(Me.ProductName & "_" & Me.Name))
            If p_FormStatus = True Then
                p_MenuEdit.Items.Item("mnuAdd").Enabled = False
                p_MenuEdit.Items.Item("mnuSave").Enabled = True
                p_MenuEdit.Items.Item("mnuCancel").Enabled = True
                p_MenuEdit.Items.Item("mnuRemove").Enabled = False
            Else
                p_MenuEdit.Items.Item("mnuAdd").Enabled = True
                p_MenuEdit.Items.Item("mnuSave").Enabled = False
                p_MenuEdit.Items.Item("mnuCancel").Enabled = False
                p_MenuEdit.Items.Item("mnuRemove").Enabled = True
            End If
        End If
    End Sub

    Private Sub XtraCusForm1_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CursorChanged

    End Sub

    Private Sub XtraForm1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim p_Value As Integer
        'If Me.FormStatus = True Then
        '    If Me.DefaultSave = False Then
        '        Exit Sub
        '    End If

        '    p_Value = p_XtraModuleObj.ShowMessage(Me,
        '                               "",
        '            "Thông tin chưa được lưu. Bạn có muốn lưu lại không?",
        '            True,
        '            "Có",
        '            True,
        '            "Không",
        '             True,
        '            "Hủy",
        '           2)
        '    Select Case p_Value
        '        Case 2 'Cancel
        '            e.Cancel = True
        '            Exit Sub
        '        Case 7  'No
        '            g_LineRemove.Clear()
        '            pv_LineRemove.Clear()
        '            pv_TableEdit.Clear()
        '        Case 6    'Yes
        '            'If Me.DefaultSave = False Then
        '            Me.DefaultSave = True
        '            ' End If
        '            UpdateToDatabase(Me, Me.ButtonSave.ToString.Trim)


        '            Me.DefaultSave = False
        '    End Select
        'End If

        '' Dim p_MenuIcon As ToolStrip
        ''Dim p_Count As Integer
        ''  Dim p_OwnerForm As Form
        ''Dim p_MenuIconArr() As ToolStrip
        ''Dim p_MenuIconIndex As ToolStripButton
        ''Dim p_Top As Integer

        'Dim p_form As New Form
        'Dim p_Object As Object

        '' Dim p_MenuArr() As Object
        ''Dim p_Count As Integer
        'Dim p_MenuName As String
        'p_Object = Me.Owner
        'Dim p_MenuObj() As Object
        'If Not p_Object Is Nothing Then
        '    'p_form = CType(p_form, Form)
        '    Try
        '        p_MenuName = UCase(Me.ProductName & "_" & Me.Name)
        '        p_MenuObj = p_Object.Controls.Find(p_MenuName, True)
        '        If p_MenuObj.Length > 0 Then
        '            p_Object.Controls.RemoveByKey(p_MenuObj(0).name)
        '            'p_form.Controls.RemoveByKey()
        '        End If



        '    Catch ex As Exception

        '    End Try

        'End If

    End Sub

    Public Sub Edit_Button_Click(ByVal p_Item As Object, _
                                        ByRef p_RptForm As Object, _
                                        ByRef p_Commit1 As Boolean, _
                                        ByRef p_ButtonOK As Object, _
                                        ByVal p_CaptionUpd As String, Optional ByVal p_FormList As Boolean = False)
        p_XtraModuleObj.p_Mod_Edit_Button_Click(p_Item, p_RptForm, p_Commit1, p_ButtonOK, p_CaptionUpd, p_FormList)
    End Sub


    Public Sub LoadDataToForm()
        Dim p_Where As String = ""
        'Dim p_Page_Total As Integer
        'Dim P_Databale As DataTable
        'Dim p_Desc As String
        'Dim p_SQL As String
        Try
            ' If Me.DefaultFormLoad = True Then Exit Sub
            g_LineRemove.Clear()
            pv_LineRemove.Clear()
            pv_TableEdit.Clear()


            g_FormLoad = True
            ' If p_XtraModuleObj Is Nothing Then Exit Sub

            If g_XtraServicesObj Is Nothing Then Exit Sub

            g_Service = g_XtraServicesObj
            g_Module = p_XtraModuleObj


            If ModSet_BindSource_ForForm(Me) = False Then
                'MsgBox("Lỗi khi mở Form")
                p_XtraModuleObj.ModErrExceptionNew("", "Lỗi khi mở Form")
                g_FormLoad = False
                Exit Sub
            Else

            End If






            g_FormLoad = False '
        Catch ex As Exception
            ' MsgBox(ex.Message)
            p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
            g_FormLoad = False
        End Try


        'If p_FptModule.p_ModControl_UpdateIfNull(Me, False) = False Then
        '    MsgBox("Lỗi khi thực hiện")
        'End If



    End Sub

    Private Sub XtraCusForm1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            '  MsgBox(Asc(e.KeyChar))

            Me.Update()
            UpdateToDatabase(Me, Me.ButtonSave)
            e.Handled = True
            Exit Sub
        End If

        If Asc(e.KeyChar) = 27 Then
            'Me.Close()
            Try
                Me.Close()
            Catch ex As Exception

            End Try

        End If
        If Me.EnterNextControl = True Then
            Try
                If Asc(e.KeyChar) = 13 Then
                    Dim ctl As Control
                    ctl = CType(sender, Control)
                    ctl.SelectNextControl(ActiveControl, True, True, True, True)
                End If
            Catch ex As Exception

            End Try
            
        End If
       

    End Sub


    Public Sub UpdateToDatabase(ByRef p_Form As Object, Optional ByVal p_BtnSave As String = "")

        If Me.FormStatus = True Then
            If Me.DefaultSave = True Then

                Me.U_Focus.Focus()
                'Me.GridView2.RefreshData()
                '  GridView2.SetFocusedRowModified()
                'GridView2.UpdateCurrentRow()
                'GridView2.RefreshEditor(True)
                Me.Focus()


                Cursor = Cursors.WaitCursor
                p_UpdateToDatabase(Me, Me.ButtonSave)
                Cursor = Cursors.Default
            End If
        End If


        'ModSet_BindSource_ForForm(Me, True)
        ' LockObjectIsNull()
    End Sub


    Private Sub GetParameter()
        Dim TypeOfMe As Type = Me.GetType()
        Dim p_VariableName As String = ""
        Dim p_VariableValue As String = ""
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_Para As String = ""
        Dim p_ArrPara() As String

        Dim p_Parameter() As String
        Dim p_Count As Integer
        Dim Field As FieldInfo

        Dim p_Double As Double
        Dim p_Integer As Integer
        Dim p_String As String
        Dim p_Date As Date
        Dim p_Boolean As Boolean


        Dim p_FormName As String
        If g_XtraServicesObj Is Nothing Then
            Exit Sub
        End If
        ' Dim Field As FieldInfo = TypeOfMe.GetField(p_VariableName, BindingFlags.NonPublic Or BindingFlags.Instance)
        p_SQL = "select * from sys_function where isnull(ParValue,'-99') <>'-99' and ParValue <>'' and  Function_ID=" & g_XtraFunctionID
        p_DataTable = g_XtraServicesObj.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_Para = p_DataTable.Rows(0).Item("ParValue").ToString.Trim
            End If
        End If
        If p_Para <> "" Then
            p_ArrPara = Split(p_Para, " ", -1, CompareMethod.Binary)
        Else
            Exit Sub
        End If
        If p_ArrPara Is Nothing Then
            Exit Sub
        End If
        For p_Count = 0 To p_ArrPara.Length - 1
            p_Parameter = Split(p_ArrPara(p_Count), "=", -1, CompareMethod.Binary)
            If p_Parameter.Length > 1 Then
                p_VariableName = p_Parameter(0)
                p_VariableValue = p_Parameter(1)
                Try
                    'Field = TypeOfMe.GetField(p_VariableName, BindingFlags.NonPublic Or BindingFlags.Instance)

                    Field = TypeOfMe.GetField(p_VariableName, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetProperty _
                                                 Or BindingFlags.DeclaredOnly Or BindingFlags.Public)
                    If Not Field Is Nothing Then
                        If UCase(Field.FieldType.Name.ToString) = "STRING" Then
                            Field.SetValue(Me, p_VariableValue)
                        ElseIf UCase(Field.FieldType.Name.ToString) = "DOUBLE" Then
                            Double.TryParse(p_VariableValue.ToString.Trim, p_Double)
                            Field.SetValue(Me, p_Double)
                        ElseIf UCase(Field.FieldType.Name.ToString) = "BOOLEAN" Then
                            Boolean.TryParse(p_VariableValue.ToString.Trim, p_Boolean)
                            Field.SetValue(Me, p_Boolean)
                        ElseIf UCase(Field.FieldType.Name.ToString) = "INT32" Then
                            Integer.TryParse(p_VariableValue.ToString.Trim, p_Integer)
                            Field.SetValue(Me, p_Integer)
                        ElseIf UCase(Field.FieldType.Name.ToString) = "DATETIME" Then
                            'Date.TryParse("", p_Date)
                            Date.TryParse(p_VariableValue.ToString.Trim, p_Date)
                            Field.SetValue(Me, p_Date)
                        End If

                        'If Not Field Is Nothing Then
                        '    Field.SetValue(Me, p_VariableValue)
                        'End If
                    End If
                Catch ex As Exception
                    ShowMessageBox("", ex.Message)
                End Try

            End If
        Next

        'set the value of that field, on the object "Me".
        '<


    End Sub

    Public Sub GetSourceCombobox(ByVal p_Form As Form, _
                                     ByRef p_Item As U_TextBox.U_Combobox, _
                                     Optional ByVal b1_Get As Boolean = False)
        If p_Set_Combo_PropertyNew(p_Form, p_Item, p_GetB1) = False Then
            Exit Sub
        Else

        End If
    End Sub

    Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.ShowFormMessage = True Then
            Me.cusStatusStrip1.Visible = True
            Me.cusStatusLabel1.Text = ""
            Me.Timer1.Interval = 1000
            Me.Timer1.Enabled = True
        End If




        Try
            g_DBTYPE = ""
            g_XtraServicesObj.Sys_GetParameterOracle(g_DBTYPE)
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

        GetParameter()

        If pv_TableEdit.Columns.Count <= 0 Then
            pv_TableEdit.Columns.Add("TableEdit", GetType(String))
        End If
        If Not Me.Owner Is Nothing Then
            If Not Me.Owner.MainMenuStrip Is Nothing Then
                g_OwnerMenuStrip = Me.Owner.MainMenuStrip
            End If
        End If

        'Dim p_OwnerForm As Object
        'p_OwnerForm = Me.Owner



        pv_TableEdit.Clear()
        g_LineRemove.Clear()
        pv_LineRemove.Clear()
        If Me.DefaultFormLoad = True Then
            XtraForm1_Load()
        End If
        If Me.StartPosition = FormStartPosition.Manual Then
            Me.Location = New System.Drawing.Point(0, 50)
        End If
        ' CreateFormMenu(Me, Me.ProductName, Me.Name)
        'SetMenuEdit()
        ' g_XtraServicesObj.Sys_GetParameterOracle(g_DBTYPE)
    End Sub



    Private Sub SaveStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles ToolStripButton1.Click

        StripButton1_Click("SAVE", sender.owner.name)
    End Sub

    Private Sub AddStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles ToolStripButton1.Click
        StripButton1_Click("NEW", sender.owner.name)
    End Sub

    Private Sub CancelStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles ToolStripButton1.Click
        StripButton1_Click("CANCEL", sender.owner.name)
    End Sub

    Private Sub DeleteStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles ToolStripButton1.Click
        StripButton1_Click("DELETE", sender.owner.name)
    End Sub




    Private Sub StripButton1_Click(ByVal p_Type As String, ByVal p_MenuIconName As String)
        Dim p_Form As U_CusForm.XtraCusForm1
        Dim p_NameForm As String

        p_NameForm = p_MenuIconName
        If InStr(p_NameForm, "_", CompareMethod.Text) <= 0 Then Exit Sub
        p_NameForm = Mid(p_NameForm, InStr(p_NameForm, "_", CompareMethod.Text) + 1)

        Dim frmCollection As New FormCollection()
        frmCollection = Application.OpenForms()
        Try
            If frmCollection.Item(p_NameForm).IsHandleCreated Then
                p_Form = frmCollection.Item(p_NameForm)
            Else

                ShowStatusMessage(True, "MS991", "Không xác định form cập nhật", g_TimeError)
                Exit Sub
            End If
        Catch ex As Exception
            ShowStatusMessage(True, "MS991", "Không xác định form cập nhật", g_TimeError)
            Exit Sub
        End Try



        Select Case p_Type
            Case "NEW"
                If p_BindingSourceAddNewRow() = False Then

                End If
            Case "SAVE"
                UpdateToDatabase(p_Form, "BtnOk")
            Case "DELETE"
                DeleteHeaderRecord(p_Form)
                DeleteRecord()
            Case "CANCEL"
                FormCancelEdit()
        End Select
    End Sub




    Private Sub CreateIconMenu(ByRef p_form As Object, ByVal p_Module As String, ByVal p_FormName As String)
        Dim p_MenuIcon As ToolStrip
        'Dim p_Count As Integer
        Dim p_OwnerForm As Form
        'Dim p_MenuIconArr() As ToolStrip
        Dim p_MenuIconIndex As ToolStripButton
        Dim p_Top As Integer
        ' Dim p_MainMenu As New MainMenu

        ' Dim p_MenuItem As New MenuItem
        Dim p_MenuCount As Integer = 0



        If p_form Is Nothing Then Exit Sub

        If Me.Owner Is Nothing Then
            p_OwnerForm = CType(p_form, Form)
        Else
            p_OwnerForm = Me.Owner ' CType(p_form, Form)
        End If
        If Not g_OwnerMenuStrip Is Nothing Then
            p_OwnerForm.Controls.Item(g_OwnerMenuStrip.Name).Dock = DockStyle.Top
        End If

        If Me.MenuEdit = False And Me.MenuNavigator = False Then
            If Me.StartPosition = FormStartPosition.CenterScreen Or Me.StartPosition = FormStartPosition.CenterParent Then
            Else
                Me.Location = New System.Drawing.Point(0, 48)
            End If
            ' Me.p_XtraMenuIcon.Visible = False
            Exit Sub
        End If




        '  Dim p_Count As Integer
        Dim p_PathIcon As String
        Dim p_Object() As Object


        ' p_OwnerForm.Controls.Item("ToolStrip1").

        p_Object = p_OwnerForm.Controls.Find(UCase(p_Module & "_" & p_FormName), True)

        If p_Object.Length > 0 Then
            p_MenuIcon = p_Object(0)
            p_MenuIcon.Visible = True
            If p_MenuIcon.Focused = False Then
                p_MenuIcon.BringToFront()
                p_MenuIcon.Select()

                If Me.StartPosition = FormStartPosition.CenterScreen Or Me.StartPosition = FormStartPosition.CenterParent Then
                Else
                    Me.Location = New System.Drawing.Point(0, 72)
                End If

            End If
            Exit Sub
        Else
            p_MenuIcon = New ToolStrip

        End If

        For Each p_MenuDisable In p_OwnerForm.Controls
            If InStr(UCase(p_MenuDisable.GetType.ToString.Trim), UCase(Me.ProductName.ToString.Trim), CompareMethod.Text) > 0 Then
                If UCase(p_MenuDisable.Name) <> UCase(p_Module & "_" & p_FormName) Then
                    p_MenuDisable.visible = False
                End If
            End If
        Next


        p_PathIcon = Application.StartupPath & "\Images"

        If p_MenuIcon.Name = UCase(p_Module & "_" & p_FormName) Then Exit Sub

        p_MenuIcon.Name = UCase(p_Module & "_" & p_FormName)


        '+++++++++++++++++++++++++++++++++++++++++++++++++++Tao Button navigator
        If Me.MenuNavigator = True Then

            p_MenuIconIndex = New ToolStripButton
            p_MenuIconIndex.Name = "mnuFirst"
            p_MenuIconIndex.Text = "|<<"
            p_MenuIconIndex.ToolTipText = "Bản ghi đầu"
            p_MenuIconIndex.Font = New Drawing.Font(Font.Name, 7, Drawing.FontStyle.Bold)
            '  p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\addnew1.jpg") ' = p_PathIcon & "\addnew.jpg"
            p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Text

            AddHandler p_MenuIconIndex.Click, AddressOf MenuNavigatorCilck

            p_MenuIcon.Items.Add(p_MenuIconIndex)



            p_MenuIconIndex = New ToolStripButton
            p_MenuIconIndex.Name = "mnuPreviuos"
            p_MenuIconIndex.Text = "<"
            p_MenuIconIndex.ToolTipText = "Bản ghi trước"
            p_MenuIconIndex.Font = New Drawing.Font(Font.Name, 7, Drawing.FontStyle.Bold)
            'p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\undo.jpg")
            p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Text
            AddHandler p_MenuIconIndex.Click, AddressOf MenuNavigatorCilck
            p_MenuIcon.Items.Add(p_MenuIconIndex)

            p_MenuIconIndex = New ToolStripButton
            p_MenuIconIndex.Name = "mnuNext"
            p_MenuIconIndex.Text = ">"
            p_MenuIconIndex.ToolTipText = "Bản ghi sau"
            p_MenuIconIndex.Font = New Drawing.Font(Font.Name, 7, Drawing.FontStyle.Bold)
            'p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\delete1.jpg")
            p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Text
            AddHandler p_MenuIconIndex.Click, AddressOf MenuNavigatorCilck
            p_MenuIcon.Items.Add(p_MenuIconIndex)



            p_MenuIconIndex = New ToolStripButton
            p_MenuIconIndex.Name = "mnuLast"
            p_MenuIconIndex.Text = ">>|"
            p_MenuIconIndex.ToolTipText = "Bản ghi cuối"
            p_MenuIconIndex.Font = New Drawing.Font(Font.Name, 7, Drawing.FontStyle.Bold)
            ' p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\delete1.jpg")
            p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Text
            AddHandler p_MenuIconIndex.Click, AddressOf MenuNavigatorCilck
            p_MenuIcon.Items.Add(p_MenuIconIndex)

            '+++++++++++++++++++++++++++++++++++++++++++++++++++



        End If
        '+++++++++++++++++++++++++++++++++++++++++++++++++++Tao Buttonedit 
        If Me.MenuEdit = True Then
            p_MenuIconIndex = New ToolStripButton
            p_MenuIconIndex.Name = "mnuAdd"
            p_MenuIconIndex.Text = "Thêm mới"
            p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\addnew1.jpg") ' = p_PathIcon & "\addnew.jpg"
            'p_MenuIconIndex.ToolTipText = p_MenuIconIndex.Name
            AddHandler p_MenuIconIndex.Click, AddressOf AddStripButton1_Click
            p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Image
            p_MenuIcon.Items.Add(p_MenuIconIndex)

            p_MenuIconIndex = New ToolStripButton
            p_MenuIconIndex.Name = "mnuSave"
            p_MenuIconIndex.Text = "Lưu"
            p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\save.jpg")
            AddHandler p_MenuIconIndex.Click, AddressOf SaveStripButton1_Click
            p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Image
            p_MenuIcon.Items.Add(p_MenuIconIndex)

            p_MenuIconIndex = New ToolStripButton
            p_MenuIconIndex.Name = "mnuCancel"
            p_MenuIconIndex.Text = "Hủy cập nhật"
            p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\undo.jpg")
            AddHandler p_MenuIconIndex.Click, AddressOf CancelStripButton1_Click
            p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Image
            p_MenuIcon.Items.Add(p_MenuIconIndex)

            p_MenuIconIndex = New ToolStripButton
            p_MenuIconIndex.Name = "mnuRemove"
            p_MenuIconIndex.Text = "Xóa"
            p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\delete1.jpg")
            AddHandler p_MenuIconIndex.Click, AddressOf DeleteStripButton1_Click
            p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Image
            p_MenuIcon.Items.Add(p_MenuIconIndex)

        End If

        p_MenuIcon.Visible = True
        p_MenuIcon.Dock = DockStyle.None

        'p_MenuIcon.Width = p_OwnerForm.Controls.Item(g_OwnerMenuStrip.Name).Width

        AddHandler p_MenuIcon.MouseMove, AddressOf ToolStrip1_MouseMove


        p_OwnerForm.Controls.Add(p_MenuIcon)
        p_OwnerForm.Controls.Item(p_MenuIcon.Name.ToString.Trim).Location = New System.Drawing.Point(0, 25)
        ' p_OwnerForm.Controls.Item(p_MenuIcon.Name.ToString.Trim).Select()
        ' p_OwnerForm.Controls.Item(p_MenuIcon.Name.ToString.Trim).Width = 893   ' p_OwnerForm.Controls.Item("ToolStrip1").Width
        ' p_OwnerForm.Controls.Item(p_MenuIcon.Name.ToString.Trim).Visible = False
        ' p_OwnerForm.Controls.Item(p_MenuIcon.Name.ToString.Trim).Dock = DockStyle.None ' = False
        '  p_OwnerForm.Controls.Item(p_MenuIcon.Name.ToString.Trim).Location = New System.Drawing.Point(0, 48)

        If Me.StartPosition = FormStartPosition.CenterScreen Or Me.StartPosition = FormStartPosition.CenterParent Then
        Else
            Me.Location = New System.Drawing.Point(0, 72)
        End If

    End Sub



    Private Sub ToolStrip1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)  ' Handles ToolStrip1.MouseMove
        sender.Focus()
    End Sub


    Private Sub CreateFormMenu(ByRef p_form As Object, ByVal p_Module As String, ByVal p_FormName As String)
        Dim p_MenuIcon As MenuStrip
        Dim p_MenuIconIndex As ToolStripMenuItem
        'Dim p_Count As Integer
        Dim p_OwnerForm As Form
        'Dim p_MenuIconArr() As ToolStrip
        ' Dim p_MenuIconIndex As ToolStripButton
        Dim p_Top As Integer
        ' Dim p_MainMenu As New MainMenu

        ' Dim p_MenuItem As New MenuItem
        Dim p_MenuCount As Integer = 0

        Dim p_PathIcon As String

        If p_form Is Nothing Then Exit Sub

        If Me.Owner Is Nothing Then
            ' p_OwnerForm = CType(p_form, Form)
        Else
            p_OwnerForm = Me.Owner ' CType(p_form, Form)
        End If
        ' p_OwnerForm.Controls.Item("ToolStrip1").Dock = DockStyle.Top

        If Me.MenuEdit = False And Me.MenuNavigator = False Then
            If Me.StartPosition = FormStartPosition.CenterScreen Or Me.StartPosition = FormStartPosition.CenterParent Then
            Else
                Me.Location = New System.Drawing.Point(0, 48)
            End If
            ' Me.p_XtraMenuIcon.Visible = False
            Exit Sub
        End If

        p_PathIcon = Application.StartupPath & "\Images"
        p_MenuIcon = New MenuStrip
        p_MenuIcon.Name = p_Module & "_" & p_FormName

        p_MenuIconIndex = New ToolStripMenuItem
        p_MenuIconIndex.Name = "mnuAdd"
        p_MenuIconIndex.Text = "Thêm mới"
        p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\addnew1.jpg") ' = p_PathIcon & "\addnew.jpg"
        p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Image
        AddHandler p_MenuIconIndex.Click, AddressOf AddStripButton1_Click
        p_MenuIcon.Items.Add(p_MenuIconIndex)
        p_MenuIcon.Dock = DockStyle.Top
        Me.Controls.Add(p_MenuIcon)
        '  Me.MainMenuStrip = p_MenuIcon
        '    p_MenuIconIndex.Name = "mnuAdd"
        '    p_MenuIconIndex.Text = "Thêm mới"
        '    p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\addnew1.jpg") ' = p_PathIcon & "\addnew.jpg"
        '    'p_MenuIconIndex.ToolTipText = p_MenuIconIndex.Name
        '    AddHandler p_MenuIconIndex.Click, AddressOf AddStripButton1_Click
        '    p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Image

        ''  Dim p_Count As Integer
        'Dim p_PathIcon As String
        'Dim p_Object() As Object


        '' p_OwnerForm.Controls.Item("ToolStrip1").

        'p_Object = p_OwnerForm.Controls.Find(UCase(p_Module & "_" & p_FormName), True)

        'If p_Object.Length > 0 Then
        '    p_MenuIcon = p_Object(0)
        '    p_MenuIcon.Visible = True
        '    If p_MenuIcon.Focused = False Then
        '        p_MenuIcon.BringToFront()
        '        p_MenuIcon.Select()

        '        If Me.StartPosition = FormStartPosition.CenterScreen Or Me.StartPosition = FormStartPosition.CenterParent Then
        '        Else
        '            Me.Location = New System.Drawing.Point(0, 72)
        '        End If

        '    End If
        '    Exit Sub
        'Else
        '    p_MenuIcon = New ToolStrip

        'End If

        'For Each p_MenuDisable In p_OwnerForm.Controls
        '    If InStr(UCase(p_MenuDisable.GetType.ToString.Trim), UCase(Me.ProductName.ToString.Trim), CompareMethod.Text) > 0 Then
        '        If UCase(p_MenuDisable.Name) <> UCase(p_Module & "_" & p_FormName) Then
        '            p_MenuDisable.visible = False
        '        End If
        '    End If
        'Next


        'p_PathIcon = Application.StartupPath & "\Images"

        'If p_MenuIcon.Name = UCase(p_Module & "_" & p_FormName) Then Exit Sub

        'p_MenuIcon.Name = UCase(p_Module & "_" & p_FormName)


        ''+++++++++++++++++++++++++++++++++++++++++++++++++++Tao Button navigator
        'If Me.MenuNavigator = True Then

        '    p_MenuIconIndex = New ToolStripButton
        '    p_MenuIconIndex.Name = "mnuFirst"
        '    p_MenuIconIndex.Text = "|<<"
        '    p_MenuIconIndex.ToolTipText = "Bản ghi đầu"
        '    p_MenuIconIndex.Font = New Drawing.Font(Font.Name, 7, Drawing.FontStyle.Bold)
        '    '  p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\addnew1.jpg") ' = p_PathIcon & "\addnew.jpg"
        '    p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Text

        '    AddHandler p_MenuIconIndex.Click, AddressOf MenuNavigatorCilck

        '    p_MenuIcon.Items.Add(p_MenuIconIndex)



        '    p_MenuIconIndex = New ToolStripButton
        '    p_MenuIconIndex.Name = "mnuPreviuos"
        '    p_MenuIconIndex.Text = "<"
        '    p_MenuIconIndex.ToolTipText = "Bản ghi trước"
        '    p_MenuIconIndex.Font = New Drawing.Font(Font.Name, 7, Drawing.FontStyle.Bold)
        '    'p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\undo.jpg")
        '    p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Text
        '    AddHandler p_MenuIconIndex.Click, AddressOf MenuNavigatorCilck
        '    p_MenuIcon.Items.Add(p_MenuIconIndex)

        '    p_MenuIconIndex = New ToolStripButton
        '    p_MenuIconIndex.Name = "mnuNext"
        '    p_MenuIconIndex.Text = ">"
        '    p_MenuIconIndex.ToolTipText = "Bản ghi sau"
        '    p_MenuIconIndex.Font = New Drawing.Font(Font.Name, 7, Drawing.FontStyle.Bold)
        '    'p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\delete1.jpg")
        '    p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Text
        '    AddHandler p_MenuIconIndex.Click, AddressOf MenuNavigatorCilck
        '    p_MenuIcon.Items.Add(p_MenuIconIndex)



        '    p_MenuIconIndex = New ToolStripButton
        '    p_MenuIconIndex.Name = "mnuLast"
        '    p_MenuIconIndex.Text = ">>|"
        '    p_MenuIconIndex.ToolTipText = "Bản ghi cuối"
        '    p_MenuIconIndex.Font = New Drawing.Font(Font.Name, 7, Drawing.FontStyle.Bold)
        '    ' p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\delete1.jpg")
        '    p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Text
        '    AddHandler p_MenuIconIndex.Click, AddressOf MenuNavigatorCilck
        '    p_MenuIcon.Items.Add(p_MenuIconIndex)

        '    '+++++++++++++++++++++++++++++++++++++++++++++++++++



        'End If
        ''+++++++++++++++++++++++++++++++++++++++++++++++++++Tao Buttonedit 
        'If Me.MenuEdit = True Then
        '    p_MenuIconIndex = New ToolStripButton
        '    p_MenuIconIndex.Name = "mnuAdd"
        '    p_MenuIconIndex.Text = "Thêm mới"
        '    p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\addnew1.jpg") ' = p_PathIcon & "\addnew.jpg"
        '    'p_MenuIconIndex.ToolTipText = p_MenuIconIndex.Name
        '    AddHandler p_MenuIconIndex.Click, AddressOf AddStripButton1_Click
        '    p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Image
        '    p_MenuIcon.Items.Add(p_MenuIconIndex)

        '    p_MenuIconIndex = New ToolStripButton
        '    p_MenuIconIndex.Name = "mnuSave"
        '    p_MenuIconIndex.Text = "Lưu"
        '    p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\save.jpg")
        '    AddHandler p_MenuIconIndex.Click, AddressOf SaveStripButton1_Click
        '    p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Image
        '    p_MenuIcon.Items.Add(p_MenuIconIndex)

        '    p_MenuIconIndex = New ToolStripButton
        '    p_MenuIconIndex.Name = "mnuCancel"
        '    p_MenuIconIndex.Text = "Hủy cập nhật"
        '    p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\undo.jpg")
        '    AddHandler p_MenuIconIndex.Click, AddressOf CancelStripButton1_Click
        '    p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Image
        '    p_MenuIcon.Items.Add(p_MenuIconIndex)

        '    p_MenuIconIndex = New ToolStripButton
        '    p_MenuIconIndex.Name = "mnuRemove"
        '    p_MenuIconIndex.Text = "Xóa"
        '    p_MenuIconIndex.Image = System.Drawing.Bitmap.FromFile(p_PathIcon & "\delete1.jpg")
        '    AddHandler p_MenuIconIndex.Click, AddressOf DeleteStripButton1_Click
        '    p_MenuIconIndex.DisplayStyle = ToolStripItemDisplayStyle.Image
        '    p_MenuIcon.Items.Add(p_MenuIconIndex)

        'End If

        'p_MenuIcon.Visible = False
        'p_MenuIcon.Dock = DockStyle.None
        'p_MenuIcon.Width = p_OwnerForm.Controls.Item("ToolStrip1").Width
        'p_OwnerForm.Controls.Add(p_MenuIcon)

        '' p_OwnerForm.Controls.Item(p_MenuIcon.Name.ToString.Trim).Width = 893   ' p_OwnerForm.Controls.Item("ToolStrip1").Width
        '' p_OwnerForm.Controls.Item(p_MenuIcon.Name.ToString.Trim).Visible = False
        '' p_OwnerForm.Controls.Item(p_MenuIcon.Name.ToString.Trim).Dock = DockStyle.None ' = False
        ''  p_OwnerForm.Controls.Item(p_MenuIcon.Name.ToString.Trim).Location = New System.Drawing.Point(0, 48)

        'If Me.StartPosition = FormStartPosition.CenterScreen Or Me.StartPosition = FormStartPosition.CenterParent Then
        'Else
        '    Me.Location = New System.Drawing.Point(0, 72)
        'End If

    End Sub


    Public Sub ShowMessageBox(ByVal p_ErrorNum As String, ByVal p_StringMessage As String, Optional ByVal p_Type As Integer = 3)
        p_XtraModuleObj.ModErrExceptionNew(p_ErrorNum, p_StringMessage, p_Type)
    End Sub

    Public Sub ShowStatusMessage(ByVal p_Error As Boolean, _
                             Optional ByVal p_ErrorNumber As String = "", _
                             Optional ByVal p_ErrorText As String = "", _
                             Optional ByVal p_TimeSeconds As Integer = 10)
        'Dim currentForm As Form = Application.OpenForms. 
        Dim p_Object As Object
        Try
            p_Object = Me.cusStatusLabel1
        Catch ex As Exception
            p_Object = Nothing
        End Try

        If Not p_Object Is Nothing Then
            If p_Object.visible = True Then
                p_XtraMessageStatusl = p_Object
            End If
        End If



        If p_XtraMessageStatusl Is Nothing Or p_XtraModuleObj Is Nothing Then Exit Sub
        p_XtraModuleObj.ModStatusMessage(p_Error, p_ErrorNumber, p_ErrorText, 600, p_XtraMessageStatusl)
        'p_XtraModuleObj.ModStatusMessage(p_Error, p_ErrorNumber, p_ErrorText, p_TimeSeconds, p_XtraMessageStatusl)

    End Sub

    Public Sub XtraLoadGrid(Optional ByVal p_requery As Boolean = False)
        Dim p_TrueGridName As String
        Dim p_TrueDBGrid As U_TextBox.TrueDBGrid
        Dim p_GirdView As U_TextBox.GridView
        Dim p_Object() As Object
        Dim p_Status As Boolean
        If g_TrueGirdName.Columns.Count > 0 Then
            For p_Count = 0 To g_TrueGirdName.Rows.Count - 1
                p_TrueGridName = g_TrueGirdName.Rows(p_Count).Item(0).ToString.Trim
                If p_TrueGridName <> "" Then
                    p_Object = Me.Controls.Find(p_TrueGridName, True)
                    If Not p_Object Is Nothing Then
                        If p_Object.Length > 0 Then
                            p_TrueDBGrid = CType(p_Object(0), U_TextBox.TrueDBGrid)
                            p_GirdView = p_TrueDBGrid.Views(0)
                            p_Status = p_Set_TrueGrid_Property(Me, p_TrueDBGrid, _
                                            p_requery, "")


                        End If
                    End If
                End If
            Next
            Exit Sub
        End If
    End Sub

    Public Sub XtraForm1_Load()
        Dim p_Col As DataColumn

        If g_LineRemove.Columns.Count <= 0 Then
            p_Col = New DataColumn
            p_Col.ColumnName = "SQL_STR"
            p_Col.DataType = GetType(String)
            p_Col.MaxLength = 4000
            g_LineRemove.Columns.Add(p_Col)
        End If

        If pv_LineRemove.Columns.Count <= 0 Then
            p_Col = New DataColumn
            p_Col.ColumnName = "SQL_STR"
            p_Col.DataType = GetType(String)
            p_Col.MaxLength = 4000
            pv_LineRemove.Columns.Add(p_Col)
        End If

        If pv_TableEdit.Columns.Count <= 0 Then
            p_Col = New DataColumn
            p_Col.ColumnName = "SQL_STR"
            p_Col.DataType = GetType(String)
            p_Col.MaxLength = 4000
            pv_TableEdit.Columns.Add(p_Col)
        End If


        g_LineRemove.Clear()
        pv_LineRemove.Clear()
        pv_TableEdit.Clear()
        g_Form = Me
        g_UserName = p_XtraUserName
        g_CompanyCode = p_XtraComCode
        ReDim p_BindingSourceControl(0 To 14)
        If p_BindingSourceName.Rows.Count > 0 Then
            p_BindingSourceName.Clear()
        End If

        If p_BindingSourceKey.Rows.Count > 0 Then
            p_BindingSourceKey.Clear()
        End If

        If p_BindingTableName.Rows.Count > 0 Then
            p_BindingTableName.Clear()
        End If

        If DefaultFormLoad = True Then
            LoadDataToForm()
            If Me.g_FormAddnew = False And Me.FormStatus = True Then
                Me.FormStatus = False
            End If
            Me.g_FormLoad = False
        End If


        Me.KeyPreview = True


    End Sub



    Public Sub DeleteHeaderRecord(ByRef p_Form As U_CusForm.XtraCusForm1)
        Dim p_Count As Integer
        Dim p_Datarow As DataRow
        Dim p_Desc As String
        ModDeleteHeaderRecord(p_Form)
        For p_Count = 0 To g_LineRemove.Rows.Count - 1
            p_Datarow = pv_LineRemove.NewRow
            p_Datarow(0) = g_LineRemove.Rows(p_Count).Item(0)
            pv_LineRemove.Rows.Add(p_Datarow)
        Next

        If g_Service.Sys_Execute_DataTableNew(pv_LineRemove, p_Desc) = False Then
            ShowMessageBox("", p_Desc)
        End If
        SetmenuIcon(True)
        If Me.FormStatus = True Then
            Me.FormStatus = False
        End If
        'pv_LineRemove.Merge(g_LineRemove)
    End Sub
    Public Function EnableControl() As Boolean
        Dim p_Object_Item() As Object

        EnableControl = True
        Try

            For p_Count = 0 To 100     'g_ChooseRecordFromSearch.
                If Not g_ObjectUpdateIsNull(p_Count) Is Nothing Then
                    p_Object_Item = Me.Controls.Find(g_ObjectUpdateIsNull(p_Count), True)
                    If p_Object_Item.Length > 0 Then
                        If p_Object_Item(0).Visible = True Then
                            p_Object_Item(0).Properties.ReadOnly = False
                            ' g_ObjectUpdateIsNull(p_Count) = p_Object.Name
                            p_Object_Item(0).backcolor = g_ObjectUpdateIsNullColor(p_Count)
                            ' BackColor = pv_Locked_Back_Color
                        End If
                    End If
                    Exit For
                End If
            Next
            'p_Object_Item.Properties.ReadOnly = True

        Catch ex As Exception
            EnableControl = False
        End Try
    End Function

    Public Function SetTrueGridPropertyNew(ByRef p_Form As U_CusForm.XtraCusForm1, _
                                          ByVal p_requery As Boolean) As Boolean

        ' Dim p_Control() As Control
        Dim p_Status As Boolean
        Dim p_BindingSourceLine As U_TextBox.U_BindingSource
        ' Dim p_DataTable As DataTable
        Dim p_TrueDBGrid As U_TextBox.TrueDBGrid
        '  Dim p_GridView As U_TextBox.GridView
        SetTrueGridPropertyNew = True
        'p_DataTable = g_Service.mod_SYS_GET_DATATABLE("select Distinct Grid_Name from GRID_PROPERTY with (nolock) where FORM_NAME='" & p_Form.Name & "'")
        'If Not p_DataTable Is Nothing Then
        '    For p_Count = 0 To p_DataTable.Rows.Count - 1
        Try
            ' p_Control = p_Form.Controls.Find(p_DataTable.Rows(p_Count).Item(0).ToString.Trim, True)

            For Each p_Control In p_Form.Controls
                '  If p_Control.Length > 0 Then
                'If InStr(UCase(p_Control.GetType.ToString), pv_Type_TrueDBGrid, CompareMethod.Text) Then

                p_BindingSourceLine = New U_TextBox.U_BindingSource
                '    If p_Set_TrueGrid_Property(p_Form, p_TrueDBGrid, p_requery, "") = False Then
                '        'GoTo Line_Err
                '        MsgBox("et_TrueGrid_Property Error")
                '        SetTrueGridPropertyNew = False
                '        Exit Function
                '    End If

                'End If
                If InStr(UCase(p_Control.GetType.ToString), pv_Type_TrueDBGrid, CompareMethod.Text) > 0 _
                    Or InStr(UCase(p_Control.GetType.ToString), pv_Type_TrueDBGridNew, CompareMethod.Text) > 0 Then

                    p_TrueDBGrid = CType(p_Control, U_TextBox.TrueDBGrid)

                    p_TrueDBGrid = CType(p_Control, U_TextBox.TrueDBGrid)
                    p_Status = True
                    p_Status = p_Set_TrueGrid_Property(p_Form, p_TrueDBGrid, _
                                                p_requery, "")
                ElseIf InStr(UCase(p_Control.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    If p_Set_TrueGrid_Property_Page(p_Form,
                                          p_Control,
                                                p_requery) Then
                    End If

                End If
            Next
        Catch ex As Exception

        End Try
        '   Next
        'End If
    End Function

    Public Function CompileControlHeaderToSQL(ByRef p_Error As Boolean, ByVal p_RecordHist As Boolean, _
                                                ByRef p_Form As U_CusForm.XtraCusForm1, _
                                        ByVal p_Table_Name As String, _
                                        ByRef p_ControlKey As Object, _
                                        ByVal p_AutoKeyName As String, _
                                        Optional ByRef p_ControlKey1 As Object = Nothing, _
                                        Optional ByVal p_AutoKeyName1 As String = "", _
                                        Optional ByVal p_UserName As String = "") As DataTable
        CompileControlHeaderToSQL = p_CompileControlHeaderToSQL(p_Error, p_RecordHist, _
                                                p_Form, _
                                        p_UserName)


    End Function


    Public Function p_BindingSourceAddNewRow() As Boolean
        Dim p_ObjArr() As Object
        p_BindingSourceAddNewRow = False
        Try
            If FormStatus = True Then
                Return False
            End If
            p_BindingSourceAddNewRow = BindingSourceAddNewRow()

            Me.FormStatus = True
            Me.FormLock = False
            If Me.ButtonSave.ToString.Trim <> "" Then
                p_ObjArr = Me.Controls.Find(Me.ButtonSave.ToString.Trim, True)
                If Not p_ObjArr Is Nothing Then
                    If p_ObjArr.Length > 0 Then
                        p_ObjArr(0).Text = Me.CaptionUpd
                    End If

                End If
            End If

            SetmenuIcon(True)
        Catch ex As Exception
            p_BindingSourceAddNewRow = False
        End Try

    End Function


    Public Sub FormCancelEdit()

        Try
            For p_CountSource = 0 To p_BindingSourceName.Rows.Count - 1
                ' If UCase(p_Navigator.ViewName.ToString.Trim) = UCase(p_BindingSourceName.Rows(p_CountSource).Item(0).ToString.Trim) Then
                p_BindingSourceControl(p_CountSource).CancelEdit()
                ' p_BindingSourceControl(p_CountSource).EndEdit()

                ' p_BindingSourceControl(p_CountSource).ResumeBinding()

                ' p_BindingSourceControl(p_CountSource).ResetBindings(True)
                ' Exit Sub
                'End If
            Next
        Catch ex As Exception
            'BindingSourceCancelEdit = False
        End Try
        Me.FormStatus = False
        SetmenuIcon(False)
        ShowStatusMessage(False, "MS905", "Đã hủy cập nhật", g_TimeInfor)


    End Sub


    Private Sub DeleteRecord()

        Try
            For p_CountSource = 0 To p_BindingSourceName.Rows.Count - 1
                ' If UCase(p_Navigator.ViewName.ToString.Trim) = UCase(p_BindingSourceName.Rows(p_CountSource).Item(0).ToString.Trim) Then
                'p_BindingSourceControl(p_CountSource).CancelEdit()

                p_BindingSourceControl(p_CountSource).RemoveCurrent()


            Next

            XtraLoadGrid(True)
        Catch ex As Exception
            'BindingSourceCancelEdit = False
        End Try
        Me.FormStatus = True
        SetmenuIcon(True)
        '  ShowStatusMessage(False, "MS905", "Đã hủy cập nhật", g_TimeInfor)


    End Sub





    Public Function p_BindingSourceCancelEdit(ByRef p_Object As Object) As Boolean
        Dim p_Navigator As U_TextBox.Navigator
        Dim p_BtnSave() As Object
        p_BindingSourceCancelEdit = True
        Try
            p_Navigator = CType(p_Object, U_TextBox.Navigator)
            p_BindingSourceCancelEdit = BindingSourceCancelEdit(p_Navigator)
            If p_BindingSourceCancelEdit = True Then

                Me.FormStatus = False
                If Me.ButtonSave.ToString.Trim <> "" Then
                    p_BtnSave = Me.Controls.Find(Me.ButtonSave.ToString.Trim, True)
                    If p_BtnSave.Length > 0 Then
                        p_BtnSave(0).Text = Me.CaptionAdd
                    End If
                End If

                SetmenuIcon(False)
            End If
        Catch ex As Exception
            p_BindingSourceCancelEdit = False
        End Try


    End Function



    Public Sub GridNavigatorButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_DesError As String = ""
        If e.Handled = True Then Exit Sub
        Dim p_Control As DevExpress.XtraGrid.GridControlNavigator
        Dim p_TrueGrid As U_TextBox.U_TrueDBGrid
        Dim p_SQL As String = ""
        Dim p_Table As String = ""
        Dim p_ColumnKey As String = ""
        Dim p_FieldType As String = ""
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_DataRow As DataRow
        Dim p_dataTbl As DataTable
        Dim p_BindingSource As System.Windows.Forms.BindingSource

        Dim p_Desc As String = ""
        'If e.Handled = False Then Exit Sub

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            'e.Handled = True
            p_Control = sender
            p_TrueGrid = CType(p_Control.Parent, U_TextBox.U_TrueDBGrid)
            If p_TrueGrid.DefaultRemove = False Then Exit Sub
            If p_XtraModuleObj.ShowMessage(Me,
                                       "MS0002",
                    "Bạn có chắc chắn muốn thực hiện không?",
                    True,
                    "Có",
                    True,
                    "Không",
                     False,
                    "",
                   2) = Windows.Forms.DialogResult.No Then
                e.Handled = True
                Exit Sub
            End If
            Try

                p_Table = p_TrueGrid.TableName.ToString.Trim
                p_ColumnKey = p_TrueGrid.ColumnKey.ToString.Trim
                p_FieldType = p_TrueGrid.ColumnKeyType.ToString.Trim
                p_GridView = p_TrueGrid.Views(0)
                If p_GridView.FocusedRowHandle >= 0 Then

                    p_DataRow = p_GridView.GetDataRow(p_GridView.FocusedRowHandle)
                    If (p_FieldType = "N" Or p_FieldType = "C") And p_ColumnKey <> "" And p_Table <> "" Then

                        p_BindingSource = p_TrueGrid.DataSource
                        p_dataTbl = CType(p_BindingSource.DataSource, DataTable)
                        If p_DataRow.Item(p_ColumnKey).ToString.Trim <> "" Then
                            If p_FieldType = "N" Then
                                p_SQL = "DELETE FROM " & p_Table & " WHERE " & p_ColumnKey & "=" & p_DataRow.Item(p_ColumnKey)
                            Else
                                p_SQL = "DELETE FROM " & p_Table & " WHERE " & p_ColumnKey & "='" & p_DataRow.Item(p_ColumnKey) & "'"
                            End If
                            p_DataRow = Nothing

                            p_DataRow = g_LineRemove.NewRow
                            p_DataRow.Item(0) = p_SQL
                            g_LineRemove.Rows.Add(p_DataRow)
                            p_dataTbl.Rows.RemoveAt(p_GridView.FocusedRowHandle)
                        Else
                            p_dataTbl.Rows.RemoveAt(p_GridView.FocusedRowHandle)
                        End If

                        If Me.FormStatus = False Then
                            Dim p_ButtonSave() As Object
                            p_ButtonSave = Me.Controls.Find(Me.ButtonSave, True)
                            Me.FormStatus = True
                            If p_ButtonSave.Length > 0 Then
                                p_ButtonSave(0).text = Me.CaptionUpd
                            End If

                        End If

                        e.Handled = True
                        p_TrueGrid.Refresh()

                        'If g_XtraServicesObj.Sys_Execute(p_SQL, p_Desc) = False Then
                        '    p_XtraModuleObj.ModErrExceptionNew("", p_Desc)
                        '    e.Handled = True
                        '    Exit Sub
                        'End If
                    Else
                        p_XtraModuleObj.ModErrExceptionNew("MS0003", "")
                        e.Handled = True
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
                e.Handled = True
                Exit Sub
            End Try

        End If

    End Sub


    Private Sub GridView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles GridView1.KeyPress
        Dim p_Column As U_TextBox.GridColumn
        Dim p_Grid As U_TextBox.GridView
        p_Grid = CType(sender, U_TextBox.GridView)
        p_Column = p_Grid.FocusedColumn
        If p_Column.ChangeFormStatus = False Then
            Exit Sub
        End If
        If e.Handled = False Then
            g_ValueType = 2
        End If
        'Try
        '    If 
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub p_AddColumnTypeButtonEditView1(ByRef p_TrueGird As U_TextBox.U_TrueDBGrid,
                                       ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView,
                                       ByVal p_ColumnIndex As String)
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Dim p_DesError As String = ""
        Try
            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
            p_TrueGird.RepositoryItems.Add(p_ColType)
            p_GridView.Columns(p_ColumnIndex).ColumnEdit = p_ColType
            AddHandler p_ColType.ButtonClick, AddressOf Gridview_Column_Button_Click
            'Select Case UCase(p_TrueGird.Name)
            '    Case UCase("U_TrueDBGrid1")

            '    Case ""
            '    Case ""
            '    Case ""
            'End Select


            ' p_GridView.Columns("").
        Catch ex As Exception
            p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
        End Try
    End Sub


    Private Sub GridView_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) 'Handles GridView1.CellValueChanged
        'Not e.Column.ColumnEdit Is Nothing And 
        Dim p_Column As U_TextBox.GridColumn
        Dim p_Grid As U_TextBox.GridView
        p_Grid = CType(sender, U_TextBox.GridView)
        p_Column = p_Grid.FocusedColumn
        If p_Column.ChangeFormStatus = False Then
            Exit Sub
        End If
        If (g_ValueType = 2) Then
            ' If Not e.Column.ColumnEdit Is Nothing Then
            Dim p_Form As Object
            ' Dim p_ButtonEdit As DevExpress.XtraEditors.ButtonEdit
            Dim p_OldValue As String = ""
            Dim p_NewValue As String = ""
            Dim p_DataTable As DataTable
            Dim p_SQL As String = ""
            Dim p_Field As String = ""
            Dim p_Exist As Boolean = False
            Dim p_ButtonArr() As Object
            Dim p_ButtonOK As Object = Nothing
            Dim p_ItemBtn As String = ""
            Dim p_TrueGrid As U_TextBox.U_TrueDBGrid
            Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
            Dim p_Count As Integer
            'Dim p_DataRow As DataRow
            Dim p_RowHandle As Integer
            Dim p_ColumnName As String = ""
            Dim p_DataArr() As DataRow

            Dim p_ColumnInt As Boolean = False
            Dim dt As New DataTable
            Dim p_BindingSourceTmp As New System.Windows.Forms.BindingSource
            Dim p_DataRow As DataRow
            Dim p_CellValue As String
            ' Dim p_DataCheck As DataTable
            Try
                If p_XtraDataSet_TrueGird Is Nothing Then Exit Sub
                If Me.FormLock = True Then Exit Sub
                If e.Valid = False Then Exit Sub
                p_GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
                p_TrueGrid = p_GridView.GridControl

                p_RowHandle = p_GridView.FocusedRowHandle
                p_ColumnName = p_GridView.FocusedColumn.Name
                p_RowHandle = p_GridView.FocusedRowHandle
                If UCase(p_ColumnName) = UCase(p_TrueGrid.ColumnKey) Then
                    ' p_FieldName = p_GridView.FocusedColumn.FieldName

                    p_DataRow = p_GridView.GetDataRow(p_RowHandle)
                    If p_TrueGrid.ColumnKey.ToString.Trim <> "" And p_DataRow.Item("CHECKUPD").ToString.Trim = "I" Then
                        Try
                            p_CellValue = e.Value   ' p_DataRow.Item(p_TrueGrid.ColumnKey).ToString
                        Catch ex As Exception
                            p_DataTable = Nothing
                            p_XtraModuleObj.ErrException(Err.Number, ex.Message)
                            Exit Sub
                        End Try

                        If p_CellValue.ToString.Trim <> "" Then
                            If p_TrueGrid.ColumnKeyType = "N" Then
                                'p_RowsCheck = p_DataCheck.Select(p_ColumnKey & "=" & p_CellValue)
                                p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TrueGrid.TableName & " Where " & p_TrueGrid.ColumnKey & "=" & p_CellValue & "'"
                            Else
                                p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TrueGrid.TableName & " Where " & p_TrueGrid.ColumnKey & "=''" & p_CellValue & "'''"
                            End If
                            dt = g_XtraServicesObj.mod_SYS_GET_DATATABLE(p_SQL)
                            If dt.Rows.Count > 0 Then
                                'p_Insert = 2
                                ' If p_DataRow.Item("CHECKUPD").ToString.Trim = "I" Then
                                'e.Valid = False
                                'p_GridView.CancelUpdateCurrentRow()

                                p_GridView.ClearColumnsFilter()
                                'p_XtraModuleObj.ModErrException("MS0001", "Bản ghi đã tồn tại")
                                e.ErrorText = p_CellValue & "- Đã tồn tại trong hệ thống"
                                e.Valid = False
                                dt = Nothing
                                Exit Sub
                                'End If
                            End If
                        End If
                    End If
                End If
                If p_ColumnName <> "CHECKUPD" Then
                    Me.FormStatus = True

                    Try
                        p_ItemBtn = Me.ButtonSave
                    Catch ex As Exception

                    End Try
                    If p_ItemBtn.ToString.Trim <> "" Then
                        p_ButtonArr = Me.Controls.Find(p_ItemBtn, True)
                        If Not p_ButtonArr Is Nothing Then
                            p_ButtonOK = p_ButtonArr(0)
                            p_ButtonOK.Text = Me.CaptionUpd
                        End If
                    End If
                    p_DataRow = p_GridView.GetDataRow(p_RowHandle)
                    If Not p_DataRow Is Nothing Then
                        If Not p_DataRow.Item("CHECKUPD") Is Nothing Then
                            If p_DataRow.Item("CHECKUPD").ToString.Trim <> "I" And p_DataRow.Item("CHECKUPD").ToString.Trim <> "Y" Then
                                p_GridView.SetRowCellValue(p_RowHandle, "CHECKUPD", "Y")

                                GridViewTableEdit(p_GridView)

                            End If
                        End If
                    End If



                End If

                If p_GridView.Columns(p_ColumnName).ColumnEdit Is Nothing Then Exit Sub
                Try
                    p_DataArr = p_XtraDataSet_TrueGird.Tables(0).Select("FORM_NAME='" & Me.Name & "' and GRID_NAME='" & p_TrueGrid.Name & "' and COL_NAME='" & p_ColumnName & "'")
                Catch ex As Exception
                    Exit Sub
                End Try

                If p_DataArr Is Nothing Then Exit Sub
                If p_DataArr.Length <= 0 Then Exit Sub


                If e.Value.ToString.Trim = "" Then

                    p_BindingSourceTmp = p_GridView.DataSource
                    dt = CType(p_BindingSourceTmp.DataSource, DataTable)


                    For p_Count = 1 To 4
                        p_ColumnName = p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                        If p_ColumnName <> "" Then
                            If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
                                dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
                            Else
                                dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
                            End If
                        End If
                    Next
                End If
                p_SQL = p_DataArr(0).Item("CFLSQL").ToString.Trim

                If p_SQL = "" Then Exit Sub

                Dim p_ValueCheck As String


                p_ValueCheck = e.Value.ToString.Trim
                p_SQL = p_XtraModuleObj.Parameter_Item(Me, p_SQL)
                If p_ValueCheck = "" Then Exit Sub
                If UCase(p_GridView.Columns(p_ColumnName).ColumnType.Name.ToString.Trim) <> "STRING" Then
                    p_ColumnInt = True
                End If
                If p_ColumnInt = True Then
                    p_SQL = "SELECT * FROM (" & p_SQL & ") ABC WHERE " & p_DataArr(0).Item("CFLKeyField").ToString.Trim & "=" & p_ValueCheck
                Else
                    p_SQL = "SELECT * FROM (" & p_SQL & ") ABC WHERE " & p_DataArr(0).Item("CFLKeyField").ToString.Trim & "='" & p_ValueCheck & "'"
                End If

                p_DataTable = g_XtraServicesObj.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)



                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_Exist = True
                    End If
                End If

                If p_Exist = True Then   ''Da co trong he thong danh muc

                    p_BindingSourceTmp = p_GridView.DataSource
                    If p_RowHandle < 0 Then
                        p_GridView.UpdateCurrentRow()
                        p_RowHandle = p_GridView.FocusedRowHandle
                    End If
                    dt = CType(p_BindingSourceTmp.DataSource, DataTable)

                    If dt.Rows.Count > 0 Then
                        dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(0).ToString.Trim
                        For p_Count = 1 To 4
                            p_ColumnName = p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                            If p_ColumnName <> "" Then
                                dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(p_Count).ToString.Trim
                            End If
                        Next

                    End If
                Else    'Chua co trong danh muc
                    ' MsgBox("Giá tri không hợp lệ")
                    e.ErrorText = "Giá tri không hợp lệ"
                    e.Valid = False
                    Exit Sub

                End If
                g_ValueType = 0
                '  Exit Sub


            Catch ex As Exception

            End Try

        End If
    End Sub

    Public Sub GridViewTableEdit(ByVal p_GridView As U_TextBox.GridView)
        Dim p_RowArr() As DataRow
        Dim p_DataRow As DataRow
        Dim p_TrueGrid As U_TextBox.TrueDBGrid

        If pv_GridViewEdit.Columns.Count <= 0 Then
            pv_GridViewEdit.Columns.Add("SQL_STR", GetType(String))
        End If
        Try
            p_TrueGrid = p_GridView.GridControl
            p_RowArr = pv_GridViewEdit.Select("SQL_STR='" & UCase(p_TrueGrid.Name) & "'")
            If p_RowArr.Length <= 0 Then
                p_DataRow = pv_GridViewEdit.NewRow
                p_DataRow.Item(0) = UCase(p_TrueGrid.Name)
                pv_GridViewEdit.Rows.Add(p_DataRow)
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) ' Handles GridView1.InitNewRow
        Dim p_GridView As U_TextBox.GridView
        'Dim p_RowArr() As DataRow
        'Dim p_DataRow As DataRow
        Try

            p_GridView = CType(sender, U_TextBox.GridView)

            GridViewTableEdit(p_GridView)

            p_GridView.SetRowCellValue(p_GridView.FocusedRowHandle, "CHECKUPD", "I")
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GridviewButtonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Private Sub Gridview_Column_Button_Click(ByRef p_TrueGrid As Object, _
        '                                                  ByRef p_GridView As Object, _
        '                                           ByVal p_ColumnName As String, _
        '                                            Optional ByVal p_StrSQL As String = "")
        Dim p_TrueGrid As U_TextBox.U_TrueDBGrid
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_ButtonArr() As Object
        Dim p_ButtonOK As Object = Nothing
        Dim p_ItemBtn As String = ""
        Dim p_ColumnName As String
        Dim p_ButtonEdit As DevExpress.XtraEditors.ButtonEdit
        Dim p_StrSQL As String = ""
        Try
            p_ItemBtn = Me.ButtonSave
        Catch ex As Exception

        End Try
        If p_ItemBtn.ToString.Trim <> "" Then
            p_ButtonArr = Me.Controls.Find(p_ItemBtn, True)
            If Not p_ButtonArr Is Nothing Then
                p_ButtonOK = p_ButtonArr(0)
            End If
        End If
        p_ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)
        p_TrueGrid = CType(p_ButtonEdit.Parent, U_TextBox.U_TrueDBGrid)
        p_GridView = p_TrueGrid.Views(0)
        p_ColumnName = p_GridView.FocusedColumn.FieldName
        If p_GridView.Columns.Item(p_ColumnName).OptionsColumn.ReadOnly = True Then Exit Sub
        If p_GridView.FocusedRowHandle < 0 Then
            p_GridView.AddNewRow()
        End If
        p_XtraModuleObj.p_ModGridview_Column_Button_Click(p_TrueGrid, _
                                                       p_GridView, _
                                                        Me, _
                                                Me.FormStatus, _
                                                 p_ButtonOK, _
                                                 p_ColumnName,
                                                 p_XtraDataSet_TrueGird, p_StrSQL, False)
        If g_ChooseRecordFromSearch = True Then
            g_ValueType = 1
        End If

    End Sub


    ' Private Sub GridView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 'Handles GridView1.MouseMove
    Private Sub GridView1_FocusedColumnChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs)


        Dim p_Table_Name As String = ""
        Dim p_Field_Name As String = ""
        Dim p_View_Name As String = ""
        Dim p_Form As Object 'System.Windows.Forms.Form
        Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_TrueGrid As U_TextBox.U_TrueDBGrid

        GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        p_TrueGrid = GridView.GridControl

        p_Table_Name = p_TrueGrid.TableName
        'p_Field_Name = Me.FieldName
        p_View_Name = p_TrueGrid.ViewName
        p_Form = FindForm()

        Try
            If Not p_Form.p_XtraToolTripLabel Is Nothing Then
                ' Me.ToolTip = "NAME(" & Me.Name & ") VIEW(" & p_View_Name & ") TAB(" & p_Table_Name & ") FIELD (" & p_Field_Name & ")"
                ' Try
                p_Form.p_XtraToolTripLabel.Text = " Name(" & p_TrueGrid.Name & ") View(" & p_View_Name & ") Table(" & p_Table_Name & ") Col (" & GridView.FocusedColumn.Name & ")"
                '        Catch ex As Exception

                'End Try

            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub UnlockObjectIsNull()
        Dim p_Count As Integer
        Dim p_ControlArr() As Object
        For p_Count = 0 To 100
            If Not g_ObjectUpdateIsNull(p_Count) Is Nothing Then
                If g_ObjectUpdateIsNull(p_Count).ToString.Trim <> "" Then
                    p_ControlArr = Me.Controls.Find(g_ObjectUpdateIsNull(p_Count).ToString.Trim, True)
                    If p_ControlArr.Length > 0 Then
                        p_ControlArr(0).BackColor = g_ObjectUpdateIsNullColor(p_Count)
                        p_ControlArr(0).Properties.ReadOnly = False
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub LockObjectIsNull()
        Dim p_Count As Integer
        Dim p_ControlArr() As Object
        For p_Count = 0 To 100
            If Not g_ObjectUpdateIsNull(p_Count) Is Nothing Then
                If g_ObjectUpdateIsNull(p_Count).ToString.Trim <> "" Then
                    p_ControlArr = Me.Controls.Find(g_ObjectUpdateIsNull(p_Count).ToString.Trim, True)
                    If p_ControlArr.Length > 0 Then
                        p_ControlArr(0).BackColor = pv_Locked_Back_Color
                        p_ControlArr(0).Properties.ReadOnly = True
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub




    Public Sub Gridview_Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Column_Button_Click(sender)


        'Exit Sub


        'Dim p_TrueGrid As U_TextBox.TrueDBGrid
        'Dim p_GridView As U_TextBox.GridView
        'Dim p_ButtonArr() As Object
        'Dim p_ButtonOK As Object = Nothing
        'Dim p_ItemBtn As String = ""
        'Dim p_Column As U_TextBox.GridColumn
        'Dim p_ButtonEdit As DevExpress.XtraEditors.ButtonEdit
        'Dim p_StrSQL As String = ""
        'Dim p_DataRow As DataRow
        'Try
        '    p_ItemBtn = g_Form.ButtonSave
        'Catch ex As Exception

        'End Try
        'If p_ItemBtn.ToString.Trim <> "" Then
        '    p_ButtonArr = g_Form.Controls.Find(p_ItemBtn, True)
        '    If Not p_ButtonArr Is Nothing Then
        '        If p_ButtonArr.Length > 0 Then
        '            p_ButtonOK = p_ButtonArr(0)
        '        End If
        '    End If
        'End If
        'p_ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)
        'p_TrueGrid = CType(p_ButtonEdit.Parent, U_TextBox.TrueDBGrid)
        'p_GridView = p_TrueGrid.Views(0)
        'p_Column = p_GridView.FocusedColumn
        'If p_Column.OptionsColumn.ReadOnly = True Then Exit Sub
        'If p_GridView.FocusedRowHandle < 0 Then
        '    p_GridView.AddNewRow()
        'End If
        'p_Gridview_Column_Button_Click(p_TrueGrid, _
        '                                               p_GridView, _
        '                                                g_Form, _
        '                                        g_Form.FormStatus, _
        '                                         p_ButtonOK, _
        '                                         p_Column,
        '                                          p_StrSQL, False)
        'If g_ChooseRecordFromSearch = True Then
        '    g_ValueType = 1

        '    If p_Column.Name <> "CHECKUPD" Then
        '        g_Form.FormStatus = True

        '        Try
        '            p_ItemBtn = g_Form.ButtonSave
        '        Catch ex As Exception

        '        End Try
        '        If p_ItemBtn.ToString.Trim <> "" Then
        '            p_ButtonArr = g_Form.Controls.Find(p_ItemBtn, True)
        '            If Not p_ButtonArr Is Nothing Then
        '                p_ButtonOK = p_ButtonArr(0)
        '                p_ButtonOK.Text = g_Form.CaptionUpd
        '            End If
        '        End If
        '        p_DataRow = p_GridView.GetDataRow(p_GridView.FocusedRowHandle)
        '        If Not p_DataRow Is Nothing Then
        '            If Not p_DataRow.Item("CHECKUPD") Is Nothing Then
        '                If p_DataRow.Item("CHECKUPD").ToString.Trim <> "I" And p_DataRow.Item("CHECKUPD").ToString.Trim <> "Y" Then
        '                    p_GridView.SetRowCellValue(p_GridView.FocusedRowHandle, "CHECKUPD", "Y")
        '                End If
        '            End If
        '        End If



        '    End If


        '    ' GridView_KeyPress()
        'End If

    End Sub

    Private Sub MenuNavigatorCilck(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Count As Integer
        Dim p_BindingCount As Integer
        Dim p_MenuIconIndex As ToolStripButton
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_MenuIcon As ToolStrip
        Dim p_TableName As String
        Dim p_Value As Integer
        ' Dim p_DatarowArr() As DataRow
        If p_BindingSourceKey.Columns.Count <= 0 Or p_BindingSourceName.Columns.Count <= 0 Then Exit Sub
        ' If Me.Loading = True Then Exit Sub
        If Me.FormStatus = True Then

            p_Value = Me.p_XtraModuleObj.ShowMessage(Me,
                                       "",
                    "Thông tin chưa được lưu. Bạn có muốn lưu lại không?",
                    True,
                    "Có",
                    True,
                    "Không",
                     True,
                    "Hủy",
                   2)
            Select Case p_Value
                Case 2 'Cancel  
                    Exit Sub
                Case 7  'No  khong luu



                    'g_LineRemove.Clear()
                    Me.pv_LineRemove.Clear()
                    Me.pv_TableEdit.Clear()
                    Me.FormStatus = False
                Case 6    'Yes
                    UpdateToDatabase(Me, Me.ButtonSave.ToString.Trim)
            End Select
            '  Exit Sub
        End If
        Me.g_RecodeMove = True
        p_MenuIconIndex = CType(sender, ToolStripButton)
        p_MenuIcon = p_MenuIconIndex.GetCurrentParent
        For p_Count = 0 To p_BindingSourceKey.Rows.Count - 1
            p_TableName = p_BindingSourceKey.Rows(p_Count).Item(0).ToString.Trim
            If p_TableName <> "" Then
                For p_BindingCount = 0 To p_BindingSourceName.Rows.Count - 1
                    If p_TableName = p_BindingSourceName.Rows(p_BindingCount).Item(0).ToString.Trim Then
                        p_Binding = p_BindingSourceControl(p_BindingCount)
                        If p_Value = 7 Then
                            p_Binding.CancelEdit()
                        End If
                        Select Case UCase(p_MenuIconIndex.Name)
                            Case UCase("mnuFirst")
                                p_Binding.MoveFirst()
                                p_MenuIconIndex.Enabled = False
                                p_MenuIcon.Items("mnuLast").Enabled = True
                                p_MenuIcon.Items("mnuPreviuos").Enabled = False
                                p_MenuIcon.Items("mnuNext").Enabled = True
                            Case UCase("mnuPreviuos")
                                p_Binding.MovePrevious()
                                If p_Binding.Position = 0 Then 'Ban ghi dau
                                    p_MenuIconIndex.Enabled = False
                                    p_MenuIcon.Items("mnuFirst").Enabled = False
                                    p_MenuIcon.Items("mnuLast").Enabled = True
                                    p_MenuIcon.Items("mnuNext").Enabled = True
                                Else
                                    p_MenuIcon.Items("mnuFirst").Enabled = True
                                    p_MenuIcon.Items("mnuLast").Enabled = True
                                    p_MenuIcon.Items("mnuNext").Enabled = True
                                End If
                            Case UCase("mnuNext")
                                p_Binding.MoveNext()
                                ' p_Binding.MovePrevious()
                                If p_Binding.Count - 1 = p_Binding.Position Then 'Ban ghi cuoi
                                    p_MenuIconIndex.Enabled = False
                                    p_MenuIcon.Items("mnuFirst").Enabled = True
                                    p_MenuIcon.Items("mnuLast").Enabled = False
                                    p_MenuIcon.Items("mnuPreviuos").Enabled = True
                                Else
                                    p_MenuIcon.Items("mnuFirst").Enabled = True
                                    p_MenuIcon.Items("mnuLast").Enabled = True
                                    p_MenuIcon.Items("mnuPreviuos").Enabled = True
                                End If
                            Case UCase("mnuLast")
                                p_Binding.MoveLast()
                                p_MenuIconIndex.Enabled = False
                                p_MenuIcon.Items("mnuFirst").Enabled = True
                                p_MenuIcon.Items("mnuPreviuos").Enabled = True
                                p_MenuIcon.Items("mnuNext").Enabled = False

                        End Select

                    End If
                Next
            End If
        Next
        'Public p_BindingSourceControl(15) As U_TextBox.U_BindingSource

        'Public p_NavigatorName As New DataTable("NavigatorName")

        'Public p_BindingSourceName As New DataTable("Sourcename")
        'Public p_BindingSourceKey As New DataTable("SourceKey")
        'Public p_BindingTableName As New DataTable("TableName")
        Me.g_RecodeMove = False
    End Sub


    'ANHQH
    '01/01/2012
    'Ham thuc hien kiem tra cac item bat buoc nhap ma khong co gia tri
    Public Function Check_Control_Required() As Boolean
        Dim p_Des As String

        Check_Control_Required = p_Check_Control_Required(Me, p_Des)

        If Check_Control_Required = False Then
            ShowMessageBox("", p_Des)
        End If
    End Function

    'Private Function p_Set_TrueGrid_Property_Page(ByVal p_Form As XtraCusForm1, ByVal p_Control As Object, ByVal p_requery As Boolean) As Boolean
    '    Throw New NotImplementedException
    'End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.cusStatusLabel1.Visible = True Then
            If Me.cusStatusLabel1.ToolTipText <> "" Then
                If CInt(Me.cusStatusLabel1.ToolTipText) > 0 Then
                    Me.cusStatusLabel1.ToolTipText = CInt(Me.cusStatusLabel1.ToolTipText) - 1
                    'Me.ToolStripStatusLabel1.Text = Now.Second.ToString
                Else
                    cusStatusLabel1.ForeColor = Drawing.Color.Black
                    cusStatusLabel1.Text = ""

                End If
            End If
        End If
    End Sub



    Public Sub FormSetValueToSource(ByVal p_TableName As String, ByVal p_TableID As String)
        SetValueToSource(p_TableName, p_TableID)

    End Sub
End Class