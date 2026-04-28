Imports System.Net
Imports System.IO

Imports Newtonsoft.Json.Linq


Public Class Class1


    'Public Function B12_ThongTinHamHang(ByVal p_Do As String) As DataTable
    '    Dim requestUrl As String = "http://www.b12petroleum.com.vn/TDHKhoBeAPI/api/DuongAmTamMuc?do_sap=" & p_Do
    '    '"http://www.b12petroleum.com.vn/TDHKhoBeAPI/api/DuongAmTamMuc?do_sap=2055500198"
    '    Dim p_SQL As String
    '    Dim jResults As JObject
    '    Dim p_Array1 As String()
    '    Dim p_Array2 As String()
    '    Dim p_Int, pInt1 As Integer
    '    Dim p_Table As New DataTable("HH")
    '    Dim p_Row As DataRow
    '    Try
    '        Dim http As HttpWebRequest = CType(HttpWebRequest.Create(requestUrl), HttpWebRequest)
    '        ' h() 'ttp.Referer = referrer
    '        Dim response As HttpWebResponse = CType(http.GetResponse(), HttpWebResponse)
    '        p_Table.Columns.Add("MaNgan")
    '        p_Table.Columns.Add("HH")
    '        Using sr As StreamReader = New StreamReader(response.GetResponseStream())
    '            Dim responseJson As String = sr.ReadToEnd()
    '            ' Dim jResults As JObject = JObject.Parse(responseJson)
    '            jResults = JObject.Parse(responseJson)
    '            ' jResults = JArray.Parse(responseJson)
    '            If jResults.Count > 0 Then
    '                If jResults.Item("hh").ToString <> "" Then

    '                    'p_SQL = jResults.Item("hh").Value
    '                    p_Array1 = Split(jResults.Item("hh").ToString, ";")
    '                    For p_Int = 0 To p_Array1.Length - 1
    '                        p_Array2 = Split(p_Array1(p_Int).ToString, ":")
    '                        If p_Array2.ToString <> "" Then
    '                            Try
    '                                p_Row = p_Table.NewRow
    '                                p_Row.Item(0) = Mid(p_Array2(0).ToString, 2).Trim
    '                                p_Row.Item(1) = p_Array2(1).ToString.Trim
    '                                p_Table.Rows.Add(p_Row)
    '                            Catch ex As Exception

    '                            End Try

    '                        End If
    '                    Next
    '                End If

    '            End If





    '        End Using
    '        Return p_Table
    '    Catch ex As Exception
    '        'Return String.Empty
    '        p_SQL = ex.Message

    '        Return Nothing

    '    End Try
    'End Function

End Class
