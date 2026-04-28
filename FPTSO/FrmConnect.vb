Public Class FrmConnect
    Private p_ASHOST As String = ""
    Private p_SYSNR As String = ""
    Private p_CLIENT As String = ""
    Private p_USER As String = ""
    Private p_PASSWD As String = ""

    Private Sub SetValue()
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_String() As String
        Dim p_Stringtmp() As String
        Dim p_Count As Integer
        p_SQL = "Select * from tblconfig"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        p_SQL = ""
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then

                Me.txtcompanycode.EditValue = p_DataTable.Rows(0).Item("companycode").ToString.Trim
                Me.txtPlant_DB.EditValue = p_DataTable.Rows(0).Item("Plant_DB").ToString.Trim
                Me.txtshippingpoint.EditValue = p_DataTable.Rows(0).Item("shippingpoint").ToString.Trim
                Me.txtwarehouse.EditValue = p_DataTable.Rows(0).Item("warehouse").ToString.Trim
                p_SQL = p_DataTable.Rows(0).Item("sapconnectionstring").ToString.Trim
                If p_SQL <> "" Then
                    p_String = p_SQL.Split(";")
                    If p_String.Length > 0 Then
                        For p_Count = 0 To p_String.Length - 1
                            p_Stringtmp = p_String(p_Count).Split("=")
                            If p_Stringtmp.Length > 0 Then
                                Select Case UCase(p_Stringtmp(0))
                                    Case "ASHOST"
                                        Me.AHOST.EditValue = p_Stringtmp(1)
                                    Case "SYSNR"
                                        Me.SYSNR.EditValue = p_Stringtmp(1)
                                    Case "CLIENT"
                                        Me.Client.EditValue = p_Stringtmp(1)
                                    Case "USER"
                                        Me.User.EditValue = p_Stringtmp(1)
                                    Case "PASSWD"
                                        Me.PassWD.EditValue = p_Stringtmp(1)
                                    Case Else

                                End Select
                            End If
                        Next
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FrmConnect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'GetTypeConnectWCF()
        SetValue()
    End Sub
    Private Sub GetTypeConnectWCF()
        'Dim g_PathXML As String
        'Dim p_DataSet As New DataSet
        'Dim g_Config_XMLDatatable As DataTable
        'Dim p_Count As Integer
        'Dim p_Name As String
        'Dim p_Control() As Control
        'Dim p_EditText As U_TextBox.U_TextBox
        'Try

        '    g_PathXML = Application.StartupPath & "\Config.xml"
        '    If Dir(g_PathXML) <> "" Then
        '        p_DataSet.ReadXml(g_PathXML)
        '        If Not p_DataSet Is Nothing Then
        '            If p_DataSet.Tables.Count > 0 Then
        '                g_Config_XMLDatatable = p_DataSet.Tables(0)
        '                Try

        '                    For p_Count = 0 To g_Config_XMLDatatable.Columns.Count - 1
        '                        p_Name = UCase(g_Config_XMLDatatable.Columns.Item(p_Count).ColumnName)
        '                        p_Control = Me.Controls.Find(p_Name, True)

        '                        If p_Control Is Nothing Then
        '                            If p_Control.Length > 0 Then
        '                                p_EditText = CType(p_Control(0), U_TextBox.U_TextBox)
        '                                p_EditText.EditValue = g_Config_XMLDatatable.Rows(0).Item(p_Count).ToString.Trim
        '                            End If

        '                        End If

        '                    Next

        '                Catch ex As Exception

        '                End Try
        '                ' g_Config_XMLDatatable.WriteXml(p_PathXML)
        '            End If
        '        Else

        '        End If
        '        '
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub SetParameter()
        Dim p_PASSWDTmp As String
        p_ASHOST = ""
        If Not Me.AHOST.EditValue Is Nothing Then
            p_ASHOST = Me.AHOST.EditValue.ToString.Trim
        End If

        p_SYSNR = ""
        If Not Me.SYSNR.EditValue Is Nothing Then
            p_SYSNR = Me.SYSNR.EditValue.ToString.Trim
        End If

        p_CLIENT = ""
        If Not Me.Client.EditValue Is Nothing Then
            p_CLIENT = Me.Client.EditValue.ToString.Trim
        End If

        p_USER = ""
        If Not Me.User.EditValue Is Nothing Then
            p_USER = Me.User.EditValue.ToString.Trim
        End If

        p_PASSWDTmp = ""
        If Not Me.PassWDTmp.EditValue Is Nothing Then
            p_PASSWDTmp = Me.PassWDTmp.EditValue.ToString.Trim
        End If

        p_PASSWD = ""
        If Not Me.PassWD.EditValue Is Nothing Then
            p_PASSWD = Me.PassWD.EditValue.ToString.Trim
        End If

        If p_PASSWDTmp <> p_PASSWD And p_PASSWDTmp <> "" Then
            p_PASSWD = p_PASSWDTmp
        End If
    End Sub


    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_Desc As String = ""
        SetParameter()
        If g_WCF = False Then
            Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            'If p_SAP_Object.clsCheckSAPConnection("", p_SQL) = False Then

            'End If
            If p_SAP_Object.clsTestConnectSAP(True, p_ASHOST, p_SYSNR, p_CLIENT, p_USER, p_PASSWD, p_Desc) = False Then
                ShowMessageBox("", p_Desc)
                Exit Sub
            Else
                ShowMessageBox("", "Kết nối thành công", 1)
            End If

        Else
            If g_Services.clsTestConnectSAP(True, p_ASHOST, p_SYSNR, p_CLIENT, p_USER, p_PASSWD, p_Desc) = False Then
                ShowMessageBox("", p_Desc)
                Exit Sub
            Else
                ShowMessageBox("", "Kết nối thành công", 1)
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_Desc As String = ""
        Dim p_SQL As String = ""

        Dim p_txtwarehouse, p_txtshippingpoint, p_txtPlant_DB, p_txtcompanycode As String
        p_txtwarehouse = ""
        p_txtshippingpoint = ""
        p_txtPlant_DB = ""
        p_txtcompanycode = ""
        If Not Me.txtwarehouse.EditValue Is Nothing Then
            p_txtwarehouse = Me.txtwarehouse.EditValue.ToString.Trim
        End If
        If Not Me.txtshippingpoint.EditValue Is Nothing Then
            p_txtshippingpoint = Me.txtshippingpoint.EditValue.ToString.Trim
        End If
        If Not Me.txtPlant_DB.EditValue Is Nothing Then
            p_txtPlant_DB = Me.txtPlant_DB.EditValue.ToString.Trim
        End If
        If Not Me.txtcompanycode.EditValue Is Nothing Then
            p_txtcompanycode = Me.txtcompanycode.EditValue.ToString.Trim
        End If

        If p_txtwarehouse = "" Or p_txtPlant_DB = "" Or p_txtshippingpoint = "" Or p_txtwarehouse = "" Then
            ShowMessageBox("", "companycode, warehouse, shipping point, Plant chưa nhập thông tin")
            Exit Sub
        End If

        p_SQL = "Update tblconfig set warehouse='" & p_txtwarehouse & "',  shippingpoint='" & p_txtshippingpoint & "', Plant_DB='" & p_txtPlant_DB & "', companycode ='" & p_txtcompanycode & "'"
        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

        End If
        'If Me.FormStatus = False Then
        '    Exit Sub
        'End If
        SetParameter()
        If g_WCF = False Then
            Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            'If p_SAP_Object.clsCheckSAPConnection("", p_SQL) = False Then

            'End If
            If p_SAP_Object.clsTestConnectSAP(True, p_ASHOST, p_SYSNR, p_CLIENT, p_USER, p_PASSWD, p_Desc) = False Then
                ShowMessageBox("", p_Desc)
                Exit Sub
            Else
                'ShowMessageBox("", "Kết nối thành công")
                If p_SAP_Object.clsTestConnectSAP(False, p_ASHOST, p_SYSNR, p_CLIENT, p_USER, p_PASSWD, p_Desc) = False Then
                    ShowMessageBox("", p_Desc)
                    Exit Sub
                Else
                    ShowStatusMessage(False, "", "Lưu thành công", 7)
                End If
            End If

        Else
            If g_Services.clsTestConnectSAP(True, p_ASHOST, p_SYSNR, p_CLIENT, p_USER, p_PASSWD, p_Desc) = False Then
                ShowMessageBox("", p_Desc)
                Exit Sub
            Else
                If g_Services.clsTestConnectSAP(False, p_ASHOST, p_SYSNR, p_CLIENT, p_USER, p_PASSWD, p_Desc) = False Then
                    ShowMessageBox("", p_Desc)
                    Exit Sub
                Else
                    ShowStatusMessage(False, "", "Lưu thành công", 7)
                End If
            End If
        End If
    End Sub
End Class