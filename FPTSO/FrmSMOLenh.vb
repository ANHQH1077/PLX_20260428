Public Class FrmSMOLenh
    Private pv_Left As Integer = 0
    Private pv_Top As Integer = 0
    Private pv_Height As Integer = 0
    Private pv_Width As Integer = 0
    Private p_MainForm As Object

    Private Sub FrmSMOLenh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        ' Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        Me.Left = pv_Left + pv_Width - Me.Width
        Me.Top = pv_Top + pv_Height - Me.Height

        Me.SoTichKe.Focus()
        p_SQL = "select Convert(date,Getdate()) as dDate "
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Me.NgayXuat.EditValue = CDate(p_DataTable.Rows(0).Item(0))
            End If
        End If
    End Sub

    Private Sub SoTichKe_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoTichKe.EditValueChanged

    End Sub

    Public Sub LoadData()
        Dim p_SQL As String
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        Dim p_TichKe As String = ""
        Dim p_NgayTichKe As String = ""
        Dim p_COunt As Integer
        Dim p_Column As U_TextBox.GridColumn
        If Not Me.SoTichKe.EditValue Is Nothing Then
            p_TichKe = Me.SoTichKe.EditValue.ToString.Trim
        End If
        If Not Me.NgayXuat.EditValue Is Nothing Then
            p_NgayTichKe = CDate(NgayXuat.EditValue).ToString("yyyyMMdd")
        End If

        If p_TichKe <> "" And p_NgayTichKe <> "" Then
            p_SQL = "exec GetSMOLenhXuat '" & p_TichKe & "' , '" & p_NgayTichKe & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                p_Binding.DataSource = p_DataTable
                Me.TrueDBGrid3.DataSource = p_Binding
                For p_COunt = 0 To Me.GridView3.Columns.Count - 1
                    p_Column = Me.GridView3.Columns.Item(p_COunt)
                    If p_Column.FieldView.ToString.Trim <> "" Then
                        p_Column.FieldName = p_Column.FieldView
                    End If

                Next
            End If
            Me.TrueDBGrid3.Focus()
        Else
            ShowMessageBox("", "Giá trị không hợp lệ")
        End If
    End Sub
    Private Sub SoTichKe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SoTichKe.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadData()
        End If
    End Sub

    Public Sub New(ByVal p_Top As Integer, ByVal p_Left As Integer, ByVal p_Height As Integer, ByVal p_Width As Integer)

        pv_Top = p_Top
        pv_Left = p_Left
        pv_Height = p_Height
        pv_Width = p_Width
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DoubleClick()
        Dim p_Row As DataRow
        Dim p_SoLenh As String = ""
        Dim p_Controls() As Windows.Forms.Control
        p_Row = Me.GridView3.GetFocusedDataRow
        Dim p_Edit As U_TextBox.U_TextBox
        If Not p_Row Is Nothing Then
            p_SoLenh = p_Row.Item("SoLenh").ToString.Trim
            Dim frmCollection As New FormCollection()
            frmCollection = Application.OpenForms()
            If Not frmCollection.Item("FrmGhiNhanThucXuat") Is Nothing Then
                If frmCollection.Item("FrmGhiNhanThucXuat").IsHandleCreated Then
                    p_MainForm = frmCollection.Item("FrmGhiNhanThucXuat")
                    p_MainForm.KeyF5()

                    p_Controls = p_MainForm.Controls.Find("SoLenh", True)
                    If p_Controls.Length > 0 Then
                        p_Edit = CType(p_Controls(0), U_TextBox.U_TextBox)
                        p_Edit.EditValue = p_SoLenh
                        p_MainForm.ReloadSoLenh()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub GridView3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.DoubleClick
        DoubleClick()
    End Sub

    Private Sub GridView3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView3.KeyDown
        If e.KeyCode = Keys.Enter Then
            DoubleClick()
        End If
    End Sub
End Class