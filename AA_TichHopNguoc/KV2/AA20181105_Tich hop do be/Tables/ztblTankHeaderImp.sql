
CREATE TABLE [dbo].[ztblTankHeaderImp](
	[TankHeaderCode] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Client] [nvarchar](50) NULL,
	[Tankcode] [nvarchar](2500) NULL,
	[PurposeCode] [nvarchar](2500) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_ztblTankHeaderImp] PRIMARY KEY CLUSTERED 
(
	[TankHeaderCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ztblTankHeaderImp] ADD  CONSTRAINT [DF_ztblTankHeaderImp_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO


