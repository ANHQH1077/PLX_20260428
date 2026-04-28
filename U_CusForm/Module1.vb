Imports System.Reflection
Imports System.Windows.Forms

Module Module1
    Public g_ItemDataTable As New DataTable("Table0")
    Public p_XtrFormProperty As U_CusForm.XtraCusForm1
    Public p_FormItem As New FrmItemProperty
    Public g_ItemProperty As New DataTable("Table001")
    Public g_TimeError As Integer = 20
    Public g_TimeInfor As Integer = 10

    Public g_OwnerMenuStrip As MenuStrip


    'Private pv_Type_Tabpage As String = "TABCONTROL"

    Public Sub SendBackForm(ByVal p_NameForm As String, ByVal p_Top As Integer, Optional ByVal p_MenuIcon As Boolean = False)

        Dim frmCollection As New FormCollection()
        Dim p_Form As Form

        '   Exit Sub
        frmCollection = Application.OpenForms()
        For Each p_Form In frmCollection
            If UCase(p_Form.Name) <> UCase(p_NameForm) Then
                If Not p_Form.Owner Is Nothing Then
                    If p_Form.Name <> p_Form.Owner.Name.ToString.Trim Then
                        If p_Form.Top = p_Top Then Continue For
                        'p_Form.
                        'p_Form.Owner.BringToFront()
                        If p_MenuIcon = True Then
                            p_Form.Top = p_Top
                        End If
                    End If
                End If
            End If
        Next

        'If frmCollection.Item(p_NameForm).IsHandleCreated Then
        '    p_Form = frmCollection.Item(p_NameForm)
        'End If
    End Sub

    Private Function p_ShowItemPropertyPage(ByRef p_ControlPage As Object, ByVal p_Form As Object) As Boolean
        Dim p_Count As Integer = 0
        Dim p_Control As System.Windows.Forms.Control
        Dim p_Row As DataRow
        Dim p_TabControl_Ind As Integer
        Dim p_Object_Tab As DevExpress.XtraTab.XtraTabPage
        Try
            ' For Each p_ControlPage In p_XtrFormProperty.Controls
            For p_TabControl_Ind = p_ControlPage.TabPages.Count - 1 To 0 Step -1
                p_ControlPage.SelectedTabPageIndex = p_TabControl_Ind
                p_Object_Tab = p_ControlPage.TabPages(p_TabControl_Ind) ' p_Control
                If InStr(UCase(p_Object_Tab.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    If p_ShowItemPropertyPage(p_Object_Tab, p_Form) = False Then
                        Continue For
                    End If
                Else
                    If InStr(UCase(p_Object_Tab.GetType.ToString), "XtraTabPage", CompareMethod.Text) > 0 Then
                        For Each p_Object_Tab_Item In p_Object_Tab.Controls
                            If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                                If p_ShowItemPropertyPage(p_Object_Tab_Item, p_Form) = False Then
                                    Continue For
                                End If
                            Else
                                p_Row = g_ItemDataTable.NewRow
                                p_Row.Item("ItemName") = p_Object_Tab_Item.Name.ToString
                                ' p_Row.Item("ItemType") = p_Control.GetType.ToString
                                g_ItemDataTable.Rows.Add(p_Row)
                            End If
                        Next
                    End If
                End If
               
            Next
        Catch ex As Exception
            MsgBox("ShowItemPropertyPage: " & ex.Message)
            p_ShowItemPropertyPage = False
        End Try

    End Function
    Public Sub p_ShowItemProperty(ByRef p_Form As Object)
        Dim p_Count As Integer = 0
        ' Dim p_ControlType As Type

        Dim p_Row As DataRow
        'Dim p_RowArr() As DataRow
        Dim p_Control As System.Windows.Forms.Control
        Try
            If g_ItemDataTable.Columns.Count <= 0 Then
                g_ItemDataTable.Columns.Add("ItemName", Type.GetType("System.String"))
                'g_ItemDataTable.Columns.Add("ItemType", Type.GetType("System.String"))
            End If
            g_ItemDataTable.Clear()
            p_FormItem.ItemList.Properties.DataSource = Nothing
            p_XtrFormProperty = p_Form
            For Each p_Control In p_XtrFormProperty.Controls

                If InStr(UCase(p_Control.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    If p_ShowItemPropertyPage(p_Control, p_Form) = False Then
                        Continue For
                    End If
                Else
                    'p_RowArr = g_ItemDataTable.Select("ItemName='" & p_Control.Name.ToString & "'")
                    'If p_RowArr.Length <= 0 Then
                    p_Row = g_ItemDataTable.NewRow
                    p_Row.Item("ItemName") = p_Control.Name.ToString
                    ' p_Row.Item("ItemType") = p_Control.GetType.ToString
                    g_ItemDataTable.Rows.Add(p_Row)
                End If

                ''p_RowArr = g_ItemDataTable.Select("ItemName='" & p_Control.Name.ToString & "'")
                ''If p_RowArr.Length <= 0 Then
                'p_Row = g_ItemDataTable.NewRow
                'p_Row.Item("ItemName") = p_Control.Name.ToString
                '' p_Row.Item("ItemType") = p_Control.GetType.ToString
                'g_ItemDataTable.Rows.Add(p_Row)
                '' End If
                ''personType.GetProperty(kvp.Key)
            Next


            p_FormItem.ItemList.Properties.DataSource = g_ItemDataTable
            p_FormItem.ItemList.Properties.DisplayMember = "ItemName"
            p_FormItem.ItemList.Properties.ValueMember = "ItemName"
            p_FormItem.ItemList.Properties.DropDownRows = 20
            'Try

            'Catch ex As Exception

            'End Try
            p_FormItem.ShowDialog(p_Form)
        Catch ex As Exception

        End Try

        'If p_Form.GetType. = DevExpress.XtraEditors.XtraForm Then
        '    For Each p_Control In p

        '    Next
        'End If
    End Sub


    Public Sub p_GetPropertyItem(ByVal p_ItemName As String)
        Dim p_ControlType As Type
        Dim p_ControlArr() As System.Windows.Forms.Control
        Dim p_Control As System.Windows.Forms.Control
        Dim p_Count As Integer = 0
        Dim p_RowArr() As DataRow

        Dim p_Row As DataRow
        Dim p_ItemPropertyList As New DataTable("Table001")
        Dim str As String = "" ' - some string to send the output to
        ' Dim obj As Object = p_Control  ' - a object with properties


        If g_ItemProperty.Columns.Count <= 0 Then
            g_ItemProperty.Columns.Add("ItemProperty", Type.GetType("System.String"))
            g_ItemProperty.Columns.Add("ValueProperty", Type.GetType("System.String"))
            ' g_ItemProperty.Columns.Add("ItemType", Type.GetType("System.String"))
        End If
        g_ItemProperty.Clear()

        p_ItemPropertyList.Columns.Add("ItemProperty", Type.GetType("System.String"))

        p_ItemPropertyList.Clear()

        p_ControlArr = p_XtrFormProperty.Controls.Find(p_ItemName, True)
        If p_ControlArr.Length > 0 Then
            p_Control = p_ControlArr(0)
            p_ControlType = p_Control.GetType ' GetType(p_Control).type
          
            Dim info() As PropertyInfo = p_Control.GetType().GetProperties()
            Try
                For p_Count = 0 To info.Length - 1
                    p_RowArr = g_ItemProperty.Select("ItemProperty='" & info(p_Count).Name.ToString.Trim & "'")
                    If p_RowArr.Length <= 0 Then

                        If Not info(p_Count).GetValue(p_Control, Nothing) Is Nothing Then
                            p_Row = p_ItemPropertyList.NewRow
                            p_Row.Item("ItemProperty") = info(p_Count).Name.ToString.Trim
                            p_ItemPropertyList.Rows.Add(p_Row)




                            p_Row = g_ItemProperty.NewRow
                            p_Row.Item("ItemProperty") = info(p_Count).Name.ToString.Trim
                            str = ""
                            
                            ' If info(p_Count).PropertyType Is GetType(System.String) Then
                            str = info(p_Count).GetValue(p_Control, Nothing).ToString
                            'End If
                            p_Row.Item("ValueProperty") = str

                            g_ItemProperty.Rows.Add(p_Row)
                        End If
                    End If
                Next
            Catch ex As Exception
                MsgBox("p_GetPropertyItem:" & ex.Message)
            End Try
            

            p_FormItem.LookUpEdit1.Properties.DataSource = p_ItemPropertyList
            p_FormItem.LookUpEdit1.Properties.DisplayMember = "ItemProperty"
            p_FormItem.LookUpEdit1.Properties.ValueMember = "ItemProperty"
            p_FormItem.LookUpEdit1.Properties.DropDownRows = 20

            '  p_FormItem.LookUpEdit1.Properties.Columns(1).Visible = False


        End If
    End Sub

End Module
