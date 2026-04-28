
--Drop table zTankListATG_M
CREATE TABLE [dbo].[zTankListATG_M](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TankCode] [nvarchar](50) NULL,
	[CrDate] [datetime] NULL,
	[CrUser] [nvarchar](50) NULL,
	[UpdDate] [datetime] NULL,
	[UpdUser] [nvarchar](500) NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[Createby] [nvarchar](100) NULL,
	[Product] [nvarchar](100) NULL,
 CONSTRAINT [PK_zTankListATG_M] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zTankListATG_M] ADD  CONSTRAINT [DF_zTankListATG_M_CrDate]  DEFAULT (getdate()) FOR [CrDate]
GO


