Imports System.Data

Public Class Class1
    Public Sub New()
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_DAtaSet As New DataSet
        Dim p_PathXML As String
        p_PathXML = Windows.Forms.Application.StartupPath & "\Config.xml"
        If Dir(p_PathXML) <> "" Then
            p_DAtaSet.ReadXml(p_PathXML)
            If Not p_DAtaSet Is Nothing Then
                If p_DAtaSet.Tables.Count > 0 Then
                    p_Table = p_DAtaSet.Tables(0)
                End If
            End If
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    Try
                        If UCase(p_Table.Rows(0).Item("WCF").ToString.Trim) = "FALSE" Then
                            g_Wcf = False
                        End If
                    Catch ex As Exception

                    End Try
                   
                End If
            End If
        End If
    End Sub
    Function ModReadFile(ByVal FilePath As String, ByVal Position As Long, ByVal Count As Long, ByRef Exception As String) As Byte()
        ModReadFile = ModReadFile1(FilePath, Position, Count, Exception)
    End Function

    Function GetData(ByVal value As Integer) As String
        GetData = GetData1(value)
    End Function


    Function SysLogin(ByVal g_IP_Address As String, _
                                ByVal g_GetHostName As String, ByVal p_User As String, ByVal p_Pass As String, _
                                ByRef p_User_ID As Double) As String
        SysLogin = SysLogin1(g_IP_Address, _
                             g_GetHostName, p_User, p_Pass, _
                             p_User_ID)
    End Function

    ' TODO: Add your service operations here

    Function mod_SYS_GET_DATATABLE(ByVal p_SQL As String) As System.Data.DataTable
        mod_SYS_GET_DATATABLE = mod_SYS_GET_DATATABLE1(p_SQL)
    End Function

    Function SysExecuteSqlArray(ByVal p_SQLArray() As String, ByRef p_Desc As String) As Boolean
        SysExecuteSqlArray = SysExecuteSqlArray1(p_SQLArray, p_Desc)
    End Function


    Function SysExecuteDataSet(ByVal p_DataSet1 As DataSet, ByRef p_Desc As String) As Boolean
        SysExecuteDataSet = SysExecuteDataSet1(p_DataSet1, p_Desc)
    End Function


    Function SysExecuteDataSetTransaction(ByVal p_DataTable As DataSet, ByRef p_Desc As String) As Boolean
        SysExecuteDataSetTransaction = SysExecuteDataSetTransaction1(p_DataTable, p_Desc)
    End Function

    Function Sys_Execute_DataTable(ByVal p_DataTable As DataTable, _
                                          ByRef p_Desc As String) As Boolean
        Sys_Execute_DataTable = Sys_Execute_DataTable1(p_DataTable, p_Desc)
    End Function

    Function Sys_Execute_DataTbl(ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean
        Sys_Execute_DataTbl = Sys_Execute_DataTbl1(p_DataTable1, p_Desc)
    End Function

    Function Sys_Get_Menu_Submenu(ByVal p_User As Double, ByRef p_MenuSet As DataSet, _
                                  ByRef p_SubmenuSet As DataSet, ByRef p_ErrDes As String, ByVal p_DBTYPE As String) As Boolean
        Sys_Get_Menu_Submenu = Sys_Get_Menu_Submenu1(p_User, p_MenuSet, p_SubmenuSet, _
                                          p_ErrDes, p_DBTYPE)
    End Function

    Function mod_SYS_GET_DATASET(ByVal p_SQL As String) As System.Data.DataSet

        mod_SYS_GET_DATASET = mod_SYS_GET_DATASET1(p_SQL)
    End Function

    'Function p_Exampe(ByVal p_SQL As String) As String


    'Function Sys_SQL_ConnectionTest() As OleDb.OleDbConnection

    Function GetDataTable(ByVal sql As String) As DataTable
        GetDataTable = GetDataTable1(sql)
    End Function

    Function SysGetTrueGridSource(ByVal p_Module As String) As DataSet
        SysGetTrueGridSource = SysGetTrueGridSource1(p_Module)
    End Function

    Function SysGetTrueGridSourceForm(ByVal p_Module As String, ByVal p_FormName As String) As DataSet
        SysGetTrueGridSourceForm = SysGetTrueGridSourceForm1(p_Module, p_FormName)
    End Function

    Function mod_SYS_GET_DATASET_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQL As String) As System.Data.DataSet
        mod_SYS_GET_DATASET_Com = mod_SYS_GET_DATASET_Com1(p_CompanyHost, p_CompanyDB, _
                                           p_UsrB1, p_PassB1, p_Port, _
                                           p_SQL)
    End Function



    Function SysGetBidingSource(ByVal p_Module As String) As DataSet
        SysGetBidingSource = SysGetBidingSource1(p_Module)
    End Function

    Function mod_SYS_GET_DATASET_PAGE(ByVal p_SQLTotalPage As String, _
                                          ByVal p_Table As String, ByVal p_FieldKey As String, _
                                          ByRef p_Page_Total As Integer, _
                                          Optional ByVal p_Where As String = "", _
                                             Optional ByVal p_RowNum As Integer = 0, _
                                             Optional ByVal p_PageNum As Integer = 1) As System.Data.DataSet
        mod_SYS_GET_DATASET_PAGE = mod_SYS_GET_DATASET_PAGE1(p_SQLTotalPage, _
                                           p_Table, p_FieldKey, _
                                           p_Page_Total, _
                                            p_Where, _
                                               p_RowNum, _
                                               p_PageNum)
    End Function

    Function mod_SYS_GET_DATATABLE_PAGE_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQLTotalPage As String, _
                                          ByVal p_Table As String, ByVal p_FieldKey As String, _
                                          ByRef p_Page_Total As Integer, _
                                          Optional ByVal p_Where As String = "", _
                                             Optional ByVal p_RowNum As Integer = 0, _
                                             Optional ByVal p_PageNum As Integer = 1) As System.Data.DataTable

        mod_SYS_GET_DATATABLE_PAGE_Com = mod_SYS_GET_DATATABLE_PAGE_Com1(p_CompanyHost, p_CompanyDB, _
                                       p_UsrB1, p_PassB1, p_Port, _
                                       p_SQLTotalPage, _
                                       p_Table, p_FieldKey, _
                                       p_Page_Total, _
                                        p_Where, _
                                          p_RowNum, _
                                         p_PageNum)
    End Function



    Function SysGetPrimary(ByVal p_TableKey As String) As Double
        SysGetPrimary = SysGetPrimary1(p_TableKey)
    End Function

    Function Sys_Execute_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQL As String, _
                                              ByRef p_Desc As String) As Boolean

        Sys_Execute_Com = Sys_Execute_Com1(p_CompanyHost, p_CompanyDB, _
                                           p_UsrB1, p_PassB1, p_Port, _
                                           p_SQL, _
                                               p_Desc)
    End Function

    Function Sys_Execute(ByVal p_SQL As String, _
                                          ByRef p_Desc As String) As Boolean
        Sys_Execute = Sys_Execute1(p_SQL, p_Desc)
    End Function

    Function Sys_Execute_DataTableNew(ByVal p_DataTable As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean
        Sys_Execute_DataTableNew = Sys_Execute_DataTableNew1(p_DataTable, p_Desc)
    End Function

    Function Sys_SYS_GET_DATATABLE_Des(ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As DataTable
        Sys_SYS_GET_DATATABLE_Des = p_SYS_GET_DATATABLE_Des(p_SQL, p_DesErr)
    End Function

    Function Sys_SYS_GET_DATASET_Des(ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As System.Data.DataSet
        Sys_SYS_GET_DATASET_Des = p_SYS_GET_DATASET_Des(p_SQL, p_DesErr)
    End Function

    Sub Sys_GetParameterOracle(ByRef p_DBTYPE As String)
        ModSys_GetParameterOracle(p_DBTYPE)
    End Sub


    Function SYS_HTTG_To_Scadar(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_InsertToScadar As Boolean = True) As String
        SYS_HTTG_To_Scadar = HTTG_To_Scadar(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Terminal, _
                                    p_InsertToScadar)
    End Function

    Function Sys_ScadarToHTTG(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True) As String
        Sys_ScadarToHTTG = ScadarToHTTG(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Terminal, _
                                    p_GetScadarToHTTG)
    End Function

    Function MakeFileScadar(ByVal p_Teminal As String, ByRef p_Error As String) As Boolean
        MakeFileScadar = MakeFileScadar1(p_Teminal, p_Error)

    End Function

    'Function BuildBarcode147(ByVal p_String As String) As String
    '    BuildBarcode147 = BuildBarcode147(p_String)
    'End Function

    Function GET_DATATABLE_With_Connect_Des(ByVal p_ConnectStr As String, ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As DataTable
        GET_DATATABLE_With_Connect_Des = GET_DATATABLE_With_Connect_Des1(p_ConnectStr, p_SQL, _
                                                 p_DesErr)
    End Function

    Function Execute_DataTbl_With_Connection(ByVal p_Connection As String, ByVal p_DataTable1 As System.Data.DataTable, _
                                              ByRef p_Desc As String) As Boolean
        Execute_DataTbl_With_Connection = Execute_DataTbl_With_Connection1(p_Connection, p_DataTable1, _
                                           p_Desc)
    End Function
End Class
