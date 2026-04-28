Module Module4


    Public Function mdlCompartment_AutoCompartment(ByVal i_dt_vehicle As DataTable, _
                                                   ByVal i_dt_header As DataTable, _
                                                   ByRef o_dt_compartment As DataTable, Optional ByVal p_LoaiXuat As String = "BO") As Boolean


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

        Dim p_DuXuat As Double


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
            Double.TryParse(p_Row.Item("TongDuXuat").ToString.Trim, p_DuXuat)
            If p_DungTichNgan < p_DuXuat Then
                Continue For
            End If
            p_AddRow = o_dt_compartment.NewRow
            p_AddRow.Item("MaNgan") = p_MaNgan
            p_AddRow.Item("SoLenh") = p_Row.Item("SoLenh")
            p_AddRow.Item("LineID") = p_Row.Item("LineID")
            p_AddRow.Item("TableID") = p_Row.Item("TableID")

            'If p_DungTichNgan >= p_DuXuat Then
            p_AddRow.Item("SoLuongDuXuat") = p_Row.Item("TongDuXuat")
            'End If

            p_AddRow.Item("DungTichNgan") = p_DungTichNgan
            p_AddRow.Item("MaLenh") = p_Row.Item("MaLenh")
            o_dt_compartment.Rows.Add(p_AddRow)
        Next

    End Function


#Region "mdlCompartment_AutoCompartmentSub"
    Public Function mdlCompartment_AutoCompartmentSub(ByVal i_row As DataRow, _
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

    Public Function mdlCompartment_AutoCompartmentSub_1(ByVal i_row As DataRow, _
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

    Public Function mdlCompartment_AutoCompartmentSub_2(ByVal i_row As DataRow, _
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

    Public Function mdlCompartment_AutoCompartmentSub_3(ByVal i_row As DataRow, _
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

    Public Function mdlCompartment_AutoCompartmentSub_4(ByVal i_row As DataRow, _
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

    Public Function mdlCompartment_AutoCompartmentSub_5(ByVal i_row As DataRow, _
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

    Public Function mdlCompartment_AutoCompartmentSub_6(ByVal i_row As DataRow, _
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

    Public Function mdlCompartment_AutoCompartmentSub_7(ByVal i_row As DataRow, _
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

    Public Function mdlCompartment_AutoCompartmentSub_8(ByVal i_row As DataRow, _
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
End Module
