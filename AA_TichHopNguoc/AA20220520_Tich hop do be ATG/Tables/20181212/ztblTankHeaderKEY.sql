
CREATE TABLE [dbo].[ztblTankHeaderKEY](
	[ID] [uniqueidentifier] NOT NULL,
	[Crdate] [datetime] NULL,
	[CrUser] [nvarchar](50) NULL,
	[NumID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ztblTankHeaderKEY_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ztblTankHeaderKEY] ADD  CONSTRAINT [DF_ztblTankHeaderKEY_ID]  DEFAULT (newid()) FOR [ID]
GO

ALTER TABLE [dbo].[ztblTankHeaderKEY] ADD  CONSTRAINT [DF_ztblTankHeaderKEY_Crdate]  DEFAULT (getdate()) FOR [Crdate]
GO


