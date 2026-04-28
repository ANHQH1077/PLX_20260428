' NOTE: You can use the "Rename" command on the context menu to change the interface name "IService" in both code and config file together.
<ServiceContract()> _
Public Interface IService

    <OperationContract()> _
    Function ModReadFile(ByVal FilePath As String, ByVal Position As Long, ByVal Count As Long, ByRef Exception As String) As Byte()
    ' TODO: Add your service operations here
    <OperationContract()> _
    Function mod_SYS_GET_DATASET(ByVal p_SQL As String) As System.Data.DataSet
End Interface

' Use a data contract as illustrated in the sample below to add composite types to service operations.

<DataContract()> _
Public Class CompositeType

    Private boolValueField As Boolean
    Private stringValueField As String

    <DataMember()> _
    Public Property BoolValue() As Boolean
        Get
            Return Me.boolValueField
        End Get
        Set(ByVal value As Boolean)
            Me.boolValueField = value
        End Set
    End Property

    <DataMember()> _
    Public Property StringValue() As String
        Get
            Return Me.stringValueField
        End Get
        Set(ByVal value As String)
            Me.stringValueField = value
        End Set
    End Property

End Class
