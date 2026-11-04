Public Class FrmTankCerAdd
    Dim g_SoLenh As String = ""
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub SoLenh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoVaTen.EditValueChanged

    End Sub

    Private Sub FrmVehicleCerAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_TimeCreate As Integer
        Dim p_DateCreate As Date
        Dim p_SQL As String
        Dim p_Table As DataTable
        If g_SoLenh <> "" Then
            Me.HoVaTen.Properties.ReadOnly = True
            Me.NgayNhap.Properties.ReadOnly = True
            p_SQL = "select MaHangHoa, min(ThoiGianDau) as ThoiGianDau , (select top 1 SoTichKe from tblTichke  where solenh = '" & g_SoLenh & "' ) as SoTichKe " & _
                 " from  FPT_tblLenhXuatChiTietE5_V    where solenh = '" & g_SoLenh & "' and MaHangHoa ='0101002' " & _
                 " and  exists(select 1 from tbllenhxuate5 where status in ('4','5')  and solenh = '" & g_SoLenh & "')  group by MaHangHoa "
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    Me.HoVaTen.EditValue = p_Table.Rows(0).Item("SoTichKe").ToString.Trim
                    Me.NgayNhap.EditValue = p_Table.Rows(0).Item("ThoiGianDau")
                End If
            End If
        Else
            Me.HoVaTen.Properties.ReadOnly = False
            Me.HoVaTen.Enabled = True
            Me.NgayNhap.Properties.ReadOnly = False
            Me.NgayNhap.Enabled = True
            Me.NgayNhap.EditValue = ""
            Me.HoVaTen.EditValue = ""
            p_GetDateTime(p_DateCreate, p_TimeCreate)
            Me.NgayNhap.EditValue = p_DateCreate
        End If

        Me.HoVaTen.Focus()
    End Sub

    Public Sub New(ByVal p_SoLenh As String)
        g_SoLenh = p_SoLenh
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click
        Dim cl_SOAP_API As New SOAP_API.CL_SOAP_API(g_UserName)
        
        Dim p_Date As String = ""
        Dim p_SQL As String = ""
        Dim p_int As Integer
        Dim p_DataTable As DataTable
        Dim p_Table As DataTable
        Dim p_Check As Boolean = False

        Dim p_TankCode As String = ""
        Dim p_NgayKTNhap As String = ""
        Dim p_GioKTNhap As String = ""
        Dim p_ThoiGianOnDinh As Integer = 0
        Dim p_HovaTen As String = ""
        Dim p_ChucDanh As String = ""

        If Not Me.MaBe.EditValue Is Nothing Then
            p_TankCode = Me.MaBe.EditValue.ToString.Trim
        End If
        If Not Me.NgayNhap.EditValue Is Nothing Then
            p_Date = CDate(Me.NgayNhap.EditValue).ToString("yyyy-MM-dd")
        End If
        If Not Me.GioNhap.EditValue Is Nothing Then
            p_GioKTNhap = CDate(Me.GioNhap.EditValue).ToString("HH:mm:ss")
        End If

        If Not Me.ThoiGianOnDinh.EditValue Is Nothing Then
            Integer.TryParse(Me.ThoiGianOnDinh.EditValue.ToString.Trim, p_ThoiGianOnDinh)
        End If
        If Not Me.HoVaTen.EditValue Is Nothing Then
            p_HovaTen = Me.HoVaTen.EditValue.ToString.Trim
        End If
        If Not Me.ChucDanh.EditValue Is Nothing Then
            p_ChucDanh = Me.ChucDanh.EditValue.ToString.Trim
        End If
        If p_TankCode = "" Or p_Date = "" Or p_GioKTNhap = "" Or p_ThoiGianOnDinh = 0 Or p_HovaTen = "" Or p_ChucDanh = "" Then
            ShowMessageBox("", "Giá trị chưa nhập đủ")
            Exit Sub
        End If
        p_DataTable = cl_SOAP_API.GetValueFromTankCode(p_TankCode, p_Date, p_GioKTNhap, p_ThoiGianOnDinh, p_HovaTen, p_ChucDanh)

        If Not p_DataTable Is Nothing Then
            For p_int = 0 To p_DataTable.Rows.Count - 1

                p_SQL = p_DataTable.Rows(p_int).Item(0).ToString.Trim
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
                    ShowMessageBox("", p_SQL)
                    Exit Sub
                Else
                    p_Check = True
                End If
            Next
        End If

            'If p_SoTichKe <> "" And p_Date <> "" Then
            '    p_SQL = "select MaPhuongTien from tbllenhxuate5 a where exists (select 1 from tbltichke b where a.SoLenh =b.SoLenh  and b.SoTichKe = '" & p_SoTichKe & "' and b.NgayTichKe = '" & p_Date & "')"
            '    p_Table = GetDataTable(p_SQL, p_SQL)
            '    If Not p_Table Is Nothing Then
            '        If p_Table.Rows.Count > 0 Then
            '            p_MaphuongTien = p_Table.Rows(0).Item("MaPhuongTien").ToString.Trim
            '        End If
            '    End If
            '    If p_MaphuongTien <> "" Then

            '        'Kiem tra xem da co chung chi chu'

            '        p_SQL = "select 1 as nnumber from   [dbo].[tblPhuongTien_Cert] where MaPhuongTien = '" & p_MaphuongTien & "' and SoTichKe = '" & p_SoTichKe & "' and NgayXuat ='" & p_Date & "'"
            '        p_Table = GetDataTable(p_SQL, p_SQL)
            '        If Not p_Table Is Nothing Then
            '            If p_Table.Rows.Count > 0 Then
            '                ShowMessageBox("", "Chứng chỉ phương tiện đã có trên HTTG")
            '                Exit Sub
            '            End If
            '        End If


            '        p_DataTable = cl_SOAP_API.GetValueFromTankCode(p_MaphuongTien, p_Date)
            '        If Not p_DataTable Is Nothing Then
            '            For p_int = 0 To p_DataTable.Rows.Count - 1

            '                p_SQL = p_DataTable.Rows(p_int).Item(0).ToString.Trim
            '                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
            '                    ShowMessageBox("", p_SQL)
            '                    Exit Sub
            '                Else
            '                    p_Check = True
            '                End If
            '            Next
            '        End If
            '    Else
            '        ShowMessageBox("", "Phương tiện không xác định")
            '        Exit Sub
            '    End If

            'End If
            If p_Check = True Then

            Else
                ShowMessageBox("", "Không có thông tin của LMS")
            End If

            'If cl_HTTG_COMMON.g_LMS = "Y" Then
            '    p_SQL = "select  * from FPT_tblLenhXuat_HangHoaE5_V where solenh ='" & p_SoLenh & "'"
            '    p_DataTable = GetDataTable(p_SQL, p_SQL)
            '    If Not p_DataTable Is Nothing Then
            '        For p_Count = 0 To p_DataTable.Rows.Count - 1
            '            p_DataRow = p_DataTable.Rows(p_Count)
            '            p_Density = cl_SOAP_API.GetDensity(p_DataRow.Item("BeXuat"), p_DataRow.Item("MaHangHoa"))
            '            If p_Density <> p_DataRow.Item("D15_BQGQ") Then
            '                ShowMessageBox("", "Tỷ trọng hiện tại khác với tỷ trọng trên LMS:" & p_DataRow.Item("BeXuat") & ":" & p_DataRow.Item("MaHangHoa") & ":" & p_Density & "(LMS)")
            '            End If
            '        Next
            '    End If
            'End If
    End Sub
End Class