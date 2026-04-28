<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraForm1
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraForm1))
        Me.SuspendLayout()
        '
        'XtraForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 477)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "XtraForm1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "XtraForm1"
        Me.ResumeLayout(False)

    End Sub

    Private Sub MyMenuItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MnuItem As Windows.Forms.ToolStripMenuItem = CType(sender, Windows.Forms.ToolStripMenuItem)
        Dim p_Form As Object
        p_Form = FindForm()
        p_ShowItemProperty(p_Form)
       
    End Sub

    Private p_DefaultWhere As String

    Public Property DefaultWhere() As String  'Ten button luu thong tin vao CSDL
        Get
            Return p_DefaultWhere
        End Get
        Set(ByVal value As String)
            p_DefaultWhere = value
        End Set

    End Property

    Private p_FormLock As Boolean = False

    Public Property FormLock() As Boolean  'True: Lock form 
        Get
            Return p_FormLock
        End Get
        Set(ByVal value As Boolean)
            p_FormLock = value
        End Set

    End Property

    Private p_SequenceName As String
    Public Property SequenceName() As String  'Ten Sequen lay ID
        Get
            Return p_SequenceName
        End Get
        Set(ByVal value As String)
            p_SequenceName = value
        End Set

    End Property

    Private p_FormEdit As Boolean = True   'True neu Form  cho sua thong tin

    Public Property FormEdit() As Boolean
        Get
            Return p_FormEdit
        End Get
        Set(ByVal value As Boolean)
            p_FormEdit = value
        End Set

    End Property

    Private p_ButtonSave As String = "BtnOk"

    Public Property ButtonSave() As String  'Ten button luu thong tin vao CSDL
        Get
            Return p_ButtonSave
        End Get
        Set(ByVal value As String)
            p_ButtonSave = value
        End Set

    End Property

    Private p_FormItemKey As String

    Public Property FormItemKey() As String  'Ten Item la Key cua Form
        Get
            Return p_FormItemKey
        End Get
        Set(ByVal value As String)
            p_FormItemKey = value
        End Set

    End Property



    Private p_HeaderSource As String = ""   'Ten bang hoac view


    Public Property HeaderSource() As String
        Get
            Return p_HeaderSource
        End Get
        Set(ByVal value As String)
            p_HeaderSource = value
        End Set

    End Property

    Private p_FormStatus As Boolean = False   'True neu nhu form trang thai  Update


    Public Property FormStatus() As Boolean
        Get
            Return p_FormStatus
        End Get
        Set(ByVal value As Boolean)
            p_FormStatus = value
        End Set

    End Property

    Private p_SetSourceItem As Boolean = False   'True: set Source lai cho Item


    Public Property SetSourceItem() As Boolean
        Get
            Return p_SetSourceItem
        End Get
        Set(ByVal value As Boolean)
            p_SetSourceItem = value
        End Set

    End Property

    Private p_GetB1 As Boolean = False   'True: Nguon lay tren B1


    Public Property GetB1() As Boolean
        Get
            Return p_GetB1
        End Get
        Set(ByVal value As Boolean)
            p_GetB1 = value
        End Set

    End Property

    Private p_CaptionUpd As String = "&Lưu"
    Public Property CaptionUpd() As String
        Get
            Return p_CaptionUpd
        End Get
        Set(ByVal value As String)
            p_CaptionUpd = value
        End Set

    End Property

    Private p_CaptionAdd As String = "&Thêm mới"
    Public Property CaptionAdd() As String  '
        Get
            Return p_CaptionAdd
        End Get
        Set(ByVal value As String)
            p_CaptionAdd = value
        End Set

    End Property

    Private p_DefaultFormLoad As Boolean = True
    Public Property DefaultFormLoad() As Boolean   '
        Get
            Return p_DefaultFormLoad
        End Get
        Set(ByVal value As Boolean)
            p_DefaultFormLoad = value
        End Set

    End Property
End Class
