
Class Encrypt2MD5
    Public Function Encrypt(ByVal mess As String) As String
        Dim x As System.Security.Cryptography.MD5CryptoServiceProvider = New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim bs() As Byte
        bs = System.Text.Encoding.UTF8.GetBytes(mess)
        bs = x.ComputeHash(bs)
        Dim s As System.Text.StringBuilder = New System.Text.StringBuilder()
        For Each b As Byte In bs
            s.Append(b.ToString("x2").ToLower())
        Next
        Encrypt = s.ToString().ToUpper()
    End Function
End Class
