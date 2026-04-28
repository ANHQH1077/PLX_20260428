Module Module1

    Public g_KV1 As Boolean = False
    Public g_BATCHSLOG As Boolean = False


    'Public g_Services As Object
    Public g_User_ID As Integer
    'Public g_Module As Object
    Public g_Company_Code As String

    Private p_SYS_MALENH_S As String = String.Empty

    Public p_QUYDOI_SAP As String = "N"

    Public p_HangHoa_SoLuongSAP As DataTable


    Public g_Server As String

    Public g_Password As String

    Const g_RowNum As Integer = 20
    Public g_DBPortInstance As String
    Public g_DB_Name As String
    Public g_DBTYPE As String
    Public Const g_ORAHOST_Key As String = "ORAHOST"
    Public Const g_ORAPORT_Key As String = "ORAPORT"
    Public Const g_SERVERNAME_Key As String = "SERVERNAME"
    Public Const g_ORAUSER_Key As String = "ORAUSER"
    Public Const g_ORAPASS_Key As String = "ORAPASS"
    Public Const g_DBTYPE_Key As String = "DBTYPE"

    Public p_MALUULUONGKE As Boolean = False
    Public p_L15_RESET As Boolean = False
    Public p_TONGDUXUAT As String = "0"
    Public p_TONGDUXUATTHUY As String = "0"

    Public g_SAP_OBJECT As SAP_OBJECT.Class1
    Public g_Services As FPTBUSSINESS.Class1

    Public g_SyncMaster As SynMaster.Class1

    Public Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  convert(date, getdate()) as SysDate, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
        p_Datatable = mod_SYS_GET_DATATABLE(p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub

   
    Public Function FPT_GetMaLenh(ByVal p_SoLenh As String) As String
        Dim p_ValueTmp As String = "0000"
        Dim p_SQL As String = ""
        Dim p_Value As Integer = 0
        Dim p_DataTable As DataTable
        Try
            If p_SYS_MALENH_S.ToString.Trim = "" Then
                p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG where KEYCODE='SYS_MALENH_S'"
                p_DataTable = Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_SYS_MALENH_S = p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim

                    End If
                End If
            End If

            p_DataTable = Nothing
            FPT_GetMaLenh = "0000"
            p_SQL = "exec FPT_Get_SYS_MALENH '" & p_SoLenh & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_Value = p_DataTable.Rows(0).Item(0)
                End If
            End If
            If p_Value > 0 Then
                If p_Value < 3000 Then
                    p_Value = 3000 + p_Value
                End If
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


    Public Function KV1_FPT_GetMaLenh(ByVal p_SoLenh As String, ByVal p_Date As Date) As String
        Dim p_ValueTmp As String = "0000"
        Dim p_SQL As String = ""
        Dim p_Value As Integer = 0
        Dim p_DataTable As DataTable
        Try
            If p_SYS_MALENH_S.ToString.Trim = "" Then
                p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG where KEYCODE='SYS_MALENH_S'"
                p_DataTable = Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_SYS_MALENH_S = p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim

                    End If
                End If
            End If

            p_DataTable = Nothing
            KV1_FPT_GetMaLenh = "0000"
            p_SQL = "exec FPT_Get_SYS_MALENH11 '" & p_SoLenh & "','" & p_Date.ToString("yyyyMMdd") & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_Value = p_DataTable.Rows(0).Item(0)
                End If
            End If
            If p_Value > 0 Then
                If Len(p_Value.ToString.Trim) < 4 Then
                    KV1_FPT_GetMaLenh = Mid(p_ValueTmp, 1, Len(KV1_FPT_GetMaLenh.ToString.Trim) - Len(p_Value.ToString.Trim) - Len(p_SYS_MALENH_S)) & p_Value.ToString.Trim
                    If Len(KV1_FPT_GetMaLenh) = 3 Then
                        KV1_FPT_GetMaLenh = p_SYS_MALENH_S & KV1_FPT_GetMaLenh
                    End If
                Else
                    KV1_FPT_GetMaLenh = p_Value.ToString.Trim
                End If
            End If
        Catch ex As Exception
            KV1_FPT_GetMaLenh = "0000"
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



    Public Function GetTankActive(ByVal p_MaHangHoa As String, ByVal p_Date As Date, Optional ByVal p_Client As String = "", _
                                  Optional ByVal p_LoaiXuat As String = "BO") As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_DateValue As String
        Dim p_FILTERKHO As Boolean = False


        p_SQL = "SELECT  [KEYVALUE]  FROM [SYS_CONFIG] where KEYCODE='FILTERKHO'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    p_FILTERKHO = True
                End If
                'GetTankActive = p_DataTable.Rows(0).Item("Name_nd").ToString.Trim

            End If
        End If



        p_DateValue = p_Date.ToString("dd") & "/" & p_Date.ToString("MM") & "/" & p_Date.ToString("yyyy")
        GetTankActive = ""
        Try
            'anhqh
            '20160628
            If p_FILTERKHO = False Then
                p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where Date1='" & Format(p_Date.ToString("yyyyMMdd") & "' and Product_nd ='" & p_MaHangHoa & "'") & _
                        " and  (loadingSite ='" & p_LoaiXuat & "'  or  loadingSite is null or loadingSite='') order by Len(loadingSite)"

                ' " and  upper(isnull(loadingSite,'BO'))='" & p_LoaiXuat & "'"
            Else
                p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where Date1='" & Format(p_Date.ToString("yyyyMMdd")) & _
                        "' and Product_nd ='" & p_MaHangHoa & "' and  LEFT(Name_nd,LEN('" & p_Client & "'))='" & p_Client & "'  " & _
                        " and  (loadingSite ='" & p_LoaiXuat & "'  or  loadingSite is null or loadingSite='') order by Len(loadingSite)"
                'and  upper(isnull(loadingSite,'BO'))='" & p_LoaiXuat & "'  order by  ID Desc "
            End If
            ' p_SQL = String.Format("SELECT Name_nd FROM [FPT_tblTankActive_V] where [Date_nd]='{0}' and   Product_nd ='{1}'", p_DateValue, p_MaHangHoa)
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTankActive = p_DataTable.Rows(0).Item("Name_nd").ToString.Trim
                End If

            End If
        Catch ex As Exception
            GetTankActive = ""
        End Try


    End Function


    Public Function GetTankActiveE5(ByVal p_TankE5 As String, ByVal p_Date As Date) As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_DateValue As String
        ' p_DateValue = p_Date.ToString("dd") & "/" & p_Date.ToString("MM") & "/" & p_Date.ToString("yyyy")
        GetTankActiveE5 = ""
        Try

            p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where Date1='" & Format(p_Date.ToString("yyyyMMdd") & "' ") & _
                    " and  ( Name_nd in (select top 1  TankID   from  FPT_tblMeterE5_V	where TankE5='" & p_TankE5 & "') " & _
                     "  or Name_nd ='" & p_TankE5 & "'  )"

            ' p_SQL = String.Format("SELECT Name_nd FROM [FPT_tblTankActive_V] where [Date_nd]='{0}' and   Product_nd ='{1}'", p_DateValue, p_MaHangHoa)
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTankActiveE5 = p_DataTable.Rows(0).Item("Name_nd").ToString.Trim
                End If

            End If
        Catch ex As Exception
            GetTankActiveE5 = ""
        End Try


    End Function


    Public Function GetDataTable(ByVal p_SQL As String, ByVal p_Error As String) As DataTable
        Dim p_Datatable As DataTable
        Try
            p_Datatable = Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            'ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_Datatable

    End Function


    Public Function GetDataSet(ByVal p_SQL As String, ByVal p_Error As String) As DataSet
        Dim p_DataSet As DataSet
        Try
            p_DataSet = Sys_SYS_GET_DATASET_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            'ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_DataSet
    End Function
    Function CheckSAPConnection(ByVal p_SapConnectionString As String, ByRef p_Desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim p_ExSapConnectionString As String
        Dim p_Data As DataTable
        Dim p_SQL As String
        Try
            CheckSAPConnection = True
            p_ExSapConnectionString = p_SapConnectionString
            If p_ExSapConnectionString = "" Then
                p_SQL = "select * from tblconfig"
                p_Data = GetDataTable(p_SQL, p_SQL)
                p_ExSapConnectionString = p_Data.Rows(0).Item("sapconnectionstring").ToString.Trim
            End If
            p_Desc = ""
            l_c2sap = New Connect2SAP.Connect2SAP(p_ExSapConnectionString)
            l_c2sap.Connection.Open()

            l_c2sap.Connection.Close()
            l_c2sap.Connection.Dispose()
        Catch ex As Exception
            p_Desc = ex.Message
            CheckSAPConnection = False
        End Try
    End Function

End Module
