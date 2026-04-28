

CREATE TABLE [dbo].[ztblTankHeaderImp_Hist](
	[TankHeaderCode] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Client] [nvarchar](50) NULL,
	[Tankcode] [nvarchar](2500) NULL,
	[PurposeCode] [nvarchar](2500) NULL,
	[Status] [nvarchar](50) NULL,
	[CreateUser] [nvarchar](50) NULL,
	[DocEntry] [int] IDENTITY(1,1) NOT NULL,
	[sType] [nvarchar](50) NULL,
	[crDate] [datetime] NULL,
	[App_User] [nvarchar](50) NULL,
	[App_Date] [datetime] NULL,
	[TankList] [nvarchar](2000) NULL,
	[SyncUser] [nvarchar](50) NULL,
	[SyncDate] [datetime] NULL,
	[sStatus] [nvarchar](50) NULL,
	[sUser] [nvarchar](50) NULL,
	[dDate] [datetime] NULL
) ON [PRIMARY]
GO


