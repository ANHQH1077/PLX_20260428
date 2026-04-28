
CREATE TABLE [dbo].[ztblConfigATGHeader](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FromTable] [nvarchar](50) NULL,
	[ToTable] [nvarchar](50) NULL,
	[ServerIP] [nvarchar](50) NULL,
	[DBName] [nvarchar](50) NULL,
	[sPort] [int] NULL,
	[sUser] [nvarchar](50) NULL,
	[sPass] [nvarchar](50) NULL,
 CONSTRAINT [PK_ztblConfigATGHeader] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


