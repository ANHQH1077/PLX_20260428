

--drop table zTankListATG_M_HIST 
CREATE TABLE [dbo].[zTankListATG_M_HIST](
	[ID] [int] NULL,
	[TankCode] [nvarchar](50) NULL,
	[CrDate] [datetime] NULL,
	[CrUser] [nvarchar](50) NULL,
	[UpdDate] [datetime] NULL,
	[UpdUser] [nvarchar](500) NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[sStatus] [nvarchar](10) NULL,
	[dDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[Createby] [nvarchar](100) NULL,
	[Product] [nvarchar](100) NULL
) ON [PRIMARY]
GO


