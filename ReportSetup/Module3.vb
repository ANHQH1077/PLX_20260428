Module Module3


    Public Function Print_BienBanDoBe(ByVal i_preview As Boolean, ByVal i_SoLenh As String, ByRef o_err As String) As Boolean
        Dim err As String = String.Empty
        Dim DtSet As New DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        'Dim rpt As New rptLenhXuatKho
        Dim p_KV1_LenhxuatKho As New rptBienBanDoBe
        ' Dim p_KV1_LenhxuatKho_Sub As New KV2_LenhXuatKhoKDD_Sub
        'Dim frmView As New frmPrint
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim TongDuXuat As Double
        Dim TongThucXuat As Double
        Dim p_DataTable As DataTable

        Try
            p_SQL = "exec BienBanDoBe " & i_SoLenh
            'p_SQL = "select aa.Createdate as Ngay,aa.CreateDate as Gio, aa.TankCode as Be" & _
            '     ", aa.ProductCode as MaHangHoa, aa.TenHangHoa, aa.TankHeight as ChieuCao, aa.TankTemp as NhietDo " & _
            '     ", aa.PurposeCode as MaMDD, aa.PurposeName as TenMDD  from  dbo.ztblTankLineImp_v aa, ztblTankHeaderImp bb	" & _
            '  " where aa.TankHeaderCode =bb.TankHeaderCode and bb.DocEntry =" & i_SoLenh & " and aa.X='Y' ;"
            'p_SQL = p_SQL & " select * from dbo.ztblTankHeaderImp where DocEntry =" & i_SoLenh & ";"
            'FPT_reports_LenhXuatKhoE5
            DtSet = GetDataSet(p_SQL, err)
            ' DtSet = l_bs_reports.Select_LenhXuatKho(_SQLConnectionString, err, i_SoLenh)
            If DtSet Is Nothing Then
                o_err = "Không có dữ liệu"
                Return False
            End If



            DtTable = DtSet.Tables(0)
            If DtTable.Rows.Count <= 0 Then
                o_err = "Không có dữ liệu "
                Return False
            End If
            DtTable1 = DtSet.Tables(0)
            DtTable2 = DtSet.Tables(1)

            p_KV1_LenhxuatKho.DataSource = DtTable1
            'p_KV1_LenhxuatKho.XrLabel25.Text = "Số: " & i_SoLenh
            If Not DtTable2 Is Nothing Then
                If DtTable2.Rows.Count > 0 Then
                    p_KV1_LenhxuatKho.XrLabel26.Text = "Số giao dịch: " & DtTable2.Rows(0).Item("DocEntry").ToString.Trim
                End If
            End If
            p_KV1_LenhxuatKho.RequestParameters = False

            p_KV1_LenhxuatKho.PrinterName = g_DefaultPrint
            If i_preview Then
                p_KV1_LenhxuatKho.Print()
            Else

                '  p_KV1_LenhxuatKho.sh()
                p_KV1_LenhxuatKho.ShowPreviewDialog()
            End If

            Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try
    End Function



    Public Function Get_ThoiGianDau(p_SoLenh As String) As DateTime
        Dim p_Max As Boolean = True

        Get_ThoiGianDau = Now
        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Dim p_Row() As DataRow
        If Not g_SySConfig Is Nothing Then
            If g_SySConfig.Rows.Count > 0 Then
                p_Row = g_SySConfig.Select("KeyCode='MAX_TIME'")
                If p_Row.Length > 0 Then
                    If p_Row(0).Item("KeyValue").ToString.Trim = "Y" Then
                        p_Max = True
                    Else
                        p_Max = False
                    End If
                End If
            End If
        End If

        If p_Max = True Then
            p_SQL = "select max(isnull( ThoiGianDau,getdate())) as ThoiGianDau from fpt_tbllenhxuatchitiete5_v where solenh='" & p_SoLenh & "'"
        Else
            p_SQL = "select min(isnull( ThoiGianDau,getdate())) as ThoiGianDau from fpt_tbllenhxuatchitiete5_v where solenh='" & p_SoLenh & "'"
        End If
        '  p_SQL = "select max(isnull( ThoiGianDau,getdate())) as ThoiGianDau from fpt_tbllenhxuatchitiete5_v where solenh='" & p_SoLenh & "'"

        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Get_ThoiGianDau = p_DataTable.Rows(0).Item(0)
            End If
        End If
    End Function

    Public Sub CreateFieldForm(ByVal p_Form As U_CusForm.XtraCusForm1)
        Dim p_SQL As String
        Dim p_Object As Object
        Dim p_Count As Integer

        Dim pv_Type_Date As String = ".U_DATEEDIT"

        Dim pv_Type_ChectBox As String = ".U_CHECKBOX"

        Dim pv_Type_TextBox As String = ".U_TEXTBOX"
        Dim pv_Type_MemoEdit As String = UCase(".U_MemmoEdit")
        Dim pv_Type_Num As String = ".U_NUMERICEDIT"
        Dim pv_Type_Combo As String = ".U_COMBOBOX"
        Dim pv_Type_Button As String = ".U_BUTTONEDIT"
        'PanelControl
        Dim pv_Type_MemoTextBox As String = ".U_MEMMOEDIT"
        Dim pv_Type_TrueDBGrid As String = ".U_TRUEDBGRID"
        Dim pv_Type_TrueDBGridNew As String = ".TRUEDBGRID"
        Dim pv_Type_Navigator As String = UCase(".Navigator")
        Dim p_Field As String
        p_SQL = ""

        For p_Count = 0 To p_Form.Controls.Count - 1
            p_Object = p_Form.Controls.Item(p_Count)

            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                       Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                       Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                       Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoTextBox, CompareMethod.Text) > 0 _
                       Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                       Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                   Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                   Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                   Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Navigator, CompareMethod.Text) > 0 Then

                p_Field = p_Object.name
                Select Case p_Object.FieldType
                    Case "C"
                        p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','" & p_Field & "') is null " & _
                      "  begin alter table tblChungTu  add " & p_Field & " nvarchar(500) end;"
                    Case "N"
                        p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','" & p_Field & "') is null " & _
                      "  begin alter table tblChungTu  add " & p_Field & " Numeric(10,6) end;"
                    Case "F"
                        p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','" & p_Field & "') is null " & _
                      "  begin alter table tblChungTu  add " & p_Field & " Numeric(10,6) end;"
                    Case "D"
                        p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','" & p_Field & "') is null " & _
                      "  begin alter table tblChungTu  add " & p_Field & " DateTime end;"
                    Case Else
                        p_SQL = p_SQL
                End Select

            End If
        Next
        If p_SQL = "" Then
            Exit Sub
        End If
        If g_Services.Sys_Execute(p_SQL, _
                                        p_SQL) = False Then

        End If

    End Sub

End Module
