Public Class FrmTaoMoiLenhXuat
    Public g_LXLoai As String = "CIF"

    Dim p_SYS_MALENH_S As String = ""
    Dim p_FunctionTableId As String = ""
    Dim p_DateCreate As Date
    Dim p_TimeCreate As Integer
    Dim p_TableConfig As DataTable

    Public g_SoLenh_Q As String = ""

    Private p_GIAYTO_XE As Boolean = False
    Private p_GIAYTO_LX As Boolean = False
    Private p_BAREM_XE As Boolean = False


    Private p_tblProject_Details As DataTable

    Private p_GiaCongTy_PhiVT As Boolean = False

    Private p_SaoChepLenhXuat As Boolean = False

    Private Sub FrmTaoMoiLenhXuat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            Me.SoLenh.Focus()
            Me.GridView1.RefreshData()

            Me.Focus()

            If Me.FormStatus = True Then
                SaveRecode()
            End If
        End If

    End Sub

    Private Sub FrmTaoMoiLenhXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim p_SQL As String
        Dim p_DataRow() As DataRow
        Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        Dim p_column As U_TextBox.GridColumn
        Dim p_Decimal As Integer
        Dim p_NumberFormat As String = "############"


        p_GetDateTime(p_DateCreate, p_TimeCreate)
        p_XtraUserName = g_User_ID

        p_SQL = "select *   from tblProject_Details"
        p_tblProject_Details = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG"

        p_TableConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRow = p_TableConfig.Select("KEYCODE='SYS_MALENH_S'")
                If p_DataRow.Length > 0 Then
                    p_SYS_MALENH_S = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                End If
                p_DataRow = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRow.Length > 0 Then
                    p_FunctionTableId = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                End If


                p_GIAYTO_XE = False
                p_DataRow = p_TableConfig.Select("KEYCODE='GIAYTO_XE'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_GIAYTO_XE = True
                    End If
                End If


                p_GIAYTO_LX = False
                p_DataRow = p_TableConfig.Select("KEYCODE='GIAYTO_LX'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_GIAYTO_LX = True
                    End If
                End If

                p_BAREM_XE = False
                p_DataRow = p_TableConfig.Select("KEYCODE='BAREM_XE'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_BAREM_XE = True
                    End If
                End If



                p_GiaCongTy_PhiVT = False
                p_DataRow = p_TableConfig.Select("KEYCODE='GIACTY'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_GiaCongTy_PhiVT = True
                    End If
                End If

                p_SaoChepLenhXuat = False

                p_DataRow = p_TableConfig.Select("KEYCODE='COPY'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SaoChepLenhXuat = True
                    End If
                End If
            End If
        End If

        If p_SaoChepLenhXuat = True Then
            Me.ToolStripButton3.Visible = True
        End If


        ''anhqh
        '20200219  them ham thay doi property cua item
        ' SetItemProperty(Me, Me.Name.ToString.Trim, g_LXLoai)
        TaoColumnFind()


        If g_SoLenh_Q = "" Then
            Me.SoLenh.EditValue = ""
            Me.g_FormAddnew = True
            Me.DefaultWhere = "SoLenh=''"
            Me.DefaultFormLoad = True
            Me.Form1_Load(sender, e)
            Me.ChuyenVanChuyen.EditValue = Me.ChuyenVanChuyen.UnCheckValue
            Me.LoaiPhieu.EditValue = "V144"
            Me.NgayXuat.EditValue = p_DateCreate
            Me.LoaiPhieu.Enabled = False
            Me.SoLenh.Focus()
        Else
            Me.DefaultFormLoad = True
            Me.Form1_Load(sender, e)
        End If




        'p_column = Me.GridView1.Columns.Item("DonGia")




        'p_Decimal = p_column.NumberDecimal
        'If p_Decimal > 0 Then

        '    p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

        '    p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
        '    'p_ColNumber.

        '    If p_column.ShowCalc = False Then
        '        p_ColNumber.Buttons(0).Visible = False
        '    End If


        '    p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
        '    p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
        '    p_column.ColumnEdit = p_ColNumber


        '    'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        '    p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    'p_Column.DisplayFormat.FormatString = "c2"
        '    p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"

        'Else


        '    p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

        '    p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
        '    If p_column.ShowCalc = False Then
        '        p_ColNumber.Buttons(0).Visible = False
        '    End If

        '    p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
        '    p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal)
        '    p_column.ColumnEdit = p_ColNumber


        '    p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
        'End If





        'Dim p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        '' p_ColumnEditName = p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).ColumnEditName.ToString.Trim
        'If Me.FormEdit = False Then
        '    p_ColTypeButtonEdit.ReadOnly = True
        'End If
        'p_ColTypeButtonEdit.Appearance.BackColor = Color.LightGray
        'p_ColTypeButtonEdit.Appearance.BackColor2 = Color.LightGray

        'Me.TrueDBGrid1.RepositoryItems.Add(p_ColTypeButtonEdit)


        'AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click


        'p_column.ColumnEdit = p_ColTypeButtonEdit
        'p_column.AppearanceCell.BackColor = Color.LightGray
        'p_column.AppearanceCell.BackColor2 = Color.LightGray


    End Sub


    Private Sub TaoColumnFind()

        Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        Dim p_column As U_TextBox.GridColumn
        Dim p_Decimal As Integer
        Dim p_NumberFormat As String = "############"
        Dim p_ColTypeButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        If p_GiaCongTy_PhiVT = False Then

            If UCase(Me.GridView1.Columns.Item(14).Name) = "GIACTY" Then
                Me.GridView1.Columns.Item(14).VisibleIndex = -1
            End If


            If UCase(Me.GridView1.Columns.Item(15).Name) = "PHIVT" Then
                Me.GridView1.Columns.Item(15).VisibleIndex = -1
            End If

            If UCase(Me.GridView1.Columns.Item(16).Name) = "THEBVMT" Then
                Me.GridView1.Columns.Item(16).VisibleIndex = -1
            End If

            'Me.GridView1.Columns.Item("PhiVT").VisibleIndex = -1
            'Me.GridView1.Columns.Item("TheBVMT").VisibleIndex = -1

            p_column = Me.GridView1.Columns.Item(17)
            p_Decimal = p_column.NumberDecimal
            If p_Decimal > 0 Then

                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                'p_ColNumber.

                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If


                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_column.ColumnEdit = p_ColNumber


                'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                'p_Column.DisplayFormat.FormatString = "c2"
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"

            Else


                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If

                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_column.ColumnEdit = p_ColNumber


                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
            End If





            p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            ' p_ColumnEditName = p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).ColumnEditName.ToString.Trim
            If Me.FormEdit = False Then
                p_ColTypeButtonEdit.ReadOnly = True
            End If
            p_ColTypeButtonEdit.Appearance.BackColor = Color.LightGray
            p_ColTypeButtonEdit.Appearance.BackColor2 = Color.LightGray

            Me.TrueDBGrid1.RepositoryItems.Add(p_ColTypeButtonEdit)


            AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click

            p_column.ColumnEdit = p_ColTypeButtonEdit
            p_column.AppearanceCell.BackColor = Color.LightGray
            p_column.AppearanceCell.BackColor2 = Color.LightGray



        Else

            'Gia Cong ty  20180320
            p_column = Me.GridView1.Columns.Item(14)
            p_column.FieldView = "GiaCty"
            p_column.ValidateValue = False

            p_column.CFLShowLoad = True
            '  p_column.
            p_Decimal = p_column.NumberDecimal
            If p_Decimal > 0 Then

                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                'p_ColNumber.

                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If


                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_column.ColumnEdit = p_ColNumber


                'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                'p_Column.DisplayFormat.FormatString = "c2"
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"

            Else


                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If

                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_column.ColumnEdit = p_ColNumber


                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
            End If





            p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            ' p_ColumnEditName = p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).ColumnEditName.ToString.Trim
            If Me.FormEdit = False Then
                p_ColTypeButtonEdit.ReadOnly = True
            End If
            p_ColTypeButtonEdit.Appearance.BackColor = Color.LightGray
            p_ColTypeButtonEdit.Appearance.BackColor2 = Color.LightGray

            Me.TrueDBGrid1.RepositoryItems.Add(p_ColTypeButtonEdit)


            AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click

            p_column.ColumnEdit = p_ColTypeButtonEdit
            p_column.AppearanceCell.BackColor = Color.LightGray
            p_column.AppearanceCell.BackColor2 = Color.LightGray



            'Phi van tai  20180320
            p_column = Me.GridView1.Columns.Item(15)
            p_column.FieldView = "PhiVT"
            p_column.ValidateValue = False
            p_column.CFLShowLoad = True

            p_Decimal = p_column.NumberDecimal
            If p_Decimal > 0 Then

                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                'p_ColNumber.

                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If


                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_column.ColumnEdit = p_ColNumber


                'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                'p_Column.DisplayFormat.FormatString = "c2"
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
            Else

                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If

                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_column.ColumnEdit = p_ColNumber


                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
            End If





            p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            ' p_ColumnEditName = p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).ColumnEditName.ToString.Trim
            If Me.FormEdit = False Then
                p_ColTypeButtonEdit.ReadOnly = True
            End If
            p_ColTypeButtonEdit.Appearance.BackColor = Color.LightGray
            p_ColTypeButtonEdit.Appearance.BackColor2 = Color.LightGray

            Me.TrueDBGrid1.RepositoryItems.Add(p_ColTypeButtonEdit)


            AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click

            p_column.ColumnEdit = p_ColTypeButtonEdit
            p_column.AppearanceCell.BackColor = Color.LightGray
            p_column.AppearanceCell.BackColor2 = Color.LightGray



            'Gia Cong ty  20180320
            p_column = Me.GridView1.Columns.Item(16)
            p_column.FieldView = "TheBVMT"
            p_column.ValidateValue = False
            p_column.CFLShowLoad = True

            p_Decimal = p_column.NumberDecimal
            If p_Decimal > 0 Then

                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                'p_ColNumber.

                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If


                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_column.ColumnEdit = p_ColNumber


                'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                'p_Column.DisplayFormat.FormatString = "c2"
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"

            Else


                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If

                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_column.ColumnEdit = p_ColNumber


                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
            End If





            p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            ' p_ColumnEditName = p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).ColumnEditName.ToString.Trim
            If Me.FormEdit = False Then
                p_ColTypeButtonEdit.ReadOnly = True
            End If
            p_ColTypeButtonEdit.Appearance.BackColor = Color.LightGray
            p_ColTypeButtonEdit.Appearance.BackColor2 = Color.LightGray

            Me.TrueDBGrid1.RepositoryItems.Add(p_ColTypeButtonEdit)


            AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click


            ''''AddHandler p_ColTypeButtonEdit., AddressOf Column_Button_Click


            p_column.ColumnEdit = p_ColTypeButtonEdit
            p_column.AppearanceCell.BackColor = Color.LightGray
            p_column.AppearanceCell.BackColor2 = Color.LightGray

        End If




    End Sub





    Private Sub TaoColumnFind_BK()

        Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        Dim p_column As U_TextBox.GridColumn
        Dim p_Decimal As Integer
        Dim p_NumberFormat As String = "############"
        Dim p_ColTypeButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        If p_GiaCongTy_PhiVT = False Then

            If UCase(Me.GridView1.Columns.Item(14).Name) = "GIACTY" Then
                Me.GridView1.Columns.Item(14).VisibleIndex = -1
            End If


            If UCase(Me.GridView1.Columns.Item(15).Name) = "PHIVT" Then
                Me.GridView1.Columns.Item(15).VisibleIndex = -1
            End If

            If UCase(Me.GridView1.Columns.Item(16).Name) = "THEBVMT" Then
                Me.GridView1.Columns.Item(16).VisibleIndex = -1
            End If

            'Me.GridView1.Columns.Item("PhiVT").VisibleIndex = -1
            'Me.GridView1.Columns.Item("TheBVMT").VisibleIndex = -1

            p_column = Me.GridView1.Columns.Item("DonGia")
            p_Decimal = p_column.NumberDecimal
            If p_Decimal > 0 Then

                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                'p_ColNumber.

                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If


                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_column.ColumnEdit = p_ColNumber


                'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                'p_Column.DisplayFormat.FormatString = "c2"
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"

            Else


                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If

                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_column.ColumnEdit = p_ColNumber


                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
            End If





            p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            ' p_ColumnEditName = p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).ColumnEditName.ToString.Trim
            If Me.FormEdit = False Then
                p_ColTypeButtonEdit.ReadOnly = True
            End If
            p_ColTypeButtonEdit.Appearance.BackColor = Color.LightGray
            p_ColTypeButtonEdit.Appearance.BackColor2 = Color.LightGray

            Me.TrueDBGrid1.RepositoryItems.Add(p_ColTypeButtonEdit)


            AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click

            p_column.ColumnEdit = p_ColTypeButtonEdit
            p_column.AppearanceCell.BackColor = Color.LightGray
            p_column.AppearanceCell.BackColor2 = Color.LightGray



        Else

            'Gia Cong ty  20180320
            p_column = Me.GridView1.Columns.Item("GiaCty")
            p_column.FieldView = "GiaCty"
            p_column.ValidateValue = False

            p_column.CFLShowLoad = True
            '  p_column.
            p_Decimal = p_column.NumberDecimal
            If p_Decimal > 0 Then

                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                'p_ColNumber.

                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If


                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_column.ColumnEdit = p_ColNumber


                'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                'p_Column.DisplayFormat.FormatString = "c2"
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"

            Else


                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If

                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_column.ColumnEdit = p_ColNumber


                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
            End If





            p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            ' p_ColumnEditName = p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).ColumnEditName.ToString.Trim
            If Me.FormEdit = False Then
                p_ColTypeButtonEdit.ReadOnly = True
            End If
            p_ColTypeButtonEdit.Appearance.BackColor = Color.LightGray
            p_ColTypeButtonEdit.Appearance.BackColor2 = Color.LightGray

            Me.TrueDBGrid1.RepositoryItems.Add(p_ColTypeButtonEdit)


            AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click

            p_column.ColumnEdit = p_ColTypeButtonEdit
            p_column.AppearanceCell.BackColor = Color.LightGray
            p_column.AppearanceCell.BackColor2 = Color.LightGray



            'Phi van tai  20180320
            p_column = Me.GridView1.Columns.Item("PhiVT")
            p_column.FieldView = "PhiVT"
            p_column.ValidateValue = False
            p_column.CFLShowLoad = True

            p_Decimal = p_column.NumberDecimal
            If p_Decimal > 0 Then

                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                'p_ColNumber.

                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If


                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_column.ColumnEdit = p_ColNumber


                'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                'p_Column.DisplayFormat.FormatString = "c2"
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
            Else

                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If

                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_column.ColumnEdit = p_ColNumber


                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
            End If





            p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            ' p_ColumnEditName = p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).ColumnEditName.ToString.Trim
            If Me.FormEdit = False Then
                p_ColTypeButtonEdit.ReadOnly = True
            End If
            p_ColTypeButtonEdit.Appearance.BackColor = Color.LightGray
            p_ColTypeButtonEdit.Appearance.BackColor2 = Color.LightGray

            Me.TrueDBGrid1.RepositoryItems.Add(p_ColTypeButtonEdit)


            AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click

            p_column.ColumnEdit = p_ColTypeButtonEdit
            p_column.AppearanceCell.BackColor = Color.LightGray
            p_column.AppearanceCell.BackColor2 = Color.LightGray



            'Gia Cong ty  20180320
            p_column = Me.GridView1.Columns.Item("TheBVMT")
            p_column.FieldView = "TheBVMT"
            p_column.ValidateValue = False
            p_column.CFLShowLoad = True

            p_Decimal = p_column.NumberDecimal
            If p_Decimal > 0 Then

                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                'p_ColNumber.

                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If


                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"
                p_column.ColumnEdit = p_ColNumber


                'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                'p_Column.DisplayFormat.FormatString = "c2"
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal - 1) & "0"

            Else


                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                If p_column.ShowCalc = False Then
                    p_ColNumber.Buttons(0).Visible = False
                End If

                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_ColNumber.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_ColNumber.EditMask = "#,###,###,###0." & Strings.Left(p_NumberFormat, p_Decimal)
                p_column.ColumnEdit = p_ColNumber


                p_column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                p_column.DisplayFormat.FormatString = "#,###0." & Strings.Left(p_NumberFormat, p_Decimal)
            End If





            p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            ' p_ColumnEditName = p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).ColumnEditName.ToString.Trim
            If Me.FormEdit = False Then
                p_ColTypeButtonEdit.ReadOnly = True
            End If
            p_ColTypeButtonEdit.Appearance.BackColor = Color.LightGray
            p_ColTypeButtonEdit.Appearance.BackColor2 = Color.LightGray

            Me.TrueDBGrid1.RepositoryItems.Add(p_ColTypeButtonEdit)


            AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click


            ''''AddHandler p_ColTypeButtonEdit., AddressOf Column_Button_Click


            p_column.ColumnEdit = p_ColTypeButtonEdit
            p_column.AppearanceCell.BackColor = Color.LightGray
            p_column.AppearanceCell.BackColor2 = Color.LightGray

        End If




    End Sub

    Public Sub Column_DonGia(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_SQL As String

        If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
            If Me.MaPhuongThucBan.EditValue.ToString.Trim = "" Then
                ShowMessageBox("", "Phương thức bán chưa nhập")
                Exit Sub
            End If

            If Not New String() {"07", "08", "09", "10", "03", "05", "06"}.Contains(Me.MaPhuongThucBan.EditValue.ToString.Trim) Then
                ShowMessageBox("", "Phương thức bán không hợp lệ")
                Exit Sub
            End If
            If Me.MaPhuongThucBan.EditValue.ToString.Trim = "03" Then
                p_SQL = "select DonGia,WAERS, DATAB  from fpt_tblDonGia_v where KSCHL = 'Z001' and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat"
            End If

            If New String() {"07", "08", "09", "10"}.Contains(Me.MaPhuongThucBan.EditValue.ToString.Trim) Then
                p_SQL = "select DonGia + (Select top(1) DonGia from fpt_tblDonGia_v where KSCHL = 'Z900' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat ) as DonGia," & _
                        "WAERS, DATAB  from fpt_tblDonGia_v where KSCHL = 'Z001' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat"
            End If

            If New String() {"05", "06"}.Contains(Me.MaPhuongThucBan.EditValue.ToString.Trim) Then
                If Not Me.PriceGroup.EditValue Is Nothing Then
                    If Me.PriceGroup.EditValue.ToString.Trim = "06" Then
                        p_SQL = "select DonGia + (Select top(1) DonGia from fpt_tblDonGia_v where KSCHL = 'Z900' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and KonDa = :PriceGroup and DATAB <= :NgayXuat ) as DonGia," & _
                            "WAERS, DATAB  from fpt_tblDonGia_v where KSCHL = 'ZE01' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat"
                    Else
                        p_SQL = "select DonGia,WAERS, DATAB  from fpt_tblDonGia_v where KSCHL = 'ZE01' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat"
                    End If
                Else
                    p_SQL = "select DonGia,WAERS, DATAB  from fpt_tblDonGia_v where KSCHL = 'ZE01' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat"
                End If
            End If
        Else
            ShowMessageBox("", "Phương thức bán chưa nhập")
            Exit Sub
        End If

        p_Column1 = Me.GridView1.Columns.Item("DonGia")
        p_Column1.SQLString = p_SQL
        p_Column1.ButtonClick = True
        Me.Gridview_Column_Button_Click(sender, e)
        p_Column1.ButtonClick = False
    End Sub



    Public Sub Column_PhiVT(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_SQL As String

        Dim p_Sale_Org As String = g_Company_Code    '	Công ty-Client
        Dim p_Departure As String = ""  '  --Point	Điểm giao
        Dim p_Discharge As String = "" '   -- point	ĐIểm nhận
        Dim p_Material As String = "" '    --	Mã mặt hàng
        Dim p_SaleUnit As String = ""   '  --	Đơn vị tính dự xuất
        Dim p_LHVT As String = ""  '   -- Loại hình vận tải
        Dim p_NgayXuat As Date   ' --Ngay xuat tren lệnh
        Dim p_MaTuyenDuong As String = ""
        Dim p_Table As DataTable
        If Not Me.U_ButtonEdit3.EditValue Is Nothing Then
            If Me.U_ButtonEdit3.EditValue.ToString.Trim <> "" Then
                p_MaTuyenDuong = Me.U_ButtonEdit3.EditValue.ToString.Trim    ' Tra diem giao, diem nhan trong bang tblGiaoNhan
            End If

        End If
        If p_MaTuyenDuong = "" Then
            ShowMessageBox("", "Tuyến đường chưa nhập")
            Exit Sub
        End If
        p_SQL = "select DiemKhoiHanh, DiemDen from tblGiaoNhan  where MaTuyenDuong ='" & p_MaTuyenDuong & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_Departure = p_Table.Rows(0).Item("DiemKhoiHanh").ToString.Trim
                p_Discharge = p_Table.Rows(0).Item("DiemDen").ToString.Trim
            End If
        End If
        If p_Departure = "" Or p_Discharge = "" Then
            ShowMessageBox("", "Điểm giao hoặc điểm nhận không xác định")
            Exit Sub
        End If



        p_SQL = ""
        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_LHVT = Me.MaVanChuyen.EditValue.ToString.Trim
        End If

        If p_LHVT = "" Then
            ShowMessageBox("", "LH Vận tải chưa nhập")
            Exit Sub
        End If

        If Not Me.NgayXuat.EditValue Is Nothing Then
            p_NgayXuat = Me.NgayXuat.EditValue
        End If

        'matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat'

        p_SQL = "select KBETR, WAERS from tblDonGia_Ex with (nolock) " & _
          " where BUKRS='" & p_Sale_Org & "' " & _
              " and KSCHL  ='ZPTR' " & _
                " and KNOTA = '" & p_Departure & "' " & _
                " and OIGKNOTD = '" & p_Discharge & "' " & _
                " and  right( MATNR,7) = :Column.MaHangHoa " & _
                " and  VRKME= :Column.DonViTinh " & _
                 " and WAERS = :Column.CurrencyKey " & _
                "  and  VSART= '" & p_LHVT & "' " & _
               " and convert(date, DATAB) <=  '" & p_NgayXuat.ToString("MM-dd-yyyy") & "' " & _
                             " and convert(date, DATBI) >= '" & p_NgayXuat.ToString("MM-dd-yyyy") & "' "

        p_Column1 = Me.GridView1.Columns.Item("PhiVT")
        p_Column1.SQLString = p_SQL
        p_Column1.ButtonClick = True
        Me.Gridview_Column_Button_Click(sender, e)
        p_Column1.ButtonClick = False
    End Sub





    Public Sub Column_GiaCongTy(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_SQL As String
        Dim p_SQL2 As String
        Dim p_Sale_Org As String = g_Company_Code    '	Công ty-Client
        Dim p_DistributionChanel As String = ""  '  'Phuong thuc ban
        Dim p_Customer As String = "" '   -- Ma khach hang
        Dim p_Material As String = "" '    --	Mã mặt hàng
        Dim p_SaleUnit As String = ""   '  --	Đơn vị tính dự xuất
        ' Dim p_LHVT As String = ""  '   -- Loại hình vận tải
        Dim p_NgayXuat As Date   ' --Ngay xuat tren lệnh
        Dim p_PaymentTerm As String = ""   ' Phuong thuc thanh toan  
        Dim p_Table As DataTable
        Dim p_Exists As Boolean = False
        Dim p_LoaiTien As String
        Dim p_Row As DataRow

        Dim p_KSCHL As String = "Z001"

        p_SQL = ""

        If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
            p_DistributionChanel = Me.MaPhuongThucBan.EditValue.ToString.Trim
        End If

        If p_DistributionChanel = "" Then
            ShowMessageBox("", "Phương thức bán chưa nhập")
            Exit Sub
        End If


        If Not Me.MaKhachHang.EditValue Is Nothing Then
            p_Customer = Me.MaKhachHang.EditValue.ToString.Trim
        End If

        If p_Customer = "" Then
            ShowMessageBox("", "Khách hàng chưa nhập")
            Exit Sub
        End If


        If Not Me.Term.EditValue Is Nothing Then
            p_PaymentTerm = Me.Term.EditValue.ToString.Trim
        End If

        If p_PaymentTerm = "" Then
            ShowMessageBox("", "Thời hạn thanh toán chưa nhập")
            Exit Sub
        End If



        If Not Me.NgayXuat.EditValue Is Nothing Then
            p_NgayXuat = Me.NgayXuat.EditValue
        End If

        'matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat'

        If New String() {"05", "06"}.Contains(Me.MaPhuongThucBan.EditValue.ToString.Trim) Then
            p_KSCHL = "ZE01"
        End If

        'Me.GridView1
        If Me.GridView1.IsDataRow(Me.GridView1.FocusedRowHandle) Then
            p_Row = Me.GridView1.GetFocusedDataRow
            'and WAERS =@p_LoaiTien    CurrencyKey
            p_SQL = "select DonGia, WAERS from tbldongia  where KSCHL ='" & p_KSCHL & "'  " & _
                          " and vtweg   ='" & p_DistributionChanel & "' " & _
                          " and matnr = '" & p_Row.Item("MaHangHoa").ToString.Trim & "'  " & _
                          " and VRKME =  '" & p_Row.Item("DonViTinh").ToString.Trim & "'  " & _
                          " and  VKORG= '" & p_Sale_Org & "' " & _
                          " and  KUNNR= '" & p_Customer & "' " & _
                          " and  ZTERM= '" & p_PaymentTerm & "' " & _
                          " and  WAERS= '" & p_Row.Item("CurrencyKey").ToString.Trim & "' " & _
                          " and convert(date, DATAB) <=  '" & p_NgayXuat.ToString("MM-dd-yyyy") & "' " & _
                             " and convert(date, DATBI) >= '" & p_NgayXuat.ToString("MM-dd-yyyy") & "' "
            p_SQL = p_Parameter_Item(Me, p_SQL)
            p_Table = GetDataTable(p_SQL, p_SQL)

            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    p_Exists = True
                End If
            End If


            If p_Exists = True Then
                p_SQL = "select DonGia, WAERS from tbldongia  where KSCHL ='" & p_KSCHL & "'  " & _
                        " and vtweg   ='" & p_DistributionChanel & "' " & _
                        " and matnr = :Column.MaHangHoa  " & _
                        " and VRKME = :Column.DonViTinh " & _
                        " and  VKORG= '" & p_Sale_Org & "' " & _
                        " and  KUNNR= '" & p_Customer & "' " & _
                        " and  ZTERM= '" & p_PaymentTerm & "' " & _
                        " and WAERS = :Column.CurrencyKey " & _
                        " and convert(date, DATAB) <= '" & p_NgayXuat.ToString("MM-dd-yyyy") & "' " & _
                           " and convert(date, DATBI) >= '" & p_NgayXuat.ToString("MM-dd-yyyy") & "'"

            Else
                p_SQL = "select DonGia, WAERS from tbldongia  where KSCHL ='" & p_KSCHL & "'  " & _
                         " and vtweg   ='" & p_DistributionChanel & "' " & _
                         " and matnr = :Column.MaHangHoa  " & _
                         " and VRKME = :Column.DonViTinh " & _
                         " and  VKORG= '" & p_Sale_Org & "' " & _
                         " and   len( isnull( KUNNR,''))=0  " & _
                         " and WAERS = :Column.CurrencyKey " & _
                         " and convert(date, DATAB) <= '" & p_NgayXuat.ToString("MM-dd-yyyy") & "' " & _
                            " and convert(date, DATBI) >= '" & p_NgayXuat.ToString("MM-dd-yyyy") & "'"

            End If

            p_Column1 = Me.GridView1.Columns.Item("GiaCty")
            p_Column1.SQLString = p_SQL
            p_Column1.ButtonClick = True
            Me.Gridview_Column_Button_Click(sender, e)
            p_Column1.ButtonClick = False
        End If

    End Sub


    'Public Sub Column_ThuBVMT(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim p_Column1 As New U_TextBox.GridColumn
    '    Dim p_SQL As String

    '    Dim p_Sale_Org As String = g_Company_Code    '	Công ty-Client
    '    Dim p_Departure As String = ""  '  --Point	Điểm giao
    '    Dim p_Discharge As String = "" '   -- point	ĐIểm nhận
    '    Dim p_Material As String = "" '    --	Mã mặt hàng
    '    Dim p_SaleUnit As String = ""   '  --	Đơn vị tính dự xuất
    '    Dim p_LHVT As String = ""  '   -- Loại hình vận tải
    '    Dim p_NgayXuat As Date   ' --Ngay xuat tren lệnh
    '    Dim p_MaTuyenDuong As String = ""
    '    Dim p_Table As DataTable
    '    If Not Me.U_ButtonEdit3.EditValue Is Nothing Then
    '        If Me.U_ButtonEdit3.EditValue.ToString.Trim = "" Then
    '            p_MaTuyenDuong = Me.U_ButtonEdit3.EditValue.ToString.Trim    ' Tra diem giao, diem nhan trong bang tblGiaoNhan
    '        End If
    '    End If

    '    If p_MaTuyenDuong = "" Then
    '        ShowMessageBox("", "Tuyến đường chưa nhập")
    '        Exit Sub
    '    End If
    '    p_SQL = "select DiemKhoiHanh, DiemDen from tblGiaoNhan  where MaTuyenDuong ='" & p_MaTuyenDuong & "'"
    '    p_Table = GetDataTable(p_SQL, p_SQL)
    '    If Not p_Table Is Nothing Then
    '        If p_Table.Rows.Count > 0 Then
    '            p_Departure = p_Table.Rows(0).Item("DiemKhoiHanh").ToString.Trim
    '            p_Discharge = p_Table.Rows(0).Item("DiemDen").ToString.Trim
    '        End If
    '    End If
    '    If p_Departure = "" Or p_Discharge = "" Then
    '        ShowMessageBox("", "Điểm giao hoặc điểm nhận không xác định")
    '        Exit Sub
    '    End If



    '    p_SQL = ""
    '    If Not Me.MaVanChuyen.EditValue Is Nothing Then
    '        p_LHVT = Me.MaVanChuyen.EditValue.ToString.Trim
    '    End If

    '    If p_LHVT = "" Then
    '        ShowMessageBox("", "LH Vận tải chưa nhập")
    '        Exit Sub
    '    End If

    '    If Not Me.NgayXuat.EditValue Is Nothing Then
    '        p_NgayXuat = Me.NgayXuat.EditValue
    '    End If


    '    p_SQL = "select * from tblDonGia_Ex with (nolock) " & _
    '      " where BUKRS=@p_Sale_Org  " & _
    '          " and KSCHL  ='ZPTR' " & _
    '            " and KNOTA = '" & p_Departure & "' " & _
    '            " and OIGKNOTD = '" & p_Discharge & "' " & _
    '            " and  right( MATNR,7) = '" & p_Material & " ' " & _
    '            " and  VRKME='" & p_SaleUnit & " ' " & _
    '            "  and  VSART= '" & p_LHVT & " ' " & _
    '            "  and convert(date, DATAB) <=convert(date,'" & p_NgayXuat.ToString("MM-dd-yyyy") & "') " & _
    '            "   and convert(date, DATBI) >=convert(date,'" & p_NgayXuat.ToString("MM-dd-yyyy") & "') "
    '    p_Column1 = Me.GridView1.Columns.Item("PhiVT")
    '    p_Column1.SQLString = p_SQL
    '    p_Column1.ButtonClick = True
    '    Me.Gridview_Column_Button_Click(sender, e)
    '    p_Column1.ButtonClick = False
    'End Sub




    Public Sub Column_ThueBVMT(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_SQL As String
        Dim p_Sale_Org As String = g_Company_Code    '	Công ty-Client
        Dim p_Distribution As String = ""  '  --Phuong thuc ban
        Dim p_Material As String = "" '    --	Mã mặt hàng
        Dim p_SaleUnit As String = ""   '  --	Đơn vị tính dự xuất
        Dim p_NgayXuat As Date   ' --Ngay xuat tren lệnh





        p_SQL = ""
        If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
            p_Distribution = Me.MaPhuongThucBan.EditValue.ToString.Trim
        End If

        If p_Distribution = "" Then
            ShowMessageBox("", "Phương thức bán chưa nhập")
            Exit Sub
        End If

        If Not Me.NgayXuat.EditValue Is Nothing Then
            p_NgayXuat = Me.NgayXuat.EditValue
        End If


        'p_SQL = "select * from tblDonGia_Ex with (nolock) " & _
        '  " where BUKRS=@p_Sale_Org  " & _
        '      " and KSCHL  ='ZPTR' " & _
        '        " and KNOTA = '" & p_Departure & "' " & _
        '        " and OIGKNOTD = '" & p_Discharge & "' " & _
        '        " and  right( MATNR,7) = '" & p_Material & " ' " & _
        '        " and  VRKME='" & p_SaleUnit & " ' " & _
        '        "  and  VSART= '" & p_LHVT & " ' " & _
        '        "  and convert(date, DATAB) <=convert(date,'" & p_NgayXuat.ToString("MM-dd-yyyy") & "') " & _
        '        "   and convert(date, DATBI) >=convert(date,'" & p_NgayXuat.ToString("MM-dd-yyyy") & "') "
        p_SQL = "select DonGia, WAERS from tbldongia  where KSCHL ='Z900'  " & _
                       " and vtweg   ='" & p_Distribution & "' " & _
                       " and matnr = :Column.MaHangHoa  " & _
                       " and VRKME = :Column.DonViTinh " & _
                       " and  VKORG= '" & p_Sale_Org & "' " & _
                       " and WAERS = :Column.CurrencyKey " & _
                       " and convert(date, DATAB) <= :NgayXuat " & _
                          " and convert(date, DATBI) >= :NgayXuat"


        p_Column1 = Me.GridView1.Columns.Item("TheBVMT")
        p_Column1.SQLString = p_SQL
        p_Column1.ButtonClick = True
        Me.Gridview_Column_Button_Click(sender, e)
        p_Column1.ButtonClick = False
    End Sub






    'hieptd4 add
    Public Sub Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim p_Column1 As New U_TextBox.GridColumn

        p_Column1 = Me.GridView1.FocusedColumn
        Select Case UCase(p_Column1.FieldView)
            Case "DONGIA"
                Column_DonGia(sender, e)
            Case "GIACTY"
                Column_GiaCongTy(sender, e)
            Case "PHIVT"
                Column_PhiVT(sender, e)
            Case "THEBVMT"
                Column_ThueBVMT(sender, e)
        End Select
        'Dim p_SQL As String

        'If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
        '    If Me.MaPhuongThucBan.EditValue.ToString.Trim = "" Then
        '        ShowMessageBox("", "Phương thức bán chưa nhập")
        '        Exit Sub
        '    End If

        '    If Not New String() {"07", "08", "09", "10", "03", "05", "06"}.Contains(Me.MaPhuongThucBan.EditValue.ToString.Trim) Then
        '        ShowMessageBox("", "Phương thức bán không hợp lệ")
        '        Exit Sub
        '    End If
        '    If Me.MaPhuongThucBan.EditValue.ToString.Trim = "03" Then
        '        p_SQL = "select DonGia,WAERS, DATAB  from fpt_tblDonGia_v where KSCHL = 'Z001' and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat"
        '    End If

        '    If New String() {"07", "08", "09", "10"}.Contains(Me.MaPhuongThucBan.EditValue.ToString.Trim) Then
        '        p_SQL = "select DonGia + (Select top(1) DonGia from fpt_tblDonGia_v where KSCHL = 'Z900' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat ) as DonGia," & _
        '                "WAERS, DATAB  from fpt_tblDonGia_v where KSCHL = 'Z001' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat"
        '    End If

        '    If New String() {"05", "06"}.Contains(Me.MaPhuongThucBan.EditValue.ToString.Trim) Then
        '        If Not Me.PriceGroup.EditValue Is Nothing Then
        '            If Me.PriceGroup.EditValue.ToString.Trim = "06" Then
        '                p_SQL = "select DonGia + (Select top(1) DonGia from fpt_tblDonGia_v where KSCHL = 'Z900' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and KonDa = :PriceGroup and DATAB <= :NgayXuat ) as DonGia," & _
        '                    "WAERS, DATAB  from fpt_tblDonGia_v where KSCHL = 'ZE01' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat"
        '            Else
        '                p_SQL = "select DonGia,WAERS, DATAB  from fpt_tblDonGia_v where KSCHL = 'ZE01' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat"
        '            End If
        '        Else
        '            p_SQL = "select DonGia,WAERS, DATAB  from fpt_tblDonGia_v where KSCHL = 'ZE01' and vtweg = :MaPhuongThucBan and matnr = :Column.MaHangHoa and VRKME = :Column.DonViTinh and DATAB <= :NgayXuat"
        '        End If
        '    End If
        'Else
        '    ShowMessageBox("", "Phương thức bán chưa nhập")
        '    Exit Sub
        'End If

        'p_Column1 = Me.GridView1.Columns.Item("DonGia")
        'p_Column1.SQLString = p_SQL


        'p_Column1.ButtonClick = True

        'Me.Gridview_Column_Button_Click(sender, e)
        'p_Column1.ButtonClick = False
    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        'Dim p_Value As String = ""
        'Dim p_DuXuat As Double = 0
        'Dim p_Status As String = ""
        Dim p_Row As DataRow
        Dim p_SQL As String
        Dim p_MaPTB As String = ""
        Dim p_MaHH As String = ""
        Dim p_DVT As String = ""
        Dim p_MaKH As String = ""
        Dim p_Term As String = ""
        Dim p_PriceGroup As String = ""
        Dim p_Inco1 As String = ""
        Dim p_Inco2 As String = ""
        Dim p_NgayXuat As Date
        Dim p_DataTable As DataTable
        Dim p_DataTable22 As DataTable
        Dim p_DataTable33 As DataTable
        Dim p_SoHopDong As String
        Dim p_LoaiTien As String
        Dim p_RowCheck() As DataRow
        Dim p_DataSet As DataSet
        Dim p_MaTuyenDuong As String = ""
        Dim p_LHVT As String = ""
        Dim p_Value As Double
        Dim p_Count As Integer
        Dim p_TongDonGia As Double
        ' Dim 


        Dim p_Nguon, p_PTBan As String
        'd()
        If UCase(e.Column.FieldName) = UCase("MaHangHoa") Or UCase(e.Column.FieldName) = UCase("DonViTinh") Or UCase(e.Column.FieldName) = UCase("PhiVT") Or UCase(e.Column.FieldName) = UCase("TheBVMT") Or UCase(e.Column.FieldName) = UCase("GiaCty") Then
            If Not e.Value Is Nothing Then
                'p_Value = e.Value
                p_Row = Me.GridView1.GetFocusedDataRow
                If p_Row Is Nothing Then
                    Exit Sub
                End If

                If UCase(e.Column.FieldName) = UCase("PhiVT") Or UCase(e.Column.FieldName) = UCase("TheBVMT") Or UCase(e.Column.FieldName) = UCase("PhiVT") Or UCase(e.Column.FieldName) = UCase("GiaCty") Then
                    Double.TryParse(p_Row.Item("DonGia").ToString.Trim, p_Value)
                    p_TongDonGia = GetTongDonGia()
                    If p_TongDonGia = p_Value Then
                        Exit Sub
                    End If
                    TongDonGia()
                    Exit Sub
                End If

                'If UCase(e.Column.FieldName) = UCase("TheBVMT") Then
                '    Double.TryParse(p_Row.Item("DonGia").ToString.Trim, p_Value)
                '    p_TongDonGia = GetTongDonGia()
                'End If

                If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
                    p_MaPTB = Me.MaPhuongThucBan.EditValue.ToString.Trim()
                End If
                p_MaHH = p_Row.Item("MaHangHoa").ToString.Trim()
                p_DVT = p_Row.Item("DonViTinh").ToString.Trim()

                p_SoHopDong = ""

                If Not Me.SoHopDong.EditValue Is Nothing Then
                    p_SoHopDong = Me.SoHopDong.EditValue.ToString.Trim
                End If

                If p_SoHopDong <> "" Then
                    p_RowCheck = p_tblProject_Details.Select("Vbeln='" & p_SoHopDong & "' and  Matnr='" & p_MaHH & "'")
                    If p_RowCheck.Length > 0 Then
                        'For p_Count = 0 To p_RowCheck.Length - 1
                        '    If p_MaHH.ToString.Trim <> "" Then
                        '        If p_MaHH <> p_RowCheck(p_Count).Item("Matnr").ToString.Trim Then

                        '        End If
                        '    End If
                        'Next


                        If p_DVT.ToString.Trim <> "" Then
                            p_DVT = p_RowCheck(0).Item("Meins").ToString.Trim
                            p_Row.Item("DonViTinh") = p_DVT
                            'If p_DVT <> p_RowCheck(0).Item("Meins").ToString.Trim Then
                            '    ShowMessageBox("", "Đơn vị tính không khớp trong hợp đồng")

                            '    Exit Sub
                            'End If
                        Else
                            p_DVT = p_RowCheck(0).Item("Meins").ToString.Trim
                            p_Row.Item("DonViTinh") = p_DVT
                        End If
                    Else
                        ShowMessageBox("", "Mã hàng không khớp trong hợp đồng")
                        Exit Sub
                    End If
                End If




                If Not Me.MaKhachHang.EditValue Is Nothing Then
                    p_MaKH = Me.MaKhachHang.EditValue.ToString.Trim()
                End If
                If Not Me.Term.EditValue Is Nothing Then
                    p_Term = Me.Term.EditValue.ToString.Trim()
                End If
                If Not Me.PriceGroup.EditValue Is Nothing Then
                    p_PriceGroup = Me.PriceGroup.EditValue.ToString.Trim()
                End If
                If Not Me.Inco1.EditValue Is Nothing Then
                    p_Inco1 = Me.Inco1.EditValue.ToString.Trim()
                End If
                If Not Me.Inco2.EditValue Is Nothing Then
                    p_Inco2 = Me.Inco2.EditValue.ToString.Trim()
                End If
                If Not Me.NgayXuat.EditValue Is Nothing Then
                    p_NgayXuat = Me.NgayXuat.EditValue.ToString.Trim()
                End If


                p_Nguon = ""
                p_PTBan = ""
                If Not Me.MaNguon.EditValue Is Nothing Then
                    p_Nguon = Me.MaNguon.EditValue.ToString.Trim()
                End If

                If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
                    p_PTBan = Me.MaPhuongThucBan.EditValue.ToString.Trim()
                End If

                If (p_Nguon = "N30" Or p_Nguon = "N05") And (p_PTBan = "06" Or p_PTBan = "06") Then

                End If


                '               FPT_LayGiaCongTy()
                '@p_SaleOrg nvarchar(50), --	Công ty-Client
                '@p_DistributionChanel nvarchar(50), --	Phương thức bán
                '@p_Customer nvarchar(50)    ,   --- Khach hang	
                '@p_Material nvarchar(50),   --	Mã mặt hàng
                '@p_SaleUnit nvarchar(50),  --	Đơn vị tính dự xuất	
                '@p_PaymentTerm nvarchar(50),  --	Phương thức thanh toán	
                '@p_NgayXuat datetime  --Ngay xuat tren lệnh

                p_LoaiTien = ""
                Select Case p_PTBan
                    Case "05", "06"
                        '  Me.GridView1.SetFocusedRowCellValue("CurrencyKey", "USD")
                        p_LoaiTien = "USD"
                    Case "07", "08", "09", "10"
                        ' Me.GridView1.SetFocusedRowCellValue("CurrencyKey", "VND")
                        p_LoaiTien = "VND"
                    Case Else
                        'If Not p_DataTable Is Nothing Then
                        '    If p_DataTable.Rows.Count > 0 Then
                        '        ' Me.GridView1.SetFocusedRowCellValue("DonGia", p_DataTable.Rows(0).Item("DonGia").ToString)
                        '        Me.GridView1.SetFocusedRowCellValue("CurrencyKey", p_DataTable.Rows(0).Item("WAERS").ToString)
                        '    End If
                        'End If
                        p_LoaiTien = "VND"
                End Select
                Me.GridView1.SetFocusedRowCellValue("CurrencyKey", p_LoaiTien)

                If Not Me.MaVanChuyen.EditValue Is Nothing Then
                    p_LHVT = Me.MaVanChuyen.EditValue.ToString.Trim
                End If

                If Not Me.U_ButtonEdit3.EditValue Is Nothing Then
                    p_MaTuyenDuong = Me.U_ButtonEdit3.EditValue.ToString.Trim
                End If

                p_SQL = "exec FPT_LayGiaCongTy '" & g_Company_Code & "' " & _
                            ",'" & p_PTBan & "' " & _
                            ",'" & p_MaKH & "' " & _
                            ",'" & p_MaHH & "' " & _
                            ",'" & p_DVT & "' " & _
                            ",'" & p_Term & "' " & _
                            ",'" & p_NgayXuat.ToString("yyyyMMdd") & "' " & _
                            ",'" & p_LoaiTien & "' " & _
                              ",'" & p_MaTuyenDuong & "' " & _
                                ",'" & p_LHVT & "' " & _
                            ""

                'p_SQL = "exec FPT_GetPrice '" & p_MaPTB & "','" & p_MaHH & "','" & p_DVT & "','" & p_MaKH & "','" & p_Term & _
                '        "','" & p_PriceGroup & "','" & p_Inco1 & "','" & p_Inco2 & "','" & p_NgayXuat.ToString("yyyyMMdd") & "'"
                p_DataSet = g_Services.Sys_SYS_GET_DATASet_Des(p_SQL, p_SQL)
                If p_DataSet Is Nothing Then
                    Exit Sub
                End If
                If p_DataSet.Tables.Count <= 0 Then
                    Exit Sub
                End If
                p_DataTable = p_DataSet.Tables(0)
                If p_DataTable.Rows.Count <= 0 Then
                    p_DataTable = p_DataSet.Tables(1)
                End If

                p_DataTable22 = p_DataSet.Tables(2)
                p_DataTable33 = p_DataSet.Tables(3)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        Me.GridView1.SetFocusedRowCellValue("GiaCty", p_DataTable.Rows(0).Item("DonGia").ToString)
                        If p_DataTable22.Rows.Count > 0 Then

                            'Me.GridView1.set
                            Me.GridView1.SetFocusedRowCellValue("TheBVMT", p_DataTable22.Rows(0).Item("DonGia").ToString)
                        End If

                        If p_DataTable33.Rows.Count > 0 Then
                            'Me.GridView1.set
                            Me.GridView1.SetFocusedRowCellValue("PhiVT", p_DataTable33.Rows(0).Item("KBETR").ToString)
                        End If



                        ' Me.GridView1.SetFocusedRowCellValue("CurrencyKey", p_DataTable.Rows(0).Item("WAERS").ToString)
                    End If
                End If


                'If p_Value.ToString.Trim = "" Then
                '    Me.GridView1.SetFocusedRowCellValue("SoLuongDuXuat", 0)
                '    Me.GridView1.SetFocusedRowCellValue("TenHangHoa", "")
                '    Me.GridView1.SetFocusedRowCellValue("SoLenh", "")
                'Else
                '    Try
                '        p_DuXuat = Me.GridView1.GetFocusedRowCellValue("DungTichNgan")
                '        Me.GridView1.SetFocusedRowCellValue("SoLuongDuXuat", 0)
                '    Catch ex As Exception
                '        Me.GridView1.SetFocusedRowCellValue("SoLuongDuXuat", 0)
                '        Me.GridView1.SetFocusedRowCellValue("TenHangHoa", "")
                '        Me.GridView1.SetFocusedRowCellValue("SoLenh", "")
                '    End Try
                'End If
            End If
        End If
    End Sub


    Private Sub TongDonGia()
        Dim p_Row As DataRow
        Dim p_GiaCongTy As Double
        Dim p_GiaVT As Double
        Dim p_ThueBVMT As Double
        Dim p_DonGia As Double
        Try
            p_Row = Me.GridView1.GetFocusedDataRow
            Double.TryParse(p_Row.Item("GiaCty").ToString.Trim, p_GiaCongTy)
            Double.TryParse(p_Row.Item("PhiVT").ToString.Trim, p_GiaVT)
            Double.TryParse(p_Row.Item("TheBVMT").ToString.Trim, p_ThueBVMT)
            p_DonGia = p_GiaCongTy + p_GiaVT + p_ThueBVMT
            Me.GridView1.SetFocusedRowCellValue("DonGia", p_DonGia)

        Catch ex As Exception

        End Try


    End Sub



    Function GetTongDonGia() As Double
        Dim p_Row As DataRow
        Dim p_GiaCongTy As Double
        Dim p_GiaVT As Double
        Dim p_ThueBVMT As Double
        Dim p_DonGia As Double
        Try
            p_Row = Me.GridView1.GetFocusedDataRow
            Double.TryParse(p_Row.Item("GiaCty").ToString.Trim, p_GiaCongTy)
            Double.TryParse(p_Row.Item("PhiVT").ToString.Trim, p_GiaVT)
            Double.TryParse(p_Row.Item("TheBVMT").ToString.Trim, p_ThueBVMT)
            GetTongDonGia = p_GiaCongTy + p_GiaVT + p_ThueBVMT
            '  Me.GridView1.SetFocusedRowCellValue("DonGia", p_DonGia)

        Catch ex As Exception
            GetTongDonGia = 0
        End Try

    End Function

    'end hieptd4 add

    Sub ProcessKeyDown(ByVal sender As Object, ByVal e As Keys)
        Dim p_ValueTmp As String = "0000000000"
        Dim p_Value As String
        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Dim p_Status As String = "2"
        If e = Keys.Enter Then
            If Not Me.SoLenh.EditValue Is Nothing Then
                If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                    p_Value = Me.SoLenh.EditValue.ToString.Trim
                    If p_Value = "0" Then
                        If Len(p_Value.ToString.Trim) < 10 Then
                            p_Value = Mid(p_ValueTmp, 1, Len(p_ValueTmp) - Len(p_Value)) & p_Value
                        End If
                        p_SQL = "select top 1 SoLenh from tblLenhXuatE5 with (Nolock) where SoLenh='" & p_Value & "'"
                        p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                        If Not p_DataTable Is Nothing Then
                            If p_DataTable.Rows.Count > 0 Then
                                ShowMessageBox(True, "Số lệnh đã có trong hệ thống", 3)
                                Exit Sub
                            End If
                        End If
                        If p_Value <> Me.SoLenh.EditValue.ToString.Trim Then
                            Me.SoLenh.EditValue = p_Value
                            Me.MaKho.EditValue = g_WareHouse
                            Me.TenKho.EditValue = g_WareHouseName
                        End If
                    Else
                        p_Value = UCase(p_Value)
                        Me.SoLenh.EditValue = p_Value
                        p_SQL = "select top 1 SoLenh from tblLenhXuatE5 with (Nolock) where SoLenh='" & p_Value & "'"

                        If Mid(p_Value, 1, Len(g_WareHouse)) <> g_WareHouse Then
                            ShowMessageBox(True, "Số lệnh không hợp lệ", 3)
                            Exit Sub
                        End If
                        p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                        If Not p_DataTable Is Nothing Then
                            If p_DataTable.Rows.Count <= 0 Then
                                ShowMessageBox(True, "Số lệnh không hợp lệ", 3)
                                Exit Sub
                            Else
                                ' If p_DataTable.Rows.Count > 0 Then
                                'ShowStatusMessage(True, "MS90562", "Số lệnh đã có trong hệ thống", 5)
                                'Exit Sub
                                Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                Me.DefaultFormLoad = True
                                Me.Form1_Load(sender, Nothing)
                                Me.DefaultFormLoad = False

                                If Not Me.Status.EditValue Is Nothing Then
                                    p_Status = Me.Status.EditValue.ToString.Trim

                                End If
                                If p_Status <> "2" And p_Status <> "" Then
                                    Me.FormEdit = False
                                Else
                                    Me.FormEdit = True
                                End If
                                'End If
                            End If

                        End If
                    End If

                End If
            End If
        End If
    End Sub


    Private Sub SoLenh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SoLenh.KeyDown
        Dim p_ValueTmp As String = "0000000000"
        Dim p_Value As String
        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Dim p_Status As String = "2"
        If e.KeyCode = Keys.Enter Then

            ProcessKeyDown(sender, Keys.Enter)
            Exit Sub



            If Not Me.SoLenh.EditValue Is Nothing Then
                If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                    p_Value = Me.SoLenh.EditValue.ToString.Trim
                    If p_Value = "0" Then
                        If Len(p_Value.ToString.Trim) < 10 Then
                            p_Value = Mid(p_ValueTmp, 1, Len(p_ValueTmp) - Len(p_Value)) & p_Value
                        End If
                        p_SQL = "select top 1 SoLenh from tblLenhXuatE5 with (Nolock) where SoLenh='" & p_Value & "'"
                        p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                        If Not p_DataTable Is Nothing Then
                            If p_DataTable.Rows.Count > 0 Then
                                ShowMessageBox(True, "Số lệnh đã có trong hệ thống", 3)
                                Exit Sub
                            End If
                        End If
                        If p_Value <> Me.SoLenh.EditValue.ToString.Trim Then
                            Me.SoLenh.EditValue = p_Value
                            Me.MaKho.EditValue = g_WareHouse
                            Me.TenKho.EditValue = g_WareHouseName
                        End If
                    Else
                        p_Value = UCase(p_Value)
                        Me.SoLenh.EditValue = p_Value
                        p_SQL = "select top 1 SoLenh from tblLenhXuatE5 with (Nolock) where SoLenh='" & p_Value & "'"

                        If Mid(p_Value, 1, Len(g_WareHouse)) <> g_WareHouse Then
                            ShowMessageBox(True, "Số lệnh không hợp lệ", 3)
                            Exit Sub
                        End If
                        p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                        If Not p_DataTable Is Nothing Then
                            If p_DataTable.Rows.Count <= 0 Then
                                ShowMessageBox(True, "Số lệnh không hợp lệ", 3)
                                Exit Sub
                            Else
                                ' If p_DataTable.Rows.Count > 0 Then
                                'ShowStatusMessage(True, "MS90562", "Số lệnh đã có trong hệ thống", 5)
                                'Exit Sub
                                Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                Me.DefaultFormLoad = True
                                Me.Form1_Load(sender, e)
                                Me.DefaultFormLoad = False

                                If Not Me.Status.EditValue Is Nothing Then
                                    p_Status = Me.Status.EditValue.ToString.Trim

                                End If
                                If p_Status <> "2" And p_Status <> "" Then
                                    Me.FormEdit = False
                                Else
                                    Me.FormEdit = True
                                End If
                                'End If
                            End If

                        End If
                    End If

                End If
            End If
        End If
    End Sub



    Sub TinhQCI()
        Dim l_out As String()
        Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_bs_qci As New BSQci
        Dim p_Count As Integer
        Dim g_err As String
        Dim g_itemid As String
        Dim g_mahanghoa As String
        Dim g_donvitinh As String
        Dim g_tongduxuat As Integer = 0
        Dim p_DataRow As DataRow
        Dim p_TongQuyDoi As Integer = 0


        With Me.GridView1
            '.EndUpdate()
            .RefreshData()
            .UpdateCurrentRow()
            For p_Count = 0 To .RowCount - 1
                '  If .IsDataRow(p_Count) = True And .IsRowSelected(p_Count) = True Then
                p_DataRow = .GetDataRow(p_Count)
                If p_DataRow Is Nothing Then
                    Continue For
                End If
                g_itemid = "0"    'p_DataRow.Item("MaHangHoa").ToString.Trim
                g_mahanghoa = p_DataRow.Item("MaHangHoa").ToString.Trim
                g_donvitinh = p_DataRow.Item("DonViTinh").ToString.Trim
                p_TongQuyDoi = 0
                Integer.TryParse(p_DataRow.Item("TongDuXuat").ToString.Trim, g_tongduxuat)
                If p_DataRow.Item("TongDuXuat").ToString.Trim <> "" Then
                    g_tongduxuat = p_DataRow.Item("TongDuXuat").ToString.Trim
                End If

                If p_DataRow.Item("TongXuat").ToString.Trim <> "" Then
                    p_TongQuyDoi = p_DataRow.Item("TongXuat").ToString.Trim
                End If


                l_out = mdlQCI_GetDefaultTank(g_mahanghoa)

                If g_tongduxuat > 0 Then
                    l_quantity = mdlQCI_CalculateQCI_NS("", g_tongduxuat, g_donvitinh, l_out(0), l_out(1))
                    If l_quantity(0).ToString.Trim <> "" Then
                        .SetRowCellValue(p_Count, "TongXuat", l_quantity(0).ToString)
                    End If
                Else
                    l_quantity = mdlQCI_CalculateQCI_NS("", p_TongQuyDoi, "L", l_out(0), l_out(1))

                    Select Case UCase(g_donvitinh)
                        Case "L"
                            If l_quantity(0).ToString.Trim <> "" Then
                                .SetRowCellValue(p_Count, "TongDuXuat", l_quantity(0).ToString)
                            End If
                        Case "L15"
                            If l_quantity(0).ToString.Trim <> "" Then
                                .SetRowCellValue(p_Count, "TongDuXuat", l_quantity(1).ToString)
                            End If
                        Case Else
                            If l_quantity(0).ToString.Trim <> "" Then
                                .SetRowCellValue(p_Count, "TongDuXuat", l_quantity(3).ToString)
                            End If
                    End Select


                End If


                ' End If

            Next

        End With



    End Sub

    Private Sub ToolQCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQCI.Click
        TinhQCI()
    End Sub


    Sub SaveRecode()
        Dim p_DataRow As DataRow
        Dim p_mahanghoa As String
        Dim p_Datatable As DataTable
        Dim p_SQL As String = ""
        Dim p_LineIDTmp As String = "000000"
        Dim p_LineID As String = ""
        Dim p_Date As String

        Dim p_MaLenh As String
        Dim p_SoLenh As String = ""
        Dim p_SoLenh_Line As String = ""
        Dim p_MaBe As String
        Dim p_TableID As String
        Dim p_Slog As String = ""
        Dim p_Slog_Tmp As String = ""
        Dim p_Count As Integer
        Dim p_CountID As Integer


        Dim p_SoLenhTmp As String = ""
        ' Dim p_MaNguon As String = ""

        Dim p_NgayXuat As Date = Now.Date
        Dim p_NgayHetHieuLuc As Date = DateAdd(DateInterval.Day, 5, Now.Date)

        If Me.Check_Control_Required = False Then
            Exit Sub
        End If


        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If


        If Mid(p_SoLenh, 1, Len(g_WareHouse)) <> g_WareHouse And p_SoLenh <> "0000000000" Then
            ShowMessageBox("", "Số lệnh không hợp lệ", 3)
            Exit Sub
        End If


        If p_SoLenh = "" Then
            ShowMessageBox(True, "Số lệnh xuất chưa nhập", 3)
            Me.SoLenh.Focus()
            Exit Sub
        End If
        If Me.ChuyenVanChuyen.EditValue Is Nothing Then
            Me.ChuyenVanChuyen.Checked = False
        Else
            If ChuyenVanChuyen.Checked = False Then
                Me.LoaiPhieu.EditValue = "V144"
            End If
        End If

        If Not Me.NgayXuat.EditValue Is Nothing Then
            If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                p_NgayXuat = Me.NgayXuat.EditValue
            End If
        End If

        If Not Me.NgayHetHieuLuc.EditValue Is Nothing Then
            If Me.NgayHetHieuLuc.EditValue.ToString.Trim <> "" Then
                p_NgayHetHieuLuc = Me.NgayHetHieuLuc.EditValue
            End If
        End If


        If p_NgayHetHieuLuc.Date < p_NgayXuat.Date Then
            ShowMessageBox("", "Ngày hết hạn phải >= Ngày xuất")
            Exit Sub
        End If



        If p_SoLenh = "0000000000" Then

            p_SQL = "exec FPT_TaoMoiSoLenh_New"
            p_Datatable = GetDataTable(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_SoLenhTmp = p_Datatable.Rows(0).Item(0).ToString.Trim
                End If
            End If

            If p_SoLenhTmp = "" Then
                p_SQL = "exec FPT_TaoMoiSoLenh"
                p_Datatable = GetDataTable(p_SQL, p_SQL)
                If Not p_Datatable Is Nothing Then
                    If p_Datatable.Rows.Count > 0 Then
                        p_SoLenh = p_Datatable.Rows(0).Item(0).ToString.Trim
                    End If
                End If
            Else
                p_SoLenh = p_SoLenhTmp
            End If

        End If


        p_Slog = ""

        If Not Me.Slog.EditValue Is Nothing Then
            p_Slog = Me.Slog.EditValue.ToString.Trim
        End If
        ' If p_Slog.ToString.Trim = "" Then
        If Not Me.MaNguon.EditValue Is Nothing Then
            p_Slog_Tmp = Me.MaNguon.EditValue.ToString.Trim
        End If

        ' If p_Slog <> "" Then
        p_SQL = "select * from tblBatchSlog where BatchCode ='" & p_Slog_Tmp & "' and  sLogValue='" & p_Slog & "'"
        p_Slog_Tmp = ""
        p_Datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Slog_Tmp = p_Datatable.Rows(0).Item("SlogValue").ToString.Trim
                ' Me.Slog.EditValue = p_Slog
            End If
        End If
        'End If
        ' End If
        If p_Slog.ToString.Trim = "" Then
            Me.Slog.EditValue = p_Slog_Tmp

        Else
            If p_Slog_Tmp.ToString.Trim <> p_Slog.ToString.Trim Then
                ShowMessageBox("", "Sloc không hợp lệ", 3)
                Exit Sub
            End If

        End If
        Me.MaKho.EditValue = g_WareHouse

        p_Date = p_DateCreate.ToString("dd/MM/yyyy")

        Me.Status.EditValue = "2"
        Me.MaDonVi.EditValue = g_Company_Code
        p_MaLenh = FPT_GetMaLenh(p_SoLenh)
        If p_MaLenh = "0000" Then
            ShowMessageBox(True, "Mã lệnh đã có trong hệ thống", 3)
            Exit Sub
        End If



        'Me.LoaiPhieu.EditValue = g_LoaiPhieu
        Try
            p_CountID = 0

            With Me.GridView1
                '.EndUpdate()
                For p_Count = 0 To .RowCount - 1
                    If .IsDataRow(p_Count) = True Then
                        p_DataRow = .GetDataRow(p_Count)
                        If p_DataRow Is Nothing Then
                            Continue For
                        End If
                        If p_DataRow.Item("TongXuat").ToString.Trim = "" Then
                            'ShowStatusMessage(True, "MS0051", "Chưa tính QCI", 10)
                            ShowMessageBox("MS0051", "Chưa tính QCI")
                            Exit Sub
                        End If
                        p_mahanghoa = p_DataRow.Item("MaHangHoa").ToString.Trim
                        If p_mahanghoa <> "" Then
                            p_CountID = p_CountID + 1

                        End If
                        'p_MaBe = GetTankActive(p_mahanghoa, p_DateCreate)
                        'If p_MaBe.ToString.Trim <> "" Then
                        '    .SetRowCellValue(p_Count, "BeXuat", p_MaBe)
                        'End If

                        If p_DataRow.Item("SoLenh").ToString.Trim = "" Or p_DataRow.Item("SoLenh").ToString.Trim <> p_SoLenh Then
                            .SetRowCellValue(p_Count, "SoLenh", p_SoLenh)
                        End If

                        .SetRowCellValue(p_Count, "NgayXuat", p_DateCreate)
                        .SetRowCellValue(p_Count, "MaLenh", p_MaLenh)
                        .SetRowCellValue(p_Count, "CHECKUPD", "Y")

                        p_LineID = Mid(p_LineIDTmp, 1, Len(p_LineIDTmp) - Len((p_Count + 1).ToString.Trim)) & (p_Count + 1).ToString.Trim

                        If p_DataRow.Item("LineID").ToString.Trim = "" Then
                            .SetRowCellValue(p_Count, "LineID", p_LineID)
                        End If


                        If p_DataRow.Item("TableID").ToString.Trim = "" Then
                            p_TableID = GetTableID(p_mahanghoa)
                            .SetRowCellValue(p_Count, "TableID", p_TableID)
                        End If
                    End If

                Next

            End With
            If p_CountID = 0 Then
                ShowMessageBox("", "Lệnh chưa nhập hàng hóa xuất")
                Exit Sub
            End If

            Me.SoLenh.EditValue = p_SoLenh

            'p_MaLenh = SelectMaLenh(p_SQL, p_Date)
            Me.MaLenh.EditValue = p_MaLenh

            Me.DefaultWhere = "SoLenh='" & p_SoLenh & "'"
            Me.DefaultSave = True
            UpdateToDatabase(Me, Me.ButtonSave)
            Me.DefaultSave = False


            Exit Sub

            Call ToolStripButton2_Click(Me, Nothing)
            Me.SoLenh.Focus()
            Me.SoLenh.EditValue = p_SoLenh

            'SendKeys.Send("{ENTER}")
            ProcessKeyDown(Me, Keys.Enter)

            ' Me.SoLenh.SendKey()



            Me.GridView1.BestFitColumns()
        Catch ex As Exception
            p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
        End Try
    End Sub



    'anhqh 20160920
    Private Function GetTableIDKV1(ByVal p_MaVanChuyen As String, ByVal p_date As Date, ByVal p_HangHoa As String) As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_Int As Integer
        p_SQL = " exec  FPT_GetTableID_KV1_NewNew '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "','" & p_HangHoa & "'"

        GetTableIDKV1 = ""
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTableIDKV1 = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetTableIDKV1 = ""
        End Try

    End Function

    Function GetTableID(ByVal p_HangHoa As String) As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_MaVanChuyen As String = ""
        Dim p_date As Date

        'anhqh   20160623  Dac thu rieng cua KV1
        If g_KV1 = True Then
            p_date = Me.NgayXuat.EditValue
            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            'p_SQL = " exec  FPT_GetTableID_KV1_New '" & p_MaVanChuyen & "','" & CDate(p_date).ToString("yyyyMMdd") & "'"
            ' p_SQL = " exec  FPT_GetTableID_KV1_NewNew '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "','" & p_HangHoa & "'"

            If p_MaVanChuyen = "ZR" Then
                p_SQL = " exec  FPT_GetTableID_KV1_NewNew '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "','" & p_HangHoa & "'"
            Else
                p_SQL = " exec  FPT_GetTableID_KV1_New '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "'"
            End If

        Else
            p_SQL = " exec " & p_FunctionTableId
        End If


        'p_SQL = " exec " & p_FunctionTableId
        GetTableID = ""
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTableID = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetTableID = ""
        End Try

    End Function


    Private Sub ChuyenVanTai_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChuyenVanChuyen.CheckedChanged
        If Me.ChuyenVanChuyen.EditValue.ToString.Trim = Me.ChuyenVanChuyen.CheckValue Then
            Me.LoaiPhieu.Enabled = True
            If Not Me.LoaiPhieu.EditValue Is Nothing Then
                If Me.LoaiPhieu.EditValue.ToString.Trim = "V144" Then
                    Me.LoaiPhieu.EditValue = ""
                End If
            End If
        Else
            Me.LoaiPhieu.Enabled = False
            Me.LoaiPhieu.EditValue = "V144"
        End If

        PhuongThucXuat_Default()
    End Sub




    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        '   If Me.FormStatus = False Then
        Dim p_Time As Integer
        g_FormAddnew = True

        Me.FormEdit = True
        'Me.FormStatus = True
        Me.SoLenh.EditValue = ""
        Me.FormStatus = False
        Me.Navigator1.Buttons.DoClick(Me.Navigator1.Buttons.Append)
        ' FormStatus = True

        Me.FormStatus = True


        ' Me.Navigator1.Buttons.DoClick(Me.Navigator1.Buttons.Append)
        Me.SoLenh.Focus()

        p_GetDateTime(p_DateCreate, p_Time)


        Me.NgayXuat.EditValue = p_DateCreate
        Me.ChuyenVanChuyen.Checked = False
        Me.LoaiPhieu.EditValue = "V144"
        'Me.FormStatus = False
        ''
        ' End If


    End Sub

    Private Sub SoLenh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoLenh.EditValueChanged

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_Solenh As String = ""

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_Solenh = Me.SoLenh.EditValue.ToString.Trim
        End If


        ' ShowStatusMessage(True, "", "dfdfg")

        '   Me.sta()

        If Me.FormStatus = True Then
            Me.SoLenh.Focus()
            Me.GridView1.RefreshData()
            '  GridView2.SetFocusedRowModified()
            'GridView2.UpdateCurrentRow()
            'GridView2.RefreshEditor(True)
            Me.Focus()

            Me.HTTG.EditValue = "Y"
            SaveRecode()
        End If
    End Sub
    Private Sub MaPhuongTien_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaPhuongTien.EditValueChanged

    End Sub

    Private Sub MaPhuongTien_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaPhuongTien.Validated

    End Sub

    Private Sub MaPhuongTien_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MaPhuongTien.Validating
        Dim p_PhuongTien As String = ""
        Dim p_NguoiVanChuyen As String
        Dim p_Desc As String
        Dim p_Status As String = "2"

        If Me.MaPhuongTien.IsModified = False Then
            Exit Sub
        End If
        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If p_Status <> "2" And p_Status <> "" Then
            Exit Sub
        End If
        If Me.FormEdit = False Then
            Exit Sub
        End If
        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
        End If
        If p_PhuongTien = "" Then
            Exit Sub
        End If


        If KiemTraBarem_GiayToLaiXe(Me, p_PhuongTien, p_GIAYTO_XE, _
                                                 p_GIAYTO_LX, p_BAREM_XE) = False Then
            e.Cancel = True
            Exit Sub
        End If
        If getNguoiVanChuyen(p_PhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then
            ' ShowMessageBox("", p_Desc)
            e.Cancel = True
            Exit Sub
        End If
        If p_NguoiVanChuyen = "" Then
            Exit Sub
        End If
        If Me.NguoiVanChuyen.EditValue Is Nothing Then
            Me.NguoiVanChuyen.EditValue = p_NguoiVanChuyen
        Else
            If Me.NguoiVanChuyen.EditValue.ToString <> p_NguoiVanChuyen Then
                Me.NguoiVanChuyen.EditValue = p_NguoiVanChuyen
            End If
        End If


    End Sub





    Private Sub NguoiVanChuyen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NguoiVanChuyen.Validating
        Dim p_PhuongTien As String = ""
        Dim p_NguoiVanChuyen As String
        Dim p_Desc As String
        Dim p_Status As String = "2"


        If Me.NguoiVanChuyen.IsModified = False Then
            Exit Sub
        End If


        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If p_Status <> "2" And p_Status <> "" Then
            Exit Sub
        End If
        If Me.FormEdit = False Then
            Exit Sub
        End If
        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
        End If
        If p_PhuongTien = "" Then
            Exit Sub
        End If

        p_NguoiVanChuyen = ""
        If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
            p_NguoiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
        End If
        If p_NguoiVanChuyen = "" Then
            Exit Sub
        End If

        If getNguoiVanChuyen(p_PhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then
            ' ShowMessageBox("", p_Desc)
            e.Cancel = True
            Exit Sub
        End If
        'If Me.NguoiVanChuyen.EditValue Is Nothing Then
        '    Me.NguoiVanChuyen.EditValue = p_NguoiVanChuyen
        'Else
        '    If Me.NguoiVanChuyen.EditValue.ToString <> p_NguoiVanChuyen Then
        '        Me.NguoiVanChuyen.EditValue = p_NguoiVanChuyen
        '    End If
        'End If


    End Sub

    Private Sub MaPhuongThucBan_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaPhuongThucBan.EditValueChanged

    End Sub

    Private Sub U_TextBox1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaPhuongThucXuat.EditValueChanged

    End Sub

    Private Sub Label37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label38.Click

    End Sub

    Private Sub MaNguon_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaNguon.EditValueChanged

    End Sub

    Private Sub MaPhuongThucBan_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MaPhuongThucBan.Validating

        If Me.MaPhuongThucBan.IsModified = False Then
            Exit Sub
        End If

        PhuongThucXuat_Default()
        'Dim p_SQL As String
        'Dim p_Row() As DataRow
        'Dim p_Table As DataTable
        'Dim p_PTBan As String = ""
        'Dim p_MaKhachHang As String = ""
        'Dim p_MaNguon As String = ""
        'Dim p_TD As String = "V144"

        'If Me.MaPhuongThucBan.IsModified = False Then
        '    Exit Sub
        'End If

        'If Not Me.MaKhachHang.EditValue Is Nothing Then
        '    p_MaKhachHang = Me.MaKhachHang.EditValue.ToString.Trim
        'End If


        'If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
        '    p_PTBan = Me.MaPhuongThucBan.EditValue.ToString.Trim
        'End If

        'If Not Me.MaNguon.EditValue Is Nothing Then
        '    p_MaNguon = Me.MaNguon.EditValue.ToString.Trim
        'End If

        'If Not Me.LoaiPhieu.EditValue Is Nothing Then
        '    p_TD = Me.LoaiPhieu.EditValue.ToString.Trim
        'End If


        'If Not g_PhuongThucXuat Is Nothing Then
        '    If g_PhuongThucXuat.Rows.Count > 0 Then
        '        If p_PTBan = "03" Then
        '            If p_TD = "V144" Then   'Khong chuyen van tai
        '                p_Row = g_PhuongThucXuat.Select("VTWEG='" & p_PTBan & "' and  ma_map='621' ")
        '                If p_Row.Length > 0 Then
        '                    Me.txtPhuongThucXuat.EditValue = p_Row(0).Item("TenPhuongThucXuat").ToString.Trim

        '                    Me.MaPhuongThucXuat.EditValue = p_Row(0).Item("BWART").ToString.Trim

        '                    Me.BSART.EditValue = p_Row(0).Item("BSART").ToString.Trim

        '                    Return
        '                End If
        '            Else   'Co chuyen van tai
        '                If p_MaKhachHang = "0000106630" Then
        '                    p_Row = g_PhuongThucXuat.Select("VTWEG='" & p_PTBan & "' and  ma_map='620' ")
        '                    If p_Row.Length > 0 Then
        '                        Me.txtPhuongThucXuat.EditValue = p_Row(0).Item("TenPhuongThucXuat").ToString.Trim

        '                        Me.MaPhuongThucXuat.EditValue = p_Row(0).Item("BWART").ToString.Trim

        '                        Me.BSART.EditValue = p_Row(0).Item("BSART").ToString.Trim

        '                        Return
        '                    End If
        '                Else

        '                    p_Row = g_PhuongThucXuat.Select("VTWEG='" & p_PTBan & "' and  ma_map='610' ")
        '                    If p_Row.Length > 0 Then
        '                        Me.txtPhuongThucXuat.EditValue = p_Row(0).Item("TenPhuongThucXuat").ToString.Trim

        '                        Me.MaPhuongThucXuat.EditValue = p_Row(0).Item("BWART").ToString.Trim

        '                        Me.BSART.EditValue = p_Row(0).Item("BSART").ToString.Trim

        '                        Return
        '                    End If
        '                End If
        '            End If
        '        Else
        '            p_Row = g_PhuongThucXuat.Select("VTWEG='" & p_PTBan & "'")
        '            If p_Row.Length > 0 Then
        '                Me.txtPhuongThucXuat.EditValue = p_Row(0).Item("TenPhuongThucXuat").ToString.Trim

        '                Me.MaPhuongThucXuat.EditValue = p_Row(0).Item("BWART").ToString.Trim

        '                Me.BSART.EditValue = p_Row(0).Item("BSART").ToString.Trim

        '                Return
        '            End If
        '        End If

        '    End If

        'End If


        'p_SQL = "FPT_PhuongThucXuat_Default '" & p_PTBan & "','" & p_MaNguon & "','" & p_MaKhachHang & "'"
        'p_Table = GetDataTable(p_SQL, p_SQL)

        'If Not p_Table Is Nothing Then
        '    If p_Table.Rows.Count > 0 Then
        '        Me.txtPhuongThucXuat.EditValue = p_Table.Rows(0).Item("TenPhuongThucXuat").ToString.Trim

        '        Me.MaPhuongThucXuat.EditValue = p_Table.Rows(0).Item("BWART").ToString.Trim

        '        Me.BSART.EditValue = p_Table.Rows(0).Item("BSART").ToString.Trim

        '        ' Me.txtPhuongThucXuat.EditValue = p_Table.Rows(0).Item("TenPhuongThucXuat").ToString.Trim

        '    End If
        'End If
        ''  End If

    End Sub



    Sub PhuongThucXuat_Default()
        Dim p_SQL As String
        Dim p_Row() As DataRow
        Dim p_Table As DataTable
        Dim p_PTBan As String = ""
        Dim p_MaKhachHang As String = ""
        Dim p_MaNguon As String = ""
        Dim p_TD As String = "V144"



        If Not Me.MaKhachHang.EditValue Is Nothing Then
            p_MaKhachHang = Me.MaKhachHang.EditValue.ToString.Trim
        End If


        If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
            p_PTBan = Me.MaPhuongThucBan.EditValue.ToString.Trim
        End If

        If Not Me.MaNguon.EditValue Is Nothing Then
            p_MaNguon = Me.MaNguon.EditValue.ToString.Trim
        End If

        If Not Me.LoaiPhieu.EditValue Is Nothing Then
            p_TD = Me.LoaiPhieu.EditValue.ToString.Trim
        End If


        If Not g_PhuongThucXuat Is Nothing Then
            If g_PhuongThucXuat.Rows.Count > 0 Then
                If p_PTBan = "03" Then
                    If p_TD = "V144" Then   'Khong chuyen van tai

                        If p_MaKhachHang = "0000106630" Then
                            p_Row = g_PhuongThucXuat.Select("VTWEG='" & p_PTBan & "' and  ma_map='621' ")
                            If p_Row.Length > 0 Then
                                Me.txtPhuongThucXuat.EditValue = p_Row(0).Item("TenPhuongThucXuat").ToString.Trim

                                Me.MaPhuongThucXuat.EditValue = p_Row(0).Item("BWART").ToString.Trim
                                Me.BSART.EditValue = p_Row(0).Item("BSART").ToString.Trim

                                Return
                            End If
                        Else
                            p_Row = g_PhuongThucXuat.Select("VTWEG='" & p_PTBan & "' and  ma_map='611' ")
                            If p_Row.Length > 0 Then
                                Me.txtPhuongThucXuat.EditValue = p_Row(0).Item("TenPhuongThucXuat").ToString.Trim

                                Me.MaPhuongThucXuat.EditValue = p_Row(0).Item("BWART").ToString.Trim
                                Me.BSART.EditValue = p_Row(0).Item("BSART").ToString.Trim

                                Return
                            End If
                        End If
                    Else   'Co chuyen van tai
                        If p_MaKhachHang = "0000106630" Then
                            p_Row = g_PhuongThucXuat.Select("VTWEG='" & p_PTBan & "' and  ma_map='620' ")
                            If p_Row.Length > 0 Then
                                Me.txtPhuongThucXuat.EditValue = p_Row(0).Item("TenPhuongThucXuat").ToString.Trim

                                Me.MaPhuongThucXuat.EditValue = p_Row(0).Item("BWART").ToString.Trim

                                Me.BSART.EditValue = p_Row(0).Item("BSART").ToString.Trim

                                Return
                            End If
                        Else

                            p_Row = g_PhuongThucXuat.Select("VTWEG='" & p_PTBan & "' and  ma_map='610' ")
                            If p_Row.Length > 0 Then
                                Me.txtPhuongThucXuat.EditValue = p_Row(0).Item("TenPhuongThucXuat").ToString.Trim

                                Me.MaPhuongThucXuat.EditValue = p_Row(0).Item("BWART").ToString.Trim

                                Me.BSART.EditValue = p_Row(0).Item("BSART").ToString.Trim

                                Return
                            End If
                        End If
                    End If
                Else
                    p_Row = g_PhuongThucXuat.Select("VTWEG='" & p_PTBan & "'")
                    If p_Row.Length > 0 Then
                        Me.txtPhuongThucXuat.EditValue = p_Row(0).Item("TenPhuongThucXuat").ToString.Trim

                        Me.MaPhuongThucXuat.EditValue = p_Row(0).Item("BWART").ToString.Trim

                        Me.BSART.EditValue = p_Row(0).Item("BSART").ToString.Trim

                        Return
                    End If
                End If

            End If

        End If


        p_SQL = "FPT_PhuongThucXuat_Default '" & p_PTBan & "','" & p_MaNguon & "','" & p_MaKhachHang & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)

        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                Me.txtPhuongThucXuat.EditValue = p_Table.Rows(0).Item("TenPhuongThucXuat").ToString.Trim

                Me.MaPhuongThucXuat.EditValue = p_Table.Rows(0).Item("BWART").ToString.Trim

                Me.BSART.EditValue = p_Table.Rows(0).Item("BSART").ToString.Trim

                ' Me.txtPhuongThucXuat.EditValue = p_Table.Rows(0).Item("TenPhuongThucXuat").ToString.Trim

            End If
        End If
        '  End If

    End Sub
    ' End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim p_SoLenh As String = ""

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

        If p_SoLenh = "" Or Mid(p_SoLenh, 1, Len(g_WareHouse)) <> g_WareHouse Then
            ShowMessageBox("", "Số lệnh không hợp lệ")
            Exit Sub
        End If
        Dim FrmLenhXuatAdd As New FrmCopy
        FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
        FrmLenhXuatAdd.p_FrmSoLenh = p_SoLenh
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        FrmLenhXuatAdd.g_FormAddnew = False
        ' FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY
        FrmLenhXuatAdd.FormStatus = False
        FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
        FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.ShowDialog(Me)
    End Sub

    Private Sub GridView1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridView1.MouseMove
        Dim p_Column As U_TextBox.GridColumn
        Dim p_GridView As U_TextBox.GridView
        Dim p_String = ""
        p_GridView = CType(sender, U_TextBox.GridView)
        '  p_GridView.OptionsView
        Try
            p_Column = p_GridView.FocusedColumn
            ShowStatusMessage(False, "", p_Column.Name.ToString, 5)
            'p_Column.AppearanceHeader.

        Catch ex As Exception

        End Try


    End Sub


    'Private Sub FrmTaoMoiLenhXuat_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        Dim cmdMenu = New ContextMenuStrip
    '        Dim p_ItemMenu = cmdMenu.Items.Add("ItemInfor")
    '        p_ItemMenu.Tag = 1
    '        AddHandler p_ItemMenu.Click, AddressOf SubMenu_Click
    '    End If
    'End Sub


    Private Sub GridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        'If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
        '    Dim p_Column As U_TextBox.GridColumn
        '    Dim p_GridView As U_TextBox.GridView
        '    Dim p_Item As DevExpress.Utils.Menu.DXMenuItem

        '    If Me.ShowInfor <> "Y" Then
        '        Exit Sub
        '    End If
        '    p_GridView = CType(sender, U_TextBox.GridView)

        '    'p_Column = e.HitInfo.Column

        '    p_Item = New DevExpress.Utils.Menu.DXMenuItem
        '    p_Item.Caption = "View info"
        '    p_Item.Tag = p_GridView.GridControl.Name & "." & p_GridView.Name
        '    AddHandler p_Item.Click, AddressOf ViewInfo_Cllick
        '    e.Menu.Items.Add(p_Item)

        '    'p_Item = New DevExpress.Utils.Menu.DXMenuItem
        '    'p_Item.Caption = "Column info"
        '    'p_Item.Tag = "ColumnName: " & p_Column.Name & " - FielName: " & p_Column.FieldView
        '    'p_Column.ToolTip = p_Item.Tag


        '    'AddHandler p_Item.Click, AddressOf ViewInfo_Cllick    'ColumnInfo_Cllick
        '    'e.Menu.Items.Add(p_Item)
        'End If
    End Sub

    'Private Sub ViewInfo_Cllick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim p_Item As DevExpress.Utils.Menu.DXMenuItem
    '    Dim p_Tag As String = ""
    '    Dim p_GridView As U_TextBox.GridView
    '    Dim p_Object() As Object
    '    Dim p_TrueGrid As U_TextBox.TrueDBGrid
    '    Dim p_Name As String = ""
    '    Dim p_Column As U_TextBox.GridColumn
    '    Dim p_Int As Integer
    '    ' If Me.ShowFormMessage = True Then
    '    p_Item = CType(sender, DevExpress.Utils.Menu.DXMenuItem)
    '    p_Tag = p_Item.Tag
    '    p_Int = InStr(p_Tag, ".", CompareMethod.Text)
    '    If p_Int > 0 Then
    '        p_Name = Strings.Left(p_Tag, p_Int - 1)
    '        p_Object = Me.Controls.Find(p_Name, True)
    '        If p_Object.Length > 0 Then
    '            p_TrueGrid = CType(p_Object(0), U_TextBox.TrueDBGrid)
    '            p_GridView = p_TrueGrid.MainView
    '            For p_Int = 0 To p_GridView.Columns.Count - 1
    '                p_Column = p_GridView.Columns(p_Int)
    '                Try
    '                    If UCase(p_Column.FieldView) = UCase(p_Column.Name) Then
    '                        p_Column.ToolTip = p_GridView.ViewName & "." & p_Column.Name
    '                    Else
    '                        p_Column.ToolTip = p_GridView.ViewName & "." & p_Column.Name & "." & p_Column.FieldView
    '                    End If

    '                Catch ex As Exception

    '                End Try
    '            Next
    '            ' p_GridView 
    '        End If
    '    End If

    '    'ShowStatusMessage(False, "", p_Tag, 5)
    '    'Else
    '    'MsgBox(p_Tag)
    '    'End If

    'End Sub

End Class