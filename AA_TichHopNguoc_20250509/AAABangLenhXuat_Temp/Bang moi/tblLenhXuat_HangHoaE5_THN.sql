
CREATE TABLE [dbo].[tblLenhXuat_HangHoaE5_THN]([LineID] [nvarchar](6) NOT NULL,[MaLenh] [nvarchar](4) NULL,
	[NgayXuat] [datetime] NOT NULL,[SoLenh] [nvarchar](10) NULL,[TongXuat] [decimal](18, 2) NULL,
	[TongDuXuat] [decimal](18, 2) NULL,[MaHangHoa] [nvarchar](18) NULL,[DonViTinh] [nvarchar](3) NULL,
	[BeXuat] [nvarchar](20) NULL,[TableID] [nvarchar](8) NOT NULL,[MeterId] [char](4) NULL,
	[Createby] [nvarchar](30) NULL,[UpdatedBy] [nvarchar](30) NULL,[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,[QCI_KG] [decimal](18, 2) NULL,[QCI_NhietDo] [decimal](5, 2) NULL,
	[QCI_TyTrong] [decimal](10, 4) NULL,[DonGia] [decimal](18, 6) NULL,[CurrencyKey] [varchar](5) NULL,
	[VCF] [decimal](6, 4) NULL,[WCF] [decimal](6, 4) NULL,[NhietDo_BQGQ] [decimal](6, 4) NULL,
	[D15_BQGQ] [decimal](6, 4) NULL,[KG] [decimal](18, 2) NULL,[L15] [decimal](18, 2) NULL,
	[GiaCty] [decimal](18, 6) NULL,[PhiVT] [decimal](18, 6) NULL,[TheBVMT] [decimal](18, 6) NULL,
	[ChietKhau] [decimal](15, 4) NULL,[Z001_PER] [decimal](18, 3) NULL,[Z003_PER] [decimal](18, 3) NULL,
	[Z009_PER] [decimal](18, 3) NULL,[QCI_L15] [decimal](18, 2) NULL,[TongSoTien] [decimal](18, 6) NULL,
	[BatchNum] [nvarchar](200) NULL,[NhomBeXuat] [nvarchar](20) NULL,[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tblLenhXuat_HangHoaE5_THN] PRIMARY KEY CLUSTERED 
([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
	ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]


