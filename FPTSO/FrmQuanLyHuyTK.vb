Public Class FrmQuanLyHuyTK
    Private p_TablePara As DataTable
    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Dim p_SQL As String = ""
        Dim p_Table As DataTable

        p_QuerySource(True)
    End Sub


    '==============================================================================
    Private Sub p_QuerySource(ByVal p_LoadForm As Boolean, Optional ByVal p_CardNum As String = "")
        Dim p_DesError As String = ""
        Dim p_where As String = ""
        Dim p_Date As Date
        Dim p_SoTichKe As String = ""
        Dim p_NgayXuat As String = ""

        Try
            If Not Me.SoTichKe.EditValue Is Nothing Then
                If Me.SoTichKe.EditValue.ToString.Trim <> "" Then
                    p_SoTichKe = Me.SoTichKe.EditValue.ToString.Trim
                End If
            End If
            If Not Me.NgayXuat.EditValue Is Nothing Then
                If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                    p_Date = Me.NgayXuat.EditValue
                    p_NgayXuat = CDate(p_Date).ToString("yyyyMMdd")
                End If
            End If

            If p_SoTichKe = "" Or p_NgayXuat = "" Then
                ShowMessageBox("", "Số tích kê và ngày tháng chưa nhập")
                Exit Sub
            End If
           
            p_where = "SoTichKe='" & p_SoTichKe & "'"
            p_where = p_where & " and NgayXuat='" & p_NgayXuat & "' and Status ='3' "
            Me.GridView1.Where = p_where
            Me.DefaultFormLoad = True
            Me.LoadDataToForm()
            Me.DefaultFormLoad = False


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




    Private Sub HuyTichKeTheoTichKe()
        Dim p_SQL As String
        Dim p_SoLenh As String = ""
        Dim p_DataTable As DataTable
        Dim p_DataTableStatus As DataTable
        Dim p_DataTableHuyTK As DataTable
        Dim p_DataTableTK As DataTable
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_Desc As String = "Bạn có chắn chắn muốn thực hiện hủy tích kê?"
        Dim p_String As String = ""
        Dim p_DataSet As DataSet
        Dim p_Count As Integer
        Dim p_Error As Boolean = False
        Dim p_Message As String = ""
        Dim p_TableUser As DataTable
        Dim p_Datarow As DataRow
        Dim p_Client As String = ""
        Dim p_LoaiHinhVanChuyen As String = ""
        Dim p_MaVanChuyen As String = ""
        Dim p_NgayThang As String = ""
        Dim p_SoTichKe As String = ""
        'p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
        ' Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)



        If Me.GridView1.RowCount > 0 Then
            p_Datarow = Me.GridView1.GetDataRow(0)
        Else
            ShowMessageBox("", "Lệnh xuất không xác định")
            Exit Sub
        End If
        p_Client = p_Datarow.Item("Client").ToString.Trim
        p_SoLenh = p_Datarow.Item("SoLenh").ToString.Trim
        p_MaVanChuyen = p_Datarow.Item("MaVanChuyen").ToString.Trim
        p_LoaiHinhVanChuyen = GetLoadingSite(p_MaVanChuyen)
        If p_SoLenh = "" Then
            ShowMessageBox("", "Lệnh xuất không xác định")
            Exit Sub
        End If



        p_SQL = "FPT_KiemTra_HuyTichKe '" & p_SoLenh & "','" & g_UserName & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_DataTable = p_DataSet.Tables(0)
                p_DataTableTK = p_DataSet.Tables(1)
                p_DataTableStatus = p_DataSet.Tables(2)
                p_DataTableHuyTK = p_DataSet.Tables(3)
            End If
        End If
        'p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                ShowMessageBox("", p_DataTable.Rows(0).Item("StrName").ToString.Trim)
                Exit Sub
            End If
        End If
        If Not p_DataTableStatus Is Nothing Then
            If p_DataTableStatus.Rows.Count > 0 Then
                ShowMessageBox("", "Tích kê đã có lệnh xuất được hoàn thiện", 3)
                Exit Sub
            End If
        End If
        p_SQL = g_Terminal
        If g_Filter_Terminal = True Then
            'If Not Me.Client.EditValue Is Nothing Then
            p_SQL = p_Datarow.Item("Client").ToString.Trim
            ' If
            If p_SQL <> g_Terminal Then
                ShowMessageBox("", "Không hủy được tích kê của kho khác", 3)
                Exit Sub
            End If
        End If

        If g_KV1 = False Then
            If p_DataTableHuyTK.Rows.Count > 0 Then
                p_ValueMess = g_Module.ShowMessage(Me, "", _
                          "Tích kê đã được tạo bởi User " & p_DataTableHuyTK.Rows(0).Item("UserTichKe").ToString.Trim & vbCrLf & vbNewLine & "  Bạn có chắc chắn muốn hủy tích kê không? ", _
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
            End If

        End If


        If Not p_DataTableTK Is Nothing Then
            If p_DataTableTK.Rows.Count > 1 Then  'Huy lenh gep
                For p_Count = 0 To p_DataTableTK.Rows.Count - 1
                    p_String = p_String & "," & p_DataTableTK.Rows(p_Count).Item(0).ToString.Trim
                Next
                If p_String <> "" Then
                    p_String = Mid(p_String, 2)
                End If

                '==============================20180510  Kiem tra bat ky lenh nao cua danh sach lenh ghep da xuat hang chua
                Dim p_bHuyTichKe As Boolean = False

                p_SQL = "select HuyLenh, HuyLenhEnd from SYS_USER where User_ID =" & g_User_ID & " and Getdate() <= isnull(HuyLenhEnd,getdate());"
                p_TableUser = GetDataTable(p_SQL, p_SQL)  ' p_DataSet.Tables(2)

                If Not p_TableUser Is Nothing Then
                    If p_TableUser.Rows.Count > 0 Then
                        If p_TableUser.Rows(0).Item("HuyLenh").ToString.Trim = "Y" Then
                            p_bHuyTichKe = True
                        End If
                    End If
                End If
                If p_bHuyTichKe = True Then
                    For p_Count = 0 To p_DataTableTK.Rows.Count - 1
                        p_SoLenh = p_DataTableTK.Rows(p_Count).Item(0).ToString.Trim
                        ''HuyTichKe(p_SoLenh)
                        p_Error = False
                        HuyTichKeKiemTra(p_LoaiHinhVanChuyen, p_Client, p_Error, p_Message, p_SoLenh)
                        If p_Error = True Then
                            ShowMessageBox("", p_SoLenh & ": " & p_Message)
                            Exit Sub
                        End If
                    Next
                End If



                '==============================

                p_ValueMess = g_Module.ShowMessage(Me, "", _
                        "Lệnh ghép (" & p_String & ") - Bạn có chắc chắn muốn hủy tích kê không? ", _
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




                For p_Count = 0 To p_DataTableTK.Rows.Count - 1
                    p_SoLenh = p_DataTableTK.Rows(p_Count).Item(0).ToString.Trim
                    HuyTichKe(p_NgayThang, p_SoTichKe, p_LoaiHinhVanChuyen, p_Client, p_SoLenh)
                Next
            Else   'Huy lenh co 1 lenh xuat
                p_ValueMess = g_Module.ShowMessage(Me, "", _
                        "Bạn có chắn chắn muốn thực hiện hủy tích kê?", _
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
                HuyTichKe(p_NgayThang, p_SoTichKe, p_LoaiHinhVanChuyen, p_Client, p_SoLenh)


            End If

            ' ShowStatusMessage(False, "", "Tích kê đã được hủy", 8)
            p_QuerySource(False)
            ' GopTichKe(False, True)
            Me.SoTichKe.SelectAll()
            Me.SoTichKe.EditValue = ""

        End If


        'FPT_KiemTra_HuyTichKe'
    End Sub

    Function GetLoadingSite(ByVal p_LoaiVanChuyen As String) As String
        Dim p_Value As String
        Dim p_Count As Integer

        GetLoadingSite = "Sat"
        Try
            If Not p_TablePara Is Nothing Then
                For p_Count = 0 To p_TablePara.Rows.Count - 1
                    p_Value = p_TablePara.Rows(p_Count).Item("Value_nd").ToString.Trim
                    If InStr(p_Value, p_LoaiVanChuyen, CompareMethod.Text) > 0 Then
                        GetLoadingSite = p_TablePara.Rows(p_Count).Item("Para").ToString.Trim
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub HuyTichKeKiemTra(ByVal p_LoaiHinhVanChuyen As String, ByVal p_Terminal As String, ByRef p_Error As Boolean, ByRef p_Message As String, ByVal p_SoLenh As String)
        Dim p_SQL, p_Type As String
        Dim p_DataSet As DataSet
        Dim e As System.EventArgs
        Dim p_TableUser As DataTable
        Dim p_bHuyTichKe As Boolean = False

        'p_Terminal = g_Terminal
        'If Not Me.Client.EditValue Is Nothing Then
        '    If Me.Client.EditValue.ToString.Trim <> "" Then
        '        p_Terminal = Me.Client.EditValue.ToString.Trim
        '    End If
        'End If

        'If Not Me.LoaiXuat.EditValue Is Nothing Then
        '    p_LoaiHinhVanChuyen = Me.LoaiXuat.EditValue.ToString.Trim
        'End If

        p_SQL = "select * from SYS_CONFIG where KeyCode='WEBSERVER64';select * from tblconfig;" & _
                "select HuyLenh, HuyLenhEnd from SYS_USER where User_ID = " & g_User_ID & " and Getdate() <=HuyLenhEnd ;"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        p_SQL = "Y"
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then

                p_TableUser = p_DataSet.Tables(2)

                If Not p_TableUser Is Nothing Then
                    If p_TableUser.Rows.Count > 0 Then
                        If p_TableUser.Rows(0).Item("HuyLenh").ToString.Trim = "Y" Then
                            p_bHuyTichKe = True
                        End If

                    End If
                End If


                If p_DataSet.Tables(0).Rows.Count > 0 Then
                    p_SQL = p_DataSet.Tables(0).Rows(0).Item("KeyValue").ToString.Trim
                End If




                If p_DataSet.Tables(1).Rows.Count > 0 Then
                    p_Type = p_DataSet.Tables(1).Rows(0).Item("optional").ToString.Trim
                End If
            End If
        End If

        If p_Type = "FOX" Then
            ' Dim p_FOx_Obj As New FOX_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            'p_Message = p_FOx_Obj.clsScadar_HuyTichKe_fox(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        ElseIf p_Type = "ACC" Then
            ' Dim p_Acc_Obj As New ACCESS_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            ' p_Message = p_Acc_Obj.clsScadar_HuyTichKe_Access(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        Else

            p_Message = Scadar_HuyTichKeKiemtra(p_Error, g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)

            'End If

        End If


    End Sub

    Private Sub HuyTichKe(ByVal p_NgayThang As String, ByVal p_SoTichKe As String, ByVal p_LoaiHinhVanChuyen As String, ByVal p_Terminal As String, ByVal p_SoLenh As String)
        Dim p_Message, p_SQL, p_Type As String
        Dim p_DataSet As DataSet
        Dim e As System.EventArgs
        Dim p_TableUser As DataTable



        p_SQL = "select * from SYS_CONFIG where KeyCode='WEBSERVER64';select * from tblconfig;" & _
                "select HuyLenh, HuyLenhEnd from SYS_USER where User_ID = " & g_User_ID & " and Getdate() <=HuyLenhEnd ;"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        p_SQL = "Y"
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then



                If p_DataSet.Tables(0).Rows.Count > 0 Then
                    p_SQL = p_DataSet.Tables(0).Rows(0).Item("KeyValue").ToString.Trim
                End If

                If p_DataSet.Tables(1).Rows.Count > 0 Then
                    p_Type = p_DataSet.Tables(1).Rows(0).Item("optional").ToString.Trim
                End If
            End If
        End If

        If p_Type = "FOX" Then
            Dim p_FOx_Obj As New FOX_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            p_Message = p_FOx_Obj.clsScadar_HuyTichKe_fox(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        ElseIf p_Type = "ACC" Then
            Dim p_Acc_Obj As New ACCESS_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            p_Message = p_Acc_Obj.clsScadar_HuyTichKe_Access(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        Else

            'If p_bHuyTichKe = True Then

            'Else
            p_Message = Scadar_HuyTichKe(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)

            'End If

        End If
        'End If



        'p_Message = Scadar_HuyTichKe(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)

        If p_Message.ToString.Trim <> "" Then
            ShowMessageBox("", p_Message)
            Exit Sub
        Else

            Me.FormStatus = False

            
            Cursor = Cursors.Default
        End If


    End Sub

    Private Sub FrmQuanLyHuyTK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = ""

        'Dim p_SQL As String = ""
        Dim p_Table As DataTable

        p_SQL = "select convert(date, getdate()) as dDate"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                Me.NgayXuat.EditValue = CDate(p_Table.Rows(0).Item(0))
            End If
        End If

        p_SQL = "select Para, Value_nd  from tblPara  where Para in ('Bo','Thuy','Sat', 'FO');"
        p_TablePara = GetDataTable(p_SQL, p_SQL)

    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        HuyTichKeTheoTichKe()
    End Sub

    Private Sub SoTichKe_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoTichKe.EditValueChanged

    End Sub

    Private Sub SoTichKe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SoTichKe.KeyDown
        If e.KeyCode = Keys.Enter Then
            p_QuerySource(True)
        End If
    End Sub

    Private Sub SoTichKe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SoTichKe.KeyPress
      
    End Sub
End Class