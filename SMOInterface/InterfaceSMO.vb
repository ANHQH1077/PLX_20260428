
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module InterfaceSMO

    Public Class User
        Public Property username As String = ""
        Public Property password As String = ""
    End Class
    Public Class Item
        Public Property type As String = ""
        Public Property vrt As String = ""
        Public Property line As Integer = 0
        Public Property name As String = ""

        Public Property unit As String = ""
        Public Property amount As Integer = 0
        Public Property price As Double = 0.00 ' = 0
        Public Property quantity As Double = 0

        'anhqh  20200211 bo sung them Thue VAT theo tung line, neu co
        Public Property c0 As Integer = 0 'Tien thue
        Public Property c1 As Integer = 0 'Thanh tien sau thue


    End Class
    Public Class Inv
        Public Property sid As String = ""
        Public Property idt As String = ""
        Public Property type As String = ""
        Public Property form As String = ""
        Public Property serial As String = ""
        Public Property seq As String = ""
        Public Property bname As String = ""
        Public Property buyer As String = ""
        Public Property btax As String = ""
        Public Property baddr As String = ""
        Public Property btel As String = ""
        Public Property bmail As String = ""
        Public Property paym As String = ""
        Public Property curr As String = ""
        Public Property exrt As Integer = 0
        Public Property bacc As String = ""
        Public Property bbank As String = ""
        Public Property note As String = ""
        Public Property sumv As Integer = 0
        Public Property sum As Integer = 0
        Public Property vatv As Integer = 0
        Public Property vat As Integer = 0
        Public Property word As String = ""
        Public Property totalv As Integer = 0
        Public Property total As Integer = 0
        Public Property discount As Double = 0
        Public Property aun As Integer = 0
        Public Property stax As String = ""
        Public Property c2 As Double = 0
        Public Property c3 As Double = 0
        Public Property c4 As Double = 0
        Public Property c5 As Double = 0
        Public Property items As List(Of Item)

    End Class
End Module
