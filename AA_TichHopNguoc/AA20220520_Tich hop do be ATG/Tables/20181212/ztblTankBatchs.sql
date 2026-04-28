
CREATE TABLE [dbo].[ztblTankBatchs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TankCode] [nvarchar](50) NULL,
	[BatchNum] [nvarchar](500) NULL,
	[Add_Content] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[CrUser] [nvarchar](50) NULL,
	[UpdDate] [datetime] NULL,
	[UpdUser] [nvarchar](50) NULL,
	[Desc] [nvarchar](2000) NULL,
 CONSTRAINT [PK_ztblTankBatchs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ztblTankBatchs] ADD  CONSTRAINT [DF_ztblTankBatchs_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO


