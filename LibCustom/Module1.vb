Module Module1
    Public g_Services As New Object
    Dim g_PhuongTien As String
    Dim i_dt_vehicle As System.Data.DataTable
    Dim i_dt_header As System.Data.DataTable
    Dim o_dt_compartment As System.Data.DataTable
    Dim g_dt_compartment As System.Data.DataTable


    Private Function mdlCompartment_AutoCompartment(ByVal i_dt_vehicle As DataTable, _
                                                   ByVal i_dt_header As DataTable, _
                                                   ByRef o_dt_compartment As DataTable, ByVal p_LoaiXuat As String) As Boolean

        Try
            '-------------------------------------------------------------------------
            '   Tối ưu cho từng dòng
            '-------------------------------------------------------------------------
            If UCase(p_LoaiXuat) = "THUY" Then
                mdlTichke_new_AutoComparment_Thuy(i_dt_vehicle, i_dt_header, o_dt_compartment)
                Exit Function
            End If

            For Each row As DataRow In i_dt_header.Rows
                mdlCompartment_AutoCompartmentSub(row, i_dt_vehicle, o_dt_compartment)
            Next

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Function mdlTichke_new_AutoComparment_Thuy(ByVal i_dt_vehicle As DataTable, ByVal i_dt_header As DataTable, ByRef o_dt_compartment As DataTable) As Boolean

        Dim p_MaNgan As String
        Dim p_Count As Integer
        Dim p_Row As DataRow
        Dim p_AddRow As DataRow
        Dim p_DungTichNgan As Double

        If i_dt_vehicle.Rows.Count <= 0 Then
            Return False
        End If
        If i_dt_header.Rows.Count <= 0 Then
            Return False
        End If

        p_MaNgan = i_dt_vehicle.Rows(0).Item("MaNgan").ToString.Trim
        Double.TryParse(i_dt_vehicle.Rows(0).Item("SoLuongMax").ToString.Trim, p_DungTichNgan)
        For p_Count = 0 To i_dt_header.Rows.Count - 1
            p_Row = i_dt_header.Rows(p_Count)
            p_AddRow = o_dt_compartment.NewRow
            p_AddRow.Item("MaNgan") = p_MaNgan
            p_AddRow.Item("SoLenh") = p_Row.Item("SoLenh")
            p_AddRow.Item("LineID") = p_Row.Item("LineID")
            p_AddRow.Item("TableID") = p_Row.Item("TableID")
            p_AddRow.Item("SoLuongDuXuat") = p_Row.Item("TongDuXuat")
            p_AddRow.Item("DungTichNgan") = p_DungTichNgan
            p_AddRow.Item("MaLenh") = p_Row.Item("MaLenh")
            o_dt_compartment.Rows.Add(p_AddRow)
        Next

    End Function

#Region "mdlCompartment_AutoCompartmentSub"
    Private Function mdlCompartment_AutoCompartmentSub(ByVal i_row As DataRow, _
                                                      ByRef i_dt_vehicle As DataTable, _
                                                      ByRef o_dt_compartment As DataTable) As Boolean

        'Nếu có một ngăn OK
        If mdlCompartment_AutoCompartmentSub_1(i_row, i_dt_vehicle, o_dt_compartment) Then
            Return True
        End If

        'Nếu có hai ngăn OK
        If mdlCompartment_AutoCompartmentSub_2(i_row, i_dt_vehicle, o_dt_compartment) Then
            Return True
        End If

        'Nếu có ba ngăn OK
        If mdlCompartment_AutoCompartmentSub_3(i_row, i_dt_vehicle, o_dt_compartment) Then
            Return True
        End If

        'Nếu có bốn ngăn OK
        If mdlCompartment_AutoCompartmentSub_4(i_row, i_dt_vehicle, o_dt_compartment) Then
            Return True
        End If

        'Nếu có năm ngăn OK
        If mdlCompartment_AutoCompartmentSub_5(i_row, i_dt_vehicle, o_dt_compartment) Then
            Return True
        End If

        'Nếu có năm ngăn OK
        If mdlCompartment_AutoCompartmentSub_6(i_row, i_dt_vehicle, o_dt_compartment) Then
            Return True
        End If

        'Nếu có năm ngăn OK
        If mdlCompartment_AutoCompartmentSub_7(i_row, i_dt_vehicle, o_dt_compartment) Then
            Return True
        End If

        'Nếu có năm ngăn OK
        If mdlCompartment_AutoCompartmentSub_8(i_row, i_dt_vehicle, o_dt_compartment) Then
            Return True
        End If
        Return False


    End Function

    Private Function mdlCompartment_AutoCompartmentSub_1(ByVal i_row As DataRow, _
                                                        ByRef o_dt_vehicle As DataTable, _
                                                        ByRef o_dt_compartment As DataTable) As Boolean
        Dim l_sl_con As Decimal

        Dim l_dr As DataRow

        l_sl_con = i_row.Item("TongDuXuat").ToString()

        'Nếu có một ngăn OK
        For i As Integer = 0 To o_dt_vehicle.Rows.Count - 1
            If o_dt_vehicle.Rows(i).Item("Select") = String.Empty Then
                Continue For
            End If

            If l_sl_con = o_dt_vehicle.Rows(i).Item("SoLuongMax") Then
                l_dr = o_dt_compartment.NewRow()
                l_dr.Item("MaNgan") = o_dt_vehicle.Rows(i).Item("MaNgan").ToString()
                l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                l_dr.Item("SoLuongDuXuat") = l_sl_con.ToString()
                o_dt_compartment.Rows.Add(l_dr)

                o_dt_vehicle.Rows(i).Item("Select") = String.Empty
                Return True
            End If
        Next

        Return False

    End Function

    Private Function mdlCompartment_AutoCompartmentSub_2(ByVal i_row As DataRow, _
                                                        ByRef o_dt_vehicle As DataTable, _
                                                        ByRef o_dt_compartment As DataTable) As Boolean
        Dim l_sl_xep, _
                    l_sl_con As Decimal

        Dim l_dr As DataRow

        l_sl_con = i_row.Item("TongDuXuat").ToString()

        'Dim l_frm As frmTest
        'l_frm = New frmTest(o_dt_compartment)
        'l_frm.ShowDialog()

        'Nếu có hai ngăn OK
        For i As Integer = 0 To o_dt_vehicle.Rows.Count - 1
            If o_dt_vehicle.Rows(i).Item("Select") = String.Empty Then
                Continue For
            End If

            For j As Integer = i + 1 To o_dt_vehicle.Rows.Count - 1
                If o_dt_vehicle.Rows(j).Item("Select") = String.Empty Then
                    Continue For
                End If

                l_sl_xep = o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()
                l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString())

                If l_sl_con = l_sl_xep Then
                    l_dr = o_dt_compartment.NewRow()
                    l_dr.Item("MaNgan") = o_dt_vehicle.Rows(i).Item("MaNgan").ToString()
                    l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                    l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                    l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                    l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()).ToString()
                    o_dt_compartment.Rows.Add(l_dr)

                    l_dr = o_dt_compartment.NewRow()
                    l_dr.Item("MaNgan") = o_dt_vehicle.Rows(j).Item("MaNgan").ToString()
                    l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                    l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                    l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                    l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString()).ToString()
                    o_dt_compartment.Rows.Add(l_dr)

                    o_dt_vehicle.Rows(i).Item("Select") = String.Empty
                    o_dt_vehicle.Rows(j).Item("Select") = String.Empty
                    Return True
                End If
            Next
        Next

        Return False

    End Function

    Private Function mdlCompartment_AutoCompartmentSub_3(ByVal i_row As DataRow, _
                                                        ByRef o_dt_vehicle As DataTable, _
                                                        ByRef o_dt_compartment As DataTable) As Boolean
        Dim l_sl_xep, _
            l_sl_con As Decimal

        Dim l_dr As DataRow

        l_sl_con = i_row.Item("TongDuXuat").ToString()

        For i As Integer = 0 To o_dt_vehicle.Rows.Count - 1
            If o_dt_vehicle.Rows(i).Item("Select") = String.Empty Then
                Continue For
            End If


            For j As Integer = i + 1 To o_dt_vehicle.Rows.Count - 1
                If o_dt_vehicle.Rows(j).Item("Select") = String.Empty Then
                    Continue For
                End If


                For k As Integer = j + 1 To o_dt_vehicle.Rows.Count - 1
                    If o_dt_vehicle.Rows(k).Item("Select") = String.Empty Then
                        Continue For
                    End If

                    l_sl_xep = o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()
                    l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString())
                    l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString())

                    If l_sl_con = l_sl_xep Then
                        l_dr = o_dt_compartment.NewRow()
                        l_dr.Item("MaNgan") = o_dt_vehicle.Rows(i).Item("MaNgan").ToString()
                        l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                        l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                        l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                        l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()).ToString()
                        o_dt_compartment.Rows.Add(l_dr)

                        l_dr = o_dt_compartment.NewRow()
                        l_dr.Item("MaNgan") = o_dt_vehicle.Rows(j).Item("MaNgan").ToString()
                        l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                        l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                        l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                        l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString()).ToString()
                        o_dt_compartment.Rows.Add(l_dr)

                        l_dr = o_dt_compartment.NewRow()
                        l_dr.Item("MaNgan") = o_dt_vehicle.Rows(k).Item("MaNgan").ToString()
                        l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                        l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                        l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                        l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString()).ToString()
                        o_dt_compartment.Rows.Add(l_dr)

                        o_dt_vehicle.Rows(i).Item("Select") = String.Empty
                        o_dt_vehicle.Rows(j).Item("Select") = String.Empty
                        o_dt_vehicle.Rows(k).Item("Select") = String.Empty
                        Return True
                    End If

                Next
            Next
        Next

        Return False

    End Function

    Private Function mdlCompartment_AutoCompartmentSub_4(ByVal i_row As DataRow, _
                                                        ByRef o_dt_vehicle As DataTable, _
                                                        ByRef o_dt_compartment As DataTable) As Boolean
        Dim l_sl_xep, _
            l_sl_con As Decimal

        Dim l_dr As DataRow

        l_sl_con = i_row.Item("TongDuXuat").ToString()

        For i As Integer = 0 To o_dt_vehicle.Rows.Count - 1
            If o_dt_vehicle.Rows(i).Item("Select") = String.Empty Then
                Continue For
            End If


            For j As Integer = i + 1 To o_dt_vehicle.Rows.Count - 1
                If o_dt_vehicle.Rows(j).Item("Select") = String.Empty Then
                    Continue For
                End If


                For k As Integer = j + 1 To o_dt_vehicle.Rows.Count - 1
                    If o_dt_vehicle.Rows(k).Item("Select") = String.Empty Then
                        Continue For
                    End If


                    For l As Integer = k + 1 To o_dt_vehicle.Rows.Count - 1

                        If o_dt_vehicle.Rows(l).Item("Select") = String.Empty Then
                            Continue For
                        End If

                        l_sl_xep = o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()
                        l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString())
                        l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString())
                        l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(l).Item("SoLuongMax").ToString())

                        If l_sl_con = l_sl_xep Then
                            l_dr = o_dt_compartment.NewRow()
                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(i).Item("MaNgan").ToString()
                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()).ToString()
                            o_dt_compartment.Rows.Add(l_dr)

                            l_dr = o_dt_compartment.NewRow()
                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(j).Item("MaNgan").ToString()
                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString()).ToString()
                            o_dt_compartment.Rows.Add(l_dr)

                            l_dr = o_dt_compartment.NewRow()
                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(k).Item("MaNgan").ToString()
                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString()).ToString()
                            o_dt_compartment.Rows.Add(l_dr)

                            l_dr = o_dt_compartment.NewRow()
                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(l).Item("MaNgan").ToString()
                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(l).Item("SoLuongMax").ToString()).ToString()
                            o_dt_compartment.Rows.Add(l_dr)

                            o_dt_vehicle.Rows(i).Item("Select") = String.Empty
                            o_dt_vehicle.Rows(j).Item("Select") = String.Empty
                            o_dt_vehicle.Rows(k).Item("Select") = String.Empty
                            o_dt_vehicle.Rows(l).Item("Select") = String.Empty
                            Return True
                        End If

                    Next

                Next
            Next
        Next

        Return False

    End Function

    Private Function mdlCompartment_AutoCompartmentSub_5(ByVal i_row As DataRow, _
                                                    ByRef o_dt_vehicle As DataTable, _
                                                    ByRef o_dt_compartment As DataTable) As Boolean
        Dim l_sl_xep, _
            l_sl_con As Decimal

        Dim l_dr As DataRow

        l_sl_con = i_row.Item("TongDuXuat").ToString()

        For i As Integer = 0 To o_dt_vehicle.Rows.Count - 1
            If o_dt_vehicle.Rows(i).Item("Select") = String.Empty Then
                Continue For
            End If


            For j As Integer = i + 1 To o_dt_vehicle.Rows.Count - 1
                If o_dt_vehicle.Rows(j).Item("Select") = String.Empty Then
                    Continue For
                End If


                For k As Integer = j + 1 To o_dt_vehicle.Rows.Count - 1
                    If o_dt_vehicle.Rows(k).Item("Select") = String.Empty Then
                        Continue For
                    End If


                    For l As Integer = k + 1 To o_dt_vehicle.Rows.Count - 1
                        If o_dt_vehicle.Rows(l).Item("Select") = String.Empty Then
                            Continue For
                        End If

                        For m As Integer = l + 1 To o_dt_vehicle.Rows.Count - 1
                            If o_dt_vehicle.Rows(m).Item("Select") = String.Empty Then
                                Continue For
                            End If

                            l_sl_xep = o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()
                            l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString())
                            l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString())
                            l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(l).Item("SoLuongMax").ToString())
                            l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(m).Item("SoLuongMax").ToString())

                            If l_sl_con = l_sl_xep Then
                                l_dr = o_dt_compartment.NewRow()
                                l_dr.Item("MaNgan") = o_dt_vehicle.Rows(i).Item("MaNgan").ToString()
                                l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()).ToString()
                                o_dt_compartment.Rows.Add(l_dr)

                                l_dr = o_dt_compartment.NewRow()
                                l_dr.Item("MaNgan") = o_dt_vehicle.Rows(j).Item("MaNgan").ToString()
                                l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString()).ToString()
                                o_dt_compartment.Rows.Add(l_dr)

                                l_dr = o_dt_compartment.NewRow()
                                l_dr.Item("MaNgan") = o_dt_vehicle.Rows(k).Item("MaNgan").ToString()
                                l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString()).ToString()
                                o_dt_compartment.Rows.Add(l_dr)

                                l_dr = o_dt_compartment.NewRow()
                                l_dr.Item("MaNgan") = o_dt_vehicle.Rows(l).Item("MaNgan").ToString()
                                l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(l).Item("SoLuongMax").ToString()).ToString()
                                o_dt_compartment.Rows.Add(l_dr)

                                l_dr = o_dt_compartment.NewRow()
                                l_dr.Item("MaNgan") = o_dt_vehicle.Rows(m).Item("MaNgan").ToString()
                                l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(m).Item("SoLuongMax").ToString()).ToString()
                                o_dt_compartment.Rows.Add(l_dr)

                                o_dt_vehicle.Rows(i).Item("Select") = String.Empty
                                o_dt_vehicle.Rows(j).Item("Select") = String.Empty
                                o_dt_vehicle.Rows(k).Item("Select") = String.Empty
                                o_dt_vehicle.Rows(l).Item("Select") = String.Empty
                                o_dt_vehicle.Rows(m).Item("Select") = String.Empty
                                Return True
                            End If
                        Next

                    Next

                Next
            Next
        Next

        Return False

    End Function

    Private Function mdlCompartment_AutoCompartmentSub_6(ByVal i_row As DataRow, _
                                                    ByRef o_dt_vehicle As DataTable, _
                                                    ByRef o_dt_compartment As DataTable) As Boolean
        Dim l_sl_xep, _
            l_sl_con As Decimal

        Dim l_dr As DataRow

        l_sl_con = i_row.Item("TongDuXuat").ToString()

        For i As Integer = 0 To o_dt_vehicle.Rows.Count - 1
            If o_dt_vehicle.Rows(i).Item("Select") = String.Empty Then
                Continue For
            End If


            For j As Integer = i + 1 To o_dt_vehicle.Rows.Count - 1
                If o_dt_vehicle.Rows(j).Item("Select") = String.Empty Then
                    Continue For
                End If


                For k As Integer = j + 1 To o_dt_vehicle.Rows.Count - 1
                    If o_dt_vehicle.Rows(k).Item("Select") = String.Empty Then
                        Continue For
                    End If


                    For l As Integer = k + 1 To o_dt_vehicle.Rows.Count - 1
                        If o_dt_vehicle.Rows(l).Item("Select") = String.Empty Then
                            Continue For
                        End If

                        For m As Integer = l + 1 To o_dt_vehicle.Rows.Count - 1
                            If o_dt_vehicle.Rows(m).Item("Select") = String.Empty Then
                                Continue For
                            End If

                            For n As Integer = m + 1 To o_dt_vehicle.Rows.Count - 1
                                If o_dt_vehicle.Rows(n).Item("Select") = String.Empty Then
                                    Continue For
                                End If

                                l_sl_xep = o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()
                                l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString())
                                l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString())
                                l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(l).Item("SoLuongMax").ToString())
                                l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(m).Item("SoLuongMax").ToString())
                                l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(n).Item("SoLuongMax").ToString())

                                If l_sl_con = l_sl_xep Then
                                    l_dr = o_dt_compartment.NewRow()
                                    l_dr.Item("MaNgan") = o_dt_vehicle.Rows(i).Item("MaNgan").ToString()
                                    l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                    l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                    l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                    l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()).ToString()
                                    o_dt_compartment.Rows.Add(l_dr)

                                    l_dr = o_dt_compartment.NewRow()
                                    l_dr.Item("MaNgan") = o_dt_vehicle.Rows(j).Item("MaNgan").ToString()
                                    l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                    l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                    l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                    l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString()).ToString()
                                    o_dt_compartment.Rows.Add(l_dr)

                                    l_dr = o_dt_compartment.NewRow()
                                    l_dr.Item("MaNgan") = o_dt_vehicle.Rows(k).Item("MaNgan").ToString()
                                    l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                    l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                    l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                    l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString()).ToString()
                                    o_dt_compartment.Rows.Add(l_dr)

                                    l_dr = o_dt_compartment.NewRow()
                                    l_dr.Item("MaNgan") = o_dt_vehicle.Rows(l).Item("MaNgan").ToString()
                                    l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                    l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                    l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                    l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(l).Item("SoLuongMax").ToString()).ToString()
                                    o_dt_compartment.Rows.Add(l_dr)

                                    l_dr = o_dt_compartment.NewRow()
                                    l_dr.Item("MaNgan") = o_dt_vehicle.Rows(m).Item("MaNgan").ToString()
                                    l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                    l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                    l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                    l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(m).Item("SoLuongMax").ToString()).ToString()
                                    o_dt_compartment.Rows.Add(l_dr)

                                    l_dr = o_dt_compartment.NewRow()
                                    l_dr.Item("MaNgan") = o_dt_vehicle.Rows(n).Item("MaNgan").ToString()
                                    l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                    l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                    l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                    l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(n).Item("SoLuongMax").ToString()).ToString()
                                    o_dt_compartment.Rows.Add(l_dr)

                                    o_dt_vehicle.Rows(i).Item("Select") = String.Empty
                                    o_dt_vehicle.Rows(j).Item("Select") = String.Empty
                                    o_dt_vehicle.Rows(k).Item("Select") = String.Empty
                                    o_dt_vehicle.Rows(l).Item("Select") = String.Empty
                                    o_dt_vehicle.Rows(m).Item("Select") = String.Empty
                                    o_dt_vehicle.Rows(n).Item("Select") = String.Empty
                                    Return True
                                End If
                            Next

                        Next

                    Next

                Next
            Next
        Next

        Return False

    End Function

    Private Function mdlCompartment_AutoCompartmentSub_7(ByVal i_row As DataRow, _
                                                    ByRef o_dt_vehicle As DataTable, _
                                                    ByRef o_dt_compartment As DataTable) As Boolean
        Dim l_sl_xep, _
            l_sl_con As Decimal

        Dim l_dr As DataRow

        l_sl_con = i_row.Item("TongDuXuat").ToString()

        For i As Integer = 0 To o_dt_vehicle.Rows.Count - 1
            If o_dt_vehicle.Rows(i).Item("Select") = String.Empty Then
                Continue For
            End If


            For j As Integer = i + 1 To o_dt_vehicle.Rows.Count - 1
                If o_dt_vehicle.Rows(j).Item("Select") = String.Empty Then
                    Continue For
                End If


                For k As Integer = j + 1 To o_dt_vehicle.Rows.Count - 1
                    If o_dt_vehicle.Rows(k).Item("Select") = String.Empty Then
                        Continue For
                    End If


                    For l As Integer = k + 1 To o_dt_vehicle.Rows.Count - 1
                        If o_dt_vehicle.Rows(l).Item("Select") = String.Empty Then
                            Continue For
                        End If

                        For m As Integer = l + 1 To o_dt_vehicle.Rows.Count - 1
                            If o_dt_vehicle.Rows(m).Item("Select") = String.Empty Then
                                Continue For
                            End If

                            For n As Integer = m + 1 To o_dt_vehicle.Rows.Count - 1
                                If o_dt_vehicle.Rows(n).Item("Select") = String.Empty Then
                                    Continue For
                                End If

                                For p As Integer = n + 1 To o_dt_vehicle.Rows.Count - 1
                                    If o_dt_vehicle.Rows(p).Item("Select") = String.Empty Then
                                        Continue For
                                    End If
                                    l_sl_xep = o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()
                                    l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString())
                                    l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString())
                                    l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(l).Item("SoLuongMax").ToString())
                                    l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(m).Item("SoLuongMax").ToString())
                                    l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(n).Item("SoLuongMax").ToString())
                                    l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(p).Item("SoLuongMax").ToString())

                                    If l_sl_con = l_sl_xep Then
                                        l_dr = o_dt_compartment.NewRow()
                                        l_dr.Item("MaNgan") = o_dt_vehicle.Rows(i).Item("MaNgan").ToString()
                                        l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                        l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                        l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                        l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()).ToString()
                                        o_dt_compartment.Rows.Add(l_dr)

                                        l_dr = o_dt_compartment.NewRow()
                                        l_dr.Item("MaNgan") = o_dt_vehicle.Rows(j).Item("MaNgan").ToString()
                                        l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                        l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                        l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                        l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString()).ToString()
                                        o_dt_compartment.Rows.Add(l_dr)

                                        l_dr = o_dt_compartment.NewRow()
                                        l_dr.Item("MaNgan") = o_dt_vehicle.Rows(k).Item("MaNgan").ToString()
                                        l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                        l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                        l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                        l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString()).ToString()
                                        o_dt_compartment.Rows.Add(l_dr)

                                        l_dr = o_dt_compartment.NewRow()
                                        l_dr.Item("MaNgan") = o_dt_vehicle.Rows(l).Item("MaNgan").ToString()
                                        l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                        l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                        l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                        l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(l).Item("SoLuongMax").ToString()).ToString()
                                        o_dt_compartment.Rows.Add(l_dr)

                                        l_dr = o_dt_compartment.NewRow()
                                        l_dr.Item("MaNgan") = o_dt_vehicle.Rows(m).Item("MaNgan").ToString()
                                        l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                        l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                        l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                        l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(m).Item("SoLuongMax").ToString()).ToString()
                                        o_dt_compartment.Rows.Add(l_dr)

                                        l_dr = o_dt_compartment.NewRow()
                                        l_dr.Item("MaNgan") = o_dt_vehicle.Rows(n).Item("MaNgan").ToString()
                                        l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                        l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                        l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                        l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(n).Item("SoLuongMax").ToString()).ToString()
                                        o_dt_compartment.Rows.Add(l_dr)

                                        l_dr = o_dt_compartment.NewRow()
                                        l_dr.Item("MaNgan") = o_dt_vehicle.Rows(p).Item("MaNgan").ToString()
                                        l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                        l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                        l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                        l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(p).Item("SoLuongMax").ToString()).ToString()
                                        o_dt_compartment.Rows.Add(l_dr)

                                        o_dt_vehicle.Rows(i).Item("Select") = String.Empty
                                        o_dt_vehicle.Rows(j).Item("Select") = String.Empty
                                        o_dt_vehicle.Rows(k).Item("Select") = String.Empty
                                        o_dt_vehicle.Rows(l).Item("Select") = String.Empty
                                        o_dt_vehicle.Rows(m).Item("Select") = String.Empty
                                        o_dt_vehicle.Rows(n).Item("Select") = String.Empty
                                        o_dt_vehicle.Rows(p).Item("Select") = String.Empty
                                        Return True
                                    End If

                                Next

                            Next

                        Next

                    Next

                Next
            Next
        Next

        Return False

    End Function

    Private Function mdlCompartment_AutoCompartmentSub_8(ByVal i_row As DataRow, _
                                                    ByRef o_dt_vehicle As DataTable, _
                                                    ByRef o_dt_compartment As DataTable) As Boolean
        Dim l_sl_xep, _
            l_sl_con As Decimal

        Dim l_dr As DataRow

        l_sl_con = i_row.Item("TongDuXuat").ToString()

        For i As Integer = 0 To o_dt_vehicle.Rows.Count - 1
            If o_dt_vehicle.Rows(i).Item("Select") = String.Empty Then
                Continue For
            End If


            For j As Integer = i + 1 To o_dt_vehicle.Rows.Count - 1
                If o_dt_vehicle.Rows(j).Item("Select") = String.Empty Then
                    Continue For
                End If


                For k As Integer = j + 1 To o_dt_vehicle.Rows.Count - 1
                    If o_dt_vehicle.Rows(k).Item("Select") = String.Empty Then
                        Continue For
                    End If


                    For l As Integer = k + 1 To o_dt_vehicle.Rows.Count - 1
                        If o_dt_vehicle.Rows(l).Item("Select") = String.Empty Then
                            Continue For
                        End If

                        For m As Integer = l + 1 To o_dt_vehicle.Rows.Count - 1
                            If o_dt_vehicle.Rows(m).Item("Select") = String.Empty Then
                                Continue For
                            End If

                            For n As Integer = m + 1 To o_dt_vehicle.Rows.Count - 1
                                If o_dt_vehicle.Rows(n).Item("Select") = String.Empty Then
                                    Continue For
                                End If

                                For p As Integer = n + 1 To o_dt_vehicle.Rows.Count - 1
                                    If o_dt_vehicle.Rows(p).Item("Select") = String.Empty Then
                                        Continue For
                                    End If

                                    For q As Integer = p + 1 To o_dt_vehicle.Rows.Count - 1
                                        If o_dt_vehicle.Rows(q).Item("Select") = String.Empty Then
                                            Continue For
                                        End If
                                        l_sl_xep = o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()
                                        l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString())
                                        l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString())
                                        l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(l).Item("SoLuongMax").ToString())
                                        l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(m).Item("SoLuongMax").ToString())
                                        l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(n).Item("SoLuongMax").ToString())
                                        l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(p).Item("SoLuongMax").ToString())
                                        l_sl_xep = l_sl_xep + Convert.ToDecimal(o_dt_vehicle.Rows(q).Item("SoLuongMax").ToString())

                                        If l_sl_con = l_sl_xep Then
                                            l_dr = o_dt_compartment.NewRow()
                                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(i).Item("MaNgan").ToString()
                                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()).ToString()
                                            o_dt_compartment.Rows.Add(l_dr)

                                            l_dr = o_dt_compartment.NewRow()
                                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(j).Item("MaNgan").ToString()
                                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(j).Item("SoLuongMax").ToString()).ToString()
                                            o_dt_compartment.Rows.Add(l_dr)

                                            l_dr = o_dt_compartment.NewRow()
                                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(k).Item("MaNgan").ToString()
                                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(k).Item("SoLuongMax").ToString()).ToString()
                                            o_dt_compartment.Rows.Add(l_dr)

                                            l_dr = o_dt_compartment.NewRow()
                                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(l).Item("MaNgan").ToString()
                                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(l).Item("SoLuongMax").ToString()).ToString()
                                            o_dt_compartment.Rows.Add(l_dr)

                                            l_dr = o_dt_compartment.NewRow()
                                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(m).Item("MaNgan").ToString()
                                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(m).Item("SoLuongMax").ToString()).ToString()
                                            o_dt_compartment.Rows.Add(l_dr)

                                            l_dr = o_dt_compartment.NewRow()
                                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(n).Item("MaNgan").ToString()
                                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(n).Item("SoLuongMax").ToString()).ToString()
                                            o_dt_compartment.Rows.Add(l_dr)

                                            l_dr = o_dt_compartment.NewRow()
                                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(p).Item("MaNgan").ToString()
                                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(p).Item("SoLuongMax").ToString()).ToString()
                                            o_dt_compartment.Rows.Add(l_dr)

                                            l_dr = o_dt_compartment.NewRow()
                                            l_dr.Item("MaNgan") = o_dt_vehicle.Rows(q).Item("MaNgan").ToString()
                                            l_dr.Item("SoLenh") = i_row.Item("SoLenh").ToString()
                                            l_dr.Item("LineID") = i_row.Item("LineID").ToString()
                                            l_dr.Item("TableID") = i_row.Item("TableID").ToString()
                                            l_dr.Item("SoLuongDuXuat") = Convert.ToDecimal(o_dt_vehicle.Rows(q).Item("SoLuongMax").ToString()).ToString()
                                            o_dt_compartment.Rows.Add(l_dr)

                                            o_dt_vehicle.Rows(i).Item("Select") = String.Empty
                                            o_dt_vehicle.Rows(j).Item("Select") = String.Empty
                                            o_dt_vehicle.Rows(k).Item("Select") = String.Empty
                                            o_dt_vehicle.Rows(l).Item("Select") = String.Empty
                                            o_dt_vehicle.Rows(m).Item("Select") = String.Empty
                                            o_dt_vehicle.Rows(n).Item("Select") = String.Empty
                                            o_dt_vehicle.Rows(p).Item("Select") = String.Empty
                                            o_dt_vehicle.Rows(q).Item("Select") = String.Empty
                                            Return True
                                        End If

                                    Next

                                Next

                            Next

                        Next

                    Next

                Next
            Next
        Next

        Return False

    End Function
