
CREATE TABLE [dbo].[tblSyncHistErr](
	[TableName] [nvarchar](50) NULL,
	[ErrorNumber] [nvarchar](50) NULL,
	[ErrorMessage] [nvarchar](2000) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatDate] [datetime] NULL,
	[ObjText] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblSyncHistErr] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

