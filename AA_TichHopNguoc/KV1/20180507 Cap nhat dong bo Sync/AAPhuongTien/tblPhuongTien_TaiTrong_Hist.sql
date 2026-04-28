

CREATE TABLE [dbo].[tblPhuongTien_TaiTrong_Hist](
	[IDNumber] [int] IDENTITY(1,1) NOT NULL,
	[MaPhuongTien] [nvarchar](50) NULL,
	[ID] [int] NOT NULL,
	[TuNgay] [datetime] NULL,
	[DenNgay] [datetime] NULL,
	[TaiTrong] [numeric](18, 0) NULL,
	[Createby] [nvarchar](50) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL
	,cStatus varchar(1)
	,SynDate datetime
	,SynStatus  varchar(1)
	,CrdDate datetime)