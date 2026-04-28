
drop table tblPhuongThucXuat
CREATE TABLE [dbo].[tblPhuongThucXuat](
	[TenPhuongThucXuat] [nvarchar](200) NULL,
	[Status] [char](2) NULL,
	[Ma_Map] [nvarchar](50) NULL,
	[BWART] [nvarchar](50) NULL,
	[VTWEG] [nvarchar](50) NULL,
	[MaPhuongThucXuat] [nvarchar](20) NULL,
	[BSART] [nvarchar](50) NULL,
	[sDefault] [nvarchar](1) NULL
) ON [PRIMARY]
