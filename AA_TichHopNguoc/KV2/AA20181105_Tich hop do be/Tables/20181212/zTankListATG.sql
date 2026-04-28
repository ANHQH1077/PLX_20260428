
CREATE TABLE [dbo].[zTankListATG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TankCode] [nvarchar](50) NULL,
	[Product] [nvarchar](50) NULL,
	[CrDate] [datetime] NULL,
	[CrUser] [nvarchar](50) NULL,
	[Client] [nvarchar](50) NULL,
 CONSTRAINT [PK_zTankListATG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


