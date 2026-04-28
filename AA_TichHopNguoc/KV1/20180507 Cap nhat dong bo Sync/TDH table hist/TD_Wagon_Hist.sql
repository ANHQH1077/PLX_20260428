
CREATE TABLE [dbo].[TD_Wagon_Hist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_LenhXuat] [int]  NOT NULL,
	[SoLenh] [nvarchar](10) NULL,
	[LineID] [nvarchar](6) NULL,
	[Ma_lenh] [nvarchar](4) NULL,
	[Ngay_ctu] [datetime] NULL,
	[Ma_ngan] [nvarchar](2) NULL,
	[Ma_hhoa] [nvarchar](7) NULL,
	[So_ptien] [nchar](20) NULL,
	[Sl_preset] [real] NULL,
	[Sl_ltt] [real] NULL,
	[Nhiet_do] [real] NULL,
	[Thoigiandau] [datetime] NULL,
	[Thoigiancuoi] [datetime] NULL,
	[Ma_hong] [nchar](10) NULL,
	[Trang_thai] [nchar](2) NULL,
	[sl_llkebd] [int] NULL,
	[sl_llkekt] [int] NULL
	,CreateDate datetime
	,UpdateDate datetime
	,cStatus varchar(1)
	,SynDate datetime
	,SynStatus varchar(1))