

CREATE TABLE [dbo].[ztblTankInfor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TankCode] [nvarchar](50) NULL,
	[Plant] [nvarchar](50) NULL,
	[Description] [nvarchar](2500) NULL,
	[MinHeight] [numeric](18, 4) NULL,
	[MinVolume] [numeric](18, 4) NULL,
	[SafeHeight] [numeric](18, 4) NULL,
	[SafeVolume] [numeric](18, 4) NULL,
	[Client] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[SynDate] [datetime] NULL,
	[SynUser] [nvarchar](50) NULL,
 CONSTRAINT [PK_ztblTankInfor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ztblTankInfor] ADD  CONSTRAINT [DF_ztblTankInfor_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO


