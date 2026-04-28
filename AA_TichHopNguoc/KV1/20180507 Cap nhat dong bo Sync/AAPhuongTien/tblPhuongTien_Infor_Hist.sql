
CREATE TABLE [dbo].[tblPhuongTien_Infor_Hist](
	[IDNumber] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int]  NOT NULL,
	[MaPhuongTien] [nvarchar](50) NULL,
	[NoiDung] [nvarchar](500) NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[sType] [nvarchar](5) NULL
	,cStatus varchar(1)
	,SynDate datetime
	,SynStatus  varchar(1)
	,CrdDate datetime)
 


