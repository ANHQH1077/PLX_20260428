Public Class Class1

    Public Function SetSqlHeader(ByVal p_Form As Object, ByVal pv_Column_Name As ArrayList, ByVal pv_Column_Type As ArrayList, _
                                          ByVal pv_INS_KEY As String, ByVal p_Table_Name As String, _
                                          ByVal p_Column_Key As String, _
                                            ByVal p_Column_Key_Value As String, ByVal p_Satus As String) As String


        SetSqlHeader = p_Set_Sql_Header_new(p_Form, pv_Column_Name, pv_Column_Type, _
                                           pv_INS_KEY, p_Table_Name, _
                                           p_Column_Key, _
                                             p_Column_Key_Value, p_Satus)
    End Function

    Public Sub GetColumnType(ByVal pv_Arr_TableName As ArrayList, _
                        ByRef p_Array_Column_Name As Object, ByRef p_Array_Column_Type As Object)
        Call p_Get_Column_Type(pv_Arr_TableName, _
                        p_Array_Column_Name, p_Array_Column_Type)

    End Sub

    Public Sub New(ByVal p_Service As Object)
        g_Service = p_Service
    End Sub
End Class
