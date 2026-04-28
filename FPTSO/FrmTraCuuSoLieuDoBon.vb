Imports Microsoft.VisualBasic.Strings

Public Class FrmTraCuuSoLieuDoBon
    Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim p_NhietDoTT As Decimal = 0
        'Dim p_TyTrong As Decimal = 0
        'Dim p_ThucXuat As Decimal = 0
        'Dim p_SQL As String
        'Dim p_Datable As DataTable
        'Dim p_ChieuCaoDau As Decimal = 0
        'Dim p_Vcf As String
        'Dim p_TankCode As String = ""
        'If Not TankHeight.EditValue Is Nothing Then
        '    Decimal.TryParse(TankHeight.EditValue.ToString, p_ChieuCaoDau)
        'End If

        ''exec(FPT_GetBaremTankATG_QCI) 'B030','0.0','0',8575


        'If Not Me.TankCode.EditValue Is Nothing Then
        '    p_TankCode = Me.TankCode.EditValue.ToString.Trim
        'End If


        'If Not NhietDo.EditValue Is Nothing Then
        '    Decimal.TryParse(NhietDo.EditValue.ToString, p_NhietDoTT)
        'End If
        'If Not TyTrong.EditValue Is Nothing Then
        '    Decimal.TryParse(TyTrong.EditValue.ToString, p_TyTrong)
        'End If

        'Me.VCF.EditValue = 0
        'Me.L15.EditValue = 0
        'Me.KG.EditValue = 0
        'Me.ThucXuat.EditValue = 0

        'If p_NhietDoTT = 0 Then
        '    p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_TankCode & "','0.0','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
        'Else
        '    p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_TankCode & "','" & Math.Round(p_NhietDoTT, 4) & "','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
        'End If

        'p_Datable = GetDataTable(p_SQL, p_SQL)
        'If Not p_Datable Is Nothing Then
        '    Me.VCF.EditValue = p_Datable.Rows(0).Item("VCF")
        '    Me.L15.EditValue = p_Datable.Rows(0).Item("L15")
        '    Me.KG.EditValue = p_Datable.Rows(0).Item("Kg")
        '    Me.ThucXuat.EditValue = p_Datable.Rows(0).Item("Ltt")
        'End If


        'Exit Sub

        'If Not ThucXuat.EditValue Is Nothing Then
        '    Decimal.TryParse(ThucXuat.EditValue.ToString, p_ThucXuat)
        'End If

        'p_SQL = "select dbo.zzFPT_mdlQCI_GetVCF_NS ('" & Math.Round(p_NhietDoTT, 4) & "','" & Math.Round(p_TyTrong, 4) & "' ) as VCF"
        'p_Datable = GetDataTable(p_SQL, p_SQL)

        'Me.VCF.EditValue = 0
        'If Not p_Datable Is Nothing Then
        '    If p_Datable.Rows.Count > 0 Then
        '        Me.VCF.EditValue = p_Datable.Rows(0).Item(0)
        '    End If
        'End If


        'p_SQL = "exec dbo.zzFPT_mdlQCI_CalculateQCI_NS_QC " & _
        '      p_ThucXuat & "," & _
        '      "'L'," & _
        '      p_NhietDoTT & "," & p_TyTrong & ",'','' "
        'p_Datable = GetDataTable(p_SQL, p_SQL)
        '' p_Vcf = ""
        'Me.L15.EditValue = 0
        'If Not p_Datable Is Nothing Then
        '    If p_Datable.Rows.Count > 0 Then
        '        Me.L15.EditValue = p_Datable.Rows(0).Item(1)
        '        Me.KG.EditValue = p_Datable.Rows(0).Item(3)
        '        'p_Vcf = Mid(p_Datable.Rows(0).Item(0).ToString.Trim, 1, 6)
        '    End If
        'End If


    End Sub




    Private Sub FrmTraCuuSoLieuDoBon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TankList.SqlString = "select Name_nd, TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >=  FromDate  and getdate ()  <= ToDate  and Name_nd = a.Name_nd and Product_nd = a.Product_nd )  as NhomBeXuat from fpt_tblTank_v a  where " & _
                         " charindex(a.client,(select  isnull(Terminal,'') from " & _
                         " sys_user where upper(user_name)=upper('" & g_UserName & "')),1)>0"
        'Dim p_SQL As String = ""
        'Dim p_Table As DataTable
        'Dim p_Binding As New U_TextBox.U_BindingSource
        'Dim p_Count As Integer
        'Dim p_column1 As U_TextBox.GridColumn
        'p_SQL = "select convert(nvarchar(50),'') as MaBe, convert(nvarchar(50),'') as MaHang, 0 as CCaoDau, 0.0 as NhietDo, 0.0 as TyTrong " &
        '        ", 0.0 as VCF, 0 as Ltt,0 as L15, 0 as KG "
        'p_Table = GetDataTable(p_SQL, p_SQL)
        'p_Binding.DataSource = p_Table
        'Me.TrueDBGrid1.DataSource = p_Binding
        ''Me.GridView1.Columns(0).fie
        'For p_Count = 0 To p_Table.Columns.Count - 1
        '    Me.GridView1.Columns(p_Count).FieldName = p_Table.Columns(p_Count).ColumnName.ToString.Trim
        'Next


        'p_column1 = Me.GridView1.Columns.Item(0)

        'Dim p_ColTypeButtonEdit As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        'p_ColTypeButtonEdit = p_column1.ColumnEdit
        'AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click
        'ForMatColumn("CCaoDau")
        'ForMatColumn("NhietDo")
        'ForMatColumn("TyTrong")
        'ForMatColumn("VCF")
        'ForMatColumn("Ltt")
        'ForMatColumn("L15")
        'ForMatColumn("KG")
        Dim p_column1 As U_TextBox.GridColumn
        p_column1 = Me.GridView1.Columns.Item(0)

        Dim p_ColTypeButtonEdit As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        p_ColTypeButtonEdit = p_column1.ColumnEdit
        AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click

        TimKiem(True)

        Me.ControlResize = True

        'Me.ControlResize = True
        FindAllControls(Me)

        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        '    TimKiem()
    End Sub


    Public Sub Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_SQL As String = ""
        Dim p_Client As String = ""
        Dim p_Row As DataRow
        If Me.GridView1.RowCount > 0 Then
            p_Row = Me.GridView1.GetFocusedDataRow
            If Not p_Row Is Nothing Then
                If p_Row.Item("TankHeaderCode").ToString.Trim <> "" Then
                    Exit Sub
                End If

            End If
        End If
        'p_SQL = "select Name_nd as MaBe, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
        '                   " a where  a.Mahanghoa =b.Product_nd "
        p_SQL = "select Name_nd as MaBe, Product_nd as Product_nd, a.TenHangHoa,  (select top 1 TankGroup  from tblTankGroup where  getdate() >=  FromDate  and getdate ()  <= ToDate  and Name_nd = b.Name_nd and Product_nd = b.Product_nd )    as NhomBeXuat " & _
                 " from fpt_tblTank_v b,tblHangHoa a where  a.Mahanghoa =b.Product_nd " & _
       " and charindex (Client ,(select top 1 Terminal from SYS_USER  where upper(user_name)=upper('" & g_UserName & "') ),1) >0"
        p_Column1 = Me.GridView1.Columns.Item(0)
        p_Column1.SQLString = p_SQL
        p_Column1.ButtonClick = True
        Me.Gridview_Column_Button_Click(sender, e)
        p_Column1.ButtonClick = False
    End Sub


    Private Sub ForMatColumn(ByVal p_ColumnName As String)

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

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim p_Coulumn As U_TextBox.GridColumn
        Dim p_MaBe As String = ""
        Dim p_ChieuCaoDau As Double = 0
        Dim p_NhietDo As Double = 0
        Dim p_Datable As DataTable
        Dim p_SQL As String = ""
        Dim p_TyTrong As Double = 0
        Dim p_Date As String = ""
        Dim p_Row As DataRow
        p_Coulumn = Me.GridView1.FocusedColumn
        Dim p_TankCode As String = ""
        Dim p_WCF As Double = 0

        'TankHeight
        'TankTemp
        'Dens
        'Ltt
        'VCF
        'VolumnL15
        'WCF
        'VolumnKG
        If UCase(p_Coulumn.FieldName.ToString.Trim) = UCase("TankCode") Or UCase(p_Coulumn.FieldName.ToString.Trim) = UCase("FromDate") Then
            p_Row = Me.GridView1.GetFocusedDataRow
            If Not p_Row Is Nothing Then
                p_Date = ""
                Try
                    If UCase(p_Coulumn.FieldName.ToString.Trim) = UCase("FromDate") Then
                        p_Date = CDate(e.Value.ToString.Trim)
                    Else
                        p_Date = p_Row.Item("FromDate").ToString.Trim
                    End If
                Catch ex As Exception

                End Try
                p_TankCode = ""
                Try
                    If UCase(p_Coulumn.FieldName.ToString.Trim) = UCase("TankCode") Then
                        p_TankCode = e.Value.ToString.Trim
                    Else
                        p_TankCode = p_Row.Item("TankCode").ToString.Trim
                    End If
                Catch ex As Exception

                End Try

                If p_Date <> "" And p_TankCode <> "" Then
                    Dim p_error As Boolean
                    Dim p_DateTimeATG As DateTime
                    Dim p_DesError As String = ""
                    p_SAP_Object.clsGetTankATG_Search(p_Date, p_error, p_DesError, _
                                  p_TankCode, p_ChieuCaoDau, p_NhietDo, p_DateTimeATG)


                    'If p_Date <> "" Then
                    '    p_SQL = " exec FPT_GetBaremTankATG_QCINew '" & p_TankCode.ToString.Trim & "','" & p_Date & "' "
                    'Else
                    '    p_SQL = " exec FPT_GetBaremTankATG_QCINew '" & p_TankCode.ToString.Trim & "',NULL"
                    'End If
                    ''p_SQL = " exec FPT_GetBaremTankATG_QCINew '" & e.Value.ToString.Trim & "'"

                    p_SQL = " exec FPT_GetBaremTankATG_QCINew '" & p_TankCode.ToString.Trim & "','" & p_Date & "' "
                    p_Datable = GetDataTable(p_SQL, p_SQL)

                    If Not p_Datable Is Nothing Then
                        If p_Datable.Rows.Count > 0 Then
                            p_TyTrong = p_Datable.Rows(0).Item("Dens")
                        End If
                    End If
                    'If p_NhietDo = 0 Then
                    '    p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_MaBe & "','0.0','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
                    'Else
                    p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_TankCode & "','" & Math.Round(p_NhietDo, 2) & "','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
                    ' End If

                    p_Datable = GetDataTable(p_SQL, p_SQL)
                    If Not p_Datable Is Nothing Then
                        If p_Datable.Rows.Count > 0 Then
                            p_Row.Item("VCF") = p_Datable.Rows(0).Item("VCF")
                            p_Row.Item("VolumnL15") = p_Datable.Rows(0).Item("L15")
                            p_Row.Item("VolumnKG") = p_Datable.Rows(0).Item("Kg")
                            p_Row.Item("Ltt") = p_Datable.Rows(0).Item("Ltt")
                            p_Row.Item("WCF") = p_Datable.Rows(0).Item("Wcf")

                            p_Row.Item("TankHeight") = p_ChieuCaoDau
                            p_Row.Item("TankTemp") = Math.Round(p_NhietDo, 2)
                            p_Row.Item("Dens") = Math.Round(p_TyTrong, 4)

                        Else
                            p_Row.Item("VCF") = 0
                            p_Row.Item("VolumnL15") = 0
                            p_Row.Item("VolumnKG") = 0
                            p_Row.Item("Ltt") = 0
                            p_Row.Item("WCF") = 0

                            p_Row.Item("TankHeight") = 0
                            p_Row.Item("TankTemp") = 0
                            p_Row.Item("Dens") = 0

                        End If
                    End If

                End If


            End If

        Else

            If UCase(p_Coulumn.FieldName.ToString.Trim) = UCase("TankHeight") Or UCase(p_Coulumn.FieldName.ToString.Trim) = UCase("TankTemp") _
                        Or UCase(p_Coulumn.FieldName.ToString.Trim) = UCase("Dens") Then

                p_Row = Me.GridView1.GetFocusedDataRow
                If Not p_Row Is Nothing Then
                    p_MaBe = p_Row.Item("TankCode").ToString.Trim

                    Select Case UCase(p_Coulumn.FieldName.ToString.Trim)
                        Case UCase("TankHeight")
                            p_ChieuCaoDau = e.Value
                            Double.TryParse(p_Row.Item("TankTemp").ToString.Trim, p_NhietDo)
                            Double.TryParse(p_Row.Item("Dens").ToString.Trim, p_TyTrong)
                        Case UCase("TankTemp")
                            Double.TryParse(p_Row.Item("TankHeight").ToString.Trim, p_ChieuCaoDau)
                            p_NhietDo = e.Value
                            Double.TryParse(p_Row.Item("Dens").ToString.Trim, p_TyTrong)
                        Case Else
                            Double.TryParse(p_Row.Item("TankHeight").ToString.Trim, p_ChieuCaoDau)
                            Double.TryParse(p_Row.Item("TankTemp").ToString.Trim, p_NhietDo)
                            p_TyTrong = e.Value
                    End Select



                    If p_NhietDo = 0 Then
                        p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_MaBe & "','0.0','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
                    Else
                        p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_MaBe & "','" & Math.Round(p_NhietDo, 4) & "','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
                    End If

                    p_Datable = GetDataTable(p_SQL, p_SQL)
                    If Not p_Datable Is Nothing Then
                        'If p_Datable.Rows.Count > 0 Then
                        '    p_Row.Item("VCF") = p_Datable.Rows(0).Item("VCF")
                        '    p_Row.Item("VolumnL15") = p_Datable.Rows(0).Item("L15")
                        '    p_Row.Item("VolumnKG") = p_Datable.Rows(0).Item("Kg")
                        '    p_Row.Item("Ltt") = p_Datable.Rows(0).Item("Ltt")
                        'Else
                        '    p_Row.Item("VCF") = 0
                        '    p_Row.Item("VolumnL15") = 0
                        '    p_Row.Item("VolumnKG") = 0
                        '    p_Row.Item("Ltt") = 0
                        'End If

                        If p_Datable.Rows.Count > 0 Then
                            p_Row.Item("VCF") = p_Datable.Rows(0).Item("VCF")
                            p_Row.Item("VolumnL15") = p_Datable.Rows(0).Item("L15")
                            p_Row.Item("VolumnKG") = p_Datable.Rows(0).Item("Kg")
                            p_Row.Item("Ltt") = p_Datable.Rows(0).Item("Ltt")
                            p_Row.Item("WCF") = p_Datable.Rows(0).Item("Wcf")

                            ' p_Row.Item("TankHeight") = p_ChieuCaoDau
                            '  p_Row.Item("TankTemp") = Math.Round(p_NhietDo, 2)
                            '   p_Row.Item("Dens") = Math.Round(p_TyTrong, 4)

                        Else
                            p_Row.Item("VCF") = 0
                            p_Row.Item("VolumnL15") = 0
                            p_Row.Item("VolumnKG") = 0
                            p_Row.Item("Ltt") = 0
                            p_Row.Item("WCF") = 0

                            'p_Row.Item("TankHeight") = 0
                            'p_Row.Item("TankTemp") = 0
                            'p_Row.Item("Dens") = 0

                        End If
                    End If


                End If
            End If
        End If
    End Sub

    Private Sub TimKiem(Optional ByVal p_LoadForm As Boolean = False)
        Dim p_DocEntry As Integer = 0
        Dim p_FromDate As String = ""
        Dim p_ToDate As String = ""
        Dim p_PurposeCode As String = ""
        Dim p_Client As String = ""
        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Tank As String = ""
        Dim p_Count As Integer
        Dim p_Column As U_TextBox.GridColumn

        If Not Me.TankList.EditValue Is Nothing Then
            p_Tank = Me.TankList.EditValue.ToString.Trim
        End If
        If Not Me.txtFromDate.EditValue Is Nothing Then
            If Me.txtFromDate.EditValue.ToString.Trim <> "" Then
                p_FromDate = CDate(Me.txtFromDate.EditValue).ToString("yyyyMMdd HH:mm:ss")
            End If
        End If
        If Not Me.txtToDate.EditValue Is Nothing Then
            If Me.txtToDate.EditValue.ToString.Trim <> "" Then
                p_ToDate = CDate(Me.txtToDate.EditValue).ToString("yyyyMMdd HH:mm:ss")
            End If
        End If

        If p_LoadForm = True Then

            'Else
            p_Tank = "000000"
        End If


        If p_Tank = "" And p_FromDate = "" And p_ToDate = "" Then
            ShowMessageBox("", "Giá trị tìm kiếm chưa nhập")
            Exit Sub
        End If

        p_SQL = "exec FPT_DanhSachATG_SAP_New " & IIf(p_FromDate = "", "Null", "'" & p_FromDate & "'")
        p_SQL = p_SQL & "," & IIf(p_ToDate = "", "Null", "'" & p_ToDate & "'") & ",'" & g_UserName & "','" & p_Tank & "'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)

        If p_DataTable Is Nothing Then
            Exit Sub
        End If
        p_Binding.DataSource = p_DataTable
        Me.TrueDBGrid1.DataSource = p_Binding

        For p_Count = 0 To Me.GridView1.Columns.Count - 1
            Try
                p_Column = Me.GridView1.Columns.Item(p_Count)
                p_Column.FieldName = Me.GridView1.Columns.Item(p_Count).Name
                p_Column.FieldView = Me.GridView1.Columns.Item(p_Count).Name
            Catch ex As Exception

            End Try
        Next

        Dim p_ColDate As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        ' Dim p_Column As New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(1)

        'p_Column.Width = 250
        '  p_Column.Caption = "Thời gian tạo giao dịch"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        ' p_ColDate.DisplayFormat.FormatString = "u"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
        p_Column.ColumnEdit = p_ColDate
        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_Column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"


        Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

        'p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        ''p_ColNumber.

        ''If p_Column.ShowCalc = False Then
        ''    p_ColNumber.Buttons(0).Visible = False
        ''End If
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        p_Column = Me.GridView1.Columns.Item(2)
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber.DisplayFormat.FormatString = "#,###,###,###0."
        p_ColNumber.EditMask = "#,###,###,###0."
        p_Column.ColumnEdit = p_ColNumber


        'Nhiet do
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        'p_Column =U_TextBox.co  New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(3)
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber.DisplayFormat.FormatString = "#,###0.#0"
        p_ColNumber.EditMask = "#,###,###,###0.#0"
        p_Column.ColumnEdit = p_ColNumber


        'Ltt
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        ' p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(7)
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber.DisplayFormat.FormatString = "#,###,###,###0."
        p_ColNumber.EditMask = "#,###,###,###0."
        p_Column.ColumnEdit = p_ColNumber
        p_Column.OptionsColumn.ReadOnly = True

        'VCF
        p_Column = Me.GridView1.Columns.Item(8)
        p_Column.OptionsColumn.ReadOnly = True
        'WCF
        p_Column = Me.GridView1.Columns.Item(10)
        p_Column.OptionsColumn.ReadOnly = True
        'L15
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        ' p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(9)
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber.DisplayFormat.FormatString = "#,###,###,###0."
        p_ColNumber.EditMask = "#,###,###,###0."
        p_Column.ColumnEdit = p_ColNumber
        p_Column.OptionsColumn.ReadOnly = True
        'KG
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        '  p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(11)
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber.DisplayFormat.FormatString = "#,###,###,###0."
        p_ColNumber.EditMask = "#,###,###,###0."
        p_Column.ColumnEdit = p_ColNumber
        p_Column.OptionsColumn.ReadOnly = True
        ''p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ''p_Column.DisplayFormat.FormatString = "c2"
        'p_Column.DisplayFormat.FormatString = "#,###0.#0"


        p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        'p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(13)
        '  p_Column.Caption = "Thời gian tạo giao dịch"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        ' p_ColDate.DisplayFormat.FormatString = "u"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
        p_Column.ColumnEdit = p_ColDate
        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_Column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        ' p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(15)
        '  p_Column.Caption = "Thời gian tạo giao dịch"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        ' p_ColDate.DisplayFormat.FormatString = "u"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
        p_Column.ColumnEdit = p_ColDate
        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_Column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.GridView1.Columns.Item(4).VisibleIndex = -1
        Me.GridView1.Columns.Item(5).VisibleIndex = -1
        'Me.GridView1.Columns.Item("NhomBeXuat").Visible
        Me.GridView1.Columns.Item("NhomBeXuat").VisibleIndex = 1

        Me.GridView1.Columns.Item("TankHeaderCode").VisibleIndex = -1
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom

        '  Me.GridView1.OptionsView.ColumnAutoWidth = True

        ' Me.GridView1.OptionsView.ColumnAutoWidth = True


    End Sub

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        TimKiem()
    End Sub
End Class