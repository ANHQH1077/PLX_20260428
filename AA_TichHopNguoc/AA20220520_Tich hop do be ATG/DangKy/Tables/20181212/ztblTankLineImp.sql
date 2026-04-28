
--drop table [ztblTankLineImp]
CREATE TABLE [dbo].[ztblTankLineImp](
	[ID] [int] IDENTITY(1,1) NOT NULL,
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
	[MaHH] [nvarchar](100) NULL,
 CONSTRAINT [PK_ztblTankImp] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ztblTankLineImp] ADD  CONSTRAINT [DF_ztblTankImp_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A: tu dong       M: nhap tay' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ztblTankLineImp', @level2type=N'COLUMN',@level2name=N'Status'
GO


