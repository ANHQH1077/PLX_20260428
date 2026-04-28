<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraCusForm1


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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraCusForm1))
        Me.cusStatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.cusStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.U_Focus = New U_TextBox.U_TextBox()
        Me.cusStatusStrip1.SuspendLayout()
        CType(Me.U_Focus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cusStatusStrip1
        '
        Me.cusStatusStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cusStatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cusStatusLabel1})
        Me.cusStatusStrip1.Location = New System.Drawing.Point(0, 371)
        Me.cusStatusStrip1.Name = "cusStatusStrip1"
        Me.cusStatusStrip1.Size = New System.Drawing.Size(630, 26)
        Me.cusStatusStrip1.TabIndex = 0
        Me.cusStatusStrip1.Text = "StatusStrip1"
        Me.cusStatusStrip1.Visible = False
        '
        'cusStatusLabel1
        '
        Me.cusStatusLabel1.Name = "cusStatusLabel1"
        Me.cusStatusLabel1.Size = New System.Drawing.Size(162, 21)
        Me.cusStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'Timer1
        '
        '
        'U_Focus
        '
        Me.U_Focus.AllowInsert = True
        Me.U_Focus.AllowUpdate = True
        Me.U_Focus.AutoKeyFix = ""
        Me.U_Focus.AutoKeyName = ""
        Me.U_Focus.BindingSourceName = ""
        Me.U_Focus.ChangeFormStatus = True
        Me.U_Focus.CopyFromItem = ""
        Me.U_Focus.DefaultValue = ""
        Me.U_Focus.FieldName = ""
        Me.U_Focus.FieldType = "C"
        Me.U_Focus.KeyInsert = ""
        Me.U_Focus.LinkLabel = ""
        Me.U_Focus.Location = New System.Drawing.Point(12, 365)
        Me.U_Focus.Name = "U_Focus"
        Me.U_Focus.NoUpdate = "N"
        Me.U_Focus.PrimaryKey = ""
        Me.U_Focus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_Focus.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_Focus.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_Focus.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_Focus.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_Focus.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_Focus.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_Focus.Properties.AutoHeight = False
        Me.U_Focus.Required = ""
        Me.U_Focus.Size = New System.Drawing.Size(0, 31)
        Me.U_Focus.TabIndex = 1
        Me.U_Focus.TableName = ""
        Me.U_Focus.TabStop = False
        Me.U_Focus.UpdateIfNull = ""
        Me.U_Focus.UpdateWhenFormLock = False
        Me.U_Focus.UpperValue = False
        Me.U_Focus.ViewName = ""
        '
        'XtraCusForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 397)
        Me.Controls.Add(Me.U_Focus)
        Me.Controls.Add(Me.cusStatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "XtraCusForm1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.cusStatusStrip1.ResumeLayout(False)
        Me.cusStatusStrip1.PerformLayout()
        CType(Me.U_Focus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub MyMenuItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MnuItem As Windows.Forms.ToolStripMenuItem = CType(sender, Windows.Forms.ToolStripMenuItem)
        Dim p_Form As Object
        p_Form = FindForm()
        p_ShowItemProperty(p_Form)

    End Sub


    Private p_DefaultSave As Boolean = True

    Public Property DefaultSave() As Boolean  'True: Lock form 
        Get
            Return p_DefaultSave
        End Get
        Set(ByVal value As Boolean)
            p_DefaultSave = value
        End Set

    End Property



    Private p_EnterNextControl As Boolean = False

    Public Property EnterNextControl() As Boolean  'True: Lock form 
        Get
            Return p_EnterNextControl
        End Get
        Set(ByVal value As Boolean)
            p_EnterNextControl = value
        End Set

    End Property



    Private p_ShowFormMessage As Boolean = False

    Public Property ShowFormMessage() As Boolean  'True: Lock form 
        Get
            Return p_ShowFormMessage
        End Get
        Set(ByVal value As Boolean)
            p_ShowFormMessage = value
        End Set

    End Property


    Private p_FormDilog As Boolean = False

    Public Property FormDilog() As Boolean  'True: Lock form 
        Get
            Return p_FormDilog
        End Get
        Set(ByVal value As Boolean)
            p_FormDilog = value
        End Set

    End Property



    Private p_RefreshAfterSave As Boolean = True

    Public Property RefreshAfterSave() As Boolean  'True: Lock form 
        Get
            Return p_RefreshAfterSave
        End Get
        Set(ByVal value As Boolean)
            p_RefreshAfterSave = value
        End Set

    End Property


    Private p_ErrorSave As Boolean = True

    Public Property ErrorSave() As Boolean  'True: Lock form 
        Get
            Return p_ErrorSave
        End Get
        Set(ByVal value As Boolean)
            p_ErrorSave = value
        End Set

    End Property


    Private p_DefaultWhere As String = ""

    Public Property DefaultWhere() As String  'Ten button luu thong tin vao CSDL
        Get
            Return p_DefaultWhere
        End Get
        Set(ByVal value As String)
            p_DefaultWhere = value
        End Set

    End Property

    Private p_MenuEdit As Boolean = False

    Public Property MenuEdit() As Boolean  'True: Lock form 
        Get
            Return p_MenuEdit
        End Get
        Set(ByVal value As Boolean)
            p_MenuEdit = value
        End Set

    End Property

    Private p_MenuNavigator As Boolean = False

    Public Property MenuNavigator() As Boolean
        Get
            Return p_MenuNavigator
        End Get
        Set(ByVal value As Boolean)
            p_MenuNavigator = value
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
    Friend WithEvents cusStatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents cusStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents U_Focus As U_TextBox.U_TextBox
    Public Property DefaultFormLoad() As Boolean   '
        Get
            Return p_DefaultFormLoad
        End Get
        Set(ByVal value As Boolean)
            p_DefaultFormLoad = value
        End Set

    End Property
End Class
