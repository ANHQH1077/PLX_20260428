Module Module2
    Public p_SYS_MALENH_S As String = String.Empty

    Public g_SYS_CONFIG_RPT_PARA As DataTable
    Public g_SYS_CONFIG_RPT As DataTable
    Public g_SYS_CONFIG_RPT_FIELD As DataTable

    Public g_tblVCF As DataTable



    Public Sub p_GetCurrentDate(ByRef p_Date As DateTime)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  getdate() as SysDate"
        ' p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")

            End If
        End If
        p_Datatable = Nothing
    End Sub

    Public Function FPT_GetMaLenh() As String
        Dim p_ValueTmp As String = "0000"
        Dim p_SQL As String = ""
        Dim p_Value As Integer = 0
        Dim p_DataTable As DataTable
        Try
            If p_SYS_MALENH_S.ToString.Trim = "" Then
                p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG where KEYCODE='SYS_MALENH_S'"
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_SYS_MALENH_S = p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim

                    End If
                End If
            End If

            p_DataTable = Nothing
            FPT_GetMaLenh = "0000"
            p_SQL = "exec FPT_Get_SYS_MALENH_S"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_Value = p_DataTable.Rows(0).Item(0)
                End If
            End If
            If p_Value > 0 Then
                If Len(p_Value.ToString.Trim) < 4 Then
                    FPT_GetMaLenh = Mid(p_ValueTmp, 1, Len(FPT_GetMaLenh.ToString.Trim) - Len(p_Value.ToString.Trim) - Len(p_SYS_MALENH_S)) & p_Value.ToString.Trim
                    If Len(FPT_GetMaLenh) = 3 Then
                        FPT_GetMaLenh = p_SYS_MALENH_S & FPT_GetMaLenh
                    End If
                Else
                    FPT_GetMaLenh = p_Value.ToString.Trim
                End If
            End If
        Catch ex As Exception
            FPT_GetMaLenh = "0000"
        End Try

    End Function

    Public Function CheckMaLenh(ByRef err As String, ByVal i_malenh As String, ByVal i_ngay As Date) As String

        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Try
            CheckMaLenh = ""
            p_SQL = "select DBO.FPT_CheckMaLenh_E5('" & i_malenh & "','" & i_ngay & "') as MaLenh "
            '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
            'Return _c2SQL.getDataValue("select DBO.fm_CheckMaLenh_KV2E5('" & i_malenh & "','" & i_ngay & "')")
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    CheckMaLenh = p_DataTable.Rows(0).Item("MaLenh").ToString.Trim
                End If
            End If
            ' Return _c2SQL.getDataValue("exec CheckMaLenh_KV2E5('" & i_malenh & "','" & i_ngay & "')")

        Catch ex As Exception
            Return "1"
            err = ex.Message
        End Try
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
