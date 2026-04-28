Public Class FrmLenhXuatCopy
    Public g_SoLenhCopy As String = ""
    Public p_LenhXuatLoai As String = ""
    Public p_LenhXuatPhieu As String = ""

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        p_Search()
        Me.GridView1.BestFitColumns()
    End Sub


    '===========================================================
    Sub p_Search()
      

        Me.Cursor = Cursors.WaitCursor
        p_QuerySource(False)
        Me.Cursor = Cursors.Default
    End Sub





    '==============================================================================
    Private Sub p_QuerySource(ByVal p_LoadForm As Boolean)
        Dim p_DesError As String = ""
        'Dim p_SQLString As String = ""
        Dim p_where As String = ""
        Dim p_whereSAP As String = ""
        Dim p_Count As Integer
        Dim p_SoLenh As String
        Dim p_Date As Date

        Dim p_TMP As String



        Dim p_SQLString As String
        Try
            ' If g_MultiCheck = True Then

         
            
            If Not Me.SoLenh.EditValue Is Nothing Then
                If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                    p_where = "SoLenh='" & Me.SoLenh.EditValue.ToString.Trim & "'"
                    'p_SoLenh = "SoLenh='" & Me.SoLenh.EditValue.ToString.Trim & "'"
                    p_whereSAP = "SoLenh='" & Me.SoLenh.EditValue.ToString.Trim & "'"

                End If
            End If
            If Not Me.TuNgay.EditValue Is Nothing Then
                If Me.TuNgay.EditValue.ToString.Trim <> "" Then
                    p_Date = Me.TuNgay.EditValue
                    If p_where = "" Then
                        p_where = "NgayXuat >='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                        p_whereSAP = "NgayXuat >='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                    Else
                        p_where = p_where & " and NgayXuat>='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                        p_whereSAP = p_whereSAP & " and NgayXuat>='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                    End If
                End If
            End If

            If Not Me.DenNgay.EditValue Is Nothing Then
                If Me.DenNgay.EditValue.ToString.Trim <> "" Then
                    p_Date = Me.DenNgay.EditValue
                    If p_where = "" Then
                        p_where = "NgayXuat <='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                        p_whereSAP = "NgayXuat <='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                    Else
                        p_where = p_where & " and NgayXuat <='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                        p_whereSAP = p_whereSAP & " and NgayXuat <='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                    End If
                End If
            End If


            '  p_RollTerminal = "," & p_RollTerminal & ","
            p_SQLString = ""
            If Not Me.U_ButtonEdit1.EditValue Is Nothing Then
                '  If Me.U_ButtonEdit1.EditValue.ToString.Trim <> "" Then
                p_SQLString = U_ButtonEdit1.EditValue.ToString.Trim
                If p_SQLString <> "" Then
                    If p_where = "" Then
                        p_where = "DiemTraHang=N'" & p_SQLString & "'"
                        p_whereSAP = "DiemTraHang=N'" & p_SQLString & "'"
                    Else
                        p_where = p_where & " and DiemTraHang=N'" & p_SQLString & "'"
                        p_whereSAP = p_whereSAP & " and DiemTraHang=N'" & p_SQLString & "'"
                    End If
                End If

                'End If
            End If

            p_SQLString = ""
            If Not Me.MaKhachHang.EditValue Is Nothing Then
                '  If Me.MaKhachHang.EditValue.ToString.Trim <> "" Then
                p_SQLString = MaKhachHang.EditValue.ToString.Trim
                If p_SQLString <> "" Then
                    If p_where = "" Then
                        p_where = "MaKhachHang=N'" & p_SQLString & "'"
                        p_whereSAP = "MaKhachHang=N'" & p_SQLString & "'"
                    Else
                        p_where = p_where & " and MaKhachHang=N'" & p_SQLString & "'"
                        p_whereSAP = p_whereSAP & " and MaKhachHang=N'" & p_SQLString & "'"
                    End If
                End If

                'End If
            End If

            p_SQLString = ""
            If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
                'If Me.MaPhuongThucBan.EditValue.ToString.Trim <> "" Then
                p_SQLString = MaPhuongThucBan.EditValue.ToString.Trim
                If p_SQLString <> "" Then
                    If p_where = "" Then
                        p_where = "MaPhuongThucBan=N'" & p_SQLString & "'"
                        p_whereSAP = "MaPhuongThucBan=N'" & p_SQLString & "'"
                    Else
                        p_where = p_where & " and MaPhuongThucBan=N'" & p_SQLString & "'"
                        p_whereSAP = p_whereSAP & " and MaPhuongThucBan=N'" & p_SQLString & "'"
                    End If
                End If

                'End If
            End If

            p_SQLString = ""
            If Not Me.SoHopDong.EditValue Is Nothing Then
                'If Me.MaPhuongThucBan.EditValue.ToString.Trim <> "" Then
                p_SQLString = SoHopDong.EditValue.ToString.Trim
                If p_SQLString <> "" Then
                    If p_where = "" Then
                        p_where = "SoHopDong=N'" & p_SQLString & "'"
                        p_whereSAP = "SoHopDong=N'" & p_SQLString & "'"
                    Else
                        p_where = p_where & " and SoHopDong=N'" & p_SQLString & "'"
                        p_whereSAP = p_whereSAP & " and SoHopDong=N'" & p_SQLString & "'"
                    End If
                End If

                'End If
            End If

            ''p_TMP
            'If p_whereSAP = "" Then
            '    p_whereSAP = "LXLoai='" & p_LenhXuatLoai & "'"
            'Else
            '    p_whereSAP = p_whereSAP & " and LXLoai='" & p_LenhXuatLoai & "'"
            'End If
            p_TMP = ""
            Select Case p_LenhXuatPhieu
                Case "NOIDIA"
                    '1. FOB nội địa lấy thêm các lệnh đầu 2 có:
                    '                    Inco1 = FOB And MaNguon = N30
                    '2. CIF nội địa lấy thêm các lệnh đầu 2 có:
                    '                    Inco1 = CIF And MaNguon = N30
                    If p_LenhXuatLoai = "CIF" Then
                        p_TMP = "Inco1='CIF' and Manguon = 'N30' and isnull(HTTG,'') <> 'Y' "
                    Else
                        p_TMP = "Inco1='FOB' and Manguon = 'N30'   and isnull(HTTG,'') <> 'Y' "
                    End If

                    'If p_whereSAP = "" Then
                    '    p_whereSAP = p_TMP
                    'Else
                    '    p_whereSAP = p_whereSAP & " and " & p_TMP
                    'End If
                Case "DICHUYEN"
                    '5. DC có TD lấy thêm các lệnh đầu 2 có:
                    '                    POtype = P222 Or P250 Or (MaPhuongThucBan = 6 And MaNguon = N05)
                    '6. Di chuyển không TD lấy thêm các lệnh đầu 2 có:
                    '                    Potype = P223 Or P251
                    If p_LenhXuatLoai = "TD" Then  'Co TD
                        p_TMP = "(( POType in ('P222','P250') or BSART in ('P222','P250')  )  OR (MaPhuongThucBan='06'  and MaNguon ='N05')  )   and isnull(HTTG,'') <> 'Y' "
                    Else
                        p_TMP = " ( POType in ('P223','P251') or BSART in ('P223','P251') )  and isnull(HTTG,'') <> 'Y' "
                    End If
                Case "HANGGUI"
                    'Manguon = N40 or N45
                    p_TMP = "Manguon in ('N40','N45' ) "
                    'If p_whereSAP = "" Then
                    '    p_whereSAP = p_TMP
                    'Else
                    '    p_whereSAP = p_whereSAP & " and " & p_TMP
                    'End If
                Case "TAIXUAT"
                    '3. FOB tái xuất lấy thêm các lệnh đầu 2 có:
                    '                    Inco1 = FOB And MaNguon = N35
                    '4. CIF tái xuất lấy thêm các lệnh đầu 2 có:
                    '                    Inco1 = CIF And MaNguon = N35

                    If p_LenhXuatLoai = "CIF" Then
                        p_TMP = "Inco1='CIF' and Manguon = 'N35' and isnull(HTTG,'') <> 'Y' "
                    Else
                        p_TMP = "Inco1='FOB' and Manguon = 'N35' and isnull(HTTG,'') <> 'Y' "
                    End If



            End Select

            If p_whereSAP = "" Then
                p_whereSAP = p_TMP
            Else
                p_whereSAP = p_whereSAP & " and " & p_TMP
            End If


            If p_where <> "" Then
                p_where = "(" & p_where & " and isnull(LXLoai,'') ='" & p_LenhXuatLoai & "' and LXPhieu='" & p_LenhXuatPhieu & "' ) " & " OR (" & p_whereSAP & ")"
            Else
                p_where = "1=0"

            End If
            Me.GridView1.Where = p_where
            Me.DefaultFormLoad = True
            Me.LoadDataToForm()
            Me.DefaultFormLoad = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmLenhXuatCopy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        GridView1_Double()
    End Sub



    'anhqh
    '20200520
    '
    Private Sub CopyLenhXuat()
        Dim p_DataRow As DataRow
        Dim p_SoLenh As String = ""
        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                p_SoLenh = p_DataRow.Item("SoLenh").ToString.Trim
            End If
        End If

      

        If p_SoLenh = "" Then
            ShowMessageBox("", "Số lệnh không hợp lệ")
            Exit Sub
        End If

        Dim FrmLenhXuatAdd As New FrmCopyNew
        FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
        FrmLenhXuatAdd.p_FrmSoLenh = p_SoLenh
        FrmLenhXuatAdd.p_LenhXuatLoai = p_LenhXuatLoai
        FrmLenhXuatAdd.p_LenhXuatPhieu = p_LenhXuatPhieu

        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        FrmLenhXuatAdd.g_FormAddnew = False
        ' FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY
        FrmLenhXuatAdd.FormStatus = False
        FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
        FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.ShowDialog(Me)

        g_SoLenhCopy = FrmLenhXuatAdd.p_StringSoLenhReturn

        If g_SoLenhCopy <> "" Then
            Me.Close()
        End If
    End Sub

    Private Sub GridView1_Double()
        Dim p_DataRow As DataRow
        Dim p_SoLenh As String = ""
        Dim p_SQL As String = ""
        Dim p_SoLenhNew As String = ""
        Dim p_MaLenh As String = ""
        Dim p_DataTable As DataTable
        Dim p_ValueMess As Windows.Forms.DialogResult

        CopyLenhXuat()

        Exit Sub

        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                p_SoLenh = p_DataRow.Item("SoLenh").ToString.Trim
                p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                   "Bạn có chắc chắn muốn thực hiện không?", _
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
                p_SoLenhNew = LaySoLenhMoi()
                If p_SoLenhNew = "" Then
                  
                    Exit Sub
                End If
                p_MaLenh = FPT_GetMaLenh(p_SoLenh)
                If p_MaLenh = "0000" Then
                    ShowMessageBox(True, "Mã lệnh đã có trong hệ thống", 3)
                    Exit Sub
                End If

                p_SQL = "exec  SaoChepLenhXuat  '" & p_SoLenh & "','" & p_MaLenh & "','" & g_UserName & _
                                "','" & p_SoLenhNew & "','" & p_LenhXuatLoai & "','" & p_LenhXuatPhieu & "',0"
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        If p_DataTable.Rows(0).Item(0) <> 0 Then
                            ShowMessageBox("", p_DataTable.Rows(0).Item(1), 3)
                        Else
                            'ShowMessageBox("", p_DataTable.Rows(0).Item(1) & "-" & p_DataTable.Rows(0).Item(2), 1)
                            g_SoLenhCopy = p_SoLenhNew
                            Me.Close()
                        End If
                    End If

                Else
                    ShowMessageBox("", "Lỗi khi thực hiện", 3)
                End If
            End If
        End If
    End Sub


End Class