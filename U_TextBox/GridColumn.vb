Public Class GridColumn
    Private p_FieldView As String = ""
    Private p_Required As Boolean = False
    Private p_UpdateIfNull As String = ""
    Private p_PrimaryKey As String = ""

    Private p_NoUpdate As String = ""

    Private p_FieldType As String = "C"

    Private p_CFLKeyField As String = ""
    Private p_SQLString As String = ""

    Private p_ChangeFormStatus As Boolean = True

    Private p_UpdateWhenFormLock As Boolean = False

    Private p_CFLReturn0 As String = ""
    Private p_CFLReturn1 As String = ""
    Private p_CFLReturn2 As String = ""
    Private p_CFLReturn3 As String = ""
    Private p_CFLReturn4 As String = ""
    Private p_CFLReturn5 As String = ""
    Private p_CFLReturn6 As String = ""
    Private p_CFLReturn7 As String = ""

    Private p_CFLShowLoad As Boolean = False
    Private p_DefaultButtonClick As Boolean = False
    Private p_ColumnKey As Boolean = False
    Private p_ComboLine As Integer = 5
    Private p_AllowUpdate As Boolean = True
    Private p_AllowInsert As Boolean = True

    Private p_ParentControl As String = ""

    Private p_LocalDecimal As Boolean = False
    Private p_Digit As Boolean = False

    Private p_CFLPage As Boolean = False
    Private p_RefreshSource As Boolean = False

    Private p_FormList As Boolean = False

    Private p_CFLColumnHide As String = ""

    Private p_ShowDataTime As Boolean = False

    Private p_ValidateValue As Boolean = True

    Private p_ShowCalc As Boolean = True

    Private p_SequenceName As String = ""

    Private p_FormarNumber As Boolean = True
    Private p_UpperValue As Boolean = False


    Public Property UpperValue() As Boolean
        Get
            Return p_UpperValue
        End Get
        Set(ByVal value As Boolean)
            p_UpperValue = value
        End Set
    End Property
    Public Property SequenceName() As String
        Get
            Return p_SequenceName
        End Get
        Set(ByVal value As String)
            p_SequenceName = value
        End Set
    End Property


    Public Property FormarNumber() As Boolean
        Get
            Return p_FormarNumber
        End Get
        Set(ByVal value As Boolean)
            p_FormarNumber = value
        End Set
    End Property




    Private p_ShowOnlyTime As Boolean = False
    Public Property ShowOnlyTime() As Boolean
        Get
            Return p_ShowOnlyTime
        End Get
        Set(ByVal value As Boolean)
            p_ShowOnlyTime = value
        End Set
    End Property



    Private p_ButtonClick As Boolean = True
    Public Property ButtonClick() As Boolean
        Get
            Return p_ButtonClick
        End Get
        Set(ByVal value As Boolean)
            p_ButtonClick = value
        End Set
    End Property

    Public Property ShowCalc() As Boolean
        Get
            Return p_ShowCalc
        End Get
        Set(ByVal value As Boolean)
            p_ShowCalc = value
        End Set
    End Property


    Public Property ValidateValue() As Boolean
        Get
            Return p_ValidateValue
        End Get
        Set(ByVal value As Boolean)
            p_ValidateValue = value
        End Set
    End Property

    Public Property ShowDataTime() As Boolean
        Get
            Return p_ShowDataTime
        End Get
        Set(ByVal value As Boolean)
            p_ShowDataTime = value
        End Set
    End Property


    Public Property CFLColumnHide() As String
        Get
            Return p_CFLColumnHide
        End Get
        Set(ByVal value As String)
            p_CFLColumnHide = value
        End Set
    End Property


    Public Property FormList() As Boolean
        Get
            Return p_FormList
        End Get
        Set(ByVal value As Boolean)
            p_FormList = value
        End Set
    End Property


    Public Property RefreshSource() As Boolean
        Get
            Return p_RefreshSource
        End Get
        Set(ByVal value As Boolean)
            p_RefreshSource = value
        End Set
    End Property
    Private p_Decimal As Integer

    Public Property CFLPage() As Boolean
        Get
            Return p_CFLPage
        End Get
        Set(ByVal value As Boolean)
            p_CFLPage = value
        End Set
    End Property

    Public Property NumberDecimal() As Integer
        Get
            Return p_Decimal
        End Get
        Set(ByVal value As Integer)
            p_Decimal = value
        End Set

    End Property


    Public Property Digit() As Boolean
        Get
            Return p_Digit
        End Get
        Set(ByVal value As Boolean)
            p_Digit = value
        End Set
    End Property



    Public Property LocalDecimal() As Boolean
        Get
            Return p_LocalDecimal
        End Get
        Set(ByVal value As Boolean)
            p_LocalDecimal = value
        End Set
    End Property

    Public Property ParentControl() As String
        Get
            Return p_ParentControl
        End Get
        Set(ByVal value As String)
            p_ParentControl = value
        End Set

    End Property


    Public Property AllowUpdate() As Boolean
        Get
            Return p_AllowUpdate
        End Get
        Set(ByVal value As Boolean)
            p_AllowUpdate = value
        End Set
    End Property

    Public Property AllowInsert() As Boolean
        Get
            Return p_AllowInsert
        End Get
        Set(ByVal value As Boolean)
            p_AllowInsert = value
        End Set
    End Property


    Public Property ComboLine() As Integer
        Get
            Return p_ComboLine
        End Get
        Set(ByVal value As Integer)
            p_ComboLine = value
        End Set

    End Property


    Public Property NoUpdate() As String
        Get
            Return p_NoUpdate
        End Get
        Set(ByVal value As String)
            p_NoUpdate = value
        End Set

    End Property

 


    Public Property ColumnKey() As Boolean
        Get
            Return p_ColumnKey
        End Get
        Set(ByVal value As Boolean)
            p_ColumnKey = value
        End Set
    End Property



    Public Property DefaultButtonClick() As Boolean
        Get
            Return p_DefaultButtonClick
        End Get
        Set(ByVal value As Boolean)
            p_DefaultButtonClick = value
        End Set

    End Property

    Public Property CFLShowLoad() As Boolean
        Get
            Return p_CFLShowLoad
        End Get
        Set(ByVal value As Boolean)
            p_CFLShowLoad = value
        End Set

    End Property

    Public Property CFLReturn0() As String
        Get
            Return p_CFLReturn0
        End Get
        Set(ByVal value As String)
            p_CFLReturn0 = value
        End Set
    End Property

    Public Property CFLReturn1() As String
        Get
            Return p_CFLReturn1
        End Get
        Set(ByVal value As String)
            p_CFLReturn1 = value
        End Set
    End Property

    Public Property CFLReturn2() As String
        Get
            Return p_CFLReturn2
        End Get
        Set(ByVal value As String)
            p_CFLReturn2 = value
        End Set
    End Property
    Public Property CFLReturn3() As String
        Get
            Return p_CFLReturn3
        End Get
        Set(ByVal value As String)
            p_CFLReturn3 = value
        End Set
    End Property
    Public Property CFLReturn4() As String
        Get
            Return p_CFLReturn4
        End Get
        Set(ByVal value As String)
            p_CFLReturn4 = value
        End Set
    End Property


    Public Property CFLReturn5() As String
        Get
            Return p_CFLReturn5
        End Get
        Set(ByVal value As String)
            p_CFLReturn5 = value
        End Set
    End Property
    Public Property CFLReturn6() As String
        Get
            Return p_CFLReturn6
        End Get
        Set(ByVal value As String)
            p_CFLReturn6 = value
        End Set
    End Property
    Public Property CFLReturn7() As String
        Get
            Return p_CFLReturn7
        End Get
        Set(ByVal value As String)
            p_CFLReturn7 = value
        End Set
    End Property

    Public Property CFLKeyField() As String
        Get
            Return p_CFLKeyField
        End Get
        Set(ByVal value As String)
            p_CFLKeyField = value
        End Set
    End Property


    Public Property SQLString() As String
        Get
            Return p_SQLString
        End Get
        Set(ByVal value As String)
            p_SQLString = value
        End Set
    End Property


    Public Property UpdateWhenFormLock() As Boolean
        Get
            Return p_UpdateWhenFormLock
        End Get
        Set(ByVal value As Boolean)
            p_UpdateWhenFormLock = value
        End Set

    End Property

    Public Property ChangeFormStatus() As Boolean
        Get
            Return p_ChangeFormStatus
        End Get
        Set(ByVal value As Boolean)
            p_ChangeFormStatus = value
        End Set

    End Property


    Private p_KeyInsert As String = ""
    Public Property KeyInsert() As String
        Get
            Return p_KeyInsert
        End Get
        Set(ByVal value As String)
            p_KeyInsert = value
        End Set

    End Property


    Private p_CopyFromItem As String = ""
    Public Property CopyFromItem() As String
        Get
            Return p_CopyFromItem
        End Get
        Set(ByVal value As String)
            p_CopyFromItem = value
        End Set

    End Property


    Public Property FieldType() As String
        Get
            Return p_FieldType
        End Get
        Set(ByVal value As String)
            p_FieldType = value
        End Set

    End Property

   



    Public Property Required() As Boolean
        Get
            Return p_Required
        End Get
        Set(ByVal value As Boolean)
            p_Required = value
        End Set

    End Property


    Public Property UpdateIfNull() As String
        Get
            Return p_UpdateIfNull
        End Get
        Set(ByVal value As String)
            p_UpdateIfNull = value
        End Set

    End Property

    Public Property FieldView() As String
        Get
            Return p_FieldView
        End Get
        Set(ByVal value As String)
            p_FieldView = value
        End Set

    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
      

        ' Add any initialization after the InitializeComponent() call.

    End Sub


End Class
