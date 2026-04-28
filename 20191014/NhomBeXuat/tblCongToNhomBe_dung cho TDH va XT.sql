

CREATE TABLE [dbo].[tblCongToNhomBe](
	[ID] [int] NULL,
	[MeterId] [nvarchar](10) NULL,
	[Valid_from] [datetime] NULL,
	[Valid_to] [datetime] NULL,
	[Bexuat] [nvarchar](20) NULL,
	[TankGroup] [nvarchar](10) NULL,
	[TankGroup_Name] [nvarchar](140) NULL,
	[MaHangHoa] [nvarchar](18) NULL,
	[TenHangHoa] [nvarchar](40) NULL,
	[Push_TDH] [nvarchar](2) NULL,
	[Push_XTTD] [nvarchar](2) NULL,
	[User_Push_TDH] [nvarchar](120) NULL,
	[Date_Push_TDH] [datetime] NULL,
	[User_Push_XTTD] [nvarchar](120) NULL,
	[Date_Push_XTTD] [datetime] NULL,
	[CreateUser] [nvarchar](100) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]
GO


