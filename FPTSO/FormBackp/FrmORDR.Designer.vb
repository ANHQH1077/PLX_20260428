<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmORDR
    Inherits DevExpress.XtraEditors.XtraForm
    'Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private p_FormEdit As Boolean = True   'True neu Form  cho sua thong tin

    Public Property FormEdit() As Boolean
        Get
            Return p_FormEdit
        End Get
        Set(ByVal value As Boolean)
            p_FormEdit = value
        End Set

    End Property

    Private p_ButtonSave As String

    Public Property ButtonSave() As String  'Ten button luu thong tin vao CSDL
        Get
            Return p_ButtonSave
        End Get
        Set(ByVal value As String)
            p_ButtonSave = value
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmORDR))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.U_CrdName = New U_TextBox.U_TextBox()
        Me.U_TextBox3 = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.U_SyBill = New U_TextBox.U_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.U_Desc = New U_TextBox.U_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.U_PriLis = New U_TextBox.U_Combobox()
        Me.U_NuBill = New U_TextBox.U_TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.U_SOType = New U_TextBox.U_Combobox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComCodeKey = New U_TextBox.U_TextBox()
        Me.U_ComCode = New U_TextBox.U_TextBox()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.U_TrueDBGrid1 = New U_TextBox.U_TrueDBGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
        Me.U_DateEdit1 = New U_TextBox.U_DateEdit()
        Me.U_CtOCod = New U_TextBox.U_Combobox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.U_CrOCod = New U_TextBox.U_ButtonEdit()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.U_Inv3rd = New U_TextBox.U_CheckBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.U_ExDate = New U_TextBox.U_DateEdit()
        Me.U_DocTime = New U_TextBox.U_NumericEdit()
        Me.U_INV_TYPE = New U_TextBox.U_Combobox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.U_Forpay = New U_TextBox.U_Combobox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.U_MetPay = New U_TextBox.U_Combobox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.U_TerPay = New U_TextBox.U_Combobox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.U_DocRat = New U_TextBox.U_NumericEdit()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.U_DocCur = New U_TextBox.U_Combobox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.U_AcDate = New U_TextBox.U_DateEdit()
        Me.U_RepNum = New U_TextBox.U_NumericEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.U_Status = New U_TextBox.U_Combobox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.U_ItmOut1 = New U_TextBox.U_Combobox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.U_StsRet = New U_TextBox.U_CheckBox()
        Me.U_ReveRe = New U_TextBox.U_CheckBox()
        Me.U_BusLin = New U_TextBox.U_Combobox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.U_CrDate = New U_TextBox.U_DateEdit()
        Me.XtraTabPage7 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl2 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage8 = New DevExpress.XtraTab.XtraTabPage()
        Me.U_DownAcTran = New U_TextBox.U_ButtonEdit()
        Me.AccDownPay = New U_TextBox.U_ButtonEdit()
        Me.U_DownAcBank = New U_TextBox.U_Combobox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.U_DownBankTs = New U_TextBox.U_Combobox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.U_DownRefNTr = New U_TextBox.U_TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.U_DownDateTs = New U_TextBox.U_DateEdit()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.U_DownMoTran = New U_TextBox.U_NumericEdit()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MDownPay = New U_TextBox.U_NumericEdit()
        Me.XtraTabPage9 = New DevExpress.XtraTab.XtraTabPage()
        Me.U_TrueDBGrid3 = New U_TextBox.U_TrueDBGrid()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage10 = New DevExpress.XtraTab.XtraTabPage()
        Me.U_TrueDBGrid2 = New U_TextBox.U_TrueDBGrid()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl3 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage11 = New DevExpress.XtraTab.XtraTabPage()
        Me.U_ReAcTran = New U_TextBox.U_ButtonEdit()
        Me.AccReToTal = New U_TextBox.U_ButtonEdit()
        Me.U_ReAcBank = New U_TextBox.U_Combobox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.U_ReBankTs = New U_TextBox.U_Combobox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.U_ReRefNTr = New U_TextBox.U_TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.U_ReDateTs = New U_TextBox.U_DateEdit()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.U_ReMoTran = New U_TextBox.U_NumericEdit()
        Me.MReToTal = New U_TextBox.U_NumericEdit()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.XtraTabPage12 = New DevExpress.XtraTab.XtraTabPage()
        Me.U_TrueDBGrid4 = New U_TextBox.U_TrueDBGrid()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage13 = New DevExpress.XtraTab.XtraTabPage()
        Me.U_TrueDBGrid5 = New U_TextBox.U_TrueDBGrid()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.U_Country = New U_TextBox.U_TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.U_District = New U_TextBox.U_TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.U_AdrDel = New U_TextBox.U_TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.U_Phone = New U_TextBox.U_TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.U_Receive = New U_TextBox.U_TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.U_Note = New U_TextBox.U_TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.U_DateDe = New U_TextBox.U_DateEdit()
        Me.U_Transf = New U_TextBox.U_Combobox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.U_PerDel = New U_TextBox.U_Combobox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.U_ShipTyp = New U_TextBox.U_Combobox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.XtraTabPage5 = New DevExpress.XtraTab.XtraTabPage()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.U_AmountP = New U_TextBox.U_NumericEdit()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.U_AmountN = New U_TextBox.U_NumericEdit()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.U_Month = New U_TextBox.U_NumericEdit()
        Me.U_ProNum = New U_TextBox.U_TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.U_Program = New U_TextBox.U_ButtonEdit()
        Me.U_TextBox2 = New U_TextBox.U_TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.U_CardCode = New U_TextBox.U_ButtonEdit()
        Me.U_TextBox1 = New U_TextBox.U_TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.XtraTabPage6 = New DevExpress.XtraTab.XtraTabPage()
        Me.U_EStatus = New U_TextBox.U_Combobox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.U_ErefNum = New U_TextBox.U_TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.U_EAcDate = New U_TextBox.U_DateEdit()
        Me.U_EAcount = New U_TextBox.U_TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.U_EBank = New U_TextBox.U_TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.U_EAmount = New U_TextBox.U_NumericEdit()
        Me.U_EMetPay = New U_TextBox.U_Combobox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton11 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.U_UserLogin = New U_TextBox.U_TextBox()
        Me.U_ShpCod = New U_TextBox.U_Combobox()
        Me.SimpleButton13 = New DevExpress.XtraEditors.SimpleButton()
        Me.U_TMonPr = New U_TextBox.U_NumericEdit()
        Me.U_MonPer = New U_TextBox.U_NumericEdit()
        Me.U_TMonTX = New U_TextBox.U_NumericEdit()
        Me.U_DownPay = New U_TextBox.U_NumericEdit()
        Me.U_TmonBi = New U_TextBox.U_NumericEdit()
        Me.U_PerBil = New U_TextBox.U_NumericEdit()
        Me.U_SCTmonBi = New U_TextBox.U_NumericEdit()
        Me.U_SCDownPay = New U_TextBox.U_NumericEdit()
        Me.U_SCTMonTX = New U_TextBox.U_NumericEdit()
        Me.U_SCMonPer = New U_TextBox.U_NumericEdit()
        Me.U_SCTMonPr = New U_TextBox.U_NumericEdit()
        Me.DocNum = New U_TextBox.U_NumericEdit()
        Me.U_CrdCod = New U_TextBox.U_TextBox()
        Me.StatusAppr = New U_TextBox.U_TextBox()
        Me.DocEntry = New U_TextBox.U_NumericEdit()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.U_CtName = New U_TextBox.U_TextBox()
        Me.Code = New U_TextBox.U_ButtonEdit()
        Me.U_EplCod = New U_TextBox.U_Combobox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.U_SlpTmp = New U_TextBox.U_TextBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.U_CrdName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_SyBill.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Desc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_PriLis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_NuBill.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_SOType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComCodeKey.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ComCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.U_TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage4.SuspendLayout()
        CType(Me.U_DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CtOCod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CrOCod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Inv3rd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ExDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ExDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DocTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_INV_TYPE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Forpay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_MetPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TerPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DocRat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DocCur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_AcDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_AcDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_RepNum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Status.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ItmOut1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_StsRet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ReveRe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_BusLin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CrDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CrDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage7.SuspendLayout()
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl2.SuspendLayout()
        Me.XtraTabPage8.SuspendLayout()
        CType(Me.U_DownAcTran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccDownPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DownAcBank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DownBankTs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DownRefNTr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DownDateTs.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DownDateTs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DownMoTran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MDownPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage9.SuspendLayout()
        CType(Me.U_TrueDBGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage10.SuspendLayout()
        CType(Me.U_TrueDBGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.XtraTabControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl3.SuspendLayout()
        Me.XtraTabPage11.SuspendLayout()
        CType(Me.U_ReAcTran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccReToTal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ReAcBank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ReBankTs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ReRefNTr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ReDateTs.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ReDateTs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ReMoTran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MReToTal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage12.SuspendLayout()
        CType(Me.U_TrueDBGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage13.SuspendLayout()
        CType(Me.U_TrueDBGrid5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.U_Country.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_District.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_AdrDel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Phone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Receive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Note.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateDe.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateDe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Transf.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_PerDel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ShipTyp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage5.SuspendLayout()
        CType(Me.U_AmountP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_AmountN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Month.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ProNum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Program.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CardCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage6.SuspendLayout()
        CType(Me.U_EStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ErefNum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_EAcDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_EAcDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_EAcount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_EBank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_EAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_EMetPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_UserLogin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ShpCod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TMonPr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_MonPer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TMonTX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DownPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TmonBi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_PerBil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_SCTmonBi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_SCDownPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_SCTMonTX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_SCMonPer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_SCTMonPr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocNum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CrdCod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusAppr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocEntry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Code.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_EplCod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_SlpTmp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 271
        Me.Label1.Text = "Khách hàng"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(689, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 288
        Me.Label4.Text = "Cửa hàng"
        '
        'U_CrdName
        '
        Me.U_CrdName.Enabled = False
        Me.U_CrdName.FieldName = "U_CrdName"
        Me.U_CrdName.FieldType = "C"
        Me.U_CrdName.KeyInsert = ""
        Me.U_CrdName.Location = New System.Drawing.Point(108, 26)
        Me.U_CrdName.Name = "U_CrdName"
        Me.U_CrdName.NoUpdate = "N"
        Me.U_CrdName.PrimaryKey = ""
        Me.U_CrdName.Required = "Y"
        Me.U_CrdName.Size = New System.Drawing.Size(351, 20)
        Me.U_CrdName.TabIndex = 289
        Me.U_CrdName.TableName = "FPTORDR"
        Me.U_CrdName.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_CrdName)"
        Me.U_CrdName.UpdateIfNull = ""
        Me.U_CrdName.ViewName = "FPTORDR"
        '
        'U_TextBox3
        '
        Me.U_TextBox3.Enabled = False
        Me.U_TextBox3.FieldName = "U_CrdCard"
        Me.U_TextBox3.FieldType = "C"
        Me.U_TextBox3.KeyInsert = ""
        Me.U_TextBox3.Location = New System.Drawing.Point(108, 68)
        Me.U_TextBox3.Name = "U_TextBox3"
        Me.U_TextBox3.NoUpdate = "N"
        Me.U_TextBox3.PrimaryKey = ""
        Me.U_TextBox3.Required = ""
        Me.U_TextBox3.Size = New System.Drawing.Size(114, 20)
        Me.U_TextBox3.TabIndex = 291
        Me.U_TextBox3.TableName = "FPTORDR"
        Me.U_TextBox3.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_CrdCard)"
        Me.U_TextBox3.UpdateIfNull = ""
        Me.U_TextBox3.ViewName = "FPTORDR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 290
        Me.Label2.Text = "Hạng thẻ"
        '
        'U_SyBill
        '
        Me.U_SyBill.FieldName = "U_SyBill"
        Me.U_SyBill.FieldType = "C"
        Me.U_SyBill.KeyInsert = ""
        Me.U_SyBill.Location = New System.Drawing.Point(1100, 68)
        Me.U_SyBill.Name = "U_SyBill"
        Me.U_SyBill.NoUpdate = "N"
        Me.U_SyBill.PrimaryKey = ""
        Me.U_SyBill.Required = ""
        Me.U_SyBill.Size = New System.Drawing.Size(153, 20)
        Me.U_SyBill.TabIndex = 295
        Me.U_SyBill.TableName = "FPTORDR"
        Me.U_SyBill.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_SyBill)"
        Me.U_SyBill.UpdateIfNull = ""
        Me.U_SyBill.ViewName = "FPTORDR"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1009, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 294
        Me.Label5.Text = "Ký hiệu hóa đơn"
        '
        'U_Desc
        '
        Me.U_Desc.FieldName = "U_Desc"
        Me.U_Desc.FieldType = "C"
        Me.U_Desc.KeyInsert = ""
        Me.U_Desc.Location = New System.Drawing.Point(792, 89)
        Me.U_Desc.Name = "U_Desc"
        Me.U_Desc.NoUpdate = "N"
        Me.U_Desc.PrimaryKey = ""
        Me.U_Desc.Required = ""
        Me.U_Desc.Size = New System.Drawing.Size(460, 20)
        Me.U_Desc.TabIndex = 299
        Me.U_Desc.TableName = "FPTORDR"
        Me.U_Desc.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Desc)"
        Me.U_Desc.UpdateIfNull = ""
        Me.U_Desc.ViewName = "FPTORDR"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(689, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 298
        Me.Label7.Text = "Diễn giải"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(1009, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 304
        Me.Label10.Text = "Bảng giá"
        '
        'U_PriLis
        '
        Me.U_PriLis.DisplayField = ""
        Me.U_PriLis.DropDownRow = 10
        Me.U_PriLis.FieldName = "U_PriLis"
        Me.U_PriLis.FieldType = "N"
        Me.U_PriLis.ItemValue = ""
        Me.U_PriLis.KeyInsert = ""
        Me.U_PriLis.Location = New System.Drawing.Point(1100, 47)
        Me.U_PriLis.Name = "U_PriLis"
        Me.U_PriLis.NoUpdate = ""
        Me.U_PriLis.PrimaryKey = ""
        Me.U_PriLis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_PriLis.Properties.NullText = ""
        Me.U_PriLis.Properties.ShowHeader = False
        Me.U_PriLis.Required = "Y"
        Me.U_PriLis.ShowHeader = False
        Me.U_PriLis.Size = New System.Drawing.Size(153, 20)
        Me.U_PriLis.SQL_String = resources.GetString("U_PriLis.SQL_String")
        Me.U_PriLis.TabIndex = 305
        Me.U_PriLis.TableName = "FPTORDR"
        Me.U_PriLis.ToolTip = "NAME(U_PriLis) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_PriLis)"
        Me.U_PriLis.UpdateIfNull = ""
        Me.U_PriLis.ValueField = ""
        Me.U_PriLis.ViewName = "FPTORDR"
        '
        'U_NuBill
        '
        Me.U_NuBill.FieldName = "U_NuBill"
        Me.U_NuBill.FieldType = "C"
        Me.U_NuBill.KeyInsert = ""
        Me.U_NuBill.Location = New System.Drawing.Point(792, 68)
        Me.U_NuBill.Name = "U_NuBill"
        Me.U_NuBill.NoUpdate = "N"
        Me.U_NuBill.PrimaryKey = ""
        Me.U_NuBill.Required = ""
        Me.U_NuBill.Size = New System.Drawing.Size(209, 20)
        Me.U_NuBill.TabIndex = 307
        Me.U_NuBill.TableName = "FPTORDR"
        Me.U_NuBill.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_NuBill)"
        Me.U_NuBill.UpdateIfNull = ""
        Me.U_NuBill.ViewName = "FPTORDR"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(689, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 306
        Me.Label11.Text = "Số hóa đơn"
        '
        'U_SOType
        '
        Me.U_SOType.DisplayField = ""
        Me.U_SOType.DropDownRow = 10
        Me.U_SOType.FieldName = "U_SOType"
        Me.U_SOType.FieldType = "C"
        Me.U_SOType.ItemValue = ""
        Me.U_SOType.KeyInsert = ""
        Me.U_SOType.Location = New System.Drawing.Point(792, 47)
        Me.U_SOType.Name = "U_SOType"
        Me.U_SOType.NoUpdate = ""
        Me.U_SOType.PrimaryKey = ""
        Me.U_SOType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_SOType.Properties.NullText = ""
        Me.U_SOType.Properties.ShowHeader = False
        Me.U_SOType.Required = "Y"
        Me.U_SOType.ShowHeader = False
        Me.U_SOType.Size = New System.Drawing.Size(209, 20)
        Me.U_SOType.SQL_String = ""
        Me.U_SOType.TabIndex = 309
        Me.U_SOType.TableName = "FPTORDR"
        Me.U_SOType.ToolTip = "NAME(U_SOType) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_SOType)"
        Me.U_SOType.UpdateIfNull = ""
        Me.U_SOType.ValueField = ""
        Me.U_SOType.ViewName = "FPTORDR"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(689, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 308
        Me.Label12.Text = "Loại đơn hàng"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1009, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 312
        Me.Label14.Text = "Số đơn hàng"
        '
        'ComCodeKey
        '
        Me.ComCodeKey.FieldName = ""
        Me.ComCodeKey.FieldType = "C"
        Me.ComCodeKey.KeyInsert = ""
        Me.ComCodeKey.Location = New System.Drawing.Point(768, 0)
        Me.ComCodeKey.Name = "ComCodeKey"
        Me.ComCodeKey.NoUpdate = "N"
        Me.ComCodeKey.PrimaryKey = ""
        Me.ComCodeKey.Required = ""
        Me.ComCodeKey.Size = New System.Drawing.Size(0, 20)
        Me.ComCodeKey.TabIndex = 325
        Me.ComCodeKey.TableName = ""
        Me.ComCodeKey.ToolTip = "NAME(U_TextBox) VIEW() TAB() FIELD ()"
        Me.ComCodeKey.UpdateIfNull = ""
        Me.ComCodeKey.ViewName = ""
        '
        'U_ComCode
        '
        Me.U_ComCode.FieldName = "U_ComCode"
        Me.U_ComCode.FieldType = "C"
        Me.U_ComCode.KeyInsert = ""
        Me.U_ComCode.Location = New System.Drawing.Point(394, -2)
        Me.U_ComCode.Name = "U_ComCode"
        Me.U_ComCode.NoUpdate = "N"
        Me.U_ComCode.PrimaryKey = ""
        Me.U_ComCode.Required = "Y"
        Me.U_ComCode.Size = New System.Drawing.Size(0, 20)
        Me.U_ComCode.TabIndex = 326
        Me.U_ComCode.TableName = ""
        Me.U_ComCode.ToolTip = "NAME(U_TextBox) VIEW() TAB() FIELD (U_ComCode)"
        Me.U_ComCode.UpdateIfNull = ""
        Me.U_ComCode.ViewName = ""
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XtraTabControl1.Appearance.Options.UseBackColor = True
        Me.XtraTabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 125)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1252, 278)
        Me.XtraTabControl1.TabIndex = 327
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage4, Me.XtraTabPage7, Me.XtraTabPage3, Me.XtraTabPage2, Me.XtraTabPage5, Me.XtraTabPage6})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.LightGray
        Me.XtraTabPage1.Appearance.PageClient.Options.UseBackColor = True
        Me.XtraTabPage1.Controls.Add(Me.U_TrueDBGrid1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1246, 252)
        Me.XtraTabPage1.Text = "Nội dung"
        '
        'U_TrueDBGrid1
        '
        Me.U_TrueDBGrid1.AllowInsert = "Y"
        Me.U_TrueDBGrid1.ColumnAutoWidth = "N"
        Me.U_TrueDBGrid1.ColumnEnableUpdate = "A"
        Me.U_TrueDBGrid1.ColumnKey = "ID"
        Me.U_TrueDBGrid1.ColumnKeyIns = "N"
        Me.U_TrueDBGrid1.ColumnKeyType = "N"
        Me.U_TrueDBGrid1.ColumnVisibleUpdate = "A"
        Me.U_TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.U_TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.U_TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.U_TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.U_TrueDBGrid1.EmbeddedNavigator.Buttons.Next.Visible = False
        Me.U_TrueDBGrid1.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.U_TrueDBGrid1.Location = New System.Drawing.Point(0, 0)
        Me.U_TrueDBGrid1.MainView = Me.GridView1
        Me.U_TrueDBGrid1.Name = "U_TrueDBGrid1"
        Me.U_TrueDBGrid1.ObjectChild = True
        Me.U_TrueDBGrid1.OrderBy = ""
        Me.U_TrueDBGrid1.ParentItem = ""
        Me.U_TrueDBGrid1.Size = New System.Drawing.Size(1244, 252)
        Me.U_TrueDBGrid1.TabIndex = 0
        Me.U_TrueDBGrid1.TableName = "FPTRDR1"
        Me.U_TrueDBGrid1.UseEmbeddedNavigator = True
        Me.U_TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.U_TrueDBGrid1.ViewName = "FPTRDR1_V"
        Me.U_TrueDBGrid1.Where = "DocEntry=:DocEntry"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.U_TrueDBGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'XtraTabPage4
        '
        Me.XtraTabPage4.Controls.Add(Me.U_DateEdit1)
        Me.XtraTabPage4.Controls.Add(Me.U_CtOCod)
        Me.XtraTabPage4.Controls.Add(Me.Label44)
        Me.XtraTabPage4.Controls.Add(Me.U_CrOCod)
        Me.XtraTabPage4.Controls.Add(Me.Label43)
        Me.XtraTabPage4.Controls.Add(Me.Label42)
        Me.XtraTabPage4.Controls.Add(Me.U_Inv3rd)
        Me.XtraTabPage4.Controls.Add(Me.Label41)
        Me.XtraTabPage4.Controls.Add(Me.U_ExDate)
        Me.XtraTabPage4.Controls.Add(Me.U_DocTime)
        Me.XtraTabPage4.Controls.Add(Me.U_INV_TYPE)
        Me.XtraTabPage4.Controls.Add(Me.Label40)
        Me.XtraTabPage4.Controls.Add(Me.U_Forpay)
        Me.XtraTabPage4.Controls.Add(Me.Label37)
        Me.XtraTabPage4.Controls.Add(Me.U_MetPay)
        Me.XtraTabPage4.Controls.Add(Me.Label38)
        Me.XtraTabPage4.Controls.Add(Me.U_TerPay)
        Me.XtraTabPage4.Controls.Add(Me.Label39)
        Me.XtraTabPage4.Controls.Add(Me.U_DocRat)
        Me.XtraTabPage4.Controls.Add(Me.Label36)
        Me.XtraTabPage4.Controls.Add(Me.U_DocCur)
        Me.XtraTabPage4.Controls.Add(Me.Label35)
        Me.XtraTabPage4.Controls.Add(Me.Label34)
        Me.XtraTabPage4.Controls.Add(Me.Label33)
        Me.XtraTabPage4.Controls.Add(Me.U_AcDate)
        Me.XtraTabPage4.Controls.Add(Me.U_RepNum)
        Me.XtraTabPage4.Controls.Add(Me.Label9)
        Me.XtraTabPage4.Controls.Add(Me.Label60)
        Me.XtraTabPage4.Controls.Add(Me.Label59)
        Me.XtraTabPage4.Controls.Add(Me.U_Status)
        Me.XtraTabPage4.Controls.Add(Me.Label18)
        Me.XtraTabPage4.Controls.Add(Me.U_ItmOut1)
        Me.XtraTabPage4.Controls.Add(Me.Label15)
        Me.XtraTabPage4.Controls.Add(Me.U_StsRet)
        Me.XtraTabPage4.Controls.Add(Me.U_ReveRe)
        Me.XtraTabPage4.Controls.Add(Me.U_BusLin)
        Me.XtraTabPage4.Controls.Add(Me.Label8)
        Me.XtraTabPage4.Controls.Add(Me.Label6)
        Me.XtraTabPage4.Controls.Add(Me.U_CrDate)
        Me.XtraTabPage4.Name = "XtraTabPage4"
        Me.XtraTabPage4.Size = New System.Drawing.Size(1246, 252)
        Me.XtraTabPage4.Text = "Thông tin đơn hàng"
        '
        'U_DateEdit1
        '
        Me.U_DateEdit1.EditValue = Nothing
        Me.U_DateEdit1.FieldName = ""
        Me.U_DateEdit1.FieldType = "D"
        Me.U_DateEdit1.KeyInsert = ""
        Me.U_DateEdit1.Location = New System.Drawing.Point(547, 191)
        Me.U_DateEdit1.Name = "U_DateEdit1"
        Me.U_DateEdit1.NoUpdate = ""
        Me.U_DateEdit1.PrimaryKey = ""
        Me.U_DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_DateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_DateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_DateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_DateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_DateEdit1.Required = ""
        Me.U_DateEdit1.Size = New System.Drawing.Size(100, 20)
        Me.U_DateEdit1.TabIndex = 409
        Me.U_DateEdit1.TableName = ""
        Me.U_DateEdit1.ToolTip = "NAME(U_DateEdit1) VIEW() TAB() FIELD ()"
        Me.U_DateEdit1.UpdateIfNull = ""
        Me.U_DateEdit1.ViewName = ""
        '
        'U_CtOCod
        '
        Me.U_CtOCod.DisplayField = ""
        Me.U_CtOCod.DropDownRow = 10
        Me.U_CtOCod.FieldName = "U_CtOCod"
        Me.U_CtOCod.FieldType = "N"
        Me.U_CtOCod.ItemValue = ""
        Me.U_CtOCod.KeyInsert = ""
        Me.U_CtOCod.Location = New System.Drawing.Point(150, 195)
        Me.U_CtOCod.Name = "U_CtOCod"
        Me.U_CtOCod.NoUpdate = ""
        Me.U_CtOCod.PrimaryKey = ""
        Me.U_CtOCod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_CtOCod.Properties.NullText = ""
        Me.U_CtOCod.Properties.ShowHeader = False
        Me.U_CtOCod.Required = "N"
        Me.U_CtOCod.ShowHeader = False
        Me.U_CtOCod.Size = New System.Drawing.Size(180, 20)
        Me.U_CtOCod.SQL_String = ""
        Me.U_CtOCod.TabIndex = 407
        Me.U_CtOCod.TableName = "FPTORDR"
        Me.U_CtOCod.ToolTip = "NAME(U_CtOCod) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_CtOCod)"
        Me.U_CtOCod.UpdateIfNull = ""
        Me.U_CtOCod.ValueField = ""
        Me.U_CtOCod.ViewName = "FPTORDR"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(13, 198)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(122, 13)
        Me.Label44.TabIndex = 408
        Me.Label44.Text = "Người liên hệ in hóa đơn"
        '
        'U_CrOCod
        '
        Me.U_CrOCod.FieldName = "U_CrOCod"
        Me.U_CrOCod.FieldType = "C"
        Me.U_CrOCod.ItemReturn1 = ""
        Me.U_CrOCod.ItemReturn2 = ""
        Me.U_CrOCod.ItemReturn3 = ""
        Me.U_CrOCod.KeyInsert = ""
        Me.U_CrOCod.Location = New System.Drawing.Point(150, 174)
        Me.U_CrOCod.Name = "U_CrOCod"
        Me.U_CrOCod.NoUpdate = "N"
        Me.U_CrOCod.PrimaryKey = ""
        Me.U_CrOCod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_CrOCod.Required = ""
        Me.U_CrOCod.ShowLoad = False
        Me.U_CrOCod.Size = New System.Drawing.Size(178, 20)
        Me.U_CrOCod.SqlFielKey = ""
        Me.U_CrOCod.SqlString = ""
        Me.U_CrOCod.TabIndex = 406
        Me.U_CrOCod.TableName = "FPTORDR"
        Me.U_CrOCod.ToolTip = "NAME(U_CrOCod) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_CrOCod)"
        Me.U_CrOCod.UpdateIfNull = ""
        Me.U_CrOCod.ViewName = "FPTORDR"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(13, 177)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(105, 13)
        Me.Label43.TabIndex = 405
        Me.Label43.Text = "Mã khách in hóa đơn"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(13, 156)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(109, 13)
        Me.Label42.TabIndex = 404
        Me.Label42.Text = "In hóa đơn bên thứ 3"
        '
        'U_Inv3rd
        '
        Me.U_Inv3rd.CheckValue = "Y"
        Me.U_Inv3rd.FieldName = "U_Inv3rd"
        Me.U_Inv3rd.FieldType = "C"
        Me.U_Inv3rd.ItemValue = ""
        Me.U_Inv3rd.KeyInsert = ""
        Me.U_Inv3rd.Location = New System.Drawing.Point(150, 153)
        Me.U_Inv3rd.Name = "U_Inv3rd"
        Me.U_Inv3rd.NoUpdate = ""
        Me.U_Inv3rd.PrimaryKey = ""
        Me.U_Inv3rd.Properties.Caption = ""
        Me.U_Inv3rd.Required = ""
        Me.U_Inv3rd.Size = New System.Drawing.Size(20, 19)
        Me.U_Inv3rd.TabIndex = 403
        Me.U_Inv3rd.TableName = "FPTORDR"
        Me.U_Inv3rd.ToolTip = "NAME(U_Inv3rd) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Inv3rd) VALUE(False)"
        Me.U_Inv3rd.UnCheckValue = "N"
        Me.U_Inv3rd.UpdateIfNull = ""
        Me.U_Inv3rd.ViewName = "FPTORDR"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(13, 132)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(99, 13)
        Me.Label41.TabIndex = 402
        Me.Label41.Text = "Ngày xuất hóa đơn"
        '
        'U_ExDate
        '
        Me.U_ExDate.EditValue = Nothing
        Me.U_ExDate.FieldName = "U_ExDate"
        Me.U_ExDate.FieldType = "D"
        Me.U_ExDate.KeyInsert = ""
        Me.U_ExDate.Location = New System.Drawing.Point(150, 129)
        Me.U_ExDate.Name = "U_ExDate"
        Me.U_ExDate.NoUpdate = ""
        Me.U_ExDate.PrimaryKey = ""
        Me.U_ExDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("U_ExDate.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.U_ExDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_ExDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_ExDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_ExDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_ExDate.Required = ""
        Me.U_ExDate.Size = New System.Drawing.Size(114, 20)
        Me.U_ExDate.TabIndex = 401
        Me.U_ExDate.TableName = "FPTORDR"
        Me.U_ExDate.ToolTip = "NAME(U_ExDate) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ExDate)"
        Me.U_ExDate.UpdateIfNull = ""
        Me.U_ExDate.ViewName = "FPTORDR"
        '
        'U_DocTime
        '
        Me.U_DocTime.Digit = False
        Me.U_DocTime.Enabled = False
        Me.U_DocTime.FieldName = "U_DocTim"
        Me.U_DocTime.FieldType = "N"
        Me.U_DocTime.KeyInsert = ""
        Me.U_DocTime.LocalDecimal = False
        Me.U_DocTime.Location = New System.Drawing.Point(349, 3)
        Me.U_DocTime.Name = "U_DocTime"
        Me.U_DocTime.NoUpdate = "N"
        Me.U_DocTime.NumberDecimal = 0
        Me.U_DocTime.PrimaryKey = ""
        Me.U_DocTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_DocTime.Required = ""
        Me.U_DocTime.Size = New System.Drawing.Size(113, 20)
        Me.U_DocTime.TabIndex = 400
        Me.U_DocTime.TableName = "FPTORDR"
        Me.U_DocTime.ToolTip = "NAME(U_DocTime) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DocTim)"
        Me.U_DocTime.UpdateIfNull = ""
        Me.U_DocTime.ViewName = "FPTORDR"
        '
        'U_INV_TYPE
        '
        Me.U_INV_TYPE.DisplayField = ""
        Me.U_INV_TYPE.DropDownRow = 10
        Me.U_INV_TYPE.FieldName = "U_INV_TYPE"
        Me.U_INV_TYPE.FieldType = "C"
        Me.U_INV_TYPE.ItemValue = ""
        Me.U_INV_TYPE.KeyInsert = ""
        Me.U_INV_TYPE.Location = New System.Drawing.Point(150, 108)
        Me.U_INV_TYPE.Name = "U_INV_TYPE"
        Me.U_INV_TYPE.NoUpdate = ""
        Me.U_INV_TYPE.PrimaryKey = ""
        Me.U_INV_TYPE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_INV_TYPE.Properties.NullText = ""
        Me.U_INV_TYPE.Properties.ShowHeader = False
        Me.U_INV_TYPE.Required = "Y"
        Me.U_INV_TYPE.ShowHeader = False
        Me.U_INV_TYPE.Size = New System.Drawing.Size(519, 20)
        Me.U_INV_TYPE.SQL_String = "SELECT U_CODE,U_NAME FROM [FPTINVTYPE] WITH (NOLOCK) WHERE U_STATUS = 'Y'  AND u_" & _
            "out='Y'  ORDER BY U_CODE"
        Me.U_INV_TYPE.TabIndex = 398
        Me.U_INV_TYPE.TableName = "FPTORDR"
        Me.U_INV_TYPE.ToolTip = "NAME(U_INV_TYPE) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_INV_TYPE)"
        Me.U_INV_TYPE.UpdateIfNull = ""
        Me.U_INV_TYPE.ValueField = ""
        Me.U_INV_TYPE.ViewName = "FPTORDR"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(14, 111)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(68, 13)
        Me.Label40.TabIndex = 399
        Me.Label40.Text = "Loại hóa đơn"
        '
        'U_Forpay
        '
        Me.U_Forpay.DisplayField = ""
        Me.U_Forpay.DropDownRow = 10
        Me.U_Forpay.FieldName = "U_Forpay"
        Me.U_Forpay.FieldType = "N"
        Me.U_Forpay.ItemValue = ""
        Me.U_Forpay.KeyInsert = ""
        Me.U_Forpay.Location = New System.Drawing.Point(150, 87)
        Me.U_Forpay.Name = "U_Forpay"
        Me.U_Forpay.NoUpdate = ""
        Me.U_Forpay.PrimaryKey = ""
        Me.U_Forpay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_Forpay.Properties.NullText = ""
        Me.U_Forpay.Properties.ShowHeader = False
        Me.U_Forpay.Required = "Y"
        Me.U_Forpay.ShowHeader = False
        Me.U_Forpay.Size = New System.Drawing.Size(312, 20)
        Me.U_Forpay.SQL_String = "SELECT  [Code], [U_NAME] FROM [FPTSAL_PAY] with (nolock)"
        Me.U_Forpay.TabIndex = 396
        Me.U_Forpay.TableName = "FPTORDR"
        Me.U_Forpay.ToolTip = "NAME(U_Forpay) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Forpay)"
        Me.U_Forpay.UpdateIfNull = ""
        Me.U_Forpay.ValueField = ""
        Me.U_Forpay.ViewName = "FPTORDR"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(14, 90)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(109, 13)
        Me.Label37.TabIndex = 397
        Me.Label37.Text = "Hình thức thanh toán"
        '
        'U_MetPay
        '
        Me.U_MetPay.DisplayField = ""
        Me.U_MetPay.DropDownRow = 10
        Me.U_MetPay.FieldName = "U_MetPay"
        Me.U_MetPay.FieldType = "C"
        Me.U_MetPay.ItemValue = ""
        Me.U_MetPay.KeyInsert = ""
        Me.U_MetPay.Location = New System.Drawing.Point(150, 66)
        Me.U_MetPay.Name = "U_MetPay"
        Me.U_MetPay.NoUpdate = ""
        Me.U_MetPay.PrimaryKey = ""
        Me.U_MetPay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_MetPay.Properties.NullText = ""
        Me.U_MetPay.Properties.ShowHeader = False
        Me.U_MetPay.Required = "Y"
        Me.U_MetPay.ShowHeader = False
        Me.U_MetPay.Size = New System.Drawing.Size(312, 20)
        Me.U_MetPay.SQL_String = "SELECT CardID,CardDes  FROM FPTCARDS where U_Status='Y' order by CardID"
        Me.U_MetPay.TabIndex = 394
        Me.U_MetPay.TableName = "FPTORDR"
        Me.U_MetPay.ToolTip = "NAME(U_MetPay) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_MetPay)"
        Me.U_MetPay.UpdateIfNull = ""
        Me.U_MetPay.ValueField = ""
        Me.U_MetPay.ViewName = "FPTORDR"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(14, 69)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(90, 13)
        Me.Label38.TabIndex = 395
        Me.Label38.Text = "CTKM thẻ liên kết"
        '
        'U_TerPay
        '
        Me.U_TerPay.DisplayField = ""
        Me.U_TerPay.DropDownRow = 10
        Me.U_TerPay.FieldName = "U_TerPay"
        Me.U_TerPay.FieldType = "N"
        Me.U_TerPay.ItemValue = ""
        Me.U_TerPay.KeyInsert = ""
        Me.U_TerPay.Location = New System.Drawing.Point(150, 45)
        Me.U_TerPay.Name = "U_TerPay"
        Me.U_TerPay.NoUpdate = ""
        Me.U_TerPay.PrimaryKey = ""
        Me.U_TerPay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_TerPay.Properties.NullText = ""
        Me.U_TerPay.Properties.ShowHeader = False
        Me.U_TerPay.Required = "Y"
        Me.U_TerPay.ShowHeader = False
        Me.U_TerPay.Size = New System.Drawing.Size(312, 20)
        Me.U_TerPay.SQL_String = "SELECT [GroupNum],[PymntGroup] FROM [FPT_OCTG] WITH (NOLOCK) WHERE [GroupNum] > 0" & _
            " ORDER BY [GroupNum]"
        Me.U_TerPay.TabIndex = 392
        Me.U_TerPay.TableName = "FPTORDR"
        Me.U_TerPay.ToolTip = "NAME(U_TerPay) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_TerPay)"
        Me.U_TerPay.UpdateIfNull = ""
        Me.U_TerPay.ValueField = ""
        Me.U_TerPay.ViewName = "FPTORDR"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(14, 48)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(114, 13)
        Me.Label39.TabIndex = 393
        Me.Label39.Text = "Điều khoản thanhtoán"
        '
        'U_DocRat
        '
        Me.U_DocRat.Digit = True
        Me.U_DocRat.FieldName = "U_DocRat"
        Me.U_DocRat.FieldType = "F"
        Me.U_DocRat.KeyInsert = ""
        Me.U_DocRat.LocalDecimal = True
        Me.U_DocRat.Location = New System.Drawing.Point(349, 24)
        Me.U_DocRat.Name = "U_DocRat"
        Me.U_DocRat.NoUpdate = "N"
        Me.U_DocRat.NumberDecimal = 0
        Me.U_DocRat.PrimaryKey = ""
        Me.U_DocRat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_DocRat.Required = ""
        Me.U_DocRat.Size = New System.Drawing.Size(113, 20)
        Me.U_DocRat.TabIndex = 391
        Me.U_DocRat.TableName = "FPTORDR"
        Me.U_DocRat.ToolTip = "NAME(U_DocRat) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DocRat)"
        Me.U_DocRat.UpdateIfNull = ""
        Me.U_DocRat.ViewName = "FPTORDR"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(306, 27)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(36, 13)
        Me.Label36.TabIndex = 390
        Me.Label36.Text = "Tỷ giá"
        '
        'U_DocCur
        '
        Me.U_DocCur.DisplayField = ""
        Me.U_DocCur.DropDownRow = 5
        Me.U_DocCur.FieldName = "U_DocCur"
        Me.U_DocCur.FieldType = "C"
        Me.U_DocCur.ItemValue = ""
        Me.U_DocCur.KeyInsert = ""
        Me.U_DocCur.Location = New System.Drawing.Point(150, 24)
        Me.U_DocCur.Name = "U_DocCur"
        Me.U_DocCur.NoUpdate = ""
        Me.U_DocCur.PrimaryKey = ""
        Me.U_DocCur.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_DocCur.Properties.NullText = ""
        Me.U_DocCur.Properties.ShowHeader = False
        Me.U_DocCur.Required = "Y"
        Me.U_DocCur.ShowHeader = False
        Me.U_DocCur.Size = New System.Drawing.Size(113, 20)
        Me.U_DocCur.SQL_String = "select CurrCode    from FPTOCRN where Locked ='N' order by CurrCode"
        Me.U_DocCur.TabIndex = 388
        Me.U_DocCur.TableName = "FPTORDR"
        Me.U_DocCur.ToolTip = "NAME(U_DocCur) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DocCur)"
        Me.U_DocCur.UpdateIfNull = ""
        Me.U_DocCur.ValueField = ""
        Me.U_DocCur.ViewName = "FPTORDR"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(14, 27)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(47, 13)
        Me.Label35.TabIndex = 389
        Me.Label35.Text = "Loại tiền"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(306, 6)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(22, 13)
        Me.Label34.TabIndex = 387
        Me.Label34.Text = "Giờ"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(13, 6)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(83, 13)
        Me.Label33.TabIndex = 386
        Me.Label33.Text = "Ngày hạch toán"
        '
        'U_AcDate
        '
        Me.U_AcDate.EditValue = Nothing
        Me.U_AcDate.FieldName = "U_AcDate"
        Me.U_AcDate.FieldType = "D"
        Me.U_AcDate.KeyInsert = ""
        Me.U_AcDate.Location = New System.Drawing.Point(150, 3)
        Me.U_AcDate.Name = "U_AcDate"
        Me.U_AcDate.NoUpdate = ""
        Me.U_AcDate.PrimaryKey = ""
        Me.U_AcDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("U_AcDate.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.U_AcDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_AcDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_AcDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_AcDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_AcDate.Required = "Y"
        Me.U_AcDate.Size = New System.Drawing.Size(114, 20)
        Me.U_AcDate.TabIndex = 385
        Me.U_AcDate.TableName = "FPTORDR"
        Me.U_AcDate.ToolTip = "NAME(U_AcDate) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_AcDate)"
        Me.U_AcDate.UpdateIfNull = ""
        Me.U_AcDate.ViewName = "FPTORDR"
        '
        'U_RepNum
        '
        Me.U_RepNum.Digit = False
        Me.U_RepNum.Enabled = False
        Me.U_RepNum.FieldName = "U_RepNum"
        Me.U_RepNum.FieldType = "N"
        Me.U_RepNum.KeyInsert = ""
        Me.U_RepNum.LocalDecimal = False
        Me.U_RepNum.Location = New System.Drawing.Point(824, 47)
        Me.U_RepNum.Name = "U_RepNum"
        Me.U_RepNum.NoUpdate = ""
        Me.U_RepNum.NumberDecimal = 0
        Me.U_RepNum.PrimaryKey = ""
        Me.U_RepNum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_RepNum.Required = "Y"
        Me.U_RepNum.Size = New System.Drawing.Size(114, 20)
        Me.U_RepNum.TabIndex = 384
        Me.U_RepNum.TableName = "FPTORDR"
        Me.U_RepNum.ToolTip = "NAME(U_RepNum) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_RepNum)"
        Me.U_RepNum.UpdateIfNull = ""
        Me.U_RepNum.ViewName = "FPTORDR"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(721, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 383
        Me.Label9.Text = "Số y/c điều chuyển"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(721, 110)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(50, 13)
        Me.Label60.TabIndex = 382
        Me.Label60.Text = "Trả hàng"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(721, 89)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(101, 13)
        Me.Label59.TabIndex = 381
        Me.Label59.Text = "Ghi nhận doanh thu"
        '
        'U_Status
        '
        Me.U_Status.DisplayField = ""
        Me.U_Status.DropDownRow = 10
        Me.U_Status.FieldName = "U_Status"
        Me.U_Status.FieldType = "C"
        Me.U_Status.ItemValue = ""
        Me.U_Status.KeyInsert = ""
        Me.U_Status.Location = New System.Drawing.Point(824, 150)
        Me.U_Status.Name = "U_Status"
        Me.U_Status.NoUpdate = ""
        Me.U_Status.PrimaryKey = ""
        Me.U_Status.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_Status.Properties.NullText = ""
        Me.U_Status.Properties.ShowHeader = False
        Me.U_Status.Required = "Y"
        Me.U_Status.ShowHeader = False
        Me.U_Status.Size = New System.Drawing.Size(209, 20)
        Me.U_Status.SQL_String = ""
        Me.U_Status.TabIndex = 378
        Me.U_Status.TableName = "FPTORDR"
        Me.U_Status.ToolTip = "NAME(U_Status) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Status)"
        Me.U_Status.UpdateIfNull = ""
        Me.U_Status.ValueField = ""
        Me.U_Status.ViewName = "FPTORDR"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(721, 153)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 379
        Me.Label18.Text = "Trạng thái"
        '
        'U_ItmOut1
        '
        Me.U_ItmOut1.DisplayField = ""
        Me.U_ItmOut1.DropDownRow = 10
        Me.U_ItmOut1.FieldName = "U_ItmOut1"
        Me.U_ItmOut1.FieldType = "C"
        Me.U_ItmOut1.ItemValue = ""
        Me.U_ItmOut1.KeyInsert = ""
        Me.U_ItmOut1.Location = New System.Drawing.Point(824, 128)
        Me.U_ItmOut1.Name = "U_ItmOut1"
        Me.U_ItmOut1.NoUpdate = ""
        Me.U_ItmOut1.PrimaryKey = ""
        Me.U_ItmOut1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_ItmOut1.Properties.NullText = ""
        Me.U_ItmOut1.Properties.ShowHeader = False
        Me.U_ItmOut1.Required = "Y"
        Me.U_ItmOut1.ShowHeader = False
        Me.U_ItmOut1.Size = New System.Drawing.Size(209, 20)
        Me.U_ItmOut1.SQL_String = ""
        Me.U_ItmOut1.TabIndex = 372
        Me.U_ItmOut1.TableName = "FPTORDR"
        Me.U_ItmOut1.ToolTip = "NAME(U_ItmOut1) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ItmOut1)"
        Me.U_ItmOut1.UpdateIfNull = ""
        Me.U_ItmOut1.ValueField = ""
        Me.U_ItmOut1.ViewName = "FPTORDR"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(721, 131)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 13)
        Me.Label15.TabIndex = 373
        Me.Label15.Text = "Xuất hàng"
        '
        'U_StsRet
        '
        Me.U_StsRet.CheckValue = "Y"
        Me.U_StsRet.Enabled = False
        Me.U_StsRet.FieldName = "U_StsRet"
        Me.U_StsRet.FieldType = ""
        Me.U_StsRet.ItemValue = ""
        Me.U_StsRet.KeyInsert = ""
        Me.U_StsRet.Location = New System.Drawing.Point(822, 107)
        Me.U_StsRet.Name = "U_StsRet"
        Me.U_StsRet.NoUpdate = ""
        Me.U_StsRet.PrimaryKey = ""
        Me.U_StsRet.Properties.Caption = ""
        Me.U_StsRet.Required = ""
        Me.U_StsRet.Size = New System.Drawing.Size(21, 19)
        Me.U_StsRet.TabIndex = 371
        Me.U_StsRet.TableName = "FPTORDR"
        Me.U_StsRet.ToolTip = "NAME(U_StsRet) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_StsRet) VALUE(False)"
        Me.U_StsRet.UnCheckValue = "N"
        Me.U_StsRet.UpdateIfNull = ""
        Me.U_StsRet.ViewName = "FPTORDR"
        '
        'U_ReveRe
        '
        Me.U_ReveRe.CheckValue = "Y"
        Me.U_ReveRe.Enabled = False
        Me.U_ReveRe.FieldName = "U_ReveRe"
        Me.U_ReveRe.FieldType = "C"
        Me.U_ReveRe.ItemValue = ""
        Me.U_ReveRe.KeyInsert = ""
        Me.U_ReveRe.Location = New System.Drawing.Point(822, 86)
        Me.U_ReveRe.Name = "U_ReveRe"
        Me.U_ReveRe.NoUpdate = ""
        Me.U_ReveRe.PrimaryKey = ""
        Me.U_ReveRe.Properties.Caption = ""
        Me.U_ReveRe.Required = ""
        Me.U_ReveRe.Size = New System.Drawing.Size(21, 19)
        Me.U_ReveRe.TabIndex = 370
        Me.U_ReveRe.TableName = "FPTORDR"
        Me.U_ReveRe.ToolTip = "NAME(U_ReveRe) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ReveRe) VALUE(False)"
        Me.U_ReveRe.UnCheckValue = "N"
        Me.U_ReveRe.UpdateIfNull = ""
        Me.U_ReveRe.ViewName = "FPTORDR"
        '
        'U_BusLin
        '
        Me.U_BusLin.DisplayField = ""
        Me.U_BusLin.DropDownRow = 10
        Me.U_BusLin.FieldName = "U_BusLin"
        Me.U_BusLin.FieldType = "C"
        Me.U_BusLin.ItemValue = ""
        Me.U_BusLin.KeyInsert = ""
        Me.U_BusLin.Location = New System.Drawing.Point(824, 25)
        Me.U_BusLin.Name = "U_BusLin"
        Me.U_BusLin.NoUpdate = ""
        Me.U_BusLin.PrimaryKey = ""
        Me.U_BusLin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_BusLin.Properties.NullText = ""
        Me.U_BusLin.Properties.ShowHeader = False
        Me.U_BusLin.Required = "Y"
        Me.U_BusLin.ShowHeader = False
        Me.U_BusLin.Size = New System.Drawing.Size(209, 20)
        Me.U_BusLin.SQL_String = "select OcrCode, OcrName from  FPTOOCR   with (nolock) where DimCode=4 and Active " & _
            "='Y' and OcrCode in ('B01','B05')"
        Me.U_BusLin.TabIndex = 302
        Me.U_BusLin.TableName = "FPTORDR"
        Me.U_BusLin.ToolTip = "NAME(U_BusLin) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_BusLin)"
        Me.U_BusLin.UpdateIfNull = ""
        Me.U_BusLin.ValueField = ""
        Me.U_BusLin.ViewName = "FPTORDR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(721, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 303
        Me.Label8.Text = "Kênh bán hàng"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(721, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 299
        Me.Label6.Text = "Ngày lập đơn hàng"
        '
        'U_CrDate
        '
        Me.U_CrDate.EditValue = Nothing
        Me.U_CrDate.FieldName = "U_CrDate"
        Me.U_CrDate.FieldType = "D"
        Me.U_CrDate.KeyInsert = ""
        Me.U_CrDate.Location = New System.Drawing.Point(824, 3)
        Me.U_CrDate.Name = "U_CrDate"
        Me.U_CrDate.NoUpdate = ""
        Me.U_CrDate.PrimaryKey = ""
        Me.U_CrDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("U_CrDate.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "", Nothing, Nothing, True)})
        Me.U_CrDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_CrDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_CrDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_CrDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_CrDate.Required = "Y"
        Me.U_CrDate.Size = New System.Drawing.Size(114, 20)
        Me.U_CrDate.TabIndex = 298
        Me.U_CrDate.TableName = "FPTORDR"
        Me.U_CrDate.ToolTip = "NAME(U_CrDate) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_CrDate)"
        Me.U_CrDate.UpdateIfNull = ""
        Me.U_CrDate.ViewName = "FPTORDR"
        '
        'XtraTabPage7
        '
        Me.XtraTabPage7.Controls.Add(Me.XtraTabControl2)
        Me.XtraTabPage7.Name = "XtraTabPage7"
        Me.XtraTabPage7.Size = New System.Drawing.Size(1246, 252)
        Me.XtraTabPage7.Text = "Thông tin trả trước"
        '
        'XtraTabControl2
        '
        Me.XtraTabControl2.Location = New System.Drawing.Point(0, 12)
        Me.XtraTabControl2.Name = "XtraTabControl2"
        Me.XtraTabControl2.SelectedTabPage = Me.XtraTabPage8
        Me.XtraTabControl2.Size = New System.Drawing.Size(1037, 237)
        Me.XtraTabControl2.TabIndex = 415
        Me.XtraTabControl2.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage8, Me.XtraTabPage9, Me.XtraTabPage10})
        '
        'XtraTabPage8
        '
        Me.XtraTabPage8.Controls.Add(Me.U_DownAcTran)
        Me.XtraTabPage8.Controls.Add(Me.AccDownPay)
        Me.XtraTabPage8.Controls.Add(Me.U_DownAcBank)
        Me.XtraTabPage8.Controls.Add(Me.Label68)
        Me.XtraTabPage8.Controls.Add(Me.U_DownBankTs)
        Me.XtraTabPage8.Controls.Add(Me.Label67)
        Me.XtraTabPage8.Controls.Add(Me.Label66)
        Me.XtraTabPage8.Controls.Add(Me.U_DownRefNTr)
        Me.XtraTabPage8.Controls.Add(Me.Label65)
        Me.XtraTabPage8.Controls.Add(Me.Label64)
        Me.XtraTabPage8.Controls.Add(Me.U_DownDateTs)
        Me.XtraTabPage8.Controls.Add(Me.Label16)
        Me.XtraTabPage8.Controls.Add(Me.U_DownMoTran)
        Me.XtraTabPage8.Controls.Add(Me.Label61)
        Me.XtraTabPage8.Controls.Add(Me.Label3)
        Me.XtraTabPage8.Controls.Add(Me.MDownPay)
        Me.XtraTabPage8.Name = "XtraTabPage8"
        Me.XtraTabPage8.Size = New System.Drawing.Size(1031, 211)
        Me.XtraTabPage8.Text = "Tiền mặt/Chuyển khoản"
        '
        'U_DownAcTran
        '
        Me.U_DownAcTran.FieldName = "U_DownAcTran"
        Me.U_DownAcTran.FieldType = "C"
        Me.U_DownAcTran.ItemReturn1 = ""
        Me.U_DownAcTran.ItemReturn2 = ""
        Me.U_DownAcTran.ItemReturn3 = ""
        Me.U_DownAcTran.KeyInsert = ""
        Me.U_DownAcTran.Location = New System.Drawing.Point(813, 14)
        Me.U_DownAcTran.Name = "U_DownAcTran"
        Me.U_DownAcTran.NoUpdate = "N"
        Me.U_DownAcTran.PrimaryKey = ""
        Me.U_DownAcTran.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_DownAcTran.Properties.ReadOnly = True
        Me.U_DownAcTran.Required = "Y"
        Me.U_DownAcTran.ShowLoad = True
        Me.U_DownAcTran.Size = New System.Drawing.Size(170, 20)
        Me.U_DownAcTran.SqlFielKey = "[Số TK]"
        Me.U_DownAcTran.SqlString = "select AcctCode as [Số TK], AcctName as [Tên TK] from  FPTOACT  where AcctCode li" & _
            "ke '112%' "
        Me.U_DownAcTran.TabIndex = 449
        Me.U_DownAcTran.TableName = "FPTORDR"
        Me.U_DownAcTran.ToolTip = "NAME(U_DownAcTran) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DownAcTran)"
        Me.U_DownAcTran.UpdateIfNull = ""
        Me.U_DownAcTran.ViewName = "FPTORDR"
        '
        'AccDownPay
        '
        Me.AccDownPay.FieldName = "AccDownPay"
        Me.AccDownPay.FieldType = "C"
        Me.AccDownPay.ItemReturn1 = ""
        Me.AccDownPay.ItemReturn2 = ""
        Me.AccDownPay.ItemReturn3 = ""
        Me.AccDownPay.KeyInsert = ""
        Me.AccDownPay.Location = New System.Drawing.Point(79, 36)
        Me.AccDownPay.Name = "AccDownPay"
        Me.AccDownPay.NoUpdate = "N"
        Me.AccDownPay.PrimaryKey = ""
        Me.AccDownPay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.AccDownPay.Properties.ReadOnly = True
        Me.AccDownPay.Required = "Y"
        Me.AccDownPay.ShowLoad = True
        Me.AccDownPay.Size = New System.Drawing.Size(170, 20)
        Me.AccDownPay.SqlFielKey = "[Số TK]"
        Me.AccDownPay.SqlString = "select AcctCode as [Số TK], AcctName as [Tên TK] from  FPTOACT  where AcctCode li" & _
            "ke '111%' "
        Me.AccDownPay.TabIndex = 448
        Me.AccDownPay.TableName = "FPTORDR"
        Me.AccDownPay.ToolTip = "NAME(AccDownPay) VIEW(FPTORDR) TAB(FPTORDR) FIELD (AccDownPay)"
        Me.AccDownPay.UpdateIfNull = ""
        Me.AccDownPay.ViewName = "FPTORDR"
        '
        'U_DownAcBank
        '
        Me.U_DownAcBank.DisplayField = ""
        Me.U_DownAcBank.DropDownRow = 15
        Me.U_DownAcBank.FieldName = "U_DownAcBank"
        Me.U_DownAcBank.FieldType = "C"
        Me.U_DownAcBank.ItemValue = ""
        Me.U_DownAcBank.KeyInsert = ""
        Me.U_DownAcBank.Location = New System.Drawing.Point(813, 58)
        Me.U_DownAcBank.Name = "U_DownAcBank"
        Me.U_DownAcBank.NoUpdate = ""
        Me.U_DownAcBank.PrimaryKey = ""
        Me.U_DownAcBank.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_DownAcBank.Properties.NullText = ""
        Me.U_DownAcBank.Properties.ShowHeader = False
        Me.U_DownAcBank.Required = "Y"
        Me.U_DownAcBank.ShowHeader = False
        Me.U_DownAcBank.Size = New System.Drawing.Size(209, 20)
        Me.U_DownAcBank.SQL_String = "select c.Code , Name  from [FPTSHOP] c  with (nolock) , SYS_USER_SHOP d  where c." & _
            "Code = case when ISNULL(d.ShpCode ,'')='ALL' then c.Code else  d.ShpCode end and" & _
            " d.USER_ID =:U_UserLogin"
        Me.U_DownAcBank.TabIndex = 429
        Me.U_DownAcBank.TableName = "FPTORDR"
        Me.U_DownAcBank.ToolTip = "NAME(U_DownAcBank) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DownAcBank)"
        Me.U_DownAcBank.UpdateIfNull = ""
        Me.U_DownAcBank.ValueField = ""
        Me.U_DownAcBank.ViewName = "FPTORDR"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(735, 61)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(74, 13)
        Me.Label68.TabIndex = 430
        Me.Label68.Text = "TK Ngân hàng"
        '
        'U_DownBankTs
        '
        Me.U_DownBankTs.DisplayField = ""
        Me.U_DownBankTs.DropDownRow = 15
        Me.U_DownBankTs.FieldName = "U_DownBankTs"
        Me.U_DownBankTs.FieldType = "C"
        Me.U_DownBankTs.ItemValue = ""
        Me.U_DownBankTs.KeyInsert = ""
        Me.U_DownBankTs.Location = New System.Drawing.Point(813, 36)
        Me.U_DownBankTs.Name = "U_DownBankTs"
        Me.U_DownBankTs.NoUpdate = ""
        Me.U_DownBankTs.PrimaryKey = ""
        Me.U_DownBankTs.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_DownBankTs.Properties.NullText = ""
        Me.U_DownBankTs.Properties.ShowHeader = False
        Me.U_DownBankTs.Required = "Y"
        Me.U_DownBankTs.ShowHeader = False
        Me.U_DownBankTs.Size = New System.Drawing.Size(209, 20)
        Me.U_DownBankTs.SQL_String = "select c.Code , Name  from [FPTSHOP] c  with (nolock) , SYS_USER_SHOP d  where c." & _
            "Code = case when ISNULL(d.ShpCode ,'')='ALL' then c.Code else  d.ShpCode end and" & _
            " d.USER_ID =:U_UserLogin"
        Me.U_DownBankTs.TabIndex = 427
        Me.U_DownBankTs.TableName = "FPTORDR"
        Me.U_DownBankTs.ToolTip = "NAME(U_DownBankTs) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DownBankTs)"
        Me.U_DownBankTs.UpdateIfNull = ""
        Me.U_DownBankTs.ValueField = ""
        Me.U_DownBankTs.ViewName = "FPTORDR"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(735, 39)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(59, 13)
        Me.Label67.TabIndex = 428
        Me.Label67.Text = "Ngân hàng"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(735, 17)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(53, 13)
        Me.Label66.TabIndex = 426
        Me.Label66.Text = "Tài khoản"
        '
        'U_DownRefNTr
        '
        Me.U_DownRefNTr.FieldName = "U_DownRefNTr"
        Me.U_DownRefNTr.FieldType = "C"
        Me.U_DownRefNTr.KeyInsert = ""
        Me.U_DownRefNTr.Location = New System.Drawing.Point(560, 58)
        Me.U_DownRefNTr.Name = "U_DownRefNTr"
        Me.U_DownRefNTr.NoUpdate = "N"
        Me.U_DownRefNTr.PrimaryKey = ""
        Me.U_DownRefNTr.Required = ""
        Me.U_DownRefNTr.Size = New System.Drawing.Size(114, 20)
        Me.U_DownRefNTr.TabIndex = 424
        Me.U_DownRefNTr.TableName = "FPTORDR"
        Me.U_DownRefNTr.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DownRefNTr)"
        Me.U_DownRefNTr.UpdateIfNull = ""
        Me.U_DownRefNTr.ViewName = "FPTORDR"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(457, 61)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(91, 13)
        Me.Label65.TabIndex = 423
        Me.Label65.Text = "Số GD tham chiếu"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(457, 39)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(70, 13)
        Me.Label64.TabIndex = 422
        Me.Label64.Text = "Ngày chuyển"
        '
        'U_DownDateTs
        '
        Me.U_DownDateTs.EditValue = Nothing
        Me.U_DownDateTs.FieldName = "U_DownDateTs"
        Me.U_DownDateTs.FieldType = "D"
        Me.U_DownDateTs.KeyInsert = ""
        Me.U_DownDateTs.Location = New System.Drawing.Point(560, 36)
        Me.U_DownDateTs.Name = "U_DownDateTs"
        Me.U_DownDateTs.NoUpdate = ""
        Me.U_DownDateTs.PrimaryKey = ""
        Me.U_DownDateTs.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("U_DownDateTs.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "", Nothing, Nothing, True)})
        Me.U_DownDateTs.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_DownDateTs.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_DownDateTs.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_DownDateTs.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_DownDateTs.Required = "Y"
        Me.U_DownDateTs.Size = New System.Drawing.Size(114, 20)
        Me.U_DownDateTs.TabIndex = 421
        Me.U_DownDateTs.TableName = "FPTORDR"
        Me.U_DownDateTs.ToolTip = "NAME(U_DownDateTs) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DownDateTs)"
        Me.U_DownDateTs.UpdateIfNull = ""
        Me.U_DownDateTs.ViewName = "FPTORDR"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(457, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 13)
        Me.Label16.TabIndex = 420
        Me.Label16.Text = "Số chuyển khoản"
        '
        'U_DownMoTran
        '
        Me.U_DownMoTran.Digit = False
        Me.U_DownMoTran.FieldName = "U_DownMoTran"
        Me.U_DownMoTran.FieldType = "N"
        Me.U_DownMoTran.KeyInsert = ""
        Me.U_DownMoTran.LocalDecimal = False
        Me.U_DownMoTran.Location = New System.Drawing.Point(560, 14)
        Me.U_DownMoTran.Name = "U_DownMoTran"
        Me.U_DownMoTran.NoUpdate = ""
        Me.U_DownMoTran.NumberDecimal = 0
        Me.U_DownMoTran.PrimaryKey = ""
        Me.U_DownMoTran.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_DownMoTran.Required = ""
        Me.U_DownMoTran.Size = New System.Drawing.Size(152, 20)
        Me.U_DownMoTran.TabIndex = 419
        Me.U_DownMoTran.TableName = "FPTORDR"
        Me.U_DownMoTran.ToolTip = "NAME(U_DownMoTran) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DownMoTran)"
        Me.U_DownMoTran.UpdateIfNull = ""
        Me.U_DownMoTran.ViewName = "FPTORDR"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(22, 39)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(53, 13)
        Me.Label61.TabIndex = 418
        Me.Label61.Text = "Tài khoản"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 416
        Me.Label3.Text = "Tiền mặt"
        '
        'MDownPay
        '
        Me.MDownPay.Digit = False
        Me.MDownPay.FieldName = "MDownPay"
        Me.MDownPay.FieldType = "N"
        Me.MDownPay.KeyInsert = ""
        Me.MDownPay.LocalDecimal = False
        Me.MDownPay.Location = New System.Drawing.Point(79, 14)
        Me.MDownPay.Name = "MDownPay"
        Me.MDownPay.NoUpdate = ""
        Me.MDownPay.NumberDecimal = 0
        Me.MDownPay.PrimaryKey = ""
        Me.MDownPay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MDownPay.Required = ""
        Me.MDownPay.Size = New System.Drawing.Size(152, 20)
        Me.MDownPay.TabIndex = 415
        Me.MDownPay.TableName = "FPTORDR"
        Me.MDownPay.ToolTip = "NAME(MDownPay) VIEW(FPTORDR) TAB(FPTORDR) FIELD (MDownPay)"
        Me.MDownPay.UpdateIfNull = ""
        Me.MDownPay.ViewName = "FPTORDR"
        '
        'XtraTabPage9
        '
        Me.XtraTabPage9.Controls.Add(Me.U_TrueDBGrid3)
        Me.XtraTabPage9.Name = "XtraTabPage9"
        Me.XtraTabPage9.Size = New System.Drawing.Size(1031, 211)
        Me.XtraTabPage9.Text = "Voucher/Check"
        '
        'U_TrueDBGrid3
        '
        Me.U_TrueDBGrid3.AllowInsert = "Y"
        Me.U_TrueDBGrid3.ColumnAutoWidth = "N"
        Me.U_TrueDBGrid3.ColumnEnableUpdate = "A"
        Me.U_TrueDBGrid3.ColumnKey = "LineId"
        Me.U_TrueDBGrid3.ColumnKeyIns = "N"
        Me.U_TrueDBGrid3.ColumnKeyType = "N"
        Me.U_TrueDBGrid3.ColumnVisibleUpdate = "A"
        Me.U_TrueDBGrid3.Location = New System.Drawing.Point(0, 0)
        Me.U_TrueDBGrid3.MainView = Me.GridView3
        Me.U_TrueDBGrid3.Name = "U_TrueDBGrid3"
        Me.U_TrueDBGrid3.ObjectChild = True
        Me.U_TrueDBGrid3.OrderBy = ""
        Me.U_TrueDBGrid3.ParentItem = ""
        Me.U_TrueDBGrid3.Size = New System.Drawing.Size(1031, 211)
        Me.U_TrueDBGrid3.TabIndex = 414
        Me.U_TrueDBGrid3.TableName = "FPTRCT1"
        Me.U_TrueDBGrid3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        Me.U_TrueDBGrid3.ViewName = "FPTRCT1_V"
        Me.U_TrueDBGrid3.Where = "DocEntry=:DocEntry"
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.U_TrueDBGrid3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ShowGroupPanel = False
        Me.GridView3.ViewCaption = "Thanh toán Voucher"
        '
        'XtraTabPage10
        '
        Me.XtraTabPage10.Controls.Add(Me.U_TrueDBGrid2)
        Me.XtraTabPage10.Name = "XtraTabPage10"
        Me.XtraTabPage10.Size = New System.Drawing.Size(1031, 211)
        Me.XtraTabPage10.Text = "Credit Card"
        '
        'U_TrueDBGrid2
        '
        Me.U_TrueDBGrid2.AllowInsert = "Y"
        Me.U_TrueDBGrid2.ColumnAutoWidth = "N"
        Me.U_TrueDBGrid2.ColumnEnableUpdate = "A"
        Me.U_TrueDBGrid2.ColumnKey = "LineId"
        Me.U_TrueDBGrid2.ColumnKeyIns = "N"
        Me.U_TrueDBGrid2.ColumnKeyType = "N"
        Me.U_TrueDBGrid2.ColumnVisibleUpdate = "A"
        Me.U_TrueDBGrid2.Location = New System.Drawing.Point(0, 0)
        Me.U_TrueDBGrid2.MainView = Me.GridView2
        Me.U_TrueDBGrid2.Name = "U_TrueDBGrid2"
        Me.U_TrueDBGrid2.ObjectChild = True
        Me.U_TrueDBGrid2.OrderBy = ""
        Me.U_TrueDBGrid2.ParentItem = ""
        Me.U_TrueDBGrid2.Size = New System.Drawing.Size(1031, 211)
        Me.U_TrueDBGrid2.TabIndex = 415
        Me.U_TrueDBGrid2.TableName = "FPTRCT3"
        Me.U_TrueDBGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        Me.U_TrueDBGrid2.ViewName = "FPTRCT3_V"
        Me.U_TrueDBGrid2.Where = "DocEntry=:DocEntry"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.U_TrueDBGrid2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowGroupPanel = False
        Me.GridView2.ViewCaption = "Thanh toán Voucher"
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Appearance.PageClient.BackColor = System.Drawing.Color.DimGray
        Me.XtraTabPage3.Appearance.PageClient.Options.UseBackColor = True
        Me.XtraTabPage3.Controls.Add(Me.XtraTabControl3)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(1246, 252)
        Me.XtraTabPage3.Text = "Thông tin thanh toán hóa đơn"
        '
        'XtraTabControl3
        '
        Me.XtraTabControl3.Location = New System.Drawing.Point(0, 12)
        Me.XtraTabControl3.Name = "XtraTabControl3"
        Me.XtraTabControl3.SelectedTabPage = Me.XtraTabPage11
        Me.XtraTabControl3.Size = New System.Drawing.Size(1037, 237)
        Me.XtraTabControl3.TabIndex = 416
        Me.XtraTabControl3.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage11, Me.XtraTabPage12, Me.XtraTabPage13})
        '
        'XtraTabPage11
        '
        Me.XtraTabPage11.Controls.Add(Me.U_ReAcTran)
        Me.XtraTabPage11.Controls.Add(Me.AccReToTal)
        Me.XtraTabPage11.Controls.Add(Me.U_ReAcBank)
        Me.XtraTabPage11.Controls.Add(Me.Label69)
        Me.XtraTabPage11.Controls.Add(Me.U_ReBankTs)
        Me.XtraTabPage11.Controls.Add(Me.Label70)
        Me.XtraTabPage11.Controls.Add(Me.Label71)
        Me.XtraTabPage11.Controls.Add(Me.U_ReRefNTr)
        Me.XtraTabPage11.Controls.Add(Me.Label72)
        Me.XtraTabPage11.Controls.Add(Me.Label73)
        Me.XtraTabPage11.Controls.Add(Me.U_ReDateTs)
        Me.XtraTabPage11.Controls.Add(Me.Label74)
        Me.XtraTabPage11.Controls.Add(Me.U_ReMoTran)
        Me.XtraTabPage11.Controls.Add(Me.MReToTal)
        Me.XtraTabPage11.Controls.Add(Me.Label62)
        Me.XtraTabPage11.Controls.Add(Me.Label63)
        Me.XtraTabPage11.Name = "XtraTabPage11"
        Me.XtraTabPage11.Size = New System.Drawing.Size(1031, 211)
        Me.XtraTabPage11.Text = "Tiền mặt/Chuyển khoản"
        '
        'U_ReAcTran
        '
        Me.U_ReAcTran.FieldName = "U_ReAcTran"
        Me.U_ReAcTran.FieldType = "C"
        Me.U_ReAcTran.ItemReturn1 = ""
        Me.U_ReAcTran.ItemReturn2 = ""
        Me.U_ReAcTran.ItemReturn3 = ""
        Me.U_ReAcTran.KeyInsert = ""
        Me.U_ReAcTran.Location = New System.Drawing.Point(815, 14)
        Me.U_ReAcTran.Name = "U_ReAcTran"
        Me.U_ReAcTran.NoUpdate = "N"
        Me.U_ReAcTran.PrimaryKey = ""
        Me.U_ReAcTran.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_ReAcTran.Properties.ReadOnly = True
        Me.U_ReAcTran.Required = "Y"
        Me.U_ReAcTran.ShowLoad = True
        Me.U_ReAcTran.Size = New System.Drawing.Size(170, 20)
        Me.U_ReAcTran.SqlFielKey = "[Số TK]"
        Me.U_ReAcTran.SqlString = "select AcctCode as [Số TK], AcctName as [Tên TK] from  FPTOACT  where AcctCode li" & _
            "ke '112%' "
        Me.U_ReAcTran.TabIndex = 448
        Me.U_ReAcTran.TableName = "FPTORDR"
        Me.U_ReAcTran.ToolTip = "NAME(U_ReAcTran) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ReAcTran)"
        Me.U_ReAcTran.UpdateIfNull = ""
        Me.U_ReAcTran.ViewName = "FPTORDR"
        '
        'AccReToTal
        '
        Me.AccReToTal.FieldName = "AccReToTal"
        Me.AccReToTal.FieldType = "C"
        Me.AccReToTal.ItemReturn1 = ""
        Me.AccReToTal.ItemReturn2 = ""
        Me.AccReToTal.ItemReturn3 = ""
        Me.AccReToTal.KeyInsert = ""
        Me.AccReToTal.Location = New System.Drawing.Point(79, 36)
        Me.AccReToTal.Name = "AccReToTal"
        Me.AccReToTal.NoUpdate = "N"
        Me.AccReToTal.PrimaryKey = ""
        Me.AccReToTal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.AccReToTal.Properties.ReadOnly = True
        Me.AccReToTal.Required = "Y"
        Me.AccReToTal.ShowLoad = True
        Me.AccReToTal.Size = New System.Drawing.Size(170, 20)
        Me.AccReToTal.SqlFielKey = "[Số TK]"
        Me.AccReToTal.SqlString = "select AcctCode as [Số TK], AcctName as [Tên TK] from  FPTOACT  where AcctCode li" & _
            "ke '111%' "
        Me.AccReToTal.TabIndex = 447
        Me.AccReToTal.TableName = "FPTORDR"
        Me.AccReToTal.ToolTip = "NAME(AccReToTal) VIEW(FPTORDR) TAB(FPTORDR) FIELD (AccReToTal)"
        Me.AccReToTal.UpdateIfNull = ""
        Me.AccReToTal.ViewName = "FPTORDR"
        '
        'U_ReAcBank
        '
        Me.U_ReAcBank.DisplayField = ""
        Me.U_ReAcBank.DropDownRow = 15
        Me.U_ReAcBank.FieldName = "U_ReAcBank"
        Me.U_ReAcBank.FieldType = "C"
        Me.U_ReAcBank.ItemValue = ""
        Me.U_ReAcBank.KeyInsert = ""
        Me.U_ReAcBank.Location = New System.Drawing.Point(815, 58)
        Me.U_ReAcBank.Name = "U_ReAcBank"
        Me.U_ReAcBank.NoUpdate = ""
        Me.U_ReAcBank.PrimaryKey = ""
        Me.U_ReAcBank.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_ReAcBank.Properties.NullText = ""
        Me.U_ReAcBank.Properties.ShowHeader = False
        Me.U_ReAcBank.Required = "Y"
        Me.U_ReAcBank.ShowHeader = False
        Me.U_ReAcBank.Size = New System.Drawing.Size(209, 20)
        Me.U_ReAcBank.SQL_String = "select c.Code , Name  from [FPTSHOP] c  with (nolock) , SYS_USER_SHOP d  where c." & _
            "Code = case when ISNULL(d.ShpCode ,'')='ALL' then c.Code else  d.ShpCode end and" & _
            " d.USER_ID =:U_UserLogin"
        Me.U_ReAcBank.TabIndex = 445
        Me.U_ReAcBank.TableName = "FPTORDR"
        Me.U_ReAcBank.ToolTip = "NAME(U_ReAcBank) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ReAcBank)"
        Me.U_ReAcBank.UpdateIfNull = ""
        Me.U_ReAcBank.ValueField = ""
        Me.U_ReAcBank.ViewName = "FPTORDR"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(737, 61)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(74, 13)
        Me.Label69.TabIndex = 446
        Me.Label69.Text = "TK Ngân hàng"
        '
        'U_ReBankTs
        '
        Me.U_ReBankTs.DisplayField = ""
        Me.U_ReBankTs.DropDownRow = 15
        Me.U_ReBankTs.FieldName = "U_ReBankTs"
        Me.U_ReBankTs.FieldType = "C"
        Me.U_ReBankTs.ItemValue = ""
        Me.U_ReBankTs.KeyInsert = ""
        Me.U_ReBankTs.Location = New System.Drawing.Point(815, 36)
        Me.U_ReBankTs.Name = "U_ReBankTs"
        Me.U_ReBankTs.NoUpdate = ""
        Me.U_ReBankTs.PrimaryKey = ""
        Me.U_ReBankTs.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_ReBankTs.Properties.NullText = ""
        Me.U_ReBankTs.Properties.ShowHeader = False
        Me.U_ReBankTs.Required = "Y"
        Me.U_ReBankTs.ShowHeader = False
        Me.U_ReBankTs.Size = New System.Drawing.Size(209, 20)
        Me.U_ReBankTs.SQL_String = "select c.Code , Name  from [FPTSHOP] c  with (nolock) , SYS_USER_SHOP d  where c." & _
            "Code = case when ISNULL(d.ShpCode ,'')='ALL' then c.Code else  d.ShpCode end and" & _
            " d.USER_ID =:U_UserLogin"
        Me.U_ReBankTs.TabIndex = 443
        Me.U_ReBankTs.TableName = "FPTORDR"
        Me.U_ReBankTs.ToolTip = "NAME(U_ReBankTs) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ReBankTs)"
        Me.U_ReBankTs.UpdateIfNull = ""
        Me.U_ReBankTs.ValueField = ""
        Me.U_ReBankTs.ViewName = "FPTORDR"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(737, 39)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(59, 13)
        Me.Label70.TabIndex = 444
        Me.Label70.Text = "Ngân hàng"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(737, 17)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(53, 13)
        Me.Label71.TabIndex = 442
        Me.Label71.Text = "Tài khoản"
        '
        'U_ReRefNTr
        '
        Me.U_ReRefNTr.FieldName = "U_ReRefNTr"
        Me.U_ReRefNTr.FieldType = "C"
        Me.U_ReRefNTr.KeyInsert = ""
        Me.U_ReRefNTr.Location = New System.Drawing.Point(562, 58)
        Me.U_ReRefNTr.Name = "U_ReRefNTr"
        Me.U_ReRefNTr.NoUpdate = "N"
        Me.U_ReRefNTr.PrimaryKey = ""
        Me.U_ReRefNTr.Required = ""
        Me.U_ReRefNTr.Size = New System.Drawing.Size(114, 20)
        Me.U_ReRefNTr.TabIndex = 440
        Me.U_ReRefNTr.TableName = "FPTORDR"
        Me.U_ReRefNTr.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ReRefNTr)"
        Me.U_ReRefNTr.UpdateIfNull = ""
        Me.U_ReRefNTr.ViewName = "FPTORDR"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(459, 61)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(91, 13)
        Me.Label72.TabIndex = 439
        Me.Label72.Text = "Số GD tham chiếu"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(459, 39)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(70, 13)
        Me.Label73.TabIndex = 438
        Me.Label73.Text = "Ngày chuyển"
        '
        'U_ReDateTs
        '
        Me.U_ReDateTs.EditValue = Nothing
        Me.U_ReDateTs.FieldName = "U_ReDateTs"
        Me.U_ReDateTs.FieldType = "D"
        Me.U_ReDateTs.KeyInsert = ""
        Me.U_ReDateTs.Location = New System.Drawing.Point(562, 36)
        Me.U_ReDateTs.Name = "U_ReDateTs"
        Me.U_ReDateTs.NoUpdate = ""
        Me.U_ReDateTs.PrimaryKey = ""
        Me.U_ReDateTs.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("U_ReDateTs.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, "", Nothing, Nothing, True)})
        Me.U_ReDateTs.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_ReDateTs.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_ReDateTs.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_ReDateTs.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_ReDateTs.Required = "Y"
        Me.U_ReDateTs.Size = New System.Drawing.Size(114, 20)
        Me.U_ReDateTs.TabIndex = 437
        Me.U_ReDateTs.TableName = "FPTORDR"
        Me.U_ReDateTs.ToolTip = "NAME(U_ReDateTs) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ReDateTs)"
        Me.U_ReDateTs.UpdateIfNull = ""
        Me.U_ReDateTs.ViewName = "FPTORDR"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(459, 17)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(89, 13)
        Me.Label74.TabIndex = 436
        Me.Label74.Text = "Số chuyển khoản"
        '
        'U_ReMoTran
        '
        Me.U_ReMoTran.Digit = False
        Me.U_ReMoTran.FieldName = "U_ReMoTran"
        Me.U_ReMoTran.FieldType = "N"
        Me.U_ReMoTran.KeyInsert = ""
        Me.U_ReMoTran.LocalDecimal = False
        Me.U_ReMoTran.Location = New System.Drawing.Point(562, 14)
        Me.U_ReMoTran.Name = "U_ReMoTran"
        Me.U_ReMoTran.NoUpdate = ""
        Me.U_ReMoTran.NumberDecimal = 0
        Me.U_ReMoTran.PrimaryKey = ""
        Me.U_ReMoTran.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_ReMoTran.Required = ""
        Me.U_ReMoTran.Size = New System.Drawing.Size(114, 20)
        Me.U_ReMoTran.TabIndex = 435
        Me.U_ReMoTran.TableName = "FPTORDR"
        Me.U_ReMoTran.ToolTip = "NAME(U_ReMoTran) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ReMoTran)"
        Me.U_ReMoTran.UpdateIfNull = ""
        Me.U_ReMoTran.ViewName = "FPTORDR"
        '
        'MReToTal
        '
        Me.MReToTal.Digit = False
        Me.MReToTal.FieldName = "MReToTal"
        Me.MReToTal.FieldType = "N"
        Me.MReToTal.KeyInsert = ""
        Me.MReToTal.LocalDecimal = False
        Me.MReToTal.Location = New System.Drawing.Point(79, 14)
        Me.MReToTal.Name = "MReToTal"
        Me.MReToTal.NoUpdate = ""
        Me.MReToTal.NumberDecimal = 0
        Me.MReToTal.PrimaryKey = ""
        Me.MReToTal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MReToTal.Required = ""
        Me.MReToTal.Size = New System.Drawing.Size(114, 20)
        Me.MReToTal.TabIndex = 419
        Me.MReToTal.TableName = "FPTORDR"
        Me.MReToTal.ToolTip = "NAME(MReToTal) VIEW(FPTORDR) TAB(FPTORDR) FIELD (MReToTal)"
        Me.MReToTal.UpdateIfNull = ""
        Me.MReToTal.ViewName = "FPTORDR"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(22, 39)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(53, 13)
        Me.Label62.TabIndex = 418
        Me.Label62.Text = "Tài khoản"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(22, 17)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(48, 13)
        Me.Label63.TabIndex = 416
        Me.Label63.Text = "Tiền mặt"
        '
        'XtraTabPage12
        '
        Me.XtraTabPage12.Controls.Add(Me.U_TrueDBGrid4)
        Me.XtraTabPage12.Name = "XtraTabPage12"
        Me.XtraTabPage12.Size = New System.Drawing.Size(1031, 211)
        Me.XtraTabPage12.Text = "Voucher/Check"
        '
        'U_TrueDBGrid4
        '
        Me.U_TrueDBGrid4.AllowInsert = "Y"
        Me.U_TrueDBGrid4.ColumnAutoWidth = "N"
        Me.U_TrueDBGrid4.ColumnEnableUpdate = "A"
        Me.U_TrueDBGrid4.ColumnKey = "LineId"
        Me.U_TrueDBGrid4.ColumnKeyIns = "N"
        Me.U_TrueDBGrid4.ColumnKeyType = "N"
        Me.U_TrueDBGrid4.ColumnVisibleUpdate = "A"
        Me.U_TrueDBGrid4.Location = New System.Drawing.Point(-1, 0)
        Me.U_TrueDBGrid4.MainView = Me.GridView4
        Me.U_TrueDBGrid4.Name = "U_TrueDBGrid4"
        Me.U_TrueDBGrid4.ObjectChild = True
        Me.U_TrueDBGrid4.OrderBy = ""
        Me.U_TrueDBGrid4.ParentItem = ""
        Me.U_TrueDBGrid4.Size = New System.Drawing.Size(1032, 211)
        Me.U_TrueDBGrid4.TabIndex = 414
        Me.U_TrueDBGrid4.TableName = "FPTRCT2"
        Me.U_TrueDBGrid4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        Me.U_TrueDBGrid4.ViewName = "FPTRCT2_V"
        Me.U_TrueDBGrid4.Where = "DocEntry=:DocEntry"
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.U_TrueDBGrid4
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsView.ShowGroupPanel = False
        Me.GridView4.ViewCaption = "Thanh toán Voucher"
        '
        'XtraTabPage13
        '
        Me.XtraTabPage13.Controls.Add(Me.U_TrueDBGrid5)
        Me.XtraTabPage13.Name = "XtraTabPage13"
        Me.XtraTabPage13.Size = New System.Drawing.Size(1031, 211)
        Me.XtraTabPage13.Text = "Credit Card"
        '
        'U_TrueDBGrid5
        '
        Me.U_TrueDBGrid5.AllowInsert = "Y"
        Me.U_TrueDBGrid5.ColumnAutoWidth = "Y"
        Me.U_TrueDBGrid5.ColumnEnableUpdate = "A"
        Me.U_TrueDBGrid5.ColumnKey = "LineId"
        Me.U_TrueDBGrid5.ColumnKeyIns = "N"
        Me.U_TrueDBGrid5.ColumnKeyType = "N"
        Me.U_TrueDBGrid5.ColumnVisibleUpdate = "A"
        Me.U_TrueDBGrid5.Location = New System.Drawing.Point(0, 0)
        Me.U_TrueDBGrid5.MainView = Me.GridView5
        Me.U_TrueDBGrid5.Name = "U_TrueDBGrid5"
        Me.U_TrueDBGrid5.ObjectChild = True
        Me.U_TrueDBGrid5.OrderBy = ""
        Me.U_TrueDBGrid5.ParentItem = ""
        Me.U_TrueDBGrid5.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.U_TrueDBGrid5.Size = New System.Drawing.Size(1031, 211)
        Me.U_TrueDBGrid5.TabIndex = 415
        Me.U_TrueDBGrid5.TableName = "FPTRCT4"
        Me.U_TrueDBGrid5.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        Me.U_TrueDBGrid5.ViewName = "FPTRCT4_V"
        Me.U_TrueDBGrid5.Where = "DocEntry=:DocEntry"
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.U_TrueDBGrid5
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsView.ShowGroupPanel = False
        Me.GridView5.ViewCaption = "Thanh toán Voucher"
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.U_Country)
        Me.XtraTabPage2.Controls.Add(Me.Label32)
        Me.XtraTabPage2.Controls.Add(Me.U_District)
        Me.XtraTabPage2.Controls.Add(Me.Label31)
        Me.XtraTabPage2.Controls.Add(Me.U_AdrDel)
        Me.XtraTabPage2.Controls.Add(Me.Label30)
        Me.XtraTabPage2.Controls.Add(Me.U_Phone)
        Me.XtraTabPage2.Controls.Add(Me.Label29)
        Me.XtraTabPage2.Controls.Add(Me.U_Receive)
        Me.XtraTabPage2.Controls.Add(Me.Label28)
        Me.XtraTabPage2.Controls.Add(Me.U_Note)
        Me.XtraTabPage2.Controls.Add(Me.Label27)
        Me.XtraTabPage2.Controls.Add(Me.Label26)
        Me.XtraTabPage2.Controls.Add(Me.U_DateDe)
        Me.XtraTabPage2.Controls.Add(Me.U_Transf)
        Me.XtraTabPage2.Controls.Add(Me.Label25)
        Me.XtraTabPage2.Controls.Add(Me.U_PerDel)
        Me.XtraTabPage2.Controls.Add(Me.Label24)
        Me.XtraTabPage2.Controls.Add(Me.U_ShipTyp)
        Me.XtraTabPage2.Controls.Add(Me.Label13)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1246, 252)
        Me.XtraTabPage2.Text = "Thông tin giao hàng"
        '
        'U_Country
        '
        Me.U_Country.FieldName = "U_Country"
        Me.U_Country.FieldType = "C"
        Me.U_Country.KeyInsert = ""
        Me.U_Country.Location = New System.Drawing.Point(610, 87)
        Me.U_Country.Name = "U_Country"
        Me.U_Country.NoUpdate = "N"
        Me.U_Country.PrimaryKey = ""
        Me.U_Country.Required = ""
        Me.U_Country.Size = New System.Drawing.Size(282, 20)
        Me.U_Country.TabIndex = 311
        Me.U_Country.TableName = "FPTORDR"
        Me.U_Country.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Country)"
        Me.U_Country.UpdateIfNull = ""
        Me.U_Country.ViewName = "FPTORDR"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(488, 90)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(58, 13)
        Me.Label32.TabIndex = 310
        Me.Label32.Text = "Thành phố"
        '
        'U_District
        '
        Me.U_District.FieldName = "U_District"
        Me.U_District.FieldType = "C"
        Me.U_District.KeyInsert = ""
        Me.U_District.Location = New System.Drawing.Point(610, 66)
        Me.U_District.Name = "U_District"
        Me.U_District.NoUpdate = "N"
        Me.U_District.PrimaryKey = ""
        Me.U_District.Required = ""
        Me.U_District.Size = New System.Drawing.Size(282, 20)
        Me.U_District.TabIndex = 309
        Me.U_District.TableName = "FPTORDR"
        Me.U_District.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_District)"
        Me.U_District.UpdateIfNull = ""
        Me.U_District.ViewName = "FPTORDR"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(488, 69)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(68, 13)
        Me.Label31.TabIndex = 308
        Me.Label31.Text = "Quận/Huyện"
        '
        'U_AdrDel
        '
        Me.U_AdrDel.FieldName = "U_AdrDel"
        Me.U_AdrDel.FieldType = "C"
        Me.U_AdrDel.KeyInsert = ""
        Me.U_AdrDel.Location = New System.Drawing.Point(610, 45)
        Me.U_AdrDel.Name = "U_AdrDel"
        Me.U_AdrDel.NoUpdate = "N"
        Me.U_AdrDel.PrimaryKey = ""
        Me.U_AdrDel.Required = ""
        Me.U_AdrDel.Size = New System.Drawing.Size(282, 20)
        Me.U_AdrDel.TabIndex = 307
        Me.U_AdrDel.TableName = "FPTORDR"
        Me.U_AdrDel.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_AdrDel)"
        Me.U_AdrDel.UpdateIfNull = ""
        Me.U_AdrDel.ViewName = "FPTORDR"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(488, 48)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(89, 13)
        Me.Label30.TabIndex = 306
        Me.Label30.Text = "Địa chỉ giao hàng"
        '
        'U_Phone
        '
        Me.U_Phone.FieldName = "U_Phone"
        Me.U_Phone.FieldType = "C"
        Me.U_Phone.KeyInsert = ""
        Me.U_Phone.Location = New System.Drawing.Point(610, 24)
        Me.U_Phone.Name = "U_Phone"
        Me.U_Phone.NoUpdate = "N"
        Me.U_Phone.PrimaryKey = ""
        Me.U_Phone.Required = ""
        Me.U_Phone.Size = New System.Drawing.Size(282, 20)
        Me.U_Phone.TabIndex = 305
        Me.U_Phone.TableName = "FPTORDR"
        Me.U_Phone.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Phone)"
        Me.U_Phone.UpdateIfNull = ""
        Me.U_Phone.ViewName = "FPTORDR"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(488, 27)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(90, 13)
        Me.Label29.TabIndex = 304
        Me.Label29.Text = "Điện thoại liên hệ"
        '
        'U_Receive
        '
        Me.U_Receive.FieldName = "U_Receive"
        Me.U_Receive.FieldType = "C"
        Me.U_Receive.KeyInsert = ""
        Me.U_Receive.Location = New System.Drawing.Point(610, 3)
        Me.U_Receive.Name = "U_Receive"
        Me.U_Receive.NoUpdate = "N"
        Me.U_Receive.PrimaryKey = ""
        Me.U_Receive.Required = ""
        Me.U_Receive.Size = New System.Drawing.Size(282, 20)
        Me.U_Receive.TabIndex = 303
        Me.U_Receive.TableName = "FPTORDR"
        Me.U_Receive.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Receive)"
        Me.U_Receive.UpdateIfNull = ""
        Me.U_Receive.ViewName = "FPTORDR"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(488, 6)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(89, 13)
        Me.Label28.TabIndex = 302
        Me.Label28.Text = "Người nhận hàng"
        '
        'U_Note
        '
        Me.U_Note.FieldName = "U_Note"
        Me.U_Note.FieldType = "C"
        Me.U_Note.KeyInsert = ""
        Me.U_Note.Location = New System.Drawing.Point(129, 87)
        Me.U_Note.Name = "U_Note"
        Me.U_Note.NoUpdate = "N"
        Me.U_Note.PrimaryKey = ""
        Me.U_Note.Required = ""
        Me.U_Note.Size = New System.Drawing.Size(282, 20)
        Me.U_Note.TabIndex = 301
        Me.U_Note.TableName = "FPTORDR"
        Me.U_Note.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Note)"
        Me.U_Note.UpdateIfNull = ""
        Me.U_Note.ViewName = "FPTORDR"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(7, 90)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 13)
        Me.Label27.TabIndex = 300
        Me.Label27.Text = "Ghi chú"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(7, 69)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 13)
        Me.Label26.TabIndex = 299
        Me.Label26.Text = "Thời gian giao hàng"
        '
        'U_DateDe
        '
        Me.U_DateDe.EditValue = Nothing
        Me.U_DateDe.FieldName = "U_DateDe"
        Me.U_DateDe.FieldType = "D"
        Me.U_DateDe.KeyInsert = ""
        Me.U_DateDe.Location = New System.Drawing.Point(129, 66)
        Me.U_DateDe.Name = "U_DateDe"
        Me.U_DateDe.NoUpdate = ""
        Me.U_DateDe.PrimaryKey = ""
        Me.U_DateDe.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("U_DateDe.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, "", Nothing, Nothing, True)})
        Me.U_DateDe.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_DateDe.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_DateDe.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_DateDe.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_DateDe.Required = "Y"
        Me.U_DateDe.Size = New System.Drawing.Size(114, 20)
        Me.U_DateDe.TabIndex = 298
        Me.U_DateDe.TableName = "FPTORDR"
        Me.U_DateDe.ToolTip = "NAME(U_DateDe) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DateDe)"
        Me.U_DateDe.UpdateIfNull = ""
        Me.U_DateDe.ViewName = "FPTORDR"
        '
        'U_Transf
        '
        Me.U_Transf.DisplayField = ""
        Me.U_Transf.DropDownRow = 10
        Me.U_Transf.FieldName = "U_Transf"
        Me.U_Transf.FieldType = "C"
        Me.U_Transf.ItemValue = ""
        Me.U_Transf.KeyInsert = ""
        Me.U_Transf.Location = New System.Drawing.Point(129, 45)
        Me.U_Transf.Name = "U_Transf"
        Me.U_Transf.NoUpdate = ""
        Me.U_Transf.PrimaryKey = ""
        Me.U_Transf.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_Transf.Properties.NullText = ""
        Me.U_Transf.Properties.ShowHeader = False
        Me.U_Transf.Required = "Y"
        Me.U_Transf.ShowHeader = False
        Me.U_Transf.Size = New System.Drawing.Size(282, 20)
        Me.U_Transf.SQL_String = "SELECT [CardCode], [CardName] FROM [FPTOCRD] with(nolock) WHERE [CardType] = 'S' " & _
            "And [U_NhVC] = 'Y'"
        Me.U_Transf.TabIndex = 293
        Me.U_Transf.TableName = "FPTORDR"
        Me.U_Transf.ToolTip = "NAME(U_Transf) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Transf)"
        Me.U_Transf.UpdateIfNull = ""
        Me.U_Transf.ValueField = ""
        Me.U_Transf.ViewName = "FPTORDR"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(7, 48)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(85, 13)
        Me.Label25.TabIndex = 294
        Me.Label25.Text = "Nhà vẫn chuyển"
        '
        'U_PerDel
        '
        Me.U_PerDel.DisplayField = ""
        Me.U_PerDel.DropDownRow = 10
        Me.U_PerDel.FieldName = "U_PerDel"
        Me.U_PerDel.FieldType = "N"
        Me.U_PerDel.ItemValue = ""
        Me.U_PerDel.KeyInsert = ""
        Me.U_PerDel.Location = New System.Drawing.Point(129, 24)
        Me.U_PerDel.Name = "U_PerDel"
        Me.U_PerDel.NoUpdate = ""
        Me.U_PerDel.PrimaryKey = ""
        Me.U_PerDel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_PerDel.Properties.NullText = ""
        Me.U_PerDel.Properties.ShowHeader = False
        Me.U_PerDel.Required = "N"
        Me.U_PerDel.ShowHeader = False
        Me.U_PerDel.Size = New System.Drawing.Size(282, 20)
        Me.U_PerDel.SQL_String = ""
        Me.U_PerDel.TabIndex = 291
        Me.U_PerDel.TableName = "FPTORDR"
        Me.U_PerDel.ToolTip = "NAME(U_PerDel) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_PerDel)"
        Me.U_PerDel.UpdateIfNull = ""
        Me.U_PerDel.ValueField = ""
        Me.U_PerDel.ViewName = "FPTORDR"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(7, 27)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(85, 13)
        Me.Label24.TabIndex = 292
        Me.Label24.Text = "Người giao hàng"
        '
        'U_ShipTyp
        '
        Me.U_ShipTyp.DisplayField = ""
        Me.U_ShipTyp.DropDownRow = 10
        Me.U_ShipTyp.FieldName = "U_ShipTyp"
        Me.U_ShipTyp.FieldType = "N"
        Me.U_ShipTyp.ItemValue = ""
        Me.U_ShipTyp.KeyInsert = ""
        Me.U_ShipTyp.Location = New System.Drawing.Point(129, 3)
        Me.U_ShipTyp.Name = "U_ShipTyp"
        Me.U_ShipTyp.NoUpdate = ""
        Me.U_ShipTyp.PrimaryKey = ""
        Me.U_ShipTyp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_ShipTyp.Properties.NullText = ""
        Me.U_ShipTyp.Properties.ShowHeader = False
        Me.U_ShipTyp.Required = ""
        Me.U_ShipTyp.ShowHeader = False
        Me.U_ShipTyp.Size = New System.Drawing.Size(282, 20)
        Me.U_ShipTyp.SQL_String = "select [TrnspCode] , [TrnspName]  from  [FPTOSHP] with(nolock) order by [TrnspCod" & _
            "e]"
        Me.U_ShipTyp.TabIndex = 289
        Me.U_ShipTyp.TableName = "FPTORDR"
        Me.U_ShipTyp.ToolTip = "NAME(U_ShipTyp) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ShipTyp)"
        Me.U_ShipTyp.UpdateIfNull = ""
        Me.U_ShipTyp.ValueField = ""
        Me.U_ShipTyp.ViewName = "FPTORDR"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 13)
        Me.Label13.TabIndex = 290
        Me.Label13.Text = "Phương thức giao hàng"
        '
        'XtraTabPage5
        '
        Me.XtraTabPage5.Controls.Add(Me.Label50)
        Me.XtraTabPage5.Controls.Add(Me.U_AmountP)
        Me.XtraTabPage5.Controls.Add(Me.Label49)
        Me.XtraTabPage5.Controls.Add(Me.U_AmountN)
        Me.XtraTabPage5.Controls.Add(Me.Label48)
        Me.XtraTabPage5.Controls.Add(Me.U_Month)
        Me.XtraTabPage5.Controls.Add(Me.U_ProNum)
        Me.XtraTabPage5.Controls.Add(Me.Label47)
        Me.XtraTabPage5.Controls.Add(Me.U_Program)
        Me.XtraTabPage5.Controls.Add(Me.U_TextBox2)
        Me.XtraTabPage5.Controls.Add(Me.Label46)
        Me.XtraTabPage5.Controls.Add(Me.U_CardCode)
        Me.XtraTabPage5.Controls.Add(Me.U_TextBox1)
        Me.XtraTabPage5.Controls.Add(Me.Label45)
        Me.XtraTabPage5.Name = "XtraTabPage5"
        Me.XtraTabPage5.PageVisible = False
        Me.XtraTabPage5.Size = New System.Drawing.Size(1246, 252)
        Me.XtraTabPage5.Text = "Thông tin trả góp"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(3, 111)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(78, 13)
        Me.Label50.TabIndex = 368
        Me.Label50.Text = "Số tiền trả góp"
        '
        'U_AmountP
        '
        Me.U_AmountP.Digit = True
        Me.U_AmountP.FieldName = "U_AmountP"
        Me.U_AmountP.FieldType = "N"
        Me.U_AmountP.KeyInsert = ""
        Me.U_AmountP.LocalDecimal = True
        Me.U_AmountP.Location = New System.Drawing.Point(125, 108)
        Me.U_AmountP.Name = "U_AmountP"
        Me.U_AmountP.NoUpdate = "N"
        Me.U_AmountP.NumberDecimal = 0
        Me.U_AmountP.PrimaryKey = ""
        Me.U_AmountP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_AmountP.Required = ""
        Me.U_AmountP.Size = New System.Drawing.Size(192, 20)
        Me.U_AmountP.TabIndex = 367
        Me.U_AmountP.TableName = "FPTORDR"
        Me.U_AmountP.ToolTip = "NAME(U_NumericEdit5) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_SCTMonPr)"
        Me.U_AmountP.UpdateIfNull = ""
        Me.U_AmountP.ViewName = "FPTORDR"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(3, 90)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(74, 13)
        Me.Label49.TabIndex = 366
        Me.Label49.Text = "Số lần trả góp"
        '
        'U_AmountN
        '
        Me.U_AmountN.Digit = True
        Me.U_AmountN.FieldName = "U_AmountN"
        Me.U_AmountN.FieldType = "N"
        Me.U_AmountN.KeyInsert = ""
        Me.U_AmountN.LocalDecimal = False
        Me.U_AmountN.Location = New System.Drawing.Point(125, 87)
        Me.U_AmountN.Name = "U_AmountN"
        Me.U_AmountN.NoUpdate = "N"
        Me.U_AmountN.NumberDecimal = 0
        Me.U_AmountN.PrimaryKey = ""
        Me.U_AmountN.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_AmountN.Required = ""
        Me.U_AmountN.Size = New System.Drawing.Size(114, 20)
        Me.U_AmountN.TabIndex = 365
        Me.U_AmountN.TableName = "FPTORDR"
        Me.U_AmountN.ToolTip = "NAME(U_NumericEdit4) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_SCTMonPr)"
        Me.U_AmountN.UpdateIfNull = ""
        Me.U_AmountN.ViewName = "FPTORDR"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(3, 69)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(61, 13)
        Me.Label48.TabIndex = 364
        Me.Label48.Text = "Kỳ hạn vay"
        '
        'U_Month
        '
        Me.U_Month.Digit = True
        Me.U_Month.FieldName = "U_Month"
        Me.U_Month.FieldType = "N"
        Me.U_Month.KeyInsert = ""
        Me.U_Month.LocalDecimal = False
        Me.U_Month.Location = New System.Drawing.Point(125, 66)
        Me.U_Month.Name = "U_Month"
        Me.U_Month.NoUpdate = "N"
        Me.U_Month.NumberDecimal = 0
        Me.U_Month.PrimaryKey = ""
        Me.U_Month.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_Month.Required = ""
        Me.U_Month.Size = New System.Drawing.Size(114, 20)
        Me.U_Month.TabIndex = 363
        Me.U_Month.TableName = "FPTORDR"
        Me.U_Month.ToolTip = "NAME(U_Month) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Month)"
        Me.U_Month.UpdateIfNull = ""
        Me.U_Month.ViewName = "FPTORDR"
        '
        'U_ProNum
        '
        Me.U_ProNum.FieldName = "U_ProNum"
        Me.U_ProNum.FieldType = "C"
        Me.U_ProNum.KeyInsert = ""
        Me.U_ProNum.Location = New System.Drawing.Point(125, 45)
        Me.U_ProNum.Name = "U_ProNum"
        Me.U_ProNum.NoUpdate = "N"
        Me.U_ProNum.PrimaryKey = ""
        Me.U_ProNum.Required = ""
        Me.U_ProNum.Size = New System.Drawing.Size(192, 20)
        Me.U_ProNum.TabIndex = 362
        Me.U_ProNum.TableName = "FPTORDR"
        Me.U_ProNum.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ProNum)"
        Me.U_ProNum.UpdateIfNull = ""
        Me.U_ProNum.ViewName = "FPTORDR"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(5, 48)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(67, 13)
        Me.Label47.TabIndex = 361
        Me.Label47.Text = "Số hợp đồng"
        '
        'U_Program
        '
        Me.U_Program.FieldName = "U_Program"
        Me.U_Program.FieldType = "C"
        Me.U_Program.ItemReturn1 = ""
        Me.U_Program.ItemReturn2 = ""
        Me.U_Program.ItemReturn3 = ""
        Me.U_Program.KeyInsert = ""
        Me.U_Program.Location = New System.Drawing.Point(125, 24)
        Me.U_Program.Name = "U_Program"
        Me.U_Program.NoUpdate = "N"
        Me.U_Program.PrimaryKey = ""
        Me.U_Program.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_Program.Required = ""
        Me.U_Program.ShowLoad = False
        Me.U_Program.Size = New System.Drawing.Size(114, 20)
        Me.U_Program.SqlFielKey = ""
        Me.U_Program.SqlString = ""
        Me.U_Program.TabIndex = 360
        Me.U_Program.TableName = "FPTORDR"
        Me.U_Program.ToolTip = "NAME(U_Program) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_Program)"
        Me.U_Program.UpdateIfNull = ""
        Me.U_Program.ViewName = "FPTORDR"
        '
        'U_TextBox2
        '
        Me.U_TextBox2.Enabled = False
        Me.U_TextBox2.FieldName = ""
        Me.U_TextBox2.FieldType = "C"
        Me.U_TextBox2.KeyInsert = ""
        Me.U_TextBox2.Location = New System.Drawing.Point(243, 24)
        Me.U_TextBox2.Name = "U_TextBox2"
        Me.U_TextBox2.NoUpdate = "N"
        Me.U_TextBox2.PrimaryKey = ""
        Me.U_TextBox2.Required = ""
        Me.U_TextBox2.Size = New System.Drawing.Size(325, 20)
        Me.U_TextBox2.TabIndex = 359
        Me.U_TextBox2.TableName = ""
        Me.U_TextBox2.ToolTip = "NAME(U_TextBox) VIEW() TAB() FIELD ()"
        Me.U_TextBox2.UpdateIfNull = ""
        Me.U_TextBox2.ViewName = ""
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(5, 27)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(108, 13)
        Me.Label46.TabIndex = 358
        Me.Label46.Text = "Chương trình trả góp"
        '
        'U_CardCode
        '
        Me.U_CardCode.FieldName = "U_CardCode"
        Me.U_CardCode.FieldType = "C"
        Me.U_CardCode.ItemReturn1 = ""
        Me.U_CardCode.ItemReturn2 = ""
        Me.U_CardCode.ItemReturn3 = ""
        Me.U_CardCode.KeyInsert = ""
        Me.U_CardCode.Location = New System.Drawing.Point(125, 3)
        Me.U_CardCode.Name = "U_CardCode"
        Me.U_CardCode.NoUpdate = "N"
        Me.U_CardCode.PrimaryKey = ""
        Me.U_CardCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_CardCode.Required = ""
        Me.U_CardCode.ShowLoad = False
        Me.U_CardCode.Size = New System.Drawing.Size(114, 20)
        Me.U_CardCode.SqlFielKey = ""
        Me.U_CardCode.SqlString = ""
        Me.U_CardCode.TabIndex = 357
        Me.U_CardCode.TableName = "FPTORDR"
        Me.U_CardCode.ToolTip = "NAME(U_CardCode) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_CardCode)"
        Me.U_CardCode.UpdateIfNull = ""
        Me.U_CardCode.ViewName = "FPTORDR"
        '
        'U_TextBox1
        '
        Me.U_TextBox1.Enabled = False
        Me.U_TextBox1.FieldName = ""
        Me.U_TextBox1.FieldType = "C"
        Me.U_TextBox1.KeyInsert = ""
        Me.U_TextBox1.Location = New System.Drawing.Point(243, 3)
        Me.U_TextBox1.Name = "U_TextBox1"
        Me.U_TextBox1.NoUpdate = "N"
        Me.U_TextBox1.PrimaryKey = ""
        Me.U_TextBox1.Required = ""
        Me.U_TextBox1.Size = New System.Drawing.Size(325, 20)
        Me.U_TextBox1.TabIndex = 356
        Me.U_TextBox1.TableName = ""
        Me.U_TextBox1.ToolTip = "NAME(U_TextBox) VIEW() TAB() FIELD ()"
        Me.U_TextBox1.UpdateIfNull = ""
        Me.U_TextBox1.ViewName = ""
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(5, 6)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(83, 13)
        Me.Label45.TabIndex = 355
        Me.Label45.Text = "Công ty trả góp"
        '
        'XtraTabPage6
        '
        Me.XtraTabPage6.Controls.Add(Me.U_EStatus)
        Me.XtraTabPage6.Controls.Add(Me.Label57)
        Me.XtraTabPage6.Controls.Add(Me.U_ErefNum)
        Me.XtraTabPage6.Controls.Add(Me.Label56)
        Me.XtraTabPage6.Controls.Add(Me.Label55)
        Me.XtraTabPage6.Controls.Add(Me.U_EAcDate)
        Me.XtraTabPage6.Controls.Add(Me.U_EAcount)
        Me.XtraTabPage6.Controls.Add(Me.Label54)
        Me.XtraTabPage6.Controls.Add(Me.U_EBank)
        Me.XtraTabPage6.Controls.Add(Me.Label53)
        Me.XtraTabPage6.Controls.Add(Me.Label52)
        Me.XtraTabPage6.Controls.Add(Me.U_EAmount)
        Me.XtraTabPage6.Controls.Add(Me.U_EMetPay)
        Me.XtraTabPage6.Controls.Add(Me.Label51)
        Me.XtraTabPage6.Name = "XtraTabPage6"
        Me.XtraTabPage6.PageVisible = False
        Me.XtraTabPage6.Size = New System.Drawing.Size(1246, 252)
        Me.XtraTabPage6.Text = "Thông tin đơn hàng ECom"
        '
        'U_EStatus
        '
        Me.U_EStatus.DisplayField = ""
        Me.U_EStatus.DropDownRow = 10
        Me.U_EStatus.FieldName = "U_EStatus"
        Me.U_EStatus.FieldType = "C"
        Me.U_EStatus.ItemValue = ""
        Me.U_EStatus.KeyInsert = ""
        Me.U_EStatus.Location = New System.Drawing.Point(179, 129)
        Me.U_EStatus.Name = "U_EStatus"
        Me.U_EStatus.NoUpdate = ""
        Me.U_EStatus.PrimaryKey = ""
        Me.U_EStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_EStatus.Properties.NullText = ""
        Me.U_EStatus.Properties.ShowHeader = False
        Me.U_EStatus.Required = "Y"
        Me.U_EStatus.ShowHeader = False
        Me.U_EStatus.Size = New System.Drawing.Size(151, 20)
        Me.U_EStatus.SQL_String = "select OcrCode, OcrName from  FPTOOCR where DimCode=4 and Active ='Y' and OcrCode" & _
            " in ('B01','B05')"
        Me.U_EStatus.TabIndex = 379
        Me.U_EStatus.TableName = "FPTORDR"
        Me.U_EStatus.ToolTip = "NAME(U_Combobox8) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_BusLin)"
        Me.U_EStatus.UpdateIfNull = ""
        Me.U_EStatus.ValueField = ""
        Me.U_EStatus.ViewName = "FPTORDR"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(5, 132)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(112, 13)
        Me.Label57.TabIndex = 380
        Me.Label57.Text = "Trạng thái thanh toán"
        '
        'U_ErefNum
        '
        Me.U_ErefNum.EditValue = ""
        Me.U_ErefNum.FieldName = "U_ErefNum"
        Me.U_ErefNum.FieldType = "C"
        Me.U_ErefNum.KeyInsert = ""
        Me.U_ErefNum.Location = New System.Drawing.Point(179, 108)
        Me.U_ErefNum.Name = "U_ErefNum"
        Me.U_ErefNum.NoUpdate = "N"
        Me.U_ErefNum.PrimaryKey = ""
        Me.U_ErefNum.Required = ""
        Me.U_ErefNum.Size = New System.Drawing.Size(151, 20)
        Me.U_ErefNum.TabIndex = 378
        Me.U_ErefNum.TableName = "FPTORDR"
        Me.U_ErefNum.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_RepNum)"
        Me.U_ErefNum.UpdateIfNull = ""
        Me.U_ErefNum.ViewName = "FPTORDR"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(5, 111)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(119, 13)
        Me.Label56.TabIndex = 377
        Me.Label56.Text = "Số giao dịch tham chiếu"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(5, 90)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(88, 13)
        Me.Label55.TabIndex = 376
        Me.Label55.Text = "Ngày thanh toán"
        '
        'U_EAcDate
        '
        Me.U_EAcDate.EditValue = Nothing
        Me.U_EAcDate.FieldName = "U_EAcDate"
        Me.U_EAcDate.FieldType = "D"
        Me.U_EAcDate.KeyInsert = ""
        Me.U_EAcDate.Location = New System.Drawing.Point(179, 87)
        Me.U_EAcDate.Name = "U_EAcDate"
        Me.U_EAcDate.NoUpdate = ""
        Me.U_EAcDate.PrimaryKey = ""
        Me.U_EAcDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("U_EAcDate.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject7, "", Nothing, Nothing, True)})
        Me.U_EAcDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_EAcDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_EAcDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_EAcDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_EAcDate.Required = ""
        Me.U_EAcDate.Size = New System.Drawing.Size(114, 20)
        Me.U_EAcDate.TabIndex = 375
        Me.U_EAcDate.TableName = "FPTORDR"
        Me.U_EAcDate.ToolTip = "NAME(U_EAcDate) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_EAcDate)"
        Me.U_EAcDate.UpdateIfNull = ""
        Me.U_EAcDate.ViewName = "FPTORDR"
        '
        'U_EAcount
        '
        Me.U_EAcount.EditValue = ""
        Me.U_EAcount.FieldName = "U_EAcount"
        Me.U_EAcount.FieldType = "C"
        Me.U_EAcount.KeyInsert = ""
        Me.U_EAcount.Location = New System.Drawing.Point(179, 66)
        Me.U_EAcount.Name = "U_EAcount"
        Me.U_EAcount.NoUpdate = "N"
        Me.U_EAcount.PrimaryKey = ""
        Me.U_EAcount.Required = ""
        Me.U_EAcount.Size = New System.Drawing.Size(288, 20)
        Me.U_EAcount.TabIndex = 374
        Me.U_EAcount.TableName = "FPTORDR"
        Me.U_EAcount.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_EAcount)"
        Me.U_EAcount.UpdateIfNull = ""
        Me.U_EAcount.ViewName = "FPTORDR"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(5, 69)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(155, 13)
        Me.Label54.TabIndex = 373
        Me.Label54.Text = "Tài khoản ngân hàng nhận tiền"
        '
        'U_EBank
        '
        Me.U_EBank.FieldName = "U_EBank"
        Me.U_EBank.FieldType = "C"
        Me.U_EBank.KeyInsert = ""
        Me.U_EBank.Location = New System.Drawing.Point(179, 45)
        Me.U_EBank.Name = "U_EBank"
        Me.U_EBank.NoUpdate = "N"
        Me.U_EBank.PrimaryKey = ""
        Me.U_EBank.Required = ""
        Me.U_EBank.Size = New System.Drawing.Size(288, 20)
        Me.U_EBank.TabIndex = 372
        Me.U_EBank.TableName = "FPTORDR"
        Me.U_EBank.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_EBank)"
        Me.U_EBank.UpdateIfNull = ""
        Me.U_EBank.ViewName = "FPTORDR"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(5, 48)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(107, 13)
        Me.Label53.TabIndex = 371
        Me.Label53.Text = "Ngân hàng nhận tiền"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(5, 27)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(111, 13)
        Me.Label52.TabIndex = 370
        Me.Label52.Text = "Số tiền đã thanh toán"
        '
        'U_EAmount
        '
        Me.U_EAmount.Digit = True
        Me.U_EAmount.FieldName = "U_EAmount"
        Me.U_EAmount.FieldType = "F"
        Me.U_EAmount.KeyInsert = ""
        Me.U_EAmount.LocalDecimal = True
        Me.U_EAmount.Location = New System.Drawing.Point(179, 24)
        Me.U_EAmount.Name = "U_EAmount"
        Me.U_EAmount.NoUpdate = "N"
        Me.U_EAmount.NumberDecimal = 0
        Me.U_EAmount.PrimaryKey = ""
        Me.U_EAmount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_EAmount.Required = ""
        Me.U_EAmount.Size = New System.Drawing.Size(151, 20)
        Me.U_EAmount.TabIndex = 369
        Me.U_EAmount.TableName = "FPTORDR"
        Me.U_EAmount.ToolTip = "NAME(U_EAmount) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_EAmount)"
        Me.U_EAmount.UpdateIfNull = ""
        Me.U_EAmount.ViewName = "FPTORDR"
        '
        'U_EMetPay
        '
        Me.U_EMetPay.DisplayField = ""
        Me.U_EMetPay.DropDownRow = 10
        Me.U_EMetPay.FieldName = "U_EMetPay"
        Me.U_EMetPay.FieldType = "C"
        Me.U_EMetPay.ItemValue = ""
        Me.U_EMetPay.KeyInsert = ""
        Me.U_EMetPay.Location = New System.Drawing.Point(179, 3)
        Me.U_EMetPay.Name = "U_EMetPay"
        Me.U_EMetPay.NoUpdate = ""
        Me.U_EMetPay.PrimaryKey = ""
        Me.U_EMetPay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_EMetPay.Properties.NullText = ""
        Me.U_EMetPay.Properties.ShowHeader = False
        Me.U_EMetPay.Required = ""
        Me.U_EMetPay.ShowHeader = False
        Me.U_EMetPay.Size = New System.Drawing.Size(288, 20)
        Me.U_EMetPay.SQL_String = "Select '0' As [Code], N'' As [Name]  UNION select [PayMethCod], [Descript]  from " & _
            "[FPTOPYM] with(nolock) where [Active] = 'Y' and TYPE='I'"
        Me.U_EMetPay.TabIndex = 302
        Me.U_EMetPay.TableName = "FPTORDR"
        Me.U_EMetPay.ToolTip = "NAME(U_EMetPay) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_EMetPay)"
        Me.U_EMetPay.UpdateIfNull = ""
        Me.U_EMetPay.ValueField = ""
        Me.U_EMetPay.ViewName = "FPTORDR"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(5, 6)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(125, 13)
        Me.Label51.TabIndex = 303
        Me.Label51.Text = "Phương thức thanh toán"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(3, 485)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 54)
        Me.btnOK.TabIndex = 329
        Me.btnOK.Text = "&Thêm mới"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(84, 485)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(156, 23)
        Me.SimpleButton2.TabIndex = 330
        Me.SimpleButton2.Text = "(&1) hàng khuyến mại"
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Location = New System.Drawing.Point(84, 516)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SimpleButton6.Size = New System.Drawing.Size(156, 23)
        Me.SimpleButton6.TabIndex = 334
        Me.SimpleButton6.Text = "(&2) Tách đơn hàng"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Location = New System.Drawing.Point(1107, 516)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(138, 23)
        Me.SimpleButton7.TabIndex = 335
        Me.SimpleButton7.Text = "(&9) hoàn tất"
        '
        'SimpleButton11
        '
        Me.SimpleButton11.Location = New System.Drawing.Point(246, 516)
        Me.SimpleButton11.Name = "SimpleButton11"
        Me.SimpleButton11.Size = New System.Drawing.Size(87, 23)
        Me.SimpleButton11.TabIndex = 339
        Me.SimpleButton11.Text = "(&8) in"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(995, 412)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 13)
        Me.Label19.TabIndex = 341
        Me.Label19.Text = "Tổng tiền trước thuế"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(904, 433)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(106, 13)
        Me.Label20.TabIndex = 343
        Me.Label20.Text = "Chiết khấu đơn hàng"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(995, 454)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 13)
        Me.Label21.TabIndex = 346
        Me.Label21.Text = "Tổng tiền thuế"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(995, 475)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(90, 13)
        Me.Label22.TabIndex = 348
        Me.Label22.Text = "Tổng tiền đặt cọc"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(995, 496)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(99, 13)
        Me.Label23.TabIndex = 350
        Me.Label23.Text = "Tổng tiền còn lại"
        '
        'U_UserLogin
        '
        Me.U_UserLogin.FieldName = ""
        Me.U_UserLogin.FieldType = "N"
        Me.U_UserLogin.KeyInsert = ""
        Me.U_UserLogin.Location = New System.Drawing.Point(807, 45)
        Me.U_UserLogin.Name = "U_UserLogin"
        Me.U_UserLogin.NoUpdate = "N"
        Me.U_UserLogin.PrimaryKey = ""
        Me.U_UserLogin.Required = ""
        Me.U_UserLogin.Size = New System.Drawing.Size(0, 20)
        Me.U_UserLogin.TabIndex = 352
        Me.U_UserLogin.TableName = ""
        Me.U_UserLogin.ToolTip = "NAME(U_TextBox) VIEW() TAB() FIELD ()"
        Me.U_UserLogin.UpdateIfNull = ""
        Me.U_UserLogin.ViewName = ""
        '
        'U_ShpCod
        '
        Me.U_ShpCod.DisplayField = ""
        Me.U_ShpCod.DropDownRow = 20
        Me.U_ShpCod.FieldName = "U_ShpCod"
        Me.U_ShpCod.FieldType = "C"
        Me.U_ShpCod.ItemValue = ""
        Me.U_ShpCod.KeyInsert = ""
        Me.U_ShpCod.Location = New System.Drawing.Point(792, 5)
        Me.U_ShpCod.Name = "U_ShpCod"
        Me.U_ShpCod.NoUpdate = ""
        Me.U_ShpCod.PrimaryKey = ""
        Me.U_ShpCod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_ShpCod.Properties.NullText = ""
        Me.U_ShpCod.Properties.ShowHeader = False
        Me.U_ShpCod.Required = "Y"
        Me.U_ShpCod.ShowHeader = False
        Me.U_ShpCod.Size = New System.Drawing.Size(209, 20)
        Me.U_ShpCod.SQL_String = resources.GetString("U_ShpCod.SQL_String")
        Me.U_ShpCod.TabIndex = 0
        Me.U_ShpCod.TableName = "FPTORDR"
        Me.U_ShpCod.ToolTip = "NAME(U_ShpCod) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ShpCod)"
        Me.U_ShpCod.UpdateIfNull = ""
        Me.U_ShpCod.ValueField = ""
        Me.U_ShpCod.ViewName = "FPTORDR"
        '
        'SimpleButton13
        '
        Me.SimpleButton13.Location = New System.Drawing.Point(281, 2)
        Me.SimpleButton13.Name = "SimpleButton13"
        Me.SimpleButton13.Size = New System.Drawing.Size(19, 23)
        Me.SimpleButton13.TabIndex = 353
        Me.SimpleButton13.Text = "..."
        '
        'U_TMonPr
        '
        Me.U_TMonPr.Digit = True
        Me.U_TMonPr.FieldName = "U_TMonPr"
        Me.U_TMonPr.FieldType = "F"
        Me.U_TMonPr.KeyInsert = ""
        Me.U_TMonPr.LocalDecimal = True
        Me.U_TMonPr.Location = New System.Drawing.Point(1107, 409)
        Me.U_TMonPr.Name = "U_TMonPr"
        Me.U_TMonPr.NoUpdate = "N"
        Me.U_TMonPr.NumberDecimal = 0
        Me.U_TMonPr.PrimaryKey = ""
        Me.U_TMonPr.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_TMonPr.Properties.ReadOnly = True
        Me.U_TMonPr.Required = ""
        Me.U_TMonPr.Size = New System.Drawing.Size(138, 20)
        Me.U_TMonPr.TabIndex = 355
        Me.U_TMonPr.TableName = "FPTORDR"
        Me.U_TMonPr.ToolTip = "NAME(U_TMonPr) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_TMonPr)"
        Me.U_TMonPr.UpdateIfNull = ""
        Me.U_TMonPr.ViewName = "FPTORDR"
        '
        'U_MonPer
        '
        Me.U_MonPer.Digit = True
        Me.U_MonPer.FieldName = "U_MonPer"
        Me.U_MonPer.FieldType = "F"
        Me.U_MonPer.KeyInsert = ""
        Me.U_MonPer.LocalDecimal = True
        Me.U_MonPer.Location = New System.Drawing.Point(1107, 430)
        Me.U_MonPer.Name = "U_MonPer"
        Me.U_MonPer.NoUpdate = "N"
        Me.U_MonPer.NumberDecimal = 0
        Me.U_MonPer.PrimaryKey = ""
        Me.U_MonPer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_MonPer.Required = ""
        Me.U_MonPer.Size = New System.Drawing.Size(138, 20)
        Me.U_MonPer.TabIndex = 356
        Me.U_MonPer.TableName = "FPTORDR"
        Me.U_MonPer.ToolTip = "NAME(U_MonPer) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_MonPer)"
        Me.U_MonPer.UpdateIfNull = ""
        Me.U_MonPer.ViewName = "FPTORDR"
        '
        'U_TMonTX
        '
        Me.U_TMonTX.Digit = True
        Me.U_TMonTX.FieldName = "U_TMonTX"
        Me.U_TMonTX.FieldType = "F"
        Me.U_TMonTX.KeyInsert = ""
        Me.U_TMonTX.LocalDecimal = True
        Me.U_TMonTX.Location = New System.Drawing.Point(1107, 451)
        Me.U_TMonTX.Name = "U_TMonTX"
        Me.U_TMonTX.NoUpdate = "N"
        Me.U_TMonTX.NumberDecimal = 0
        Me.U_TMonTX.PrimaryKey = ""
        Me.U_TMonTX.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_TMonTX.Properties.ReadOnly = True
        Me.U_TMonTX.Required = ""
        Me.U_TMonTX.Size = New System.Drawing.Size(138, 20)
        Me.U_TMonTX.TabIndex = 357
        Me.U_TMonTX.TableName = "FPTORDR"
        Me.U_TMonTX.ToolTip = "NAME(U_TMonTX) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_TMonTX)"
        Me.U_TMonTX.UpdateIfNull = ""
        Me.U_TMonTX.ViewName = "FPTORDR"
        '
        'U_DownPay
        '
        Me.U_DownPay.Digit = True
        Me.U_DownPay.FieldName = "U_DownPay"
        Me.U_DownPay.FieldType = "F"
        Me.U_DownPay.KeyInsert = ""
        Me.U_DownPay.LocalDecimal = True
        Me.U_DownPay.Location = New System.Drawing.Point(1107, 472)
        Me.U_DownPay.Name = "U_DownPay"
        Me.U_DownPay.NoUpdate = "N"
        Me.U_DownPay.NumberDecimal = 0
        Me.U_DownPay.PrimaryKey = ""
        Me.U_DownPay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_DownPay.Properties.ReadOnly = True
        Me.U_DownPay.Required = ""
        Me.U_DownPay.Size = New System.Drawing.Size(138, 20)
        Me.U_DownPay.TabIndex = 358
        Me.U_DownPay.TableName = "FPTORDR"
        Me.U_DownPay.ToolTip = "NAME(U_DownPay) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_DownPay)"
        Me.U_DownPay.UpdateIfNull = ""
        Me.U_DownPay.ViewName = "FPTORDR"
        '
        'U_TmonBi
        '
        Me.U_TmonBi.Digit = True
        Me.U_TmonBi.FieldName = "U_TmonBi"
        Me.U_TmonBi.FieldType = "F"
        Me.U_TmonBi.KeyInsert = ""
        Me.U_TmonBi.LocalDecimal = True
        Me.U_TmonBi.Location = New System.Drawing.Point(1107, 493)
        Me.U_TmonBi.Name = "U_TmonBi"
        Me.U_TmonBi.NoUpdate = "N"
        Me.U_TmonBi.NumberDecimal = 0
        Me.U_TmonBi.PrimaryKey = ""
        Me.U_TmonBi.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.U_TmonBi.Properties.Appearance.Options.UseFont = True
        Me.U_TmonBi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_TmonBi.Properties.ReadOnly = True
        Me.U_TmonBi.Required = ""
        Me.U_TmonBi.Size = New System.Drawing.Size(138, 20)
        Me.U_TmonBi.TabIndex = 359
        Me.U_TmonBi.TableName = "FPTORDR"
        Me.U_TmonBi.ToolTip = "NAME(U_TmonBi) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_TmonBi)"
        Me.U_TmonBi.UpdateIfNull = ""
        Me.U_TmonBi.ViewName = "FPTORDR"
        '
        'U_PerBil
        '
        Me.U_PerBil.Digit = True
        Me.U_PerBil.FieldName = "U_PerBil"
        Me.U_PerBil.FieldType = "F"
        Me.U_PerBil.KeyInsert = ""
        Me.U_PerBil.LocalDecimal = False
        Me.U_PerBil.Location = New System.Drawing.Point(1016, 430)
        Me.U_PerBil.Name = "U_PerBil"
        Me.U_PerBil.NoUpdate = "N"
        Me.U_PerBil.NumberDecimal = 2
        Me.U_PerBil.PrimaryKey = ""
        Me.U_PerBil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_PerBil.Required = ""
        Me.U_PerBil.Size = New System.Drawing.Size(85, 20)
        Me.U_PerBil.TabIndex = 360
        Me.U_PerBil.TableName = "FPTORDR"
        Me.U_PerBil.ToolTip = "NAME(U_PerBil) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_PerBil)"
        Me.U_PerBil.UpdateIfNull = ""
        Me.U_PerBil.ViewName = "FPTORDR"
        '
        'U_SCTmonBi
        '
        Me.U_SCTmonBi.Digit = True
        Me.U_SCTmonBi.FieldName = "U_SCTmonBi"
        Me.U_SCTmonBi.FieldType = "F"
        Me.U_SCTmonBi.KeyInsert = ""
        Me.U_SCTmonBi.LocalDecimal = False
        Me.U_SCTmonBi.Location = New System.Drawing.Point(461, 524)
        Me.U_SCTmonBi.Name = "U_SCTmonBi"
        Me.U_SCTmonBi.NoUpdate = "N"
        Me.U_SCTmonBi.NumberDecimal = 6
        Me.U_SCTmonBi.PrimaryKey = ""
        Me.U_SCTmonBi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_SCTmonBi.Required = ""
        Me.U_SCTmonBi.Size = New System.Drawing.Size(0, 20)
        Me.U_SCTmonBi.TabIndex = 365
        Me.U_SCTmonBi.TableName = "FPTORDR"
        Me.U_SCTmonBi.ToolTip = "NAME(U_SCTmonBi) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_SCTmonBi)"
        Me.U_SCTmonBi.UpdateIfNull = ""
        Me.U_SCTmonBi.ViewName = "FPTORDR"
        '
        'U_SCDownPay
        '
        Me.U_SCDownPay.Digit = True
        Me.U_SCDownPay.FieldName = "U_SCDownPay"
        Me.U_SCDownPay.FieldType = "F"
        Me.U_SCDownPay.KeyInsert = ""
        Me.U_SCDownPay.LocalDecimal = False
        Me.U_SCDownPay.Location = New System.Drawing.Point(461, 503)
        Me.U_SCDownPay.Name = "U_SCDownPay"
        Me.U_SCDownPay.NoUpdate = "N"
        Me.U_SCDownPay.NumberDecimal = 6
        Me.U_SCDownPay.PrimaryKey = ""
        Me.U_SCDownPay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_SCDownPay.Required = ""
        Me.U_SCDownPay.Size = New System.Drawing.Size(0, 20)
        Me.U_SCDownPay.TabIndex = 364
        Me.U_SCDownPay.TableName = "FPTORDR"
        Me.U_SCDownPay.ToolTip = "NAME(U_SCDownPay) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_SCDownPay)"
        Me.U_SCDownPay.UpdateIfNull = ""
        Me.U_SCDownPay.ViewName = "FPTORDR"
        '
        'U_SCTMonTX
        '
        Me.U_SCTMonTX.Digit = True
        Me.U_SCTMonTX.FieldName = "U_SCTMonTX"
        Me.U_SCTMonTX.FieldType = "F"
        Me.U_SCTMonTX.KeyInsert = ""
        Me.U_SCTMonTX.LocalDecimal = False
        Me.U_SCTMonTX.Location = New System.Drawing.Point(461, 482)
        Me.U_SCTMonTX.Name = "U_SCTMonTX"
        Me.U_SCTMonTX.NoUpdate = "N"
        Me.U_SCTMonTX.NumberDecimal = 6
        Me.U_SCTMonTX.PrimaryKey = ""
        Me.U_SCTMonTX.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_SCTMonTX.Required = ""
        Me.U_SCTMonTX.Size = New System.Drawing.Size(0, 20)
        Me.U_SCTMonTX.TabIndex = 363
        Me.U_SCTMonTX.TableName = "FPTORDR"
        Me.U_SCTMonTX.ToolTip = "NAME(U_SCTMonTX) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_SCTMonTX)"
        Me.U_SCTMonTX.UpdateIfNull = ""
        Me.U_SCTMonTX.ViewName = "FPTORDR"
        '
        'U_SCMonPer
        '
        Me.U_SCMonPer.Digit = True
        Me.U_SCMonPer.FieldName = "U_SCMonPer"
        Me.U_SCMonPer.FieldType = "F"
        Me.U_SCMonPer.KeyInsert = ""
        Me.U_SCMonPer.LocalDecimal = False
        Me.U_SCMonPer.Location = New System.Drawing.Point(461, 430)
        Me.U_SCMonPer.Name = "U_SCMonPer"
        Me.U_SCMonPer.NoUpdate = "N"
        Me.U_SCMonPer.NumberDecimal = 6
        Me.U_SCMonPer.PrimaryKey = ""
        Me.U_SCMonPer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_SCMonPer.Required = ""
        Me.U_SCMonPer.Size = New System.Drawing.Size(0, 20)
        Me.U_SCMonPer.TabIndex = 362
        Me.U_SCMonPer.TableName = "FPTORDR"
        Me.U_SCMonPer.ToolTip = "NAME(U_SCMonPer) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_SCMonPer)"
        Me.U_SCMonPer.UpdateIfNull = ""
        Me.U_SCMonPer.ViewName = "FPTORDR"
        '
        'U_SCTMonPr
        '
        Me.U_SCTMonPr.Digit = True
        Me.U_SCTMonPr.FieldName = "U_SCTMonPr"
        Me.U_SCTMonPr.FieldType = "F"
        Me.U_SCTMonPr.KeyInsert = ""
        Me.U_SCTMonPr.LocalDecimal = False
        Me.U_SCTMonPr.Location = New System.Drawing.Point(461, 409)
        Me.U_SCTMonPr.Name = "U_SCTMonPr"
        Me.U_SCTMonPr.NoUpdate = "N"
        Me.U_SCTMonPr.NumberDecimal = 6
        Me.U_SCTMonPr.PrimaryKey = ""
        Me.U_SCTMonPr.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.U_SCTMonPr.Required = ""
        Me.U_SCTMonPr.Size = New System.Drawing.Size(0, 20)
        Me.U_SCTMonPr.TabIndex = 361
        Me.U_SCTMonPr.TableName = "FPTORDR"
        Me.U_SCTMonPr.ToolTip = "NAME(U_SCTMonPr) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_SCTMonPr)"
        Me.U_SCTMonPr.UpdateIfNull = ""
        Me.U_SCTMonPr.ViewName = "FPTORDR"
        '
        'DocNum
        '
        Me.DocNum.Digit = False
        Me.DocNum.FieldName = "DocNum"
        Me.DocNum.FieldType = "N"
        Me.DocNum.KeyInsert = ""
        Me.DocNum.LocalDecimal = False
        Me.DocNum.Location = New System.Drawing.Point(1100, 5)
        Me.DocNum.Name = "DocNum"
        Me.DocNum.NoUpdate = ""
        Me.DocNum.NumberDecimal = 0
        Me.DocNum.PrimaryKey = ""
        Me.DocNum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocNum.Properties.ReadOnly = True
        Me.DocNum.Required = "Y"
        Me.DocNum.Size = New System.Drawing.Size(152, 20)
        Me.DocNum.TabIndex = 369
        Me.DocNum.TableName = "FPTORDR"
        Me.DocNum.ToolTip = "NAME(DocNum) VIEW(FPTORDR) TAB(FPTORDR) FIELD (DocNum)"
        Me.DocNum.UpdateIfNull = ""
        Me.DocNum.ViewName = "FPTORDR"
        '
        'U_CrdCod
        '
        Me.U_CrdCod.Enabled = False
        Me.U_CrdCod.FieldName = "U_CrdCod"
        Me.U_CrdCod.FieldType = "C"
        Me.U_CrdCod.KeyInsert = ""
        Me.U_CrdCod.Location = New System.Drawing.Point(458, 450)
        Me.U_CrdCod.Name = "U_CrdCod"
        Me.U_CrdCod.NoUpdate = "N"
        Me.U_CrdCod.PrimaryKey = ""
        Me.U_CrdCod.Required = ""
        Me.U_CrdCod.Size = New System.Drawing.Size(0, 20)
        Me.U_CrdCod.TabIndex = 371
        Me.U_CrdCod.TableName = "FPTORDR"
        Me.U_CrdCod.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_CrdCod)"
        Me.U_CrdCod.UpdateIfNull = ""
        Me.U_CrdCod.ViewName = "FPTORDR"
        '
        'StatusAppr
        '
        Me.StatusAppr.FieldName = "StatusAppr"
        Me.StatusAppr.FieldType = "C"
        Me.StatusAppr.KeyInsert = ""
        Me.StatusAppr.Location = New System.Drawing.Point(458, 479)
        Me.StatusAppr.Name = "StatusAppr"
        Me.StatusAppr.NoUpdate = "N"
        Me.StatusAppr.PrimaryKey = ""
        Me.StatusAppr.Required = ""
        Me.StatusAppr.Size = New System.Drawing.Size(0, 20)
        Me.StatusAppr.TabIndex = 372
        Me.StatusAppr.TableName = "FPTORDR"
        Me.StatusAppr.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (StatusAppr)"
        Me.StatusAppr.UpdateIfNull = ""
        Me.StatusAppr.ViewName = "FPTORDR"
        '
        'DocEntry
        '
        Me.DocEntry.Digit = False
        Me.DocEntry.FieldName = "DocEntry"
        Me.DocEntry.FieldType = "N"
        Me.DocEntry.KeyInsert = "Y"
        Me.DocEntry.LocalDecimal = False
        Me.DocEntry.Location = New System.Drawing.Point(394, 430)
        Me.DocEntry.Name = "DocEntry"
        Me.DocEntry.NoUpdate = ""
        Me.DocEntry.NumberDecimal = 0
        Me.DocEntry.PrimaryKey = "Y"
        Me.DocEntry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocEntry.Required = "Y"
        Me.DocEntry.Size = New System.Drawing.Size(0, 20)
        Me.DocEntry.TabIndex = 373
        Me.DocEntry.TableName = "FPTORDR"
        Me.DocEntry.ToolTip = "NAME(DocEntry) VIEW(FPTORDR) TAB(FPTORDR) FIELD (DocEntry)"
        Me.DocEntry.UpdateIfNull = ""
        Me.DocEntry.ViewName = "FPTORDR"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(5, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 13)
        Me.Label17.TabIndex = 411
        Me.Label17.Text = "Tên khách hàng"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(5, 50)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(69, 13)
        Me.Label58.TabIndex = 412
        Me.Label58.Text = "Người liên hệ"
        '
        'U_CtName
        '
        Me.U_CtName.Enabled = False
        Me.U_CtName.FieldName = "U_CtName"
        Me.U_CtName.FieldType = "C"
        Me.U_CtName.KeyInsert = ""
        Me.U_CtName.Location = New System.Drawing.Point(108, 47)
        Me.U_CtName.Name = "U_CtName"
        Me.U_CtName.NoUpdate = "N"
        Me.U_CtName.PrimaryKey = ""
        Me.U_CtName.Required = ""
        Me.U_CtName.Size = New System.Drawing.Size(351, 20)
        Me.U_CtName.TabIndex = 413
        Me.U_CtName.TableName = "FPTORDR"
        Me.U_CtName.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_CtName)"
        Me.U_CtName.UpdateIfNull = ""
        Me.U_CtName.ViewName = "FPTORDR"
        '
        'Code
        '
        Me.Code.FieldName = "Code"
        Me.Code.FieldType = "C"
        Me.Code.ItemReturn1 = "U_CrdName"
        Me.Code.ItemReturn2 = ""
        Me.Code.ItemReturn3 = ""
        Me.Code.KeyInsert = ""
        Me.Code.Location = New System.Drawing.Point(108, 5)
        Me.Code.Name = "Code"
        Me.Code.NoUpdate = "N"
        Me.Code.PrimaryKey = ""
        Me.Code.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Code.Required = "Y"
        Me.Code.ShowLoad = False
        Me.Code.Size = New System.Drawing.Size(167, 20)
        Me.Code.SqlFielKey = "[Mã khách hàng]"
        Me.Code.SqlString = "select  Code as [Mã khách hàng], CardName as [Tên khách hàng], LictradNum as [MST" & _
            "/DTDĐ], CardCode as [Mã tích hợp] from [FPTOCRD] where CardType='C'"
        Me.Code.TabIndex = 414
        Me.Code.TableName = "FPTORDR"
        Me.Code.ToolTip = "NAME(Code) VIEW(FPTORDR) TAB(FPTORDR) FIELD (Code)"
        Me.Code.UpdateIfNull = ""
        Me.Code.ViewName = "FPTORDR"
        '
        'U_EplCod
        '
        Me.U_EplCod.DisplayField = ""
        Me.U_EplCod.DropDownRow = 20
        Me.U_EplCod.FieldName = "U_EplCod"
        Me.U_EplCod.FieldType = "C"
        Me.U_EplCod.ItemValue = ""
        Me.U_EplCod.KeyInsert = ""
        Me.U_EplCod.Location = New System.Drawing.Point(846, 26)
        Me.U_EplCod.Name = "U_EplCod"
        Me.U_EplCod.NoUpdate = ""
        Me.U_EplCod.PrimaryKey = ""
        Me.U_EplCod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_EplCod.Properties.NullText = ""
        Me.U_EplCod.Properties.ShowHeader = False
        Me.U_EplCod.Required = "Y"
        Me.U_EplCod.ShowHeader = False
        Me.U_EplCod.Size = New System.Drawing.Size(155, 20)
        Me.U_EplCod.SQL_String = "SELECT  [SlpCode],[SlpName] FROM [FPTOSLP] Where (U_EmpSale='Y' and U_Code_SH=:U_" & _
            "ShpCod and Locked='N'  ) Or ID=-1 Order by [SlpCode]"
        Me.U_EplCod.TabIndex = 415
        Me.U_EplCod.TableName = "FPTORDR"
        Me.U_EplCod.ToolTip = "NAME(U_EplCod) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_EplCod)"
        Me.U_EplCod.UpdateIfNull = ""
        Me.U_EplCod.ValueField = ""
        Me.U_EplCod.ViewName = "FPTORDR"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(689, 29)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(103, 13)
        Me.Label75.TabIndex = 416
        Me.Label75.Text = "Nhân viên bán hàng"
        '
        'U_SlpTmp
        '
        Me.U_SlpTmp.FieldName = ""
        Me.U_SlpTmp.FieldType = "C"
        Me.U_SlpTmp.KeyInsert = ""
        Me.U_SlpTmp.Location = New System.Drawing.Point(792, 26)
        Me.U_SlpTmp.Name = "U_SlpTmp"
        Me.U_SlpTmp.NoUpdate = "N"
        Me.U_SlpTmp.PrimaryKey = ""
        Me.U_SlpTmp.Required = ""
        Me.U_SlpTmp.Size = New System.Drawing.Size(53, 20)
        Me.U_SlpTmp.TabIndex = 417
        Me.U_SlpTmp.TableName = "FPTORDR"
        Me.U_SlpTmp.ToolTip = "NAME(U_TextBox) VIEW(FPTORDR) TAB(FPTORDR) FIELD ()"
        Me.U_SlpTmp.UpdateIfNull = ""
        Me.U_SlpTmp.ViewName = "FPTORDR"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(3, 412)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(123, 23)
        Me.SimpleButton1.TabIndex = 418
        Me.SimpleButton1.Text = "(&7) Hủy đơn hàng"
        '
        'FrmORDR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1255, 547)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.U_SlpTmp)
        Me.Controls.Add(Me.U_EplCod)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.Code)
        Me.Controls.Add(Me.U_CtName)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.DocEntry)
        Me.Controls.Add(Me.StatusAppr)
        Me.Controls.Add(Me.U_CrdCod)
        Me.Controls.Add(Me.DocNum)
        Me.Controls.Add(Me.U_SCTmonBi)
        Me.Controls.Add(Me.U_SCDownPay)
        Me.Controls.Add(Me.U_SCTMonTX)
        Me.Controls.Add(Me.U_SCMonPer)
        Me.Controls.Add(Me.U_SCTMonPr)
        Me.Controls.Add(Me.U_PerBil)
        Me.Controls.Add(Me.U_TmonBi)
        Me.Controls.Add(Me.U_DownPay)
        Me.Controls.Add(Me.U_TMonTX)
        Me.Controls.Add(Me.U_MonPer)
        Me.Controls.Add(Me.U_TMonPr)
        Me.Controls.Add(Me.SimpleButton13)
        Me.Controls.Add(Me.U_ShpCod)
        Me.Controls.Add(Me.U_UserLogin)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.SimpleButton11)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.SimpleButton6)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.U_ComCode)
        Me.Controls.Add(Me.ComCodeKey)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.U_SOType)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.U_NuBill)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.U_PriLis)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.U_Desc)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.U_SyBill)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.U_TextBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.U_CrdName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmORDR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Đơn hàng"
        CType(Me.U_CrdName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_SyBill.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Desc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_PriLis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_NuBill.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_SOType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComCodeKey.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ComCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.U_TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage4.ResumeLayout(False)
        Me.XtraTabPage4.PerformLayout()
        CType(Me.U_DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CtOCod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CrOCod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Inv3rd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ExDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ExDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DocTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_INV_TYPE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Forpay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_MetPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TerPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DocRat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DocCur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_AcDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_AcDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_RepNum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Status.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ItmOut1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_StsRet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ReveRe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_BusLin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CrDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CrDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage7.ResumeLayout(False)
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl2.ResumeLayout(False)
        Me.XtraTabPage8.ResumeLayout(False)
        Me.XtraTabPage8.PerformLayout()
        CType(Me.U_DownAcTran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccDownPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DownAcBank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DownBankTs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DownRefNTr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DownDateTs.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DownDateTs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DownMoTran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MDownPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage9.ResumeLayout(False)
        CType(Me.U_TrueDBGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage10.ResumeLayout(False)
        CType(Me.U_TrueDBGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.XtraTabControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl3.ResumeLayout(False)
        Me.XtraTabPage11.ResumeLayout(False)
        Me.XtraTabPage11.PerformLayout()
        CType(Me.U_ReAcTran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccReToTal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ReAcBank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ReBankTs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ReRefNTr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ReDateTs.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ReDateTs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ReMoTran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MReToTal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage12.ResumeLayout(False)
        CType(Me.U_TrueDBGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage13.ResumeLayout(False)
        CType(Me.U_TrueDBGrid5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        Me.XtraTabPage2.PerformLayout()
        CType(Me.U_Country.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_District.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_AdrDel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Phone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Receive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Note.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateDe.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateDe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Transf.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_PerDel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ShipTyp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage5.ResumeLayout(False)
        Me.XtraTabPage5.PerformLayout()
        CType(Me.U_AmountP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_AmountN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Month.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ProNum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Program.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CardCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage6.ResumeLayout(False)
        Me.XtraTabPage6.PerformLayout()
        CType(Me.U_EStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ErefNum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_EAcDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_EAcDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_EAcount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_EBank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_EAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_EMetPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_UserLogin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ShpCod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TMonPr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_MonPer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TMonTX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DownPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TmonBi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_PerBil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_SCTmonBi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_SCDownPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_SCTMonTX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_SCMonPer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_SCTMonPr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocNum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CrdCod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusAppr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocEntry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Code.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_EplCod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_SlpTmp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents U_CrdName As U_TextBox.U_TextBox
    Friend WithEvents U_TextBox3 As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents U_SyBill As U_TextBox.U_TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents U_Desc As U_TextBox.U_TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents U_PriLis As U_TextBox.U_Combobox
    Friend WithEvents U_NuBill As U_TextBox.U_TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents U_SOType As U_TextBox.U_Combobox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComCodeKey As U_TextBox.U_TextBox
    Friend WithEvents U_ComCode As U_TextBox.U_TextBox
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage5 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage6 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton11 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents U_UserLogin As U_TextBox.U_TextBox
    Friend WithEvents U_ShpCod As U_TextBox.U_Combobox
    Friend WithEvents SimpleButton13 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents U_Transf As U_TextBox.U_Combobox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents U_PerDel As U_TextBox.U_Combobox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents U_ShipTyp As U_TextBox.U_Combobox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents U_DateDe As U_TextBox.U_DateEdit
    Friend WithEvents U_Note As U_TextBox.U_TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents U_Country As U_TextBox.U_TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents U_District As U_TextBox.U_TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents U_AdrDel As U_TextBox.U_TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents U_Phone As U_TextBox.U_TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents U_Receive As U_TextBox.U_TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents U_TMonPr As U_TextBox.U_NumericEdit
    Friend WithEvents U_MonPer As U_TextBox.U_NumericEdit
    Friend WithEvents U_TMonTX As U_TextBox.U_NumericEdit
    Friend WithEvents U_DownPay As U_TextBox.U_NumericEdit
    Friend WithEvents U_TmonBi As U_TextBox.U_NumericEdit
    Friend WithEvents U_PerBil As U_TextBox.U_NumericEdit
    Friend WithEvents U_SCTmonBi As U_TextBox.U_NumericEdit
    Friend WithEvents U_SCDownPay As U_TextBox.U_NumericEdit
    Friend WithEvents U_SCTMonTX As U_TextBox.U_NumericEdit
    Friend WithEvents U_SCMonPer As U_TextBox.U_NumericEdit
    Friend WithEvents U_SCTMonPr As U_TextBox.U_NumericEdit
    Friend WithEvents U_CardCode As U_TextBox.U_ButtonEdit
    Friend WithEvents U_TextBox1 As U_TextBox.U_TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents U_Program As U_TextBox.U_ButtonEdit
    Friend WithEvents U_TextBox2 As U_TextBox.U_TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents U_ProNum As U_TextBox.U_TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents U_Month As U_TextBox.U_NumericEdit
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents U_AmountN As U_TextBox.U_NumericEdit
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents U_AmountP As U_TextBox.U_NumericEdit
    Friend WithEvents U_EMetPay As U_TextBox.U_Combobox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents U_EAmount As U_TextBox.U_NumericEdit
    Friend WithEvents U_EBank As U_TextBox.U_TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents U_EAcount As U_TextBox.U_TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents U_EAcDate As U_TextBox.U_DateEdit
    Friend WithEvents U_ErefNum As U_TextBox.U_TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents U_EStatus As U_TextBox.U_Combobox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents DocNum As U_TextBox.U_NumericEdit
    Friend WithEvents U_CrdCod As U_TextBox.U_TextBox
    Friend WithEvents XtraTabPage4 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents U_CrDate As U_TextBox.U_DateEdit
    Friend WithEvents U_BusLin As U_TextBox.U_Combobox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents U_Status As U_TextBox.U_Combobox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents U_ItmOut1 As U_TextBox.U_Combobox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents U_RepNum As U_TextBox.U_NumericEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents StatusAppr As U_TextBox.U_TextBox
    Friend WithEvents DocEntry As U_TextBox.U_NumericEdit
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents U_StsRet As U_TextBox.U_CheckBox
    Friend WithEvents U_ReveRe As U_TextBox.U_CheckBox
    Friend WithEvents U_CtOCod As U_TextBox.U_Combobox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents U_CrOCod As U_TextBox.U_ButtonEdit
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents U_Inv3rd As U_TextBox.U_CheckBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents U_ExDate As U_TextBox.U_DateEdit
    Friend WithEvents U_DocTime As U_TextBox.U_NumericEdit
    Friend WithEvents U_INV_TYPE As U_TextBox.U_Combobox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents U_Forpay As U_TextBox.U_Combobox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents U_MetPay As U_TextBox.U_Combobox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents U_TerPay As U_TextBox.U_Combobox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents U_DocRat As U_TextBox.U_NumericEdit
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents U_DocCur As U_TextBox.U_Combobox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents U_AcDate As U_TextBox.U_DateEdit
    Friend WithEvents XtraTabPage7 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents U_CtName As U_TextBox.U_TextBox
    Friend WithEvents XtraTabControl2 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage8 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MDownPay As U_TextBox.U_NumericEdit
    Friend WithEvents XtraTabPage9 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents XtraTabPage10 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents U_TrueDBGrid3 As U_TextBox.U_TrueDBGrid
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents U_TrueDBGrid2 As U_TextBox.U_TrueDBGrid
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraTabControl3 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage11 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents XtraTabPage12 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents U_TrueDBGrid4 As U_TextBox.U_TrueDBGrid
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraTabPage13 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents U_TrueDBGrid5 As U_TextBox.U_TrueDBGrid
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MReToTal As U_TextBox.U_NumericEdit
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents U_DownMoTran As U_TextBox.U_NumericEdit
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents U_DownDateTs As U_TextBox.U_DateEdit
    Friend WithEvents U_DownRefNTr As U_TextBox.U_TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents U_DownBankTs As U_TextBox.U_Combobox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents U_DownAcBank As U_TextBox.U_Combobox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents U_ReAcBank As U_TextBox.U_Combobox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents U_ReBankTs As U_TextBox.U_Combobox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents U_ReRefNTr As U_TextBox.U_TextBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents U_ReDateTs As U_TextBox.U_DateEdit
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents U_ReMoTran As U_TextBox.U_NumericEdit
    Friend WithEvents AccReToTal As U_TextBox.U_ButtonEdit
    Friend WithEvents U_ReAcTran As U_TextBox.U_ButtonEdit
    Friend WithEvents AccDownPay As U_TextBox.U_ButtonEdit
    Friend WithEvents U_DownAcTran As U_TextBox.U_ButtonEdit
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents Code As U_TextBox.U_ButtonEdit
    Friend WithEvents U_EplCod As U_TextBox.U_Combobox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents U_SlpTmp As U_TextBox.U_TextBox
    Friend WithEvents U_TrueDBGrid1 As U_TextBox.U_TrueDBGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents U_DateEdit1 As U_TextBox.U_DateEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton

    ' Friend WithEvents U_TrueDBGrid11 As DevExpress.XtraGrid.GridControlNavigator
End Class
