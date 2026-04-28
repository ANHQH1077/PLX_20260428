
--drop table tblChungTuLine

CREATE TABLE [dbo].[tblChungTuLine](
	[SoLenh] [nvarchar](20) NOT NULL,
	[TableID] [nvarchar](200) NOT NULL,
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
	[DonGia] [decimal](18, 4) NULL,
	[TongTIen] [decimal](18, 2) NULL,
	[KeyCode] [nvarchar](50) NULL,
	[MaVanChuyen] [nvarchar](50) NULL,
	[XITEC_OPTION] [nvarchar](50) NULL,
	[ChietKhau] [decimal](10, 4) NULL,
	[NgayXuat] [datetime] NULL,
	[MaLenh] [nvarchar](10) NULL,
	[LoaiTien] [nvarchar](50) NULL,
	[SoLuong] [decimal](18, 2) NULL,
	[Row_ID] [int] IDENTITY(1,1) NOT NULL,
	[LoaiChungTu] [nvarchar](100) NOT NULL,
	[SoGhiNhan] [decimal](18, 0) NULL,
	[SoLuong2] [decimal](18, 0) NULL,
	[L15_2] [decimal](18, 0) NULL,
	[KG_2] [decimal](18, 0) NULL,
	[TongSoTien] [decimal](18, 6) NULL,
 CONSTRAINT [PK_tblChungTuLine_1] PRIMARY KEY CLUSTERED 
(
	[SoLenh] ASC,
	[TableID] ASC,
	[LoaiChungTu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


