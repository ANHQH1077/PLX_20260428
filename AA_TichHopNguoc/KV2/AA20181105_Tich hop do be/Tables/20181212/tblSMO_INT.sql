
CREATE TABLE [dbo].[tblSMO_INT](
	[SoLenh] [nvarchar](10) NOT NULL,
	[MaPhuongTien] [nvarchar](20) NULL,
	[TrangThai_SMO] [nvarchar](10) NULL,
	NgayVaoKho	datetime,
	NguoiLaiXe nvarchar(500)
	,SoChuyen int
 CONSTRAINT [PK_tblSMO_INT] PRIMARY KEY CLUSTERED 
(
	[SoLenh] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

