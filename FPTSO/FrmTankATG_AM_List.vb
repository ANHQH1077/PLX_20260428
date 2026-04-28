Public Class FrmTankATG_AM_List

    Private Sub FrmTankATG_AM_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL, p_Kho As String
        Dim p_DAta As DataTable
        Dim p_Kho1 As String = ""
        Dim p_Kho2 As String = ""
        Dim p_Kho3 As String = ""
        p_Kho = ""
        p_SQL = "select Terminal from sys_user  where user_name ='" & g_UserName & "'"
        p_DAta = GetDataTable(p_SQL, p_SQL)


        If Not p_DAta Is Nothing Then
            If p_DAta.Rows.Count > 0 Then
                p_Kho = p_DAta.Rows(0).Item("Terminal").ToString.Trim
            End If
        End If


        p_SQL = ""

        p_Kho1 = InStr(p_Kho, "A", CompareMethod.Text)
        If p_Kho1 > 0 Then
            p_SQL = "select 'A' as Kho"
        End If

        p_Kho2 = InStr(p_Kho, "B", CompareMethod.Text)
        If p_Kho2 > 0 Then
            If p_SQL <> "" Then
                p_SQL = p_SQL & " UNION ALL select 'B' as Kho"
            Else
                p_SQL = "select 'B'  as Kho "
            End If
        End If

        p_Kho3 = InStr(p_Kho, "C", CompareMethod.Text)
        '  p_Kho2 = InStr(p_Kho, "B", CompareMethod.Text)
        If p_Kho3 > 0 Then
            If p_SQL <> "" Then
                p_SQL = p_SQL & " UNION ALL select 'C' as Kho "
            Else
                p_SQL = "select 'C' as Kho"
            End If
        End If
        If p_Kho3 > 0 And p_Kho2 > 0 And p_Kho1 > 0 Then
            If p_SQL <> "" Then
                p_SQL = p_SQL & " UNION ALL select 'ALL' as Kho "
            Else
                p_SQL = "select 'ALL' as Kho"
            End If
        End If

        If p_SQL <> "" Then
            Me.Client.SqlString = p_SQL
        Else
            If g_Filter_Terminal = False Then
                p_SQL = "select 'ALL' as Kho "
                Me.Client.SqlString = p_SQL
                ' Me.Client.EditValue = "ALL"

            End If
        End If
    End Sub

    Private Sub U_ButtonEdit2_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TankList.ButtonClick
        Dim FrmLenhXuatAdd As New FrmChonBeATG
        Dim p_Client As String = ""
        Dim p_TankList As String = ""
        Dim p_Status As String = ""
        Dim p_Date As String = ""

        If Not Me.TankList.EditValue Is Nothing Then
            p_TankList = Me.TankList.EditValue.ToString.Trim
        End If

        If Not Me.Client.EditValue Is Nothing Then
            p_Client = Me.Client.EditValue.ToString.Trim
        End If

        FrmLenhXuatAdd.g_Date = p_Date
        FrmLenhXuatAdd.g_Status = p_Status
        FrmLenhXuatAdd.g_Tank = p_Client
        FrmLenhXuatAdd.g_StringTank = p_TankList
        FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim       
        FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
        FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmLenhXuatAdd.g_TankATG_AM_List = True
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.ShowDialog(Me)
        Me.TankList.EditValue = FrmLenhXuatAdd.g_StringTank
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_TableConfig1 As DataTable
        Dim p_TableReturn, p_Table As DataTable
        Dim _SapConnectionString As String
        Dim p_Plan_DB As String
        Dim _WareHouse As String
        Dim _ShPoint As String
        Dim p_date As String = ""
        Dim p_Tank As String
        Dim p_Int As Integer
        Dim p_Row As DataRow

        Dim p_Array() As String
        Dim p_Error As String = ""

        Dim p_TankList As String = ""
        Dim p_SQL As String = ""
        Dim p_DataTablExe As DataTable

        p_TableReturn = New DataTable("Table01")
        p_DataTablExe = New DataTable("Table02")
        p_DataTablExe.Columns.Add("STR_SQL")

        p_TableReturn.Columns.Add("LGORT")
        p_TableReturn.Columns.Add("DATE_F")
        p_TableReturn.Columns.Add("DATE_T")

        p_SQL = "select *, convert(nvarchar (20), getdate(),112)  as nDate from tblconfig"

        p_TableConfig1 = GetDataTable(p_SQL, p_SQL)
            If Not p_TableConfig1 Is Nothing Then
                If p_TableConfig1.Rows.Count > 0 Then
                    _SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                    _WareHouse = p_TableConfig1.Rows(0).Item("WareHouse").ToString.Trim
                    _ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
                    p_Plan_DB = p_TableConfig1.Rows(0).Item("Plant_DB").ToString.Trim
                    p_date = p_TableConfig1.Rows(0).Item("nDate").ToString
                End If
            End If

            If Not Me.TankList.EditValue Is Nothing Then
                p_TankList = Me.TankList.EditValue.ToString
            End If
            p_Array = p_TankList.Split(",")
            If p_Array.Length > 0 Then
                For p_Int = 0 To p_Array.Length - 1
                    If Strings.Left(p_Array(p_Int), 2) = "CD" Then
                        p_SQL = "select Map_Sap1  from tblTank  where name_nd ='" & p_Array(p_Int) & "'"
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                p_Tank = p_Table.Rows(0).Item(0).ToString.Trim
                                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", "60", g_Company_Code)
                            p_ECCDestinationConfig.clsGet_ATG_M_LIST(p_TableReturn, p_Plan_DB, p_Tank, p_date, p_Error)
                                p_ECCDestinationConfig = Nothing
                            End If
                        End If
                    Else
                        p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", "60", g_Company_Code)
                    p_ECCDestinationConfig.clsGet_ATG_M_LIST(p_TableReturn, p_Plan_DB, "", p_date, p_Error)

                        p_ECCDestinationConfig = Nothing
                    End If
                Next
            End If

        If p_TableReturn.Rows.Count > 0 Then
            For p_Int = 0 To p_TableReturn.Rows.Count - 1
                p_SQL = "MERGE zTankListATG_AM AS target " & _
                                              " USING (SELECT (select top 1 Name_nd from tblTank   where   Name_nd='" & p_TableReturn.Rows(p_Int).Item("LGORT").ToString.Trim & "' or  Map_Sap1='" & p_TableReturn.Rows(p_Int).Item("LGORT").ToString.Trim & "')  as TankCode," & _
                                                        "(select top 1 Product_nd from tblTank   where   Name_nd='" & p_TableReturn.Rows(p_Int).Item("LGORT").ToString.Trim & "' or  Map_Sap1='" & p_TableReturn.Rows(p_Int).Item("LGORT").ToString.Trim & "')  as Product_nd," & _
                                                       "convert(datetime,'" & p_TableReturn.Rows(p_Int).Item("DATE_F").ToString.Trim & "') as FromDate," & _
                                                      "convert(datetime,'" & p_TableReturn.Rows(p_Int).Item("DATE_T").ToString.Trim & "') as ToDate, " & _
                                                      "'" & g_UserName & "' as Createby, getdate() as CrDate )" & _
                                                      " AS source (TankCode, Product_nd, FromDate, ToDate, Createby,CrDate) " & _
                                                      " ON (target.TankCode = source.TankCode and target.FromDate = source.FromDate) " & _
                                                  " WHEN MATCHED  THEN UPDATE SET " & _
                                                          "ToDate=source.ToDate " & _
                                                          ",UpdateDate = source.CrDate, UpdatedBy =source.Createby, Product = source.Product_nd " & _
                                               " WHEN NOT MATCHED THEN " & _
                                                  "INSERT  ( TankCode, FromDate, ToDate, Createby , CrDate, Product) " & _
                                                      "VALUES (source.TankCode,source.FromDate,source.ToDate,source.Createby,source.CrDate ,source.Product_nd );"
                ' p_SQL = Replace(p_SQL, "''", "'", 1)
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)
            Next
            If p_DataTablExe.Rows.Count > 0 Then
                If g_Services.Sys_Execute_DataTableNew(p_DataTablExe, _
                                      p_SQL) = False Then
                    ShowStatusMessage(True, "", p_SQL)
                Else
                    ShowStatusMessage(False, "", "Đã thực hiện xong")
                End If
            End If
        End If

    End Sub

    Private Sub TankList_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TankList.EditValueChanged

    End Sub
End Class