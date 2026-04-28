
--drop table tblChungTuLineHuy

CREATE TABLE [dbo].[tblChungTuLineHuy](
	[SoLenh] [nvarchar](20) NULL,
	[TableID] [nvarchar](200) NULL,
	[LineID] [nvarchar](20) NULL,
	[MaHangHoa] [nvarchar](100) NULL,
	[TenHangHoa] [nvarchar](2000) NULL,
	[DonViTinh] [nvarchar](10) NULL,
	[SoLuongDuXuat] [decimal](18, 2) NULL,
	[SoLuongThucXuat] [decimal](18, 2) NULL,
	[L15] [decimal](18, 2) NULL,
	[KG] [decimal](18, 2) NULL,
	[VCF] [decimal](6, 4) NULL,
	[WCF] [decimal](6, 4) NULL,
	[NhietDo] [decimal](8, 2) NULL,
	[TyTrong] [decimal](6, 4) NULL,
	[DonGia] [decimal](18, 6) NULL,
	[TongTIen] [decimal](18, 2) NULL,
	[KeyCode] [nvarchar](50) NULL,
	[MaVanChuyen] [nvarchar](50) NULL,
	[XITEC_OPTION] [nvarchar](50) NULL,
	[ChietKhau] [decimal](18, 6) NULL,
	[NgayXuat] [datetime] NULL,
	[MaLenh] [nvarchar](10) NULL,
	[Row_ID] [int] IDENTITY(1,1) NOT NULL,
	[LoaiTien] [nvarchar](50) NULL,
	[SoLuong] [decimal](18, 2) NULL,
	[LoaiChungTu] [nvarchar](100) NULL,
	[SoGhiNhan] [decimal](18, 0) NULL,
	[SoLuong2] [decimal](18, 0) NULL,
	[L15_2] [decimal](18, 0) NULL,
	[KG_2] [decimal](18, 0) NULL
) ON [PRIMARY]
GO

