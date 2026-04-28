Public Class FrmConfig
    Dim p_Datatable As DataTable
    Dim p_ChenhLech As Double

    Sub SaveToTable()
        Dim p_DataTableSave As New DataTable("Table01")
        Dim p_DataRow As DataRow
        Dim p_ArrayRow() As DataRow
        Dim p_SQL As String


        p_SQL = "SELECT *  FROM [SYS_CONFIG]"
        p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        p_DataTableSave.Columns.Add("STR_SQL")
        p_ArrayRow = p_Datatable.Select("KEYCODE='CURRENTDATE'")
        If p_ArrayRow.Length > 0 Then
            If CURRENTDATE.Checked = True Then
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
            Else
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
            End If
            p_SQL = p_SQL & "  WHERE  KEYCODE='CURRENTDATE'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If

        p_ArrayRow = p_Datatable.Select("KEYCODE='SAISOCHOPHEPTHEONGAN'")
        If p_ArrayRow.Length > 0 Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.SAISOCHOPHEPTHEONGAN.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE  KEYCODE='SAISOCHOPHEPTHEONGAN'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If

        p_ArrayRow = p_Datatable.Select("KEYCODE='SAISOCHOPHEP'")
        If p_ArrayRow.Length > 0 Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.SAISOCHOPHEP.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE  KEYCODE='SAISOCHOPHEP'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If

        p_ArrayRow = p_Datatable.Select("KEYCODE='TONGDUXUAT'")
        If p_ArrayRow.Length > 0 Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & IIf(Me.TONGDUXUAT.EditValue.ToString.Trim = "Y", "1", "0") & "'"
            p_SQL = p_SQL & "  WHERE  KEYCODE='TONGDUXUAT'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If

        p_ArrayRow = p_Datatable.Select("KEYCODE='TONGDUXUATTHUY'")
        If p_ArrayRow.Length > 0 Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & IIf(Me.TONGDUXUATTHUY.EditValue.ToString.Trim = "Y", "1", "0") & "'"
            p_SQL = p_SQL & "  WHERE  KEYCODE='TONGDUXUATTHUY'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If

        p_ArrayRow = p_Datatable.Select("KEYCODE='SAISOCHOPHEPTHEOCTO'")
        If p_ArrayRow.Length > 0 Then
            If SAISOCHOPHEPTHEOCTO.Checked = True Then
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
            Else
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
            End If
            p_SQL = p_SQL & "  WHERE  KEYCODE='SAISOCHOPHEPTHEOCTO'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If


        p_ArrayRow = p_Datatable.Select("KEYCODE='SAISOCHOPHEPTHEOCTO_THUY'")
        If p_ArrayRow.Length > 0 Then
            If SAISOCHOPHEPTHEOCTO_THUY.Checked = True Then
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
            Else
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
            End If
            p_SQL = p_SQL & "  WHERE  KEYCODE='SAISOCHOPHEPTHEOCTO_THUY'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If

        p_ArrayRow = p_Datatable.Select("KEYCODE='SAISOCHOPHEP_CTO'")
        If p_ArrayRow.Length > 0 Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.SAISOCHOPHEP_CTO.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE  KEYCODE='SAISOCHOPHEP_CTO'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If

        p_ArrayRow = p_Datatable.Select("KEYCODE='TINHSAISOCHOPHEP_THUY'")
        If p_ArrayRow.Length > 0 Then
            If TINHSAISOCHOPHEP_THUY.Checked = True Then
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
            Else
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
            End If
            p_SQL = p_SQL & "  WHERE  KEYCODE='TINHSAISOCHOPHEP_THUY'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If

        p_ArrayRow = p_Datatable.Select("KEYCODE='SAISOCHOPHEP_THUY'")
        If p_ArrayRow.Length > 0 Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.SAISOCHOPHEP_THUY.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE  KEYCODE='SAISOCHOPHEP_THUY'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        'QUYDOI_SAP

        p_ArrayRow = p_Datatable.Select("KEYCODE='QUYDOI_SAP'")
        If p_ArrayRow.Length > 0 Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.QUYDOI_SAP.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE  KEYCODE='QUYDOI_SAP'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)

        End If

        ''20240717 Tam muc
        p_ArrayRow = p_Datatable.Select("KEYCODE='TAMMUC'")
        If p_ArrayRow.Length > 0 Then
            If TamMuc.Checked = True Then
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
                p_SQL = p_SQL & "  WHERE  KEYCODE='TAMMUC'"
            Else
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
                p_SQL = p_SQL & "  WHERE  KEYCODE='TAMMUC'"
            End If
            
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        Else
            If TamMuc.Checked = True Then
                p_SQL = "INSERT INTO SYS_CONFIG  (KEYCODE, KEYVALUE ) VALUES ('TAMMUC', 'Y')"
            Else
                p_SQL = "INSERT INTO SYS_CONFIG  (KEYCODE, KEYVALUE ) VALUES ('TAMMUC', 'N')"
            End If

            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If

        p_ArrayRow = p_Datatable.Select("KEYCODE='TAMMUCLINK'")
        If p_ArrayRow.Length > 0 Then
            If Not Me.TamMucLink.EditValue Is Nothing Then
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.TamMucLink.EditValue.ToString & "'"
                p_SQL = p_SQL & "  WHERE  KEYCODE='TAMMUCLINK'"
                p_DataRow = p_DataTableSave.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataTableSave.Rows.Add(p_DataRow)
            End If
            
        Else
            If Not Me.TamMucLink.EditValue Is Nothing Then
                p_SQL = "INSERT INTO SYS_CONFIG  (KEYCODE, KEYVALUE ) VALUES ('TAMMUCLINK', '" & Me.TamMucLink.EditValue.ToString & "')"
                p_DataRow = p_DataTableSave.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataTableSave.Rows.Add(p_DataRow)
            End If
        End If

            '=======================================

            '===============================HDDT      
        If A1MaTraCuu.Checked = True Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
        Else
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
        End If
        p_SQL = p_SQL & "  WHERE upper( KEYCODE)=upper('A1MaTraCuu')"
        p_DataRow = p_DataTableSave.NewRow
        p_DataRow.Item(0) = p_SQL
        p_DataTableSave.Rows.Add(p_DataRow)


        If KHONG_TDH.Checked = True Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
        Else
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
        End If
        p_SQL = p_SQL & "  WHERE upper( KEYCODE)=upper('KHONG_TDH')"
        p_DataRow = p_DataTableSave.NewRow
        p_DataRow.Item(0) = p_SQL
        p_DataTableSave.Rows.Add(p_DataRow)
        If CHIEUCAO_MD.Checked = True Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
        Else
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
        End If
        p_SQL = p_SQL & "  WHERE upper( KEYCODE)=upper('CHIEUCAO_MD')"
        p_DataRow = p_DataTableSave.NewRow
        p_DataRow.Item(0) = p_SQL
        p_DataTableSave.Rows.Add(p_DataRow)
        If NHIETDOXE_CHXD.Checked = True Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
        Else
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
        End If
        p_SQL = p_SQL & "  WHERE upper( KEYCODE)=upper('NHIETDOXE_CHXD')"
        p_DataRow = p_DataTableSave.NewRow
        p_DataRow.Item(0) = p_SQL
        p_DataTableSave.Rows.Add(p_DataRow)



            If A1VatHTTG.Checked = True Then
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
            Else
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
            End If
            p_SQL = p_SQL & "  WHERE upper( KEYCODE)=upper('1VatHTTG')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        If Not Me.A1VATAddress.EditValue Is Nothing Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.A1VATAddress.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE    upper( KEYCODE)=upper('1VATAddress')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        
        If Not Me.A1VatPass.EditValue Is Nothing Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.A1VatPass.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE    upper( KEYCODE)=upper('1VatPass')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        If Not Me.A1VatPassWS.EditValue Is Nothing Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.A1VatPassWS.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE    upper( KEYCODE)=upper('1VatPassWS')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        If Not Me.A1VatUser.EditValue Is Nothing Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.A1VatUser.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE    upper( KEYCODE)=upper('1VatUser')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        If Not Me.A1VatUserWS.EditValue Is Nothing Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.A1VatUserWS.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE    upper( KEYCODE)=upper('1VatUserWS')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        '=========================================
        If Not Me.A2VATAddress.EditValue Is Nothing Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.A2VATAddress.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE    upper( KEYCODE)=upper('2VATAddress')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        If Not Me.A2VatPass.EditValue Is Nothing Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.A2VatPass.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE    upper( KEYCODE)=upper('2VatPass')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        If Not Me.A2VatPassWS.EditValue Is Nothing Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.A2VatPassWS.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE    upper( KEYCODE)=upper('2VatPassWS')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        If Not Me.A2VatUser.EditValue Is Nothing Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.A2VatUser.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE    upper( KEYCODE)=upper('2VatUser')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        If Not Me.A2VatUserWS.EditValue Is Nothing Then
            p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='" & Me.A2VatUserWS.EditValue.ToString.Trim & "'"
            p_SQL = p_SQL & "  WHERE    upper( KEYCODE)=upper('2VatUserWS')"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)
        End If
        p_ArrayRow = p_Datatable.Select("KEYCODE='SAPOFF'")
        If p_ArrayRow.Length > 0 Then
            If SapOff.Checked = True Then
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='Y'"
            Else
                p_SQL = "UPDATE SYS_CONFIG set KEYVALUE='N'"
            End If
            p_SQL = p_SQL & "  WHERE upper( KEYCODE) ='SAPOFF'"
            p_DataRow = p_DataTableSave.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableSave.Rows.Add(p_DataRow)

        Else
            If SapOff.Checked = True Then
                p_SQL = "INSERT INTO SYS_CONFIG  (KEYCODE, KEYVALUE ) VALUES ('SAPOFF', 'Y')"
                p_DataRow = p_DataTableSave.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataTableSave.Rows.Add(p_DataRow)
            End If
        End If
        Dim p_SMOAPI As String = ""
        Dim p_SMOLinkServices As String = ""
        Dim p_SMOUserName As String = ""
        Dim p_SMOPass As String = ""

        If Me.SMOAPI.Checked = True Then
            p_SMOAPI = "Y"
        Else
            p_SMOAPI = "N"
        End If
        If Not Me.SMOLinkServices.EditValue Is Nothing Then
            p_SMOLinkServices = Me.SMOLinkServices.EditValue.ToString.Trim
        End If
        If Not Me.SMOUserName.EditValue Is Nothing Then
            p_SMOUserName = Me.SMOUserName.EditValue.ToString.Trim
        End If
        If Not Me.SMOPass.EditValue Is Nothing Then
            p_SMOPass = Me.SMOPass.EditValue.ToString.Trim
        End If
        p_SQL = "MERGE INTO sys_config  AS target " & _
                        "USING (select 'SMOAPI' as KeyCode , '" & p_SMOAPI & "' as KeyValue, N'Trạng thái bật tích hợp Link SMO' as sDesc " & _
                          "union all select 'SMOLinkServices' as KeyCode,  '" & p_SMOLinkServices & "' as KeyValue, N'Link API của SMO' as sDesc " & _
                          "union all select 'SMOUserName' as   KeyCode, '" & p_SMOUserName & "' as KeyValue , N'Tên đăng nhập' as sDesc " & _
                          "union select 'SMOPass' as KeyCode, '" & p_SMOPass & "' as KeyValue , N'Mật khẩu đăng nhập' as sDesc) AS source " & _
                            "ON target.KeyCode = source.KeyCode " & _
                        "WHEN MATCHED THEN  UPDATE SET target.KeyValue = source.KeyValue, target.[Desc]  = source.sDesc " & _
                        "WHEN NOT MATCHED BY TARGET THEN     INSERT (KeyCode, KeyValue, [Desc] ) VALUES (source.KeyCode, source.KeyValue, source.sDesc);"
        p_DataRow = p_DataTableSave.NewRow
        p_DataRow.Item(0) = p_SQL
        p_DataTableSave.Rows.Add(p_DataRow)
        If g_Services.Sys_Execute_DataTbl(p_DataTableSave, p_SQL) = False Then
            ShowMessageBox("", p_SQL)
        Else
            ShowStatusMessage(False, "MS901", "Lưu thành công", 5)
            Me.FormStatus = False
        End If


        p_DataTableSave.Clear()

        p_SMOAPI = ""
        p_SMOLinkServices = ""
        p_SMOUserName = ""
        p_SMOPass = ""

        If Me.SAP_API_FLAG.Checked = True Then
            p_SMOAPI = "Y"
        Else
            p_SMOAPI = "N"
        End If
        If Not Me.API_SAP_LINK.EditValue Is Nothing Then
            p_SMOLinkServices = Me.API_SAP_LINK.EditValue.ToString.Trim
        End If
        If Not Me.API_SAP_USER.EditValue Is Nothing Then
            p_SMOUserName = Me.API_SAP_USER.EditValue.ToString.Trim
        End If
        If Not Me.API_SAP_PASS.EditValue Is Nothing Then
            p_SMOPass = Me.API_SAP_PASS.EditValue.ToString.Trim
        End If

        p_SQL = "MERGE INTO sys_config  AS target " & _
                        "USING (select 'API_SAP_LINK' as KeyCode , '" & p_SMOLinkServices & "' as KeyValue, N'Link API SAP' as sDesc " & _
                          "union all select 'API_SAP_USER' as KeyCode,  '" & p_SMOUserName & "' as KeyValue, N'User API của SAP' as sDesc " & _
                          "union all select 'API_SAP_PASS' as   KeyCode, '" & p_SMOPass & "' as KeyValue , N'Pass API' as sDesc " & _
                          "union select 'SAP_API_FLAG' as KeyCode, '" & p_SMOAPI & "' as KeyValue , N'Trang thai tắt/bật' as sDesc) AS source " & _
                            "ON target.KeyCode = source.KeyCode " & _
                        "WHEN MATCHED THEN  UPDATE SET target.KeyValue = source.KeyValue " & _
                        "WHEN NOT MATCHED BY TARGET THEN     INSERT (KeyCode, KeyValue, [Desc] ) VALUES (source.KeyCode, source.KeyValue, source.sDesc);"
        p_DataRow = p_DataTableSave.NewRow
        p_DataRow.Item(0) = p_SQL
        p_DataTableSave.Rows.Add(p_DataRow)
        If g_Services.Sys_Execute_DataTbl(p_DataTableSave, p_SQL) = False Then
            ShowMessageBox("", p_SQL)
        Else
            ShowStatusMessage(False, "MS901", "Lưu thành công", 5)
            Me.FormStatus = False
        End If

    End Sub

    Private Sub FrmConfig_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            SaveToTable()
        End If
    End Sub

    Private Sub FrmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim p_SQL As String
        Dim p_DataRow() As DataRow
        Dim p_Count As Integer

        p_ChenhLech = 0.05

        p_XtraUserName = g_User_ID

        p_SQL = "SELECT *  FROM [SYS_CONFIG]"
        p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        If g_Company_Code = "2610" Then
            Me.TamMuc.Visible = True
            Me.TamMucLink.Visible = True
            Label19.Visible = True

        Else
            Me.TamMuc.Visible = False
            Me.TamMucLink.Visible = False
            Label19.Visible = False

        End If

        If Not p_Datatable Is Nothing Then
            For p_Count = 0 To p_Datatable.Rows.Count - 1
                Select Case UCase(p_Datatable.Rows(p_Count).Item("KEYCODE").ToString.Trim)

                    Case "TAMMUC"
                        'Me.CURRENTDATE.EditValue = p_Datatable.Rows(p_Count).Item("KEYCODE").ToString.Trim
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.TamMuc.Checked = True
                            ' Me.CURRENTDATE.Checked = True
                        Else
                            Me.TamMuc.Checked = False
                        End If
                    Case "TAMMUCLINK"
                        Me.TamMucLink.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                        
                    Case "CURRENTDATE"
                        'Me.CURRENTDATE.EditValue = p_Datatable.Rows(p_Count).Item("KEYCODE").ToString.Trim
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.CURRENTDATE.Checked = True
                            ' Me.CURRENTDATE.Checked = True
                        Else
                            Me.CURRENTDATE.Checked = False
                        End If
                    Case "SAISOCHOPHEPTHEONGAN"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.SAISOCHOPHEPTHEONGAN.EditValue = "Y"
                        Else
                            Me.SAISOCHOPHEPTHEONGAN.EditValue = "N"
                        End If
                    Case "SAISOCHOPHEP"
                        Me.SAISOCHOPHEP.EditValue = IIf(p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "", 0, p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim)
                    Case "TONGDUXUAT"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "1" Then
                            Me.TONGDUXUAT.EditValue = "Y"
                        Else
                            Me.TONGDUXUAT.EditValue = "N"
                        End If
                    Case "TONGDUXUATTHUY"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "1" Then
                            Me.TONGDUXUATTHUY.EditValue = "Y"
                        Else
                            Me.TONGDUXUATTHUY.EditValue = "N"
                        End If
                    Case "SAISOCHOPHEPTHEOCTO"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.SAISOCHOPHEPTHEOCTO.Checked = True
                            Me.SAISOCHOPHEP_CTO.Enabled = True
                        Else
                            Me.SAISOCHOPHEPTHEOCTO.Checked = False
                            Me.SAISOCHOPHEP_CTO.Enabled = False
                        End If
                    Case "SAISOCHOPHEPTHEOCTO_THUY"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.SAISOCHOPHEPTHEOCTO_THUY.Checked = True
                            'Me.SAISOCHOPHEP_CTO.Enabled = True
                        Else
                            Me.SAISOCHOPHEPTHEOCTO_THUY.Checked = False
                            'Me.SAISOCHOPHEP_CTO.Enabled = False
                        End If
                    Case "SAISOCHOPHEP_CTO"
                        Me.SAISOCHOPHEP_CTO.EditValue = IIf(p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "", 0, p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim)

                    Case "TINHSAISOCHOPHEP_THUY"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.TINHSAISOCHOPHEP_THUY.Checked = True
                            Me.SAISOCHOPHEP_THUY.Enabled = True
                        Else
                            Me.TINHSAISOCHOPHEP_THUY.Checked = False
                            Me.SAISOCHOPHEP_THUY.Enabled = False
                        End If
                    Case "SAISOCHOPHEP_THUY"
                        Me.SAISOCHOPHEP_THUY.EditValue = IIf(p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "", 0, p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim)
                    Case "QUYDOI_SAP"
                        'Me.CURRENTDATE.EditValue = p_Datatable.Rows(p_Count).Item("KEYCODE").ToString.Trim
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.QUYDOI_SAP.EditValue = "Y"
                            ' Me.CURRENTDATE.Checked = True
                        Else
                            Me.QUYDOI_SAP.EditValue = "N"
                        End If
                        '
                    Case "CHENHLECH"
                        Try
                            'p_ChenhLech = Double.TryParse(p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim, p_ChenhLech)
                            p_ChenhLech = IIf(p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "", 0, p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim)
                        Catch ex As Exception
                            p_ChenhLech = 0.05
                        End Try
                    Case "SAPOFF"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.SapOff.Checked = True
                            ' Me.CURRENTDATE.Checked = True
                        Else
                            Me.SapOff.Checked = False
                        End If
                    Case "1MATRACUU"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.A1MaTraCuu.Checked = True
                        Else
                            Me.A1MaTraCuu.Checked = False
                        End If
                    Case "1VATHTTG"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.A1VatHTTG.Checked = True
                        Else
                            Me.A1VatHTTG.Checked = False
                        End If
                        'Me.A1MaTraCuu.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "1VATADDRESS"
                        Me.A1VATAddress.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "1VATPASS"
                        Me.A1VatPass.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "1VATPASSWS"
                        Me.A1VatPassWS.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "1VATUSER"
                        Me.A1VatUser.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "1VATUSERWS"
                        Me.A1VatUserWS.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                        'Me.A1MaTraCuu.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "2VATADDRESS"
                        Me.A2VATAddress.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "2VATPASS"
                        Me.A2VatPass.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "2VATPASSWS"
                        Me.A2VatPassWS.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "2VATUSER"
                        Me.A2VatUser.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "2VATUSERWS"
                        Me.A2VatUserWS.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim

                    Case UCase("SMOAPI")
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.SMOAPI.Checked = True
                        Else
                            Me.SMOAPI.Checked = False
                        End If
                    Case UCase("SMOLinkServices")
                        Me.SMOLinkServices.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case UCase("SMOUserName")
                        Me.SMOUserName.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case UCase("SMOPass")
                        Me.SMOPass.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "KHONG_TDH"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.KHONG_TDH.Checked = True
                            ' Me.CURRENTDATE.Checked = True
                        Else
                            Me.KHONG_TDH.Checked = False
                        End If
                    Case "CHIEUCAO_MD"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.CHIEUCAO_MD.Checked = True
                            ' Me.CURRENTDATE.Checked = True
                        Else
                            Me.CHIEUCAO_MD.Checked = False
                        End If
                    Case "NHIETDOXE_CHXD"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.NHIETDOXE_CHXD.Checked = True
                            ' Me.CURRENTDATE.Checked = True
                        Else
                            Me.NHIETDOXE_CHXD.Checked = False
                        End If


                    Case "SAP_API_FLAG"
                        If p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim = "Y" Then
                            Me.SAP_API_FLAG.Checked = True
                            ' Me.CURRENTDATE.Checked = True
                        Else
                            Me.SAP_API_FLAG.Checked = False
                        End If
                    Case "API_SAP_LINK"
                        Me.API_SAP_LINK.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case "API_SAP_USER"

                        Me.API_SAP_USER.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim

                    Case "API_SAP_PASS"
                        Me.API_SAP_PASS.EditValue = p_Datatable.Rows(p_Count).Item("KEYVALUE").ToString.Trim
                    Case Else
                End Select
            Next
        End If
    End Sub

    Private Sub SAISOCHOPHEPTHEOCTO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAISOCHOPHEPTHEOCTO.CheckedChanged
        If Me.SAISOCHOPHEPTHEOCTO.Checked = True Then
            SAISOCHOPHEP_CTO.Enabled = True
        Else
            SAISOCHOPHEP_CTO.Enabled = False
        End If
    End Sub

    Private Sub TINHSAISOCHOPHEP_THUY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TINHSAISOCHOPHEP_THUY.CheckedChanged
        If Me.TINHSAISOCHOPHEP_THUY.Checked = True Then
            SAISOCHOPHEP_THUY.Enabled = True
        Else
            SAISOCHOPHEP_THUY.Enabled = False
        End If
    End Sub

    Function CheckValue(ByVal p_Value As String) As Boolean
        Dim p_Double As Double
        Try

            If p_Value = "" Then
                Return True
            End If
            p_Double = CDbl(p_Value)
            If p_Double >= 0.01 And p_Double <= p_ChenhLech Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

   
    Private Sub SAISOCHOPHEP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles SAISOCHOPHEP.Validated

    End Sub

    Private Sub SAISOCHOPHEP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SAISOCHOPHEP.Validating
        If CheckValue(Me.SAISOCHOPHEP.Text.ToString.Trim) = False Then
            ShowMessageBox("", "Bạn đã nhập sai giá trị cho phép")
            e.Cancel = True
        End If
    End Sub

    Private Sub SAISOCHOPHEP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAISOCHOPHEP.EditValueChanged

    End Sub

    Private Sub SAISOCHOPHEP_THUY_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAISOCHOPHEP_THUY.EditValueChanged

    End Sub

    Private Sub SAISOCHOPHEP_THUY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SAISOCHOPHEP_THUY.Validating
        If CheckValue(Me.SAISOCHOPHEP_THUY.Text.ToString.Trim) = False Then
            ShowMessageBox("", "Bạn đã nhập sai giá trị")
            e.Cancel = True
        End If
    End Sub

    Private Sub SAISOCHOPHEP_CTO_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAISOCHOPHEP_CTO.EditValueChanged

    End Sub

    Private Sub SAISOCHOPHEP_CTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SAISOCHOPHEP_CTO.Validating
        If CheckValue(Me.SAISOCHOPHEP_CTO.Text.ToString.Trim) = False Then
            ShowMessageBox("", "Bạn đã nhập sai giá trị")
            e.Cancel = True
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If CheckValue(Me.SAISOCHOPHEP.Text.ToString.Trim) = False Then
            ShowMessageBox("", "Sai số cho phép không đúng")
            Exit Sub
        End If

        If CheckValue(Me.SAISOCHOPHEP_CTO.Text.ToString.Trim) = False Then
            ShowMessageBox("", "Sai số cho phép không đúng")
            Exit Sub
        End If


        If CheckValue(Me.SAISOCHOPHEP_THUY.Text.ToString.Trim) = False Then
            ShowMessageBox("", "Sai số cho phép không đúng")
            Exit Sub
        End If

        SaveToTable()
    End Sub

    
    Private Sub A1VatHTTG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A1VatHTTG.CheckedChanged

    End Sub
End Class