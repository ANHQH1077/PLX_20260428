Public Class FrmTankHeaderImp
    Public g_TankHeaderCode As String = ""
    Public g_Auto As Boolean = True
    Public g_Approved As Boolean = False
    Public ATG As Boolean = False
    Public ViewAdmin As Boolean = False
    Public g_BaremCheck As Boolean = False
    Public p_TANK_GROUP As Boolean = False
    Private Sub FrmTankHeaderImp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim p_column1 As U_TextBox.GridColumn = Nothing
        Dim p_SQL As String = "" '"select Terminal from sys_user  where user_name ='" & g_UserName & "'"
        Dim p_DAta As DataTable
        Dim p_Kho As String
        Dim p_Kho1 As Integer = 0
        Dim p_Kho2 As Integer = 0
        Dim p_Kho3 As Integer = 0
        Dim p_Status As String = ""
        Dim p_Kho_List() As String
        Dim p_Table As DataTable


        p_TANK_GROUP = False
        p_SQL = "select KEYVALUE  from sys_config  where UPPER (Keycode) ='TANK_GROUP' "
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    p_TANK_GROUP = True
                End If
            End If
        End If



        'ztblTankLineImp_v
        p_SQL = "select KeyValue from SYS_CONFIG where upper(KeyCode) ='BAREMCHECK'  and isnull(KeyValue,'') ='Y' "
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_column1 = Me.GridView1.Columns.ColumnByName("BAREM_HEIGHT")
                p_column1.FieldView = "BAREM_HEIGHT"
                p_column1 = Me.GridView1.Columns.ColumnByName("BAREM_WATER")
                p_column1.FieldView = "BAREM_WATER"
                ' p_column1.VisibleIndex = 19
                ' p_column1.Visible = True
            End If
        End If



        p_SQL = "Select top 1 WaterHeight from ztblTankLineImp_v"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_column1 = Me.GridView1.Columns.ColumnByName("WaterHeight")
                p_column1.FieldView = "WaterHeight"
                ' p_column1.VisibleIndex = 19
                ' p_column1.Visible = True
            End If
        End If
        'If p_column1 Is Nothing Then
        '    Me.GridView1.Columns.Item(Me.GridView1.Columns.ColumnByName("WaterHeight").VisibleIndex).Visible = False
        'End If

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


        If p_TANK_GROUP = False Then
            Dim p_column As U_TextBox.GridColumn
            For p_int = 0 To Me.GridView1.Columns.Count - 1
                p_column = Me.GridView1.Columns.Item(p_int)
                If p_column.Name = "NhomBeXuat" Then
                    p_column.Visible = False
                    p_column.FieldView = ""
                End If

            Next

        End If
        If g_Auto = False Or ATG = True Then
            Me.ToolStripButton3.Visible = False

            '1,2,3,5,6,8
            Me.GridView1.Columns.Item(1).OptionsColumn.ReadOnly = False
            Me.GridView1.Columns.Item(2).OptionsColumn.ReadOnly = False
            'Me.GridView1.Columns.Item(3).OptionsColumn.ReadOnly = False
            Me.GridView1.Columns.Item(5).OptionsColumn.ReadOnly = False
            Me.GridView1.Columns.Item(6).OptionsColumn.ReadOnly = False
            Me.GridView1.Columns.Item(8).OptionsColumn.ReadOnly = False

            Me.GridView1.Columns.ColumnByName("WaterHeight").OptionsColumn.ReadOnly = False
            Me.GridView1.AllowInsert = True

            ' Me.TrueDBGrid1.new()
        Else
            ' Me.ToolStripButton2.Visible = False
            ' Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        End If
        ReloadData()

        If g_TankHeaderCode = "" Then
            TaoMoiGiaoDich()
        End If

        'p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa  a " & _
        '            "where left(Name_nd,1) = :Client and isnull(Product_nd,'') <>'' and a.Mahanghoa =b.Product_nd and " & _
        '            " not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
        'Dim p_Col As New U_TextBox.GridColumn
        'p_Col = Me.GridView1.Columns.Item("")
        'p_Col.SQLString = p_SQL

        If g_Approved = True Then
            Me.FormEdit = False
            Me.U_ButtonCus1.Visible = True
        Else
            Me.U_ButtonCus1.Visible = False
        End If
        p_SQL = ""
        If Not Me.Status.EditValue Is Nothing Then
            p_SQL = Me.Status.EditValue.ToString.Trim
        End If
        If p_SQL = "Y" Or p_SQL = "S" Then
            'Me.FormEdit = False
            ' Me.GridView1.OptionsBehavior.ReadOnly = True
            SetItemProperty(False)
            If p_SQL = "S" Then
                ToolStripButton6.Enabled = False
            End If
        Else
            SetItemProperty(True)
            If g_Auto = False Or ATG = True Then
                Me.GridView1.Columns("TankCode").OptionsColumn.ReadOnly = False
                Me.GridView1.Columns("TankHeight").OptionsColumn.ReadOnly = False
                Me.GridView1.Columns("TankTemp").OptionsColumn.ReadOnly = False
                Me.GridView1.Columns("PurposeCode").OptionsColumn.ReadOnly = False
            End If
            ToolStripButton6.Enabled = True
            ' Me.FormEdit = True
            ' Me.GridView1.OptionsBehavior.ReadOnly = False
        End If


        p_column1 = Me.GridView1.Columns.Item("TankCode")

        Dim p_ColTypeButtonEdit As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        p_ColTypeButtonEdit = p_column1.ColumnEdit
        AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click
        If ATG = True And g_Auto = False Then   'do bể TBĐMTĐ Trống
            Me.Text = "Thông tin đo bể - bể TBĐMTĐ trống"
        End If

        If ATG = False And g_Auto = True Then   'do bể tự động
            Me.Text = "Thông tin đo bể - Đo tự động"
        End If
        If ATG = False And g_Auto = False Then   'do bể - đo tay
            Me.Text = "Thông tin đo bể - Đo nhập tay"
        End If
        Me.ControlResize = True
        FindAllControls(Me)
        Me.WindowState = FormWindowState.Maximized





    End Sub



    Public Sub Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_SQL As String = ""
        Dim p_Client As String = ""
        Dim p_Date As String = ""
        Dim p_DateTime As DateTime
        Dim p_DateCheck As Boolean = False
        Dim p_Row As DataRow

        If p_TANK_GROUP = True Then
            Column_Button_Click_NhomBe(sender, e)
            Exit Sub
        End If

        Try
            If UCase(Me.GridView1.FocusedColumn.FieldName.ToString.Trim) <> UCase("TankCode") Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try
        p_Row = Me.GridView1.GetDataRow(Me.GridView1.FocusedRowHandle)
        If p_Row Is Nothing Then
            Me.GridView1.AddNewRow()
        End If
        Try
            If Not Me.GridView1.GetRowCellValue(Me.GridView1.FocusedRowHandle, "CrDate") Is Nothing Then
                p_Date = Me.GridView1.GetRowCellValue(Me.GridView1.FocusedRowHandle, "CrDate").ToString.Trim
            End If

        Catch ex As Exception

        End Try
        If Not Me.Client.EditValue Is Nothing Then
            p_Client = Me.Client.EditValue.ToString.Trim
        End If

        If Not Me.FromDate.EditValue Is Nothing Then
            If Me.FromDate.EditValue.ToString.Trim <> "" Then
                p_DateTime = Me.FromDate.EditValue
                p_DateCheck = True
            End If

        End If

        If p_DateCheck = False And p_Date = "" Then
            ShowMessageBox("", "Ngày giờ đo bể chưa nhập")
            Exit Sub
        End If
        If p_Date = "" Then
            p_Date = CDate(p_DateTime).ToString("yyyyMMdd HH:mm:ss")
            Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "CrDate", p_DateTime)
            '  GridView1.
        End If


        If p_Client = "" Then
            Exit Sub
        End If
        If ATG = True Then
            If g_Auto = False Then  'Nhap tay  cho be ATG  (Đo bể trống ) chỉ lấy danh sách bể  trong danh mục đo bể trống
                If p_Client <> "ALL" Then
                    If p_Client = "C" Then
                        p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) like  '%" & p_Client & "%' or substring(Name_nd,2,1) Like '%D%'   ) and isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd " 'and  not  exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    Else
                        p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd " 'and  not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    End If
                Else
                    p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                                " a where  isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd " ' and  not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                End If
                p_SQL = p_SQL & " and ( exists (select 1  from dbo.zTankListATG_M  h  where  :Column.CrDate  >=   isnull(FROMDATE,getdate()-5) " & _
                      " and  :Column.CrDate   <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd ) )"


                'p_SQL = p_SQL & " and ( exists (select 1  from dbo.zTankListATG_M  h  where  getdate() >=   isnull(FROMDATE,getdate()-5) " & _
                '     " and  getdate() <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"


                'p_SQL = p_SQL & "  and  not exists (select 1  from dbo.zTankListATG_AM  h  where  :Column.CrDate >=   isnull(FROMDATE,getdate()-5) " & _
                '             " and  :Column.CrDate <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )  )"
            Else
                If p_Client <> "ALL" Then
                    If p_Client = "C" Then
                        p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) like  '%" & p_Client & "%' or substring(Name_nd,2,1) Like '%D%'   ) and isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd and  exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    Else
                        p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd and  exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    End If
                Else
                    p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                                " a where  isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd and  exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                End If
            End If

           

        Else    'Do be nhap tay    lấy danh sách bể khôg nằm trong danh sách khai báo bể ATG   hoặc nằm trong danh sách TBĐMTĐ chuyển nhập tay 
            If p_Client <> "ALL" Then
                If p_Client = "C" Then
                    p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                            " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) like  '%" & p_Client & "%' or substring(Name_nd,2,1) Like '%D%'   ) and isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    'Them danh sach cac be ATG tu dong cho nhap tay
                    p_SQL = p_SQL & " union all select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                       " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) like  '%" & p_Client & "%' or substring(Name_nd,2,1) Like '%D%'   ) and isnull(Product_nd,'') <>'' " & _
                       " and a.Mahanghoa =b.Product_nd "
                    p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where  :Column.CrDate >=   isnull(FROMDATE,getdate()-5) " & _
                              " and  :Column.CrDate <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
                Else
                    p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                            " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    'Them danh sach cac be ATG tu dong cho nhap tay
                    p_SQL = p_SQL & " union all select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                            " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd "
                    p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where :Column.CrDate >=   isnull(FROMDATE,getdate()-5) " & _
                            " and  :Column.CrDate <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
                End If
            Else
                p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                            " a where  isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                'Them danh sach cac be ATG tu dong cho nhap tay
                p_SQL = p_SQL & " union all  select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                            " a where  isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd "
                p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where  :Column.CrDate >=   isnull(FROMDATE,getdate()-5) " & _
                          " and  :Column.CrDate <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
            End If



            'p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where  getdate() >=   isnull(FROMDATE,getdate()-5) " & _
            '          " and  getdate() <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
        End If

        p_SQL = "select distinct * from  (" & p_SQL & ") abc"
        
        p_Column1 = Me.GridView1.Columns.Item("TankCode")
        p_Column1.SQLString = p_SQL
        p_Column1.ButtonClick = True
        Me.Gridview_Column_Button_Click(sender, e)
        p_Column1.ButtonClick = False
    End Sub



    '20250106 dung cho tham số  NhomBeXuat
    Public Sub Column_Button_Click_NhomBe(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_SQL As String = ""
        Dim p_Client As String = ""
        Dim p_Date As String = ""
        Dim p_DateTime As DateTime
        Dim p_DateCheck As Boolean = False
        Dim p_Row As DataRow
        Try
            If UCase(Me.GridView1.FocusedColumn.FieldName.ToString.Trim) <> UCase("TankCode") Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try
        p_Row = Me.GridView1.GetDataRow(Me.GridView1.FocusedRowHandle)
        If p_Row Is Nothing Then
            Me.GridView1.AddNewRow()
        End If
        Try
            If Not Me.GridView1.GetRowCellValue(Me.GridView1.FocusedRowHandle, "CrDate") Is Nothing Then
                p_Date = Me.GridView1.GetRowCellValue(Me.GridView1.FocusedRowHandle, "CrDate").ToString.Trim
            End If

        Catch ex As Exception

        End Try
        If Not Me.Client.EditValue Is Nothing Then
            p_Client = Me.Client.EditValue.ToString.Trim
        End If

        If Not Me.FromDate.EditValue Is Nothing Then
            If Me.FromDate.EditValue.ToString.Trim <> "" Then
                p_DateTime = Me.FromDate.EditValue
                p_DateCheck = True
            End If

        End If

        If p_DateCheck = False And p_Date = "" Then
            ShowMessageBox("", "Ngày giờ đo bể chưa nhập")
            Exit Sub
        End If
        If p_Date = "" Then
            p_Date = CDate(p_DateTime).ToString("yyyyMMdd HH:mm:ss")
            Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "CrDate", p_DateTime)
            '  GridView1.
        End If


        If p_Client = "" Then
            Exit Sub
        End If
        If ATG = True Then
            If g_Auto = False Then  'Nhap tay  cho be ATG  (Đo bể trống ) chỉ lấy danh sách bể  trong danh mục đo bể trống
                If p_Client <> "ALL" Then
                    If p_Client = "C" Then
                        p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)  and Name_nd = b.Name_nd  and Product_nd = b.Product_nd )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) like  '%" & p_Client & "%' or substring(Name_nd,2,1) Like '%D%'   ) and isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd " 'and  not  exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    Else
                        p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)   and Name_nd = b.Name_nd and Product_nd = b.Product_nd  )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd " 'and  not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    End If
                Else
                    p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)   and Name_nd = b.Name_nd and Product_nd = b.Product_nd  )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                                " a where  isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd " ' and  not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                End If
                p_SQL = p_SQL & " and ( exists (select 1  from dbo.zTankListATG_M  h  where  :Column.CrDate  >=   isnull(FROMDATE,getdate()-5) " & _
                      " and  :Column.CrDate   <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd ) )"


                'p_SQL = p_SQL & " and ( exists (select 1  from dbo.zTankListATG_M  h  where  getdate() >=   isnull(FROMDATE,getdate()-5) " & _
                '     " and  getdate() <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"


                'p_SQL = p_SQL & "  and  not exists (select 1  from dbo.zTankListATG_AM  h  where  :Column.CrDate >=   isnull(FROMDATE,getdate()-5) " & _
                '             " and  :Column.CrDate <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )  )"
            Else
                If p_Client <> "ALL" Then
                    If p_Client = "C" Then
                        p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)  and Name_nd = b.Name_nd and Product_nd = b.Product_nd )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) like  '%" & p_Client & "%' or substring(Name_nd,2,1) Like '%D%'   ) and isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd and  exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    Else
                        p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)  and Name_nd = b.Name_nd and Product_nd = b.Product_nd )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd and  exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    End If
                Else
                    p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)  and Name_nd = b.Name_nd and Product_nd = b.Product_nd )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                                " a where  isnull(Product_nd,'') <>'' " & _
                                " and a.Mahanghoa =b.Product_nd and  exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                End If
            End If



        Else    'Do be nhap tay    lấy danh sách bể khôg nằm trong danh sách khai báo bể ATG   hoặc nằm trong danh sách TBĐMTĐ chuyển nhập tay 
            If p_Client <> "ALL" Then
                If p_Client = "C" Then
                    p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)   and Name_nd = b.Name_nd and Product_nd = b.Product_nd )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                            " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) like  '%" & p_Client & "%' or substring(Name_nd,2,1) Like '%D%'   ) and isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    'Them danh sach cac be ATG tu dong cho nhap tay
                    p_SQL = p_SQL & " union all select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)   and Name_nd = b.Name_nd and Product_nd = b.Product_nd )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                       " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) like  '%" & p_Client & "%' or substring(Name_nd,2,1) Like '%D%'   ) and isnull(Product_nd,'') <>'' " & _
                       " and a.Mahanghoa =b.Product_nd "
                    p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where  :Column.CrDate >=   isnull(FROMDATE,getdate()-5) " & _
                              " and  :Column.CrDate <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
                Else
                    p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)   and Name_nd = b.Name_nd and Product_nd = b.Product_nd  )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                            " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                    'Them danh sach cac be ATG tu dong cho nhap tay
                    p_SQL = p_SQL & " union all select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)  and Name_nd = b.Name_nd and Product_nd = b.Product_nd )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                            " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd "
                    p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where :Column.CrDate >=   isnull(FROMDATE,getdate()-5) " & _
                            " and  :Column.CrDate <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
                End If
            Else
                p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)  and Name_nd = b.Name_nd and Product_nd = b.Product_nd )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                            " a where  isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
                'Them danh sach cac be ATG tu dong cho nhap tay
                p_SQL = p_SQL & " union all  select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)  and Name_nd = b.Name_nd and Product_nd = b.Product_nd )  as NhomBeXuat from tblTank b,tblHangHoa " & _
                            " a where  isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd "
                p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where  :Column.CrDate >=   isnull(FROMDATE,getdate()-5) " & _
                          " and  :Column.CrDate <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
            End If



            'p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where  getdate() >=   isnull(FROMDATE,getdate()-5) " & _
            '          " and  getdate() <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
        End If

        p_SQL = "select distinct * from  (" & p_SQL & ") abc"

        p_Column1 = Me.GridView1.Columns.Item("TankCode")
        p_Column1.CFLReturn3 = "NhomBeXuat"

        p_Column1.CFLReturn2 = "TenHangHoa"
        '



        p_Column1.SQLString = p_SQL
        p_Column1.ButtonClick = True
        Me.Gridview_Column_Button_Click(sender, e)
        p_Column1.ButtonClick = False
    End Sub


    Private Sub SetItemProperty(p_Value As Boolean)
        On Error Resume Next
        Me.FormEdit = p_Value
        Me.U_ButtonCus2.Enabled = p_Value
        ToolStripButton3.Enabled = p_Value
        Me.GridView1.OptionsBehavior.ReadOnly = Not p_Value
        ToolStripButton5.Enabled = p_Value
        If g_Auto = False Or ATG = True Then
            Label7.Visible = False
            TankList.Visible = False
            U_ButtonCus2.Visible = False
        Else
            Label7.Visible = True
            TankList.Visible = True
            U_ButtonCus2.Visible = True
        End If
    End Sub

    Private Sub ReloadData()
        If ViewAdmin = False Then
            Me.DefaultWhere = "Where TankHeaderCode='" & g_TankHeaderCode & "'  and  isnull(Status,'') <> 'C' "
        Else
            Me.DefaultWhere = "Where TankHeaderCode='" & g_TankHeaderCode & "'"
        End If

        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
        Dim p_Status As String = ""
        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If
        If p_Status = "Y" Then
            Me.FormEdit = False
            Me.ToolStripButton1.Enabled = False
        Else
            Me.FormEdit = True
            Me.ToolStripButton1.Enabled = True
        End If


    End Sub


    Private Sub TaoMoiGiaoDich()
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        p_SQL = "exec GetKeyztblTankHeader '" & g_UserName & "'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        p_SQL = ""
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_SQL = p_DataTable.Rows(0).Item("newKey").ToString.Trim
            End If
        End If
        If p_SQL = "" Then
            ShowMessageBox("", "Lỗi khi thục hiện tạo Key")
            Exit Sub
        End If
        Me.FormStatus = False
        Me.Navigator1.Buttons.DoClick(Me.Navigator1.Buttons.Append)
        Me.TankHeaderCode.EditValue = p_SQL
        g_TankHeaderCode = p_SQL
        If g_Auto = True Then
            Me.sType.EditValue = "A"
        Else
            Me.sType.EditValue = "M"
        End If
        If g_Company_Code = "6610" Then

            Me.Client.EditValue = g_Terminal
        Else
            Me.Client.EditValue = "ALL"
        End If


        Me.CreateDate.EditValue = p_DataTable.Rows(0).Item("AcDate")

        ' FormStatus = True
        Me.FormStatus = True
        CreateUser.EditValue = g_UserName
        SetItemProperty(True)
        ReloadData()
        Me.ToolStripButton6.Enabled = True
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        TaoMoiGiaoDich()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_TankHeaderCode As String = ""
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Dim p_Type As String = ""
        If Not Me.sType.EditValue Is Nothing Then
            p_Type = Me.sType.EditValue.ToString.Trim
        End If
        If Not Me.TankHeaderCode.EditValue Is Nothing Then
            p_TankHeaderCode = Me.TankHeaderCode.EditValue.ToString.Trim
            p_SQL = "select 1 from ztblTankHeaderImp with (nolock) where TankHeaderCode ='" & p_TankHeaderCode & "' and isnull(Status,'') in ('C','S')"
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    ShowMessageBox("", "Trạng thái giao dịch không hợp lệ")
                    Exit Sub
                End If
            End If
        End If
        If p_Type = "M" Then
          

                If CheckValidTankLine() = False Then
                    Exit Sub
                End If
                Me.DefaultSave = True
                Me.UpdateToDatabase(Me)
                Me.DefaultSave = False
               
                '   GetQCI()
                ReloadData()

           
        Else
            If Not Me.TankHeaderCode.EditValue Is Nothing Then
                p_TankHeaderCode = TankHeaderCode.EditValue.ToString.Trim
            End If
            If p_TankHeaderCode <> "" Then

                'If CheckValidTankLine() = False Then
                '    Exit Sub
                'End If
                If KiemTRaThoiGian() = False Then
                    Exit Sub
                End If
                Me.DefaultSave = True
                Me.UpdateToDatabase(Me)
                Me.DefaultSave = False
                If p_TankHeaderCode <> g_TankHeaderCode Then
                    g_TankHeaderCode = p_TankHeaderCode
                End If
                '   GetQCI()
                ReloadData()

            Else
                ShowMessageBox("", "Lỗi không xác định Key")
            End If

        End If
       
    End Sub


    Private Function KiemTRaThoiGian() As Boolean
        ' Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Dim p_RowArray() As DataRow
        Dim p_Biding As New U_TextBox.U_BindingSource
        ' Dim p_Grid As New U_TextBox.GridView
        Dim p_Count As Integer
        'Dim p_Value As Integer
        '   Dim p_CoLumn As U_TextBox.GridColumn
        Dim p_Row As DataRow
        Dim p_Tank As String = ""
        Dim p_Date As DateTime
        KiemTRaThoiGian = True
        If Me.GridView1.RowCount > 0 Then
            p_Biding = Me.TrueDBGrid1.DataSource
            p_Table = CType(p_Biding.DataSource, DataTable)
            p_RowArray = p_Table.Select("", "TankCode")
            For p_Count = 0 To p_RowArray.Length - 1

                p_Row = p_RowArray(p_Count)


                If Not p_Row Is Nothing Then
                    If p_Tank <> p_Row("TankCode").ToString.Trim Then
                        p_Tank = p_Row("TankCode").ToString.Trim
                        p_Date = p_Row("CrDate").ToString.Trim
                    Else
                        If p_Date <> p_Row("CrDate") Then
                            ShowMessageBox("", "Bể (" & p_Tank & ") có ngày tháng khác nhau")
                            Return False
                        End If
                    End If
                End If

            Next
            

        End If


    End Function
    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Dim p_SQL As String = ""
        Dim p_TranCode As String = ""
        Dim p_Table As DataTable

        If Not Me.TankHeaderCode.EditValue Is Nothing Then
            p_TranCode = Me.TankHeaderCode.EditValue.ToString.Trim
        End If
        'If p_TranCode = "" Then
        '    ShowMessageBox("", "Giao dịch chưa tạo")
        '    Exit Sub
        'End If
        p_SQL = "select top 1 TankHeaderCode  from  ztblTankLineImp where  TankHeaderCode ='" & p_TranCode & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)

        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                ShowMessageBox("", "Thực hiện Rút thêm số liệu từ ATG")
                Exit Sub
            End If
        End If
        RutSoLieuATG(True)

    End Sub

    Private Sub RutSoLieuATG(p_Delete As Boolean)
        Dim p_SQL As String = ""
        Dim p_TranCode As String = ""
        Dim p_Table As DataTable
        Dim p_Client As String = ""
        Dim p_PurposeCode As String = ""
        Dim p_TankList As String = ""


 
        If Me.FormStatus = True Then
            Me.DefaultSave = True
            Me.UpdateToDatabase(Me)
            Me.DefaultSave = False
        End If

        If CheckValidTank() = False Then
            Exit Sub
        End If

        If g_Auto = False Then
            ShowMessageBox("", "Loại giao dịch không đúng")
            Exit Sub
        End If


        If Not Me.U_ButtonEdit1.EditValue Is Nothing Then
            p_PurposeCode = Me.U_ButtonEdit1.EditValue.ToString.Trim
        End If


        If Not Me.TankHeaderCode.EditValue Is Nothing Then
            p_TranCode = Me.TankHeaderCode.EditValue.ToString.Trim
        End If
        If p_TranCode = "" Then
            ShowMessageBox("", "Giao dịch chưa tạo")
            Exit Sub
        End If

        p_SQL = "select Status from where TankHeaderCode ='" & p_SQL & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item(0).ToString.Trim = "Y" Then
                    ShowMessageBox("", "Giao dịch đã đồng bộ lên SAP")
                    Exit Sub
                End If
            End If
        End If

        Dim p_error As Boolean
        Dim p_Datetime As DateTime
        Dim p_DesError As String
        Dim p_Check As Boolean = False
        'Dim p_DocNum As Integer = 0
        'If Not Me.DocEntry.EditValue Then
        '    Integer.TryParse(Me.DocEntry.EditValue.ToString.Trim, p_DocNum)
        'End If
        'If p_DocNum > 0 Then


        If Not Me.FromDate.EditValue Is Nothing Then
            If Me.FromDate.EditValue.ToString.Trim <> "" Then
                p_Datetime = Me.FromDate.EditValue
                p_Check = True
            End If

        End If
        If p_Check = False Then
            ShowMessageBox("", "Ngày giờ đo bể chưa được chọn")
            Exit Sub
        End If
        If Not Me.Client.EditValue Is Nothing Then
            p_Client = Me.Client.EditValue.ToString.Trim
        End If
        Cursor = Cursors.WaitCursor
        Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
        If p_Client <> "" Then

            If p_Delete = True Then
                p_SQL = "delete from  ztblTankLineImp where TankHeaderCode ='" & p_TranCode & "'"
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If
            End If
            If Not Me.TankList.EditValue Is Nothing Then
                p_TankList = Me.TankList.EditValue.ToString.Trim
            End If
            If g_Filter_Terminal = True Then
                If p_Client = "ALL" Then
                    p_SAP_Object.clsGetTankATG(p_PurposeCode, p_TranCode, "A", p_Datetime, p_error, p_DesError, p_TankList)
                    p_SAP_Object.clsGetTankATG(p_PurposeCode, p_TranCode, "B", p_Datetime, p_error, p_DesError, p_TankList)
                    p_SAP_Object.clsGetTankATG(p_PurposeCode, p_TranCode, "C", p_Datetime, p_error, p_DesError, p_TankList)
                    p_SAP_Object.clsGetTankATG(p_PurposeCode, p_TranCode, "D", p_Datetime, p_error, p_DesError, p_TankList)

                ElseIf p_Client = "C" Then
                    p_SAP_Object.clsGetTankATG(p_PurposeCode, p_TranCode, "C", p_Datetime, p_error, p_DesError, p_TankList)
                    p_SAP_Object.clsGetTankATG(p_PurposeCode, p_TranCode, "D", p_Datetime, p_error, p_DesError, p_TankList)
                Else
                    p_SAP_Object.clsGetTankATG(p_PurposeCode, p_TranCode, p_Client, p_Datetime, p_error, p_DesError, p_TankList)
                End If
            Else
                p_SAP_Object.clsGetTankATG(p_PurposeCode, p_TranCode, p_Client, p_Datetime, p_error, p_DesError, p_TankList)
            End If
           

            'Else
            '    p_SAP_Object.clsGetTankATG(p_TranCode, g_Terminal, p_Datetime, p_error, p_DesError)
        Else
            ShowMessageBox("", "Kho không xác định")
            Exit Sub
        End If
        'If p_PurposeCode <> "" Then
        '    p_SQL = "Update ztblTankLineImp  set PurposeCode ='" & p_PurposeCode & "' where TankHeaderCode = '" & p_TranCode & "' and isnull(PurposeCode,'') ='' "
        '    If g_Services.Sys_Execute(p_SQL, _
        '                               p_SQL) = False Then
        '        'ShowMessageBox("", p_SQLErr)
        '    End If

        'End If

        GetQCI()

        ReloadData()

        Cursor = Cursors.Default
        ' Else
        ' ShowMessageBox("", "Số giao dịch không xác định")
        'End If


    End Sub
    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        If Me.FormStatus = True Then
            Me.DefaultSave = True
            Me.UpdateToDatabase(Me)
            Me.DefaultSave = False
        End If

        Dim l_err As String
        ' If Me.rdoPXK.Checked = True Then
        l_err = "BIENBANDOBE"
        InChungTu(l_err)
        'End If

    End Sub



    Sub InChungTu(ByVal l_err As String)
        Dim p_SoGiaoDich As String = ""
        If Not Me.DocEntry.EditValue Is Nothing Then
            p_SoGiaoDich = Me.DocEntry.EditValue.ToString.Trim
        End If
        If l_err.ToString.Trim <> "" And p_SoGiaoDich <> "" Then
            _Report_Object.clsInChungTu(Me.Owner, False, p_SoGiaoDich, l_err)
        End If
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        GetQCI()
    End Sub

    Private Sub GetQCI()
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Dim p_Code As String = ""

        If Me.FormStatus = True Then
            Me.DefaultSave = True
            Me.UpdateToDatabase(Me)
            Me.DefaultSave = False
        End If
        If Not Me.Status.EditValue Is Nothing Then
            p_SQL = Me.Status.EditValue.ToString.Trim
        End If
        If p_SQL = "" Or p_SQL = "N" Or p_SQL = "U" Then
            p_SQL = ""
            If Not Me.TankHeaderCode.EditValue Is Nothing Then
                p_Code = Me.TankHeaderCode.EditValue.ToString.Trim
            End If
            If p_Code = "" Then
                Exit Sub
            End If

            'Cap nhat lai Ltt theo barem be
            'p_SQL = "select top 1 VOLCON from ztbltankbarem with (nolock) where SEQNR='A009' and Lincon=3552.0000"

            p_SQL = "exec FPT_UpdateTankATG_QCI '" & p_Code & "'"
            p_Table = GetDataTable(p_SQL, p_SQL)

            Me.DefaultFormLoad = True
            Me.LoadDataToForm()
            Me.DefaultFormLoad = False
            'ShowMessageBox("", "Đã thực hiện xong", 1)
            ShowStatusMessage(False, "", "Đã thực hiện xong")
        Else
            ShowMessageBox("", "Trạng thái Đã phê duyệt hoặc Đã đưa lên SAP")
        End If

        'Dim p_SQL As String = ""
        'Dim p_Desc As String = ""

        'Dim p_Datatable As DataTable
        'Dim p_Binding As U_TextBox.U_BindingSource


        'p_Binding = Me.TrueDBGrid1.DataSource
        'p_Datatable = CType(p_Binding.DataSource, DataTable)
        'If p_Datatable.Rows.Count <= 0 Then
        '    ShowMessageBox("", "Bản ghi không xác định")
        '    Exit Sub
        'End If
        ''  If g_WCF = False Then

        'Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
        ''If p_SAP_Object.clsCheckSAPConnection("", p_SQL) = False Then

        ''End If
        'If p_SAP_Object.clsQCI_CalculateQCI_ATG(g_WareHouse, "", p_Datatable, p_Desc) = False Then

        '    ShowMessageBox("", p_SQL)
        '    Exit Sub

        'End If


        'p_Binding.DataSource = p_Datatable
        'Me.TrueDBGrid1.DataSource = p_Binding
        'Me.TrueDBGrid1.RefreshDataSource()
        'Me.GridView1.BestFitColumns()
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        If Me.FormStatus = True Then
            ShowMessageBox("", "Đề nghị lưu lại trước khi thực hiện")
            Exit Sub
        End If



        Dim p_SapConnectionString As String
        Dim p_Code As String = ""
        Dim l_sap As Connect2SapEx.Connect2Sap
        ' Dim l_ztb_Tank As Connect2SapEx.ZSTBAPI_TANK_DIPTable '  .ZST_TANK_DIPTable
        ' Dim l_str_Tank As Connect2SapEx.ZSTBAPI_TANK_DIP    ' .ZST_TANK_DIP
        ' Dim l_ret2 As Connect2SapEx.BAPIRET2
        '  Dim l_ret2table As Connect2SapEx.BAPIRET2Table
        ' Dim l_dt_tank As DataTable
        Dim p_Table As System.Data.DataTable
        Dim p_SQL As String
        Dim p_Binding As U_TextBox.U_BindingSource
        '  Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim p_Tank As String
        Dim p_Plant_DB As String = ""
        Dim p_Status As String = ""
        Dim p_TankHeaderCode As String = ""
        Dim p_sType As String = ""
        Dim p_row As DataRow
        Dim p_MucDD As String = ""
        ' Dim p_SQL As String = ""
        Dim p_TableCheck As DataTable
        Dim p_Count As Integer = 0

        Dim p_Value As Double = 0.0
        For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
            p_row = Me.GridView1.GetDataRow(p_Count)
            If Not p_row Is Nothing Then               '
                If p_row.Item("PurposeCode").ToString.Trim = "" And p_row.Item("X").ToString.Trim = "Y" Then
                    ShowMessageBox("", "Mục đích đo không được trống, đề nghị kiểm tra lại")

                    Exit Sub
                End If
            End If
        Next
        p_Count = 0

        If Not Me.U_ButtonEdit1.EditValue Is Nothing Then
            p_MucDD = Me.U_ButtonEdit1.EditValue.ToString.Trim
        End If
        If Not Me.TankHeaderCode.EditValue Is Nothing Then
            p_TankHeaderCode = Me.TankHeaderCode.EditValue.ToString.Trim
        End If
        If p_TankHeaderCode = "" Then
            ShowMessageBox("", "Bản ghi không xác định")
            Exit Sub
        End If

        'p_SQL = "select  count(*) as TankHeaderCode from ztblTankLineImp where TankHeaderCode ='" & p_TankHeaderCode & "'"
        'p_TableCheck = GetDataTable(p_SQL, p_SQL)
        'If Not p_TableCheck Is Nothing Then
        '    p_Count = p_TableCheck.Rows(0).Item(0)
        'End If
        p_SQL = ""
        For p_Count = Me.GridView1.RowCount - 1 To -0 Step -1
            p_row = GridView1.GetDataRow(p_Count)
            If Not p_row Is Nothing Then
                If p_row.Item("X").ToString.Trim = "Y" Then
                    p_SQL = "1"
                    Exit For
                End If
            End If
        Next
        If p_SQL = "" Then
            ShowMessageBox("", "Vui lòng chọn thông tin đo bể cần đưa lên SAP")
            Exit Sub
        End If
        p_SQL = ""
        'GoTo LineTT    'Tam thoi 
        If Not Me.sType.EditValue Is Nothing Then
            p_sType = Me.sType.EditValue.ToString.Trim
        End If

