
CREATE TABLE [dbo].[zTankListATG_M](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TankCode] [nvarchar](50) NULL,	
	[CrDate] [datetime] NULL,
	[CrUser] [nvarchar](50) NULL,
	---[Client] [nvarchar](50) NULL,
	Upđate datetime
	,UpdUser nvarchar(500)
	,FromDate datetime
	,ToDate datetime
 CONSTRAINT [PK_zTankListATG_M] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

