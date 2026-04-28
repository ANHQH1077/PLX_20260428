' NOTE: You can use the "Rename" command on the context menu to change the interface name "IService" in both code and config file together.
Imports System.Data
Imports Microsoft.VisualBasic.FileIO
Imports System.Web.Services
Imports System.IO
Imports System.ServiceModel
'Imports System.Data.OracleClient
Imports System.Data.OleDb
Imports VFPOLEDBLib



'Namespace Microsoft.ServiceModel.Samples
<ServiceContract()> _
Public Interface IService
    '<OperationContract()> _
    'Function CheckConnect_Oracle(ByRef p_ConnectOracle As OracleConnection, ByRef p_ConnectStr As String) As Boolean
    '<OperationContract()> _
    'Function GetCompanyAPI(ByRef p_APICom As SAPbobsCOM.Company, _
    '                                ByVal g_LicenceHost As String, _
    '                                ByVal g_Company_DBName As String, _
    '                                ByVal g_DBUser As String, _
    '                                ByVal g_DBPass As String, _
    '                                 ByVal p_AppUsername As String, _
    '                                 ByVal p_AppPassword As String, _
    '                                 ByVal p_language As Integer, _
    '                                 ByVal p_DbServerType As Integer, _
    '                                      ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function ModReadFile(ByVal FilePath As String, ByVal Position As Long, ByVal Count As Long, ByRef Exception As String) As Byte()
    <OperationContract()> _
    Function GetData(ByVal value As Integer) As String
    <OperationContract()> _
    Function SysLogin(ByVal g_IP_Address As String, _
                                ByVal g_GetHostName As String, ByVal p_User As String, ByVal p_Pass As String, _
                                ByRef p_User_ID As Double) As String
    ' TODO: Add your service operations here
    <OperationContract()> _
    Function mod_SYS_GET_DATATABLE(ByVal p_SQL As String) As DataTable

    <OperationContract()> _
    Function SysExecuteSqlArray(ByVal p_SQLArray() As String, ByRef p_Desc As String) As Boolean


    <OperationContract()> _
    Function SysExecuteDataSet(ByVal p_DataSet1 As DataSet, ByRef p_Desc As String) As Boolean

    <OperationContract()> _
    Function SysExecuteDataSetTransaction(ByVal p_DataTable As DataSet, ByRef p_Desc As String) As Boolean

    <OperationContract()> _
    Function Sys_Execute_DataTable(ByVal p_DataTable As DataTable, _
                                          ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function Sys_Execute_DataTbl(ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function Sys_Get_Menu_Submenu(ByVal p_User As Double, ByRef p_MenuSet As DataSet, _
                                  ByRef p_SubmenuSet As DataSet, ByRef p_ErrDes As String, ByVal p_DBTYPE As String) As Boolean

    <OperationContract()> _
    Function mod_SYS_GET_DATASET(ByVal p_SQL As String) As System.Data.DataSet

    <OperationContract()> _
    Function p_Exampe(ByVal p_SQL As String) As String
    <OperationContract()> _
    Function Sys_SQL_ConnectionTest() As OleDb.OleDbConnection
    <OperationContract()> _
    Function GetDataTable(ByVal sql As String) As DataTable
    <OperationContract()> _
    Function SysGetTrueGridSource(ByVal p_Module As String) As DataSet
    <OperationContract()> _
    Function SysGetTrueGridSourceForm(ByVal p_Module As String, ByVal p_FormName As String) As DataSet
    <OperationContract()> _
    Function mod_SYS_GET_DATASET_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQL As String) As System.Data.DataSet

    <OperationContract()> _
    Function mod_SYS_GET_DATATABLE_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQL As String) As System.Data.DataTable

    <OperationContract()> _
    Function Sys_Execute_DataTable_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_DataTable As DataTable, _
                                              ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function SysExecuteDataSet_Company(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                              ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                              ByVal p_DataSet As DataSet) As Boolean
    <OperationContract()> _
    Function SysGetBidingSource(ByVal p_Module As String) As DataSet
    <OperationContract()> _
    Function mod_SYS_GET_DATASET_PAGE(ByVal p_SQLTotalPage As String, _
                                          ByVal p_Table As String, ByVal p_FieldKey As String, _
                                          ByRef p_Page_Total As Integer, _
                                          Optional ByVal p_Where As String = "", _
                                             Optional ByVal p_RowNum As Integer = 0, _
                                             Optional ByVal p_PageNum As Integer = 1) As System.Data.DataSet
    <OperationContract()> _
    Function mod_SYS_GET_DATATABLE_PAGE_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQLTotalPage As String, _
                                          ByVal p_Table As String, ByVal p_FieldKey As String, _
                                          ByRef p_Page_Total As Integer, _
                                          Optional ByVal p_Where As String = "", _
                                             Optional ByVal p_RowNum As Integer = 0, _
                                             Optional ByVal p_PageNum As Integer = 1) As System.Data.DataTable

    '================================Oracle
    '<OperationContract()> _
    'Function Sys_Execute_DataTable_Oracle(ByVal p_DataTable As DataTable, _
    '                                ByRef p_Desc As String) As Boolean
    '<OperationContract()> _
    'Function mod_SYS_GET_DATASET_Oracle(ByVal p_SQL As String, ByRef p_DescErr As String) As System.Data.DataSet
    <OperationContract()> _
    Function SysLogin_Oracle(ByVal g_IP_Address As String, _
                                ByVal g_GetHostName As String, ByVal p_User As String, ByVal p_Pass As String, _
                                ByRef p_User_ID As Double) As String
    <OperationContract()> _
    Function SysGetPrimary(ByVal p_TableKey As String) As Double

    <OperationContract()> _
    Function Sys_Execute_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQL As String, _
                                              ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function Sys_Execute(ByVal p_SQL As String, _
                                          ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function Sys_Execute_DataTableNew(ByVal p_DataTable As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function Sys_SYS_GET_DATATABLE_Des(ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As DataTable
    <OperationContract()> _
    Function Sys_SYS_GET_DATASET_Des(ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As System.Data.DataSet
    <OperationContract()> _
    Sub Sys_GetParameterOracle(ByRef p_DBTYPE As String)
    
    <OperationContract()> _
    Function SYS_HTTG_To_Scadar(ByVal p_UserName As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_InsertToScadar As Boolean = True) As String
    <OperationContract()> _
    Function Sys_ScadarToHTTG(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, Optional ByVal p_E5 As Boolean = True) As String
    <OperationContract()> _
    Function MakeFileScadar(ByVal p_Teminal As String, ByRef p_Error As String) As Boolean
    '<OperationContract()> _
    'Function BuildBarcode147(ByVal p_String As String) As String
    <OperationContract()> _
    Function GET_DATATABLE_With_Connect_Des(ByVal p_ConnectStr As String, ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As DataTable
    <OperationContract()> _
    Function Execute_DataTbl_With_Connection(ByVal p_Connection As String, ByVal p_DataTable1 As System.Data.DataTable, _
                                              ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function mdlSyncMaster_SyncMaterial(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As TimeSpan, _
                                                ByRef p_DataTablExe As System.Data.DataTable, ByVal i_getall As String, _
                                                ByVal i_date As String, ByRef p_desc As String) As Boolean
    <OperationContract()> _
    Function mdlSyncMaster_SyncTank(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                           ByVal i_date As String, _
                                           ByVal i_plant As String, _
                                           ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function SynDonViTinh(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                    ByRef p_desc As String) As Boolean
    <OperationContract()> _
    Function SynPhuongThuc(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                                    ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function mdlSyncMaster_SyncVehicleDown(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getAll As String, ByVal i_date As String,
                                                    ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function SynNguonHang(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, _
                                                    ByRef p_desc As String) As Boolean
    <OperationContract()> _
    Function mdlSyncMaster_SyncTransport(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                                ByRef p_desc As String) As Boolean
    <OperationContract()> _
    Function mdlSyncMaster_SyncCustomer(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, _
                                                    ByVal i_getall As String, ByVal i_date As String,
                                                    ByRef p_desc As String) As Boolean
    <OperationContract()> _
    Function clsSyncMaster_SyncVehicleUp(ByVal i_number As String, ByVal i_tutype As String, ByVal i_dt_compartment As DataTable) As Boolean
    <OperationContract()> _
    Function mdlSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String) As Boolean
    <OperationContract()> _
    Function mdlSyncDeliveries_Httg2Sap(ByVal i_dt_Header As DataTable, ByVal i_dt_Material As DataTable, ByVal i_dt_Details As DataTable,
                                                ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function clsCheckSAPConnection(ByVal p_SapConnectionString As String, ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function clsLenhXuatAuto(ByVal p_Date As Date, ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_User_Name As String, ByVal p_Company_Code As String, _
                                        ByRef p_DataTable As System.Data.DataTable, ByVal p_Desc As String) As Boolean
    <OperationContract()> _
    Function clsQCI_CalculateQCIThuy(ByVal i_plant As String, _
                                             ByVal i_batch As String, _
                                             ByRef i_dgv_QCI As System.Data.DataTable,
                                             ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function clsTestConnectSAP(ByVal p_Connect As Boolean, ByVal p_ASHOST As String, ByVal p_SYSNR As String, ByVal p_Client As String, _
                                        ByVal p_User As String, ByVal p_Pass As String, ByRef p_Desc As String) As Boolean
    <OperationContract()> _
    Function clsSyncDeliveries_DoList(ByVal i_SapConnectionstring As String, ByVal i_date As String, _
                                             ByVal _ShPoint As String, ByVal i_TimeOut As String, ByRef o_table As DataTable, _
                                             ByRef o_err As String) As Boolean

    <OperationContract()> _
    Function kv1clsSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_Company_Code As String, ByVal p_SoLenh As String, _
                                                       ByRef p_Desc As String, ByVal p_CrDate As Date) As Boolean
    <OperationContract()> _
    Function clsGetDiemTraHang(ByVal p_ChuyenVanTai As String, ByVal p_SapConnectionString As String,
                                        ByVal p_dtVariable As DataTable, ByVal p_TimeOut As TimeSpan) As String
    <OperationContract()> _
    Function CheckClsScadarToHTTG(ByRef p_TableScadar As DataTable, _
                                        ByRef p_TableScadar_E5 As DataTable, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String
    <OperationContract()> _
    Function ClsSyncMaster_SyncVehicleDownNew(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByVal i_vehicle As String, ByRef p_Count As Integer, ByRef p_Desc As String) As Boolean



    <OperationContract()> _
    Function SYS_HTTG_To_ScadarFox(ByVal p_UserName As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_InsertToScadar As Boolean = True) As String
    '<OperationContract()> _
    'Function Sys_ScadarToHTTGFox(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
    '                               Optional ByVal p_GetScadarToHTTG As Boolean = True, Optional ByVal p_E5 As Boolean = True) As String
    <OperationContract()> _
    Sub GetPathFileFox_DB(ByRef p_FoxOut As String, ByRef p_FoxIn As String, ByRef p_FoxTemp As String)

    <OperationContract()> _
    Function ClsScadarToHTTG_Fox(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String
    <OperationContract()> _
    Function clsScadar_HuyTichKe_fox(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As String
    <OperationContract()> _
    Function clsHTTG_To_ScadarAccess(ByVal p_UserName As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                   Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_InsertToScadar As Boolean = True,
                                   Optional ByVal p_E5 As Boolean = True) As String
    <OperationContract()> _
    Function ClsScadarToHTTG_Access(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String

    <OperationContract()> _
    Function ClsSyncMaster_SyncPrice(ByRef p_DataTablExe As DataTable, ByVal i_date As String, ByRef p_desc As String) As Boolean
    <OperationContract()> _
    Function ClsSyncMaster_SyncPaymentTerm(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
    <OperationContract()> _
    Function ClsSyncMaster_SyncDischard(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
    <OperationContract()> _
    Function ClsSyncMaster_SyncRoute(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
    <OperationContract()> _
    Function ClsSyncMaster_SyncVendor(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, ByRef p_desc As String) As Boolean
      


#Region "Dong Bo"
    '<OperationContract()> _
    'Function mdlSyncMaster_SyncCustomer(ByVal _SapConnectionString As String, _
    '                                           ByVal _dtVariable As DataTable, _
    '                                           ByVal p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, ByRef p_Err As String) As Boolean
#End Region
End Interface
'End Namespace