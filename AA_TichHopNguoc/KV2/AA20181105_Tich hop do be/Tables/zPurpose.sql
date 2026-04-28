

CREATE TABLE [dbo].[zPurpose](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](1500) NULL,
	[Status] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[SynDate] [datetime] NULL,
	[SynUser] [nvarchar](50) NULL,
 CONSTRAINT [PK_zPurpose] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[zPurpose] ADD  CONSTRAINT [DF_zPurpose_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO


