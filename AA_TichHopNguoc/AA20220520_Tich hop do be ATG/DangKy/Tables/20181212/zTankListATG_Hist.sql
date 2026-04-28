

CREATE TABLE [dbo].[zTankListATG_Hist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TankCode] [nvarchar](50) NULL,
	[Product] [nvarchar](50) NULL,
	[CrDate] [datetime] NULL,
	[CrUser] [nvarchar](50) NULL,
	[Client] [nvarchar](50) NULL,
	[Status] [nvarchar](10) NULL,
	[DateHist] [datetime] NULL
) ON [PRIMARY]
GO