#End Region



#Region "Tu dong chi ngan"
    Private Sub Load1(ByVal p_dt_vehicle As System.Data.DataTable, ByVal p_PhuongTien As String, ByVal p_TableLine As System.Data.DataTable, _
                        ByRef p_dt_compartment As System.Data.DataTable, ByVal p_LoaiXuat As String)
        Dim p_SQL As String

        Dim p_Count As Integer
        Dim p_DataRow As DataRow
        Dim p_Column As Integer
        Dim g_SoLenh As String

        'Dim p_TableHangHoa As DataTable = Nothing
        'Dim g_TableLine As DataTable

        i_dt_vehicle = p_dt_vehicle

        ' g_PhuongTien = p_PhuongTien
        'g_TableLine = p_TableLine
        Try
            'p_SQL = "select MaNgan, SoLuongMax, 'X' as [Select] from FPT_tblChiTietPhuongTien_V where MaPhuongTien ='" & p_PhuongTien & "' ORDER By MaNgan"
            'i_dt_vehicle = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

            If i_dt_header Is Nothing Then
                i_dt_header = New DataTable
                i_dt_header.Columns.Add("SoLenh")
                i_dt_header.Columns.Add("LineID")
                i_dt_header.Columns.Add("TableID")
                i_dt_header.Columns.Add("TongDuXuat", Type.GetType("System.Int32"))
                i_dt_header.Columns.Add("MaHangHoa")
                i_dt_header.Columns.Add("MaLenh")
                i_dt_header.Columns.Add("NgayXuat", GetType(DateTime))
            ElseIf i_dt_header.Columns.Count = 0 Then
                i_dt_header.Columns.Add("SoLenh")
                i_dt_header.Columns.Add("LineID")
                i_dt_header.Columns.Add("TableID")
                i_dt_header.Columns.Add("TongDuXuat", Type.GetType("System.Int32"))
                i_dt_header.Columns.Add("MaHangHoa")
                i_dt_header.Columns.Add("MaLenh")
                i_dt_header.Columns.Add("NgayXuat", GetType(DateTime))
            End If
            If p_TableLine Is Nothing Then
                Exit Sub
            End If
            i_dt_header.Clear()
            For p_Count = 0 To p_TableLine.Rows.Count - 1
                p_DataRow = i_dt_header.NewRow
                p_DataRow.Item("SoLenh") = p_TableLine.Rows(p_Count).Item("SoLenh").ToString.Trim
                p_DataRow.Item("LineID") = p_TableLine.Rows(p_Count).Item("LineID").ToString.Trim
                p_DataRow.Item("TableID") = p_TableLine.Rows(p_Count).Item("TableID").ToString.Trim
                p_DataRow.Item("TongDuXuat") = IIf(p_TableLine.Rows(p_Count).Item("TongXuat").ToString.Trim = "", 0, p_TableLine.Rows(p_Count).Item("TongXuat"))
                p_DataRow.Item("MaHangHoa") = p_TableLine.Rows(p_Count).Item("MaHangHoa").ToString.Trim
                p_DataRow.Item("MaLenh") = p_TableLine.Rows(p_Count).Item("MaLenh").ToString.Trim

                p_DataRow.Item("NgayXuat") = p_TableLine.Rows(p_Count).Item("NgayXuat").ToString.Trim

                i_dt_header.Rows.Add(p_DataRow)
            Next

            'p_SQL = "select SoLenh, LineID, TableID,case when isnull(TongXuat,0)>0 then TongXuat else TongDuXuat end TongDuXuat, MaHangHoa, " & _
            '        " MaLenh from tblLenhXuat_HangHoaE5 with (nolock) where CHARINDEX ( SoLenh, '" & g_SoLenh & "' ,1) >0 and  SoLenh <>'0' "
            'i_dt_header = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

            'o_dt_compartment = i_dt_header.Clone
            'o_dt_compartment.Clear()
            o_dt_compartment = New DataTable
            o_dt_compartment.Columns.Add("MaNgan")
            o_dt_compartment.Columns.Add("SoLenh")
            o_dt_compartment.Columns.Add("LineID")
            o_dt_compartment.Columns.Add("TableID")
            o_dt_compartment.Columns.Add("SoLuongDuXuat")
            o_dt_compartment.Columns.Add("MaHangHoa")
            o_dt_compartment.Columns.Add("DungTichNgan", Type.GetType("System.Int32"))
            o_dt_compartment.Columns.Add("MaLenh")
            o_dt_compartment.Columns.Add("NgayXuat", GetType(DateTime))

            If Not g_dt_compartment Is Nothing Then
                g_dt_compartment.Clear()
            End If


            TuDongChiaNgan(p_LoaiXuat)
            p_dt_compartment = g_dt_compartment
            'SetVehicle()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TuDongChiaNgan(ByVal p_LoaiXuat As String)
        ' Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_RowArr() As DataRow
        Dim p_DataRow As DataRow
        Dim p_MaNgan As String
        Dim p_TableID As String
        ' Dim p_Column As U_TextBox.GridColumn
        Dim p_Count As Integer
        Dim p_CurrentValue As String
        Dim p_CurrentName As String
        o_dt_compartment.Clear()


        mdlCompartment_AutoCompartment(i_dt_vehicle, i_dt_header, o_dt_compartment, p_LoaiXuat)

        For p_Count = 0 To o_dt_compartment.Rows.Count - 1
            p_DataRow = o_dt_compartment.Rows(p_Count)
            p_TableID = p_DataRow.Item("TableID").ToString.Trim
            p_RowArr = i_dt_header.Select("TableID='" & p_TableID & "'")
            If p_RowArr.Length > 0 Then
                o_dt_compartment.Rows(p_Count).Item("MaHangHoa") = p_RowArr(0).Item("MaHangHoa").ToString.Trim
            End If
            p_MaNgan = p_DataRow.Item("MaNgan").ToString.Trim
            o_dt_compartment.Rows(p_Count).Item("MaLenh") = p_RowArr(0).Item("MaLenh").ToString.Trim

            p_RowArr = i_dt_vehicle.Select("MaNgan='" & p_MaNgan & "'")
            If p_RowArr.Length > 0 Then
                o_dt_compartment.Rows(p_Count).Item("DungTichNgan") = p_RowArr(0).Item("SoLuongMax").ToString.Trim
            End If

        Next

        g_dt_compartment = o_dt_compartment
    End Sub



    Public Sub LoadDefault(ByVal p_dt_vehicle As System.Data.DataTable, ByVal p_PhuongTien As String, ByVal p_TableHangHoa As System.Data.DataTable, _
                            ByRef p_TableReturn As System.Data.DataTable, ByVal p_LoaiXuat As String)
        Dim p_TableLine As New DataTable
        ' Dim 
        Dim p_Column As DataColumn
        ' Dim p_TableNgan As New DataTable

        If p_TableReturn Is Nothing Then
            p_TableReturn = New DataTable("Table001")
        End If
        p_TableLine = p_TableHangHoa

        Load1(p_dt_vehicle, p_PhuongTien, p_TableLine, p_TableReturn, p_LoaiXuat)

        'p_Column = p_TableHangHoa.Columns("NgayXuat")
        ' p_TableReturn.Columns.Add("NgayXuat", GetType(DateTime))
    End Sub

#End Region

End Module
