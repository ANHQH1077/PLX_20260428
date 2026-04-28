
--drop table [ztblTankLineImp_Hist] 
CREATE TABLE [dbo].[ztblTankLineImp_Hist](
	[ID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CrDate] [datetime] NULL,
	[TankCode] [nvarchar](50) NULL,
	[ProductCode] [nvarchar](50) NULL,
	[TankHeight] [numeric](18, 4) NULL,
	[TankTemp] [numeric](18, 4) NULL,
	[PurposeCode] [nvarchar](50) NULL,
	[SynDate] [datetime] NULL,
	[SynUser] [nvarchar](50) NULL,
	[SAPSynStatus] [nvarchar](50) NULL,
	[SAPSynUser] [nvarchar](50) NULL,
	[SAPSynDate] [datetime] NULL,
	[Client] [nvarchar](50) NULL,
	[Dens] [numeric](18, 4) NULL,
	[VolumnL] [numeric](18, 2) NULL,
	[VCF] [numeric](18, 4) NULL,
	[VolumnL15] [numeric](18, 2) NULL,
	[VolumnKG] [numeric](18, 2) NULL,
	[Description] [nvarchar](2500) NULL,
	[Status] [nvarchar](50) NULL,
	[X] [nvarchar](50) NULL,
	[TankHeaderCode] [nvarchar](50) NOT NULL,
	[Ltt] [numeric](18, 2) NULL,
	[TankMap] [nvarchar](50) NULL,
	[WCF] [numeric](18, 4) NULL,
	[SyncDate1] [datetime] NULL,
	[SyncUser1] [nvarchar](50) NULL,
	[SyncStatus1] [nvarchar](50) NULL,
	[SyncSDesc1] [nvarchar](1500) NULL,
	[sStatus] [nvarchar](50) NULL,
	[sUser] [nvarchar](50) NULL,
	[dDate] [datetime] NULL
) ON [PRIMARY]
GO


