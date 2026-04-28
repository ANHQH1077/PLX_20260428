
CREATE TABLE [dbo].[SYS_TABLEID_Hist](
	[TableID] [nvarchar](50) NULL,
	[CrdDate] [date] NOT NULL,
	[SoLenh] [nvarchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
		,CreateDate datetime
	,UpdateDate datetime
	,cStatus varchar(1)
	,SynDate datetime
	,SynStatus varchar(1)
	,Old_ID	int)
