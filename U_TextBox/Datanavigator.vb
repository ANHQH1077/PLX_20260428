Public Class Datanavigator
    ' Inherits C1.Win.C1Input.C1TextBox
    Private p_ViewName As String = ""
    Private p_TableName As String = ""
    Private p_Where As String = ""
    Private p_KeyField As String = ""
    Private p_RowNum As Integer = 0

   
    Public Sub New()

        ' This call is required by the Windows Form Designer.

        MyBase.New()

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Property ViewName() As String
        Get
            Return p_ViewName
        End Get
        Set(ByVal value As String)
            p_ViewName = value
        End Set

    End Property


    Public Property RowNum() As String
        Get
            Return p_RowNum
        End Get
        Set(ByVal value As String)
            p_RowNum = value
        End Set

    End Property



    Public Property KeyField() As String
        Get
            Return p_KeyField
        End Get
        Set(ByVal value As String)
            p_KeyField = value
        End Set

    End Property

    Public Property Where() As String
        Get
            Return p_Where
        End Get
        Set(ByVal value As String)
            p_Where = value
        End Set
    End Property


    Public Property TableName() As String
        Get
            Return p_TableName
        End Get
        Set(ByVal value As String)
            p_TableName = value
        End Set

    End Property
    

    Private Sub DataNavigator1_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyClass.PositionChanged
        SendToBack()
    End Sub

   
End Class
