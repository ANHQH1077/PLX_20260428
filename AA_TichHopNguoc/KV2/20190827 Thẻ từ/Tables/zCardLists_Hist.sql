

CREATE TABLE [dbo].[zCardLists_Hist](
	[CardNum] [nvarchar](150)  NULL,
	[CardData] [nvarchar](150)  NULL,
	[sDesc] [nvarchar](1150) NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Status] [nvarchar](5) NULL,
	[Createby] [nvarchar](150) NULL,
	[UpdatedBy] [nvarchar](150) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL 
	,cType nvarchar(10)
	,cDate datetime )

