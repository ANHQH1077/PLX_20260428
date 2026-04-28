Public Class FrmQuanLySoLenh22

    Private p_SQLString As String = ""
    Public p_ObjSearchReturn(0 To 10) As String
    Public p_ChooseRecord As Object
    Public p_ColumnWidth(0 To 100) As Integer   'Danh sach do rong cua cac Column neu co

    Private Fpt_SQLString As String = ""  'SQL show
    Public Fpt_Object As Object   'Object gọi form Searchs
    Private Fpt_B1Get As Boolean = False   'Fpt_B1Get=true: lay tren B1,  Fpt_B1Get=False: lấy trên FPTCUSTOMIZE
    Private Fpt_Row_ID As Integer = 0   'Dòng thứ i mà gọi Form Search
    ' Private Fpt_Column_ID As Integer = 0  

    Private Fpt_PageNum As Integer = 1  'Page cần lấy dữ liệu

    Public p_CFLColumnHide As String = ""

    Private p_RollTerminal As String



    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Fpt_PageNum = 1

        p_Search()

    End Sub


    '==============================================================================
    Private Sub p_QuerySource(ByVal p_LoadForm As Boolean, Optional ByVal p_CardNum As String = "")
        Dim p_DesError As String = ""
        'Dim p_SQLString As String = ""
        Dim p_where As String = ""
        Dim p_Count As Integer
        Dim p_SoLenh As String
        Dim p_Date As Date
        Dim p_ColumnKey As String
        Dim p_View As String

        Try
            If Not Me.SoLenh.EditValue Is Nothing Then
                If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                    p_where = "SoLenh='" & Me.SoLenh.EditValue.ToString.Trim & "'"
                End If
            End If
            If Not Me.U_DateEdit1.EditValue Is Nothing Then
                If Me.U_DateEdit1.EditValue.ToString.Trim <> "" Then
                    p_Date = Me.U_DateEdit1.EditValue
                    If p_where = "" Then
                        p_where = "NgayXuat='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                    Else
                        p_where = p_where & " and NgayXuat='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                    End If
                End If
            End If


            If g_Filter_Terminal = True Then
                If p_RollTerminal.ToString.Trim <> "" Then
                    If p_where <> "" Then
                        p_where = p_where & " AND CHARINDEX (  ',' + Client + ',','," & p_RollTerminal & ",',1)>0 "
                    Else
                        p_where = " CHARINDEX (  ',' + Client + ',','," & p_RollTerminal & ",',1)>0 "
                    End If
                Else
                    If p_where <> "" Then
                        p_where = p_where & " AND Client ='" & g_Terminal & "' "
                    Else
                        p_where = "  Client ='" & g_Terminal & "' "
                    End If
                End If
            End If

            If Me.U_CheckBox1.Checked = True Then
                If p_where <> "" Then
                    p_where = p_where & " AND  Status  in  ('3','31') "
                Else
                    p_where = " Status  in  ('3','31') "
                End If
            End If

            If p_CardNum <> "" Then
                If p_where <> "" Then
                    p_where = p_where & " AND  ( CardNum  ='" & p_CardNum & "'  or   CardData  ='" & p_CardNum & "' ) "
                Else
                    p_where = " (CardNum  ='" & p_CardNum & "'   or   CardData  ='" & p_CardNum & "') "
                End If
            End If

            If p_where <> "" Then
                p_where = p_where & "  AND isnull(CardNum,'') <>'' "
            Else
                p_where = "1=0"
            End If

            Me.GridView1.Where = p_where
            Me.DefaultFormLoad = True
            Me.LoadDataToForm()
            Me.DefaultFormLoad = False

            Me.CardCode.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_DataRow As DataRow

        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                'If p_DataRow.Item("Status").ToString.Trim = "3" Or p_DataRow.Item("Status").ToString.Trim = "31" _
                '        Or p_DataRow.Item("Status").ToString.Trim = "4" Or p_DataRow.Item("Status").ToString.Trim = "5" Then
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

                Me.DefaultFormLoad = True
                Me.LoadDataToForm()
                Me.DefaultFormLoad = False

                '   End If

                'End If
            End If
        End If
    End Sub

    Sub p_Search()
        'If Not Me.SoLenh.EditValue Is Nothing Then
        '    If Me.SoLenh.EditValue.ToString <> "" Or Me.GridView1.RowCount > 0 Then
        '        Me.Cursor = Cursors.WaitCursor
        '        p_QuerySource(False)
        '        Me.Cursor = Cursors.Default
        '    Else
        '        MsgBox("Giá trị tìm kiếm không được trống")
        '    End If
        'Else
        '    MsgBox("Giá trị tìm kiếm không được trống")
        'End If

        Me.Cursor = Cursors.WaitCursor
        p_QuerySource(False)

        Me.GridView1.BestFitColumns()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SoLenh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardCode.EditValueChanged

    End Sub

    Private Sub SoLenh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CardCode.KeyDown
        Dim p_CardCode As String = ""
        If e.KeyCode = Keys.Enter Then
            If Not Me.CardCode.EditValue Is Nothing Then
                p_CardCode = Me.CardCode.EditValue.ToString.Trim
            End If
            p_QuerySource(False, p_CardCode)
            Me.CardCode.EditValue = ""

        End If
    End Sub

    Private Sub FrmQuanLySoLenh22_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.U_CheckBox1.Checked = True

        Dim p_ButtonEdit As U_TextBox.U_ButtonEdit = Nothing
        Dim p_Control() As Object
        Dim p_SQL As String

        Dim p_Databale As DataTable

        p_SQL = "select * from sys_user where user_id=" & g_User_ID
        p_Databale = GetDataTable(p_SQL, p_SQL)
        p_RollTerminal = ""


        If Not p_Databale Is Nothing Then
            If p_Databale.Rows.Count > 0 Then
                p_RollTerminal = p_Databale.Rows(0).Item("Terminal").ToString.Trim
            End If
        End If

        Try

            Me.U_DateEdit1.EditValue = Now.Date

            Me.GridView1.OptionsBehavior.AllowAddRows = False


            'p_ChooseRecord.editvalue = "N"

            p_QuerySource(True)
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.GridView1.Columns.Item("Status").Visible = True
        Catch ex As Exception

        End Try

    End Sub
End Class