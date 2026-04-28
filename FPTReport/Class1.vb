Imports System.Reflection

Public Class Class1

    'Private trd As Threading.Thread

    Public Sub ViewPrintReport(ByVal p_MDIFORM As Object,
                               ByVal p_SQLReport As String,
                                ByVal p_ReportName As String
                                )
        Dim p_PrintReport As New FrmPrint
        g_Print_ReportName = p_ReportName
        g_SQLPrintReport = p_SQLReport
        p_PrintReport.ShowDialog(p_MDIFORM)
    End Sub

    Public Sub New(ByVal p_Company_Code As String, ByVal p_Services As Object, ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                  Optional ByVal p_Company_Host As String = "", _
                   Optional ByVal p_Company_DB_Name As String = "", Optional ByVal p_UserName As String = "", _
                   Optional ByVal p_LicenceHost As String = "", Optional ByVal p_DBUser As String = "", _
                   Optional ByVal p_DBPass As String = "", _
                   Optional ByVal p_ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel = Nothing, _
                   Optional ByVal p_MessageStatus As System.Windows.Forms.ToolStripStatusLabel = Nothing)

        g_Company_Host = p_Company_Host
        g_GetHostName = p_Company_DB_Name
        g_Company_DBName = p_Company_DB_Name
        g_Services = p_Services

        g_ToolStripStatus = p_ToolStripStatus
        g_UserName = p_UserName
        g_MessageStatus = p_MessageStatus



        g_UsrB1 = p_UsrB1
        g_PassB1 = p_PassB1
        g_Port = p_Port
        g_Company_Code = p_Company_Code
        g_UserName = p_UserName
        'g_LicenceHost = p_LicenceHost

        g_DBUser = p_DBUser
        g_DBPass = p_DBPass
        p_GetReport()
        'Dim p_FptMod As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, g_Company_Host, g_GetHostName)


        'p_FptMod = Nothing

    End Sub

    Public Shared Function p_CreateObjectInstance(ByVal objectName As String) As Object ' Creates and returns an instance of any object in the assembly by its type name. 
        Dim p_obj As Object
        Try
            If objectName.LastIndexOf(".") = -1 Then 'Appends the root namespace if not specified.
                objectName = [Assembly].GetCallingAssembly.GetName.Name & "." & objectName '"MnuSystem." & objectName '[Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If
            p_obj = [Assembly].GetCallingAssembly.CreateInstance(objectName)
        Catch ex As Exception

            p_obj = Nothing

        End Try

        Return p_obj
    End Function

    Public Shared Function p_CreateForm(ByVal formName As String) As Form ' Return the instance of the form by specifying its name. 
        Return DirectCast(p_CreateObjectInstance(formName), Form)
    End Function

    Public Sub P_Show_Form(ByVal p_MDIFORM As Object, ByVal p_Form_Name As String, _
                            ByVal p_User_Database1 As String, _
                            ByVal p_User_ID1 As Double, _
                                ByVal p_Company_ID1 As Integer, _
                                ByVal p_Company_Host As String)
        Dim p_Frm As Object = p_CreateForm(p_Form_Name)
        Dim p_FptMod As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        p_User_Database = p_User_Database1

        g_Company_DBName = p_User_Database1
        g_User_ID = p_User_ID1
        p_Company_ID = p_Company_ID1

        g_Company_Host = p_Company_Host




        If p_Frm Is Nothing Then
        Else
            Try
                p_Frm.p_XtraModuleObj = p_FptMod
                p_Frm.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                p_Frm.p_XtraToolTripLabel = g_ToolStripStatus
                '  p_Frm.p_UserName = g_UserName
            Catch ex As Exception

            End Try
            p_Frm.StartPosition = FormStartPosition.CenterScreen
            p_Frm.Show(p_MDIFORM)
        End If
    End Sub
End Class