LineTT:
        If p_Status = "S" Then
            ShowMessageBox("", "Thông tin đã được đưa lên SAP")
            Exit Sub
        End If


        'If p_Status <> "Y" Then
        '    ShowMessageBox("", "Thông tin chưa được phê duyệt")
        '    Exit Sub
        'End If
        Try


            Dim p_ValueMess As Windows.Forms.DialogResult

            p_ValueMess = g_Module.ShowMessage(Me, "", _
                                            "Bạn có chắn chắn muốn thực hiện không?", _
                                            True, _
                                             "Có", _
                                            True, _
                                            "Không", _
                                            False, _
                                            "", _
                                             0)
            If p_ValueMess = Windows.Forms.DialogResult.No Then
                Cursor = Cursors.Default
                Exit Sub
            End If

            p_SQL = "select * from tblConfig"
            p_Table = GetDataTable(p_SQL, p_SQL)

            If Not Me.TankHeaderCode.EditValue Is Nothing Then
                p_Code = Me.TankHeaderCode.EditValue.ToString.Trim
            End If

            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    p_SapConnectionString = p_Table.Rows(0).Item("SapConnectionString").ToString.Trim
                    p_Plant_DB = p_Table.Rows(0).Item("Plant_DB").ToString.Trim
                End If
            End If

            If p_SapConnectionString = "" Then
                Exit Sub
            End If

            Dim p_TableATG As DataTable

            p_Binding = Me.TrueDBGrid1.DataSource
            p_TableATG = CType(p_Binding.DataSource, DataTable)
            p_SQL = ""
            DongBoATG(p_TankHeaderCode, p_Plant_DB, p_TableATG, p_SQL)
          
           
            'l_err = _dsMessage.Tables(0).Rows(11)("Message").ToString() '"m011"
            'o_err = o_err & "-" & l_err

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
        End Try
    End Sub




    Public Sub DongBoATG(ByVal p_TankHeaderCode As String, ByVal p_Plant_DB As String, ByVal p_TableATG As DataTable, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
                p_Table = p_ECCDestinationConfig.clsDongBoATG(p_TankHeaderCode, p_Plant_DB, p_TableATG, g_UserName, o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""
                        '   p_SQL = "Update ztblTankHeaderImp set Status ='S', SyncDate =getdate()  ,SyncUser  ='" & g_UserName & "'  where TankHeaderCode = '" & p_TankHeaderCode & "'"
                        If g_Services.Sys_Execute_DataTbl(p_Table, _
                                                  o_err) = False Then
                            Exit Sub
                        End If
                        Me.DefaultFormLoad = True
                        Me.LoadDataToForm()
                        Me.DefaultFormLoad = False
                        ReloadData()
                        ShowMessageBox("", "Đã thực hiện xong", 1)
                    End If
                End If
                If o_err <> "" Then
                    ShowMessageBox("", o_err)
                End If
            End If
        End If



    End Sub


    Private Sub U_ButtonCus1_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_SQL As String
        Dim p_TRanCode As String = ""
        If Not Me.TankHeaderCode.EditValue Is Nothing Then
            p_TRanCode = Me.TankHeaderCode.EditValue.ToString.Trim
        End If
        If p_TRanCode = "" Then
            Exit Sub
        End If
        p_ValueMess = g_Module.ShowMessage(Me, "", _
                                        "Bạn có chắn chắn muốn Phê duyệt không?", _
                                        True, _
                                         "Có", _
                                        True, _
                                        "Không", _
                                        False, _
                                        "", _
                                         0)
        If p_ValueMess = Windows.Forms.DialogResult.No Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        p_SQL = "update ztblTankHeaderImp set Status ='Y' where  TankHeaderCode ='" & p_TRanCode & "'"
        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
            ShowMessageBox("", p_SQL, 3)
        Else
            ShowMessageBox("", "Đã thực hiện xong", 1)
            ReloadData()
        End If

    End Sub


    Private Function ValidDateTank(ByVal p_Date As String, ByVal p_TankCode As String) As Boolean
        Dim p_SQL As String = "SELECT 'N' as X, [TankCode],[Product]  FROM [zTankListATG_v] b "   'where charindex(left(TankCode,1),(select Terminal  from sys_USeR where upper(USER_NAME) =UPPER('" & g_UserName & "')),1)>0"
        Dim p_Count As Integer
        Dim p_Count2 As Integer
        Dim p_StrSplit() As String
        Dim p_Datatable As DataTable
        'Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Dim p_Client As String = ""
        Dim p_RowArr() As DataRow

        p_StrSplit = p_TankCode.Split(",")

        If Not Me.Client.EditValue Is Nothing Then
            p_Client = Me.Client.EditValue.ToString.Trim
        End If

        If p_Client = "ALL" Then
            p_SQL = p_SQL & "  where 1=1 "
        ElseIf p_Client = "C" Then
            p_SQL = p_SQL & " where (left(TankCode,1) ='C' or  left(TankCode,1) ='D')"
        Else
            p_SQL = p_SQL & " where (left(TankCode,1) ='" & p_Client & "')  "
        End If

        If p_Date <> "" Then
            p_SQL = p_SQL & " and  not exists (select 1  from dbo.zTankListATG_AM  h  where  '" & p_Date & "' >=   isnull(FROMDATE,getdate()-5) " & _
                             " and '" & p_Date & "'  <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.TankCode ) "
            p_SQL = p_SQL & " and  not exists (select 1  from dbo.zTankListATG_M  h  where  '" & p_Date & "' >=   isnull(FROMDATE,getdate()-5) " & _
                            " and '" & p_Date & "'  <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.TankCode ) "
        End If
        p_Datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                If p_StrSplit.Length > 0 Then
                    For p_Count = 0 To p_StrSplit.Length - 1
                        If p_StrSplit(p_Count).ToString.Trim <> "" Then
                            p_RowArr = p_Datatable.Select("TankCode ='" & p_StrSplit(p_Count).ToString.Trim & "'")
                            If p_RowArr.Length <= 0 Then
                                ShowMessageBox("", "Bể đo " & p_StrSplit(p_Count).ToString.Trim & " không hợp lệ")
                                Return False
                            End If
                        End If
                       
                    Next
                End If
            End If
        End If
        Return True
    End Function

    Private Function ValidDateTankM(ByVal p_Date As String, ByVal p_TankCode As String) As Boolean
        Dim p_SQL As String = "SELECT 'N' as X, [TankCode],[Product]  FROM [zTankListATG_v] b "   'where charindex(left(TankCode,1),(select Terminal  from sys_USeR where upper(USER_NAME) =UPPER('" & g_UserName & "')),1)>0"
        Dim p_Count As Integer
        Dim p_Count2 As Integer
        Dim p_StrSplit() As String
        Dim p_Datatable As DataTable
        'Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Dim p_Client As String = ""
        Dim p_RowArr() As DataRow

        'p_StrSplit = p_TankCode.Split(",")

        'If Not Me.Client.EditValue Is Nothing Then
        '    p_Client = Me.Client.EditValue.ToString.Trim
        'End If
        If p_TankCode.ToString.Trim = "" Then
            Return True
        End If

        If ATG = True Then
            If g_Auto = False Then  'Nhap tay  cho be ATG  (Đo bể trống ) chỉ lấy danh sách bể  trong danh mục đo bể trống

                p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                            " a where  isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd  and b.Name_nd  ='" & p_TankCode & "' " ' and  not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"

                p_SQL = p_SQL & " and ( exists (select 1  from dbo.zTankListATG_M  h  where  '" & p_Date & "'  >=   isnull(FROMDATE,getdate()-5) " & _
                      " and   '" & p_Date & "'    <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd ) )"


            Else

                p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                            " a where  isnull(Product_nd,'') <>'' " & _
                            " and a.Mahanghoa =b.Product_nd and  exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)   and b.Name_nd  ='" & p_TankCode & "' "

            End If



        Else    'Do be nhap tay    lấy danh sách bể khôg nằm trong danh sách khai báo bể ATG   hoặc nằm trong danh sách TBĐMTĐ chuyển nhập tay 
            'If p_Client <> "ALL" Then
            '    If p_Client = "C" Then
            '        p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
            '                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) like  '%" & p_Client & "%' or substring(Name_nd,2,1) Like '%D%'   ) and isnull(Product_nd,'') <>'' " & _
            '                " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
            '        'Them danh sach cac be ATG tu dong cho nhap tay
            '        p_SQL = p_SQL & " union all select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
            '           " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) like  '%" & p_Client & "%' or substring(Name_nd,2,1) Like '%D%'   ) and isnull(Product_nd,'') <>'' " & _
            '           " and a.Mahanghoa =b.Product_nd "
            '        p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where  :Column.CrDate >=   isnull(FROMDATE,getdate()-5) " & _
            '                  " and  :Column.CrDate <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
            '    Else
            '        p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
            '                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
            '                " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
            '        'Them danh sach cac be ATG tu dong cho nhap tay
            '        p_SQL = p_SQL & " union all select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
            '                " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
            '                " and a.Mahanghoa =b.Product_nd "
            '        p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where :Column.CrDate >=   isnull(FROMDATE,getdate()-5) " & _
            '                " and  :Column.CrDate <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
            '    End If
            'Else
            p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                        " a where  isnull(Product_nd,'') <>'' " & _
                        " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd) " & _
                        "  and b.Name_nd  ='" & p_TankCode & "' "
            'Them danh sach cac be ATG tu dong cho nhap tay
            p_SQL = p_SQL & " union all  select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
                        " a where  isnull(Product_nd,'') <>'' " & _
                        " and a.Mahanghoa =b.Product_nd  and b.Name_nd  ='" & p_TankCode & "' "
            p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where   '" & p_Date & "'  >=   isnull(FROMDATE,getdate()-5) " & _
                      " and   '" & p_Date & "'  <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
            '  End If



            'p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where  getdate() >=   isnull(FROMDATE,getdate()-5) " & _
            '          " and  getdate() <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"
        End If



        p_Datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count <= 0 Then

                ShowMessageBox("", "Bể đo " & p_TankCode & " không hợp lệ")
                Return False
                'If p_StrSplit.Length > 0 Then
                '    For p_Count = 0 To p_StrSplit.Length - 1
                '        If p_StrSplit(p_Count).ToString.Trim <> "" Then
                '            p_RowArr = p_Datatable.Select("TankCode ='" & p_StrSplit(p_Count).ToString.Trim & "'")
                '            If p_RowArr.Length <= 0 Then
                '                ShowMessageBox("", "Bể đo " & p_StrSplit(p_Count).ToString.Trim & " không hợp lệ")
                '                Return False
                '            End If
                '        End If

                '    Next
                'End If
            End If
        End If
        Return True
    End Function

    'Private Function ValidDateTankM(ByVal p_Date As String, ByVal p_TankCode As String) As Boolean
    '    Dim p_SQL As String = "SELECT 'N' as X, [TankCode],[Product]  FROM [zTankListATG_v] b "   'where charindex(left(TankCode,1),(select Terminal  from sys_USeR where upper(USER_NAME) =UPPER('" & g_UserName & "')),1)>0"
    '    Dim p_Count As Integer
    '    Dim p_Count2 As Integer
    '    Dim p_StrSplit() As String
    '    Dim p_Datatable As DataTable
    '    'Dim p_Binding As New U_TextBox.U_BindingSource
    '    Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    '    Dim p_Client As String = ""
    '    Dim p_RowArr() As DataRow

    '    p_StrSplit = p_TankCode.Split(",")

    '    If Not Me.Client.EditValue Is Nothing Then
    '        p_Client = Me.Client.EditValue.ToString.Trim
    '    End If

    '    If p_Client = "ALL" Then
    '        'p_SQL = p_SQL & "  where 1=1 "
    '        If p_Date <> "" Then
    '            p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
    '                            " a where  isnull(Product_nd,'') <>'' " & _
    '                            " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
    '            'Them danh sach cac be ATG tu dong cho nhap tay
    '            p_SQL = p_SQL & " union all select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
    '                    " a where  isnull(Product_nd,'') <>'' " & _
    '                    " and a.Mahanghoa =b.Product_nd "
    '            p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where  '" & p_Date & "'  >=   isnull(FROMDATE,getdate()-5) " & _
    '                    " and   '" & p_Date & "' <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"

    '            p_SQL = p_SQL & " union all select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
    '                   " a where  isnull(Product_nd,'') <>'' " & _
    '                   " and a.Mahanghoa =b.Product_nd "
    '            p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_M  h  where  '" & p_Date & "'  >=   isnull(FROMDATE,getdate()-5) " & _
    '                    " and   '" & p_Date & "' <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"

    '        End If

    '        '  ElseIf p_Client = "C" Then
    '    Else
    '        If p_Date <> "" Then
    '            p_SQL = "select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
    '                            " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
    '                            " and a.Mahanghoa =b.Product_nd and not exists (select 1 from zTankListATG h where h.tankcode =b.Name_nd)"
    '            'Them danh sach cac be ATG tu dong cho nhap tay
    '            p_SQL = p_SQL & " union all select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
    '                    " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
    '                    " and a.Mahanghoa =b.Product_nd "
    '            p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_AM  h  where  '" & p_Date & "'  >=   isnull(FROMDATE,getdate()-5) " & _
    '                    " and   '" & p_Date & "' <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"

    '            p_SQL = p_SQL & " union all select Name_nd as TankCode, Product_nd as Product_nd, a.TenHangHoa from tblTank b,tblHangHoa " & _
    '                    " a where ( left(Name_nd,1) = '" & p_Client & "'   or substring(Name_nd,2,1) Like '%" & p_Client & "%'  ) and isnull(Product_nd,'') <>'' " & _
    '                    " and a.Mahanghoa =b.Product_nd "
    '            p_SQL = p_SQL & " and exists (select 1  from dbo.zTankListATG_M  h  where  '" & p_Date & "'  >=   isnull(FROMDATE,getdate()-5) " & _
    '                    " and   '" & p_Date & "' <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.Name_nd )"

    '        End If
    '        ''p_SQL = p_SQL & " where (left(TankCode,1) ='C' or  left(TankCode,1) ='D')"
    '        ' Else
    '        '  p_SQL = p_SQL & " where (left(TankCode,1) ='" & p_Client & "')  "
    '    End If


    '    p_Datatable = GetDataTable(p_SQL, p_SQL)
    '    If Not p_Datatable Is Nothing Then
    '        If p_Datatable.Rows.Count > 0 Then
    '            If p_StrSplit.Length > 0 Then
    '                For p_Count = 0 To p_StrSplit.Length - 1
    '                    If p_StrSplit(p_Count).ToString.Trim <> "" Then
    '                        p_RowArr = p_Datatable.Select("TankCode ='" & p_StrSplit(p_Count).ToString.Trim & "'")
    '                        If p_RowArr.Length <= 0 Then
    '                            ShowMessageBox("", "Bể đo " & p_StrSplit(p_Count).ToString.Trim & " không hợp lệ")
    '                            Return False
    '                        End If
    '                    End If

    '                Next
    '            End If
    '        End If
    '    End If
    '    Return True
    'End Function


    Private Sub U_ButtonEdit2_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TankList.ButtonClick
        Dim FrmLenhXuatAdd As New FrmChonBeATG
        Dim p_Client As String = ""
        Dim p_TankList As String = ""
        Dim p_Status As String = ""
        Dim p_Date As String = ""

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If
        If Not Me.TankList.EditValue Is Nothing Then
            p_TankList = Me.TankList.EditValue.ToString.Trim
        End If
        If Not Me.Client.EditValue Is Nothing Then
            p_Client = Me.Client.EditValue.ToString.Trim
        End If

        If Not Me.FromDate.EditValue Is Nothing Then
            If Me.FromDate.EditValue.ToString.Trim <> "" Then
                p_Date = CDate(Me.FromDate.EditValue).ToString("yyyyMMdd HH:mm:ss")

            End If

        End If
        If p_Date = "" Then
            ShowMessageBox("", "Ngày giờ đo bể không được trống")
            Exit Sub
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
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.ShowDialog(Me)
        Me.TankList.EditValue = FrmLenhXuatAdd.g_StringTank
    End Sub

    Private Sub U_ButtonEdit2_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TankList.EditValueChanged

    End Sub

    Private Sub PurposeName_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles CreateUser.EditValueChanged, PurposeName.EditValueChanged

    End Sub

    Private Sub U_ButtonEdit1_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles U_ButtonEdit1.EditValueChanged

    End Sub

    Private Sub U_ButtonCus2_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus2.Click
        Dim p_MDD As String = ""
        If Not Me.U_ButtonEdit1.EditValue Is Nothing Then
            p_MDD = Me.U_ButtonEdit1.EditValue.ToString.Trim
        End If
        'If p_MDD = "" Then
        '    ShowMessageBox("", "Mục đích đo chưa nhập")
        '    Exit Sub
        'End If
        If Me.FormStatus = True Then
            Me.DefaultSave = True
            Me.UpdateToDatabase(Me)
            Me.DefaultSave = False
            RutSoLieuATG(False)
            ReloadData()
        End If

    End Sub

    Private Sub U_CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles U_CheckBox1.CheckedChanged
        Dim p_Count As Integer
        Dim p_Value As String = "N"
        If Me.FormEdit = False Then
            Exit Sub
        End If
        If Me.U_CheckBox1.Checked = True Then
            p_Value = "Y"

        End If
     
        Try
            'End If
            Cursor = Cursors.WaitCursor
            For p_Count = Me.GridView1.RowCount To 0 Step -1
                GridView1.SetRowCellValue(p_Count, "X", p_Value)
                GridView1.SetRowCellValue(p_Count, "CHECKUPD", "Y")
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub Client_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Client.KeyPress
        e.Handled = True
    End Sub



    Private Sub TankList_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TankList.Validating
        Dim p_Value As String = ""
        Dim p_StrSplit() As String
        Dim p_Obj As New U_TextBox.U_ButtonEdit
        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        Dim p_Date As String
        Dim p_Check As Boolean = False
        Try
            p_Obj = CType(sender, U_TextBox.U_ButtonEdit)

            If p_Obj.IsModified = False Then
                Exit Sub
            End If
            'If Not p_Obj.OldEditValue Is Nothing Then
            '    If Not p_Obj.EditValue Is Nothing Then
            '        If  p_Obj.OldEditValue.ToString.Trim = Then

            '        End If
            '    End If
            'End If
            If Me.TankList.Enabled = False Then
                Exit Sub
            End If
            If Me.TankList.Properties.ReadOnly = True Then
                Exit Sub
            End If
            If Me.FormEdit = False Then
                Exit Sub
            End If
            If Me.TankList.EditValue Is Nothing Then
                Exit Sub
            End If
            If Not Me.FromDate.EditValue Is Nothing Then
                If Me.FromDate.EditValue.ToString.Trim <> "" Then
                    p_Date = CDate(Me.FromDate.EditValue).ToString("yyyyMMdd HH:mm:ss")
                End If
            End If
            p_Value = UCase(Me.TankList.EditValue.ToString.Trim)
            'Me.TankList.EditValue = p_Value
            If p_Value <> "" Then
                '  p_SQL = Me.TankList.SqlString
                If ValidDateTank(p_Date, p_Value) = False Then
                    e.Cancel = True

                    Exit Sub
                End If
            End If
            ' p_StrSplit = p_Value.Split(",")
        Catch ex As Exception

        End Try

    End Sub



    Private Function CheckValidTank() As Boolean
        Dim p_Value As String = ""
        Dim p_StrSplit() As String
        Dim p_Obj As New U_TextBox.U_ButtonEdit
        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        Dim p_Date As String
        Dim p_Check As Boolean = False
        Try
           
            'If Not p_Obj.OldEditValue Is Nothing Then
            '    If Not p_Obj.EditValue Is Nothing Then
            '        If  p_Obj.OldEditValue.ToString.Trim = Then

            '        End If
            '    End If
            'End If
            CheckValidTank = True

            If Me.TankList.Enabled = False Then
                Exit Function
            End If
            If Me.TankList.Properties.ReadOnly = True Then
                Exit Function
            End If
            If Me.FormEdit = False Then
                Exit Function
            End If
            If Me.TankList.EditValue Is Nothing Then
                Exit Function
            End If
            If Not Me.FromDate.EditValue Is Nothing Then
                If Me.FromDate.EditValue.ToString.Trim <> "" Then
                    p_Date = CDate(Me.FromDate.EditValue).ToString("yyyyMMdd HH:mm:ss")
                End If
            End If
            p_Value = UCase(Me.TankList.EditValue.ToString.Trim)
            'Me.TankList.EditValue = p_Value
            If p_Value <> "" Then
                '  p_SQL = Me.TankList.SqlString
                If ValidDateTank(p_Date, p_Value) = False Then
                    Return False
                End If
            End If
            ' p_StrSplit = p_Value.Split(",")
        Catch ex As Exception

        End Try
        Return True
    End Function




    Private Function CheckValidTankLine() As Boolean
        Dim p_Value As String = ""
        Dim p_StrSplit() As String
        '  Dim p_Obj As New U_TextBox.U_ButtonEdit
        '  Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        Dim p_Date As String
        Dim p_Check As Boolean = False
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Count As Integer
        Dim p_Row As DataRow
        Try
           
            'If Not p_Obj.OldEditValue Is Nothing Then
            '    If Not p_Obj.EditValue Is Nothing Then
            '        If  p_Obj.OldEditValue.ToString.Trim = Then

            '        End If
            '    End If
            'End If
            CheckValidTankLine = True
            ' Exit Function

            If Not Me.sType.EditValue Is Nothing Then
                p_Value = Me.sType.EditValue.ToString.Trim
            End If

            If p_Value <> "M" Then
                Exit Function
            End If
            '    p_Binding = Me.TrueDBGrid1.DataSource

            '   p_Binding = Me.GridView1.DataSource
            ' p_DataTable = CType(p_Binding.DataSource, DataTable)
            For p_Count = 0 To Me.GridView1.RowCount - 1
                p_Row = Me.GridView1.GetDataRow(p_Count)
                If p_Row Is Nothing Then
                    Continue For
                End If
                If Not p_Row.Item("CrDate") Is Nothing Then
                    If p_Row.Item("CrDate").ToString.Trim = "" Then
                        Continue For
                    End If
                    If p_Row.Item("TankCode").ToString.Trim = "" Then
                        Continue For
                    End If
                    p_Date = CDate(p_Row.Item("CrDate")).ToString("yyyyMMdd HH:mm:ss")
                    p_Value = p_Row.Item("TankCode").ToString.Trim
                    If ValidDateTankM(p_Date, p_Value) = False Then
                        Return False
                    End If
                End If
            Next
           
          
            ' p_StrSplit = p_Value.Split(",")
        Catch ex As Exception

        End Try
        Return True
    End Function


    Private Sub TrueDBGrid1_Click(sender As System.Object, e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim p_Value As String = ""
        Dim p_Row As DataRow
        Dim p_DateTime As DateTime
        Dim p_DateCheck As Boolean = False
        Dim p_Value2 As String = ""
        Dim p_MucDDCode As String = ""
        Dim p_MucDDName As String = ""
        Dim p_Dens As Double = 0.0
        Dim p_Temp As Double = 0.0
        Dim p_SQL As String = ""
        Dim p_Tank As String = ""
        Dim p_Table As DataTable
        Dim p_TankHeight As Double = 0
        Dim p_Item As String = ""
        '  Dim p_Row As DataRow
        'Exit Sub
        If UCase(Me.GridView1.FocusedColumn.FieldName.ToString.Trim) = UCase("PurposeCode") Then
            Try

                p_Row = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                If Not p_Row Is Nothing Then
                    If p_Row.Item("PurposeCode").ToString.Trim = UCase(Me.GridView1.GetFocusedValue.ToString.Trim) Then
                        Exit Sub
                    End If
                End If
                Me.GridView1.SetFocusedRowCellValue("PurposeCode", UCase(Me.GridView1.GetFocusedValue.ToString.Trim))
            Catch ex As Exception

            End Try

        End If


        If g_Auto = False Or ATG = True Then
            If UCase(e.Column.FieldName.ToString.Trim) = UCase("TankHeight") Or UCase(e.Column.FieldName.ToString.Trim) = UCase("Dens") _
                    Or UCase(e.Column.FieldName.ToString.Trim) = UCase("TankTemp") Or UCase(e.Column.FieldName.ToString.Trim) = UCase("TankCode") Then
                'Tinh QCI
                GridView1.UpdateCurrentRow()
                p_Row = Me.GridView1.GetFocusedDataRow

                If Not p_Row Is Nothing Then
                    Try
                        p_Tank = ""
                        p_Dens = 0.0
                        p_Temp = 0.0
                        p_TankHeight = 0


                        p_Tank = p_Row.Item("TankCode").ToString.Trim

                        p_Item = p_Row.Item("ProductCode").ToString.Trim
                        'If p_Item = "" Then
                        p_SQL = " select Product_nd  from tbltank   where Name_nd ='" & p_Tank & "' "
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                p_Row.Item("ProductCode") = p_Table.Rows(0).Item(0).ToString.Trim
                            End If
                        End If
                        ' End If
                        p_Dens = p_Row.Item("Dens").ToString.Trim
                        p_Temp = p_Row.Item("TankTemp").ToString.Trim
                        p_TankHeight = p_Row.Item("TankHeight").ToString.Trim
                    Catch ex As Exception

                    End Try

                End If


                If p_Dens = 0 Or p_Temp = 0 Or p_TankHeight = 0 Then
                    If p_Tank <> "" Then
                        p_SQL = "select top 1 case when isnull(Map_Sap1,'') <>'' then Map_Sap1 else Null end from tblTank b  where Name_nd= '" & p_Tank & "'"
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                p_Row.Item("TankMap") = p_Table.Rows(0).Item(0).ToString.Trim
                            End If
                        End If
                    End If
                Else
                    p_SQL = "FPT_GetBaremTankATG_QCI '" & p_Tank & "','" & p_Temp & "', '" & p_Dens & "', " & p_TankHeight
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If p_Table.Rows.Count > 0 Then
                            p_Row.Item("Ltt") = p_Table.Rows(0).Item("Ltt")
                            p_Row.Item("VCF") = p_Table.Rows(0).Item("VCF")
                            p_Row.Item("WCF") = p_Table.Rows(0).Item("WCF")
                            p_Row.Item("VolumnL15") = p_Table.Rows(0).Item("L15")
                            p_Row.Item("VolumnKG") = p_Table.Rows(0).Item("Kg")
                            'TankMap'
                            p_Row.Item("TankMap") = p_Table.Rows(0).Item("TankMap")
                            'Me.GridView1.SetFocusedRowCellValue("Ltt", p_Table.Rows(0).Item("Ltt"))
                            'Me.GridView1.SetFocusedRowCellValue("VCF", p_Table.Rows(0).Item("VCF"))
                            'Me.GridView1.SetFocusedRowCellValue("WCF", p_Table.Rows(0).Item("WCF"))
                            'Me.GridView1.SetFocusedRowCellValue("VolumnL15", p_Table.Rows(0).Item("L15"))
                            'Me.GridView1.SetFocusedRowCellValue("VolumnKG", p_Table.Rows(0).Item("Kg"))
                        End If


                        '    Me.GridView1.SetFocusedRowCellValue("Ltt", p_Table.Rows(0).Item("Ltt"))
                        '    Me.GridView1.SetFocusedRowCellValue("VCF", p_Table.Rows(0).Item("VCF"))
                        '    Me.GridView1.SetFocusedRowCellValue("WCF", p_Table.Rows(0).Item("WCF"))
                        '    Me.GridView1.SetFocusedRowCellValue("VolumnL15", p_Table.Rows(0).Item("L15"))
                        '    Me.GridView1.SetFocusedRowCellValue("VolumnKG", p_Table.Rows(0).Item("Kg"))
                        'End If
                    End If
                End If

            End If
            If UCase(e.Column.FieldName.ToString.Trim) <> "TANKCODE" And UCase(e.Column.FieldName.ToString.Trim) <> "CRDATE" Then
                Exit Sub
            End If


            'If UCase(e.Column.FieldName.ToString.Trim) = "PurposeCode" Then
            '    Try
            '        Me.GridView1.SetFocusedRowCellValue("PurposeCode", UCase(e.Value))
            '    Catch ex As Exception

            '    End Try

            'End If


            If Not Me.FromDate.EditValue Is Nothing Then
                If Me.FromDate.EditValue.ToString.Trim <> "" Then
                    p_DateTime = Me.FromDate.EditValue
                    p_DateCheck = True
                End If

            End If
            Try
                If Not Me.U_ButtonEdit1.EditValue Is Nothing Then
                    p_MucDDCode = Me.U_ButtonEdit1.EditValue.ToString.Trim
                End If
            Catch ex As Exception

            End Try

            If p_MucDDCode <> "" Then
                If Not Me.PurposeName.EditValue Is Nothing Then
                    p_MucDDName = Me.PurposeName.EditValue.ToString.Trim
                End If
            End If

            p_Row = Me.GridView1.GetFocusedDataRow
            If UCase(e.Column.FieldName.ToString.Trim) = UCase("CrDate") Then
                ' Exit Sub
            End If
            If Not p_Row Is Nothing Then
                Try
                    p_Value = p_DateTime.ToString.Trim
                    ' p_Value = p_Row.Item("CrDate").ToString.Trim
                Catch ex As Exception

                End Try
                If g_Auto = False Then
                    Try

                        p_Value = p_Row.Item("CrDate").ToString.Trim
                    Catch ex As Exception

                    End Try
                End If

                If p_Value = "" And p_DateCheck = True Then
                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "CrDate", p_DateTime)
                    Double.TryParse(p_Row.Item("Dens").ToString.Trim, p_Dens)
                    If p_Dens = 0 Then
                        p_Tank = p_Row.Item("TankCode").ToString.Trim
                        If p_Tank <> "" Then
                            p_SQL = "exec FPT_GetDensATG '" & p_Tank & "','" & p_DateTime.ToString("MM-dd-yyyy hh:mm:ss") & "'"
                            p_Table = GetDataTable(p_SQL, p_SQL)
                            If Not p_Table Is Nothing Then
                                If p_Table.Rows.Count > 0 Then
                                    Double.TryParse(p_Table.Rows(0).Item("Dens").ToString.Trim, p_Dens)
                                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "Dens", p_Dens)
                                End If
                            End If
                        End If
                        'If
                    End If
                ElseIf p_Value <> "" Then
                    Double.TryParse(p_Row.Item("Dens").ToString.Trim, p_Dens)
                    'If p_Dens = 0 Then
                    p_Tank = p_Row.Item("TankCode").ToString.Trim
                    If p_Tank <> "" Then
                        p_SQL = "exec FPT_GetDensATG '" & p_Tank & "','" & CDate(p_Value).ToString("MM-dd-yyyy HH:mm:ss") & "'"
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                Double.TryParse(p_Table.Rows(0).Item("Dens").ToString.Trim, p_Dens)
                                Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "Dens", p_Dens)
                            End If
                        End If
                    End If
                    'End If
                    'End If

                End If
                If p_MucDDCode <> "" Then
                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "PurposeCode", p_MucDDCode)
                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "PurposeName", p_MucDDName)
                End If
            End If

        End If
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        'Dim p_Value As String = ""
        'Dim p_Row As DataRow
        'Dim p_DateTime As DateTime


        'e.Value = UCase(e.Value)
        'Dim p_Value2 As String = ""
        'If g_Auto = False Then
        '    If Not Me.FromDate.EditValue Is Nothing Then
        '        p_DateTime = Me.FromDate.EditValue
        '    End If
        '    p_Row = Me.GridView1.GetFocusedDataRow
        '    If Not p_Row Is Nothing Then
        '        Try
        '            p_Value = p_Row.Item("CrDate").ToString.Trim
        '        Catch ex As Exception

        '        End Try
        '    End If
        '    If p_Value = "" Then
        '        Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, CrDate, p_DateTime)
        '    End If
        'End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown
        'Dim p_View As New U_TextBox.GridView
        'Dim p_Row As DataRow
        'If UCase(Me.GridView1.FocusedColumn.FieldName.ToString.Trim) = UCase("PurposeCode") Then
        '    Try
        '        p_View = CType(sender, U_TextBox.GridView)
        '        p_Row = p_View.GetDataRow(p_View.FocusedRowHandle)
        '        Me.GridView1.SetFocusedRowCellValue("PurposeCode", UCase(Me.GridView1.GetFocusedValue.ToString.Trim))
        '    Catch ex As Exception

        '    End Try

        'End If
    End Sub

    Private Sub GridView1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles GridView1.KeyPress

    End Sub




    Private Sub GridView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridView1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If g_Auto = True Then Exit Sub

            Dim p_Menu As New ContextMenu
            Dim p_Menuitem As MenuItem
            Dim p_Status As String = ""
            If Not Me.Status.EditValue Is Nothing Then
                p_Status = Me.Status.EditValue.ToString.Trim
            End If
            If p_Status = "Y" Or p_Status = "S" Then
                Exit Sub

            End If
            p_Menuitem = New MenuItem
            p_Menuitem.Name = "mnuDel"
            p_Menuitem.Text = "Xóa dòng"

            AddHandler p_Menuitem.Click, AddressOf Mouse_Click

            p_Menu.MenuItems.Add(p_Menuitem)
            p_Menu.Show(Me.TrueDBGrid1, New Point(e.X + 10, e.Y))
        End If
    End Sub
    Private Sub Mouse_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim p_DocEntry As Double
        If Not Me.DocEntry.EditValue Is Nothing Then
            Double.TryParse(Me.DocEntry.EditValue.ToString.Trim, p_DocEntry)
        End If
        If p_DocEntry > 0 Then
            Dim p_SQL As String = ""
            Dim p_Table As DataTable
            p_SQL = " select isnull(Status,'')  as Status from [ztblTankHeaderImp]  where sType ='M' and DocEntry =" & p_DocEntry
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0).ToString.Trim <> "" Then
                        ShowMessageBox("", "Trạng thái giao dịch không phù hợp")
                        Exit Sub
                    End If
                    Me.GridView1.DefaultRemove = True
                    Me.TrueDBGrid1.EmbeddedNavigator.Buttons.DoClick(Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove)
                    Me.FormStatus = True
                    Me.GridView1.DefaultRemove = False
                End If
            End If
        End If
    End Sub

    Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim p_View As U_TextBox.GridView
        Dim p_Status As String = ""
        p_View = sender
        p_Status = ""
        If e.RowHandle >= 0 Then
            Try
                p_Status = p_View.GetRowCellDisplayText(e.RowHandle, "Status")
            Catch ex As Exception

            End Try

            If p_Status = "E" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
                e.HighPriority = True
            Else
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
                e.HighPriority = True
            End If
        End If
    End Sub

    Private Sub GridView1_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor
        Column_Button_Click(sender, e)

    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        Dim FrmATG As New FrmBarem
        FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmATG.g_XtraServicesObj = g_XtraServicesObj
        FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
        FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmATG.p_XtraMessageStatusl = g_MessageStatus
        FrmATG.ShowDialog(Me)


    End Sub

    Private Sub ToolStripButton8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton8.Click
        Dim p_SQL As String = ""
        Dim p_TranCode As String = ""
        Dim p_SQLErr As String = ""
        '  p_SQL = ""
        If Not Me.Status.EditValue Is Nothing Then
            p_SQL = Me.Status.EditValue.ToString.Trim
        End If

        If p_SQL = "Y" Or p_SQL = "S" Or p_SQL = "C" Then
            ShowMessageBox("", "Trạng thái không hợp lệ")
            Exit Sub
        End If

        Dim p_ValueMess As Windows.Forms.DialogResult

        p_ValueMess = g_Module.ShowMessage(Me, "", _
                                        "Bạn có chắn chắn muốn hủy giao dịch không?", _
                                        True, _
                                         "Có", _
                                        True, _
                                        "Không", _
                                        False, _
                                        "", _
                                         0)
        If p_ValueMess = Windows.Forms.DialogResult.No Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        If g_TankHeaderCode <> "" Then
            p_SQL = "UPDATE ztblTankHeaderImp set Status ='C' where  TankHeaderCode ='" & g_TankHeaderCode & "'"
            If g_Services.Sys_Execute(p_SQL, _
                                            p_SQLErr) = False Then
                ShowMessageBox("", p_SQLErr)
                Exit Sub
            End If
           TaoMoiGiaoDich
        End If
    End Sub

    Private Sub Client_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Client.EditValueChanged

    End Sub

    Private Sub FrmTankHeaderImp_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
     
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim p_DataRow As DataRow

        Dim p_SoGiaoDich As Integer = 0
        Dim p_NgayThang As DateTime


        Dim FrmATG As New FrmTankHeaderImp_QL
        If Not Me.DocEntry.EditValue Is Nothing Then
            p_SoGiaoDich = Me.DocEntry.EditValue
        End If
        If Not Me.FromDate.EditValue Is Nothing Then
            p_NgayThang = Me.FromDate.EditValue
        End If
        If p_SoGiaoDich > 0 Then
            FrmATG.g_SoGiaoDich = p_SoGiaoDich
            FrmATG.g_NgayThang = p_NgayThang
            FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
            FrmATG.g_XtraServicesObj = g_XtraServicesObj
            FrmATG.g_Approved = g_Approved
            'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim

            ' FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY
            FrmATG.ViewAdmin = Me.ViewAdmin
            FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
            FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
            FrmATG.p_XtraMessageStatusl = g_MessageStatus

            FrmATG.ShowDialog(Me)
        End If
       
           
    End Sub

    Private Sub FrmTankHeaderImp_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
      
    End Sub

    Private Sub ToolStripButton4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButton4.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim cms = New ContextMenuStrip
            Dim item1 = cms.Items.Add("In nhiều giao dịch")
            item1.Tag = 3

            'Dim cmdMenu = New ContextMenuStrip
            'Dim p_ItemMenu As ToolStripItem
            'p_ItemMenu = cmdMenu.Items.Add(Me.Name.ToString)
            'p_ItemMenu.Name = "sFormName"
            'p_ItemMenu.Tag = 1
            AddHandler item1.Click, AddressOf menuChoice
            'cms.Show(New System.Drawing.Point(e.Location.X + 150, e.Location.Y))
            cms.Show(New System.Drawing.Point(Me.Label1.Left, Me.Label1.Top))
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class