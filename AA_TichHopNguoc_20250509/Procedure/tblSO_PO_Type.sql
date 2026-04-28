

CREATE TABLE [dbo].[tblSO_PO_Type](
	[Code] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](2550) NULL,
	[Status] [nvarchar](50) NULL,
	[sDesc] [nvarchar](2550) NULL,
	[sType] [nvarchar](2550) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](150) NULL,
	[UpdatedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_tblSO_PO_Type] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


