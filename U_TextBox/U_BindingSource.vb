Imports System.Windows.Forms


Public Class U_BindingSource
    Private p_ViewName As String = ""
    Private p_TableName As String = ""
    Private p_OrderBy As String = ""
    Private p_Where As String
    Private p_LastQuery As String = ""


    Private p_GetB1 As Boolean = False

    Private p_CompanyCode As String = ""

    Private p_FormName As String = ""

    Private p_Loading As Boolean = True
    Public Property Loading() As Boolean
        Get
            Return p_Loading
        End Get
        Set(ByVal value As Boolean)
            p_Loading = value
        End Set
    End Property


    Private p_GridSource As Boolean = True
    Public Property GridSource() As Boolean
        Get
            Return p_GridSource
        End Get
        Set(ByVal value As Boolean)
            p_GridSource = value
        End Set
    End Property


    Public Property FormName() As String
        Get
            Return p_FormName
        End Get
        Set(ByVal value As String)
            p_FormName = value
        End Set

    End Property

    Private p_BindingSourceName As String = ""
    Public Property BindingSourceName() As String
        Get
            Return p_BindingSourceName
        End Get
        Set(ByVal value As String)
            p_BindingSourceName = value
        End Set
    End Property



    Public Property CompanyCode() As String
        Get
            Return p_CompanyCode
        End Get
        Set(ByVal value As String)
            p_CompanyCode = value
        End Set
    End Property



    Public Property GetB1() As Boolean
        Get
            Return p_GetB1
        End Get
        Set(ByVal value As Boolean)
            p_GetB1 = value
        End Set
    End Property





    Public Property LastQuery() As String
        Get
            Return p_LastQuery
        End Get
        Set(ByVal value As String)
            p_LastQuery = value
        End Set
    End Property



    Public Property ViewName() As String
        Get
            Return p_ViewName
        End Get
        Set(ByVal value As String)
            p_ViewName = value
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


    Public Property OrderBy() As String
        Get
            Return p_OrderBy
        End Get
        Set(ByVal value As String)
            p_OrderBy = value
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


    Private Sub U_BindingSource1_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.CurrentChanged
       

    End Sub

    Private Sub U_BindingSource1_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PositionChanged
        Dim p_Form As Object
        Dim p_FormName As String

        ' Dim frm As Form
        Dim i As Integer = 0
        Dim found As Boolean = False
        If Me.Loading = True Then Exit Sub

        p_FormName = UCase(Me.FormName)
        If p_FormName.ToString.Trim = "" Then Exit Sub


        'Try
        '    If p_Form.g_FormLoad = True Then Exit Sub
        'Catch ex As Exception
        '    Exit Sub
        'End Try
        'If Me.Loading = True Then

        ' p_Form.XtraLoadGrid(True)
        'End If
        ' p_Form.g_RecodeMove = False

        If Me.GridSource = True Then
            Exit Sub
        End If

        While i < Application.OpenForms.Count
            p_Form = Application.OpenForms.Item(i)
            If UCase(p_Form.Name) = p_FormName Then
                Try
                    If p_Form.g_FormLoad = True Then Exit Sub
                Catch ex As Exception
                    Continue While
                End Try

                If p_Form.FormStatus = False Or (p_Form.g_FormAddnew = True And p_Form.FormStatus = False) Then
                    p_Form.XtraLoadGrid(True)
                End If
                p_Form.g_RecodeMove = False
            End If
            i += 1
        End While

    End Sub
End Class
