
CREATE TABLE [dbo].[tblLenhXuatChiTietE5_THN]([MaNgan] [nvarchar](3) NOT NULL,[MaLenh] [nvarchar](4) NULL,
	[NgayXuat] [datetime] NOT NULL,[LineID] [nvarchar](6) NOT NULL,[SoLuongDuXuat] [decimal](18, 2) NULL,
	[SoLuongThucXuat] [decimal](18, 2) NULL,[ThoiGianDau] [datetime] NULL,[ThoiGianCuoi] [datetime] NULL,
	[Sl_llkebd] [decimal](18, 2) NULL,[Sl_llkekt] [decimal](18, 2) NULL,[HeSo_k] [decimal](6, 4) NULL,
	[NhietDo] [decimal](5, 2) NULL,[TyTrong_15] [decimal](6, 4) NULL,[MaDanXuat] [nvarchar](2) NULL,
	[MaLoi] [nvarchar](6) NULL,[TrangThai] [nvarchar](2) NULL,[MaLuuLuongKe] [nvarchar](30) NULL,
	[MaEntry] [decimal](6, 0) NULL,[MaLo] [decimal](6, 0) NULL,[GhiChu] [nvarchar](50) NULL,[Status] [char](2) NULL,
	[ERate] [nvarchar](6) NULL,[Createby] [nvarchar](30) NULL,[UpdatedBy] [nvarchar](30) NULL,[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,[DungTichNgan] [int] NULL,[TableID] [varchar](8) NULL,[MaTuDongHoa] [varchar](8) NULL,
	[Row_id] [int] IDENTITY(1,1) NOT NULL,[PhuongTien] [nvarchar](50) NULL,[Record_Status] [nvarchar](50) NULL,
	[SO_TT] [int] NULL,[FlagTankLine] [nvarchar](1) NULL,[GST_TDH] [decimal](18, 2) NULL,[CardNum] [nvarchar](100) NULL,
	[CardData] [nvarchar](100) NULL,[BatchNum] [nvarchar](100) NULL,[L15] [decimal](18, 3) NULL,
	[KG] [decimal](18, 3) NULL,[BQGQ_NhietDo] [decimal](18, 2) NULL,[BQGQ_D15] [decimal](18, 4) NULL,
	[VCF] [decimal](18, 4) NULL,[WCF] [decimal](18, 4) NULL,[NhomBeXuat] [nvarchar](20) NULL,
	[BeXuat] [nvarchar](20) NULL,[ThongTinTDH] [nvarchar](20) NULL,[NhietDoXe] [decimal](5, 2) NULL,SoLenhLine varchar(20) NULL,
 CONSTRAINT [PK_tblLenhXuatChiTietE5_THN] PRIMARY KEY CLUSTERED 
([Row_id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON,
	OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]) ON [PRIMARY] 


