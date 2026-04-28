<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDongBoSAP
    Inherits U_CusForm.XtraCusForm1

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.rAll = New System.Windows.Forms.RadioButton()
        Me.rHaft = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToKhai = New U_TextBox.U_CheckBox()
        Me.STO = New U_TextBox.U_CheckBox()
        Me.CongTy = New U_TextBox.U_CheckBox()
        Me.HoaDon = New U_TextBox.U_CheckBox()
        Me.chkKho = New U_TextBox.U_CheckBox()
        Me.chkDonGia = New U_TextBox.U_CheckBox()
        Me.Project = New U_TextBox.U_CheckBox()
        Me.chkThoiHanThanhToan = New U_TextBox.U_CheckBox()
        Me.chkGiaoNhan = New U_TextBox.U_CheckBox()
        Me.chkTuyenDuong = New U_TextBox.U_CheckBox()
        Me.chkNhaCungCap = New U_TextBox.U_CheckBox()
        Me.chkSoHoaDon = New U_TextBox.U_CheckBox()
        Me.chkBeXuat = New U_TextBox.U_CheckBox()
        Me.chkCongTo = New U_TextBox.U_CheckBox()
        Me.chkDonViTinh = New U_TextBox.U_CheckBox()
        Me.chkPhuongThuc = New U_TextBox.U_CheckBox()
        Me.chkPhuongTien = New U_TextBox.U_CheckBox()
        Me.chkHangHoa = New U_TextBox.U_CheckBox()
        Me.chkNguonHang = New U_TextBox.U_CheckBox()
        Me.chkVanChuyen = New U_TextBox.U_CheckBox()
        Me.chkKhachHang = New U_TextBox.U_CheckBox()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.SO_PO_Type = New U_TextBox.U_CheckBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ToKhai.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CongTy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HoaDon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkKho.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDonGia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Project.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkThoiHanThanhToan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGiaoNhan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTuyenDuong.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNhaCungCap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSoHoaDon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkBeXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCongTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDonViTinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPhuongThuc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPhuongTien.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHangHoa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNguonHang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVanChuyen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkKhachHang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SO_PO_Type.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rAll
        '
        Me.rAll.AutoSize = True
        Me.rAll.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rAll.Location = New System.Drawing.Point(11, 417)
        Me.rAll.Name = "rAll"
        Me.rAll.Size = New System.Drawing.Size(110, 23)
        Me.rAll.TabIndex = 10
        Me.rAll.TabStop = True
        Me.rAll.Text = "Lấy toàn bộ"
        Me.rAll.UseVisualStyleBackColor = True
        '
        'rHaft
        '
        Me.rHaft.AutoSize = True
        Me.rHaft.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rHaft.Location = New System.Drawing.Point(143, 417)
        Me.rHaft.Name = "rHaft"
        Me.rHaft.Size = New System.Drawing.Size(113, 23)
        Me.rHaft.TabIndex = 11
        Me.rHaft.TabStop = True
        Me.rHaft.Text = "Lấy thay đổi"
        Me.rHaft.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SO_PO_Type)
        Me.GroupBox1.Controls.Add(Me.ToKhai)
        Me.GroupBox1.Controls.Add(Me.STO)
        Me.GroupBox1.Controls.Add(Me.CongTy)
        Me.GroupBox1.Controls.Add(Me.HoaDon)
        Me.GroupBox1.Controls.Add(Me.chkKho)
        Me.GroupBox1.Controls.Add(Me.chkDonGia)
        Me.GroupBox1.Controls.Add(Me.Project)
        Me.GroupBox1.Controls.Add(Me.chkThoiHanThanhToan)
        Me.GroupBox1.Controls.Add(Me.chkGiaoNhan)
        Me.GroupBox1.Controls.Add(Me.chkTuyenDuong)
        Me.GroupBox1.Controls.Add(Me.chkNhaCungCap)
        Me.GroupBox1.Controls.Add(Me.chkSoHoaDon)
        Me.GroupBox1.Controls.Add(Me.chkBeXuat)
        Me.GroupBox1.Controls.Add(Me.chkCongTo)
        Me.GroupBox1.Controls.Add(Me.chkDonViTinh)
        Me.GroupBox1.Controls.Add(Me.chkPhuongThuc)
        Me.GroupBox1.Controls.Add(Me.chkPhuongTien)
        Me.GroupBox1.Controls.Add(Me.chkHangHoa)
        Me.GroupBox1.Controls.Add(Me.chkNguonHang)
        Me.GroupBox1.Controls.Add(Me.chkVanChuyen)
        Me.GroupBox1.Controls.Add(Me.chkKhachHang)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(551, 384)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Danh mục"
        '
        'ToKhai
        '
        Me.ToKhai.AllowInsert = True
        Me.ToKhai.AllowUpdate = True
        Me.ToKhai.BindingSourceName = ""
        Me.ToKhai.ChangeFormStatus = True
        Me.ToKhai.CheckValue = "Y"
        Me.ToKhai.CopyFromItem = ""
        Me.ToKhai.DefaultValue = ""
        Me.ToKhai.FieldName = ""
        Me.ToKhai.FieldType = ""
        Me.ToKhai.ItemValue = ""
        Me.ToKhai.KeyInsert = ""
        Me.ToKhai.LinkLabel = ""
        Me.ToKhai.Location = New System.Drawing.Point(31, 280)
        Me.ToKhai.Name = "ToKhai"
        Me.ToKhai.NoUpdate = ""
        Me.ToKhai.PrimaryKey = ""
        Me.ToKhai.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToKhai.Properties.Appearance.Options.UseFont = True
        Me.ToKhai.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToKhai.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ToKhai.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToKhai.Properties.AppearanceFocused.Options.UseFont = True
        Me.ToKhai.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToKhai.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ToKhai.Properties.AutoHeight = False
        Me.ToKhai.Properties.Caption = "Danh mục tờ khai"
        Me.ToKhai.Required = ""
        Me.ToKhai.Size = New System.Drawing.Size(256, 24)
        Me.ToKhai.TabIndex = 30
        Me.ToKhai.TableName = ""
        Me.ToKhai.UnCheckValue = "N"
        Me.ToKhai.UpdateIfNull = ""
        Me.ToKhai.UpdateWhenFormLock = False
        Me.ToKhai.ViewName = ""
        '
        'STO
        '
        Me.STO.AllowInsert = True
        Me.STO.AllowUpdate = True
        Me.STO.BindingSourceName = ""
        Me.STO.ChangeFormStatus = True
        Me.STO.CheckValue = "Y"
        Me.STO.CopyFromItem = ""
        Me.STO.DefaultValue = ""
        Me.STO.FieldName = ""
        Me.STO.FieldType = ""
        Me.STO.ItemValue = ""
        Me.STO.KeyInsert = ""
        Me.STO.LinkLabel = ""
        Me.STO.Location = New System.Drawing.Point(289, 276)
        Me.STO.Name = "STO"
        Me.STO.NoUpdate = ""
        Me.STO.PrimaryKey = ""
        Me.STO.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.STO.Properties.Appearance.Options.UseFont = True
        Me.STO.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.STO.Properties.AppearanceDisabled.Options.UseFont = True
        Me.STO.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.STO.Properties.AppearanceFocused.Options.UseFont = True
        Me.STO.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.STO.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.STO.Properties.AutoHeight = False
        Me.STO.Properties.Caption = "Danh mục STO"
        Me.STO.Required = ""
        Me.STO.Size = New System.Drawing.Size(256, 24)
        Me.STO.TabIndex = 29
        Me.STO.TableName = ""
        Me.STO.UnCheckValue = "N"
        Me.STO.UpdateIfNull = ""
        Me.STO.UpdateWhenFormLock = False
        Me.STO.ViewName = ""
        '
        'CongTy
        '
        Me.CongTy.AllowInsert = True
        Me.CongTy.AllowUpdate = True
        Me.CongTy.BindingSourceName = ""
        Me.CongTy.ChangeFormStatus = True
        Me.CongTy.CheckValue = "Y"
        Me.CongTy.CopyFromItem = ""
        Me.CongTy.DefaultValue = ""
        Me.CongTy.FieldName = ""
        Me.CongTy.FieldType = ""
        Me.CongTy.ItemValue = ""
        Me.CongTy.KeyInsert = ""
        Me.CongTy.LinkLabel = ""
        Me.CongTy.Location = New System.Drawing.Point(289, 250)
        Me.CongTy.Name = "CongTy"
        Me.CongTy.NoUpdate = ""
        Me.CongTy.PrimaryKey = ""
        Me.CongTy.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CongTy.Properties.Appearance.Options.UseFont = True
        Me.CongTy.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CongTy.Properties.AppearanceDisabled.Options.UseFont = True
        Me.CongTy.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CongTy.Properties.AppearanceFocused.Options.UseFont = True
        Me.CongTy.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CongTy.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.CongTy.Properties.AutoHeight = False
        Me.CongTy.Properties.Caption = "Danh mục Công ty - Đơn vị"
        Me.CongTy.Required = ""
        Me.CongTy.Size = New System.Drawing.Size(256, 24)
        Me.CongTy.TabIndex = 28
        Me.CongTy.TableName = ""
        Me.CongTy.UnCheckValue = "N"
        Me.CongTy.UpdateIfNull = ""
        Me.CongTy.UpdateWhenFormLock = False
        Me.CongTy.ViewName = ""
        '
        'HoaDon
        '
        Me.HoaDon.AllowInsert = True
        Me.HoaDon.AllowUpdate = True
        Me.HoaDon.BindingSourceName = ""
        Me.HoaDon.ChangeFormStatus = True
        Me.HoaDon.CheckValue = "Y"
        Me.HoaDon.CopyFromItem = ""
        Me.HoaDon.DefaultValue = ""
        Me.HoaDon.FieldName = ""
        Me.HoaDon.FieldType = ""
        Me.HoaDon.ItemValue = ""
        Me.HoaDon.KeyInsert = ""
        Me.HoaDon.LinkLabel = ""
        Me.HoaDon.Location = New System.Drawing.Point(289, 219)
        Me.HoaDon.Name = "HoaDon"
        Me.HoaDon.NoUpdate = ""
        Me.HoaDon.PrimaryKey = ""
        Me.HoaDon.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.HoaDon.Properties.Appearance.Options.UseFont = True
        Me.HoaDon.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.HoaDon.Properties.AppearanceDisabled.Options.UseFont = True
        Me.HoaDon.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.HoaDon.Properties.AppearanceFocused.Options.UseFont = True
        Me.HoaDon.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.HoaDon.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.HoaDon.Properties.AutoHeight = False
        Me.HoaDon.Properties.Caption = "Ký hiệu - Mẫu số của hóa đơn"
        Me.HoaDon.Required = ""
        Me.HoaDon.Size = New System.Drawing.Size(256, 24)
        Me.HoaDon.TabIndex = 27
        Me.HoaDon.TableName = ""
        Me.HoaDon.UnCheckValue = "N"
        Me.HoaDon.UpdateIfNull = ""
        Me.HoaDon.UpdateWhenFormLock = False
        Me.HoaDon.ViewName = ""
        '
        'chkKho
        '
        Me.chkKho.AllowInsert = True
        Me.chkKho.AllowUpdate = True
        Me.chkKho.BindingSourceName = ""
        Me.chkKho.ChangeFormStatus = True
        Me.chkKho.CheckValue = "Y"
        Me.chkKho.CopyFromItem = ""
        Me.chkKho.DefaultValue = ""
        Me.chkKho.FieldName = ""
        Me.chkKho.FieldType = ""
        Me.chkKho.ItemValue = ""
        Me.chkKho.KeyInsert = ""
        Me.chkKho.LinkLabel = ""
        Me.chkKho.Location = New System.Drawing.Point(289, 188)
        Me.chkKho.Name = "chkKho"
        Me.chkKho.NoUpdate = ""
        Me.chkKho.PrimaryKey = ""
        Me.chkKho.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkKho.Properties.Appearance.Options.UseFont = True
        Me.chkKho.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkKho.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkKho.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkKho.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkKho.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkKho.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkKho.Properties.AutoHeight = False
        Me.chkKho.Properties.Caption = "Danh mục Kho"
        Me.chkKho.Required = ""
        Me.chkKho.Size = New System.Drawing.Size(256, 24)
        Me.chkKho.TabIndex = 25
        Me.chkKho.TableName = ""
        Me.chkKho.UnCheckValue = "N"
        Me.chkKho.UpdateIfNull = ""
        Me.chkKho.UpdateWhenFormLock = False
        Me.chkKho.ViewName = ""
        '
        'chkDonGia
        '
        Me.chkDonGia.AllowInsert = True
        Me.chkDonGia.AllowUpdate = True
        Me.chkDonGia.BindingSourceName = ""
        Me.chkDonGia.ChangeFormStatus = True
        Me.chkDonGia.CheckValue = "Y"
        Me.chkDonGia.CopyFromItem = ""
        Me.chkDonGia.DefaultValue = ""
        Me.chkDonGia.FieldName = ""
        Me.chkDonGia.FieldType = ""
        Me.chkDonGia.ItemValue = ""
        Me.chkDonGia.KeyInsert = ""
        Me.chkDonGia.LinkLabel = ""
        Me.chkDonGia.Location = New System.Drawing.Point(289, 126)
        Me.chkDonGia.Name = "chkDonGia"
        Me.chkDonGia.NoUpdate = ""
        Me.chkDonGia.PrimaryKey = ""
        Me.chkDonGia.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkDonGia.Properties.Appearance.Options.UseFont = True
        Me.chkDonGia.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkDonGia.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkDonGia.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkDonGia.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkDonGia.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkDonGia.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkDonGia.Properties.AutoHeight = False
        Me.chkDonGia.Properties.Caption = "Danh mục Đơn giá bán"
        Me.chkDonGia.Required = ""
        Me.chkDonGia.Size = New System.Drawing.Size(256, 24)
        Me.chkDonGia.TabIndex = 24
        Me.chkDonGia.TableName = ""
        Me.chkDonGia.UnCheckValue = "N"
        Me.chkDonGia.UpdateIfNull = ""
        Me.chkDonGia.UpdateWhenFormLock = False
        Me.chkDonGia.ViewName = ""
        '
        'Project
        '
        Me.Project.AllowInsert = True
        Me.Project.AllowUpdate = True
        Me.Project.BindingSourceName = ""
        Me.Project.ChangeFormStatus = True
        Me.Project.CheckValue = "Y"
        Me.Project.CopyFromItem = ""
        Me.Project.DefaultValue = ""
        Me.Project.FieldName = ""
        Me.Project.FieldType = ""
        Me.Project.ItemValue = ""
        Me.Project.KeyInsert = ""
        Me.Project.LinkLabel = ""
        Me.Project.Location = New System.Drawing.Point(289, 157)
        Me.Project.Name = "Project"
        Me.Project.NoUpdate = ""
        Me.Project.PrimaryKey = ""
        Me.Project.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Project.Properties.Appearance.Options.UseFont = True
        Me.Project.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Project.Properties.AppearanceDisabled.Options.UseFont = True
        Me.Project.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Project.Properties.AppearanceFocused.Options.UseFont = True
        Me.Project.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Project.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.Project.Properties.AutoHeight = False
        Me.Project.Properties.Caption = "Danh mục Hợp đồng"
        Me.Project.Required = ""
        Me.Project.Size = New System.Drawing.Size(256, 24)
        Me.Project.TabIndex = 26
        Me.Project.TableName = ""
        Me.Project.UnCheckValue = "N"
        Me.Project.UpdateIfNull = ""
        Me.Project.UpdateWhenFormLock = False
        Me.Project.ViewName = ""
        '
        'chkThoiHanThanhToan
        '
        Me.chkThoiHanThanhToan.AllowInsert = True
        Me.chkThoiHanThanhToan.AllowUpdate = True
        Me.chkThoiHanThanhToan.BindingSourceName = ""
        Me.chkThoiHanThanhToan.ChangeFormStatus = True
        Me.chkThoiHanThanhToan.CheckValue = "Y"
        Me.chkThoiHanThanhToan.CopyFromItem = ""
        Me.chkThoiHanThanhToan.DefaultValue = ""
        Me.chkThoiHanThanhToan.FieldName = ""
        Me.chkThoiHanThanhToan.FieldType = ""
        Me.chkThoiHanThanhToan.ItemValue = ""
        Me.chkThoiHanThanhToan.KeyInsert = ""
        Me.chkThoiHanThanhToan.LinkLabel = ""
        Me.chkThoiHanThanhToan.Location = New System.Drawing.Point(289, 95)
        Me.chkThoiHanThanhToan.Name = "chkThoiHanThanhToan"
        Me.chkThoiHanThanhToan.NoUpdate = ""
        Me.chkThoiHanThanhToan.PrimaryKey = ""
        Me.chkThoiHanThanhToan.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkThoiHanThanhToan.Properties.Appearance.Options.UseFont = True
        Me.chkThoiHanThanhToan.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkThoiHanThanhToan.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkThoiHanThanhToan.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkThoiHanThanhToan.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkThoiHanThanhToan.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkThoiHanThanhToan.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkThoiHanThanhToan.Properties.AutoHeight = False
        Me.chkThoiHanThanhToan.Properties.Caption = "Danh mục Thời hạn thanh toán"
        Me.chkThoiHanThanhToan.Required = ""
        Me.chkThoiHanThanhToan.Size = New System.Drawing.Size(256, 24)
        Me.chkThoiHanThanhToan.TabIndex = 23
        Me.chkThoiHanThanhToan.TableName = ""
        Me.chkThoiHanThanhToan.UnCheckValue = "N"
        Me.chkThoiHanThanhToan.UpdateIfNull = ""
        Me.chkThoiHanThanhToan.UpdateWhenFormLock = False
        Me.chkThoiHanThanhToan.ViewName = ""
        '
        'chkGiaoNhan
        '
        Me.chkGiaoNhan.AllowInsert = True
        Me.chkGiaoNhan.AllowUpdate = True
        Me.chkGiaoNhan.BindingSourceName = ""
        Me.chkGiaoNhan.ChangeFormStatus = True
        Me.chkGiaoNhan.CheckValue = "Y"
        Me.chkGiaoNhan.CopyFromItem = ""
        Me.chkGiaoNhan.DefaultValue = ""
        Me.chkGiaoNhan.FieldName = ""
        Me.chkGiaoNhan.FieldType = ""
        Me.chkGiaoNhan.ItemValue = ""
        Me.chkGiaoNhan.KeyInsert = ""
        Me.chkGiaoNhan.LinkLabel = ""
        Me.chkGiaoNhan.Location = New System.Drawing.Point(289, 64)
        Me.chkGiaoNhan.Name = "chkGiaoNhan"
        Me.chkGiaoNhan.NoUpdate = ""
        Me.chkGiaoNhan.PrimaryKey = ""
        Me.chkGiaoNhan.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkGiaoNhan.Properties.Appearance.Options.UseFont = True
        Me.chkGiaoNhan.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkGiaoNhan.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkGiaoNhan.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkGiaoNhan.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkGiaoNhan.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkGiaoNhan.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkGiaoNhan.Properties.AutoHeight = False
        Me.chkGiaoNhan.Properties.Caption = "Tuyến đường - Điểm giao nhận"
        Me.chkGiaoNhan.Required = ""
        Me.chkGiaoNhan.Size = New System.Drawing.Size(256, 24)
        Me.chkGiaoNhan.TabIndex = 22
        Me.chkGiaoNhan.TableName = ""
        Me.chkGiaoNhan.UnCheckValue = "N"
        Me.chkGiaoNhan.UpdateIfNull = ""
        Me.chkGiaoNhan.UpdateWhenFormLock = False
        Me.chkGiaoNhan.ViewName = ""
        '
        'chkTuyenDuong
        '
        Me.chkTuyenDuong.AllowInsert = True
        Me.chkTuyenDuong.AllowUpdate = True
        Me.chkTuyenDuong.BindingSourceName = ""
        Me.chkTuyenDuong.ChangeFormStatus = True
        Me.chkTuyenDuong.CheckValue = "Y"
        Me.chkTuyenDuong.CopyFromItem = ""
        Me.chkTuyenDuong.DefaultValue = ""
        Me.chkTuyenDuong.FieldName = ""
        Me.chkTuyenDuong.FieldType = ""
        Me.chkTuyenDuong.ItemValue = ""
        Me.chkTuyenDuong.KeyInsert = ""
        Me.chkTuyenDuong.LinkLabel = ""
        Me.chkTuyenDuong.Location = New System.Drawing.Point(289, 422)
        Me.chkTuyenDuong.Name = "chkTuyenDuong"
        Me.chkTuyenDuong.NoUpdate = ""
        Me.chkTuyenDuong.PrimaryKey = ""
        Me.chkTuyenDuong.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkTuyenDuong.Properties.Appearance.Options.UseFont = True
        Me.chkTuyenDuong.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkTuyenDuong.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkTuyenDuong.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkTuyenDuong.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkTuyenDuong.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkTuyenDuong.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkTuyenDuong.Properties.AutoHeight = False
        Me.chkTuyenDuong.Properties.Caption = "Danh mục Tuyến đường"
        Me.chkTuyenDuong.Required = ""
        Me.chkTuyenDuong.Size = New System.Drawing.Size(256, 24)
        Me.chkTuyenDuong.TabIndex = 21
        Me.chkTuyenDuong.TableName = ""
        Me.chkTuyenDuong.UnCheckValue = "N"
        Me.chkTuyenDuong.UpdateIfNull = ""
        Me.chkTuyenDuong.UpdateWhenFormLock = False
        Me.chkTuyenDuong.ViewName = ""
        Me.chkTuyenDuong.Visible = False
        '
        'chkNhaCungCap
        '
        Me.chkNhaCungCap.AllowInsert = True
        Me.chkNhaCungCap.AllowUpdate = True
        Me.chkNhaCungCap.BindingSourceName = ""
        Me.chkNhaCungCap.ChangeFormStatus = True
        Me.chkNhaCungCap.CheckValue = "Y"
        Me.chkNhaCungCap.CopyFromItem = ""
        Me.chkNhaCungCap.DefaultValue = ""
        Me.chkNhaCungCap.FieldName = ""
        Me.chkNhaCungCap.FieldType = ""
        Me.chkNhaCungCap.ItemValue = ""
        Me.chkNhaCungCap.KeyInsert = ""
        Me.chkNhaCungCap.LinkLabel = ""
        Me.chkNhaCungCap.Location = New System.Drawing.Point(289, 34)
        Me.chkNhaCungCap.Name = "chkNhaCungCap"
        Me.chkNhaCungCap.NoUpdate = ""
        Me.chkNhaCungCap.PrimaryKey = ""
        Me.chkNhaCungCap.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkNhaCungCap.Properties.Appearance.Options.UseFont = True
        Me.chkNhaCungCap.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkNhaCungCap.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkNhaCungCap.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkNhaCungCap.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkNhaCungCap.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkNhaCungCap.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkNhaCungCap.Properties.AutoHeight = False
        Me.chkNhaCungCap.Properties.Caption = "Danh mục Nhà cung cấp"
        Me.chkNhaCungCap.Required = ""
        Me.chkNhaCungCap.Size = New System.Drawing.Size(256, 24)
        Me.chkNhaCungCap.TabIndex = 20
        Me.chkNhaCungCap.TableName = ""
        Me.chkNhaCungCap.UnCheckValue = "N"
        Me.chkNhaCungCap.UpdateIfNull = ""
        Me.chkNhaCungCap.UpdateWhenFormLock = False
        Me.chkNhaCungCap.ViewName = ""
        '
        'chkSoHoaDon
        '
        Me.chkSoHoaDon.AllowInsert = True
        Me.chkSoHoaDon.AllowUpdate = True
        Me.chkSoHoaDon.BindingSourceName = ""
        Me.chkSoHoaDon.ChangeFormStatus = False
        Me.chkSoHoaDon.CheckValue = "Y"
        Me.chkSoHoaDon.CopyFromItem = ""
        Me.chkSoHoaDon.DefaultValue = ""
        Me.chkSoHoaDon.FieldName = ""
        Me.chkSoHoaDon.FieldType = ""
        Me.chkSoHoaDon.ItemValue = ""
        Me.chkSoHoaDon.KeyInsert = ""
        Me.chkSoHoaDon.LinkLabel = ""
        Me.chkSoHoaDon.Location = New System.Drawing.Point(289, 443)
        Me.chkSoHoaDon.Name = "chkSoHoaDon"
        Me.chkSoHoaDon.NoUpdate = ""
        Me.chkSoHoaDon.PrimaryKey = ""
        Me.chkSoHoaDon.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSoHoaDon.Properties.Appearance.Options.UseFont = True
        Me.chkSoHoaDon.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkSoHoaDon.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkSoHoaDon.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkSoHoaDon.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkSoHoaDon.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkSoHoaDon.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkSoHoaDon.Properties.AutoHeight = False
        Me.chkSoHoaDon.Properties.Caption = "Danh mục số hóa đơn"
        Me.chkSoHoaDon.Required = ""
        Me.chkSoHoaDon.Size = New System.Drawing.Size(256, 24)
        Me.chkSoHoaDon.TabIndex = 19
        Me.chkSoHoaDon.TableName = ""
        Me.chkSoHoaDon.UnCheckValue = "N"
        Me.chkSoHoaDon.UpdateIfNull = ""
        Me.chkSoHoaDon.UpdateWhenFormLock = False
        Me.chkSoHoaDon.ViewName = ""
        Me.chkSoHoaDon.Visible = False
        '
        'chkBeXuat
        '
        Me.chkBeXuat.AllowInsert = True
        Me.chkBeXuat.AllowUpdate = True
        Me.chkBeXuat.BindingSourceName = ""
        Me.chkBeXuat.ChangeFormStatus = False
        Me.chkBeXuat.CheckValue = "Y"
        Me.chkBeXuat.CopyFromItem = ""
        Me.chkBeXuat.DefaultValue = ""
        Me.chkBeXuat.FieldName = ""
        Me.chkBeXuat.FieldType = ""
        Me.chkBeXuat.ItemValue = ""
        Me.chkBeXuat.KeyInsert = ""
        Me.chkBeXuat.LinkLabel = ""
        Me.chkBeXuat.Location = New System.Drawing.Point(31, 250)
        Me.chkBeXuat.Name = "chkBeXuat"
        Me.chkBeXuat.NoUpdate = ""
        Me.chkBeXuat.PrimaryKey = ""
        Me.chkBeXuat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBeXuat.Properties.Appearance.Options.UseFont = True
        Me.chkBeXuat.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkBeXuat.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkBeXuat.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkBeXuat.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkBeXuat.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkBeXuat.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkBeXuat.Properties.AutoHeight = False
        Me.chkBeXuat.Properties.Caption = "Danh mục bể xuất"
        Me.chkBeXuat.Required = ""
        Me.chkBeXuat.Size = New System.Drawing.Size(238, 24)
        Me.chkBeXuat.TabIndex = 18
        Me.chkBeXuat.TableName = ""
        Me.chkBeXuat.UnCheckValue = "N"
        Me.chkBeXuat.UpdateIfNull = ""
        Me.chkBeXuat.UpdateWhenFormLock = False
        Me.chkBeXuat.ViewName = ""
        '
        'chkCongTo
        '
        Me.chkCongTo.AllowInsert = True
        Me.chkCongTo.AllowUpdate = True
        Me.chkCongTo.BindingSourceName = ""
        Me.chkCongTo.ChangeFormStatus = True
        Me.chkCongTo.CheckValue = "Y"
        Me.chkCongTo.CopyFromItem = ""
        Me.chkCongTo.DefaultValue = ""
        Me.chkCongTo.FieldName = ""
        Me.chkCongTo.FieldType = ""
        Me.chkCongTo.ItemValue = ""
        Me.chkCongTo.KeyInsert = ""
        Me.chkCongTo.LinkLabel = ""
        Me.chkCongTo.Location = New System.Drawing.Point(289, 464)
        Me.chkCongTo.Name = "chkCongTo"
        Me.chkCongTo.NoUpdate = ""
        Me.chkCongTo.PrimaryKey = ""
        Me.chkCongTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCongTo.Properties.Appearance.Options.UseFont = True
        Me.chkCongTo.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkCongTo.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkCongTo.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkCongTo.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkCongTo.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkCongTo.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkCongTo.Properties.AutoHeight = False
        Me.chkCongTo.Properties.Caption = "Danh mục công tơ"
        Me.chkCongTo.Required = ""
        Me.chkCongTo.Size = New System.Drawing.Size(256, 24)
        Me.chkCongTo.TabIndex = 17
        Me.chkCongTo.TableName = ""
        Me.chkCongTo.UnCheckValue = "N"
        Me.chkCongTo.UpdateIfNull = ""
        Me.chkCongTo.UpdateWhenFormLock = False
        Me.chkCongTo.ViewName = ""
        Me.chkCongTo.Visible = False
        '
        'chkDonViTinh
        '
        Me.chkDonViTinh.AllowInsert = True
        Me.chkDonViTinh.AllowUpdate = True
        Me.chkDonViTinh.BindingSourceName = ""
        Me.chkDonViTinh.ChangeFormStatus = False
        Me.chkDonViTinh.CheckValue = "Y"
        Me.chkDonViTinh.CopyFromItem = ""
        Me.chkDonViTinh.DefaultValue = ""
        Me.chkDonViTinh.FieldName = ""
        Me.chkDonViTinh.FieldType = ""
        Me.chkDonViTinh.ItemValue = ""
        Me.chkDonViTinh.KeyInsert = ""
        Me.chkDonViTinh.LinkLabel = ""
        Me.chkDonViTinh.Location = New System.Drawing.Point(31, 219)
        Me.chkDonViTinh.Name = "chkDonViTinh"
        Me.chkDonViTinh.NoUpdate = ""
        Me.chkDonViTinh.PrimaryKey = ""
        Me.chkDonViTinh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDonViTinh.Properties.Appearance.Options.UseFont = True
        Me.chkDonViTinh.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkDonViTinh.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkDonViTinh.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkDonViTinh.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkDonViTinh.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkDonViTinh.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkDonViTinh.Properties.AutoHeight = False
        Me.chkDonViTinh.Properties.Caption = "Danh mục đơn vị tính"
        Me.chkDonViTinh.Required = ""
        Me.chkDonViTinh.Size = New System.Drawing.Size(238, 24)
        Me.chkDonViTinh.TabIndex = 16
        Me.chkDonViTinh.TableName = ""
        Me.chkDonViTinh.UnCheckValue = "N"
        Me.chkDonViTinh.UpdateIfNull = ""
        Me.chkDonViTinh.UpdateWhenFormLock = False
        Me.chkDonViTinh.ViewName = ""
        '
        'chkPhuongThuc
        '
        Me.chkPhuongThuc.AllowInsert = True
        Me.chkPhuongThuc.AllowUpdate = True
        Me.chkPhuongThuc.BindingSourceName = ""
        Me.chkPhuongThuc.ChangeFormStatus = False
        Me.chkPhuongThuc.CheckValue = "Y"
        Me.chkPhuongThuc.CopyFromItem = ""
        Me.chkPhuongThuc.DefaultValue = ""
        Me.chkPhuongThuc.FieldName = ""
        Me.chkPhuongThuc.FieldType = ""
        Me.chkPhuongThuc.ItemValue = ""
        Me.chkPhuongThuc.KeyInsert = ""
        Me.chkPhuongThuc.LinkLabel = ""
        Me.chkPhuongThuc.Location = New System.Drawing.Point(31, 188)
        Me.chkPhuongThuc.Name = "chkPhuongThuc"
        Me.chkPhuongThuc.NoUpdate = ""
        Me.chkPhuongThuc.PrimaryKey = ""
        Me.chkPhuongThuc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPhuongThuc.Properties.Appearance.Options.UseFont = True
        Me.chkPhuongThuc.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkPhuongThuc.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkPhuongThuc.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkPhuongThuc.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkPhuongThuc.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkPhuongThuc.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkPhuongThuc.Properties.AutoHeight = False
        Me.chkPhuongThuc.Properties.Caption = "Danh mục phương thức"
        Me.chkPhuongThuc.Required = ""
        Me.chkPhuongThuc.Size = New System.Drawing.Size(238, 24)
        Me.chkPhuongThuc.TabIndex = 15
        Me.chkPhuongThuc.TableName = ""
        Me.chkPhuongThuc.UnCheckValue = "N"
        Me.chkPhuongThuc.UpdateIfNull = ""
        Me.chkPhuongThuc.UpdateWhenFormLock = False
        Me.chkPhuongThuc.ViewName = ""
        '
        'chkPhuongTien
        '
        Me.chkPhuongTien.AllowInsert = True
        Me.chkPhuongTien.AllowUpdate = True
        Me.chkPhuongTien.BindingSourceName = ""
        Me.chkPhuongTien.ChangeFormStatus = False
        Me.chkPhuongTien.CheckValue = "Y"
        Me.chkPhuongTien.CopyFromItem = ""
        Me.chkPhuongTien.DefaultValue = ""
        Me.chkPhuongTien.FieldName = ""
        Me.chkPhuongTien.FieldType = ""
        Me.chkPhuongTien.ItemValue = ""
        Me.chkPhuongTien.KeyInsert = ""
        Me.chkPhuongTien.LinkLabel = ""
        Me.chkPhuongTien.Location = New System.Drawing.Point(31, 157)
        Me.chkPhuongTien.Name = "chkPhuongTien"
        Me.chkPhuongTien.NoUpdate = ""
        Me.chkPhuongTien.PrimaryKey = ""
        Me.chkPhuongTien.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPhuongTien.Properties.Appearance.Options.UseFont = True
        Me.chkPhuongTien.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkPhuongTien.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkPhuongTien.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkPhuongTien.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkPhuongTien.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkPhuongTien.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkPhuongTien.Properties.AutoHeight = False
        Me.chkPhuongTien.Properties.Caption = "Danh mục phương tiện"
        Me.chkPhuongTien.Required = ""
        Me.chkPhuongTien.Size = New System.Drawing.Size(238, 24)
        Me.chkPhuongTien.TabIndex = 14
        Me.chkPhuongTien.TableName = ""
        Me.chkPhuongTien.UnCheckValue = "N"
        Me.chkPhuongTien.UpdateIfNull = ""
        Me.chkPhuongTien.UpdateWhenFormLock = False
        Me.chkPhuongTien.ViewName = ""
        '
        'chkHangHoa
        '
        Me.chkHangHoa.AllowInsert = True
        Me.chkHangHoa.AllowUpdate = True
        Me.chkHangHoa.BindingSourceName = ""
        Me.chkHangHoa.ChangeFormStatus = False
        Me.chkHangHoa.CheckValue = "Y"
        Me.chkHangHoa.CopyFromItem = ""
        Me.chkHangHoa.DefaultValue = ""
        Me.chkHangHoa.FieldName = ""
        Me.chkHangHoa.FieldType = ""
        Me.chkHangHoa.ItemValue = ""
        Me.chkHangHoa.KeyInsert = ""
        Me.chkHangHoa.LinkLabel = ""
        Me.chkHangHoa.Location = New System.Drawing.Point(31, 126)
        Me.chkHangHoa.Name = "chkHangHoa"
        Me.chkHangHoa.NoUpdate = ""
        Me.chkHangHoa.PrimaryKey = ""
        Me.chkHangHoa.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHangHoa.Properties.Appearance.Options.UseFont = True
        Me.chkHangHoa.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkHangHoa.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkHangHoa.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkHangHoa.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkHangHoa.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkHangHoa.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkHangHoa.Properties.AutoHeight = False
        Me.chkHangHoa.Properties.Caption = "Danh mục hàng hóa"
        Me.chkHangHoa.Required = ""
        Me.chkHangHoa.Size = New System.Drawing.Size(238, 24)
        Me.chkHangHoa.TabIndex = 13
        Me.chkHangHoa.TableName = ""
        Me.chkHangHoa.UnCheckValue = "N"
        Me.chkHangHoa.UpdateIfNull = ""
        Me.chkHangHoa.UpdateWhenFormLock = False
        Me.chkHangHoa.ViewName = ""
        '
        'chkNguonHang
        '
        Me.chkNguonHang.AllowInsert = True
        Me.chkNguonHang.AllowUpdate = True
        Me.chkNguonHang.BindingSourceName = ""
        Me.chkNguonHang.ChangeFormStatus = False
        Me.chkNguonHang.CheckValue = "Y"
        Me.chkNguonHang.CopyFromItem = ""
        Me.chkNguonHang.DefaultValue = ""
        Me.chkNguonHang.FieldName = ""
        Me.chkNguonHang.FieldType = ""
        Me.chkNguonHang.ItemValue = ""
        Me.chkNguonHang.KeyInsert = ""
        Me.chkNguonHang.LinkLabel = ""
        Me.chkNguonHang.Location = New System.Drawing.Point(31, 95)
        Me.chkNguonHang.Name = "chkNguonHang"
        Me.chkNguonHang.NoUpdate = ""
        Me.chkNguonHang.PrimaryKey = ""
        Me.chkNguonHang.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNguonHang.Properties.Appearance.Options.UseFont = True
        Me.chkNguonHang.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkNguonHang.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkNguonHang.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkNguonHang.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkNguonHang.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkNguonHang.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkNguonHang.Properties.AutoHeight = False
        Me.chkNguonHang.Properties.Caption = "Danh mục nguồn hàng"
        Me.chkNguonHang.Required = ""
        Me.chkNguonHang.Size = New System.Drawing.Size(238, 24)
        Me.chkNguonHang.TabIndex = 12
        Me.chkNguonHang.TableName = ""
        Me.chkNguonHang.UnCheckValue = "N"
        Me.chkNguonHang.UpdateIfNull = ""
        Me.chkNguonHang.UpdateWhenFormLock = False
        Me.chkNguonHang.ViewName = ""
        '
        'chkVanChuyen
        '
        Me.chkVanChuyen.AllowInsert = True
        Me.chkVanChuyen.AllowUpdate = True
        Me.chkVanChuyen.BindingSourceName = ""
        Me.chkVanChuyen.ChangeFormStatus = False
        Me.chkVanChuyen.CheckValue = "Y"
        Me.chkVanChuyen.CopyFromItem = ""
        Me.chkVanChuyen.DefaultValue = ""
        Me.chkVanChuyen.FieldName = ""
        Me.chkVanChuyen.FieldType = ""
        Me.chkVanChuyen.ItemValue = ""
        Me.chkVanChuyen.KeyInsert = ""
        Me.chkVanChuyen.LinkLabel = ""
        Me.chkVanChuyen.Location = New System.Drawing.Point(31, 64)
        Me.chkVanChuyen.Name = "chkVanChuyen"
        Me.chkVanChuyen.NoUpdate = ""
        Me.chkVanChuyen.PrimaryKey = ""
        Me.chkVanChuyen.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVanChuyen.Properties.Appearance.Options.UseFont = True
        Me.chkVanChuyen.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkVanChuyen.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkVanChuyen.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkVanChuyen.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkVanChuyen.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkVanChuyen.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkVanChuyen.Properties.AutoHeight = False
        Me.chkVanChuyen.Properties.Caption = "Danh mục vận chuyển"
        Me.chkVanChuyen.Required = ""
        Me.chkVanChuyen.Size = New System.Drawing.Size(238, 24)
        Me.chkVanChuyen.TabIndex = 11
        Me.chkVanChuyen.TableName = ""
        Me.chkVanChuyen.UnCheckValue = "N"
        Me.chkVanChuyen.UpdateIfNull = ""
        Me.chkVanChuyen.UpdateWhenFormLock = False
        Me.chkVanChuyen.ViewName = ""
        '
        'chkKhachHang
        '
        Me.chkKhachHang.AllowInsert = True
        Me.chkKhachHang.AllowUpdate = True
        Me.chkKhachHang.BindingSourceName = ""
        Me.chkKhachHang.ChangeFormStatus = False
        Me.chkKhachHang.CheckValue = "Y"
        Me.chkKhachHang.CopyFromItem = ""
        Me.chkKhachHang.DefaultValue = ""
        Me.chkKhachHang.FieldName = ""
        Me.chkKhachHang.FieldType = ""
        Me.chkKhachHang.ItemValue = ""
        Me.chkKhachHang.KeyInsert = ""
        Me.chkKhachHang.LinkLabel = ""
        Me.chkKhachHang.Location = New System.Drawing.Point(31, 34)
        Me.chkKhachHang.Name = "chkKhachHang"
        Me.chkKhachHang.NoUpdate = ""
        Me.chkKhachHang.PrimaryKey = ""
        Me.chkKhachHang.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKhachHang.Properties.Appearance.Options.UseFont = True
        Me.chkKhachHang.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkKhachHang.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkKhachHang.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkKhachHang.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkKhachHang.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.chkKhachHang.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkKhachHang.Properties.AutoHeight = False
        Me.chkKhachHang.Properties.Caption = "Danh mục Khách hàng"
        Me.chkKhachHang.Required = ""
        Me.chkKhachHang.Size = New System.Drawing.Size(238, 24)
        Me.chkKhachHang.TabIndex = 10
        Me.chkKhachHang.TableName = ""
        Me.chkKhachHang.UnCheckValue = "N"
        Me.chkKhachHang.UpdateIfNull = ""
        Me.chkKhachHang.UpdateWhenFormLock = False
        Me.chkKhachHang.ViewName = ""
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(414, 417)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(148, 29)
        Me.U_ButtonCus1.TabIndex = 13
        Me.U_ButtonCus1.Text = "Đồng bộ từ SAP"
        '
        'SO_PO_Type
        '
        Me.SO_PO_Type.AllowInsert = True
        Me.SO_PO_Type.AllowUpdate = True
        Me.SO_PO_Type.BindingSourceName = ""
        Me.SO_PO_Type.ChangeFormStatus = True
        Me.SO_PO_Type.CheckValue = "Y"
        Me.SO_PO_Type.CopyFromItem = ""
        Me.SO_PO_Type.DefaultValue = ""
        Me.SO_PO_Type.FieldName = ""
        Me.SO_PO_Type.FieldType = ""
        Me.SO_PO_Type.ItemValue = ""
        Me.SO_PO_Type.KeyInsert = ""
        Me.SO_PO_Type.LinkLabel = ""
        Me.SO_PO_Type.Location = New System.Drawing.Point(129, 360)
        Me.SO_PO_Type.Name = "SO_PO_Type"
        Me.SO_PO_Type.NoUpdate = ""
        Me.SO_PO_Type.PrimaryKey = ""
        Me.SO_PO_Type.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SO_PO_Type.Properties.Appearance.Options.UseFont = True
        Me.SO_PO_Type.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SO_PO_Type.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SO_PO_Type.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SO_PO_Type.Properties.AppearanceFocused.Options.UseFont = True
        Me.SO_PO_Type.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SO_PO_Type.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SO_PO_Type.Properties.AutoHeight = False
        Me.SO_PO_Type.Properties.Caption = "Danh mục SO_Type, PO_Type"
        Me.SO_PO_Type.Required = ""
        Me.SO_PO_Type.Size = New System.Drawing.Size(256, 24)
        Me.SO_PO_Type.TabIndex = 31
        Me.SO_PO_Type.TableName = ""
        Me.SO_PO_Type.UnCheckValue = "N"
        Me.SO_PO_Type.UpdateIfNull = ""
        Me.SO_PO_Type.UpdateWhenFormLock = False
        Me.SO_PO_Type.ViewName = ""
        Me.SO_PO_Type.Visible = False
        '
        'FrmDongBoSAP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 469)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rHaft)
        Me.Controls.Add(Me.rAll)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmDongBoSAP"
        Me.ShowFormMessage = True
        Me.Text = "Đồng bộ danh mục từ SAP"
        Me.Controls.SetChildIndex(Me.rAll, 0)
        Me.Controls.SetChildIndex(Me.rHaft, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ToKhai.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CongTy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HoaDon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkKho.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDonGia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Project.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkThoiHanThanhToan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGiaoNhan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTuyenDuong.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNhaCungCap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSoHoaDon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkBeXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCongTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDonViTinh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPhuongThuc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPhuongTien.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHangHoa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNguonHang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVanChuyen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkKhachHang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SO_PO_Type.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rAll As System.Windows.Forms.RadioButton
    Friend WithEvents rHaft As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSoHoaDon As U_TextBox.U_CheckBox
    Friend WithEvents chkBeXuat As U_TextBox.U_CheckBox
    Friend WithEvents chkCongTo As U_TextBox.U_CheckBox
    Friend WithEvents chkDonViTinh As U_TextBox.U_CheckBox
    Friend WithEvents chkPhuongThuc As U_TextBox.U_CheckBox
    Friend WithEvents chkPhuongTien As U_TextBox.U_CheckBox
    Friend WithEvents chkHangHoa As U_TextBox.U_CheckBox
    Friend WithEvents chkNguonHang As U_TextBox.U_CheckBox
    Friend WithEvents chkVanChuyen As U_TextBox.U_CheckBox
    Friend WithEvents chkKhachHang As U_TextBox.U_CheckBox
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents chkNhaCungCap As U_TextBox.U_CheckBox
    Friend WithEvents chkTuyenDuong As U_TextBox.U_CheckBox
    Friend WithEvents chkGiaoNhan As U_TextBox.U_CheckBox
    Friend WithEvents chkThoiHanThanhToan As U_TextBox.U_CheckBox
    Friend WithEvents chkDonGia As U_TextBox.U_CheckBox
    Friend WithEvents chkKho As U_TextBox.U_CheckBox
    Friend WithEvents Project As U_TextBox.U_CheckBox
    Friend WithEvents HoaDon As U_TextBox.U_CheckBox
    Friend WithEvents CongTy As U_TextBox.U_CheckBox
    Friend WithEvents STO As U_TextBox.U_CheckBox
    Friend WithEvents ToKhai As U_TextBox.U_CheckBox
    Friend WithEvents SO_PO_Type As U_TextBox.U_CheckBox
End Class
