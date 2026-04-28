
Imports System.Threading

Public Class FrmAutoCheck
    Private p_LeadTime As Integer = 150000
    Private p_Threading As Thread  '' New Thread(AddressOf GetAuto)
    Private p_Threading_Show As Thread   ' As New Thread(AddressOf ShowSoLenh)
    Private p_Run As Boolean = False

    Private m_Thread As Thread
    'Private p_Binding As New U_TextBox.U_BindingSource
    Private p_Datatable_Ins As New DataTable
    Private p_Datatable_Ins2 As New DataTable
    Private p_Binding11 As New U_TextBox.U_BindingSource
    Private Sub AutoTimer_Tick(sender As System.Object, e As System.EventArgs) Handles AutoTimer.Tick

        ' p_Threading.ToStrin()

        'GetAuto()
        ' End If
        Try
            ShowSoLenh()
        Catch ex As Exception
            'p_Threading_Show.Abort()
        End Try
        ' p_Threading.Start()
    End Sub

    Private Sub ShowSoLenh()

        Dim p_Count As Integer
        Dim p_SQLErr As String = ""

        Dim p_NgayXuat As Date = Now.Date
        Dim p_Datatable As DataTable

        Dim p_SQL As String = ""
        Dim p_Eror As String = ""
        Dim p_SoLenh As String = ""
        Dim p_LoaiHinhVanChuyen As String = ""
        '' Dim p_Binding11 As New U_TextBox.U_BindingSource
        'Dim p_Row As DataRow
        'Dim p_Col_In As Integer


        If Not Me.NgayXuat.EditValue Is Nothing Then
            If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                p_NgayXuat = Me.NgayXuat.EditValue
            End If

        End If


        ' If Not p_NgayXuat Is Nothing Then
        p_SQL = "exec FPT_GetAutoLenh '" & p_NgayXuat.ToString("MM-dd-yyyy") & "'"

        p_Datatable = GetDataTable(p_SQL, p_SQL)

        p_Binding11.DataSource = p_Datatable
        Me.TrueDBGrid1.DataSource = p_Binding11
      
    End Sub

    'Private Sub GetAuto()
    '    Dim p_Count As Integer
    '    Dim p_SQLErr As String = ""

    '    Dim p_NgayXuat As Date = Now.Date
    '    Dim p_Datatable As DataTable

    '    Dim p_SQL As String = ""
    '    Dim p_Eror As String = ""
    '    Dim p_SoLenh As String = ""
    '    Dim p_LoaiHinhVanChuyen As String = ""
    '    ' Dim p_Binding11 As New U_TextBox.U_BindingSource
    '    Dim p_Row As DataRow
    '    Dim p_Col_In As Integer
    '    Dim p_Row_In As Integer
    '    Try '
    '        'p_Run = True

    '        'If (m_Thread.ThreadState And ThreadState.Unstarted) <>  0 Then
    '        '    ' The thread has never been started. Start it.
    '        '    p_Threading.Start()
    '        'Else
    '        '    ' The thread is paused. Resume it.
    '        '    p_Threading.Resume()
    '        'End If

    '        While 1 = 1
    '            ' p_Threading.Start()
    '            'Me.Cursor = Cursors.WaitCursor
    '            If Not Me.NgayXuat.EditValue Is Nothing Then
    '                If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
    '                    p_NgayXuat = Me.NgayXuat.EditValue
    '                End If

    '            End If


    '            ' If Not p_NgayXuat Is Nothing Then
    '            p_SQL = "exec FPT_GetAutoLenh '" & p_NgayXuat.ToString("MM-dd-yyyy") & "'"

    '            p_Datatable = GetDataTable(p_SQL, p_SQL)
    '            p_Datatable_Ins = p_Datatable.Clone

    '            '  p_Binding.DataSource = p_Datatable_Ins
    '            '  Me.TrueDBGrid1.DataSource = p_Binding

    '            If Not p_Datatable Is Nothing Then
    '                Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
    '                For p_Count = p_Datatable.Rows.Count - 1 To 0 Step -1
    '                    p_SoLenh = p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim
    '                    p_LoaiHinhVanChuyen = p_Datatable.Rows(p_Count).Item("MavanChuyen").ToString.Trim
    '                    p_SQLErr = p_SAP_Obj.AutoClsScadarToHTTG("in", p_SoLenh, p_LoaiHinhVanChuyen, g_Terminal, True, g_E5)

    '                    'If p_SoLenh = "2023289926" Then
    '                    '    p_SoLenh = p_SoLenh
    '                    'End If
    '                    If p_SQLErr.ToString.Trim <> "" Then
    '                        ' ShowMessageBox("", p_SQLErr)
    '                        'p_Datatable.Rows.RemoveAt(p_Count)
    '                    Else
    '                        p_Row = p_Datatable_Ins.NewRow
    '                        For p_Col_In = 0 To p_Datatable.Columns.Count - 1
    '                            p_Row.Item(p_Col_In) = p_Datatable.Rows(p_Count).Item(p_Col_In).ToString.Trim
    '                        Next
    '                        p_Datatable_Ins.Rows.Add(p_Row)
    '                        ' p_Binding.DataSource = p_Datatable_Ins
    '                        p_Binding11.DataSource = p_Datatable_Ins
    '                        ' FrmAutoCheck.TrueDBGrid1.DataSource = p_Binding
    '                        Try
    '                            ' Me.TrueDBGrid1.DataSource = p_Binding
    '                        Catch ex As Exception

    '                        End Try

    '                    End If
    '                Next
    '                'p_Datatable.AcceptChanges()
    '                ' p_Binding.DataSource = p_Datatable
    '                'Me.TrueDBGrid1.DataSource = p_Binding
    '            End If
    '            'Me.Cursor = Cursors.Default
    '            '  p_Run = False
    '            ' p_Threading.Abort()
    '            p_Threading.Sleep(p_LeadTime)
    '        End While

    '    Catch ex As Exception

    '        MsgBox(ex.Message)
    '        p_Threading.Abort()
    '        p_Threading = Nothing
    '        ' p_Run = False
    '        ' Me.Cursor = Cursors.Default
    '    End Try


    'End Sub

    Private Sub FrmAutoCheck_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Dim p_SQLErr As String = ""

        Dim p_NgayXuat As Date = Now.Date
        Dim p_Datatable As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_SQLErr As String = ""

        '  Dim p_Datatable As DataTable

        Dim p_SQL As String = ""
        Try
            p_SQL = "select * from sys_config where KeyCode='AUTOTIME'"
            p_Datatable = GetDataTable(p_SQL, p_SQLErr)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    Integer.TryParse(p_Datatable.Rows(0).Item("KeyValue").ToString.Trim, p_LeadTime)
                End If
            End If
        Catch ex As Exception

        End Try
        If p_LeadTime <= 0 Then
            p_LeadTime = 150000
        End If
        ' Me.AutoTimer.Interval = p_LeadTime
        Me.NgayXuat.EditValue = Now.Date
        'Me.AutoTimer.Enabled = True


        Try
            'Me.Cursor = Cursors.WaitCursor
            If Not Me.NgayXuat.EditValue Is Nothing Then
                If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                    p_NgayXuat = Me.NgayXuat.EditValue
                End If

            End If

            ShowSoLenh()

            '' If Not p_NgayXuat Is Nothing Then
            'p_SQL = "exec FPT_GetAutoLenh '20000101'"

            'p_Datatable_Ins = GetDataTable(p_SQL, p_SQL)
            ''p_Datatable_Ins = p_Datatable.Clone

            ' p_Binding.DataSource = p_Datatable_Ins
            'Me.TrueDBGrid1.DataSource = p_Binding

            ''If p_Run = False Then

            'p_Threading.Sleep(p_LeadTime)

            'p_Threading.Start()

            'Me.AutoTimer.Interval = p_LeadTime
            ''Me.NgayXuat.EditValue = Now.Date
            'Me.AutoTimer.Enabled = True

            'DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = True

            'p_Threading = New Thread(AddressOf GetAuto)

            '' Make this a background thread so it automatically
            '' ends when the form's thread ends.
            'p_Threading.IsBackground = True
            'p_Threading.Start()
            
            'p_Threading_Show = New Thread(AddressOf ShowSoLenh)
            'p_Threading_Show.IsBackground = True
            'p_Threading_Show.Start()
            ''End If
            ' GetAuto()
            ' Me.GridView1.OptionsBehavior.ReadOnly = True

            ' p_Threading_Show.Start()

            Me.AutoTimer.Interval = p_LeadTime
            'Me.NgayXuat.EditValue = Now.Date
            'Me.AutoTimer.Enabled = True


        Catch ex As Exception
            'p_Threading.Abort()
        End Try

    End Sub


    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_DataRow As DataRow

        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                Dim FrmLenhXuatAdd As New FrmGhiNhanThucXuat
                FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
                'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
                FrmLenhXuatAdd.g_FormAddnew = False
                FrmLenhXuatAdd.FormStatus = False
                FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
                FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
                FrmLenhXuatAdd.g_SoLenh_Q = p_DataRow.Item("SoLenh").ToString.Trim
                FrmLenhXuatAdd.DefaultWhere = " WHERE SoLenh='" & p_DataRow.Item("SoLenh").ToString.Trim & "'"
                FrmLenhXuatAdd.ShowDialog(Me)

            End If
        End If
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        ShowSoLenh()
    End Sub
End Class