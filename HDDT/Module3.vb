Imports System.Drawing
Module Module3
    Public g_TableMessage As DataTable
    Public Const g_LISTINVBYCUSFKEY As String = "LISTINVBYCUSFKEY"    ' Kem tra ma tra cuu ton tai tren web chua
    Public Const g_IMPORTANDPUBLISHINV As String = "IMPORTANDPUBLISHINV"    'Tao hoa don len web
    Public Const g_cancelInv As String = "CANCELINV"    'Huy hoa don
    Public Const g_FindCustomer As String = "FINDCUS"    'Tim kiem khach hang
    Public Const g_UpdateCustomer As String = "UPDATECUS"    'Cap nhat thong tin khachs hang
    'Public Sub InChungTuHoaDon(ByVal p_Form As Object, ByVal p_Type As String, ByVal p_SoLenh As String)
    '    Dim l_err As String
    '    Select Case p_Type
    '        Case "HOADON"
    '            Dim p_FormHD As New frmImfor_HoaDon(p_SoLenh)
    '            p_FormHD.g_XtraServicesObj = g_Services
    '            p_FormHD.p_XtraModuleObj = g_Module
    '            p_FormHD.Show(p_Form)
    '            'Case "HOADONCT"
    '            '    Dim p_FormHD As New frmImfor_HoaDonCT(p_SoLenh)
    '            '    p_FormHD.g_XtraServicesObj = g_Services
    '            '    p_FormHD.p_XtraModuleObj = g_Module
    '            '    p_FormHD.Show(p_Form)
    '            'Case "HOADONVCNB"
    '            '    Dim p_FormHDVCNB As New frmImfor_HoaDonVCNB(p_SoLenh)
    '            '    p_FormHDVCNB.g_XtraServicesObj = g_Services
    '            '    p_FormHDVCNB.p_XtraModuleObj = g_Module
    '            '    p_FormHDVCNB.Show(p_Form)
    '            'Case "HOADONVCNB_NBN"
    '            '    Dim p_FormHDVCNB_NBN As New frmImfor_HoaDonVCNB_NBN(p_SoLenh)
    '            '    p_FormHDVCNB_NBN.g_XtraServicesObj = g_Services
    '            '    p_FormHDVCNB_NBN.p_XtraModuleObj = g_Module
    '            '    p_FormHDVCNB_NBN.Show(p_Form)
    '            'Case "HOADONVCNB_CIF"
    '            '    Dim p_FormHDVCNB_CIF As New frmImfor_HoaDonVCNB_CIF(p_SoLenh)
    '            '    p_FormHDVCNB_CIF.g_XtraServicesObj = g_Services
    '            '    p_FormHDVCNB_CIF.p_XtraModuleObj = g_Module
    '            '    p_FormHDVCNB_CIF.Show(p_Form)

    '            'Case "HOADONGIUHO"
    '            '    Dim p_FormHDGiuHo As New frmImfor_HoaDonHangGiuHo(p_SoLenh)
    '            '    p_FormHDGiuHo.g_XtraServicesObj = g_Services
    '            '    p_FormHDGiuHo.p_XtraModuleObj = g_Module
    '            '    p_FormHDGiuHo.Show(p_Form)
    '            'Case "LENHXUATKHO"
    '            '    If Not Print_LenhXuatKho(False, p_SoLenh, l_err) Then
    '            '        ShowMessageBox("", l_err)
    '            '    End If
    '            'Case "LENHXKTHEOPHOI"
    '            '    If Not Print_LenhXKTheoPhoi(False, p_SoLenh, l_err) Then
    '            '        ShowMessageBox("", l_err)
    '            '    End If
    '            'Case "LENHXUATKHOKDD"
    '            '    If Not Print_LENHXUATKHOKDD(False, p_SoLenh, l_err) Then
    '            '        ShowMessageBox("", l_err)
    '            '    End If
    '            'Case "LENHXUATKHOKDDA4"
    '            '    If Not Print_LENHXUATKHOKDDA4(False, p_SoLenh, l_err) Then
    '            '        ShowMessageBox("", l_err)
    '            '    End If

    '            'Case "TAIXUAT"
    '            '    Dim p_FormTaiXuat As New frmImfor_HoaDonTaiXuat(p_SoLenh)
    '            '    p_FormTaiXuat.g_XtraServicesObj = g_Services
    '            '    p_FormTaiXuat.p_XtraModuleObj = g_Module
    '            '    p_FormTaiXuat.Show(p_Form)


    '            'Case UCase("TaiXuatGTGT")
    '            '    Dim p_FormTaiXuatEN As New frmImfor_HoaDonTaiXuat_EN(p_SoLenh)
    '            '    p_FormTaiXuatEN.g_XtraServicesObj = g_Services
    '            '    p_FormTaiXuatEN.GTGT_EN = False
    '            '    p_FormTaiXuatEN.p_XtraModuleObj = g_Module
    '            '    p_FormTaiXuatEN.Show(p_Form)

    '            'Case UCase("TaiXuatGTGT1")
    '            '    Dim p_FormTaiXuatEN1 As New frmImfor_HoaDonTaiXuat_EN(p_SoLenh)
    '            '    p_FormTaiXuatEN1.g_XtraServicesObj = g_Services
    '            '    p_FormTaiXuatEN1.p_XtraModuleObj = g_Module
    '            '    p_FormTaiXuatEN1.GTGT_EN = True
    '            '    p_FormTaiXuatEN1.Show(p_Form)
    '            'Case UCase("BIENBANDOBE")
    '            '    If Not Print_BienBanDoBe(False, p_SoLenh, l_err) Then
    '            '        ShowMessageBox("", l_err)
    '            '    End If

    '    End Select
    'End Sub



    Public Function mdlDelivery_CheckTransmot(ByVal i_mavanchuyen As String, ByVal i_dt_para As DataTable) As String
        Dim l_bo, _
            l_thuy, _
            l_sat As String()
        Dim p_ArrRow() As DataRow
        Try
            '----------------------------------------------------------------
            '   Para:
            '       Index 0: Bo
            '       Index 1: Thuy
            '----------------------------------------------------------------
            p_ArrRow = i_dt_para.Select("Para='Bo' or Para='BO'")
            If p_ArrRow.Length > 0 Then
                l_bo = p_ArrRow(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            End If
            p_ArrRow = i_dt_para.Select("Para='Thuy' or Para='THUY'")
            If p_ArrRow.Length > 0 Then
                l_thuy = p_ArrRow(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            End If

            'l_bo = i_dt_para.Rows(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            'l_thuy = i_dt_para.Rows(1).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

            'FES KV2
            '20141014
            '            l_sat = i_dt_para.Rows(12).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

            For i As Integer = 0 To l_bo.Length - 1
                If l_bo(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Bo"
                End If
            Next

            For i As Integer = 0 To l_thuy.Length - 1
                If l_thuy(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Thuy"
                End If
            Next

            For i As Integer = 0 To l_sat.Length - 1
                If l_sat(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Sat"
                End If
            Next

            Return String.Empty

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function


    Public Sub XoaChungTu(ByVal p_LoaiChungTu As String, ByVal p_SoLenh As String, _
                                ByRef p_Error As Boolean, ByRef p_StringError As String)
        Try
            Dim p_SQL As String
            Dim p_DataTable As DataTable
            p_Error = False
            p_StringError = ""

            p_SQL = "exec HuyChungTuHoaDonDienTu '" & p_SoLenh & "','" & p_LoaiChungTu & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_StringError = p_DataTable.Rows(0).Item(1).ToString.Trim
                    If p_DataTable.Rows(0).Item(0) <> 0 Then
                        p_Error = True
                    End If
                End If
            End If
        Catch ex As Exception
            p_Error = True
            p_StringError = ex.Message
        End Try
    End Sub


End Module
