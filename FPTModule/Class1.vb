Imports System.Windows.Forms

Public Class Class1
    'FPtModule
    Public abc As String


    Public Function clsGet_ThoiGianDau(p_SoLenh As String) As DateTime
        clsGet_ThoiGianDau = Get_ThoiGianDau(p_SoLenh)

    End Function
    Public Sub ModErrExceptionNew(ByVal p_ErrNumber As String, Optional ByVal p_Message As String = "", Optional ByVal p_Type As Integer = 0)
        ErrException(p_ErrNumber, p_Message, True, "Ok", False, "", False, "", 0, p_Type)
    End Sub

    Public Sub ModErrException(ByVal p_ErrNumber As String, Optional ByVal p_Message As String = "", _
                               Optional ByVal p_BtnYes As Boolean = False, _
                    Optional ByVal p_TextYes As String = "", _
                    Optional ByVal p_BtnNo As Boolean = False, _
                    Optional ByVal p_TextNo As String = "", _
                    Optional ByVal p_BtnCancel As Boolean = False, _
                    Optional ByVal p_TextCancel As String = "", _
                    Optional ByVal p_DefaultButton As Integer = 0)
        ErrException(p_ErrNumber, p_Message, p_BtnYes, p_TextYes, p_BtnNo, p_TextNo, p_BtnCancel, p_TextCancel, p_DefaultButton)
    End Sub
    Public Function ShowMessage(ByVal p_form As Object, Optional ByVal p_ErrNumber As String = "", _
                    Optional ByVal p_Message As String = "", _
                    Optional ByVal p_BtnYes As Boolean = False, _
                    Optional ByVal p_TextYes As String = "", _
                    Optional ByVal p_BtnNo As Boolean = False, _
                    Optional ByVal p_TextNo As String = "", _
                    Optional ByVal p_BtnCancel As Boolean = False, _
                    Optional ByVal p_TextCancel As String = "", _
                    Optional ByVal p_DefaultButton As Integer = 0) As Windows.Forms.DialogResult
        Dim p_FormMess As New FrmShowMessage(p_ErrNumber, p_Message, p_BtnYes, p_TextYes, p_BtnNo, p_TextNo, p_BtnCancel, p_TextCancel, p_DefaultButton)
        ShowMessage = p_FormMess.ShowDialog(p_form)
    End Function

    Public Function p_Mod_SetDefautCombobox(ByRef p_Form As Object) As Boolean
        p_Mod_SetDefautCombobox = p_SetDefautCombobox(p_Form)
    End Function
    Public Function p_Mod_Get_TrueGrid_Property(ByRef p_Form As Form, _
                                            ByVal p_DataTrueGird As DataSet, _
                                            ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                                ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        p_Mod_Get_TrueGrid_Property = p_Get_TrueGrid_Property(p_Form,
                                             p_DataTrueGird,
                                             p_TrueGird,
                                                 p_GridView)
    End Function
    Public Function p_Mod_Set_TrueGrid_Property_LoadPage(ByRef p_DesError As String, _
                                                    ByVal p_SQLString As String, _
                                                    ByRef p_Form As Form, _
                                                   ByRef p_BindingSource As BindingSource, _
                                                   ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                                   ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                   ByVal p_FieldKey As String, _
                                                   ByVal p_PageNum As Integer, _
                                                   ByVal p_LineOfPage As Integer, _
                                                    ByRef p_PageTotal As Integer, _
                                                   Optional ByVal B1Get As Boolean = True, _
                                                   Optional ByVal p_LoadPage As Boolean = False) As Boolean

        p_Mod_Set_TrueGrid_Property_LoadPage = p_Set_TrueGrid_Property_LoadPage(p_DesError,
                                                     p_SQLString,
                                                     p_Form,
                                                    p_BindingSource,
                                                    p_TrueGird,
                                                    p_GridView,
                                                    p_FieldKey,
                                                    p_PageNum,
                                                    p_LineOfPage,
                                                     p_PageTotal,
                                                    B1Get,
                                                    p_LoadPage)

    End Function


    Public Function p_Mod_Set_TrueGrid_Property_LoadPageNew(ByRef p_DesError As String, _
                                                    ByVal p_SQLString As String, _
                                                    ByRef p_Form As Form, _
                                                   ByRef p_BindingSource As BindingSource, _
                                                   ByRef p_TrueGird As U_TextBox.TrueDBGrid, _
                                                   ByRef p_GridView As U_TextBox.GridView, _
                                                   ByVal p_FieldKey As String, _
                                                   ByVal p_PageNum As Integer, _
                                                   ByVal p_LineOfPage As Integer, _
                                                    ByRef p_PageTotal As Integer, _
                                                   Optional ByVal B1Get As Boolean = True, _
                                                   Optional ByVal p_LoadPage As Boolean = False) As Boolean

        p_Mod_Set_TrueGrid_Property_LoadPageNew = p_Set_TrueGrid_Property_LoadPageNew(p_DesError,
                                                     p_SQLString,
                                                     p_Form,
                                                    p_BindingSource,
                                                    p_TrueGird,
                                                    p_GridView,
                                                    p_FieldKey,
                                                    p_PageNum,
                                                    p_LineOfPage,
                                                     p_PageTotal,
                                                    B1Get,
                                                    p_LoadPage)

    End Function

    Public Function p_ModSet_Control_Required(ByRef p_Form As Object, ByRef p_Des As String) As Boolean
        p_ModSet_Control_Required = p_Set_Control_Required(p_Form, p_Des)
    End Function
    Public Function p_ModCheckApproved(ByVal p_form As Form, ByVal p_Module As String, ByVal g_DataApprove As DataTable, _
                                    ByVal p_User_ID As Double, ByVal p_UserName As String, _
                                   ByVal p_CompanyCode As String, ByVal p_CompanyName As String) As Boolean
        p_ModCheckApproved = p_CheckApproved(p_form, p_Module, g_DataApprove, _
                                     p_User_ID, p_UserName, _
                                    p_CompanyCode, p_CompanyName)
    End Function


    Public Sub p_ModSendForApproved(ByVal p_Module As String, ByVal p_Form As Form, ByVal p_User_ID As Double, ByVal p_UserName As String,
                                    ByVal p_CompanyCode As String, ByVal p_CompanyName As String)
        p_SendForApproved(p_Module, p_Form, p_User_ID, p_UserName, p_CompanyCode, p_CompanyName)
    End Sub
    Public Function p_ModSys_Get_Menu_SubmenuChildNew(ByVal p_User As Double, ByVal p_DBType As String) As DataTable
        p_ModSys_Get_Menu_SubmenuChildNew = p_Sys_Get_Menu_SubmenuChildNew(p_User, p_DBType)
    End Function



    Public Function p_ModSys_Get_Menu_SubmenuChild(ByVal p_User As Double, ByVal p_MenuParentCode As String, ByRef p_SubmenuSet As DataSet, ByVal p_DBType As String) As Boolean
        p_ModSys_Get_Menu_SubmenuChild = p_Sys_Get_Menu_SubmenuChild(p_User, p_MenuParentCode, p_SubmenuSet, p_DBType)
    End Function


    Public Function p_ModSys_Get_Menu_Submenu(ByVal p_User As Double, ByRef p_MenuSet As DataSet) As Boolean
        p_ModSys_Get_Menu_Submenu = p_Sys_Get_Menu_Submenu(p_User, p_MenuSet)
    End Function



    Public Function p_ModUpdateParentID(ByVal p_Item As U_TextBox.U_TextBox, ByVal GridView1 As DevExpress.XtraGrid.Views.Grid.GridView, _
                                   ByVal pv_TrueGirdLineAdd() As Boolean, ByRef p_Desc As String) As Boolean
        p_ModUpdateParentID = p_UpdateParentID(p_Item, GridView1, pv_TrueGirdLineAdd, p_Desc)
    End Function
    Public Function clsModImportFromExcelToGridView(ByRef p_TrueDBGrid As U_TextBox.U_TrueDBGrid, _
                                                     ByRef p_GridVew As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                     ByRef p_BidingSource As System.Windows.Forms.BindingSource, _
                                                      ByVal p_SheetName As String, _
                                                     ByRef p_TrueGirdLineAdd() As Boolean, _
                                                     ByRef p_TrueGirdLineUpd() As Boolean, _
                                                      ByRef p_TrueGirdLineDel() As String, _
                                                        ByRef p_Err As String) As Boolean


        clsModImportFromExcelToGridView = ModImportFromExcelToGridView(p_TrueDBGrid, _
                                                      p_GridVew, _
                                                      p_BidingSource, _
                                                       p_SheetName, _
                                                      p_TrueGirdLineAdd, _
                                                      p_TrueGirdLineUpd, _
                                                      p_TrueGirdLineDel, _
                                                         p_Err)
    End Function


    Public Function p_ModGridExportToExcel(ByVal p_TrueDBGrid As U_TextBox.U_TrueDBGrid, _
                                                ByRef p_Err As String) As Boolean
        p_ModGridExportToExcel = p_GridExportToExcel(p_TrueDBGrid,
                                                p_Err)
    End Function


    Public Function p_ModGridExportToExcelNew(ByVal p_TrueDBGrid As U_TextBox.TrueDBGrid, _
                                                ByRef p_Err As String) As Boolean
        p_ModGridExportToExcelNew = p_GridExportToExcelNew(p_TrueDBGrid,
                                                p_Err)
    End Function

    Public Function p_ModCheckExist_Code(ByVal p_Item As Object, _
                                      Optional ByVal p_B1Get As Boolean = False) As Boolean
        p_ModCheckExist_Code = p_CheckExist_Code(p_Item, p_B1Get)
    End Function


    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function p_mod_SYS_GET_DATATABLE(ByVal p_SQL As String) As System.Data.DataTable
        ' Dim p_Sysbatch As New SystemBatch.Class1
        p_mod_SYS_GET_DATATABLE = g_Service.SysGetDataTable(p_SQL)
    End Function

    Public Function p_ModFocus_Set_Combo_Property(ByVal p_Form As Form, _
                                   ByRef p_Item As U_TextBox.U_Combobox, _
                                   Optional ByVal b1_Get As Boolean = False) As Boolean

        p_ModFocus_Set_Combo_Property = p_Focus_Set_Combo_Property(p_Form, _
                                    p_Item, _
                                     b1_Get)
    End Function


    Public Function Parameter_Item(ByVal p_Form As Form, _
                                      ByVal p_SQL As String) As String

        Parameter_Item = p_Parameter_Item(p_Form, p_SQL)
    End Function
    Public Function p_ModControl_UpdateIfNull(ByRef p_Form As Object, _
                                              Optional ByVal p_AddNew As Boolean = False) As Boolean
        p_ModControl_UpdateIfNull = p_Control_UpdateIfNull(p_Form, p_AddNew)
    End Function
    Public Function p_ModSet_BindSource_Header(ByVal p_SetSourceItem As Boolean, ByRef p_Form As Form, _
                                      ByVal p_ViewName As String, _
                                      ByRef p_BingdingSource As BindingSource, _
                                      ByVal p_Table As String, ByVal p_FieldKey As String, _
                                        ByRef p_Page_Total As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True, _
                                     Optional ByVal p_Where As String = "", _
                                    Optional ByVal p_RowNum As Integer = 0, _
                                    Optional ByVal p_PageNum As Integer = 1) As Boolean
        p_ModSet_BindSource_Header = p_Set_BindSource_Header(p_SetSourceItem, p_Form, _
                                       p_ViewName, _
                                       p_BingdingSource, p_Table, p_FieldKey, p_Page_Total, _
                                        p_GetB1, p_Where, p_RowNum, p_PageNum)
    End Function

    'anhqh
    '14/10/2013
    'Ham thuc hien lay cac gia tri cua DataNavigator lam Source
    Public Function Set_BindSource_HeaderNew(ByVal p_DataNavigator As U_TextBox.Datanavigator,
                                               ByVal p_SetSourceItem As Boolean, _
                                                ByRef p_Form As Form, _
                                      ByRef p_BingdingSource As BindingSource, _
                                        ByRef p_Page_Total As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True, _
                                     Optional ByVal p_Where As String = "", _
                                    Optional ByVal p_PageNum As Integer = 1) As Boolean
        Set_BindSource_HeaderNew = p_Set_BindSource_HeaderNew(p_DataNavigator,
                                                p_SetSourceItem, _
                                                 p_Form, _
                                       p_BingdingSource, _
                                         p_Page_Total, _
                                        p_GetB1, _
                                       p_Where, _
                                      p_PageNum)

    End Function

    Public Function p_ModColumnEdit_Property(ByRef p_Form As Form, _
                                          ByVal p_DataTrueGird As DataSet, _
                                                ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                ByVal p_ColumnEdit As String, _
                                                ByVal p_SQL As String, _
                                                 Optional ByVal p_ListCount As Integer = 7, _
                                                Optional ByVal B1Get As Boolean = True) As Boolean
        p_ModColumnEdit_Property = p_ColumnEdit_Property(p_Form, _
                                           p_DataTrueGird, _
                                                 p_GridView, _
                                                 p_ColumnEdit, _
                                                 p_SQL, _
                                                 p_ListCount, _
                                                  B1Get)
    End Function

    'ANHQH
    '01/10/2012
    'Ham thuc hien chuyen di lieu tu Grid thanh p_TrueDBGirdToDataTable
    Public Function p_Mod_TrueDBGirdToDataTable(ByVal p_TrueDbGird As U_TextBox.U_TrueDBGrid, _
                                          ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                          ByRef p_TrueGirdLineAdd() As Boolean, _
                                          ByRef p_TrueGirdLineUpd() As Boolean, _
                                          ByRef p_TrueGirdLineDel() As String, _
                                          ByRef p_DataTable_Exe As DataTable, _
                                          Optional ByVal p_GetB1 As Boolean = False _
                                           ) As String
        p_Mod_TrueDBGirdToDataTable = p_TrueDBGirdToDataTable(p_TrueDbGird, _
                                           p_GridView, _
                                           p_TrueGirdLineAdd, _
                                           p_TrueGirdLineUpd, _
                                           p_TrueGirdLineDel, _
                                           p_DataTable_Exe, _
                                           p_GetB1)
    End Function
    Public Function p_ModTrueDBGirdToDatabase(ByVal p_TrueDbGird As U_TextBox.U_TrueDBGrid, _
                                          ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                          ByRef p_TrueGirdLineAdd() As Boolean, _
                                          ByRef p_TrueGirdLineUpd() As Boolean, _
                                          ByRef p_TrueGirdLineDel() As String, _
                                          Optional ByVal p_GetB1 As Boolean = True _
                                           ) As String
        p_ModTrueDBGirdToDatabase = p_TrueDBGirdToDatabase(p_TrueDbGird, _
                                           p_GridView, _
                                           p_TrueGirdLineAdd, _
                                           p_TrueGirdLineUpd, _
                                           p_TrueGirdLineDel, _
                                           p_GetB1)
    End Function
    Public Function p_Mod_Check_Control_Required(ByRef p_Form As Object, ByRef p_Des As String) As Boolean
        p_Mod_Check_Control_Required = p_Check_Control_Required(p_Form, p_Des)
    End Function
    Public Function p_Mod_Set_TrueGrid_Property(ByRef p_Form As Form, _
                                            ByVal p_DataTrueGird As DataSet, _
                                            ByRef p_BindingSource As BindingSource, _
                                            ByRef p_TrueGird As DevExpress.XtraGrid.GridControl, _
                                            ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                             Optional ByVal B1Get As Boolean = True, _
                                                Optional ByVal p_Requery As Boolean = False, _
                                                 Optional ByVal p_WhereExt As String = "") As Boolean

        p_Mod_Set_TrueGrid_Property = p_Set_TrueGrid_Property(p_Form, p_DataTrueGird, p_BindingSource, _
                                                                p_TrueGird, p_GridView, B1Get, p_Requery, p_WhereExt)


    End Function

    Public Function p_Mod_Set_TrueGrid_Property_Page(ByRef p_DesError As String, _
                                                 ByVal p_SQLString As String, _
                                                 ByRef p_Form As Form, _
                                                ByRef p_BindingSource As BindingSource, _
                                                ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                                ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                ByVal p_FieldKey As String, _
                                                ByVal p_PageNum As Integer, _
                                                ByVal p_LineOfPage As Integer, _
                                                Optional ByVal B1Get As Boolean = True, _
                                                Optional ByVal p_LoadPage As Boolean = False) As Boolean
        'p_DesError, _
        '    p_SQLString, _
        '    Me, _
        '    p_BindingSourceLine, _
        '    Me.U_TrueDBGrid1, _
        '    Me.GridView1, _
        '    Fpt_FieldKey, _
        '    Fpt_PageNum, _
        '    Fpt_LineOfPage, _
        '    Fpt_B1Get, _
        '    Fpt_LoadPage) As Boolean
        p_Mod_Set_TrueGrid_Property_Page = p_Set_TrueGrid_Property_Page(
                                     p_DesError, _
                                                  p_SQLString, _
                                                  p_Form, _
                                                 p_BindingSource, _
                                                 p_TrueGird, _
                                                 p_GridView, _
                                                 p_FieldKey, _
                                                 p_PageNum, _
                                                 p_LineOfPage, _
                                                  B1Get, _
                                                  p_LoadPage)
    End Function



    Public Function p_Mod_Set_SQLString_TrueGrid_Property(ByRef p_Form As Form, _
                                           ByVal p_DataTrueGird As DataSet, _
                                           ByRef p_BindingSource As BindingSource, _
                                           ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                               ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                               Optional ByVal B1Get As Boolean = True, _
                                               Optional ByVal p_Requery As Boolean = False, _
                                               Optional ByVal p_SQL As String = "") As Boolean
        p_Mod_Set_SQLString_TrueGrid_Property = p_Set_SQLString_TrueGrid_Property(p_Form, _
                                            p_DataTrueGird, _
                                            p_BindingSource, _
                                            p_TrueGird, _
                                                p_GridView, _
                                                 B1Get, _
                                                 p_Requery, _
                                              p_SQL)
    End Function

    Public Function p_Mod_Set_TrueGrid_Property_PageNew(ByRef p_DesError As String, _
                                                ByRef p_Form As Form, _
                                                ByVal p_DataTrueGird As DataSet, _
                                               ByRef p_BindingSource As BindingSource, _
                                               ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                               ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                               ByVal p_FieldKey As String, _
                                               ByVal p_PageNum As Integer, _
                                               ByVal p_LineOfPage As Integer, _
                                                ByRef p_RecordTotal As Integer, _
                                               Optional ByVal B1Get As Boolean = True, _
                                               Optional ByVal p_LoadPage As Boolean = False,
                                               Optional ByVal p_Requery As Boolean = False, _
                                               Optional ByVal p_WhereExt As String = "", _
                                               Optional ByVal p_GetPageTotal As Boolean = False, _
                                               Optional ByVal p_SQLString As String = "") As Boolean
        p_Mod_Set_TrueGrid_Property_PageNew = p_Set_TrueGrid_Property_PageNew(p_DesError, _
                                                  p_Form, _
                                                  p_DataTrueGird, _
                                                 p_BindingSource, _
                                                 p_TrueGird, _
                                                 p_GridView, _
                                                 p_FieldKey, _
                                                 p_PageNum, _
                                                 p_LineOfPage, _
                                                 p_RecordTotal, _
                                                  B1Get, _
                                                  p_LoadPage,
                                                  p_Requery, _
                                                  p_WhereExt, p_GetPageTotal, p_SQLString)
    End Function



    Public Function p_Set_Control_DataField(ByRef p_Form As Object, _
                                    ByVal p_BindingSource As Object, _
                                    ByVal p_DBDataSet As DataSet, ByVal p_TableID As Integer, _
                                    ByRef p_ComboboxObj() As Object, _
                                    ByRef p_ComboboxValue() As Object, _
                                    ByRef p_CheckBoxObj() As String, _
                                    ByRef p_CheckBoxValue() As String) As Boolean
        p_Set_Control_DataField = p_Control_DataField(p_Form, p_BindingSource, _
                                                        p_DBDataSet, p_TableID)
    End Function

    Public Function p_Mod_Get_Gird_Combo(ByVal p_SQL As String, _
                                        ByRef p_BindingSource1 As Object, _
                                        ByRef p_abc As Object, _
                                        ByVal p_DisplayMember As String, _
                                       ByVal p_ValueMember As String, _
                                        Optional ByVal p_GetB1 As Boolean = False) As Boolean
        p_Mod_Get_Gird_Combo = Mod_Get_Gird_Combo(p_SQL, p_BindingSource1, p_abc, p_DisplayMember, p_ValueMember, p_GetB1)
    End Function
    Public Function p_Mod_Get_Gird(ByVal p_SQL As String, ByRef p_BindingSource1 As Object, _
                                        ByRef p_abc As Object, _
                                        Optional ByVal p_GetB1 As Boolean = False) As Boolean
        p_Mod_Get_Gird = Mod_Get_Gird(p_SQL, p_BindingSource1, p_abc, p_GetB1)
    End Function
    Public Function p_Mod_Get_BindingSource(ByVal p_SQL As String, _
                                ByRef p_BindingSource1 As BindingSource, _
                                ByVal p_Table As String, ByVal p_FieldKey As String, _
                                ByRef p_Page_Total As Integer, _
                                Optional ByVal p_GetB1 As Boolean = False, _
                                 Optional ByVal p_Where As String = "", _
                                Optional ByVal p_RowNum As Integer = 0, _
                                Optional ByVal p_PageNum As Integer = 1) As Boolean
        p_Mod_Get_BindingSource = Mod_Get_BindingSource(p_SQL, p_BindingSource1, p_Table, p_FieldKey, p_Page_Total, p_GetB1, p_Where, p_RowNum, p_Page_Total)
    End Function

    Public Function p_Get_Table_Structure(ByVal p_TableHead As String, _
                                          ByRef p_DBDataSet As DataSet, _
                                        Optional ByVal p_GetB1 As Boolean = False) As Boolean
        p_Get_Table_Structure = p_TableStructure(p_TableHead, p_DBDataSet, p_GetB1)
    End Function

    Public Sub New(ByVal p_UserLogin As String, ByVal p_CompanyCode As String, ByVal p_Service As Object, ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                    Optional ByVal p_Company_Host As String = "", _
                    Optional ByVal p_Company_DB_Name As String = "", _
                    Optional ByVal p_CurrencyDtl As DataTable = Nothing, Optional ByVal p_Currency As String = "VND", _
                                Optional ByVal p_DBUser As String = "", Optional ByVal p_DBPass As String = "")


        p_Service.Sys_GetParameterOracle(g_DBTYPE)

        g_Company_Host = p_Company_Host
        g_Company_DB_Name = p_Company_DB_Name
        g_CurrencyDtl = p_CurrencyDtl
        g_Currency = p_Currency
        g_Service = p_Service
        g_UsrB1 = p_UsrB1
        g_PassB1 = p_PassB1
        g_Port = p_Port
        g_DBUsr = p_DBUser
        g_DBPass = p_DBPass

        g_UserName = p_UserLogin
        g_CompanyCode = p_CompanyCode
        'ANHQH
        'Ham get các thông báo hệ thống vào DataSet

        'g_ite()
    End Sub






    Public Function p_Mod_Set_BindSource(ByRef p_Form As Form, _
                                     ByVal p_Dataset_Binding As DataSet, _
                                     ByVal p_Form_Name As String, _
                                     ByRef p_BindingNavigator1 As Object, _
                                     ByRef p_BindingSource() As BindingSource, _
                                      ByRef p_Page_Total As Integer, _
                                    ByVal p_PageNum As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True) As Boolean
        p_Mod_Set_BindSource = p_Set_BindSource(p_Form, _
                                 p_Dataset_Binding, _
                                  p_Form_Name, _
                                  p_BindingNavigator1, _
                                  p_BindingSource, _
                                    p_Page_Total, _
                                    p_PageNum, _
                                  p_GetB1)
    End Function


    Public Function p_Mod_ComboboxGetValue(ByRef p_Form As System.Windows.Forms.Form, ByVal p_ComboboxObj() As String, _
                                    ByVal p_ComboboxValue() As String) As Boolean
        p_Mod_ComboboxGetValue = p_ComboboxGetValue(p_Form, p_ComboboxObj, _
                                     p_ComboboxValue)
    End Function

    Public Function p_Mod_Get_Combobox_Source(ByVal p_Module As String, _
                                          ByRef p_DataSet As DataSet) As Boolean
        p_Mod_Get_Combobox_Source = p_Get_Combobox_Source(p_Module, p_DataSet)
    End Function


    Public Function p_Mod_Combo_Source(ByRef p_Form As System.Windows.Forms.Form, _
                                        ByVal p_Rows() As DataRow, _
                                        ByRef p_BindingSource() As BindingSource) As Boolean
        p_Mod_Combo_Source = p_Set_Combo_Source(p_Form, p_Rows, p_BindingSource)
    End Function

    Public Function p_Mod_DataToDatabase(ByRef p_Form As Form, _
                                     ByVal p_Table_Name As String, _
                                    ByVal p_Insert_Type As Boolean, _
                                    Optional ByVal B1Get As Boolean = False) As Boolean
        p_Mod_DataToDatabase = p_DataToDatabase(p_Form, p_Table_Name, p_Insert_Type, B1Get)
    End Function

    'ANHQH
    '01/01/2012
    'Ham thuc hien tao cau lenh SQL roi tra ve 1 DataTable
    Public Function p_Mod_ControlToDataTable(ByRef p_Form As Form, _
                                     ByVal p_Table_Name As String, _
                                    ByVal p_Insert_Type As Boolean, _
                                    ByRef p_Table_Execute As DataTable) As Boolean

        p_Mod_ControlToDataTable = p_ControlToDataTable(p_Form, _
                                      p_Table_Name, _
                                     p_Insert_Type, _
                                     p_Table_Execute)

    End Function

    Public Function p_Mod_CheckboxGetValue(ByRef p_Form As System.Windows.Forms.Form, ByVal p_CheckboxObj() As String, _
                                    ByVal p_CheckboxValue() As String) As Boolean
        p_Mod_CheckboxGetValue = p_CheckboxGetValue(p_Form, p_CheckboxObj, p_CheckboxValue)
    End Function

    'anhqh
    Public Function p_Mod_Set_Form_Combo_Property(ByVal p_Form As Form, Optional ByVal b1_Get As Boolean = False) As Boolean
        p_Mod_Set_Form_Combo_Property = p_Set_Form_Combo_Property(p_Form, b1_Get)
    End Function


    Function p_Mod_Set_Form_Condition(ByVal p_Form As Form, ByRef p_WhereReturn As String, Optional ByVal p_FieldName As Boolean = False, _
                                            Optional ByVal p_ParentName As String = "") As Boolean
        p_Mod_Set_Form_Condition = p_Set_Form_Condition(p_Form, p_WhereReturn, p_FieldName, p_ParentName)
    End Function

    Public Function p_Mod_Set_Panel_Condition(ByVal p_Object As DevExpress.XtraEditors.PanelControl, ByRef p_WhereReturn As String, Optional ByVal p_FieldName As Boolean = False) As Boolean
        p_Mod_Set_Panel_Condition = p_Set_Panel_Condition(p_Object, p_WhereReturn, p_FieldName)
    End Function

    Public Function p_ModFilComboboxParent(ByVal p_Form As Object, ByVal p_Combobox As U_TextBox.U_Combobox, Optional ByVal p_GetB1 As Boolean = False) As Boolean
        p_ModFilComboboxParent = p_FilComboboxParent(p_Form, p_Combobox, p_GetB1)
    End Function

    Public Sub p_ModComboboxAddValue(ByRef p_Combobox As U_TextBox.U_Combobox, ByVal p_Code As String, ByVal p_Name As String)
        p_ComboboxAddValue(p_Combobox, p_Code, p_Name)
    End Sub

    Public Function p_ModGirdViewCheckRequiredBeforUpdate(ByVal p_DataSet_TrueGird As DataSet, ByVal p_FormName As String, _
                                                         ByRef p_TrueGrid As U_TextBox.U_TrueDBGrid, _
                                                         ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                         ByRef p_DescError As String, _
                                                         Optional ByVal p_CheckAllRow As Boolean = True) As Boolean
        p_ModGirdViewCheckRequiredBeforUpdate = p_GirdViewCheckRequiredBeforUpdate(p_DataSet_TrueGird, p_FormName, _
                                                          p_TrueGrid, _
                                                          p_GridView, _
                                                          p_DescError, p_CheckAllRow)
    End Function

    Public Sub p_Mod_Edit_Button_Click(ByVal p_Item As U_TextBox.U_ButtonEdit, _
                                        ByRef p_RptForm As Object, _
                                        ByRef p_Commit1 As Boolean, _
                                        ByRef p_ButtonOK As Object, _
                                        ByVal p_CaptionUpd As String, Optional ByVal p_SmallFormSearch As Boolean = False)
        p_Edit_Button_Click(p_Item, _
                                         p_RptForm, _
                                         p_Commit1, _
                                         p_ButtonOK, _
                                          p_CaptionUpd, p_SmallFormSearch)
    End Sub
    Public Sub p_ModGridview_Column_Button_Click(ByRef p_TrueGrid As U_TextBox.U_TrueDBGrid, _
                                              ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                               ByRef p_RptForm As System.Windows.Forms.Form, _
                                       ByRef p_Commit1 As Boolean, _
                                       ByRef p_ButtonOK As Object, _
                                       ByVal p_ColumnName As String, _
                                       ByVal p_DataSet_TrueGird As DataSet, _
                                        Optional ByVal p_StrSQL As String = "", _
                                        Optional ByVal p_AddNewRow As Boolean = True)

        p_Gridview_Column_Button_Click(p_TrueGrid, _
                                           p_GridView, _
                                            p_RptForm, _
                                    p_Commit1, _
                                    p_ButtonOK, _
                                    p_ColumnName, _
                                    p_DataSet_TrueGird, p_StrSQL, p_AddNewRow)
    End Sub

    Public Function p_ModCompileControlHeaderToSQL(ByVal p_DataSet_TrueGird As DataSet, _
                                                   ByVal p_RecordHist As Boolean, _
                                                   ByRef p_Form As Form, _
                                     ByVal p_Table_Name As String, _
                                        ByRef p_ControlKey As Object, _
                                        ByVal p_AutoKeyName As String, _
                                        Optional ByRef p_ControlKey1 As Object = Nothing, _
                                        Optional ByVal p_AutoKeyName1 As String = "", _
                                        Optional ByVal p_UserName As String = "") As DataTable
        p_ModCompileControlHeaderToSQL = p_CompileControlHeaderToSQL(p_DataSet_TrueGird,
                                                                     p_RecordHist, p_Form, _
                                      p_Table_Name, _
                                     p_ControlKey, p_AutoKeyName, p_ControlKey1, p_AutoKeyName1, p_UserName)

    End Function

    Public Function p_ModCompileTrueDBGirdLineToSQL(ByVal p_RecordHist As Boolean, _
                                                 ByVal p_TrueDbGird As U_TextBox.U_TrueDBGrid, _
                                          ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                          ByVal p_HeaderControlKey As Object, _
                                          ByRef p_DataTable As DataTable, _
                                           ByVal p_GetB1 As Boolean, _
                                           Optional ByVal p_UserName As String = "") As String
        p_ModCompileTrueDBGirdLineToSQL = p_CompileTrueDBGirdLineToSQL(p_RecordHist,
                                                                       p_TrueDbGird, _
                                           p_GridView, _
                                           p_HeaderControlKey, _
                                           p_DataTable, _
                                           p_GetB1,
                                           p_UserName)
    End Function

    Public Function p_ModSet_Combo_PropertyNew(ByVal p_Form As Form, _
                                     ByRef p_Item As U_TextBox.U_Combobox, _
                                     Optional ByVal b1_Get As Boolean = False) As Boolean
        p_ModSet_Combo_PropertyNew = p_Set_Combo_PropertyNew(p_Form, _
                                      p_Item, _
                                      b1_Get)
    End Function
    Public Function p_ModCompileTrueDBGirdToSQL(ByVal p_DataSet_TrueGird As DataSet, _
                                             ByVal p_Form As Object, _
                                             ByVal p_RecordHist As Boolean, _
                                             ByVal p_TrueDbGird As U_TextBox.U_TrueDBGrid, _
                                          ByVal p_GridViewIn As DevExpress.XtraGrid.Views.Grid.GridView, _
                                          ByRef p_DataTable As DataTable, _
                                           ByVal p_GetB1 As Boolean, _
                                           Optional ByVal p_ColumnCHECKUPDate As String = "", _
                                           Optional ByVal p_UserName As String = "") As String

        p_ModCompileTrueDBGirdToSQL = p_CompileTrueDBGirdToSQL(p_DataSet_TrueGird, p_Form, p_RecordHist, p_TrueDbGird,
                                          p_GridViewIn,
                                          p_DataTable,
                                           p_GetB1,
                                            p_ColumnCheckUpdate, p_UserName)
    End Function

    'anhqh
    '01/07/2014
    'Ham gan Source cho cac Item trên form
    Public Function p_Mod_Set_BindSource_ForForm(ByVal p_DataSet_TrueGird As DataSet, _
                                             ByVal p_SetSourceItem As Boolean, _
                                                ByRef p_Form As Form, _
                                      ByVal p_ViewName As String, _
                                      ByRef p_BingdingSource As BindingSource, _
                                      ByVal p_Table As String, ByVal p_FieldKey As String, _
                                        ByRef p_Page_Total As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True, _
                                     Optional ByVal p_Where As String = "", _
                                    Optional ByVal p_RowNum As Integer = 0, _
                                    Optional ByVal p_PageNum As Integer = 1) As Boolean

        p_Mod_Set_BindSource_ForForm = p_Set_BindSource_ForForm(p_DataSet_TrueGird,
                                              p_SetSourceItem,
                                                 p_Form,
                                       p_ViewName,
                                       p_BingdingSource,
                                       p_Table, p_FieldKey,
                                         p_Page_Total,
                                        p_GetB1,
                                       p_Where,
                                      p_RowNum,
                                     p_PageNum)
    End Function

    Public Function ModSetTrueGridPropertyNew(ByVal p_DataSet_TrueGird As DataSet, ByRef p_Form As Form, ByVal p_requery As Boolean) As Boolean
        ModSetTrueGridPropertyNew = SetTrueGridPropertyNew(p_DataSet_TrueGird, p_Form, p_requery)
    End Function
    'anhqh
    '01/07/2014
    'Ham kiểm tra các giá trị bắt buộc trên 1 line của Grid
    'Public Function p_ModCheckRequiredGridView(ByVal p_FormName As String, _
    '                                        ByVal p_TrueDBGridName As String, _
    '                                        ByVal p_DataSet_TrueGird As DataSet, ByVal p_DataRow As DataRow) As Boolean
    '    p_ModCheckRequiredGridView = p_CheckRequiredGridView(p_FormName,
    '                                        p_TrueDBGridName,
    '                                        p_DataSet_TrueGird,
    '                                        p_DataRow)
    'End Function

    Public Function ModSetTrueGridEditColumn(ByVal p_EditColumn As Boolean, _
                                          ByRef p_TrueDBGrid As U_TextBox.U_TrueDBGrid, _
                                          ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                          ByVal p_DataSet_TrueGird As DataSet, _
                                          ByVal p_FormName As String, Optional ByVal p_SetAllColumn As Boolean = False) As Boolean
        ModSetTrueGridEditColumn = SetTrueGridEditColumn(p_EditColumn,
                                           p_TrueDBGrid,
                                          p_GridView,
                                           p_DataSet_TrueGird,
                                           p_FormName, p_SetAllColumn)
    End Function

    Public Function ModGET_DATATABLE_Des(ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As DataTable
        ModGET_DATATABLE_Des = p_GET_DATATABLE_Des(p_SQL,
                                                 p_DesErr)
    End Function



    Public Sub ModStatusMessage(ByVal p_Error As Boolean, _
                            Optional ByVal p_ErrorNumber As String = "", _
                            Optional ByVal p_ErrorText As String = "", _
                            Optional ByVal p_TimeSeconds As Integer = 10, _
                            Optional ByRef p_MessageStatusl As System.Windows.Forms.ToolStripStatusLabel = Nothing)


        StatusMessage(p_Error, p_ErrorNumber, p_ErrorText, p_TimeSeconds, p_MessageStatusl)


    End Sub

    Public Function p_ModTrueGrid_OnlyView_Page(ByRef p_DesError As String, _
                                                 ByRef p_Form As Form, _
                                                 ByRef p_BindingSource As BindingSource, _
                                                ByRef p_TrueGird As U_TextBox.TrueDBGrid, _
                                                ByVal p_FieldKey As String, _
                                                ByVal p_PageNum As Integer, _
                                                ByVal p_LineOfPage As Integer, _
                                                ByRef p_PageTotal As Integer, _
                                                Optional ByVal B1Get As Boolean = True, _
                                                Optional ByVal p_LoadPage As Boolean = False,
                                                Optional ByVal p_Requery As Boolean = False, _
                                                Optional ByVal p_WhereExt As String = "", _
                                                Optional ByVal p_GetPageTotal As Boolean = False, _
                                                Optional ByVal p_SQLString As String = "") As Boolean
        p_ModTrueGrid_OnlyView_Page = p_TrueGrid_OnlyView_Page(p_DesError, _
                                                  p_Form, _
                                                  p_BindingSource, _
                                                 p_TrueGird, _
                                                 p_FieldKey, _
                                                 p_PageNum, _
                                                 p_LineOfPage, _
                                                 p_PageTotal, _
                                                 B1Get, _
                                               p_LoadPage, _
                                               p_Requery, _
                                                p_WhereExt, _
                                                p_GetPageTotal, _
                                                p_SQLString)
    End Function

End Class
