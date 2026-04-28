
CREATE TABLE [dbo].[Sys_tableid_old_Hist](
	[SoLenh] [nvarchar](50) NULL,
	[MaxTable] [int] NULL,
	[NgayXuat] [datetime] NULL,
	[ID] int  NOT NULL
	,CreateDate datetime
	,UpdateDate datetime
	,cStatus varchar(1)
	,SynDate datetime
	,SynStatus varchar(1)
) 
