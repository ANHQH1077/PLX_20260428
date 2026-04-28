Imports DevExpress.Utils
Imports System.Data.OleDb
Module Module1
    Public g_Company_Code As String
    'Public g_User_Database As String
    Public g_IP_Address As String
    Public g_GetHostName As String
    Public g_User_ID As Double

    Public p_Company_ID As Integer
    Public p_Company_Code As String
    Public p_Company_Name As String
    Public p_User_Database As String
    Public g_Company_Host As String
    Public g_Company_DBName As String

    Public g_UserName As String
    Public g_UsrB1 As String
    Public g_PassB1 As String
    Public g_Port As String
    Public g_Services As Object

    Public g_ReportFolder As String = "Reports"
    'Public SBO_Application As SAPbouiCOM.Application
    Public g_DatabaseName As String = ""

    Private pv_Type_Column_Char As String = "C"  'Kieu du lieu cua column
    Private pv_Type_Column_Date As String = "D"  'Kieu du lieu cua column
    Private pv_Type_Column_Number As String = "N"  'Kieu du lieu cua column

    Public g_Format_Date As String = "MM/dd/yyyy"
    Public pv_Type_Date As String = ".U_DATEEDIT"

    Public pv_Type_ChectBox As String = ".U_CHECKBOX"

    Public pv_Type_TextBox As String = ".U_TEXTBOX"
    Public pv_Type_Num As String = ".U_NUMERICEDIT"
    Public pv_Type_Combo As String = ".U_COMBOBOX"
    Public pv_Type_Button As String = ".U_BUTTONEDIT"
    Public pv_Type_Tabpage As String = "TABCONTROL"
    Public pv_Type_PanelControl As String = "PANELCONTROL"
    'PanelControl
    Public pv_Type_MemoTextBox As String = ".U_MEMMOEDIT"

    Public g_ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel

    Public pv_Back_Color As System.Drawing.Color = System.Drawing.Color.White
    Public pv_Required_Back_Color As System.Drawing.Color = System.Drawing.Color.LightGoldenrodYellow
    Public pv_Locked_Back_Color As System.Drawing.Color = System.Drawing.Color.LightCyan

    Public g_ReportParameter As New System.Data.DataTable


    Public g_Company_DB_Name As String

    Public g_Server As String

    Public g_Password As String

    Const g_RowNum As Integer = 20
    Public g_DBPortInstance As String
    Public g_DB_Name As String

    Public g_DBUser As String
    Public g_DBPass As String

    Public p_DataSet_TrueGird As New DataSet

    Public g_Print_ReportName As String = ""  'Ten bao cao in chung tu
    Public g_SQLPrintReport As String = ""  'SQL de get Datatable cho in chung tu

    Public g_CurrencyDtl As DataTable
    Public g_Currency As String = ""

    Public g_MessageStatus As System.Windows.Forms.ToolStripStatusLabel


    'Public WithEvents SBO_Application As SAPbouiCOM.Application
    Public Sub p_GetReport()
        Dim p_Count As Integer
        Dim p_Row As DataRow
        Dim p_SQl As String
        Dim p_DataTable As New System.Data.DataTable
        Dim p_DEsc As String
        ' Dim p_FptMod As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        Try

            'oCompany.

            g_ReportParameter = New System.Data.DataTable("RptPar01")
            g_ReportParameter.Columns.Add("U_Order", Type.GetType("System.Double"))

            g_ReportParameter.Columns.Add("Code", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_ParCode", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_ItmCode", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_ItmDes", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_ItmType", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_CFL", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_CFLAlias", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_SQL", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_ReQuired", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_FieldKey", Type.GetType("System.String"))

            g_ReportParameter.Columns.Add("U_VISIBLE", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_DEFAULT", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_DEFAULTSQL", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("U_SHOWLOAD", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("ParameterInput", Type.GetType("System.String"))
            g_ReportParameter.Columns.Add("ItemWidth", Type.GetType("System.Double"))
            

            p_SQl = "Exec FPT_GetReportName"
            p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQl, p_DEsc)
            If Not p_DataTable Is Nothing Then
                For p_Count = 0 To p_DataTable.Rows.Count - 1

                    p_Row = g_ReportParameter.NewRow
                    p_Row.Item("Code") = p_DataTable.Rows(p_Count).Item("Code").ToString.Trim ' p_Rs.Fields.Item("Code").Value.ToString.Trim
                    p_Row.Item("U_Order") = p_DataTable.Rows(p_Count).Item("U_Order").ToString.Trim   ' p_Rs.Fields.Item("U_Order").Value.ToString.Trim
                    p_Row.Item("U_ParCode") = p_DataTable.Rows(p_Count).Item("U_ParCode").ToString.Trim   ' p_Rs.Fields.Item("U_ParCode").Value.ToString.Trim
                    p_Row.Item("U_ItmCode") = p_DataTable.Rows(p_Count).Item("U_ItmCode").ToString.Trim   ' p_Rs.Fields.Item("U_ItmCode").Value.ToString.Trim
                    p_Row.Item("U_ItmDes") = p_DataTable.Rows(p_Count).Item("U_ItmDes").ToString.Trim   ' p_Rs.Fields.Item("U_ItmDes").Value.ToString.Trim
                    p_Row.Item("U_ItmType") = p_DataTable.Rows(p_Count).Item("U_ItmType").ToString.Trim   '  p_Rs.Fields.Item("U_ItmType").Value.ToString.Trim
                    p_Row.Item("U_CFL") = p_DataTable.Rows(p_Count).Item("U_CFL").ToString.Trim   '  p_Rs.Fields.Item("U_CFL").Value.ToString.Trim
                    p_Row.Item("U_CFLAlias") = p_DataTable.Rows(p_Count).Item("U_CFLAlias").ToString.Trim   ' p_Rs.Fields.Item("U_CFLAlias").Value.ToString.Trim
                    p_Row.Item("U_SQL") = p_DataTable.Rows(p_Count).Item("U_SQL").ToString.Trim   ' p_Rs.Fields.Item("U_SQL").Value.ToString.Trim
                    p_Row.Item("U_ReQuired") = p_DataTable.Rows(p_Count).Item("U_ReQuired").ToString.Trim   ' p_Rs.Fields.Item("U_ReQuired").Value.ToString.Trim
                    p_Row.Item("U_FieldKey") = p_DataTable.Rows(p_Count).Item("U_FieldKey").ToString.Trim

                    p_Row.Item("U_VISIBLE") = p_DataTable.Rows(p_Count).Item("U_VISIBLE").ToString.Trim
                    p_Row.Item("U_DEFAULT") = p_DataTable.Rows(p_Count).Item("U_DEFAULT").ToString.Trim
                    p_Row.Item("U_DEFAULTSQL") = p_DataTable.Rows(p_Count).Item("U_DEFAULTSQL").ToString.Trim
                    p_Row.Item("U_SHOWLOAD") = p_DataTable.Rows(p_Count).Item("U_SHOWLOAD").ToString.Trim
                    '
                    p_Row.Item("ParameterInput") = p_DataTable.Rows(p_Count).Item("ParameterInput").ToString.Trim
                    If p_DataTable.Rows(p_Count).Item("ItemWidth").ToString.Trim <> "" Then
                        p_Row.Item("ItemWidth") = p_DataTable.Rows(p_Count).Item("ItemWidth").ToString.Trim
                    Else
                        p_Row.Item("ItemWidth") = 0
                    End If
                    g_ReportParameter.Rows.Add(p_Row)


                Next

            End If


        Catch ex As Exception

        End Try
        '   p_FptMod = Nothing
    End Sub
    'Public Sub p_GetReport()
    '    Dim p_Count As Integer
    '    Dim p_Row As DataRow
    '    Dim p_SQl As String
    '    Dim p_DataTable As New System.Data.DataTable
    '    Try


    '        g_ReportParameter = New System.Data.DataTable("RptPar01")
    '        g_ReportParameter.Columns.Add("U_Order", Type.GetType("System.Double"))
    '        g_ReportParameter.Columns.Add("Code", Type.GetType("System.String"))
    '        g_ReportParameter.Columns.Add("U_ParCode", Type.GetType("System.String"))
    '        g_ReportParameter.Columns.Add("U_ItmCode", Type.GetType("System.String"))
    '        g_ReportParameter.Columns.Add("U_ItmDes", Type.GetType("System.String"))
    '        g_ReportParameter.Columns.Add("U_ItmType", Type.GetType("System.String"))
    '        g_ReportParameter.Columns.Add("U_CFL", Type.GetType("System.String"))
    '        g_ReportParameter.Columns.Add("U_CFLAlias", Type.GetType("System.String"))
    '        g_ReportParameter.Columns.Add("U_SQL", Type.GetType("System.String"))
    '        g_ReportParameter.Columns.Add("U_ReQuired", Type.GetType("System.String"))
    '        g_ReportParameter.Columns.Add("U_FieldKey", Type.GetType("System.String"))

    '        g_ReportParameter.Columns.Add("U_VISIBLE", Type.GetType("System.String"))
    '        g_ReportParameter.Columns.Add("U_DEFAULT", Type.GetType("System.String"))
    '        'U_FieldKey
    '        'p_SQl = "SELECT a.""Code"",""U_Order"",""U_ParCode"",""U_ItmCode"",""U_ItmDes"" " & _
    '        '          ",""U_ItmType"",""U_CFL"",""U_CFLAlias"",""U_SQL"",""U_ReQuired"", a.""U_FieldKey"", " & _
    '        '          """U_VISIBLE"", a.""U_DEFAULT""" & _
    '        '      "FROM NITORI_TEST.""@FPTRPT1"" A, NITORI_TEST.""@FPTORPT"" b where A.""Code""=b.""Code"" " & _
    '        '     "and b.""U_Status""='Y' and a.""U_Status""='Y'  Order by a.""Code"", a.""U_Order"""

    '        'p_SQl = Nothing
    '        p_SQl = "Exec FPT_GetReportName"
    '        p_DataTable = mod_SYS_GET_DATATABLE(p_SQl)
    '        For p_Count = 0 To p_DataTable.Rows.Count - 1

    '            p_Row = g_ReportParameter.NewRow
    '            p_Row.Item("Code") = p_DataTable.Rows(p_Count).Item("Code").ToString.Trim ' p_Rs.Fields.Item("Code").Value.ToString.Trim
    '            p_Row.Item("U_Order") = p_DataTable.Rows(p_Count).Item("U_Order").ToString.Trim   ' p_Rs.Fields.Item("U_Order").Value.ToString.Trim
    '            p_Row.Item("U_ParCode") = p_DataTable.Rows(p_Count).Item("U_ParCode").ToString.Trim   ' p_Rs.Fields.Item("U_ParCode").Value.ToString.Trim
    '            p_Row.Item("U_ItmCode") = p_DataTable.Rows(p_Count).Item("U_ItmCode").ToString.Trim   ' p_Rs.Fields.Item("U_ItmCode").Value.ToString.Trim
    '            p_Row.Item("U_ItmDes") = p_DataTable.Rows(p_Count).Item("U_ItmDes").ToString.Trim   ' p_Rs.Fields.Item("U_ItmDes").Value.ToString.Trim
    '            p_Row.Item("U_ItmType") = p_DataTable.Rows(p_Count).Item("U_ItmType").ToString.Trim   '  p_Rs.Fields.Item("U_ItmType").Value.ToString.Trim
    '            p_Row.Item("U_CFL") = p_DataTable.Rows(p_Count).Item("U_CFL").ToString.Trim   '  p_Rs.Fields.Item("U_CFL").Value.ToString.Trim
    '            p_Row.Item("U_CFLAlias") = p_DataTable.Rows(p_Count).Item("U_CFLAlias").ToString.Trim   ' p_Rs.Fields.Item("U_CFLAlias").Value.ToString.Trim
    '            p_Row.Item("U_SQL") = p_DataTable.Rows(p_Count).Item("U_SQL").ToString.Trim   ' p_Rs.Fields.Item("U_SQL").Value.ToString.Trim
    '            p_Row.Item("U_ReQuired") = p_DataTable.Rows(p_Count).Item("U_ReQuired").ToString.Trim   ' p_Rs.Fields.Item("U_ReQuired").Value.ToString.Trim
    '            p_Row.Item("U_FieldKey") = p_DataTable.Rows(p_Count).Item("U_FieldKey").ToString.Trim

    '            p_Row.Item("U_VISIBLE") = p_DataTable.Rows(p_Count).Item("U_VISIBLE").ToString.Trim
    '            p_Row.Item("U_DEFAULT") = p_DataTable.Rows(p_Count).Item("U_DEFAULT").ToString.Trim
    '            '
    '            g_ReportParameter.Rows.Add(p_Row)


    '        Next




    '    Catch ex As Exception

    '    End Try
    'End Sub

    Public Sub p_ShowFormReport()
        Dim p_FormReport As New FrmReport
        'Application.DoEvents()
        p_FormReport.TopMost = True


        p_FormReport.WindowState = FormWindowState.Maximized

        p_FormReport.ShowDialog()
    End Sub


    'Public g_USer As String = "NT_DTW"
    'Public g_Pass As String = "Nitori_DTW$12345"

    'ANHQH
    '27/02/2014
    'Ham thuc Set thuoc tinh cho cac item bắt buộc nhập
    Public Function p_Set_Control_Required(ByRef p_Form As Object, ByRef p_Des As String) As Boolean

        Dim p_Object As Object
        Dim p_Object_Item As Object
        ' Dim p_Object_Value As Object

        'Dim p_ItemName As String
        ' Dim p_Rows() As DataRow
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        'Dim p_View_Name As String
        Dim p_Control_Ind As Integer
        Dim p_Value As String
        Dim p_CountObj As Integer
        Dim p_CountObj1 As Integer = Nothing

        p_Set_Control_Required = True
        p_Des = ""
        p_CountObj = 0
        Try
            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)
                'If p_Object.name = "PanelControl1" Then
                '    MsgBox("sda")
                'End If
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                      Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then

                    If p_Object.Visible = True Then
                        p_Value = p_Object.Required
                        If p_Value = "Y" Then
                            p_Object.BackColor = pv_Required_Back_Color
                        Else
                            'p_Object.BackColor = pv_Back_Color
                        End If

                    End If

                    'End If
                End If


                'Xu ly cho cac item tabpage
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    '
                    For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                        p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                        For p_Count = 0 To p_Object_Item.Controls.Count - 1
                            If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                 Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                  Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                                p_Value = p_Object_Item.Controls(p_Count).Required

                                'If p_Object_Item.Controls(p_Count).Visible = True Then
                                'p_Value = p_Object.Required
                                If p_Value = "Y" Then
                                    p_Object_Item.Controls(p_Count).BackColor = pv_Required_Back_Color
                                Else
                                    'p_Object.BackColor = pv_Back_Color
                                End If

                                'End If

                            End If

                        Next
                    Next


                End If


                'Xu ly cho cac item PanelControl
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_PanelControl, CompareMethod.Text) > 0 Then
                    '
                    'For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                    'p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                    p_Object_Item = p_Object
                    For p_Count = 0 To p_Object_Item.Controls.Count - 1
                        If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                            p_Value = p_Object_Item.Controls(p_Count).Required
                            'If p_Object_Item.Controls(p_Count).Name = "U_Nganh" Then
                            '    MsgBox("dfgdgd")
                            'End If
                            '  If p_Object_Item.Controls(p_Count).Visible = True Then
                            'p_Value = p_Object.Required
                            If p_Value = "Y" Then
                                p_Object_Item.Controls(p_Count).BackColor = pv_Required_Back_Color
                            Else
                                'p_Object.BackColor = pv_Back_Color
                            End If

                            'End If

                        End If

                    Next
                    'Next


                End If
            Next
        Catch ex As Exception
            'MsgBox("Err:" & p_Control_Ind)
            p_Set_Control_Required = False
            p_Des = ex.Message
        End Try

    End Function


    'anhqh
    '10/10/2012
    'Ham thuc hien replace cac string khai bao trong SQL thanh cac gia tri theo cac
    'Item tren form

    Public Function p_Parameter_Item(ByVal p_Form As System.Windows.Forms.Form, _
                                      ByVal p_SQL As String) As String
        Dim p_SQL_Tmp As String
        Dim p_Pos As Integer
        Dim p_SQL_Tmp1 As String
        Dim p_Parent_Item As String = ""
        Dim p_Parent_Obj As Object
        Dim p_SValue As String = ""
        Dim p_NValue As Integer = 0

        p_Parameter_Item = ""

        p_SQL_Tmp = p_SQL
        While InStr(p_SQL_Tmp, ":", CompareMethod.Text) > 0


            p_Pos = InStr(p_SQL_Tmp, ":", CompareMethod.Text)
            If p_Pos > 0 Then

                If InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) = 0 Then
                    p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos)
                Else
                    If InStr(1, Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) - p_Pos), "=", CompareMethod.Text) > 0 Then
                        p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, "=", CompareMethod.Text) - p_Pos)
                    Else
                        p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) - p_Pos)
                    End If

                End If
                ' End If


                If p_SQL_Tmp1.Length > 0 Then
                    If InStr(p_SQL_Tmp1, ",", CompareMethod.Text) > 0 Then
                        p_Parent_Item = Mid(p_SQL_Tmp1, 2, InStr(p_SQL_Tmp1, ",", CompareMethod.Text) - 2)
                    Else
                        p_Parent_Item = Mid(p_SQL_Tmp1, 2)
                    End If


                End If
                p_Parent_Obj = p_Form.Controls.Find(p_Parent_Item, True)
                If Not p_Parent_Obj Is Nothing Then
                    If Not p_Parent_Obj(0).editvalue Is Nothing Then
                        Select Case p_Parent_Obj(0).FieldType
                            Case "C"

                                p_SValue = p_Parent_Obj(0).editvalue
                                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                            Case "N"
                                If p_Parent_Obj(0).text = "" Then
                                    p_NValue = 0
                                Else
                                    p_NValue = p_Parent_Obj(0).editvalue
                                End If
                                ' p_NValue = p_Parent_Obj(0).text
                                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, p_NValue, 1)
                            Case "D"
                                p_SValue = p_Parent_Obj(0).editvalue
                                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                            Case Else
                                Exit Function

                        End Select
                    Else
                        p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                    End If
                End If

            End If
            p_SQL_Tmp = p_SQL
        End While
        p_Parameter_Item = p_SQL
    End Function

    Public Function p_Parameter_Item_Report(ByVal p_Form As System.Windows.Forms.Form, _
                                         ByVal p_SQL As String, _
                                         ByVal p_DataTable As System.Data.DataTable) As String
        Dim p_SQL_Tmp As String
        Dim p_Pos As Integer
        Dim p_SQL_Tmp1 As String
        Dim p_Parent_Item As String = ""
        Dim p_Parent_Obj As Object
        Dim p_SValue As String = ""
        Dim p_NValue As Integer = 0
        Dim p_DataRow() As System.Data.DataRow
        p_Parameter_Item_Report = ""

        p_SQL_Tmp = p_SQL
        While InStr(p_SQL_Tmp, ":", CompareMethod.Text) > 0


            p_Pos = InStr(p_SQL_Tmp, ":", CompareMethod.Text)
            If p_Pos > 0 Then

                If InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) = 0 Then
                    p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos)
                Else
                    If InStr(1, Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) - p_Pos), "=", CompareMethod.Text) > 0 Then
                        p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, "=", CompareMethod.Text) - p_Pos)
                    Else
                        p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) - p_Pos)
                    End If

                End If
                ' End If
                p_SQL_Tmp1 = p_SQL_Tmp1.Replace(")", "")
                p_SQL_Tmp1 = p_SQL_Tmp1.Replace("(", "")

                If p_SQL_Tmp1.Length > 0 Then
                    If InStr(p_SQL_Tmp1, ",", CompareMethod.Text) > 0 Then
                        p_Parent_Item = Mid(p_SQL_Tmp1, 2, InStr(p_SQL_Tmp1, ",", CompareMethod.Text) - 2)
                    Else
                        p_Parent_Item = Mid(p_SQL_Tmp1, 2)
                    End If


                End If

                p_DataRow = p_DataTable.Select("U_Order=" & p_Parent_Item)
                If Not p_DataRow Is Nothing Then
                    If p_DataRow.Length > 0 Then
                        p_Parent_Item = p_DataRow(0).Item("Parameter").ToString.Trim
                        p_Parent_Obj = p_Form.Controls.Find(p_Parent_Item, True)
                        If Not p_Parent_Obj Is Nothing Then
                            If Not p_Parent_Obj(0).editvalue Is Nothing Then
                                Select Case p_Parent_Obj(0).FieldType
                                    Case "C"

                                        p_SValue = p_Parent_Obj(0).editvalue
                                        p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                                    Case "N"
                                        If p_Parent_Obj(0).text = "" Then
                                            p_NValue = 0
                                        Else
                                            p_NValue = p_Parent_Obj(0).editvalue
                                        End If
                                        ' p_NValue = p_Parent_Obj(0).text
                                        p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, p_NValue, 1)
                                    Case "D"
                                        p_SValue = p_Parent_Obj(0).editvalue
                                        p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & CDate(p_Parent_Obj(0).editvalue).ToString("yyyyMMdd") & "'", 1)
                                    Case Else
                                        Exit Function

                                End Select
                            Else
                                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                            End If
                        End If
                    End If
                End If
            End If
            p_SQL_Tmp = p_SQL
        End While
        p_Parameter_Item_Report = p_SQL
    End Function

    'ANHQH
    '01/01/2012
    'Ham thuc hien kiem tra cac item bat buoc nhap ma khong co gia tri
    Public Function p_Check_Control_Required(ByRef p_Form As Object, ByRef p_Des As String) As Boolean

        Dim p_Object As Object
        Dim p_Object_Item As Object
        ' Dim p_Object_Value As Object

        'Dim p_ItemName As String
        ' Dim p_Rows() As DataRow
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        'Dim p_View_Name As String
        Dim p_Control_Ind As Integer
        Dim p_Value As String
        Dim p_CountObj As Integer
        Dim p_CountObj1 As Integer = Nothing

        p_Check_Control_Required = True
        p_Des = ""
        p_CountObj = 0
        Try
            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)
                'If p_Object.name = "PanelControl1" Then
                '    MsgBox("sda")
                'End If
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                      Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then

                    p_Value = p_Object.Required
                    If p_Value = "Y" Then
                        If p_Object.EditValue Is Nothing Then
                            p_Value = ""
                        Else
                            p_Value = p_Object.EditValue.ToString
                        End If

                        If p_Value Is Nothing Then
                            p_Des = "Thông tin nhập chưa đầy đủ"
                            p_Check_Control_Required = False
                            If p_Object.Visible = True Then
                                p_Object.Focus()
                                Exit Function
                            End If
                        ElseIf p_Value = "" Then
                            p_Des = "Thông tin nhập chưa đầy đủ"
                            p_Check_Control_Required = False
                            If p_Object.Visible = True Then
                                p_Object.Focus()
                                Exit Function
                            End If
                        End If
                    End If

                    'End If
                End If


                'Xu ly cho cac item tabpage
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    '
                    For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                        p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                        For p_Count = 0 To p_Object_Item.Controls.Count - 1
                            If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                 Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                  Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                                p_Value = p_Object_Item.Controls(p_Count).Required
                                If p_Value = "Y" Then
                                    If p_Object_Item.Controls(p_Count).EditValue Is Nothing Then
                                        p_Value = ""
                                    Else
                                        p_Value = p_Object_Item.Controls(p_Count).EditValue.ToString
                                    End If

                                    If p_Value Is Nothing Then
                                        p_Des = "Thông tin nhập chưa đầy đủ"
                                        p_Check_Control_Required = False
                                        p_Object.SelectedIndex = p_TabControl_Ind
                                        If p_Object_Item.Controls(p_Count).Visible = True Then
                                            p_Object_Item.Controls(p_Count).Focus()
                                            Exit Function
                                        End If
                                    ElseIf p_Value = "" Then
                                        p_Des = "Thông tin nhập chưa đầy đủ"
                                        p_Check_Control_Required = False
                                        p_Object.SelectedIndex = p_TabControl_Ind
                                        If p_Object_Item.Controls(p_Count).Visible = True Then
                                            p_Object_Item.Controls(p_Count).Focus()
                                            Exit Function
                                        End If
                                    End If
                                End If

                            End If

                        Next
                    Next


                End If


                'Xu ly cho cac item PanelControl
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_PanelControl, CompareMethod.Text) > 0 Then
                    '
                    'For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                    'p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                    p_Object_Item = p_Object
                    For p_Count = 0 To p_Object_Item.Controls.Count - 1
                        If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                            p_Value = p_Object_Item.Controls(p_Count).Required
                            'If p_Object_Item.Controls(p_Count).Name = "U_Nganh" Then
                            '    MsgBox("dfgdgd")
                            'End If
                            If p_Value = "Y" Then
                                If p_Object_Item.Controls(p_Count).EditValue Is Nothing Then
                                    p_Value = ""
                                Else
                                    p_Value = p_Object_Item.Controls(p_Count).EditValue.ToString
                                End If

                                If p_Value Is Nothing Then
                                    p_Des = "Thông tin nhập chưa đầy đủ"
                                    p_Check_Control_Required = False
                                    'p_Object.SelectedIndex = p_TabControl_Ind
                                    If p_Object_Item.Controls(p_Count).Visible = True Then
                                        p_Object_Item.Controls(p_Count).Focus()
                                        Exit Function
                                    End If
                                ElseIf p_Value = "" Then
                                    p_Des = "Thông tin nhập chưa đầy đủ"
                                    p_Check_Control_Required = False
                                    ' p_Object.SelectedIndex = p_TabControl_Ind
                                    If p_Object_Item.Controls(p_Count).Visible = True Then
                                        p_Object_Item.Controls(p_Count).Focus()
                                        Exit Function
                                    End If
                                End If
                            End If

                        End If

                    Next
                    'Next


                End If
            Next
        Catch ex As Exception
            'MsgBox("Err:" & p_Control_Ind)
            p_Check_Control_Required = False
            p_Des = ex.Message
        End Try

    End Function

    'ANHQH
    '04/07/2012
    'Ham tra ve 1 Recordsetssss
  
    'ANHQH
    '21/11/2011
    'Ham Tra ve chuoi ket noi voi CSDL
    Public Function SysGetConnect() As String
        Dim p_ConStr As String
        ' SysGetStrConnect()
        p_ConStr = ""
        If g_DB_Name <> "" Then
            If g_DBPortInstance.ToString.Trim = "" Then
                p_ConStr = "Provider=SQLOLEDB;Data Source=" & g_Server & ";Persist Security Info=True;User ID=" & _
                    g_UserName & ";Password=" & g_Password & ";Initial Catalog=" & g_DB_Name & ";Connect Timeout=300"
            Else
                p_ConStr = "Provider=SQLOLEDB;Server=" & g_Server & "," & g_DBPortInstance & ";" & _
                        "Database=" & g_DB_Name & ";User ID=" & g_UserName & ";Password=" & g_Password & ";" & _
                        "Trusted_Connection=False;Connect Timeout=300"
            End If

        End If

        SysGetConnect = p_ConStr
    End Function

    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function mod_SYS_GET_DATATABLE(ByVal p_SQL As String) As DataTable
        'Dim dr As OleDbDataReader 

        'Dim connectionString As String
        Dim sSQL As String
        Dim p_Status As Boolean
        Dim p_DataTable As New DataTable

        Dim p_DataSet As New DataSet

        Dim p_Recorset As New Object
        Dim p_Int As Integer

        Dim Olecon As New OleDb.OleDbConnection
        Dim OlemyCommand As OleDb.OleDbCommand
        Dim p_OleAdapter As OleDb.OleDbDataAdapter
        Dim p_ConnectStr As String
        p_Status = True



        'p_DataTable.c()
        sSQL = p_SQL
        Try
            'con.Open()
            'Olecon = Sys_SQL_Connection()
            p_ConnectStr = SysGetConnect()
            Olecon.ConnectionString = p_ConnectStr
            Olecon.Open()
            If Olecon.State.ToString() = "Open" Then
                OlemyCommand = New OleDbCommand(sSQL, Olecon)

                OlemyCommand.CommandTimeout = 300
                p_OleAdapter = New OleDbDataAdapter(OlemyCommand)
                p_Int = p_OleAdapter.Fill(p_DataSet)
            Else
                p_Status = False
            End If
            Olecon.Close()
            Olecon = Nothing
            'mod_SYS_GET_DATATABLE = p_DataTable
            Return p_DataSet.Tables(0)


        Catch ex As Exception
            MsgBox(ex.Message)
            p_DataTable = Nothing
            p_Status = False
            Return Nothing
        End Try

    End Function



    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function mod_SYS_GET_DATAREADER(ByVal p_SQL As String) As OleDbDataReader
        Dim dr As OleDbDataReader

        'Dim connectionString As String
        Dim sSQL As String
        Dim p_Status As Boolean
        Dim p_DataTable As New DataTable

        Dim p_DataSet As New DataSet

        Dim p_Recorset As New Object
        Dim p_Int As Integer

        Dim Olecon As New OleDb.OleDbConnection
        Dim OlemyCommand As OleDb.OleDbCommand
        Dim p_OleAdapter As OleDb.OleDbDataAdapter
        Dim p_ConnectStr As String
        p_Status = True



        'p_DataTable.c()
        sSQL = p_SQL
        Try
            'con.Open()
            'Olecon = Sys_SQL_Connection()
            p_ConnectStr = SysGetConnect()
            Olecon.ConnectionString = p_ConnectStr
            Olecon.Open()
            If Olecon.State.ToString() = "Open" Then
                OlemyCommand = New OleDbCommand(sSQL, Olecon)

                OlemyCommand.CommandTimeout = 300
                dr = OlemyCommand.ExecuteReader
                'p_OleAdapter = New OleDbDataAdapter(OlemyCommand)
                'p_Int = p_OleAdapter.Fill(p_DataSet)
            Else
                p_Status = False
            End If
            Olecon.Close()
            Olecon = Nothing
            'mod_SYS_GET_DATATABLE = p_DataTable
            Return dr


        Catch
            p_DataTable = Nothing
            p_Status = False
            Return Nothing
        End Try

    End Function


    Public Function p_Set_TrueGrid_Property_Page(ByRef p_DesError As String, _
                                              ByVal p_SQLString As String, _
                                              ByRef p_Form As System.Windows.Forms.Form, _
                                             ByRef p_BindingSource As BindingSource, _
                                             ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                             ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                             ByVal p_FieldKey As String, _
                                             ByVal p_PageNum As Integer, _
                                             ByVal p_LineOfPage As Integer, _
                                             Optional ByVal B1Get As Boolean = True, _
                                             Optional ByVal p_LoadPage As Boolean = False) As Boolean
        Dim p_Count As Integer
        Dim p_FieldNAme() As String
        Dim p_FieldCaption() As String
        Dim p_SQL As String = ""
        Dim p_ViewName As String = ""
        Dim p_NoCustomize As Boolean = False
        Dim p_Where As String = ""
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

        Try

            p_GridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False
            p_GridView.OptionsBehavior.Editable = False
            p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            p_GridView.OptionsNavigation.EnterMoveNextColumn = True


            p_Set_TrueGrid_Property_Page = True
            If p_SQLString = "" Then
                p_Set_TrueGrid_Property_Page = False
                Exit Function
            End If
            p_SQL = p_SQLString

            'If p_FieldKey <> "" And p_LoadPage = True Then
            '    p_SQL = "SELECT * FROM (" & _
            '                            " SELECT *, ROW_NUMBER() OVER (ORDER BY " & p_FieldKey & ") AS RowNum" & _
            '                            " FROM (" & p_SQLString & ") anhqh " & _
            '                        " ) AS MyDerivedTable " & _
            '                        " WHERE MyDerivedTable.RowNum BETWEEN (" & p_PageNum & " -1)* " & p_LineOfPage & " +1  " & _
            '                        " AND " & (p_PageNum * p_LineOfPage)
            'Else
            '    p_SQL = p_SQLString
            'End If
            '  p_BindingSource.ResetBindings(True)

            p_BindingSource.DataSource = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Where)
            If p_Where <> "" Then
                MsgBox(p_Where)
                p_Set_TrueGrid_Property_Page = False
                Exit Function
            End If

            p_TrueGird.DataSource = p_BindingSource

            'Cac Column khong duoc  khai bao trong bang GRID_PROPERTY
            ReDim p_FieldNAme(0 To p_GridView.Columns.Count - 1)
            ReDim p_FieldCaption(0 To p_GridView.Columns.Count - 1)
            For p_Count = 0 To p_GridView.Columns.Count - 1
                p_FieldNAme(p_Count) = p_GridView.Columns(p_Count).FieldName
                p_FieldCaption(p_Count) = p_GridView.Columns(p_Count).Caption

                ' p_TrueGird.Columns(p_Count).DataField = p_TrueGird.Columns(p_Count).DataField
            Next

            'p_BindingSource.ResetBindings(True)
            For p_Count = 0 To UBound(p_FieldNAme, 1)
                p_GridView.Columns(p_Count).FieldName = p_FieldNAme(p_Count)
                p_GridView.Columns(p_Count).Caption = p_FieldCaption(p_Count)

            Next
            p_TrueGird.Refresh()

            Try
                'p_CountTo = p_Count
                'For p_Count = 0 To p_GridView.Columns.Count - p_CountTo
                '    If Not p_GridView.Columns(p_Count) Is Nothing Then
                '        If p_GridView.Columns(p_Count).FieldName.ToString = "" Then
                '            'p_GridView.Columns.RemoveAt(p_Count)
                '            p_Column = p_GridView.Columns(p_Count)
                '            p_GridView.Columns.Remove(p_Column)

                '        Else
                '            If p_Count >= p_CountTo Then
                '                'Else
                '                p_GridView.Columns(p_Count).Visible = False
                '            End If

                '        End If
                '    End If
                ' Next

            Catch ex As Exception
                p_DesError = ex.Message
                p_Set_TrueGrid_Property_Page = False
            End Try

        Catch ex As Exception
            p_DesError = ex.Message
            p_Set_TrueGrid_Property_Page = False
        End Try


    End Function




    Public Sub p_ComboboxAddValue(ByRef p_Combobox As U_TextBox.U_Combobox, ByVal p_Code As String, ByVal p_Name As String)
        Dim p_Datatable As DataTable
        Dim p_Col1 As DataColumn '  New DataColumn("Column0")
        Dim p_DataRow As DataRow
        Dim p_SQL As String = ""
        Dim p_DisplayMember As String = "Name"
        Dim p_ValueMember As String = "Code"
        Try
            p_Datatable = p_Combobox.Properties.DataSource
            'p_DisplayMember = p_Combobox.DisplayField
            ' p_ValueMember = p_Combobox.ValueField
            If p_Datatable Is Nothing Then
                p_Datatable = New DataTable("Table0")



                p_Col1 = New DataColumn(p_ValueMember)
                p_Col1.DataType = GetType(String)
                p_Datatable.Columns.Add(p_Col1)
                p_Col1 = New DataColumn(p_DisplayMember)
                p_Col1.DataType = GetType(String)
                p_Datatable.Columns.Add(p_Col1)
            End If

            p_DataRow = p_Datatable.NewRow
            p_DataRow.Item(0) = p_Code
            p_DataRow.Item(1) = p_Name
            p_Datatable.Rows.Add(p_DataRow)

            p_Combobox.Properties.DataSource = p_Datatable
            p_Combobox.Properties.DisplayMember = p_DisplayMember
            p_Combobox.Properties.ValueMember = p_ValueMember
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

End Module
