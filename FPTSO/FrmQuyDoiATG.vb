Imports Microsoft.VisualBasic.Strings

Public Class FrmBarem

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_NhietDoTT As Decimal = 0
        Dim p_TyTrong As Decimal = 0
        Dim p_ThucXuat As Decimal = 0
        Dim p_SQL As String
        Dim p_Datable As DataTable
        Dim p_ChieuCaoDau As Decimal = 0
        Dim p_Vcf As String
        Dim p_TankCode As String = ""
        If Not TankHeight.EditValue Is Nothing Then
            Decimal.TryParse(TankHeight.EditValue.ToString, p_ChieuCaoDau)
        End If

        'exec(FPT_GetBaremTankATG_QCI) 'B030','0.0','0',8575


        If Not Me.TankCode.EditValue Is Nothing Then
            p_TankCode = Me.TankCode.EditValue.ToString.Trim
        End If


        If Not NhietDo.EditValue Is Nothing Then
            Decimal.TryParse(NhietDo.EditValue.ToString, p_NhietDoTT)
        End If
        If Not TyTrong.EditValue Is Nothing Then
            Decimal.TryParse(TyTrong.EditValue.ToString, p_TyTrong)
        End If

        Me.VCF.EditValue = 0
        Me.L15.EditValue = 0
        Me.KG.EditValue = 0
        Me.ThucXuat.EditValue = 0

        If p_NhietDoTT = 0 Then
            p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_TankCode & "','0.0','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
        Else
            p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_TankCode & "','" & Math.Round(p_NhietDoTT, 4) & "','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
        End If

        p_Datable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datable Is Nothing Then
            Me.VCF.EditValue = p_Datable.Rows(0).Item("VCF")
            Me.L15.EditValue = p_Datable.Rows(0).Item("L15")
            Me.KG.EditValue = p_Datable.Rows(0).Item("Kg")
            Me.ThucXuat.EditValue = p_Datable.Rows(0).Item("Ltt")
        End If


        Exit Sub

        If Not ThucXuat.EditValue Is Nothing Then
            Decimal.TryParse(ThucXuat.EditValue.ToString, p_ThucXuat)
        End If

        p_SQL = "select dbo.zzFPT_mdlQCI_GetVCF_NS ('" & Math.Round(p_NhietDoTT, 4) & "','" & Math.Round(p_TyTrong, 4) & "' ) as VCF"
        p_Datable = GetDataTable(p_SQL, p_SQL)

        Me.VCF.EditValue = 0
        If Not p_Datable Is Nothing Then
            If p_Datable.Rows.Count > 0 Then
                Me.VCF.EditValue = p_Datable.Rows(0).Item(0)
            End If
        End If


        p_SQL = "exec dbo.zzFPT_mdlQCI_CalculateQCI_NS_QC " & _
              p_ThucXuat & "," & _
              "'L'," & _
              p_NhietDoTT & "," & p_TyTrong & ",'','' "
        p_Datable = GetDataTable(p_SQL, p_SQL)
        ' p_Vcf = ""
        Me.L15.EditValue = 0
        If Not p_Datable Is Nothing Then
            If p_Datable.Rows.Count > 0 Then
                Me.L15.EditValue = p_Datable.Rows(0).Item(1)
                Me.KG.EditValue = p_Datable.Rows(0).Item(3)
                'p_Vcf = Mid(p_Datable.Rows(0).Item(0).ToString.Trim, 1, 6)
            End If
        End If


    End Sub

    Public Sub Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_SQL As String = ""
        Dim p_Client As String = ""
        p_SQL = "select Name_nd as MaBe, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                           " a where  a.Mahanghoa =b.Product_nd "

        p_Column1 = Me.GridView1.Columns.Item(0)
        p_Column1.SQLString = p_SQL
        p_Column1.ButtonClick = True
        Me.Gridview_Column_Button_Click(sender, e)
        p_Column1.ButtonClick = False
    End Sub



    Private Sub FrmQhuyDoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Count As Integer
        Dim p_column1 As U_TextBox.GridColumn
        p_SQL = "select convert(nvarchar(50),'') as MaBe, convert(nvarchar(50),'') as MaHang, 0 as CCaoDau, 0.0 as NhietDo, 0.0 as TyTrong " &
                ", 0.0 as VCF, 0 as Ltt,0 as L15, 0 as KG "
        p_Table = GetDataTable(p_SQL, p_SQL)
        p_Binding.DataSource = p_Table
        Me.TrueDBGrid1.DataSource = p_Binding
        'Me.GridView1.Columns(0).fie
        For p_Count = 0 To p_Table.Columns.Count - 1
            Me.GridView1.Columns(p_Count).FieldName = p_Table.Columns(p_Count).ColumnName.ToString.Trim
        Next


        p_column1 = Me.GridView1.Columns.Item(0)

        Dim p_ColTypeButtonEdit As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        p_ColTypeButtonEdit = p_column1.ColumnEdit
        AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click
        ForMatColumn("CCaoDau")
        ForMatColumn("NhietDo")
        ForMatColumn("TyTrong")
        ForMatColumn("VCF")
        ForMatColumn("Ltt")
        ForMatColumn("L15")
        ForMatColumn("KG")
    End Sub



    Private Sub ForMatColumn(p_ColumnName As String)
        
        Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        Dim p_NumberFormat As String = "############"

        Dim p_Column As U_TextBox.GridColumn
        Dim p_Digit As Integer
        'On Error Resume Next

        p_Column = Me.GridView1.Columns.Item(p_ColumnName)
        p_Digit = p_Column.NumberDecimal


        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

        ' If p_Column.ShowCalc = False Then
        p_ColNumber.Buttons(0).Visible = False
        'End If

        Try
            If p_Digit > 0 Then
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Digit - 1) & "0"
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Digit - 1) & "0"
                p_Column.ColumnEdit = p_ColNumber


                p_Column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Digit - 1) & "0"
            Else
                p_ColNumber.DisplayFormat.FormatString = "#,###0."
                p_ColNumber.EditMask = "#,###,###,###0."
                p_Column.ColumnEdit = p_ColNumber

                p_Column.DisplayFormat.FormatString = "#,###0."
            End If
        Catch ex As Exception
            p_Column.DisplayFormat.FormatString = "#,###0."
        End Try


    End Sub

    Private Sub TrueDBGrid1_Click(sender As System.Object, e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub



    Private Sub GridView1_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim p_Coulumn As U_TextBox.GridColumn
        Dim p_MaBe As String = ""
        Dim p_ChieuCaoDau As Double = 0
        Dim p_NhietDo As Double = 0
        Dim p_Datable As DataTable
        Dim p_SQL As String = ""
        Dim p_TyTrong As Double = 0
        Dim p_Row As DataRow
        p_Coulumn = Me.GridView1.FocusedColumn
        If UCase(p_Coulumn.FieldName.ToString.Trim) = UCase("CCaoDau") Or UCase(p_Coulumn.FieldName.ToString.Trim) = UCase("NhietDo") _
                    Or UCase(p_Coulumn.FieldName.ToString.Trim) = UCase("TyTrong") Then

            p_Row = Me.GridView1.GetFocusedDataRow
            If Not p_Row Is Nothing Then
                p_MaBe = p_Row.Item("MaBe").ToString.Trim

                Select Case UCase(p_Coulumn.FieldName.ToString.Trim)
                    Case UCase("CCaoDau")
                        p_ChieuCaoDau = e.Value
                        Double.TryParse(p_Row.Item("NhietDo").ToString.Trim, p_NhietDo)
                        Double.TryParse(p_Row.Item("TyTrong").ToString.Trim, p_TyTrong)
                    Case UCase("NhietDo")
                        Double.TryParse(p_Row.Item("CCaoDau").ToString.Trim, p_ChieuCaoDau)
                        p_NhietDo = e.Value
                        Double.TryParse(p_Row.Item("TyTrong").ToString.Trim, p_TyTrong)
                    Case Else
                        Double.TryParse(p_Row.Item("CCaoDau").ToString.Trim, p_ChieuCaoDau)
                        Double.TryParse(p_Row.Item("NhietDo").ToString.Trim, p_NhietDo)
                        p_TyTrong = e.Value
                End Select

                

                If p_NhietDo = 0 Then
                    p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_MaBe & "','0.0','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
                Else
                    p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_MaBe & "','" & Math.Round(p_NhietDo, 4) & "','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
                End If

                p_Datable = GetDataTable(p_SQL, p_SQL)
                If Not p_Datable Is Nothing Then
                    If p_Datable.Rows.Count > 0 Then
                        p_Row.Item("VCF") = p_Datable.Rows(0).Item("VCF")
                        p_Row.Item("L15") = p_Datable.Rows(0).Item("L15")
                        p_Row.Item("KG") = p_Datable.Rows(0).Item("Kg")
                        p_Row.Item("Ltt") = p_Datable.Rows(0).Item("Ltt")
                    Else
                        p_Row.Item("VCF") = 0
                        p_Row.Item("L15") = 0
                        p_Row.Item("KG") = 0
                        ' p_Row.Item("Ltt") = p_Datable.Rows(0).Item("Ltt")
                    End If
                End If


            End If
        End If
    End Sub
End Class