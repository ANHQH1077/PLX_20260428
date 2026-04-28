Imports System.Timers

Module Module4



    Public Sub Main()
        p_GetSystemInfor()

        'g_SyncMaster.clsHistStringSyn("SoLenh1111", True)

        ExecRuntimeLenhXuat()
    End Sub


    Public Class Service1




        'private



        Dim timer As Timer


        Dim timer2 As Timer

        Dim timer3 As Timer

        Dim timer4 As Timer
        Dim timer5 As Timer
        Dim timer6 As Timer
        Dim timer7 As Timer

        Dim timer8 As Timer
        Dim timer9 As Timer

       
        Protected Sub OnStart()

            p_GetSystemInfor()

            '=================================================================================================
            If g_Interval1_Start = True Then   'Tu dong dong bo lenh SAP
                timer = New Timer
                AddHandler timer.Elapsed, AddressOf OnElapsedTime
                timer.Interval = g_Interval1   '600000   '10 minute
                timer.Enabled = True
            End If
            '=================================================================================================
            If g_Interval2_Start = True Then    'Rut hong xuat
                timer2 = New Timer
                AddHandler timer2.Elapsed, AddressOf OnElapsedTime99
                timer2.Interval = g_Interval2   ' 60000   '1 phut
                timer2.Enabled = True
            End If
            '=================================================================================================
            If g_Interval3_Start = True Then    'Dong bo  khach hang
                timer3 = New Timer
                AddHandler timer3.Elapsed, AddressOf OnElapsedTime88
                timer3.Interval = g_Interval3   ' 60000   '1 phut
                timer3.Enabled = True
            End If
            '=================================================================================================
            If g_Interval4_Start = True Then    'Dong bo  Hop dong
                timer4 = New Timer
                AddHandler timer4.Elapsed, AddressOf OnElapsedTimeHopDong
                timer4.Interval = g_Interval4   ' 60000   '1 phut
                timer4.Enabled = True
            End If
            '=================================================================================================
            If g_Interval5_Start = True Then    'Dong bo  ton kho to khai
                timer5 = New Timer
                AddHandler timer5.Elapsed, AddressOf OnElapsedTonKhoToKhai
                timer5.Interval = g_Interval5   ' 60000   '1 phut
                timer5.Enabled = True
            End If

            '=================================================================================================
            If g_Interval6_Start = True Then    'Dong bo  tuyen duong
                timer6 = New Timer
                AddHandler timer6.Elapsed, AddressOf OnElapsedTuyenDuong
                timer6.Interval = g_Interval6   ' 60000   '1 phut
                timer6.Enabled = True
            End If

            '=================================================================================================
            If g_Interval7_Start = True Then    'Dong bo STO
                timer7 = New Timer
                AddHandler timer7.Elapsed, AddressOf OnElapsedTimeSTO
                timer7.Interval = g_Interval7   ' 60000   '1 phut
                timer7.Enabled = True
            End If



            '=================================================================================================
            If g_Interval8_Start = True Then    'Dong bo  Dơn gia
                timer8 = New Timer
                AddHandler timer8.Elapsed, AddressOf OnElapsedTimeDonGia
                timer8.Interval = g_Interval8   ' 60000   '1 phut
                timer8.Enabled = True
            End If


            '=================================================================================================
            If g_Interval9_Start = True Then    'Dong bo  Nha cung cap
                timer9 = New Timer
                AddHandler timer9.Elapsed, AddressOf OnElapsedTimeNhaCungCap
                timer9.Interval = g_Interval9   ' 60000   '1 phut
                timer9.Enabled = True
            End If

            '==========================
        End Sub


        Protected Sub OnElapsedTime(ByVal source As Object, ByVal e As ElapsedEventArgs)
            Try
                'p_GetSOPutAPI_Company()
                If g_JobRunng = False Then
                    '''  modGetDataFromSAP()
                    '''  anhqh  20200831  Code theo DLL de tien cap nhat
                    'DongBoLenhXuat()
                    g_JobRunng = True
                    'While True
                    ExecRuntimeLenhXuat()

                    'End While

                End If
                g_JobRunng = False
            Catch ex As Exception
                g_JobRunng = False
            End Try
        End Sub


        Protected Sub OnElapsedTimeHopDong(ByVal source As Object, ByVal e As ElapsedEventArgs)
            Try
                'p_GetSOPutAPI_Company()
                If g_JobRunngHopDong = False Then
                    g_JobRunngHopDong = True
                    ExecRuntimeHopDong()
                End If
                g_JobRunngHopDong = False
            Catch ex As Exception
                g_JobRunngHopDong = False
            End Try
        End Sub



        Protected Sub OnElapsedTimeSTO(ByVal source As Object, ByVal e As ElapsedEventArgs)
            Try
                'p_GetSOPutAPI_Company()
                If g_JobRunngSTO = False Then
                    g_JobRunngSTO = True
                    ExecRuntimeSTO()
                End If
                g_JobRunngSTO = False
            Catch ex As Exception
                g_JobRunngSTO = False
            End Try
        End Sub

        Protected Sub OnElapsedTimeDonGia(ByVal source As Object, ByVal e As ElapsedEventArgs)
            Try
                'p_GetSOPutAPI_Company()
                If g_JobRunngDonGia = False Then
                    g_JobRunngDonGia = True
                    ExecRuntimeDonGia()

                    ExecRuntimeTyGia()
                End If
                g_JobRunngDonGia = False
            Catch ex As Exception
                g_JobRunngDonGia = False
            End Try
        End Sub



        Protected Sub OnElapsedTonKhoToKhai(ByVal source As Object, ByVal e As ElapsedEventArgs)
            Try
                'p_GetSOPutAPI_Company()
                If g_JobRunngToKhai = False Then
                    g_JobRunngToKhai = True
                    ExecRuntimeToKhai()
                End If
                g_JobRunngToKhai = False
            Catch ex As Exception
                g_JobRunngToKhai = False
            End Try
        End Sub


        Protected Sub OnElapsedTuyenDuong(ByVal source As Object, ByVal e As ElapsedEventArgs)
            Try
                'p_GetSOPutAPI_Company()
                If g_JobRunngTuyenDuong = False Then
                    g_JobRunngTuyenDuong = True
                    DongBoTuyenDuong()
                End If
                g_JobRunngTuyenDuong = False
            Catch ex As Exception
                g_JobRunngTuyenDuong = False
            End Try
        End Sub

        Protected Sub OnElapsedTime88(ByVal source As Object, ByVal e As ElapsedEventArgs)
            Try
                'p_GetSOPutAPI_Company()
                Dim i_date, p_desc As String
                If g_JobRunngCustomize = False Then
                    ' modGetDataFromSAP()
                    g_JobRunngCustomize = True
                    SynCustomer()

                End If
                g_JobRunngCustomize = False
            Catch ex As Exception
                g_JobRunngCustomize = False
            End Try
        End Sub




        Protected Sub OnElapsedTime99(ByVal source As Object, ByVal e As ElapsedEventArgs)
            Try
                'p_GetSOPutAPI_Company()
                GetSoLenhBomXuat()
            Catch ex As Exception

            End Try
        End Sub




        Protected Sub OnElapsedTimeNhaCungCap(ByVal source As Object, ByVal e As ElapsedEventArgs)
            Try
                'p_GetSOPutAPI_Company()
                If g_JobRunngNhaCungCap = False Then
                    g_JobRunngNhaCungCap = True
                    ExecRuntimeNhaCungCap()
                End If
                g_JobRunngNhaCungCap = False
            Catch ex As Exception
                g_JobRunngNhaCungCap = False
            End Try
        End Sub

    End Class
End Module
