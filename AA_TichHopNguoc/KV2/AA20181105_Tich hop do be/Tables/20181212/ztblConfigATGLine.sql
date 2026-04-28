

CREATE TABLE [dbo].[ztblConfigATGLine](
	[ID] [int] NOT NULL,
	[FromField] [nvarchar](50) NOT NULL,
	[ToField] [nvarchar](50) NOT NULL,
	[FieldType] [nchar](10) NOT NULL,
	[FieldKey] [nvarchar](50) NOT NULL,
	[CrDate] [datetime] NULL,
	[UpdDate] [datetime] NULL,
	[UpdUser] [nvarchar](50) NULL,
	[Client] [nvarchar](50) NULL,
 CONSTRAINT [PK_ztblConfigATG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ztblConfigATGLine] ADD  CONSTRAINT [DF_ztblConfigATG_CrDate]  DEFAULT (getdate()) FOR [CrDate]
GO


