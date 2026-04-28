

CREATE TABLE [dbo].[zCardLists](
	ID int Identity (1,1) not null,
	[CardNum] [nvarchar](150) NOT NULL,
	[CardData] [nvarchar](150) NOT NULL,
	[sDesc] [nvarchar](1150) NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Status] [nvarchar](5) NULL,
	[Createby] [nvarchar](150) NULL,
	[UpdatedBy] [nvarchar](150) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_zCardLists] PRIMARY KEY CLUSTERED 
(
	[CardNum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


