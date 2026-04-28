Imports System
Imports System.Data
'Imports System.Windows.Forms
Module Lib_Module1
    Public g_Service As Object

    Private pv_Type_Column_Char As String = "VARCHAR"  'Kieu du lieu cua column
    Private pv_Type_Column_Date As String = "DATE"  'Kieu du lieu cua column
    Private pv_Type_Column_Number As String = "NUMBER"  'Kieu du lieu cua column


    Private pv_Type_Date As String = "DATEEDIT"
    Private pv_Type_TextBox As String = "C1TEXTBOX"
    Private pv_Type_Num As String = "C1NUMERICEDIT"
    Private pv_Type_Combo As String = "C1COMBO"

    Private g_Format_Date_Ora As String = "MM/DD/YYYY"
    Private g_Format_Date As String = "MM/dd/yyyy"

    ' Private pv_C1TrueDBGrid As C1.Win.C1TrueDBGrid.


    Private Function p_Convert_Date(ByVal p_Str_Date As String) As String
        p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date), g_Format_Date)
    End Function
    
    'ANHQH
    '03/01/2011
    'HAm thuc hien kiem tra gia tri cua control vơi kieu du lieu va tra ve gia tri tương ứng
    'ByVal p_Control_Name As String, _   'Ten Column
    'ByVal p_Control_Type As String, _   'Kieu cua Column
    'p_Value   Gia tri cua Control truyen vao
    'ByRef p_Return_Value As String   Gia tri tra ve
    Private Sub p_Get_Value_Control(ByVal p_Value As String, ByVal p_Control_Name As String, _
                                    ByVal p_Control_Type As String, _
                                    ByRef p_Return_Value As String)
        If p_Value = "" Then
            p_Return_Value = "null"
        Else
            If InStr(UCase(p_Control_Type), pv_Type_Column_Char, CompareMethod.Text) > 0 Then
                p_Return_Value = "'" & p_Value & "'"
            ElseIf InStr(UCase(p_Control_Type), pv_Type_Column_Date, CompareMethod.Text) > 0 Then
                p_Return_Value = "To_Date('" & p_Convert_Date(p_Value) & "','" & g_Format_Date_Ora & "')"
            Else
                p_Return_Value = p_Value
            End If
            
        End If

    End Sub





    'ANHQH
    '03/01.2011
    'HAm tao cau lenh SQL cho Header
    'p_Column_Key: Ten truong Primarykey dung de update
    'Array ten cot cua table
    'Array kieu du lieu cua cot
    Public Function p_Set_Sql_Header_new(ByVal p_Form As Object, ByVal pv_Column_Name As ArrayList, ByVal pv_Column_Type As ArrayList, _
                                          ByVal pv_INS_KEY As String, ByVal p_Table_Name As String, _
                                          ByVal p_Column_Key As String, _
                                            ByVal p_Column_Key_Value As String, ByVal p_Satus As String) As String
        Dim p_Control_Ind As Integer
        'Dim p_Array_Index As Integer
        Dim p_Object As Object

        Dim p_SQL As String = ""
        Dim p_SQL1 As String = ""
        Dim p_SQL2 As String = ""
        Dim p_Value As String
        Dim p_Return_Value As String
        Dim p_Control_Name As String
        Dim p_Positton As Integer
        Dim p_Control_Type As String

        For p_Control_Ind = 0 To p_Form.Controls.Count - 1
            p_Object = p_Form.Controls.Item(p_Control_Ind)

            p_Control_Name = UCase(p_Object.Name.ToString)


            If p_Find_Control_New(pv_Column_Name, p_Control_Name, p_Positton) = True Then
                If InStr(p_Object.ToString, pv_Type_Combo, CompareMethod.Text) = 0 Then
                    p_Value = p_Object.text.ToString

                Else
                    p_Value = p_Object.Value.ToString

                End If
                p_Return_Value = ""
                p_Control_Type = UCase(pv_Column_Type(p_Positton))
                Call p_Get_Value_Control(p_Value, p_Control_Name, p_Control_Type, p_Return_Value)

                If p_Satus = pv_INS_KEY Then
                    If p_SQL1 = "" Then
                        p_SQL1 = p_Control_Name
                        p_SQL2 = p_Return_Value
                    Else
                        p_SQL1 = p_SQL1 & "," & p_Control_Name
                        p_SQL2 = p_SQL2 & "," & p_Return_Value
                    End If

                Else
                    If p_Column_Key <> "" Then
                        If UCase(p_Column_Key) <> p_Control_Name Then
                            If p_SQL1 = "" Then
                                p_SQL1 = p_Control_Name & "=" & p_Return_Value
                            Else
                                p_SQL1 = p_SQL1 & "," & p_Control_Name & "=" & p_Return_Value
                            End If
                        End If
                    End If
                End If
            End If
        Next
        If p_Satus = pv_INS_KEY Then
            p_SQL = "INSERT INTO " & p_Table_Name & "(" & p_SQL1 & ") VALUES (" & p_SQL2 & ")"
        Else
            p_SQL = " UPDATE  " & p_Table_Name & " SET " & p_SQL1 & " WHERE " & p_Column_Key & "=" & p_Column_Key_Value
        End If
        p_Set_Sql_Header_new = p_SQL
    End Function


    'ANHQH,
    '03/01/2011
    'Ham tim kien ten cua Controltrong mang 
    'Neu tim thay tra va True
    Private Function p_Find_Control_New(ByVal pv_Column_Name As ArrayList, ByVal p_Control_Name As String, ByRef p_Positton As Integer) As Boolean

        p_Find_Control_New = False
        p_Positton = 0
        If p_Control_Name <> "" Then
            p_Positton = pv_Column_Name.IndexOf(p_Control_Name)
            If p_Positton > 0 Then
                p_Find_Control_New = True
            End If
        End If
    End Function


    'ANHQH
    '28/12/2011
    'Ham thuc hien Get cau truc bang
    'p_Array_Column_Name:MAng luu danh sach cot cua Table
    'p_Array_Column_Type: mang luu danh sach kieu du lieu cua Table
    Public Sub p_Get_Column_Type(ByVal pv_Arr_TableName As ArrayList, _
                        ByRef p_Array_Column_Name As Object, ByRef p_Array_Column_Type As Object)
        Dim p_Count As Integer
        Dim p_SQL As String

        'Dim Svr As New SystemBatch.Class1
        Dim p_DataTable As DataTable

        Dim p_Table_Name As String = ""

        p_Array_Column_Name.Clear()
        p_Array_Column_Type.Clear()
        For p_Count = 0 To pv_Arr_TableName.Count - 1
            If p_Table_Name = "" Then
                p_Table_Name = "'" & UCase(pv_Arr_TableName(p_Count).ToString) & "'"
            Else
                p_Table_Name = p_Table_Name & ",'" & UCase(pv_Arr_TableName(p_Count).ToString) & "'"
            End If

        Next p_Count
        If p_Table_Name <> "" Then
            p_SQL = "select k1.name as table_name, k.name as column_name,k.user_type_id as data_type from sys.all_columns k," & _
                    "sys.all_objects k1 where    k.object_id=k1.object_id and upper( k1.name) in (" & p_Table_Name & ")"
            p_DataTable = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            
            For p_Count = 0 To p_DataTable.Rows.Count - 1

                p_Array_Column_Name.add(UCase(p_DataTable.Rows(p_Count).Item(1).ToString))
                p_Array_Column_Type.add(UCase(p_DataTable.Rows(p_Count).Item(2).ToString))
            Next
        End If
        g_Service = Nothing
    End Sub

End Module
